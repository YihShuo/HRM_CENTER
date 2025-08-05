USE FM508;
GO

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
