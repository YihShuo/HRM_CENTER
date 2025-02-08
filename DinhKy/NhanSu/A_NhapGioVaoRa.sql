SELECT NV_MaTu,NV_Ten,DV_MA FROM ST_NHANVIEN WHERE NV_Ma = '319203'

---------------------------------------------------------------------------------------Chấm Theo Máy Fastma----------------------------------------------------------------------
---------------------------------------------------------------------Trường hợp nhập Full Vào Ra------------------------------------------
----------------------
DECLARE @ErrorCode INT;
EXEC mfsp_save_access_record 
	@DevNo=0, -- int
    @DevType=0, -- int
    @UserNo=N'319203', -- nvarchar(32)
    @CardNo=N'00081606952018', -- nvarchar(32)
    @MatTime=N'2024-07-25 07:22:07', -- nvarchar(19)
    @MiSec=37086, -- int
    @Score=153, -- int
    @EventNo=0, -- int
    @ReaderNo=0, -- int
    @Offline=0, -- int
    @Interval=0, -- int
    @ErrorCode=@ErrorCode OUTPUT -- int
--------------
--DECLARE @ErrorCode INT;
EXEC mfsp_save_access_record 
	@DevNo=0, -- int
    @DevType=0, -- int
    @UserNo=N'319203', -- nvarchar(32)
    @CardNo=N'00081606952018', -- nvarchar(32)
    @MatTime=N'2024-07-25 20:09:32', -- nvarchar(19)
    @MiSec=37086, -- int
    @Score=153, -- int
    @EventNo=0, -- int
    @ReaderNo=0, -- int
    @Offline=0, -- int
    @Interval=0, -- int
    @ErrorCode=@ErrorCode OUTPUT -- int

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------Xem-------------------
-------------------------------------
--SELECT NV_MaTu,NV_Ten,DV_MA FROM ST_NHANVIEN WHERE NV_Ma = '319203'
------------------------------------Công Trong
SELECT * FROM ST_VAORA WHERE      NV_MA = '319203' AND QT_NGAY = '2024-07-25' AND CA_MA = 'Ca HC'
SELECT * FROM ST_GIOQUETTHE WHERE NV_MA = '319203' AND QT_NGAY = '2024-07-25' 
------------------------------------Công Ngoài
SELECT * FROM ST_VAORA_ WHERE      NV_MA = '319203' AND QT_NGAY = '2024-07-25' AND CA_MA = 'Ca HC'
SELECT * FROM ST_GIOQUETTHE_ WHERE NV_MA = '319203' AND QT_NGAY = '2024-07-25'
-------------------------------------MF_RECORD
SELECT * From MF_Record WHERE UserNo='319203' AND MatTime >= '2024-07-25 00:00:00' AND MatTime <= '2024-07-25 23:59:59'

---------------Xóa-------------------
-------------------------------------
------------------------------------Công Trong
Delete From ST_VaoRa WHERE		NV_Ma='319203' and QT_Ngay='2024-07-25' --AND CA_MA = 'Ca HC'
DELETE FROM ST_GioQuetThe WHERE NV_Ma='319203' and QT_Ngay='2024-07-25'
------------------------------------Công Ngoài
Delete From ST_VaoRa_ WHERE		 NV_Ma='319203' and QT_Ngay='2024-07-25'
DELETE FROM ST_GioQuetThe_ WHERE NV_Ma='319203' and QT_Ngay='2024-07-25'
------------------------------------MF_Record
DELETE MF_Record WHERE UserNo='319203' AND  MatTime >= '2024-07-25 00:00:00' AND MatTime <= '2024-07-25 23:59:59'

/*--------------------Code đầy đủ khi quẹt máy------------------
DECLARE @p1 int
set @p1=1
declare @p14 int
set @p14=0
exec sp_prepexecrpc @p1 output,N'mfsp_save_access_record','088',2,'319203','00081606952018','2024-07-25 07:22:07',4822,100,0,1,0,5,@p14 output
select @p1, @p14

--------------------Trích------------------------
DECLARE @ErrorCode INT;
EXEC mfsp_save_access_record 
	@DevNo='088', -- int
    @DevType='2', -- int
    @UserNo=N'319203', -- nvarchar(32)
    @CardNo=N'00081606952018', -- nvarchar(32)
    @MatTime=N'2024-07-25 17:35:28', -- nvarchar(19)
    @MiSec=4822, -- int
    @Score=100, -- int
    @EventNo=0, -- int
    @ReaderNo=1, -- int
    @Offline=0, -- int
    @Interval=5, -- int
    @ErrorCode=@ErrorCode OUTPUT -- int
*/


/*
-------------------------------------------------------Chấm Theo Cách Cũ
---------------Nhập-------------------
-------------------------------------
SELECT NV_MaTu,NV_Ten,DV_MA FROM ST_NHANVIEN WHERE NV_Ma = '319203'
-------Chạy dòng lệnh theo thứ tự Phần mềm lấy DL
--F1: 01	14-03-2024	07:15:03	'00081606952018		0009
exec SP_TINHVAORA              @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 07:22:07'
exec SP_TINHVAORA_             @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 07:22:07'
exec SP_TINHVAORA_MACHINE_NEW  @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 07:22:07',@InOut=N'01',@Shift=N'0',@Somay=N'09'
exec SP_CHAMCONGBINHTHUONG_IN  @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 07:22:07',@InOut=N'01',@Shift=N'0',@Somay=N'09'
exec SP_CHAMCONGBINHTHUONG_OUT @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 07:22:07',@InOut=N'01',@Shift=N'0',@Somay=N'09'

--F2: 14-03-2024	22:00:03	'00081606952018		0009
exec SP_TINHVAORA              @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 20:09:32'
exec SP_TINHVAORA_             @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 20:09:32'
exec SP_TINHVAORA_MACHINE_NEW  @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 20:09:32',@InOut=N'02',@Shift=N'0',@Somay=N'09'
exec SP_CHAMCONGBINHTHUONG_IN  @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 20:09:32',@InOut=N'02',@Shift=N'0',@Somay=N'09'
exec SP_CHAMCONGBINHTHUONG_OUT @MATU=N'00081606952018',@NGAY='2024-07-25 00:00:00',@GIO='2024-07-25 20:09:32',@InOut=N'02',@Shift=N'0',@Somay=N'09'

-- Tính lại tăng ca - công ngoài
--exec SP_CAPNHATTANGCA300 @NGAY='2024-07-25 00:00:00'
--Xem Thống kê giờ tăng ca
--EXEC A_SP_CAPNHATTANGCA300_NHANVIEN_A_XemTongTangCa @NGAY='2024-07-25 00:00:00',  @MATU=N'00081606952018'

EXEC SP_CAPNHATTANGCA300_NHANVIEN_A @NGAY='2024-07-25 00:00:00',  @MATU=N'00081606952018' 

---------------Xem-------------------
-------------------------------------
------------------------------------Công Trong
SELECT * FROM ST_VAORA WHERE      NV_MA = '319203' AND QT_NGAY = '2024-07-25' --AND CA_MA = 'Ca HC'
SELECT * FROM ST_GIOQUETTHE WHERE NV_MA = '319203' AND QT_NGAY = '2024-07-25' 
------------------------------------Công Ngoài
SELECT * FROM ST_VAORA_ WHERE      NV_MA = '319203' AND QT_NGAY = '2024-07-25' --AND CA_MA = 'Ca HC'
SELECT * FROM ST_GIOQUETTHE_ WHERE NV_MA = '319203' AND QT_NGAY = '2024-07-25'
-------------------------------------MF_RECORD
SELECT * From MF_Record WHERE UserNo='319203' AND MatTime >= '2024-07-25 00:00:00' AND MatTime <= '2024-07-25 23:59:59'
------------------------------------Machine
--SELECT * FROM ST_VAORA_MACHINE_NEW WHERE NV_MA = '319203' AND QT_NGAY = '2024-07-25 00:00:00.000'
--SELECT * FROM ST_VAORA_MACHINE WHERE MaNV= '319203' AND nam = 2021 AND Thang = 11

---------------Xóa-------------------
-------------------------------------

------------------------------------Công Trong
Delete From ST_VaoRa WHERE		NV_Ma='319203' and QT_Ngay='2024-07-25' --AND CA_MA = 'Ca HC'
DELETE FROM ST_GioQuetThe WHERE NV_Ma='319203' and QT_Ngay='2024-07-25'
------------------------------------Công Ngoài
Delete From ST_VaoRa_ WHERE		 NV_Ma='319203' and QT_Ngay='2024-07-25'
DELETE FROM ST_GioQuetThe_ WHERE NV_Ma='319203' and QT_Ngay='2024-07-25'
-------------------------------------MF_RECORD
--DELETE MF_Record WHERE UserNo='319203' AND  MatTime >= '2024-07-25 00:00:00' AND MatTime <= '2024-07-25 23:59:59'
--------------------------------------Machine
--DELETE ST_VAORA_MACHINE_NEW WHERE NV_MA = '319203' AND QT_NGAY = '2024-07-25 00:00:00.000'

*/
