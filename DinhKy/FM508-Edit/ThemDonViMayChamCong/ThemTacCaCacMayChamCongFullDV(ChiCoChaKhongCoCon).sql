
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
	SELECT Clock_ID 
	FROM t_Clocks
	--WHERE Clock_ID = '1'
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @clockID NVARCHAR(50) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @clockID -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	IF @clockID NOT IN (SELECT  Clock_ID FROM t_DeptClocks)
		BEGIN
			--Con trỏ lồng
			Declare Cur_IT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
				SELECT deptID 
				FROM t_DeptClocks_Andrew --(Đây là bảng dạm chỉ chứa các Đơn vị cha không có đơn vị con nhằm đối phó lỗi phần mềm chưa sửa)
				Where Khu = 'YS'
			---------------Mở bảng Cursor
			Open Cur_IT
			Declare @depid NVARCHAR(50) 
			---------------Lấy dữ liệu
			Fetch Next From Cur_IT into @depid 
			---------------Bắt đầu duyệt
			While (@@FETCH_STATUS=0) 
			Begin
				IF @depid NOT IN (SELECT  DeptID FROM t_DeptClocks WHERE Clock_ID = @clockID)
					BEGIN
						INSERT INTO t_DeptClocks(DeptID, Clock_ID)
						VALUES(@depid,@clockID)
						--PRINT @depid
					END
				-------Chạy dòng kế tiếp 
				Fetch Next From Cur_IT into @depid
			End
			---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
			Close Cur_IT
			Deallocate Cur_IT
		END
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @clockID-- -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT




SELECT *
FROM t_DeptClocks