
/*
SELECT * FROM t_AppParams
SELECT * FROM Employee
SELECT * FROM Departs
SELECT * FROM t_Clocks
SELECT * FROM Empphoto
SELECT * FROM t_mf_RecData
SELECT * FROM t_user
SELECT * FROM t_DeviceEmp
SELECT * FROM t_DeptClocks
*/
/*
----------------------------------------------------------------------Xóa NV Đã Nghỉ Việc (Rác) Còn Dính Trên Bảng Chờ Cập Nhật Xuống máy-------------------------------------------
*/
SELECT *
FROM t_DeviceEmp a INNER JOIN employee b ON a.emp_id = b.EmpID 
WHERE b.DeptID like 'NV%'
--AND a.dev_id = '2'
ORDER BY b.DeptID

--DELETE a
FROM t_DeviceEmp a INNER JOIN employee b ON a.emp_id = b.EmpID
WHERE b.DeptID like 'NV%'
---------------------------------------------------------
SELECT *
FROM t_DeviceEmp a INNER JOIN employee b ON a.emp_id = b.EmpID 
WHERE  a.dev_id = '1'
ORDER BY b.DeptID

SELECT *
FROM t_DeviceEmp a INNER JOIN employee b ON a.emp_id = b.EmpID 
WHERE  a.dev_id = '3'
ORDER BY b.DeptID