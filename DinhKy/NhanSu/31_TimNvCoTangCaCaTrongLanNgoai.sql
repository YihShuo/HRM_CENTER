------------------------Do lấy lại dữ liệu máy chấm công, nên sẽ có trường hợp bị trùng vừa có tăng ca công trong và công ngoài, nên NS sẽ nhờ xuất DS này mỗi cuối tháng
---------để tránh sai sót. (Vì theo qui định hiện hành hễ nhập tay giờ công thì phải nhập hết ra công ngoài để dễ quản lý

SELECT a.NV_MA,a.QT_NGAY,a.CC_GIOTANGCA,b.CC_GIOTANGCA,a.DV_MA
FROM ST_GIOQUETTHE a INNER JOIN ST_GIOQUETTHE_ b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY AND a.CC_GIOTANGCA=b.CC_GIOTANGCA
WHERE YEAR(b.QT_NGAY) = '2024'
AND MONTH(b.QT_NGAY) = '12'
AND	a.CC_GIOTANGCA >0
