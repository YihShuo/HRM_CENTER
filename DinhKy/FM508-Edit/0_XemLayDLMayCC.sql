

--===========================================Tìm xem đã hoàn tất chấm công từ máy quẹt thẻ hay chưa
--Theo thứ tự quẹt cuối cùng từ máy
SELECT c.Clock_name,a.*,b.empname,b.DeptID,CASE 
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

--Theo thứ tự chấm trễ nhất trong ngày
SELECT c.Clock_name,a.*,b.empname,b.DeptID,CASE 
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
ORDER BY DATEDIFF(MINUTE,a.RecTime,a.ProcessedTime) DESC

--Theo thứ tự chấm trễ nhất qua ngày
SELECT c.Clock_name,a.*,b.empname,b.DeptID 
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
--=================================== Tìm xem lấy t_mf_RecData1 con thiếu từ t_mf_RecData ======================
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
--===================Trường hợp Dept ID số lớn quá thì reset=============================
--DBCC CHECKIDENT ('t_mf_RecData1', RESEED, 0);


--SELECT  * FROM t_mf_RecData WHERE CAST(RecTime AS DATE) = CAST(GETDATE() AS DATE) ORDER BY RecTime DESC
--SELECT * FROM t_mf_RecData1 WHERE CAST(RecTime AS DATE) = CAST(GETDATE() AS DATE) ORDER BY RecTime DESC
