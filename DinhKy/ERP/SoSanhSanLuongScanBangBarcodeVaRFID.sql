----------------------------------------------------/*So sánh sản lượng scan bằng BARCODE VÀ RFID*/-------------------------------------------------------
--================================================================================================================================
--==============================================================================================================================
--============================================================May RFID===========================================================
--==============================================================================================================================
--RFID xem Sản lượng may trong ngày
--Xem chuyền nào có scan RFID
SELECT ID,DepName 
FROM LIY_TYTHAC.dbo.RFID_TempStitching 
WHERE CAST(Userdate AS DATE) = CAST(GETDATE()-0 AS DATE)
GROUP BY ID,DepName

--Xem Sản lượng
SELECT * 
FROM LIY_TYTHAC.dbo.RFID_TempStitching 
WHERE CAST(Userdate AS DATE) = CAST(GETDATE()-0 AS DATE)
	AND DepName = 'DT_M-LINE 6'
SELECT SUM(QTY) 
FROM LIY_TYTHAC.dbo.RFID_TempStitching 
WHERE CAST(Userdate AS DATE) = CAST(GETDATE()-0 AS DATE)
	AND DepName = 'DT_M-LINE 6'
--================================================================================================================================
--==============================================================================================================================
--============================================================May BARCODE===========================================================
--==============================================================================================================================
--Barcode xem Sản lượng may trong ngày
--Xem chuyền nào có scan barcode
SELECT a.DepNO,b.DepName
FROM SMZL a LEFT JOIN BDepartment b ON a.DepNO = b.ID
WHERE  CAST(Scandate AS DATE) = CAST(GETDATE()-0 AS DATE) 
	AND CODEBAR IN (SELECT CODEBAR FROM SMDDSS WHERE GXLB = 'S')
GROUP BY a.DepNO,b.DepName
--Xem sản lượng
SELECT a.*
FROM SMZL a LEFT JOIN BDepartment b ON a.DepNO = b.ID
WHERE  CAST(Scandate AS DATE) = CAST(GETDATE()-0 AS DATE) 
	AND CODEBAR IN (SELECT CODEBAR FROM SMDDSS WHERE GXLB = 'S')
	AND a.DepNO IN (SELECT a.DepNO FROM BDepartment WHERE  b.DepName = 'DT_M-LINE 6')

SELECT sum (CTS)
FROM SMZL a LEFT JOIN BDepartment b ON a.DepNO = b.ID
WHERE  CAST(Scandate AS DATE) = CAST(GETDATE()-0 AS DATE) 
	AND CODEBAR IN (SELECT CODEBAR FROM SMDDSS WHERE GXLB = 'S')
	AND a.DepNO in (SELECT a.DepNO FROM BDepartment WHERE  b.DepName = 'DT_M-LINE 6')

