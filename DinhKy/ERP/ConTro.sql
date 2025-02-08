--update RFID_TempStitching every hour Null -> N
UPDATE RFID_TempStitching
SET status = 'N'
WHERE status IS NULL;

-- while loop
DECLARE @DDBH VARCHAR(20), @QTY INT, @ID VARCHAR(20), @SIZE VARCHAR(6), @Codebar VARCHAR(20);

-- 定義游標  -游标的定义
DECLARE data_cursor CURSOR FOR 
SELECT DDBH, SUM(QTY) AS QTY, ID, SIZE 
FROM RFID_TempStitching 
WHERE status = 'N' 
GROUP BY DDBH, ID, SIZE;

-- 打開游標  打开游标
OPEN data_cursor;

-- 讀取第一行數據到變量中 --读取第一行数据到变量中 - Dọc dòng dữ liệu đầu tiên vào biến
FETCH NEXT FROM data_cursor INTO @DDBH, @QTY, @ID, @SIZE;

-- 繼續迴圈直到游標中沒有更多數據  -- 继续循环直到游标中没有更多数据 Tiếp tục vòng lặp cho đến khi con trỏ không còn dữ liệu
WHILE @@FETCH_STATUS = 0
				BEGIN
					-- 更新 SMDDSS 
					UPDATE S
					SET S.okCTS = CASE 
									WHEN S.okCTS + @QTY > S.CTS THEN S.CTS 
									ELSE S.okCTS + @QTY 
								  END,
						S.ScanSDate = ISNULL(S.ScanSDate, GETDATE()),
						S.ScanEDate = GETDATE()
					FROM [LYS_ERP].[dbo].[SMDDSS] S
					WHERE S.CTS > S.okCTS
					  AND S.DDBH = @DDBH
					  AND s.XXCC = @SIZE
					  AND S.GXLB = 'S';

					-- 保留 CodeBar 信息
					DECLARE Codebar_cursor CURSOR FOR 
					SELECT CODEBAR 
					FROM [LYS_ERP].[dbo].[SMDDSS]
					WHERE DDBH = @DDBH;  

					-- 打開 Codebar_cursor
					OPEN Codebar_cursor;
					-- 讀取 Codebar_cursor 的數據
					FETCH NEXT FROM Codebar_cursor INTO @Codebar;

					-- 當 Codebar_cursor 有更多數據時，進行處理 当 Codebar_cursor 有更多数据时，进行处理
					--Khi con trỏ Codebar_cursor có thêm dữ liệu, tiến hành xử lý
					WHILE @@FETCH_STATUS = 0
										BEGIN
											-- 更新或插入 SMZL 表  更新或插入 SMZL 表
											IF EXISTS (SELECT CODEBAR 
													   FROM [LYS_ERP].[dbo].[SMZL] 
													   WHERE CODEBAR = @Codebar 
														 AND CONVERT(VARCHAR, USERDATE, 111) = CONVERT(VARCHAR, GETDATE(), 111))
											BEGIN
												-- 如果數據存在，進行更新 --如果数据存在，进行更新
												UPDATE SMZL
												SET SMZL.CTS = SMZL.CTS + @QTY 
												FROM [LYS_ERP].[dbo].[SMZL] SMZL
												WHERE CODEBAR = @Codebar;
											END
											ELSE
											BEGIN
												-- 如果數據不存在，進行插入 --如果数据不存在，进行插入
												INSERT INTO [LYS_ERP].[dbo].[SMZL] (CODEBAR, CTS, DepNO, ScanDate, USERDATE, USERID, YN, SB)
												VALUES (@Codebar, @QTY, @ID, GETDATE(), GETDATE(), 'SYSTEM', 1, NULL);
											END

											-- 獲取下一個 Codebar_cursor 的數據 --获取下一个 Codebar_cursor 的数据
											FETCH NEXT FROM Codebar_cursor INTO @Codebar;
										END

					-- 關閉並釋放 Codebar_cursor --关闭并释放 Codebar_cursor
					CLOSE Codebar_cursor;
					DEALLOCATE Codebar_cursor;

					-- 獲取下一個 data_cursor 的數據 --获取下一个 data_cursor 的数据
					FETCH NEXT FROM data_cursor INTO @DDBH, @QTY, @ID, @SIZE;
				END

-- 關閉並釋放 data_cursor
CLOSE data_cursor;
DEALLOCATE data_cursor;

-- 更新 RFID_TempStitching 的狀態 --更新 RFID_TempStitching 的状态
UPDATE RFID_TempStitching 
SET status = 'Y'
WHERE status = 'N';


