     -----------------------------------更新 RFID_TempStitching (Status) -------------------------------------
--update RFID_TempStitching every hour Null -> N
UPDATE RFID_TempStitching
SET status = 'N'
WHERE status IS NULL;

-- while loop
DECLARE @DDBH VARCHAR(20), @QTY INT, @ID VARCHAR(20), @SIZE VARCHAR(6), @Codebar VARCHAR(20),@Userdate SMALLDATETIME;

-- 定义游标 - Định nghĩa con trỏ 
DECLARE data_cursor CURSOR FOR 
	/*Lấy ra từ bàng RFID_TempStitching có điều kiện là 
									Status = 'NULL' (tức là dòng mới quét RFID và đưa được Agent cập nhật)
									sản lượng scan của chuyền May
									smddss_test chưa scan đủ */
	SELECT distinct S.DDBH, SUM(S.QTY) AS QTY, S.ID, S.SIZE,SS.CODEBAR,S.Userdate
	FROM RFID_TempStitching S LEFT	JOIN smddss_test SS on S.DDBH = SS.DDBH 
													   AND  S.SIZE = SS.XXCC
	WHERE status = 'N' 
		and S.SIZE=SS.XXCC
		and SS.GXLB='S'
		and SS.CTS>SS.okCTS
	GROUP BY S.DDBH, S.ID, S.SIZE,SS.CODEBAR;
-- 打开游标 - Mở con trỏ 
OPEN data_cursor;
-- 读取第一行数据到变量中 - Đọc dòng dữ liệu đầu tiên vào biến 
FETCH NEXT FROM data_cursor INTO @DDBH, @QTY, @ID, @size, @codebar,@Userdate;
-- 继续循环直到游标中没有更多数据 - tiếp tục vòng lặp đến khi không còn dữ liệu trong con trỏ
WHILE @@FETCH_STATUS = 0
BEGIN
     -----------------------------------更新 SMDDSS -------------------------------------
	 /*Cập nhật smddss_test các đơn hàng của RFID_TempStitching ở bảng lọc trên nội dung
			Cộng dồn okCTS từ số lượng scan QTY */
    UPDATE S
    SET S.okCTS = CASE 
                    WHEN S.okCTS + @QTY > S.CTS THEN S.CTS 
                    ELSE S.okCTS + @QTY 
                  END,
        S.ScanSDate = ISNULL(S.ScanSDate, GETDATE()),
        S.ScanEDate = @Userdate 
    FROM smddss_test S
    WHERE S.CTS > S.okCTS
      AND S.DDBH = @DDBH 
      AND S.GXLB = 'S'
	  and s.XXCC=@SIZE;
	-----------------------------------更新 smzl_test ------------------------------------
	IF EXISTS (SELECT CODEBAR 
				FROM smzl_test 
				WHERE CODEBAR = @Codebar and SB is NULL 
				and DepNO =@ID
					AND CONVERT(VARCHAR, USERDATE, 111) = CONVERT(VARCHAR, GETDATE(), 111))
		BEGIN
			-- 如果数据存在，进行更新 - Nếu số liệu tồn tại, tiến hành cập nhật
			UPDATE SMZL
			SET SMZL.CTS = SMZL.CTS + @QTY ,
				SMZL.USERDATE = @Userdate
			FROM smzl_test SMZL
			WHERE CODEBAR = @Codebar and SB is NULL 
			and DepNO =@ID ;
		END
	ELSE
		BEGIN
			-- 如果数据不存在，进行插入 - Nếu số liệu không tồn tại tiến hành chèn vào
			INSERT INTO smzl_test (CODEBAR, CTS, DepNO, ScanDate, USERDATE, USERID, YN, SB)
			VALUES (@Codebar, @QTY, @ID, GETDATE(), @Userdate, 'SYSTEM', 1, NULL);
		END

     --获取下一个 data_cursor 的数据 - Lấy dữ liệu tiếp theo từ con trỏ
    FETCH NEXT FROM data_cursor INTO @DDBH, @QTY, @ID, @SIZE,@codebar;
END

-- 关闭并释放 data_cursor - Đóng và giải phóng con trỏ
CLOSE data_cursor;
DEALLOCATE data_cursor;
    -----------------------------------更新 RFID_TempStitching (Status) -------------------------------------
--更新 RFID_TempStitching 的状态
UPDATE RFID_TempStitching
SET status = 'Y'
WHERE status = 'N';