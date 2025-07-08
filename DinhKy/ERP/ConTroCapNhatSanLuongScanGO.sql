--update RFID_TempAssembly every hour Null -> N
UPDATE RFID_TempAssembly
SET status = 'N'
WHERE status IS NULL;

-- while loop
DECLARE @DDBH VARCHAR(20), @QTY INT, @ID VARCHAR(20), @SIZE VARCHAR(6), @Codebar VARCHAR(20);

-- 定義游標 
DECLARE data_cursor CURSOR FOR 
	SELECT distinct S.DDBH, SUM(S.QTY) AS QTY, S.ID, S.SIZE,SS.CODEBAR 
			FROM RFID_TempAssembly S LEFT join smddss_test SS on S.DDBH = SS.DDBH and  S.SIZE = SS.XXCC
			WHERE status = 'N' 
				AND S.DDBH = SS.DDBH
				and S.SIZE=SS.XXCC
				and SS.GXLB='A'
				and SS.CTS>SS.okCTS
			--and s.DDBH='JHS2502-152-001'
	GROUP BY S.DDBH, S.ID, S.SIZE,SS.CODEBAR;
-- 打開游標 
OPEN data_cursor;
-- 讀取第一行數據到變量中 
FETCH NEXT FROM data_cursor INTO @DDBH, @QTY, @ID, @size, @codebar;
-- 繼續迴圈直到游標中沒有更多數據 
WHILE @@FETCH_STATUS = 0
BEGIN
     --更新 SMDDSS 
    UPDATE S
    SET S.okCTS = CASE 
                    WHEN S.okCTS + @QTY > S.CTS THEN S.CTS 
                    ELSE S.okCTS + @QTY 
                  END,
        S.ScanSDate = ISNULL(S.ScanSDate, GETDATE()),
        S.ScanEDate = GETDATE()
    FROM smddss_test S
    WHERE S.CTS > S.okCTS
      AND S.DDBH = @DDBH
      AND S.GXLB = 'A'
	  and s.XXCC=@SIZE;
		IF EXISTS (SELECT CODEBAR 
				FROM smzl_test 
				WHERE CODEBAR = @Codebar and SB is NULL 
				and DepNO =@ID
					AND CONVERT(VARCHAR, USERDATE, 111) = CONVERT(VARCHAR, GETDATE(), 111))
	BEGIN
		-- 如果數據存在，進行更新
		UPDATE SMZL
		SET SMZL.CTS = SMZL.CTS + @QTY 
		FROM smzl_test SMZL
		WHERE CODEBAR = @Codebar and SB is NULL 
		and DepNO =@ID ;
	END
	ELSE
	BEGIN
		-- 如果數據不存在，進行插入
		INSERT INTO smzl_test (CODEBAR, CTS, DepNO, ScanDate, USERDATE, USERID, YN, SB)
		VALUES (@Codebar, @QTY, @ID, GETDATE(), GETDATE(), 'SYSTEM', 1, NULL);
	END

     --獲取下一個 data_cursor 的數據
    FETCH NEXT FROM data_cursor INTO @DDBH, @QTY, @ID, @SIZE,@codebar;
END

-- 關閉並釋放 data_cursor
CLOSE data_cursor;
DEALLOCATE data_cursor;

 --更新 RFID_TempAssembly 的狀態
UPDATE RFID_TempAssembly
SET status = 'Y'
WHERE status = 'N';