------------------------------------------------Cách Tính Số Tháng Được "Tính Thưởng"----------------------------
/*Nội dung:
	Có 2 loại DS:
		1: Tính thời gian làm việc được xét thưởng của cả năm trừ các phép (NO1,NO2,RO,OP) bao gồm luôn những tháng bị chấm OX
		2: Tính thời gian làm việc được xét thưởng của cả năm trừ các phép (NO1,NO2,RO,OP) không tính những tháng bị chấm OX
	Lưu ý:
		Đối tượng phân ra là công nhân cũ (tính từ đầu năm) và công nhân mới (chỉ tính từ thời gian bắt đầu ký hợp đồng)
*/
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------Xử Lý Trước Các Công Đoạn--------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--A:Xử lý trước cập nhật các ngày phép R (do nhân sự không nhập vô vì)
SELECT a.NP_MA,a.QT_NGAY
FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_Ma = b.NV_MA
WHERE b.DV_Ma NOT LIKE N'NV%'
	AND b.DV_Ma NOT IN ('BGD','CG')
	AND a.QT_NGAY IN ('2023-01-01','2023-01-20','2023-01-21','2023-01-22','2023-01-23','2023-01-24','2023-04-29','2023-04-30','2023-05-01','2023-09-01','2023-09-02') 
	--AND a.NP_MA NOT IN ('ST','TS')
	AND a.NP_MA IS NULL

--UPDATE a
SET a.NP_MA = 'R'
FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_Ma = b.NV_MA
WHERE b.DV_Ma NOT LIKE N'NV%'
	AND b.DV_Ma NOT IN ('BGD','CG')
	AND a.QT_NGAY IN ('2023-01-01','2023-01-20','2023-01-21','2023-01-22','2023-01-23','2023-01-24','2023-04-29','2023-04-30','2023-05-01','2023-09-01','2023-09-02')  
	--AND a.NP_MA NOT IN ('ST','TS')
	AND a.NP_MA IS NULL
--B:Xử lý trước các phép TS,ST... bị chạy liên tục luôn ngày CN, xóa ra để ko bị cộng vô thời gian tính thưởng (DS các ngày CN xóa nên để NS cung cấp vì có thể có nghỉ bù)
 SELECT NP_MA,* 
 FROM ST_GIOQUETTHE a INNER JOIN A_NV_MA b ON a.QT_NGAY = b.NgayThang
 WHERE a.NP_MA IS NOT NULL

 --UPDATE a
SET  NP_MA = Null 
 FROM ST_GIOQUETTHE a INNER JOIN A_NV_MA b ON a.QT_NGAY = b.NgayThang
 WHERE a.NP_MA IS NOT NULL

----------------------------------------------------------------------------------SỐ THÁNG TÍNH THƯỞNG THÁNG 13-----------------------------------------------------------------------------
---------------------------------------------------------TH 1 (Tính thời gian tính thưởng gồm giờ làm việc và trừ các phép ('No1','No2','RO','O','N','N1') kể cả tháng bị OX--------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT NV_Ma,NV_Ngayvao,DV_MA
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'01','2023'),0) Thang1
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'02','2023'),0) Thang2
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'03','2023'),0) Thang3
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'04','2023'),0) Thang4
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'05','2023'),0) Thang5
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'06','2023'),0) Thang6
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'07','2023'),0) Thang7
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'08','2023'),0) Thang8
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'09','2023'),0) Thang9
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'10','2023'),0) Thang10
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'11','2023'),0) Thang11
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'12','2023'),0) Thang12						
		,[SoThangThuongThang13(CoTinhOX)]= ROUND(
									(
									 (
										ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'01','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'02','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'03','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'04','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'05','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'06','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'07','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'08','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'09','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'10','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'11','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'12','2023'),0)
									 )/8
									)/CAST(26 AS FLOAT) --Chuyển dạng số thực 1 số để ra được thập phân
								  ,1)

FROM ST_NHANVIEN
WHERE DV_Ma NOT LIKE N'NV%'
	AND DV_Ma NOT IN ('BGD','CG')
----------------------------------------------------------------------------------SỐ THÁNG TÍNH THƯỞNG HỆ SỐ BÌNH BẦU(Không Tính OX)--------------------------------------------------------------------------
---------------------------------------------------------TH 2 (Tính thời gian tính thưởng gồm giờ làm việc và trừ các phép ('No1','No2','RO','O','N','N1')khong tinh tháng bị OX--------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT NV_Ma,NV_Ngayvao,DV_MA
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'01','2023'),0) Thang1
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'02','2023'),0) Thang2
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'03','2023'),0) Thang3
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'04','2023'),0) Thang4
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'05','2023'),0) Thang5
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'06','2023'),0) Thang6
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'07','2023'),0) Thang7
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'08','2023'),0) Thang8
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'09','2023'),0) Thang9
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'10','2023'),0) Thang10
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'11','2023'),0) Thang11
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'12','2023'),0) Thang12						
		,[SoThangThuongHeSoBinhBau(KhongTinhOX)]= ROUND(
									(
									 (
										ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'01','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'02','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'03','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'04','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'05','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'06','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'07','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'08','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'09','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'10','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'11','2023'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'12','2023'),0)
									 )/8
									)/CAST(26 AS FLOAT) --Chuyển dạng số thực 1 số để ra được thập phân
								  ,1)

FROM ST_NHANVIEN
WHERE DV_Ma NOT LIKE N'NV%'
	AND DV_Ma NOT IN ('BGD','CG')

--------------------
SELECT dbo.fn_LayGioTinhThuongOX_A('315281','01','2023')
SELECT dbo.fn_LayGioTinhThuongOX_A('315281','01','2023')
SELECT dbo.fn_LayGioTinhThuong_A('327690','04','2023')





----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------Cách khác (không dùng vì ko chia ra tháng và ko loại trừ được các tháng bị OX--------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----TH1: Số tháng tính thưởng theo tháng 13 (lấy đủ 12 tháng) và trừ các phép (NO1,NO2,RO,OP)
-------------------------------------------------
----CN cũ: Lấy giờ công từ ngày 1/01 - 31/12 của năm đang xét đối với người KHD năm trước
--SELECT a.NV_MA,b.NV_Ten,b.NV_Ngayvao,b.DV_MA
--		,SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0)) 		   
--			AS [Giờ Tính Thưởng]
--		,ROUND(
--				(
--					SUM(
--						ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0)
--						)/8
--				)
--				/26,1
--				)
--		AS [Tháng Tính Thưởng]
--FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_MA=b.NV_Ma
--WHERE YEAR(a.QT_NGAY)='2023' 
--	AND QT_NGAY>='2022-01-01' AND QT_NGAY<='2022-12-31'
--	--Chọn thời gian tính là có phát sinh giờ làm việc và các phép trừ phép 'No1','No2','RO','O'
--	AND (NP_MA NOT IN ('No1','No2','RO','O') 
--			OR CC_GIOBINHTHUONG >=1
--			OR CC_GIOBINHTHUONGTAY >=1
--		)
--	AND  a.DV_MA='NS'
--	--AND a.NV_MA IN ('316199','311708')
--	AND b.DV_MA NOT LIKE ('NV%')
--	AND a.CA_MA IN ('Ca HC','Ca 2','Ca 3','Ca 5','Ca 6','Ca 7','Ca 8','Ca01','Ca02','Ca03')
--	AND (b.NV_NGAYKHD < '2022-01-01'                               --HĐ cũ
--		OR 
--		(b.NV_Ngayvao<'2022-01-01' AND b.NV_NGAYKHD>='2022-01-01') --HĐ đáo hạn
--		)
--GROUP BY a.NV_MA,b.NV_Ngayvao,b.NV_Ten,b.DV_MA
--UNION
----CN Mới (Lấy giờ công từ ngày KHD trong năm đang xét)
--SELECT a.NV_MA,b.NV_Ten,b.NV_Ngayvao,b.DV_MA
--		,SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0)) 		   
--			AS [Giờ Tính Thưởng]
--		,ROUND(
--				(
--					SUM(
--						ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0)
--						)/8
--				)
--				/26,1
--				)
--		AS [Tháng Tính Thưởng]
--FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_MA=b.NV_Ma
--WHERE YEAR(a.QT_NGAY)='2023' 
--	AND QT_NGAY>=b.NV_NGAYKHD AND QT_NGAY<='2022-12-31'
--	--Chọn thời gian tính là có phát sinh giờ làm việc và các phép trừ phép 'No1','No2','RO','O'
--	AND (NP_MA NOT IN ('No1','No2','RO','O') 
--			OR CC_GIOBINHTHUONG >=1
--			OR CC_GIOBINHTHUONGTAY >=1
--		)
--	AND  a.DV_MA='NS'
--	--AND a.NV_MA IN ('316199','311708')
--	AND b.DV_MA NOT LIKE ('NV%')
--	AND a.CA_MA IN ('Ca HC','Ca 2','Ca 3','Ca 5','Ca 6','Ca 7','Ca 8','Ca01','Ca02','Ca03')
--	AND b.NV_Ngayvao > '2022-01-01'
--GROUP BY a.NV_MA,b.NV_Ngayvao,b.NV_Ten,b.DV_MA
-------------------------------------------------
----TH2: Số tháng tính thưởng không tính OX và trừ các phép (NO1,NO2,RO,OP)
-------------------------------------------------
--SELECT NV_Ma,NV_Ngayvao,DV_MA
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'01','2023'),0) Thang1
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'02','2023'),0) Thang2
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'03','2023'),0) Thang3
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'04','2023'),0) Thang4
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'05','2023'),0) Thang5
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'06','2023'),0) Thang6
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'07','2023'),0) Thang7
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'08','2023'),0) Thang8
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'09','2023'),0) Thang9
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'10','2023'),0) Thang10
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'11','2023'),0) Thang11
--		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'12','2023'),0) Thang12						
--		,[SoThangDuocThuong]= ROUND(
--									(
--									 (
--										ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'01','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'02','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'03','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'04','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'05','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'06','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'07','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'08','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'09','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'10','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'11','2023'),0)
--										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'12','2023'),0)
--									 )/8
--									)/CAST(26 AS FLOAT) --Chuyển dạng số thực 1 số để ra được thập phân
--								  ,1)

--FROM ST_NHANVIEN
--WHERE DV_Ma NOT LIKE N'NV%'
--	AND DV_Ma NOT IN ('BGD','CG')
