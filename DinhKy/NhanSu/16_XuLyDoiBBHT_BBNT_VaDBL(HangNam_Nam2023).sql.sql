---------------------------------------Hằng Năm NS Yêu Cầu
/* Bước làm sau khi NS cập nhật xong Tăng Lương Tháng 2:

A- Tren DBL và DBL Promax
    1- (Copy trước lần 1 ds NV_MA và Số Tiền BB) --> Kéo thêm dòng mới giống như DBL mới nhất của tấc cả nv trong danh sách "Chỉ cập nhật BBHT" của NS với ngày 01/02/(Năm mới)
    2- (Copy lần 2 ds vừa BB và TL)              --> Cập nhật lại tấc cả BBHT trong ngày 01/02/(Năm mới) của tấc cả trong DS Nhân sự đưa (Gồm chỉ có BBHT, và có vừ BBHT và TL)
B- Trên HDLD:
	3- Xóa bình bầu năm trước,cho lại thành 0 (Toàn bộ Nhân viên cty)
	4- Kéo BBHT qua BBNT sau đó xóa BBHT (Toàn bọ NV Cty)
    5- Cập nhật lại Bình bầu hằng tháng ( Theo 2 DS NS đưa qua)

*/
-----------------------------------------------------------------------------Bước A- Trên DBL và DBLProma:-- --------------------------------------------------------------------------
------------1- (Copy trước lần 1 ds NV_MA và Số Tiền BB) --> Kéo thêm dòng mới giống như DBL mới nhất của tấc cả nv trong danh sách "Chỉ cập nhật BBHT" của NS với ngày 01/02/(Năm mới)
--SELECT * FROM IT_DIENBIENLUONG WHERE NV_Ma = '315260' ORDER BY DBL_Ngaybatdau DESC
--SELECT * FROM ST_DIENBIENLUONG WHERE NV_Ma = '315260' ORDER BY DBL_Ngaybatdau DESC

						--Khai báo bảng chứa cursor
						Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
							   Select NV_Ma
							   From A_NV_MA
						---------------Mở bảng Cursor
						Open Cur_PhongIT
						Declare @NV_MA char(6)--Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
						---------------Lấy dữ liệu
						Fetch Next From Cur_PhongIT into @NV_MA --Gán tham số từ bảng thực vào bảng tạm
						---------------Bắt đầu duyệt
						While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
						BEGIN
							--ST_DienBienLuong
							INSERT INTO IT_DIENBIENLUONG(NV_Ma, DBL_Ngaybatdau, DBL_Soquyetdinh, DBL_Heso, DBL_LuongCB, DBL_PhuCap, CV_MA, CVU_MA, DHNN, LDCM, HASHVALUE, DBL_PhuCapKhac, DBL_TrocapCV, DBL_TrocapUDMAY, DBL_TrocapCMNV, DBL_TrocapNN, DBL_TrocapHMPT, DBL_TroCapQLSX, DBL_TroCapCBVP, DBL_TroCapBBNT, DBL_TroCapBBHT, DBL_TroCapBBTHANG, DBL_TroCapCLGD, DBL_TroCapHTDP, DBL_TroCapQAQIP, DBL_TrocapThoRap, DBL_TrocapHSE, DBL_TrocapMOITRUONG, DBL_KHONGHUONGCHUYENCAN, DBL_NGAYTAO, DBL_NGUOITAO, DBL_NGAYCN, DBL_NGUOICN, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC)
							SELECT TOP 1 NV_Ma, '2023-02-01', DBL_Soquyetdinh, DBL_Heso, DBL_LuongCB, DBL_PhuCap, CV_MA, CVU_MA, DHNN, LDCM, HASHVALUE, DBL_PhuCapKhac, DBL_TrocapCV, DBL_TrocapUDMAY, DBL_TrocapCMNV, DBL_TrocapNN, DBL_TrocapHMPT, DBL_TroCapQLSX, DBL_TroCapCBVP, DBL_TroCapBBNT, DBL_TroCapBBHT, DBL_TroCapBBTHANG, DBL_TroCapCLGD, DBL_TroCapHTDP, DBL_TroCapQAQIP, DBL_TrocapThoRap, DBL_TrocapHSE, DBL_TrocapMOITRUONG, DBL_KHONGHUONGCHUYENCAN, '2023-02-01', 'Adr', DBL_NGAYCN, DBL_NGUOICN, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC
							FROM IT_DIENBIENLUONG
							WHERE NV_Ma = @NV_MA
							ORDER BY DBL_Ngaybatdau DESC
							--ST_DienBienLuongProma
							INSERT INTO ST_DIENBIENLUONG(NV_Ma, DBL_Ngaybatdau, DBL_Soquyetdinh, DBL_Heso, DBL_LuongCB, DBL_PhuCap, CV_MA, CVU_MA, DHNN, LDCM, HASHVALUE, DBL_PhuCapKhac, DBL_TrocapCV, DBL_TrocapUDMAY, DBL_TrocapCMNV, DBL_TrocapNN, DBL_TrocapHMPT, DBL_TroCapQLSX, DBL_TroCapCBVP, DBL_TroCapBBNT, DBL_TroCapBBHT, DBL_TroCapBBTHANG, DBL_TroCapCLGD, DBL_TroCapHTDP, DBL_TroCapQAQIP, DBL_TrocapThoRap, DBL_TrocapHSE, DBL_TrocapMOITRUONG, DBL_KHONGHUONGCHUYENCAN, DBL_NGAYTAO, DBL_NGUOITAO, DBL_NGAYCN, DBL_NGUOICN, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC)
							SELECT TOP 1 NV_Ma, '2023-02-01', DBL_Soquyetdinh, DBL_Heso, DBL_LuongCB, DBL_PhuCap, CV_MA, CVU_MA, DHNN, LDCM, HASHVALUE, DBL_PhuCapKhac, DBL_TrocapCV, DBL_TrocapUDMAY, DBL_TrocapCMNV, DBL_TrocapNN, DBL_TrocapHMPT, DBL_TroCapQLSX, DBL_TroCapCBVP, DBL_TroCapBBNT, DBL_TroCapBBHT, DBL_TroCapBBTHANG, DBL_TroCapCLGD, DBL_TroCapHTDP, DBL_TroCapQAQIP, DBL_TrocapThoRap, DBL_TrocapHSE, DBL_TrocapMOITRUONG, DBL_KHONGHUONGCHUYENCAN, '2023-02-01', 'Adr', DBL_NGAYCN, DBL_NGUOICN, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC
							FROM ST_DIENBIENLUONG
							WHERE NV_Ma = @NV_MA
							ORDER BY DBL_Ngaybatdau DESC
							-------Chạy dòng kế tiếp 
							Fetch Next From Cur_PhongIT into @NV_MA-- Duyệt qua 1 record kế tiếp 
						End
						---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
						Close Cur_PhongIT
						Deallocate Cur_PhongIT

------------2-(Copy lần 2 ds vừa BB và TL)              --> Cập nhật lại tấc cả BBHT trong ngày 01/02/(Năm mới) của tấc cả trong DS Nhân sự đưa (Gồm chỉ có BBHT, và có vừ BBHT và TL)
--UPDATE b
SET b.DBL_TroCapBBHT = a.SoTien
FROM A_NV_MA a INNER JOIN IT_DIENBIENLUONG b ON a.NV_Ma =  b.NV_Ma AND b.DBL_Ngaybatdau = '2023-02-01'

--UPDATE b
SET b.DBL_TroCapBBHT = a.SoTien
FROM A_NV_MA a INNER JOIN ST_DIENBIENLUONG b ON a.NV_Ma =  b.NV_Ma AND b.DBL_Ngaybatdau = '2023-02-01'

-----------------------------------------------------------------------------Bước B- Trên HDLD:-- --------------------------------------------------------------------------
------------3- Xóa bình bầu năm trước,cho lại thành 0 (Toàn bộ Nhân viên cty)
SELECT TCBBNT,* FROM ST_HOPDONGLAODONG
--UPDATE ST_HOPDONGLAODONG SET TCBBNT = '0'

------------4- Kéo BBHT qua BBNT sau đó xoa BBHT (Toàn bọ NV Cty)
SELECT TCBBHT,* FROM ST_HOPDONGLAODONG

--UPDATE ST_HOPDONGLAODONG SET TCBBNT = TCBBHT
--UPDATE ST_HOPDONGLAODONG SET TCBBHT = '0'

------------5- Cập nhật lại Bình bầu hằng tháng ( Theo 2 DS NS đưa qua)
--UPDATE a
SET a.TCBBHT=b.SoTien 
FROM ST_HOPDONGLAODONG a INNER JOIN A_NV_MA b ON a.NV_Ma = b.NV_Ma
-------------------------------------------------------------------------------------HẾT-----------------------------------------------------------------------------------