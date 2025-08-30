

--===========================================Tìm xem đã hoàn tất chấm công từ máy quẹt thẻ hay chưa
--Theo thứ tự quẹt cuối cùng từ máy
SELECT c.Clock_name,a.*,b.empname,b.DeptID,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.CopyTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.CopyTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Copy'
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Xử lý'
FROM t_mf_RecData1 a INNER JOIN employee b ON a.UserNo = b.EmpID
					LEFT JOIN t_Clocks c ON a.DevNo = c.Clock_ID
WHERE CAST(a.RecTime AS DATE) = CAST(GETDATE() AS DATE) 
ORDER BY RecTime DESC

--Theo thứ tự chấm lâu nhất trong ngày
SELECT c.Clock_name,a.*,b.empname,b.DeptID,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.CopyTime) < '60'
									THEN CAST(DATEDIFF(MINUTE,a.RecTime,a.CopyTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Copy'
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) < '60'
									THEN CAST(DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Xử lý'
FROM t_mf_RecData1 a INNER JOIN employee b ON a.UserNo = b.EmpID
					LEFT JOIN t_Clocks c ON a.DevNo = c.Clock_ID
WHERE CAST(a.RecTime AS DATE) = CAST(GETDATE() AS DATE) 
ORDER BY DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) DESC

--Theo thứ tự chấm trễ nhất qua ngày
SELECT c.Clock_name,a.*,b.empname,b.DeptID 
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.CopyTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.CopyTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Copy'
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Xử lý'
FROM t_mf_RecData1 a INNER JOIN employee b ON a.UserNo = b.EmpID
					LEFT JOIN t_Clocks c ON a.DevNo = c.Clock_ID
WHERE CAST(a.RecTime AS DATE) < CAST(GETDATE() AS DATE) 
AND CAST(a.ProcessedTime AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY (a.ProcessedTime - a.RecTime) DESC

--=================================== Tìm xem còn bao nhiêu chưa chấm======================
SELECT c.Clock_name,a.*,b.empname,b.DeptID ,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.CopyTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.CopyTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Copy'
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Xử lý'
FROM t_mf_RecData1 a INNER JOIN employee b ON a.UserNo = b.EmpID
					LEFT JOIN t_Clocks c ON a.DevNo = c.Clock_ID
WHERE CAST(a.RecTime AS DATE) = CAST(GETDATE() AS DATE) 
AND a.Processed = '0'
ORDER BY RecTime DESC

--=================================== Tìm xem Lấy dữ liệu thiếu (Có ngày Copy khác ngày Gốc ======================
SELECT c.Clock_name,a.*,b.empname,b.DeptID 
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.CopyTime) < '60'
									THEN Cast(DATEDIFF(MINUTE,a.RecTime,a.CopyTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.CopyTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Copy'
								,CASE 
								WHEN DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) < '60'
									THEN CAST(DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) AS NVARCHAR) + N' phút'
								ELSE
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)/60)AS NVARCHAR) + N' tiếng'
									+
									CAST((DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime)%60) AS NVARCHAR) + N' phút'
								END AS N'Time Xử lý'
FROM t_mf_RecData1 a INNER JOIN employee b ON a.UserNo = b.EmpID
					LEFT JOIN t_Clocks c ON a.DevNo = c.Clock_ID
WHERE CAST(RecTime AS DATE) < CAST(GETDATE() AS DATE) 
		AND DATEPART(DAY,RecTime) <> DATEPART(DAY,CopyTime) 
		AND CAST(a.ProcessedTime AS DATE)=CAST(GETDATE() AS DATE)
ORDER BY (a.ProcessedTime - a.RecTime) DESC

--================================== Tìm xem lấy t_mf_RecData1 con thiếu từ t_mf_RecData ======================
--SELECT * 
--FROM t_mf_RecData AS A
--WHERE NOT EXISTS ( SELECT 1
--					FROM t_mf_RecData1 AS B
--					WHERE a.UserNo = b.UserNo
--						AND a.RecTime = b.RecTime
--					)
--	AND CAST(a.RecTime AS DATE) = CAST(GETDATE() AS DATE) 


--===================Kiểm tra Agent trang thái xem có bị kẹt hay không (IsRunning = 1)
SELECT * FROM dbo.JobLock
--UPDATE dbo.JobLock SET IsRunning = '0'
--===================Trường hợp Dept ID số lớn quá thì reset=============================
--DBCC CHECKIDENT ('t_mf_RecData1', RESEED, 0);


/*

SELECT  count(UserNo) FROM t_mf_RecData WHERE CAST(RecTime AS DATE) = CAST(GETDATE() AS DATE) --ORDER BY RecTime DESC
SELECT count(UserNo) FROM t_mf_RecData1 WHERE CAST(RecTime AS DATE) = CAST(GETDATE() AS DATE) --ORDER BY RecTime DESC

*/

SELECT  UserNo,CardNo,RecTime,DevNo,modifytime FROM t_mf_RecData WHERE CAST(RecTime AS DATE) = CAST(GETDATE() AS DATE) ORDER BY RecTime DESC
SELECT  UserNo,CardNo,RecTime,DevNo,modifytime FROM t_mf_RecData WHERE CAST(RecTime AS DATE)  = CAST(GETDATE() AS DATE) AND modifytime IS NULL ORDER BY RecTime DESC
SELECT  * FROM t_mf_RecData1 WHERE CAST(RecTime AS DATE) = CAST(GETDATE() -1 AS DATE) AND UserNo ='317472' ORDER BY RecTime DESC


SELECT  * 
FROM t_mf_RecData
WHERE CAST(RecTime AS DATE) = CAST(GETDATE()-2 AS DATE)
AND UserNo = '339420' ORDER BY RecTime DESC

SELECT  * 
FROM t_mf_RecData1
WHERE CAST(RecTime AS DATE) = CAST(GETDATE()-2 AS DATE)
AND UserNo = '339420' ORDER BY RecTime DESC

SELECT * 
FROM t_mf_RecData1 
WHERE CAST(RecTime AS DATE) = CAST(GETDATE()-1 AS DATE) AND DATEPART(DAY,RecTime) <> DATEPART(DAY,CopyTime)
--ORDER BY RecTime DESC

