------Nhập tài khoản NH của Nhân viên Mới
---Tạo mới bảng tạm
--Select NV_Ma,DV_MA,SOTAIKHOAN Into A_TaiKhoan From ST_NHANVIEN Where NV_Ma='316503'
Delete From A_TaiKhoan
Select * From A_TaiKhoan
---Thử truy vấn 
Select a.NV_Ma,a.SOTAIKHOAN,b.NV_Ma,b.SOTAIKHOAN
From ST_NHANVIEN As a Inner Join A_TaiKhoan As b on a.NV_Ma=b.NV_Ma
Where a.NV_Ma=b.NV_Ma
---Cập nhật

Update a
Set a.SOTAIKHOAN=b.SOTAIKHOAN
From ST_NHANVIEN As a Inner Join A_TaiKhoan As b on a.NV_Ma=b.NV_Ma
Where a.NV_Ma=b.NV_Ma
