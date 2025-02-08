------------------------------------------------------------------------------Thao tác thông tin người dùng phần mềm Client------------------------------------------------------------------------------
SELECT *
FROM [FM508]..t_user

------------------------------------------------------------------------------Thao tác quản lý Đơn Vị Trên Các Máy-------------------------------------------------------------------------------
SELECT * 
FROM FM508..t_DeptClocks
--DELETE t_DeptClocks WHERE DeptID = 'TV'
--INSERT INTO t_DeptClocks(DeptID, Clock_ID)
VALUES(N'IT', -- DeptID - nvarchar(50)
204   -- Clock_ID - int
    )
------------------------------------------------------------------------------Thao tác quản lý Nhân viên trên các Máy------------------------------------------------------------------------------
---Lưu ý: ItType nếu = 2 thì sẽ quyền Admin quản lý cài đặt trên máy cục bộ
SELECT a.*,b.NV_Ten,b.DV_MA
FROM [FM508]..t_DeviceEmp a INNER JOIN [P0104-TYTHAC]..ST_NHANVIEN b ON a.emp_id= b.NV_Ma
WHERE b.DV_MA = 'IT'

--DELETE t_DeviceEmp 
WHERE [FM508]..emp_id = '312429'

--INSERT INTO [FM508]..t_DeviceEmp(dev_id, itype, emp_id)
VALUES(1, -- dev_id - int
0   , -- itype - int
N'314844' -- emp_id - nvarchar(20)
    )

-------------------------------------------------Các View lấy từ P0104-TYTHAC------------------------------------------------------
SELECT * FROM [FM508]..departs WHERE deptid = N'TV'
SELECT * FROM [FM508]..employee 

-------------------------------------------------Xem Giờ Quẹt Thẻ------------------------------------------------------
SELECT * 
FROM FM508..t_mf_RecData
WHERE UserNo IN ('324199','324200')

SELECT * 
FROM [P0104-TYTHAC]..MF_Record
WHERE UserNo IN ('324199','324200')
AND DevNo = ''

