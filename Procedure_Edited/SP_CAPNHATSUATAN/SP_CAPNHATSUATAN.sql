USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_CAPNHATSUATAN_]    Script Date: 15/06/2022 3:09:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_CAPNHATSUATAN_]
@Ngay datetime,@NV_MA nvarchar(50)
AS
Begin
Declare 
	@VaoTT datetime,
	@RaTT datetime,
	@VaotayTT datetime,
	@RatayTT datetime,
	@Suatan int,
	@SuatanTCa int,
	@CA_Ma nvarchar(10),
	@Giora datetime,
	@Giovao datetime,
	@Gioratam real,
	@GioLamThuong real,
	@GioTangCa real
	select @CA_Ma=CA_Ma , @GioLamThuong=CC_GIOBINHTHUONG, @GioTangCa = CC_GIOTANGCA from ST_GIOQUETTHE_ where NV_MA=@NV_MA and QT_Ngay=@Ngay
--	select @Giora=QT_Giora  from ST_VAORA_ where NV_MA=@NV_MA and QT_Ngay=@Ngay and Ca_ma=@CA_Ma
		select @Giovao=null,@Giovao=null
		select @VaoTT=null,@RaTT=null,@VaotayTT=null,@RatayTT=null
		select @VaoTT=QT_GIOVAO,@RaTT=QT_GIORA,@VaotayTT=QT_GIOVAOTAY,@RatayTT=QT_GIORATAY
		from ST_GIOQUETTHE_ left outer join ST_VAORA_ on
			ST_GIOQUETTHE_.NV_MA=ST_VAORA_.NV_MA 
			and ST_GIOQUETTHE_.QT_Ngay=ST_VAORA_.QT_Ngay
			and ST_GIOQUETTHE_.CA_MA=ST_VAORA_.CA_MA
		Where ST_GIOQUETTHE_.NV_MA=@NV_MA and ST_GIOQUETTHE_.QT_Ngay=@Ngay

	if @VaoTT is null
		select @Giovao=@VaotayTT
	else
		select @Giovao=@VaoTT
	if not @VaotayTT is null 
		select @Giovao=@VaotayTT
	if @RaTT is null
		select @Giora=@RatayTT
	else
		select @Giora=@RaTT
	if not @RatayTT is null 
		select @Giora=@RatayTT

	if exists(select * from ST_GIOQUETTHE_ where NV_MA=@NV_MA and QT_Ngay=@Ngay)
	select @Gioratam=datepart(hh,@Giora) * 60 +datepart(n,@Giora)

	---------------------------------Tính suất ăn dựa trên @Gioratam (giờ ra thực tế)------------------------
	--Nếu có làm việc từ 4 tiếng thì được 1 suất
	if @GioLamThuong >4 
		select @Suatan=1


	--TH Ca HC (7h30-16h30): tăng ca trên 2 tiếng mới có thêm 1 xuất ăn tức giờ tăng ca phải từ 19h00 trở đi (Andrew sửa)
																	--1140 là 19h00 (1140:60 = 19h) 
																	-- tăng ca trên 2 tiếng mới thêm được 1 xuất ăn( lưu ý, tăng ca trên 2 tiếng sẽ bị trừ nữa tiếng đi ăn không tính công)
    if @GioLamThuong >4	AND (@Gioratam-1140)>=0	AND @Ca_ma='Ca HC'
		select @SuatanTCa=1
	--TH Ca01 (6h30:15h30): phải từ 18h trở đi (18h=1080)
	if @GioLamThuong >4	AND (@Gioratam-1080)>=0	AND @Ca_ma='Ca01'
		select @SuatanTCa=1

	--TH Ca02 (6h00:15h00): phải từ 17h:30 trở đi (17h30=1050)
	if @GioLamThuong >4	AND (@Gioratam-1050)>=0	AND @Ca_ma='Ca02'
		select @SuatanTCa=1	

	--TH Ca03 (7h00:16h00): phải từ 18h30 trở đi (18h30=1080)
	if @GioLamThuong >4	AND (@Gioratam-1110)>=0	AND @Ca_ma='Ca03'
		select @SuatanTCa=1

	--TH Ca 6 (5h00:14h00): phải từ 16h30 trở đi (16h30=990)
	if @GioLamThuong >4	AND (@Gioratam-990)>=0	AND @Ca_ma='Ca 6'
		select @SuatanTCa=1

	--TH Ca 7 (12h00:20h00): phải từ 22h30 trở đi (22h30=1350)
	if @GioLamThuong >4	AND (@Gioratam-1350)>=0	AND @Ca_ma='Ca 7'
	--------------------------------------------------------------

	select @SuatanTCa=1
	update ST_GIOQUETTHE_
	set CC_SUATAN=isnull(@SuatanTCa,0)
	where NV_MA=@NV_MA and QT_Ngay=@Ngay

end

