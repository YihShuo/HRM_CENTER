

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

