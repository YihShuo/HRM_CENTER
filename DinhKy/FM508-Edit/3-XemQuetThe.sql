USE [FM508]
GO
------------------------------------------Xem Quẹt Thẻ---------------------
DECLARE @Nam INT,@Thang INT,@Ngay INT
SET @Nam ='2024'
SET @Thang = '12'
SET @Ngay = DATEPART(DAY,GETDATE())
--SET @Ngay = '11'

--Gio lay the
Select  value AS GioLayDL From t_AppParams WHERE ParamID ='timingRetrieve_l'--16:46,18:16,20:16
------------Xem Top 3 lấy thẻ gần đây nhất
SELECT TOP 3 b.DeptID,b.empname,a.* 
FROM t_mf_RecData a INNER JOIN employee b ON a.UserNo = b.EmpID
WHERE YEAR(RecTime)='2024'
	AND MONTH(RecTime)=@Thang
	AND DAY(RecTime)=@Ngay
	--AND	 a.DevNo = '3'
	--AND a.UserNo ='314844'
ORDER BY a.RecTime DESC
------------Xem Lấy thẻ máy IT
SELECT b.DeptID,b.empname,a.* 
FROM t_mf_RecData a INNER JOIN employee b ON a.UserNo = b.EmpID
WHERE YEAR(RecTime)='2024'
	AND MONTH(RecTime)=@Thang
	AND DAY(RecTime)=@Ngay
	--AND	 a.DevNo = '3'
	AND a.UserNo ='314844'
Union
SELECT b.DeptID,b.empname,a.* 
FROM t_mf_RecData a INNER JOIN employee b ON a.UserNo = b.EmpID
WHERE YEAR(RecTime)='2024'
	AND MONTH(RecTime)=@Thang
	AND DAY(RecTime)=@Ngay-1
	--AND	 a.DevNo = '3'
	AND a.UserNo ='314844'
ORDER BY a.DevNo,a.RecTime
------------Xem Lấy thẻ tấc cả máy
SELECT a.DevNo,COUNT(b.empname)
FROM t_mf_RecData a INNER JOIN employee b ON a.UserNo = b.EmpID
WHERE YEAR(RecTime)='2024'
	AND MONTH(RecTime)=@Thang
	AND DAY(RecTime)=@Ngay
	--AND	 a.DevNo = '3'
	--AND a.UserNo ='314844'
GROUP BY a.DevNo
ORDER BY a.DevNo
------------Xem tổng quẹt thẻ
SELECT COUNT(a.RecTime) AS [TongQuetThe]
FROM t_mf_RecData a INNER JOIN employee b ON a.UserNo = b.EmpID
WHERE YEAR(RecTime)='2024'
	AND MONTH(RecTime)=@Thang
	AND DAY(RecTime)=@Ngay
	--AND	 a.DevNo = '3'
	--AND a.UserNo ='314844'


/*xem tấc cả cac máy mới cũ
SELECT a.DevNo,COUNT(a.UserNo) --Dùng DISTINCT và bỏ ra cột MatTime để loại trừ quẹt 2 lần
FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
WHERE  YEAR(MatTime)='2024'
	AND MONTH(MatTime)='10'
	AND DAY(MatTime) IN ('03')
	AND a.DevNo <>'250'
	--AND a.UserNo='310330'
	AND DATEPART(HOUR,a.MatTime)<'15'
	--AND b.DV_MA = 'NS'
	GROUP BY a.DevNo
	ORDER BY CONVERT(NUMERIC,a.DevNo)

*/