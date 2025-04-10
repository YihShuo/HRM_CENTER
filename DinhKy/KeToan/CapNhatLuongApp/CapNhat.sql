-------------------------Copy File Excel vào bảng sau là được--------------------
---------------------------------------------------------------------------------LƯƠNG-------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------
---Server trên Lạc Tỷ là 192.168.0.63 LDT/lacty123-------------
SELECT TOP 1* FROM Data_Salary_Person WHERE Month_Year = '09-2025'
--DELETE Data_Salary_Person WHERE Month_Year = '01-2025'

----------------------------------------------------------------
SELECT ThucLanh,TIENLAMTHEM,* 
FROM Data_Salary_Person 
WHERE Person_ID='314844' AND SUBSTRING(Month_Year,4,4)='2025'
ORDER BY SUBSTRING(Data_Salary_Person.Month_Year,1,2) DESC
----------------------------------------------------------------
SELECT ThucLanh,TIENLAMTHEM,* 
FROM Data_Salary_Person 
WHERE Month_Year = '09-2025'
	--AND Department_ID = 'IT'
	AND Person_ID='314844'
ORDER BY Data_Salary_Person.ThucLanh DESC



--Ba tháng gần nhất
SELECT ThucLanh,TIENLAMTHEM,* 
FROM Data_Salary_Person 
WHERE LEFT(Month_Year,2) IN( DATEPART(MONTH,GETDATE())-1,DATEPART(MONTH,GETDATE())-2,DATEPART(MONTH,GETDATE())-3,DATEPART(MONTH,GETDATE())-4,DATEPART(MONTH,GETDATE())-5,DATEPART(MONTH,GETDATE())-6)
	AND RIGHT(Month_Year,4) = '2025'
	--AND Department_ID = 'IT'
	AND Person_ID='314844'

----------------------------------------------------------------
SELECT FORMAT(ThucLanh,'#,###'),FORMAT(TIENLAMTHEM,'#,###'),* 
FROM Data_Salary_Person 
WHERE Month_Year = '01-2025'
	AND Department_ID = 'HCM-TONGVU' AND Person_ID IN ('339967','339968','340055','340056','318366','318787')
	--AND Person_ID=''
ORDER BY Data_Salary_Person.ThucLanh DESC
---------------------------------------------------------------------------------THƯỞNG-------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT * FROM Data_Salary_Month_13 WHERE YEAR = '2025' AND Person_ID IN ( '314844','313582')

SELECT a.Real_Total_Bonus,b.NV_Ten,b.DV_MA,b.*
FROM Data_Salary_Month_13 a INNER JOIN ST_NHANVIEN b ON a.Person_ID = b.NV_Ma
WHERE b.DV_MA = 'IT'
	AND a.Year ='2025'

SELECT a.Real_Total_Bonus,b.NV_Ten,b.DV_MA,b.*
FROM Data_Salary_Month_13 a INNER JOIN ST_NHANVIEN b ON a.Person_ID = b.NV_Ma
WHERE  a.Year ='2025'
ORDER BY a.Real_Total_Bonus DESC