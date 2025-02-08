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
								  WHERE NV_MA = '321574' AND YEAR(NP_TUNGAY) = '2024' AND NP_MA = 'P') np
							GROUP BY np.NV_Ma
						    ) c ON  A.nv_ma = C.NV_Ma
WHERE a.NV_Ma = '321574'
AND a.PN_Nam = '2024'
--------------------Xem các phép đã nghỉ của năm
SELECT NV_Ma, NP_Ma, SUM(DATEDIFF(day, NP_TuNgay, NP_DenNgay) + 1) AS SoNgayNghi
FROM ST_NHANVIENNGHIPHEP
WHERE YEAR(NP_TUNGAY) = '2024'
	AND NV_Ma = '321574'
GROUP BY NV_Ma, NP_Ma;
