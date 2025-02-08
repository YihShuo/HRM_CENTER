---Cách 1: Lấy từ máy chấm công Do chưa chấm công nên dựa vào giờ quẹt thẻ
SELECT DISTINCT a.UserNo,a.DevNo,b.NV_Ten,b.DV_MA --Dùng DISTINCT và bỏ ra cột MatTime để loại trừ quẹt 2 lần
FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
WHERE  YEAR(MatTime)='2023'
	AND MONTH(MatTime)='08'
	AND DAY(MatTime) IN ('15')
	AND a.DevNo <>'250'
	--AND a.UserNo='310330'
	AND DATEPART(HOUR,a.MatTime)<'15'
	--AND b.DV_MA = 'NS'
	ORDER BY a.UserNo

----- Xem quẹt nhiều lần
--SELECT a.UserNo,COUNT(a.UserNo) AS STT
--FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
--WHERE  YEAR(MatTime)='2023'
--	AND MONTH(MatTime)='07'
--	AND DAY(MatTime) IN ('22')
--	AND a.DevNo <>'250'
--	--AND a.UserNo='314844'
--	AND DATEPART(HOUR,a.MatTime)<'15'
--	--AND b.DV_MA = 'NS'
--GROUP BY a.UserNo 
--ORDER BY STT DESC

---Cách 2: Xem ngày hôm trước (căn cứ trên dữ liệu đã chấm công)
--SELECT *
--FROM ST_GIOQUETTHE
--WHERE QT_NGAY = '2023-02-20'
--	AND CC_GIOBINHTHUONG > 0
--	AND DV_MA NOT LIKE 'HCM%'
--	ORDER BY CA_MA