--Cập Nhật Lên Bảng Lương Của Tháng Hiện Tại Các NV Bắt Đầu Tính Bảo Hiểm khi có ngày vào vào sau ngày 15 (do phần mềm ko cho load lên)
--------------------------(Cột TienBHTY,BHXH,BHTT trong BangLuong)
----------------Lưu Ý: Kế Toán Tính Lương Rồi Mới Cập Nhật Sau--- Nếu 2 dòng Thì cập nhật dòng DÒNG 2
--------------------------(Xem lai co the ko can: Phải sửa thêm Report bên tính lương để lọc ngày ký hợp đồng (thay đổi theo từng tháng)--Formular: @TIENBH)
--B1:  Kiểm tra DS KT đưa có đúng số lượng hay chưa- Nếu thiếu thì những người thiếu đó chưa có được tính  trong ST_Luong
Delete  From A_BaoHiem
SELECT * FROM A_BaoHiem
-------
Select b.L_BHXH,b.L_BHYT,*
From A_BaoHiem as a Inner Join ST_LUONG as b on a.NV_Ma=b.NV_MA and a.T_Ma=b.T_MA
Where b.L_BHXH is Null and b.L_BHYT is Null
--B2: Update
--Update b
Set b.L_BHXH='1', b.L_BHYT='1'
From A_BaoHiem as a Inner Join ST_LUONG as b on a.NV_Ma=b.NV_MA and a.T_Ma=b.T_MA
Where b.L_BHXH is Null and b.L_BHYT is Null

--------Trả lại như cũ nếu làm sai
--Update b
--Set b.L_BHXH=NULL, b.L_BHYT=NULL
--From A_BaoHiem as a Inner Join ST_LUONG as b on a.NV_Ma=b.NV_MA and a.T_Ma=b.T_MA
--Where b.L_BHXH is not Null and b.L_BHYT is not Null and b.L_MOIKHD='1'

---------------------------------------------------------------
--Select b.L_BHXH,b.L_BHYT,*
--From A_BaoHiem as a Inner Join ST_LUONG as b on a.NV_Ma=b.NV_MA and a.T_Ma=b.T_MA
----Where b.L_BHXH is Null and b.L_BHYT is Null
--Where b.L_BHXH = 0 and b.L_BHYT =0


SELECT L_BHYT,L_BHXH,* FROM ST_LUONG WHERE NV_MA IN ('323058') AND T_MA = '05-2022' AND L_LUONGCHINH ='3284900'
--UPDATE ST_LUONG SET L_BHXH='1', L_BHYT='1'  WHERE NV_MA IN ('323058') AND T_MA = '05-2022' AND L_LUONGCHINH ='3284900'