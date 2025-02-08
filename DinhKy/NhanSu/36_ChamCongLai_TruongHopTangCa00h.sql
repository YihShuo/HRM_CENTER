-----------------------------------------------------Trường hợp tăng ca qua 12h đêm (chưa tới 12h30) thì hệ thống vẫn còn tự cắt công được
--------------------------------------tuy nhiên do lỗi nên đoi khi không tự cắt thì chạy lệnh này để tự cắt
DECLARE @Ngay DATETIME
SET @Ngay = '2024-12-30'
---------------------------------
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
		SELECT a.NV_MA,b.NV_MaTu
		FROM ST_VAORA a INNER JOIN ST_NHANVIEN b ON a.NV_Ma = b.NV_Ma
		WHERE QT_NGAY = @Ngay 
		AND QT_CHONCA = '1'
		AND DATEDIFF(DAY,CONVERT(DATE,QT_GIOVAO),CONVERT(DATE,QT_GIORA)) = '1'
		AND DATEPART(HOUR,QT_GIORA) ='0'
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA char(6), @Ma_TU NVARCHAR(50) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA ,@Ma_TU-- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	------Chấm công lại
	EXEC SP_CHAMCONGN  @NGAY,@NV_MA,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1
	------Cắt công lại
	EXEC SP_CAPNHATTANGCA300_NHANVIEN_A @Ngay, @Ma_Tu 
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA,@Ma_TU--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT
