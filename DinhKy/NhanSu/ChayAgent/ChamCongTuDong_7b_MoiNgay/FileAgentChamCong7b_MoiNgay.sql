-----------------------------------FileAgentChamCong7b_MoiNgay-----------------------------------
-------------------------Ngày chấm là ngày hôm trước, trước ngày chạy Agent
---------------Nếu ngày chấm là ngày cuối tháng thì không chấm vì Agent trên đã chạy rồi chấm lại sẽ mất công tay---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B1_ChamCongNghiPhep-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN
		------1. Chấm công nghỉ phép-------------------------------
		EXEC SP_CHAMCONGNGHIPHEP @Ngay
	END

---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------	
-------------------------------B2_CapNhatNghiPhep-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN
		-----2. Cập nhật nghỉ phép
		EXEC SP_CAPNHATNGHIPHEP_MACHINE @NGAY
	END
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------	
-------------------------------B3_ChamCongNgoaiLe-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN
		-----3. Chấm công ngoại lệ
		EXEC SP_CHAMCONGNGOAILE @NGAY
	END
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B4_ChamCongNuoiConNho-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN	
		-----4. Chấm công nuôi con nhỏ
		EXEC SP_CHAMCONGNUOICON @NGAY
	END
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------	
-------------------------------B5_ChamCongThaiSan-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN	
		-----5. Chấm công thai sản
		EXEC SP_CHAMCONGTHAISAN @NGAY
	END
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B6_TinhTangCa-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN	
		-----6. Tính tăng ca
		EXEC SP_CAPNHATTANGCA300 @NGAY
	END
---------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
-------------------------------B7_CapNhatGioCongTieuChuan-------------------------------
DECLARE @Ngay DATETIME, @NgayHT DATETIME,  @Thang INT, @Nam	INT
SET @NgayHT = Convert(DATETIME,Convert(VARCHAR(8),GetDate(),112)) -- Ép giờ hiện tại về 00:00:00.00
SET		@Ngay = CASE --Nếu là thứ 2 thì chấm lùi lại 2 ngày, ngược lại chấm lùi lại 1 ngày
					WHEN DATEPART(DW,@NgayHT) = 2  --(1:CN; 2>7 or <>1 là các ngày thứ)
						THEN DATEADD(DAY,-2,@NgayHT) 
					ELSE
						DATEADD(DAY,-1,@NgayHT) 
				END
SELECT @Ngay

SET @Thang = DATEPART(MONTH,GETDATE())
SET @Nam = DATEPART(YEAR,GETDATE())
SELECT @Ngay , @Thang, @Nam

--Nếu là ngày chấm không phải là ngày cuối tháng thì chấm công
IF (@Ngay != DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)))
	BEGIN
		-----7. Cập nhật giờ công tiêu chuẩn
		EXEC SP_TINH_VAORA_MC @Nam,  @Thang 
	END