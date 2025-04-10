
DECLARE @ErrorCode INT;
DECLARE @MaNV AS NVARCHAR(15)
DECLARE @Ngay AS	NVARCHAR(30)
DECLARE @NgaySau AS NVARCHAR(30)
DECLARE @Gio AS NVARCHAR(30)
DECLARE @QuetThe AS NVARCHAR(30)
DECLARE @MaTu AS NVARCHAR(50)
DECLARE @XuLy AS INT

SET @MaNV = '314844'
--------
SET @XuLy = '2' -- 1 là thêm giờ; 0 là xóa giờ； 2 là xem
SET @Ngay = '2025-04-17'
SET @Gio  = '16:41:10'
--------
SET @NgaySau = CONVERT(DATETIME,@Ngay,102) + 1
SET @QuetThe = @Ngay + ' ' + @Gio

SET @MaTu =(SELECT NV_MaTu FROM ST_NHANVIEN WHERE NV_Ma = @MaNV)

--SELECT @MaTu,@QuetThe,@Ngay,@NgaySau,DATEDIFF(HOUR,@Ngay,@NgaySau)

IF (@XuLy = 1)
	BEGIN
		EXEC mfsp_save_access_record 
			@DevNo=0, -- int
			@DevType=0, -- int
			@UserNo=@MaNV, -- nvarchar(32)
			@CardNo=@MaTu, -- nvarchar(32)
			@MatTime=@QuetThe, -- nvarchar(19)
			@MiSec=37086, -- int
			@Score=153, -- int
			@EventNo=0, -- int
			@ReaderNo=0, -- int
			@Offline=0, -- int
			@Interval=0, -- int
			@ErrorCode=@ErrorCode OUTPUT -- int
	END
ELSE IF (@XuLy =0 )
	BEGIN
	 --   --------------------------------------Công Trong
		Delete From ST_VaoRa WHERE		NV_Ma=@MaNV and QT_Ngay=@Ngay --AND CA_MA = 'Ca HC'
		DELETE FROM ST_GioQuetThe WHERE NV_Ma=@MaNV and QT_Ngay=@Ngay
		------------------------------------Công Ngoài
		Delete From ST_VaoRa_ WHERE		 NV_Ma=@MaNV and QT_Ngay=@Ngay
		DELETE FROM ST_GioQuetThe_ WHERE NV_Ma=@MaNV and QT_Ngay=@Ngay
		------------------------------------MF_Record
		DELETE MF_Record WHERE UserNo=@MaNV AND   MatTime >= @Ngay AND MatTime <= @NgaySau


	END
ELSE 
	BEGIN
		----------------------------------------Công Trong
		SELECT * FROM ST_VAORA WHERE      NV_MA = @MaNV AND QT_NGAY = @Ngay AND CA_MA = 'Ca HC'
		SELECT * FROM ST_GIOQUETTHE WHERE NV_MA = @MaNV AND QT_NGAY = @Ngay 
		------------------------------------Công Ngoài
		--SELECT * FROM ST_VAORA_ WHERE      NV_MA = @MaNV AND QT_NGAY = @Ngay AND CA_MA = 'Ca HC'
		--SELECT * FROM ST_GIOQUETTHE_ WHERE NV_MA = @MaNV AND QT_NGAY = @Ngay
		-------------------------------------MF_RECORD
		SELECT * From MF_Record WHERE UserNo=@MaNV AND MatTime >= @Ngay AND MatTime <= @NgaySau
	END

