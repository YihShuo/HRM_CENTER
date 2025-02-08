----Ví Dụ Về Con Trỏ----
---------------------------
--Khai báo bảng chứa cursor
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
	 SELECT deptid
	 FROM departs
---------------Mở bảng Cursor
Open Cur_PhongIT
	---Đoạn này kiểm tra trước xem nếu trước đó có dữ liệu sẽ xóa
	 DECLARE @dept NVARCHAR(1500)
	 SELECT @dept =dept FROM t_user WHERE userid = 'NhanSu'
	  IF (@dept IS NOT NULL OR @dept <>'')		--Nếu đã có đơn vị trước đó thì xóa rồi thêm mới lại
		BEGIN
			UPDATE t_user
			SET dept = ''
			WHERE userid = 'NhanSu'
		END
	--------------------------------------------------------------
Declare @depid NVARCHAR(50) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @depid -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
			UPDATE t_user
			SET dept = dept+';'+@depid--+';'
			WHERE userid = 'NhanSu'
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @depid-- -- Duyệt qua 1 record kế tiếp 
			
END
	---Đoạn này bỏ bớt ';' đầu chuỗi và thêm dấu ';' cuối chuổi để được tính thêm đơn vị mới
	UPDATE t_user
	SET dept = SUBSTRING(dept,2,LEN(dept))+';'
	WHERE userid = 'NhanSu'
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT

-----------------------------