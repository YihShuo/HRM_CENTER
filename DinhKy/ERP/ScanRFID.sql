



--------------- Bảng khai báo lần đầu ghi tem size mới sẽ ghi vào đây--------------- 
select * FROM LIY_TYTHAC..RFID_SIZE
---------------Bản phần mềm hiện trường scan sẽ ghi vào đây--------------- 
--May
SELECT TOP 50 * FROM LIY_TYTHAC..RFID_TempStitching
--Gò
SELECT TOP 50 * FROM LIY_TYTHAC..RFID_TempAssembly
--Bảng SMDD Sinh QUản kéo
SELECT TOP 50 * FROM LYS_ERP..SMDDSS --WHERE DDBH = 'JHS2502-152-001' AND GXLB = 'S' AND XXCC = '50.5'
--
SELECT TOP 50 * FROM LYS_ERP..SMZL --WHERE CODEBAR = '000003180149'

SELECT TOP 1000 * FROM LIY_TYTHAC..RFID_TempAssembly ORDER BY Userdate DESC
SELECT TOP 1000 * FROM LIY_TYTHAC..SMDDSS_test ORDER BY Userdate DESC

SELECT distinct S.DDBH, SUM(S.QTY) AS QTY, S.ID, S.SIZE,SS.CODEBAR 
FROM RFID_TempStitching S
left join smddss_test SS on S.DDBH = SS.DDBH and  S.SIZE = SS.XXCC
WHERE status = 'N' 
AND S.DDBH = SS.DDBH
and S.SIZE=SS.XXCC
and SS.GXLB='S'
and SS.CTS>SS.okCTS
GROUP BY S.DDBH, S.ID, S.SIZE,SS.CODEBAR;