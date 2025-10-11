--==========================================================Code BACKUP và RESTORE Da=========================================
--B1: Đọc thông tin file cần restorec để xác nhận LogicName và Đường dẫn các mdf và ldf
	RESTORE FILELISTONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_FULL_2025-10-19 01-00-00.bak';
	GO
	RESTORE FILELISTONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_LOG_2025-10-18_130000.trn';
	GO
	------------------------------------------FILE Cần FULL RESTORE---------------------------------------
	RESTORE HEADERONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_FULL_2025-10-19 01-00-00.bak';
	--Xem lịch sử Restore FULL gần nhất (không-COPY_ONLY)
	SELECT TOP 5 type,is_copy_only,backup_finish_date,checkpoint_lsn,backup_set_uuid
	FROM msdb.dbo.backupset
	WHERE database_name=N'ECUS5VNACCS' AND type='D'
	ORDER BY backup_finish_date DESC;
	------------------------------------------FILE Cần DIFF RESTORE (1 trong 2) ---------------------------------------
	RESTORE HEADERONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_DIFF_2025-10-19 03-00-00.bak';
	RESTORE HEADERONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_DIFF_2025-10-20 03-00-00.bak';
	--Xem lịch sử DIFF và base
	SELECT TOP 10 backup_finish_date,differential_base_lsn,differential_base_guid,first_lsn,last_lsn
	FROM msdb.dbo.backupset
	WHERE database_name=N'ECUS5VNACCS' AND type='I'
	ORDER BY backup_finish_date DESC;
	------------------------------------------FILE Cần LOG RESTORE (phải theo thứ tự) ---------------------------------------
	RESTORE HEADERONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_LOG_2025-10-19_030000.trn';
	RESTORE HEADERONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_LOG_2025-10-19_033000.trn';
	RESTORE HEADERONLY 
	FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_LOG_2025-10-19_040000.trn';

--B2: Ngắt kết nối và set database sang chế độ SINGLE_USER
		ALTER DATABASE ECUS5VNACCS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		GO

--B3:Phục Hồi FULL------------------Tùy Chọn Xem Phục Hồi Mới Hay Phục Hồi Chép Đè--------------------
		-- Nếu DB CHƯA tồn tại:
		RESTORE DATABASE [ECUS5VNACCS]
		FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_FULL_2025-10-19 01-00-00.bak'
		WITH 
			MOVE 'ECUS5VNACCS_Data'     TO 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ECUS5VNACCS.mdf',
			MOVE 'ECUS5VNACCS_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ECUS5VNACCS.ldf',
			NORECOVERY,        -- giữ trạng thái để nạp tiếp DIFF/LOG
			STATS = 5;
		GO

		-- Nếu DB ĐÃ tồn tại và muốn ghi đè:
		RESTORE DATABASE [ECUS5VNACCS]
		FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_FULL_2025-10-19 01-00-00.bak'
		WITH 
		MOVE 'ECUS5VNACCS_Data' TO 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ECUS5VNACCS.mdf',
		MOVE 'ECUS5VNACCS_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ECUS5VNACCS.ldf',
		REPLACE,             -- Thêm REPLACE để ghi đè DB cũ
		NORECOVERY,        -- giữ trạng thái để nạp tiếp DIFF/LOG
		STATS = 5;

--B3:Phục Hồi DIFF chỉ cần chọn DIFF thuộc FULL trước gần nó nhất là được, không cần phục hồi hết các Diff trước nó

		RESTORE DATABASE [ECUS5VNACCS]
		FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_DIFF_2025-10-19 03-00-00.bak'
		WITH NORECOVERY, STATS = 5;
		GO

--B4:Phục Hồi LOG  phải phục hồi tấc cả các Log từ Diff gần Log cần phục hồi nhất rồi mới tới Log cần phục hồi

		--BatDauLog
		RESTORE DATABASE [ECUS5VNACCS]
		FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_LOG_2025-10-19_033000.trn'
		WITH NORECOVERY, STATS = 5;
		GO
		--KetThuc LOG
		RESTORE DATABASE [ECUS5VNACCS]
		FROM DISK = 'C:\Users\Administrator\Downloads\PublicShare\ECUS5VNACCS_LOG_2025-10-19_040000.trn'
		WITH STOPAT = '2025-10-19T02:38:00',  -- bỏ dòng này nếu muốn tới cuối file log
		NORECOVERY, STATS = 5;
		GO
		
--B5: Kết thúc chế độ NORECOVERY và đưa cơ sở dữ liệu vào trạng thái ONLINE (Nếu trước đó chưa đưa)
		RESTORE DATABASE ECUS5VNACCS WITH RECOVERY;
		GO			
--B6: Chuyển database về chế độ MULTI_USER
ALTER DATABASE ECUS5VNACCS SET MULTI_USER;
GO


------------------------------------------------------------------------------------