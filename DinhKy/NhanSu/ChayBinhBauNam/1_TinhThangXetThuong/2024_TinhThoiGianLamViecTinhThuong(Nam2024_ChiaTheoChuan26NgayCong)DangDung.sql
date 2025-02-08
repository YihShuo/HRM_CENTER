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
--A:Xử lý trước cập nhật các ngày phép R (do nhân sự không nhập vô)
			/*
			 Từ danh sách Excel cột của NS đưa qua dùng công thức excel để chuyển về chuổi SQL xử lý
				Chuyển về định dạng: ('yyyy-mm-dd') 
					=CONCAT("('",TEXT(B1,"yyyy-mm-dd"),"')"))
				Ghép các chuổi lại và cách dấu phẩy
					=TEXTJOIN(", ",FALSE,D1:D11)
			 */ 

		--Dùng giải pháp BIẾN TẠM
			DECLARE @ngayPhepR TABLE(dateValue DATE);
			INSERT INTO @ngayPhepR (dateValue)
			VALUES ('2024-01-01'), ('2024-02-08'), ('2024-02-09'), ('2024-02-10'), ('2024-02-11'), ('2024-02-12'), ('2024-04-18'), ('2024-04-30'), ('2024-05-01'), ('2024-09-02'), ('2024-09-03')

			SELECT a.NP_MA,a.QT_NGAY
			FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_Ma = b.NV_MA
			WHERE b.DV_Ma NOT LIKE N'NV%'
				AND b.DV_Ma NOT IN ('BGD','CG')
				AND a.QT_NGAY IN (SELECT dateValue FROM @ngayPhepR) 
				--AND a.NP_MA NOT IN ('ST','TS')
				AND a.NP_MA IS NULL

			UPDATE a
			SET a.NP_MA = 'R'
			FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_Ma = b.NV_MA
			WHERE b.DV_Ma NOT LIKE N'NV%'
				AND b.DV_Ma NOT IN ('BGD','CG')
				AND a.QT_NGAY IN (SELECT dateValue FROM @ngayPhepR)   
				--AND a.NP_MA NOT IN ('ST','TS')
				AND a.NP_MA IS NULL

--B:Xử lý trước các phép TS,ST... bị chạy liên tục luôn ngày CN, xóa ra để ko bị cộng vô thời gian tính thưởng (DS các ngày CN xóa nên để NS cung cấp vì có thể có nghỉ bù)
			 /*
			 Từ danh sách Excel cột của NS đưa qua dùng công thức excel để chuyển về chuổi SQL xử lý
				Chuyển về định dạng: ('yyyy-mm-dd') 
					=CONCAT("('",TEXT(B1,"yyyy-mm-dd"),"')")
				Ghép các chuổi lại và cách dấu phẩy
					=TEXTJOIN(", ",FALSE,D1:D52)
			 */

		--Dùng giải pháp BẢNG TẠM
		CREATE TABLE #ngayChuNhat (dataValue DATE);
		INSERT INTO #ngayChuNhat (dataValue)
		VALUES ('2024-01-07'), ('2024-01-14'), ('2024-01-21'), ('2024-01-28'), ('2024-02-04'), ('2024-02-13'), ('2024-02-18'), ('2024-02-25'), ('2024-03-03'), ('2024-03-10'), ('2024-03-17'), ('2024-03-24'), ('2024-03-31'), ('2024-04-07'), ('2024-04-14'), ('2024-04-21'), ('2024-04-28'), ('2024-05-05'), ('2024-05-12'), ('2024-05-19'), ('2024-05-26'), ('2024-06-02'), ('2024-06-09'), ('2024-06-16'), ('2024-06-23'), ('2024-06-30'), ('2024-07-07'), ('2024-07-14'), ('2024-07-21'), ('2024-07-28'), ('2024-08-04'), ('2024-08-11'), ('2024-08-18'), ('2024-08-25'), ('2024-09-01'), ('2024-09-08'), ('2024-09-15'), ('2024-09-22'), ('2024-09-29'), ('2024-10-06'), ('2024-10-13'), ('2024-10-20'), ('2024-10-27'), ('2024-11-03'), ('2024-11-10'), ('2024-11-17'), ('2024-11-24'), ('2024-12-01'), ('2024-12-08'), ('2024-12-15'), ('2024-12-22'), ('2024-12-29')

			 SELECT NP_MA,*
			 FROM ST_GIOQUETTHE 
			 WHERE QT_NGAY IN (SELECT * FROM #ngayChuNhat)
			 AND NP_MA IS NOT NULL
			 ORDER BY NV_MA 

			UPDATE ST_GIOQUETTHE 
			SET NP_MA = NULL
			 WHERE QT_NGAY IN (SELECT * FROM #ngayChuNhat)
			 AND NP_MA IS NOT NULL

----------------------------------------------------------------------------------SỐ THÁNG TÍNH THƯỞNG THÁNG 13-----------------------------------------------------------------------------
---------------------------------------------------------TH 1 (Tính thời gian tính thưởng gồm giờ làm việc và trừ các phép ('No1','No2','RO','O','N','N1') kể cả tháng bị OX--------------------------------
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT NV_Ma,NV_Ngayvao,DV_MA
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'01','2024'),0) Thang1
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'02','2024'),0) Thang2
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'03','2024'),0) Thang3
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'04','2024'),0) Thang4
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'05','2024'),0) Thang5
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'06','2024'),0) Thang6
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'07','2024'),0) Thang7
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'08','2024'),0) Thang8
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'09','2024'),0) Thang9
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'10','2024'),0) Thang10
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'11','2024'),0) Thang11
		,ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'12','2024'),0) Thang12						
		,[SoThangThuongThang13(CoTinhOX)]= ROUND(
									(
									 (
										ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'01','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'02','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'03','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'04','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'05','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'06','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'07','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'08','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'09','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'10','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'11','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuongOX_A(NV_Ma,'12','2024'),0)
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
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'01','2024'),0) Thang1
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'02','2024'),0) Thang2
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'03','2024'),0) Thang3
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'04','2024'),0) Thang4
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'05','2024'),0) Thang5
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'06','2024'),0) Thang6
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'07','2024'),0) Thang7
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'08','2024'),0) Thang8
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'09','2024'),0) Thang9
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'10','2024'),0) Thang10
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'11','2024'),0) Thang11
		,ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'12','2024'),0) Thang12						
		,[SoThangThuongHeSoBinhBau(KhongTinhOX)]= ROUND(
									(
									 (
										ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'01','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'02','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'03','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'04','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'05','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'06','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'07','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'08','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'09','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'10','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'11','2024'),0)
										+ISNULL(dbo.fn_LayGioTinhThuong_A(NV_Ma,'12','2024'),0)
									 )/8
									)/CAST(26 AS FLOAT) --Chuyển dạng số thực 1 số để ra được thập phân
								  ,1)

FROM ST_NHANVIEN
WHERE DV_Ma NOT LIKE N'NV%'
	AND DV_Ma NOT IN ('BGD','CG')

--------------------
SELECT dbo.fn_LayGioTinhThuongOX_A('310913','01','2024')
SELECT dbo.fn_LayGioTinhThuongOX_A('310913','04','2024')
SELECT dbo.fn_LayGioTinhThuong_A('310913','04','2024')




