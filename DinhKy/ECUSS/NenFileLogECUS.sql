		-----------------------------------------------------------------------------Do FILE Log phìn to hơn vài Terabite nên phải nén, néng chỉ còn 1Kg
		---------------------------------------------------------------------------Nếu Code chạy lỗi thì ResetDatabase
		USE [ECUS5VNACCS]
		GO
		----Bước 2------
		----Truncate  the log by changing the database recovery model to SIMPLE.
		ALTER DATABASE ECUS5VNACCS
		SET RECOVERY SIMPLE;
		GO
		----Bước 3------
		----Shrink the truncated log file  to 1 Mb
		DBCC SHRINKFILE(ECUS5VNACCS_log, 1)
		GO
		----Bước 4------
		----Reset the database  recovery mode
		ALTER DATABASE ECUS5VNACCS
		SET RECOVERY FULL;
		GO
