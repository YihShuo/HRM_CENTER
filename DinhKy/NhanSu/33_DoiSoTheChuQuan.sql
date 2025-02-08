
DECLARE @nv_cu NVARCHAR(50), @nv_moi NVARCHAR(50);
SET @nv_cu = '340058'
SET @nv_moi = '351277'

SELECT * FROM ST_NHANVIEN WHERE NV_Ma = @nv_cu
SELECT * FROM MF_Users WHERE UserNo = @nv_cu

UPDATE ST_NHANVIEN SET NV_Ma = @nv_moi WHERE NV_Ma = @nv_cu
UPDATE MF_Users SET UserNo = @nv_moi WHERE UserNo = @nv_cu

SELECT * FROM ST_NHANVIEN WHERE NV_Ma = @nv_moi
SELECT * FROM MF_Users WHERE UserNo = @nv_moi