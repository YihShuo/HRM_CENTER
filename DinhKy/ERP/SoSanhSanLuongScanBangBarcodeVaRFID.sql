----------------------------------------------------/*So sánh sản lượng scan bằng BARCODE VÀ RFID*/-------------------------------------------------------

--Tìm đơn vị nào có scan RFID trong ngày, hoặc scan hôm qua

--SELECT ID FROM LIY_TYTHAC.dbo.RFID_TempAssembly WHERE CAST(Userdate AS DATE) = CAST(GETDATE() AS DATE) GROUP BY ID
SELECT * FROM BDepartment WHERE ID IN (SELECT ID FROM LIY_TYTHAC.dbo.RFID_TempStitching WHERE CAST(Userdate AS DATE) = CAST(GETDATE()-1 AS DATE) GROUP BY ID)
SELECT * FROM BDepartment WHERE ID IN (SELECT ID FROM LIY_TYTHAC.dbo.RFID_TempAssembly WHERE CAST(Userdate AS DATE) = CAST(GETDATE()-1 AS DATE) GROUP BY ID)
--===============================================================================================================
--Lean 6 Chuyền May và Gò
SELECT * FROM BDepartment WHERE GXLB = 'S' AND yn = '1' AND ID = 'VDH0587' --May 6
SELECT * FROM BDepartment WHERE GXLB = 'A' AND yn = '1' AND ID = 'VDH0527' --Go 6
--==============================================================================================================================
--============================================================May LEAN 6 'VDH0587'==============================================
--==============================================================================================================================
--QR

select * from SMDDSS WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM smzl 
								WHERE DepNO = 'VDH0587' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean May 6 (Hôm qua)
ORDER BY USERDate DESC
--RFID
select * from LIY_TYTHAC..SMDDSS_test WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM LIY_TYTHAC.dbo.SMZL_test 
								WHERE DepNO = 'VDH0587' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean May 6 (Hôm qua)
ORDER BY USERDate DESC

------------------------------ So Sánh Nhóm Theo Đơn Hàng-----------------------
--QR
select DDBH,SUM(CTS) AS CTS,SUM(okCTS) AS okCTS from SMDDSS WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM smzl 
								WHERE DepNO = 'VDH0587' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean May 6 (Hôm qua)
GROUP BY DDBH
ORDER BY DDBH DESC
--RFID
select DDBH,SUM(CTS) AS CTS,SUM(okCTS) AS okCTS from LIY_TYTHAC..SMDDSS_test WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM LIY_TYTHAC.dbo.SMZL_test 
								WHERE DepNO = 'VDH0587' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean May 6 (Hôm qua)
GROUP BY DDBH
ORDER BY DDBH DESC
--==============================================================================================================================
--============================================================GÒ LEAN 6 'VDH0527'==============================================
--==============================================================================================================================
--QR

select * from SMDDSS WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM smzl 
								WHERE DepNO = 'VDH0527' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean Go 6 (Hôm qua)
ORDER BY USERDate DESC
--RFID
select * from LIY_TYTHAC..SMDDSS_test WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM LIY_TYTHAC.dbo.SMZL_test
								WHERE DepNO = 'VDH0527' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean Go 6 (Hôm qua)
ORDER BY USERDate DESC

------------------------------ So Sánh Nhóm Theo Đơn Hàng-----------------------
--QR
select DDBH,SUM(CTS) AS CTS,SUM(okCTS) AS okCTS from SMDDSS WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM smzl 
								WHERE DepNO = 'VDH0527' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean Go 6 (Hôm qua)
GROUP BY DDBH
ORDER BY DDBH DESC
--RFID
select DDBH,SUM(CTS) AS CTS,SUM(okCTS) AS okCTS from LIY_TYTHAC..SMDDSS_test WHERE CODEBAR 
							IN (SELECT CODEBAR 
								FROM LIY_TYTHAC..smzl_test 
								WHERE DepNO = 'VDH0527' 
								AND CAST(ScanDate AS DATE) = CAST(GETDATE()-1 AS DATE)) --Lean Go 6 (Hôm qua)
GROUP BY DDBH
ORDER BY DDBH DESC
--================================================================================================================================
/*
/*Scan bằng Barcode*/
SELECT * from smzl where CODEBAR in (select CODEBAR from smddss where DDBH='JHS2506-136' and GXLB = 'A')

--/*Lấy đúng theo đơn vị có bên scan RFID*/
SELECT * from smzl where CODEBAR in (select CODEBAR from smddss where DDBH='JHS2506-136') 
		AND DepNO IN (select ID from LIY_TYTHAC.dbo.RFID_TempStitching where DDBH='JHS2506-136')
/*Scan bằng RFID*/
select * from LIY_TYTHAC.dbo.SMZL_test where CODEBAR in (select CODEBAR from smddss where DDBH='JHS2506-136'and GXLB = 'S')
select * from LIY_TYTHAC.dbo.RFID_TempStitching where DDBH='JHS2506-136'

select * from LIY_TYTHAC.dbo.SMZL_test where CODEBAR in (select CODEBAR from smddss where DDBH='JHS2506-136'and GXLB = 'A')
select * from LIY_TYTHAC.dbo.RFID_TempAssembly where DDBH='JHS2506-136'
*/