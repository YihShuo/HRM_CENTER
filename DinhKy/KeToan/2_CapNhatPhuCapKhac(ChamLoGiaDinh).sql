----------------Cập Nhật Phụ Cấp Khác (Trợ Cấp Chăm Lo Gia Đình trong Report Luong)-------------
---B1: Xóa Dữ Liệu Bảng Thạm
Delete From A_PhuCapThang
Select * From A_PhuCapThang
---B2: Copy Dữ Liệu Từ Excel vào bảng tạm
---B3: Select thử trước
---------------------I-Bảng I - IT-BangLuongMoi
Select a.MONNEY,a.*,b.SOTHE,b.TIEN_NTRO_KHAC_SHP
From A_PhuCapThang As a Inner Join IT_BANGLUONGMOI As b on a.NV_MA=b.SOTHE and a.T_MA=b.T_MA and Right(a.T_MA,4)=b.NAM and Left(a.T_MA,2)=b.THANG
---------------------II-Bảng II - ST_Luong
Select a.*, b.NV_MA,b.L_CONGKHAC
From A_PhuCapThang As a Inner Join ST_LUONG As b on a.NV_MA=b.NV_MA and a.T_MA=b.T_MA 
Where b.L_CONGKHAC is not null
Order by a.NV_MA
--------------------III- Bảng III- ST_KhoangCongKhac
Select a.*,b.NV_Ma,b.Sotien
From A_PhuCapThang As a Inner Join ST_KHOANCONGKHAC As b on a.NV_MA=b.NV_MA and a.T_MA=b.T_MA
Order by a.NV_MA
---B4: Cập Nhật Dữ Liệu
Update b
Set b.TIEN_NTRO_KHAC_SHP=a.MONNEY
From A_PhuCapThang As a Inner Join IT_BANGLUONGMOI As b on a.NV_MA=b.SOTHE and a.T_MA=b.T_MA and Right(a.T_MA,4)=b.NAM and Left(a.T_MA,2)=b.THANG
Update b
Set b.L_CONGKHAC=a.MONNEY
From A_PhuCapThang As a Inner Join ST_LUONG As b on a.NV_MA=b.NV_MA and a.T_MA=b.T_MA 
Where b.L_CONGKHAC is not null
Update b
Set b.Sotien=a.MONNEY
From A_PhuCapThang As a Inner Join ST_KHOANCONGKHAC As b on a.NV_MA=b.NV_MA and a.T_MA=b.T_MA