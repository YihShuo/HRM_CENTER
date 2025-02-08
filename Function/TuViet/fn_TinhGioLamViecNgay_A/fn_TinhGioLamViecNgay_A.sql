USE [P0104-TYTHAC]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_TinhGioLamViecNgay_A]    Script Date: 18/02/2023 7:33:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------Lấy giờ công làm việc trong ngày của nhân viên
ALTER FUNCTION [dbo].[fn_TinhGioLamViecNgay_A]
(
	@NV_MA AS NVARCHAR(10)
	,@Ngay NVARCHAR(2)
	,@ThangNam NVARCHAR(7)
)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @kq NVARCHAR(10),@NgayQT DATETIME, @NgayCuoiThang int
	
	
	SELECT @NgayCuoiThang = DAY(T_DENNGAY) 
	FROM ST_THANG
	WHERE T_MA = @ThangNam

	--Xét điều kiện đảm bảo ngày nhập không vượt quá ngày của tháng
	IF (@Ngay <= @NgayCuoiThang)
		BEGIN
			SET @NgayQT =CONVERT(DATETIME,@Ngay+'-'+@ThangNam,105)

			SELECT @kq = CASE 
							WHEN CC_GIOBINHTHUONG = 8
								THEN CONVERT(NVARCHAR(10),8)															--Làm đủ ngày
							ELSE
								CASE
									WHEN (ISNULL(CC_GIOBINHTHUONG,0) < 8 AND ISNULL(CC_GIOBINHTHUONG,0) <> 0 OR (CC_HESONGAYCONG = 2 AND CC_SOGIONGHI <> 8))
										THEN CONVERT(NVARCHAR(50),CC_GIOBINHTHUONG)+'('+ ISNULL(NP_MA,'')+')'			-- Làm chưa hết ngày
									ELSE
										CASE 
											WHEN  CC_SOGIONGHI = 8 AND CC_HESONGAYCONG <> 2 AND CC_HESONGAYCONG <> 3	--Nghỉ làm cả ngày
												THEN ISNULL(NP_MA,'')  
											ELSE
												CASE
													WHEN CC_GIOBINHTHUONG=0 and  CC_HESONGAYCONG = 3 AND QT_NGAY >= NV_NGAYVAO 
														THEN 'R'														--Nghỉ lễ
													ELSE ''														
												END 
										END 
								END 

						 END  
			FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a. NV_MA = b.NV_Ma
			WHERE a.NV_MA =@NV_MA
				AND QT_NGAY =@NgayQT
			
		END
	ELSE
		SELECT @kq = '0'	
	RETURN @kq
END
