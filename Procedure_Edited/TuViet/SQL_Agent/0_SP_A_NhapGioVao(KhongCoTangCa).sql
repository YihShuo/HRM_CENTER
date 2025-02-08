USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_A_CHAMCONGTUDONG]    Script Date: 17/03/2022 1:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

--Thử ngày chỉ định
EXEC SP_A_NhapGioVao @NgayNhap='2022-04-17', @NV_MA='314844' 

--Thử ngày hiện tại
DECLARE @NgayNhap NVARCHAR(10)
SET @NgayNhap =CONVERT(NVARCHAR(10),GETDATE(),120)
EXEC SP_A_NhapGioVao @NgayNhap, @NV_MA='314844'

*/
ALTER PROCEDURE [dbo].[SP_A_NhapGioVao]
	@NgayNhap DATETIME,
	@NV_MA NVARCHAR(50)
AS
BEGIN
	DECLARE @vao NVARCHAR(50), @Ngay NVARCHAR(50),@MaTu NVARCHAR(50),@InOut NVARCHAR(2),@Thu NVARCHAR(1)
    SET @InOut = '01' -- 1: Vào; 2: Ra
	SET @Ngay = LEFT(CONVERT(NVARCHAR(50),@NgayNhap,120),10)
	SET @Thu=DATEPART(DW,@Ngay)
	SELECT @vao= CONVERT(CHAR(10),CONVERT(DATETIME,GioVao),108) FROM A_Time ORDER BY NEWID()
	SELECT @vao = @Ngay+ ' '  +@vao
	SELECT @MaTu= NV_MaTu FROM ST_NHANVIEN WHERE NV_Ma=@NV_MA


	PRINT @vao
	PRINT @MaTu
	PRINT N'Ngày thứ:' + @Thu

	IF @Thu!=1 --(1: là chủ nhât,2-7: là từ Thứ 2 đến thứ 7)
	BEGIN
		--Cách I: Kiểu máy chấm công cũ (Tính ra giờ làm)
		--Chạy các thủ tục chấm công
		--exec SP_TINHVAORA @MaTu,@NgayNhap,@vao
		--exec SP_TINHVAORA_ @MaTu,@NgayNhap,@vao
		--exec SP_TINHVAORA_MACHINE_NEW  @MaTu,@ngay,@vao,@InOut,@Shift=N'0',@Somay=N'09'
		--exec SP_CHAMCONGBINHTHUONG_IN  @MaTu,@ngay,@vao,@InOut,@Shift=N'0',@Somay=N'09'
		--exec SP_CHAMCONGBINHTHUONG_OUT @MaTu,@ngay,@vao,@InOut,@Shift=N'0',@Somay=N'09'

		--Cách II: Kiểu máy chấm công Fasma (Chỉ ghi nhận vào ra)
		DECLARE @ErrorCode INT;
		EXEC mfsp_save_access_record 
		@DevNo='095', -- int
		@DevType='0', -- int
		@UserNo=@NV_MA, -- nvarchar(32)
		@CardNo=@MaTu, -- nvarchar(32)
		@MatTime=@vao, -- nvarchar(16)
		@MiSec=4822, -- int
		@Score=100, -- int
		@EventNo=0, -- int
		@ReaderNo=1, -- int
		@Offline=0, -- int
		@Interval=5, -- int
		@ErrorCode=@ErrorCode OUTPUT -- int
	END
	
END

