USE FM508;
GO
-- Khoi tao bien JOB
DECLARE @JobName NVARCHAR(128) = 'A_AutoFM508-P0104';

-- ====== KIEM TRA JOB DANG CHAY ======
/*Nếu job từng lỗi và quên gỡ cờ →  có thể reset bằng tay: UPDATE dbo.JobLock SET IsRunning = 0 WHERE JobName = 'A_AutoFM508-P0104'*/
IF EXISTS (SELECT 1 FROM dbo.JobLock WHERE JobName = @JobName AND IsRunning = 1)
BEGIN
    PRINT 'Job Dang Chay!!! Bo qua lan nay';
    RETURN;
END

-- ====== ĐÁNH DẤU LÀ ĐANG CHẠY ======
MERGE dbo.JobLock AS target
USING (SELECT @JobName AS JobName) AS source
ON target.JobName = source.JobName
WHEN MATCHED THEN 
    UPDATE SET IsRunning = 1, StartTime = GETDATE()
WHEN NOT MATCHED THEN
    INSERT (JobName, IsRunning, StartTime) VALUES (@JobName, 1, GETDATE());

-- ====== XỬ LÝ HÀNG ĐỢI ======
DECLARE @UserNo NVARCHAR(50), 
        @CardNo NVARCHAR(50), 
        @RecTime DATETIME, 
        @DevNo INT, 
        @CardNoFinal NVARCHAR(50),
        @RecTimeStr NVARCHAR(19),
        @ErrorCode INT,
        @Id BIGINT;  

-- Xử lý từng bản ghi chưa xử lý
WHILE EXISTS (SELECT 1 FROM t_mf_RecData1 WHERE Processed = 0)
	BEGIN
		-- Lấy một bản ghi (Dùng TOP 1 WITH (UPDLOCK:Đặt khóa để “đánh dấu” dòng đang xử lý, READPAST:Bỏ qua các dòng đang bị khóa bởi session khác)
		SELECT TOP 1 
			@Id = ID,
			@UserNo = UserNo,
			@CardNo = CardNo,
			@RecTime = RecTime,
			@DevNo = DevNo
		FROM t_mf_RecData1 WITH (UPDLOCK, READPAST)
		WHERE Processed = 0;

		BEGIN TRY
			-- Nếu Không có đọc được mã từ(CardNo = 0) thì tra cứu bên P0104-TYTHAC để lấy ra số thẻ
			IF @CardNo = '0' OR @CardNo IS NULL
			BEGIN
				SELECT @CardNoFinal = NV_MaTu
				FROM [P0104-TYTHAC]..ST_NHANVIEN
				WHERE NV_Ma = @UserNo
			END
			ELSE
				SET @CardNoFinal = @CardNo;

			-- Định dạng thời gian
			SET @RecTimeStr = CONVERT(NVARCHAR(19), @RecTime, 120);

			-- Gọi thủ tục
			EXEC [P0104-TYTHAC]..mfsp_save_access_record
				@DevNo=@DevNo,
				@DevType=0,
				@UserNo=@UserNo,
				@CardNo=@CardNoFinal,
				@MatTime=@RecTimeStr,
				@MiSec=0,
				@Score=0,
				@EventNo=0,
				@ReaderNo=0,
				@Offline=1,
				@Interval=1,
				@ErrorCode=@ErrorCode OUTPUT;

			-- Cập nhật lại trạng thái đã xử lý
			UPDATE t_mf_RecData1
			SET 
				Processed = 1,
				ProcessedTime = GETDATE(),
				ErrorMsg = NULL
			WHERE ID = @Id;
		END TRY
		BEGIN CATCH
			-- Nếu lỗi, log lại
			UPDATE t_mf_RecData1
			SET 
				ErrorMsg = ERROR_MESSAGE(),
				ProcessedTime = GETDATE()
			WHERE ID = @Id;
		END CATCH
	END
-- ====== Go Bo Co (Flag) JOB sau khi chay xong ======
UPDATE dbo.JobLock
SET IsRunning = 0
WHERE JobName = @JobName;

PRINT 'JOB xu ly hang doi hoang tat';