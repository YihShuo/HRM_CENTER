==========================================================Code BACKUP và RESTORE Da=========================================
--B1: Đọc thông tin file cần restorec để xác nhận LogicName và Đường dẫn các mdf và ldf
		RESTORE FILELISTONLY 
		FROM DISK = 'C:\LYS_ERP_FULL_2025-10-09 11-04-32.bak';
		GO

--B2: Ngắt kết nối và set database sang chế độ SINGLE_USER
		ALTER DATABASE LYS_ERP SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		GO

--B3:Phục Hồi FULL------------------Tùy Chọn Xem Phục Hồi Mới Hay Phục Hồi Chép Đè--------------------
		-- Nếu DB CHƯA tồn tại:
		RESTORE DATABASE LYS_ERP
		FROM DISK = 'C:\LYS_ERP_FULL_2025-10-09 11-04-32.bak'
		WITH 
		MOVE 'LIY_ERP_Data'     TO 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LIY_ERP.mdf',
		MOVE 'LIY_ERP_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LYS_ERP.ldf',
		NORECOVERY,        -- giữ trạng thái để nạp tiếp DIFF/LOG
		STATS = 5;
		GO



		-- Nếu DB ĐÃ tồn tại và muốn ghi đè:
		RESTORE DATABASE LYS_ERP
		FROM DISK = 'C:\LYS_ERP_FULL_2025-10-09 11-04-32.bak'
		WITH 
		MOVE 'LIY_ERP_Data' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LYS_ERP.mdf',
		MOVE 'LIY_ERP_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LYS_ERP.ldf',
		REPLACE,             -- Thêm REPLACE để ghi đè DB cũ
		NORECOVERY,        -- giữ trạng thái để nạp tiếp DIFF/LOG
		STATS = 5;

--B3:Phục Hồi DIFF chỉ cần chọn DIFF thuộc FULL trước gần nó nhất là được, không cần phục hồi hết các Diff trước nó

		RESTORE DATABASE LYS_ERP
		FROM DISK = 'C:\LYS_ERP_DIFF_2025-10-10 03-00-00.bak'
		WITH NORECOVERY, STATS = 5;
		GO

--B4:Phục Hồi LOG  phải phục hồi tấc cả các Log từ Diff gần Log cần phục hồi nhất rồi mới tới Log cần phục hồi

		RESTORE LOG LYS_ERP
		FROM DISK = 'C:\LYS_ERP_LOG_2025-10-10_033000.trn'
		WITH NORECOVERY;
		GO

		RESTORE LOG LYS_ERP
		FROM DISK = 'C:\LYS_ERP_LOG_2025-10-10_040000.trn'
		WITH STOPAT = '2025-10-10T03:38:00',  -- bỏ dòng này nếu muốn tới cuối file log
		RECOVERY, STATS = 5;
		GO
		
--B5: Kết thúc chế độ NORECOVERY và đưa cơ sở dữ liệu vào trạng thái ONLINE (Nếu trước đó chưa đưa)
		RESTORE DATABASE LYS_ERP WITH RECOVERY;
		GO			
--B6: Chuyển database về chế độ MULTI_USER
ALTER DATABASE LYS_ERP SET MULTI_USER;
GO

------Scrip xem các LSN
RESTORE HEADERONLY 
FROM DISK = 'C:\LYS_ERP_FULL_2025-10-09 11-04-32.bak';
RESTORE HEADERONLY 
FROM DISK = 'C:\LYS_ERP_DIFF_2025-10-10 03-00-00.bak';
RESTORE HEADERONLY 
FROM DISK = 'C:\LYS_ERP_LOG_2025-10-10_030000.trn';
RESTORE HEADERONLY 
FROM DISK = 'C:\LYS_ERP_LOG_2025-10-10_033000.trn';
RESTORE HEADERONLY 
FROM DISK = 'C:\LYS_ERP_LOG_2025-10-10_040000.trn';

-- Xem lịch sử Backup
SELECT backup_finish_date,  type
FROM msdb.dbo.backupset
WHERE type = 'L' AND database_name = 'LYS_ERP'
ORDER BY backup_finish_date;
------------------------------------------------------------------------------------