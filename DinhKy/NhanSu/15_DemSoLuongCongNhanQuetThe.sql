--=============================Thống Kê Số Lượng Quẹt Thẻ Máy Chấm Công===========================
/*--Lưu ý hàm DISTINCT
		Trường hợp có từ 2 cột trở lên thì kết quả trả về sẽ là các giá trị duy nhất của các cột được chọn.
		Mệnh đề DISTINCT trong SQL Server không bỏ qua giá trị NULL nên kết quả trả về sẽ bao gồm cả giá trị NULL duy nhất.*/
SELECT a.UserNo,b.NV_Ten,b.DV_MA,a.MatTime 
FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo=b.NV_Ma
WHERE YEAR(MatTime)='2024' AND MONTH(MatTime)='07' AND	DAY(MatTime)='19'
		AND	DATEPART(HOUR,MatTime) = '7'
		AND DATEPART(MINUTE,MatTime) >= '15' AND  DATEPART(MINUTE,MatTime) <= '30'
		AND DevNo='88'
ORDER BY a.MatTime

---------Cách I
SELECT  
		---DC
		SUM( CASE WHEN CONVERT(NVARCHAR(5),DevNo) = '250' THEN 1 ELSE 0 END) AS [DC---250]		
		---Lầu 1	
		,SUM( CASE WHEN DevNo = '117' THEN 1 ELSE 0 END) AS [NewOffice---117]
		,SUM( CASE WHEN DevNo = '95' THEN 1 ELSE 0 END) AS [Lau1-KVT---95]
		---Lầu 3
		,SUM( CASE WHEN DevNo = '109' THEN 1 ELSE 0 END) AS [Lau3-B-Phai---109]
		,SUM( CASE WHEN DevNo = '89' THEN 1 ELSE 0 END) AS [Lau3-B-Trai---89]
		---Lầu 4
		,SUM( CASE WHEN DevNo = '74' THEN 1 ELSE 0 END) AS [Lau4-A---74]
		,SUM( CASE WHEN DevNo = '73' THEN 1 ELSE 0 END) AS [Lau4-B-Phai---73]
		,SUM( CASE WHEN DevNo = '104' THEN 1 ELSE 0 END) AS [Lau4-B-Trai---104]
		---Xưởng A
		,SUM( CASE WHEN DevNo = '97' THEN 1 ELSE 0 END) AS [Xuong-A-Trai---97]
		,SUM( CASE WHEN DevNo = '110' THEN 1 ELSE 0 END) AS [Xuong-A-Phai---110]
		---Xưởng B
		,SUM( CASE WHEN CONVERT(NVARCHAR(5),DevNo) = '88' THEN 1 ELSE 0 END) AS [Xuong B-Lau1---88]
		,SUM( CASE WHEN DevNo = '96' THEN 1 ELSE 0 END) AS [Xuong B-Lau2-Phai---96]
		,SUM( CASE WHEN DevNo = '111' THEN 1 ELSE 0 END) AS [Xuong B-Lau2-Trai---96]
		---Xưởng D
		,SUM( CASE WHEN DevNo = '105' THEN 1 ELSE 0 END) AS [XuongD---105]
FROM MF_Record
WHERE YEAR(MatTime)='2024' AND MONTH(MatTime)='07' AND	DAY(MatTime)='19'
		AND	DATEPART(HOUR,MatTime) = '7'
		AND DATEPART(MINUTE,MatTime) >= '15' AND  DATEPART(MINUTE,MatTime) <= '30'
---------Cách II
SELECT '192.168.79.'+DevNo AS [Số Máy],COUNT(DevNo) AS [Số Công Nhân Quẹt]
FROM MF_Record
WHERE YEAR(MatTime)='2024' AND MONTH(MatTime)='04' AND	DAY(MatTime)='06'
		AND	DATEPART(HOUR,MatTime) = '7'
		AND DATEPART(MINUTE,MatTime) >= '15' AND  DATEPART(MINUTE,MatTime) <= '30'
		AND DevNo IN ('18','16','19','24','32')
GROUP BY DevNo
ORDER BY COUNT(DevNo)

--===================Tim Cu The Ten==================================
SELECT b.NV_Ma,b.NV_Ten,b.DV_MA,a.MatTime,a.DevNo
FROM MF_Record a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
WHERE YEAR(MatTime)='2024' AND MONTH(MatTime)='04' AND	DAY(MatTime)='06'
		AND	DATEPART(HOUR,MatTime) = '7'
		AND DATEPART(MINUTE,MatTime) >= '15' AND  DATEPART(MINUTE,MatTime) <= '30'
		AND DevNo IN ('18','16','19','24','32')
ORDER BY a.DevNo
--=============================================Xóa Thử Quẹt Thẻ

--SELECT UserNo, MatTime, DevNo 
--FROM MF_Record 
--WHERE YEAR(MatTime)='2024' AND MONTH(MatTime)='07' AND	DAY(MatTime)='19'
--		--AND DATEPART(HOUR,MatTime) = '7'
--		--AND DATEPART(MINUTE,MatTime) >= '15' AND  DATEPART(MINUTE,MatTime) <= '30'
--		--AND DevNo='88'
--		AND UserNo = '322857'
--ORDER BY MatTime

--DELETE MF_Record 
--WHERE YEAR(MatTime)='2024' AND MONTH(MatTime)='07' AND	DAY(MatTime)='19'
--		--AND DATEPART(HOUR,MatTime) = '7'
--		--AND DATEPART(MINUTE,MatTime) >= '15' AND  DATEPART(MINUTE,MatTime) <= '30'
--		--AND DevNo='88'
--		AND UserNo = '322857'
--		AND MatTime = '2024-04-14 08:22:00.000'

----Xóa Vào Ra
--SELECT * FROM ST_VAORA WHERE QT_NGAY = '2024-04-14' AND NV_MA = '322857'
----UPDATE ST_VAORA SET	QT_GIORA = NULL WHERE QT_NGAY = '2024-04-14' AND NV_MA = '322857'


