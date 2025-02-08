----------------Cập Nhật Tay Tiền HK Điều Kiện Ngoại lệ do hệ thống không tính được vì không có đi làm ngày nào-------------
-------------------Dẫn đến tiền lương 1 giờ làm việc ko có > ko tính dược Tiền Hành Kinh > Phải nhập tay tiền HK
---B1: Xóa Dữ Liệu Bảng Thạm
Delete From A_PhuCapThang
Select * From A_PhuCapThang
---B2: Copy Dữ Liệu Từ Excel vào bảng tạm
---B3: Select thử trước

---------------------II-Bảng II - ST_Luong
Select a.NV_MA,a.DV_MA,a.MONNEY, b.NV_MA,b.L_TIENHK
From A_PhuCapThang As a Inner Join ST_LUONG As b on a.NV_MA=b.NV_MA and a.T_MA=b.T_MA 
Where b.L_HUONGLUONGKHD=1
Order by a.NV_MA

---B4: Cập Nhật Dữ Liệu

--Update b
Set b.L_TIENHK=a.MONNEY
From A_PhuCapThang As a Inner Join ST_LUONG As b on a.NV_MA=b.NV_MA and a.T_MA=b.T_MA 
Where b.L_HUONGLUONGKHD=1


select * From A_PhuCapThang