-----------------------------------FileAgentChamCong7b_Cuối Tháng-----------------------------------
-------------------------Ngày chấm trong ngày và cùng ngày chạy Agent phải cài chạy cuối tháng
-------------------------------B1_ChamCongNghiPhep-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

------1. Chấm công nghỉ phép-------------------------------
EXEC SP_CHAMCONGNGHIPHEP @Ngay

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------	
-------------------------------B2_CapNhatNghiPhep-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

-----2. Cập nhật nghỉ phép
EXEC SP_CAPNHATNGHIPHEP_MACHINE @NGAY

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------	
-------------------------------B3_ChamCongNgoaiLe-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

-----3. Chấm công ngoại lệ
EXEC SP_CHAMCONGNGOAILE @NGAY

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B4_ChamCongNuoiConNho-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

	
-----4. Chấm công nuôi con nhỏ
EXEC SP_CHAMCONGNUOICON @NGAY

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------	
-------------------------------B5_ChamCongThaiSan-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

	
-----5. Chấm công thai sản
EXEC SP_CHAMCONGTHAISAN @NGAY

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B6_TinhTangCa-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

	
-----6. Tính tăng ca
EXEC SP_CAPNHATTANGCA300 @NGAY

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B7_CapNhatGioCongTieuChuan-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = @NgayHT
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

-----7. Cập nhật giờ công tiêu chuẩn
EXEC SP_TINH_VAORA_MC @Nam,  @Thang 