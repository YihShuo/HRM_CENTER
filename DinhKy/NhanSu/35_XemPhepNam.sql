----------------Công Thức Tính Phép NămBên LYG------------
SELECT a.NV_Ma AS [Mã NV] ,b.NV_Ten AS [Tên NV],b.NV_Ngayvao AS [Ngày Vào]
		,a.PN_Songaynamtruoc AS [Phép Năm Năm Trước],a.PN_Songaynamnay AS [Phép Năm Năm Nay]
		,a.PN_PhepTren5Nam AS [Phép Năm Trên 5 Năm],a.PN_NangnhocDH AS [Phép Nặng Nhọc (ĐH)]
		,a.PN_SothanglamNNDH AS [Số Tháng Nặng Nhọc (ĐH)],c.SONGAYDANGHI AS [Số ngày đã nghĩ]
		,CASE 
			WHEN (a.PN_Songaynamtruoc < 0) THEN (c.SONGAYDANGHI + a.PN_Songaynamtruoc)
			ELSE c.SONGAYDANGHI 
		 END	AS [Tổng đã nghĩ thực tế]
		,a.PN_Songaynamtruoc+a.PN_Songaynamnay+a.PN_PhepTren5Nam+a.PN_NangnhocDH - c.SONGAYDANGHI AS [Số Ngày Còn Lại]
FROM ST_PHEPNAM a INNER JOIN	ST_NHANVIEN b ON a.NV_Ma = b.NV_Ma
				  INNER JOIN (SELECT np.NV_Ma,SUM(DATEDIFF(DD,NP_TUNGAY,NP_DENNGAY)-GIOTT+1) AS SONGAYDANGHI 
							FROM (SELECT NV_Ma,NP_TUNGAY,NP_DENNGAY, case when NP_GhiChu like N'%0.5%' then 0.5 else 0 end as GIOTT 
								  FROM ST_NHANVIENNGHIPHEP 
								  WHERE NV_MA = '321928' AND YEAR(NP_TUNGAY) = '2025' AND NP_MA = 'P') np
							GROUP BY np.NV_Ma
						    ) c ON  A.nv_ma = C.NV_Ma
WHERE a.NV_Ma = '321928'
AND a.PN_Nam = '2025'
--------------------Công Thức Tính Bên HRM
--Số Ngày Đã Nghĩ
SELECT SUM(DATEDIFF(DD,NP_TUNGAY,NP_DENNGAY)-GIOTT+1 - A.SN_CHUNHAT) AS SONGAYDANGHI 
FROM (SELECT NP_TUNGAY,NP_DENNGAY,SN_CHUNHAT, 
									CASE when NP_GhiChu like N'%0.5%' then 0.5 else 0 end as GIOTT 
	  FROM ST_NHANVIENNGHIPHEP 
	  WHERE NV_MA = '321928' AND YEAR(NP_TUNGAY) = '2025' AND NP_MA = 'P'
	  ) A
--------------------Xem các phép đã nghỉ của năm
SELECT NV_Ma, NP_Ma, SUM(DATEDIFF(day, NP_TuNgay, NP_DenNgay) + 1) AS SoNgayNghi
FROM ST_NHANVIENNGHIPHEP
WHERE YEAR(NP_TUNGAY) = '2025'
	AND NV_Ma = '321928'
GROUP BY NV_Ma, NP_Ma;
--------------------Xem đếm các ngày chủ nhật
SELECT *,DATEDIFF(WEEK, NP_TUNGAY,NP_DENNGAY) 
			+ CASE WHEN DATENAME(WEEKDAY, NP_TUNGAY) = 'Sunday' THEN 1 ELSE 0 END 
			AS SoNgayChuNhat
FROM ST_NHANVIENNGHIPHEP
WHERE YEAR(NP_TUNGAY) = '2025'
AND NV_Ma = '321928'
ORDER BY SN_CHUNHAT DESC
--------------------Cập nhật lại các ngày tính Chủ Nhật Sai
SELECT *,DATEDIFF(WEEK, NP_TUNGAY,NP_DENNGAY)									--Đếm số ngày CN bằng đếm lần đi qua ngày CN DateIff(Week) = 1 (chỉ có tác dụng khi Xuất phát từ T2 vì nếu xuất phát từ CN 
		+ CASE WHEN DATENAME(WEEKDAY, NP_TUNGAY) = 'Sunday' THEN 1 ELSE 0 END   -- thì sẽ ko tính ngày CN đó, nên phải Cộng bù nếu ngày bắt đầu ngay ngày CN 
			AS SoNgayChuNhat
FROM ST_NHANVIENNGHIPHEP
WHERE YEAR(NP_TUNGAY) = '2025'
AND SN_CHUNHAT <> (DATEDIFF(WEEK, NP_TUNGAY,NP_DENNGAY) 
			+ CASE WHEN DATENAME(WEEKDAY, NP_TUNGAY) = 'Sunday' THEN 1 ELSE 0 END )
ORDER BY NP_TuNgay DESC

--UPDATE ST_NHANVIENNGHIPHEP
SET SN_CHUNHAT = DATEDIFF(WEEK, NP_TUNGAY,NP_DENNGAY) 
			+ CASE WHEN DATENAME(WEEKDAY, NP_TUNGAY) = 'Sunday' THEN 1 ELSE 0 END 
WHERE YEAR(NP_TUNGAY) = '2025'
AND SN_CHUNHAT <> (DATEDIFF(WEEK, NP_TUNGAY,NP_DENNGAY) 
			+ CASE WHEN DATENAME(WEEKDAY, NP_TUNGAY) = 'Sunday' THEN 1 ELSE 0 END )


--------------------Xem các phép đã nghỉ của năm
SELECT * FROM ST_PHEPNAM WHERE NV_Ma = '321928' AND PN_Nam = '2025'

SELECT NP_MA,* 
FROM ST_GIOQUETTHE 
WHERE NV_MA = '321928' AND YEAR(QT_NGAY) = '2025' AND NP_MA = 'TS'