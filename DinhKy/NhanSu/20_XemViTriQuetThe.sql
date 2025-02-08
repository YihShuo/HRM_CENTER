SELECT a.UserNo,a.MatTime,a.DevNo,b.NV_Ten,b.DV_MA
FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
WHERE UserNo ='321541'
	AND YEAR(MatTime)='2023'
	AND MONTH(MatTime)='04'
	AND DAY(MatTime)='24'
	--AND DAY(MatTime) >=1 AND  DAY(MatTime) <=28
ORDER BY a.MatTime

SELECT a.UserNo,a.MatTime,a.DevNo,b.NV_Ten,b.DV_MA
FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
WHERE YEAR(MatTime)='2023'
	AND MONTH(MatTime)='04'
	AND DAY(MatTime)='24'
	AND b.DV_MA = 'IT'
ORDER BY a.MatTime
