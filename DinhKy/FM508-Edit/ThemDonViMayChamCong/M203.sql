-----------Quản Lý Đơn Vị Vào Máy Chấm Công (Khi đó các nv trong đơn vị sẽ tự kéo vào bảng liên quan là t_DeviceEmp)

---Thêm Từng ĐV vào máy
SELECT * FROM t_DeptClocks
--SELECT * FROM departs 

--INSERT INTO t_DeptClocks(DeptID, Clock_ID)
SELECT deptid,'203'
FROM departs
WHERE deptid = 'IT'

--DELETE t_DeptClocks
WHERE Clock_ID='203'

---Thêm tấc cả ĐV vào máy
SELECT *
FROM t_DeptClocks
WHERE Clock_ID='203'

----Ví Dụ Về Con Trỏ----
---------------------------
--Khai báo bảng chứa cursor
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
	SELECT a.deptid
	FROM (Select ROW_NUMBER() over (order by deptid) as sTT,deptid
			FROM departs
			) as A
	WHERE a.sTT>=1 and a.sTT<=15
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @depid NVARCHAR(50) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @depid -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	IF @depid NOT IN (SELECT  DeptID FROM t_DeptClocks WHERE Clock_ID = '203')
		BEGIN
			INSERT INTO t_DeptClocks(DeptID, Clock_ID)
			VALUES(@depid,'203')
			--PRINT 'Thỏa điều kiện X'
		END
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @depid-- -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT

-----------------------------QUản lý nhân viên trong từng máy (T_DeviceEmp)----------------------------------



-----------------------------Xử lý kẹt máy (T_DeviceEmp)----------------------------------
SELECT   *
FROM      t_DeviceEmp 
WHERE dev_id ='203'
ORDER BY dev_id

--DELETE      t_DeviceEmp 
WHERE dev_id ='203'

SELECT *
FROM t_DeptClocks
WHERE Clock_ID='203'
--DELETE t_DeptClocks
WHERE Clock_ID='203'

-------------------
SELECT * FROM t_user
SELECT * FROM t_user WHERE	userid = 'admin'
--UPDATE t_user 
--SET clock='1;203;204;205;206;207;225;227;228;231' 
--WHERE	userid = 'admin'