----------------------------------Đôi khi cần chấm công lại 1 số trường hợp không rõ nguyên nhân mà bị cắt công sai
------------------------------------------Cách chấm này vẫn giữ lại các giá trị trong MF_RECORD, cách tính lấy giờ quẹt vào sớm nhất, giờ quẹt ra trễ nhất
DECLARE @MA_NV NVARCHAR(32), @NGAY_T DATETIME, @Ngay DATE, @QuetVao DATETIME, @QuetVao_CL NVARCHAR(19), @QuetRa DATETIME,@QuetRa_CL NVARCHAR(19), @MaTu NVARCHAR(18) 

SET @MA_NV = '336411'
SET @NGAY_T ='2024-11-25'
SET @Ngay = CONVERT(DATE,@NGAY_T)
SET @QuetVao = (Select MIN(MatTime) FROM MF_Record WHERE UserNo=@MA_NV AND CONVERT(DATE,MatTime)= @Ngay)
SET @QuetVao_CL = CONVERT(NVARCHAR(19),@QuetVao,120)
SET @QuetRa = (Select MAX(MatTime) FROM MF_Record WHERE UserNo=@MA_NV AND CONVERT(DATE,MatTime)= @Ngay)
SET @QuetRa_CL = CONVERT(NVARCHAR(19),@QuetRa,120)
SET @MaTu = (SELECT NV_MaTu FROM ST_NHANVIEN WHERE NV_Ma = @MA_NV)

SELECT @QuetVao,@QuetRa,@QuetVao_CL,@QuetRa_CL
----------------
Delete From ST_VaoRa WHERE		NV_Ma=@MA_NV AND QT_Ngay=@NGAY_T
DELETE FROM ST_GioQuetThe WHERE NV_Ma=@MA_NV AND QT_Ngay=@NGAY_T
------------------------------------Công Ngoài
Delete From ST_VaoRa_ WHERE		 NV_Ma=@MA_NV AND QT_Ngay=@NGAY_T
DELETE FROM ST_GioQuetThe_ WHERE NV_Ma=@MA_NV AND QT_Ngay=@NGAY_T
------------------------------------MF_RECORD
DELETE MF_Record WHERE UserNo=@MA_NV AND  MatTime = @QuetVao
DELETE MF_Record WHERE UserNo=@MA_NV AND  MatTime = @QuetRa
--------------
DECLARE @ErrorCode INT;
EXEC mfsp_save_access_record 
	@DevNo=0, -- int
    @DevType=0, -- int
    @UserNo=@MA_NV, -- nvarchar(32)
    @CardNo=@MaTu, -- nvarchar(32)
    @MatTime=@QuetVao_CL, -- nvarchar(19)
    @MiSec=37086, -- int
    @Score=153, -- int
    @EventNo=0, -- int
    @ReaderNo=0, -- int
    @Offline=0, -- int
    @Interval=0, -- int
    @ErrorCode=@ErrorCode OUTPUT -- int
--------------
EXEC mfsp_save_access_record 
	@DevNo=0, -- int
    @DevType=0, -- int
    @UserNo=@MA_NV, -- nvarchar(32)
    @CardNo=@MaTu, -- nvarchar(32)
    @MatTime=@QuetRa_CL, -- nvarchar(19)
    @MiSec=37086, -- int
    @Score=153, -- int
    @EventNo=0, -- int
    @ReaderNo=0, -- int
    @Offline=0, -- int
    @Interval=0, -- int
    @ErrorCode=@ErrorCode OUTPUT -- int
---------------Xem Lại
    SELECT * FROM ST_VAORA WHERE NV_MA = @MA_NV AND QT_NGAY = @NGAY_T --AND CA_MA = 'Ca HC'
    SELECT * FROM ST_GIOQUETTHE WHERE NV_MA = @MA_NV AND QT_NGAY = @NGAY_T 
    ------------------------------------Công Ngoài
    SELECT * FROM ST_VAORA_ WHERE      NV_MA = @MA_NV AND QT_NGAY = @NGAY_T --AND CA_MA = 'Ca HC'
    SELECT * FROM ST_GIOQUETTHE_ WHERE NV_MA = @MA_NV AND QT_NGAY = @NGAY_T
    -------------------------------------MF_RECORD
    SELECT * From MF_Record WHERE UserNo=@MA_NV AND CONVERT(DATE,MatTime)= @Ngay