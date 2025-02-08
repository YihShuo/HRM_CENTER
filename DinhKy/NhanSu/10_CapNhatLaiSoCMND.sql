----------------Cập Nhật Lại Số Chứng Minh Đúng
--Delete From A_CapnhatCMND
Select *
From A_CapNhatCMND

---B1: Select thử trường hợp có chính xác chưa
Select a.NV_Ma,a.Edit,b.NV_Ma,b.NV_CMND
From A_CapNhatCMND As a Inner Join ST_NHANVIEN As b on a.NV_Ma=b.NV_Ma 
														
---B2: Update
--update b
Set b.NV_CMND=a.Edit
From A_CapNhatCMND As a Inner Join ST_NHANVIEN As b on a.NV_Ma=b.NV_Ma 
													
