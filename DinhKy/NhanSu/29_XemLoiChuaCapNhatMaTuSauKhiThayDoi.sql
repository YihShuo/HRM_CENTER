SELECT a.NV_Ma,a.NV_MaTu,b.UserNo,b.CardNo
FROM ST_NHANVIEN a INNER JOIN MF_Users b ON a.NV_Ma = b.UserNo
AND  a.NV_Ma = '321558'

SELECT UserNo,CardNo,MatTime,DevNo
FROM MF_Record
WHERE UserNo = '321558'
AND CONVERT(DATE,MatTime) >= '2023-01-01'
ORDER BY MatTime DESC