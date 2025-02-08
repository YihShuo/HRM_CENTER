USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_A_CHAMCONGTUDONG]    Script Date: 17/03/2022 1:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	Dùng chấm mỗi ngày, những người ngày hôm trước không có quẹt thẻ để lên 0 giờ bên ST_GioQuetThe, từ đó
bảng công mới hiện phép hoặc cho cập nhật phép
*/
--EXEC SP_A_CHAMCONGKHONGQUETTHE

ALTER PROCEDURE [dbo].[SP_A_CHAMCONGKHONGQUETTHE]
AS
BEGIN
	DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
	SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
	SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
						WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
							THEN DATEADD(DAY,-2,@NgayHT) 
						ELSE
							DATEADD(DAY,-1,@NgayHT) 
					END
	SELECT @Ngay

	SET @Thang = DATEPART(MONTH,GETDATE())
	SET @Nam = DATEPART(YEAR,GETDATE())
	SELECT @Ngay , @Thang, @Nam

	-----------------------
	--Dùng con trỏ chấm công để lên phép
	--Khai báo bảng chứa cursor
	Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
		SELECT NV_Ma 
		FROM ST_NhanVien
		WHERE NV_MA not in(Select NV_MA 
							FROM ST_GIOQUETTHE 
							WHERE QT_NGAY=@NGAY AND CC_GIOBINHTHUONG IS NOT NULL)
				AND NV_MA not in(Select NV_MA from ST_NhanvienThoiViec where TV_Ngaythoiviec<@NGAY)
				AND DV_MA NOT LIKE 'NV%' 
				AND DV_MA <>'CG' 
				AND DV_MA <> 'BGD'
	---------------Mở bảng Cursor
	Open Cur_PhongIT
	Declare @NV_MA char(6)--,@NV_Ten Nvarchar(30),@DV_MA char(6),@CVU_MA char(6) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
	---------------Lấy dữ liệu
	Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Gán tham số từ bảng thực vào bảng tạm
	---------------Bắt đầu duyệt
	While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
		Begin
			EXEC SP_CHAMCONGNGHIPHEP_SOTHE @Ngay, @NV_MA
			EXEC SP_CAPNHATNGHIPHEP_MACHINE_SOTHE @Ngay, @NV_MA		
			-------Chạy dòng kế tiếp 
			Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
		End
	---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
	Close Cur_PhongIT
	Deallocate Cur_PhongIT

END

