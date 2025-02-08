USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_TONGSONGAYPHEP]    Script Date: 28/02/2024 1:38:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_TONGSONGAYPHEP]
	@NV_MA NVARCHAR(50)	
AS
Begin
	DECLARE @TUNGAY DATE
	DECLARE @DENNGAY DATE
	DECLARE @NP_MA NVARCHAR(50)
	Declare  NhanVien_Cur cursor FOR

		SELECT ST_NHANVIENNGHIPHEP.NV_MA, NP_TUNGAY,NP_DENNGAY,NP_MA 
		FROM ST_NHANVIENNGHIPHEP 
		WHERE NV_MA = @NV_MA
			AND CONVERT(DATE,NP_TuNgay) > = '2014-09-01' 
 
	Open NhanVien_Cur
	Fetch next from NhanVien_Cur into @NV_MA,@TUNGAY,@DENNGAY,@NP_MA

	While(@@Fetch_Status=0)--nếu khác 0 con trỏ đã quá hàng cuối nhóm
	Begin

		EXEC SP_TACHSONGAYNGHIPHEP @NV_MA,@TUNGAY,@DENNGAY,@NP_MA

		Fetch next from NhanVien_Cur into @NV_MA,@TUNGAY,@DENNGAY,@NP_MA
 
	End  
	Close NhanVien_Cur
	DEALLOCATE  NhanVien_Cur

end

