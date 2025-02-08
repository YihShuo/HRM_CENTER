USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_TONGGIOTANGCA_NHANVIEN]    Script Date: 29/11/2021 15:30:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	Hàm này phục phụ cho việc liệt kê số giờ làm việc hiện thị app LYG phần chấm công từng ngày trong tháng
*/
--EXEC SP_TinhGioLamViecThang_A @MANV=N'314844',    @Thang=N'02',     @Nam=N'2023' -- nvarchar(4)

ALTER  PROCEDURE [dbo].[SP_TinhGioLamViecThang_A]
	@MANV nvarchar(100),@Thang NVARCHAR(2),@Nam NVARCHAR(4)
AS
BEGIN
	DECLARE @ThangNam NVARCHAR(9)
	SET @ThangNam =  @Thang + '-' + @Nam 

	SELECT DV_MA,NV_Ma,NV_Ten,NV_Ngayvao
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'01',@ThangNam) AS [01]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'02',@ThangNam) AS [02]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'03',@ThangNam) AS [03]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'04',@ThangNam) AS [04]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'05',@ThangNam) AS [05]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'06',@ThangNam) AS [06]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'07',@ThangNam) AS [07]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'08',@ThangNam) AS [08]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'09',@ThangNam) AS [09]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'10',@ThangNam) AS [10]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'11',@ThangNam) AS [11]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'12',@ThangNam) AS [12]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'13',@ThangNam) AS [13]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'14',@ThangNam) AS [14]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'15',@ThangNam) AS [15]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'16',@ThangNam) AS [16]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'17',@ThangNam) AS [17]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'18',@ThangNam) AS [18]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'19',@ThangNam) AS [19]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'20',@ThangNam) AS [20]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'21',@ThangNam) AS [21]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'22',@ThangNam) AS [22]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'23',@ThangNam) AS [23]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'24',@ThangNam) AS [24]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'25',@ThangNam) AS [25]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'26',@ThangNam) AS [26]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'27',@ThangNam) AS [27]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'28',@ThangNam) AS [28]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'29',@ThangNam) AS [29]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'30',@ThangNam) AS [30]
		,dbo.fn_TinhGioLamViecNgay_A(NV_Ma,'31',@ThangNam) AS [31]
		,TOTAL1 = (SELECT SUM(ISNULL(CC_GIOBINHTHUONG,0)) + SUM(ISNULL(CC_GIOTANGCA,0)) --TOTAL1: Tổng giờ công + Tổng tăng ca
					FROM ST_GIOQUETTHE
					WHERE NV_MA = @MANV
						AND YEAR(QT_NGAY)=@Nam
						AND MONTH(QT_NGAY)=@Thang)
		,TOTAL2 = (SELECT SUM(ISNULL(CC_GIOBINHTHUONG,0))								--TOTAL2: Tổng giờ công 
					FROM ST_GIOQUETTHE
					WHERE NV_MA = @MANV
						AND YEAR(QT_NGAY)=@Nam
						AND MONTH(QT_NGAY)=@Thang)
		,TOTAL3 = (SELECT SUM(ISNULL(CC_GIOTANGCA,0))									--TOTAL3: Tổng tăng ca
					FROM ST_GIOQUETTHE
					WHERE NV_MA = @MANV
						AND YEAR(QT_NGAY)=@Nam
						AND MONTH(QT_NGAY)=@Thang)
		,Working_Time_Pregnancy = 0														
		,Check_In_Late = (SELECT SUM(ISNULL(CC_QUENQUETTHE,0))							--Check_In_Late: Số lần đi trễ
							FROM ST_GIOQUETTHE
							WHERE NV_MA = @MANV
								AND YEAR(QT_NGAY)=@Nam
								AND MONTH(QT_NGAY)=@Thang)
FROM ST_NHANVIEN 
WHERE NV_Ma = @MANV
End

