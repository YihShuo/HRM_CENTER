---Qui định Tiền Hành Kinh chỉ được khi làm ít nhất 3 ngày LIÊN TỤC trở lên nhưng do Hệ Thống Chưa Tính Được Liên Tục Nên Phải cập nhật tay DS do Kế Toán Gửi Qua Hằng Tháng
------Cập Nhạt Lại TONGSOGIO = 0 sẽ mất bên Bảng Công và Bảng Lương
-----Cách 1: Cập nhật số lượng lớn
--SELECT * FROM A_NV_MA order by NV_MA
--DELETE A_NV_MA

DECLARE @Thang AS INT
SET @Thang = '1'

----UPDATE b
SET b.TONGSOGIO = '0'
FROM A_NV_MA a INNER JOIN IT_SOGIONGHIHANHKINH b ON a.NV_Ma = b.NV_MA AND b.NAM ='2023' AND b.THANG =@Thang

-----Cách 2: Cập nhật ít
SELECT * FROM IT_SOGIONGHIHANHKINH WHERE NV_MA = '324106' AND NAM = '2023' AND THANG = '3'
--UPDATE IT_SOGIONGHIHANHKINH SET TONGSOGIO = '0' WHERE NV_MA = '324106' AND NAM = '2023' AND THANG = '3'