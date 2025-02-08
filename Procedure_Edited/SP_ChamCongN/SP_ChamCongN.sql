USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_CHAMCONGN]    Script Date: 27/10/2023 9:20:50 AM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
--EXEC SP_CHAMCONGN  '2018-07-09','00176',0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1

ALTER PROCEDURE [dbo].[SP_CHAMCONGN]
	@Ngay datetime,@NV_MA nvarchar(50),
	@CHK_TINHDUCONG bit,@CHK_TINHTANGCA bit,@CHK_TINHLAMDEM bit,
	@CHK_DUCONGKHIDU bit,@CHK_GIOIHANTANGCA bit,@CHK_GIAILAOTANGCA bit,
	@DUCONGKHIDU real,@GIOIHANTANGCA real,@GIAILAOTANGCA real,@TINHLAMDEM datetime,
	@HESONGAYCONG int,@CHK_DITRE bit,@CHK_QUEN bit,@CHK_LUONDITRE bit,@CHK_LUONQUENQT bit,@CHK_Som bit 
AS
Begin
	DECLARE 
	@CA_GIOBATDAU datetime,
	@CA_GIOKETTHUC datetime,
	@CA_GIOGIAILAO datetime,
	@CA_SOPHUTGIAILAO real,
	@VaoTT datetime,
	@RaTT datetime,
	@VaotayTT datetime,
	@RatayTT datetime,
	@GiovaoQD real,
	@GioraQD real,
	@GioGLQD real,
	@GiailaoQD real,
	@GioVao real,
	@GioRa real,
	@GioVaoSomQD real,
	@GioRaSomQD real,
	@Giovaotam real,
	@Gioratam real,
	@GioLamThuong real,
	@GioThucTe real,
	@GioTangCa real,
	@GioTangCaSau real,
	@GioAn REAL, --Andrew
	@GioTangCaTruoc real,
	@GiolamDem real,
	@Sogionghi float,
	@CC_GIOTANGCA	FLOAT,
	@NP_MA nvarchar(10),
	@DV_MA nvarchar(50),
	@DV_MATL nvarchar(50),
	---- bien tinh so lan di tre 
	@Vao datetime ,
	@Ra datetime ,
	@Tre int ,
	---- bien tinh quen quet the
	@Quen int,
	@Matu nvarchar(20),	
	@CA_MA nvarchar(20),	
	@GioRaQT real ,
	@GioQDKT real ,
	@Suatan int,
	@SuatanTCa int,
	---- 
	@Lamdem datetime,	
	@Giobatdau real ,
	@GioQuenQT real ,
	@Lamdemtam real	,
	@NV_NGAYVAO BIT,
	@NV_KCB BIT
	--KHAC PHUC SU CO MAT NOI KET
	--SET XACT_ABORT ON
	--BEGIN TRAN
	--BEGIN TRY

--------------------------
---------------------------Chọn ra NT từ mã từ----------------------------------
--------------------------
	SELECT @Matu =NV_Matu,@DV_Ma =DV_Ma_ ,@DV_MaTL =DV_Ma 
	FROM ST_Nhanvien 
	WHERE NV_Ma=@NV_MA  and NV_NGAYVAO<=@Ngay
--------------------------
-----------------THÊM VÔ LOẠI NHÂN VIÊN VÀO SAU NGÀY CHẤM CÔNG
--------------------------
	if exists(select * from ST_NHANVIEN where NV_MA=@NV_MA and NV_NGAYVAO<=@Ngay)
		select @NV_NGAYVAO = 1
	ELSE
		select @NV_NGAYVAO = 0			
	--------------------------	
	if exists(select * from ST_NHANVIENTHOIVIEC where NV_MA=@NV_MA and TV_Ngaythoiviec<@Ngay)
		SELECT @DV_Ma ='NV'
--------------------------
---------------------------Lấy Ca Làm Việc bên ST_GIOQUETTHE Để Chấm Công  "DÒNG" Trong ST_VaoRa của Ngày Đó-------------------
--------------------------
	if  exists(select * from ST_GIOQUETTHE where NV_MA=@NV_MA and QT_Ngay=@Ngay)
		select  @CA_MA =CA_MA  from ST_GIOQUETTHE where NV_MA=@NV_MA and QT_Ngay=@Ngay
	else
		select @CA_MA='Ca HC'
--------------------------
---------------------------Update HeSoNgayCong----------------------------------
--------------------------
	IF @HESONGAYCONG=0
	BEGIN
		select @HESONGAYCONG=1 
		if datepart(dw,@Ngay)=1 
			SELECT @HESONGAYCONG=2								--Ngày CN
		if exists(select * from ST_LE where LE_NGAY=@Ngay  ) 
			SELECT @HESONGAYCONG=3								--Ngày Lễ
		If  @CA_MA='Ca 4'  or @CA_MA='Ca 5'  
			SELECT @HESONGAYCONG=4
	END
    
	----THÊM VÔ LOẠI NHÂN VIÊN VÀO SAU NGÀY CHẤM CÔNG
	IF  (@HESONGAYCONG = 3 AND @NV_NGAYVAO = 0)
		SELECT @HESONGAYCONG = 1

	------------------------------------------------------ 
	if not exists(select * from ST_GIOQUETTHE where NV_MA=@NV_MA and QT_Ngay=@Ngay)
		insert into ST_GIOQUETTHE(NV_MA,QT_Ngay,Ca_MA,CC_HESONGAYCONG)
		values (@NV_MA,@Ngay,@CA_MA,@HESONGAYCONG)
	else
		update ST_GIOQUETTHE
		set CC_HESONGAYCONG=@HESONGAYCONG
		where NV_MA=@NV_MA and QT_Ngay=@Ngay

--------------------------
---------------------------Update NghiPhep----------------------------------
--------------------------
	select @NP_MA=null
	SELECT @NV_KCB = 0
	if exists(select * from IT_KHAMCHUABENH where NV_MA=@NV_MA	and KCB_NGAY=@Ngay   )
			SELECT @NV_KCB = 1
					-- Kiem tra neu ben Phep co nhap thi keo Phep qua					          
	IF @NV_KCB = 1
		BEGIN
			select @NP_MA='OM1' from IT_KHAMCHUABENH 
			where NV_MA=@NV_MA	and KCB_NGAY=@Ngay
		END
	ELSE
		BEGIN
			select @NP_MA=NP_MA from ST_NHANVIENNGHIPHEP 
			where NV_MA=@NV_MA
					AND NP_TUNGAY<=@Ngay and NP_DENNGAY>=@Ngay
		END	
								
	update ST_GIOQUETTHE
	set NP_MA=@NP_MA
	where NV_MA=@NV_MA and QT_Ngay=@Ngay
	----------------------------------------

	-- THEM VAO KHI NGHI THAI SAN , SAY THAI THÌ NGÀY LỄ LÀ HỆ SỐ 1
	if (@NP_MA IN ('TS','ST') and @HESONGAYCONG = 3)
	update ST_GIOQUETTHE
	set CC_HESONGAYCONG = 1
	where NV_MA=@NV_MA and QT_Ngay=@Ngay
		
--------------------------
-------------Lay gio qui dinh		---(@GioVaoQD, @GioGLQD, @GioraQD)----
--------------------------
	select  @CA_GIOBATDAU = CA_GIOBATDAU 
			,@CA_GIOKETTHUC = CA_GIOKETTHUC
			,@CA_GIOGIAILAO=CA_GIOGIAILAO
			,@CA_SOPHUTGIAILAO=CA_SOPHUTGIAILAO
	from ST_CALAMVIEC,ST_GIOQUETTHE
	Where ST_GIOQUETTHE.NV_MA=@NV_MA and ST_GIOQUETTHE.QT_Ngay=@Ngay
			AND ST_CALAMVIEC.CA_MA=ST_GIOQUETTHE.CA_MA
									--Các trường hợp cộng thêm 1 ngày (24h=1440m)
	select @GiovaoQD=datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
	if datepart(hh,@CA_GIOBATDAU)<4 
		select @GiovaoQD=@GiovaoQD+1440			

	select @GioGLQD=datepart(hh,@CA_GIOGIAILAO) * 60 +datepart(n,@CA_GIOGIAILAO)
	if @GiovaoQD>@GioGLQD
		select @GioGLQD=@GioGLQD+1440
						
	select @GioraQD=datepart(hh,@CA_GIOKETTHUC) * 60 +datepart(n,@CA_GIOKETTHUC)
	if @GiovaoQD>@GioraQD
		select @GioraQD=@GioraQD+1440
	--select @CA_GIOBATDAU,@CA_GIOKETTHUC,@CA_GIOGIAILAO,@GiovaoQD, @GioraQD,@GioGLQD 

--------------------------
-------------Lay gio thuc te			---(@VaoTT,@RaTT)---
--------------------------
	select @VaoTT=null,@RaTT=null,@VaotayTT=null,@RatayTT=null
	select @VaoTT=QT_GIOVAO
			,@RaTT=QT_GIORA
			,@VaotayTT=QT_GIOVAOTAY
			,@RatayTT=QT_GIORATAY
	from ST_GIOQUETTHE left outer join ST_VAORA on ST_GIOQUETTHE.NV_MA=ST_VAORA.NV_MA 
												and ST_GIOQUETTHE.QT_Ngay=ST_VAORA.QT_Ngay
												and ST_GIOQUETTHE.CA_MA=ST_VAORA.CA_MA
	Where ST_GIOQUETTHE.NV_MA=@NV_MA and ST_GIOQUETTHE.QT_Ngay=@Ngay

--------------------------
-------------Lay Giovao & GiovaoSomQD			---(@Giovao)---
--------------------------
									-----------------Xet ben ST_VaoRa (Co quet the)------------------
	if @VaoTT is null
		select @Giovao=0
	else
		begin						-----------------Xet ben ST_VaoRa (Lấy quẹt thẻ thực tế)------------------
			if @CHK_Som = 0									--Không tính tăng ca sớm (Giovao Ép về GiovaoSomQD)
				begin
					IF @CA_MA in ('Ca 4', 'Ca 3', 'Ca 2','Ca 6','Ca 7','Ca HC', 'Ca01', 'Ca02', 'Ca03')
						begin
							select @GiovaoSomQD = datepart(hh,@VaoTT) * 60 + datepart(n,@VaoTT)
		    				if datepart(hh,@VaoTT)<4 AND @CA_MA <> 'Ca 2'
								SELECT @GiovaoSomQD=@GiovaoSomQD+1440	
						end
					ELSE
						BEGIN
							IF DATEPART(hh,@VaoTT)< datepart(hh,@CA_GIOBATDAU)					--Ép về qui định
		   						SELECT @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
							IF datepart(hh,@CA_GIOBATDAU)<4 
								SELECT @GiovaoSomQD=@GiovaoSomQD+1440
						end
					SELECT @Giovao = @GiovaoSomQD											    --Ép về Qui định
				end		
			ELSE--@CHK_Som = 1								--Tính tăng ca sớm (GioVao lay theo VaoTT, GiovaoSomQD=Ca_GioBatDau)
				begin
					--select @CA_MA 
					if @CA_MA = 'Ca 2'
						select     @Giovao = datepart(hh,@VaoTT) * 60 + datepart(n,@VaoTT)		--Lấy theo làm sớm
					else
						begin
							select @Giovao = datepart(hh,@VaoTT) * 60 + datepart(n,@VaoTT)		--Lấy theo làm sớm
		    				if datepart(hh,@VaoTT)<4 
								select @Giovao=@Giovao+1440										
						END
                    -----------------
					--IF datepart(hh,@VaoTT)< datepart(hh,@CA_GIOBATDAU)
		   				--select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					IF Convert(time,@VaoTT)< Convert (time,@CA_GIOBATDAU)
		   				select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					if datepart(hh,@CA_GIOBATDAU)<4 
						select @GiovaoSomQD=@GiovaoSomQD+1440	
				END								
		end
	SELECT @Giovao Giovao , @GiovaoSomQD GiovaoSomQD, @VaotayTT VaotayTT
									-----------------Xet ben ST_GioQueThe (Co nhap tay)------------------
	if @VaotayTT is not null
		BEGIN
			--- moi sua
			if @CHK_Som = 0									--Không tính tăng ca sớm (Ép @Giovao về theo QĐ)
				begin
					if @CA_MA in ('Ca 4', 'Ca 3', 'Ca 2','Ca 6','Ca 7', 'Ca HC', 'Ca01', 'Ca02', 'Ca03')
						begin
							select @GiovaoSomQD = datepart(hh,@VaotayTT) * 60 + datepart(n,@VaotayTT)
		    				if datepart(hh,@VaotayTT)<4 AND @CA_MA <> 'Ca 2'
								select @GiovaoSomQD=@GiovaoSomQD+1440	
						end
					else
						begin
							if datepart(hh,@VaotayTT)< datepart(hh,@CA_GIOBATDAU) 
		   						select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
							if datepart(hh,@CA_GIOBATDAU)<4 
									select @GiovaoSomQD=@GiovaoSomQD+1440
						end	
						SELECT @Giovao = @GiovaoSomQD												--Ép về Qui định
				end		
			else          								   --Tính tăng ca sớm (@Giovao lấy theo thực tế @VaotayTT)
				begin
					if @CA_MA = 'Ca 2'
						select     @Giovao = datepart(hh,@VaotayTT) * 60 + datepart(n,@VaotayTT)		 --Lấy theo làm sớm
					ELSE
						BEGIN
							select @Giovao = datepart(hh,@VaotayTT) * 60 + datepart(n,@VaotayTT)		--Lấy theo làm sớm
		    				if datepart(hh,@VaotayTT)<4 
								select @Giovao=@Giovao+1440	
						END
					-----------------
					--IF datepart(hh,@VaotayTT)< datepart(hh,@CA_GIOBATDAU)
		   --				SELECT @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					IF Convert(time,@VaotayTT)< Convert (time,@CA_GIOBATDAU)
		   				select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					if datepart(hh,@CA_GIOBATDAU)<4 
						select @GiovaoSomQD=@GiovaoSomQD+1440	
				end						
		END
--------------------------
-------------Lay Giora			---(@Giora)---
-------------------------- 
									-----------------Xet ben ST_VaoRa (Co quet the)------------------
				
	if @RaTT is null
		select @Giora=0
	else
		begin
			select @Giora=datepart(hh,@RaTT) * 60 + datepart(n,@RaTT)
			if @Giovao>@Giora
				select @Giora=@Giora+1440
		END
        
									-----------------Xet ben ST_GioQueThe (Co nhap tay)------------------
	if @RatayTT is not null
		begin
			--chi hien gio ra tay neu co, lay gio ra tay, dong thoi xoa gio ra ben VaoRa
			update st_vaora set qt_giora=null where nv_ma=@nv_ma and qt_ngay=@ngay and ca_ma=@ca_ma
			select @Giora=datepart(hh,@RatayTT) * 60 + datepart(n,@RatayTT)
			if @Giovao>@Giora
				select @Giora=@Giora+1440
		end
	--select @GiovaoSomQD,@GioVaoQD

--------------------------
-------------Tinh toan GioVaoTam,GioGiaiLaoQd,GioRaTam de tinh duoc GioLamThuong
--------------------------	
									------GioVaoTam	
					/*Biểu thức này CEILING(((X/60))*2)/2*60 làm tròn số phút lên 30 phút
					 Nếu x nằm trong khoảng 1–29 phút, nó sẽ được làm tròn lên 30 phút.
                     Nếu x nằm trong khoảng 31–59 phút, nó sẽ được làm tròn lên 60 phút.
                     Nếu x nằm trong khoảng 61–89 phút, nó sẽ được làm tròn lên 90 phút.*/						 
	if (@GioVao<=@GioVaoQD)							--Vào sớm hoặc đúng giờ thì áp giờ vào tạm @GioVaoTam vào giờ vào qui định @GiovaoQD			
		Select @GioVaoTam=CEILING(((@GioVaoQD/60))*2)/2*60			-- Làm tròn lên (Ceiling) theo Bock 30'
	ELSE										    --Vào trễ thì lấy @GioVaoTam theo đúng lúc quẹt thẻ					
		select @GioVaoTam=CEILING(((@GioVao/60))*2)/2*60            -- Làm tròn lên (Ceiling) theo Bock 30'

									------GiailaoQD
	if @CA_SOPHUTGIAILAO is null--Ca khong co giai lao
		select  @GiailaoQD=0
	else
		select  @GiailaoQD=@CA_SOPHUTGIAILAO
	
									------GioRaTam						
	if (@GioRa<@GioGLQD)						--ra trước giờ giải lao
		begin
			--- QUET SOM 13H50 TINH 8 TIENGE
			--Select @GioRaTam=FLOOR(((@GioRa/60)+0.25)*2)/2*60
			--- QUET SOM 13H50 TINH 7.5 TIENGE
			Select @GioRaTam=FLOOR(((@GioRa/60))*2)/2*60         --Làm tròn xuống (Floor) theo Bock 30'
			select @GiailaoQD=0
		end
	else 
		IF @GioRa<@GioGLQD+@CA_SOPHUTGIAILAO	--ra trong giờ giải lao
			begin
				Select @GioRaTam=FLOOR(((@GioGLQD/60))*2)/2*60   --Làm tròn xuống (Floor) theo Bock 30'
				select @GiailaoQD=0
			end
		else									--ra sau giờ giải lao
			Select @GioRaTam=FLOOR(((@GioRa/60))*2)/2*60

	-- SUA --------
	if (@GioVao>=@GioGLQD+@CA_SOPHUTGIAILAO)	--vào sau giờ giải lao	(vào làm từ nữa ngày sau giờ GL)
		begin
			select @GiailaoQD=0
		end
	else
		if (@GioVao>=@GioGLQD)					--vào trong giờ giải lao
			begin
				Select @GioVaoTam=FLOOR(((@GioGLQD/60))*2)/2*60
				select @GiailaoQD=@CA_SOPHUTGIAILAO
			END

----------------------------------------------------------------------------------------------------------------------------------
------Tinh GioLamThuong--GioTangCaTruoc--GioTangCaSau--GioLamDem--GioThucTe 
----------------------------------------------------------------------------------------------------------------------------------             
	select @GioLamThuong=0,@GioTangCaTruoc=0,@GioTangCaSau=0,@GiolamDem=0,@GioThucTe = 0,@GioAn = 0 --Andrew
						
	if @GioVao=0 or @GioRa=0  
	begin
		Select @GioVaoTam=0
		Select @GioRaTam=0
	end
	select @Giovaotam Giovaotam,@Gioratam Gioratam, @GioraQD GioraQD

	if  @Giovaotam<@Gioratam
		BEGIN
			------------------------------
			IF @Gioratam>=@GioraQD ------------------------------------------------ Ra đúng giờ hoặc tăng ca------------------------------------------------------------------
				BEGIN
					SELECT @GioraQD,@Giovaotam,@GiailaoQD
					select @GioLamThuong=(@GioraQD-@Giovaotam-@GiailaoQD)/60
					select @GioThucTe   =(@GioraQD-@Giovaotam-@GiailaoQD)/60
					---------------------------------Giờ tang ca Truoc---------------------------------		
					SELECT @GioTangCaTruoc = ISNULL(FLOOR((@GiovaoSomQD - @Giovao) / 30) * 0.5,0)
						/*Chú thích
							Biểu thức này tính toán chênh lệch thời gian giữa @GiovaoSomQD và @Giovao 
							/30:
								Chia tổng số phút chênh lệch thành các block 30 phút.						 
							FLOOR(...):
								Lấy phần nguyên của số block (loại bỏ phần lẻ).
							* 0.5:
								Mỗi block 30 phút tương ứng với 0.5 giờ tăng ca, nhân hệ số này để chuyển đổi số block thành giờ.
						*/
					----------------------------------Giờ tang ca Sau-----------------------------------
					select @GioTangCaSau=(@Gioratam-@GioraQD)/60								
				END
			ELSE                   ------------------------------------------------- Ra sớm hơn giờ ra ca QĐ------------------------------------------------------------------
				BEGIN
					--select @Gioratam, @Giovaotam, @GiailaoQD								
					select @GioLamThuong=(@Gioratam-@Giovaotam-@GiailaoQD)/60
					select @GioThucTe   =(@Gioratam-@Giovaotam-@GiailaoQD)/60
					---------------------------------Giờ tang ca Truoc---------------------------------		
					SELECT @GioTangCaTruoc = ISNULL(FLOOR((@GiovaoSomQD - @Giovao) / 30) * 0.5,0)
						/*Chú thích
							Biểu thức này tính toán chênh lệch thời gian giữa @GiovaoSomQD và @Giovao 
							/30:
								Chia tổng số phút chênh lệch thành các block 30 phút.						 
							FLOOR(...):
								Lấy phần nguyên của số block (loại bỏ phần lẻ).
							* 0.5:
								Mỗi block 30 phút tương ứng với 0.5 giờ tăng ca, nhân hệ số này để chuyển đổi số block thành giờ.
						*/					
				END
			------------------------------Giải lao tăng ca			
			if @CHK_GIAILAOTANGCA=1 --Khi tăng ca sẽ bị trừ số giờ chỉ định đã nghỉ giải lao @Giailaotangca (đơn vị phút)
				begin
					select @GioTangCaSau=@GioTangCaSau-@GIAILAOTANGCA/60
					if @GioTangCaSau<0 select @GioTangCaSau=0, @GioTangCaTruoc=0							
				end
			ELSE					--Khi tăng ca sẽ bị trừ đúng 30'
				begin
					select @GioTangCaSau=@GioTangCaSau-30/60 
					if @GioTangCaSau<0 select @GioTangCaSau=0
				end	
			------------------------------Tính đủ công khi về sớm				
			if (@CHK_DUCONGKHIDU=1 and @DUCONGKHIDU<8) or exists(select * 
																 FROM ST_CONDUOI12THANG 
																 WHERE NV_MA=@NV_MA and D12_NGHITUNGAY<=@NGAY and D12_NGHIDENNGAY>=@NGAY)
				if @Giolamthuong<@DUCONGKHIDU --làm chưa đủ công được về sớm
					select @Giolamthuong=@Giolamthuong+8-@DUCONGKHIDU
				ELSE						  --làm đủ công được về sớm hoặc hơn
					begin
						select @GioTangCaSau=@GioTangCaSau+@Giolamthuong-@DUCONGKHIDU
						select @Giolamthuong=8
					end	
			------------------------------nếu tăng ca vượt giới hạn thì ép về giới hạn
			if @CHK_GIOIHANTANGCA=1 and @Giotangca>@GIOIHANTANGCA
				begin
					select @Giotangca=@GIOIHANTANGCA
				end		
			----------------------------------Trừ 30' giờ ăn----------------------------------
			----------------------------Nếu tăng ca từ 2 tiếng trở lên thì sẽ bị trừ 30'------
			-----------------------trên tổng giờ tăng ca do tính vào giờ ăn-------------------
			IF  @GioTangCaTruoc + @GioTangCaSau > 2
				BEGIN
					SELECT @GioTangCa = @GioTangCaTruoc + @GioTangCaSau - 0.5
					SELECT @GioAn = 0.5
				END
			ELSE
				BEGIN
					SELECT @GioTangCa = @GioTangCaTruoc + @GioTangCaSau
				END	
		END -- End của (if  @Giovaotam<@Gioratam)
    
-------------------------------------- TINH CHO NHUNG TRUONG HOP DAC BIET-------------------------------------------
										-------- Tinh Du Cong------------------				
	if @CHK_TINHDUCONG=1 
		begin
			select @Giolamthuong=8, @GioThucTe = 8
		end
										-------- Tinh Lam Dem------------------
	if @CHK_TINHLAMDEM=1 
		begin
			select @Giolamdem=(@Gioratam-datepart(hh,@Tinhlamdem)*60+datepart(n,@Tinhlamdem))/60
			if @Giolamdem>8 select @Giolamdem=8
			if @Giolamdem<0 select @Giolamdem=0
		end			
										-------- Không Cho Tăng Ca Sau------------------							
	if @CHK_TINHTANGCA=0 
		BEGIN
			select @GioTangCaSau=0
			IF  @GioTangCaTruoc  > 2
				BEGIN
					SELECT @GioTangCa = @GioTangCaTruoc - 0.5
					SELECT @GioAn = 0.5
				END
			ELSE
				BEGIN
					SELECT @GioTangCa = @GioTangCaTruoc 
				END	
		END	
									    -------- Không Cho Tăng Ca Sớm------------------	
	if (isnull(@CHK_Som,0) = 0)
		BEGIN
			SELECT @GioTangCaTruoc =0
			IF @GioTangCaSau > 2
				BEGIN
					SELECT @GioTangCa = @GioTangCaSau - 0.5
					SELECT @GioAn = 0.5
				END
			ELSE
				BEGIN
					SELECT @GioTangCa = @GioTangCaSau 
				END	
		END
--------------------------
-- Chon gio vao ra 
--------------------------
									--Vao 
	select @Vao =null
	if  @VaotayTT = null 
		select @Vao=@VaoTT
	else
		select @Vao=@VaotayTT
									--Ra
	select @Ra =null
	if  @RatayTT =null 
		select @Ra=@RaTT
	else
		select @Ra=@RatayTT
									--***--
	select @Giobatdau=datepart(hh,@CA_GIOBATDAU)*60+datepart(n,@CA_GIOBATDAU)
	select @GioQuenQT=datepart(hh,@Vao)*60+datepart(n,@Vao)

	IF (@CA_MA = 'Ca 4')
		begin
			select @GioQDKT=datepart(hh,@CA_GIOKETTHUC)*60+datepart(n,@CA_GIOKETTHUC) + 1440
		end
	else
		begin
			select @GioQDKT=datepart(hh,@CA_GIOKETTHUC)*60+datepart(n,@CA_GIOKETTHUC)
		end
	select @GioRaQT=datepart(hh,@Ra)*60+datepart(n,@Ra)

	--SELECT @CA_MA , @Vao, @Ra, @NP_Ma, @HESONGAYCONG 

										-------- Tinh Quen&Tre------------------
	if @Matu is null or @Matu ='' 
		begin
			select @Quen=0
			select @Tre =0
		end			
	else
		begin
			if @Vao = null
				if @Ra = null
					begin
						if @NP_Ma = null  
						if exists(select * from ST_Nhanvien where NV_MA=@NV_MA and  NV_Ngayvao<@Ngay)							
							update ST_GIOQUETTHE
							set NP_MA ='O'
							where NV_MA=@NV_MA and QT_Ngay=@Ngay	
									AND (CC_Hesongaycong=1 or CC_Hesongaycong=4)											
					end
				else
					select @Quen =1
			else
				if @Ra = null
					begin
						select @Quen =1							
						if @GioQuenQT > @Giobatdau
							select @Tre =1					
						else
							select @Tre =0
					end
				else
					begin
						if @NP_Ma = null
							begin
								if @GioQuenQT > @Giobatdau+30 or @GioRaQT<=@GioQDKT- 30	
									IF @CA_MA = 'Ca 4'
										begin
											update ST_GIOQUETTHE
											set NP_MA='O'
											where NV_MA=@NV_MA and QT_Ngay=@Ngay	
											and ( CC_Hesongaycong=4)
											AND (CC_GIOBINHTHUONG = 0 or CC_GIOBINHTHUONG < 8)												
										END
									else
										begin
											update ST_GIOQUETTHE
											set NP_MA='O'
											where NV_MA=@NV_MA and QT_Ngay=@Ngay
											and CC_Hesongaycong=1	
											--and (CC_Hesongaycong=1 or CC_Hesongaycong=4)
										end
								else
									if @GioQuenQT > @Giobatdau
										select @Tre =1
									else
										select @Tre =0									
							end
						else
							if @GioVao>@GioGLQD+15
								select @Tre =1			
							else
								select @Tre =0			
					end
		end			
	if  (@VaoTT =null or  @RaTT =null) and not exists(select * from ST_Nhanvien where NV_MA=@NV_MA and  NV_Ngayvao>@Ngay)
		select @Quen=1
---- Luon tinh di tre va quet the  (Do NS check tay ben bang cham cong chu ko phai he thong tu tinh------------------ 
	if @CHK_LUONDITRE=1
		begin
			select @Tre=1
		end	

	if @CHK_LUONQUENQT=1
		begin
			select @Quen=1
		end	
							
	if @CHK_DITRE=1
		begin
			select @Tre=0
		end	

	if @CHK_QUEN=1
	begin
		select @Quen=0
	end	
						
	if @CHK_TINHDUCONG=1 
		begin
			select @Quen=0
			select @Tre =0
			update ST_GIOQUETTHE
			set NP_MA=null
			where NV_MA=@NV_MA and QT_Ngay=@Ngay	
			and (CC_Hesongaycong=1 or CC_Hesongaycong=4)
		end
							

------------------------------------------------ end---------------------------------------------------------------
									--GioTangCaTruoc											
	--IF (@CA_MA IN ('CA HC') AND @GioTangCaTruoc > 1 AND @GioTangCaTruoc <= 1.5)
	--	SELECT @GioTangCaTruoc = 1.5	
	--IF (@CA_MA = 'CA HC' AND @GioTangCaTruoc = 1 )
	--	SELECT @GioTangCaTruoc = 1	  
	--IF (@CA_MA = 'CA HC' AND @GioTangCaTruoc < 1 )
	--	SELECT @GioTangCaTruoc = 0 
	IF (@CA_MA = 'Ca 2' AND @GioTangCaTruoc > 2)
		SELECT @GioTangCaTruoc = 2
	IF (@CA_MA = 'Ca 3' AND @GioTangCaTruoc > 4)
		SELECT @GioTangCaTruoc = 4
	/*--Adr: Cho Ca 4 Tăng ca trước nên bỏ điều kiện dưới
	IF (@CA_MA = 'Ca 4' AND @GioTangCaTruoc > 0)
		SELECT @GioTangCaTruoc = 0
	*/
	IF (@CA_MA = 'Ca 6' AND @GioTangCaTruoc > 0)
		SELECT @GioTangCaTruoc = 0							   
	IF (@CA_MA = 'Ca 7' AND @GioTangCaTruoc < 1)
		SELECT @GioTangCaTruoc = 0
	IF (@CA_MA = 'Ca 7' AND @GioTangCaTruoc = 1)
		SELECT @GioTangCaTruoc = 1	
	IF (@CA_MA = 'Ca 7' AND @GioTangCaTruoc > 1 AND @GioTangCaTruoc <= 1.5)
		SELECT @GioTangCaTruoc = 1.5  
	if (@CA_MA = 'Ca 7' AND (@GioTangCaTruoc >= 2 and @GioTangCaTruoc <= 4 ))
		SELECT @GioTangCaTruoc = @GioTangCaTruoc
	IF (@CA_MA = 'Ca01' AND @GioTangCaTruoc > 0)
		begin
			SELECT @GioTangCaTruoc = 0
		end
	IF (@CA_MA = 'Ca02' AND @GioTangCaTruoc > 0)
		begin
			SELECT @GioTangCaTruoc = 0
		end
	IF (@CA_MA = 'Ca03' AND @GioTangCaTruoc > 0)
		begin
			SELECT @GioTangCaTruoc = 0
		end
	--select	 @GioTangCaTruoc

------------------------------------------------ Update ST_GioQuetThe--------------------------------------------------------------
	update ST_GIOQUETTHE
	set CC_GIOBINHTHUONG=@GioLamThuong,
		CC_GIOTHUCTE =@GioThucTe,
		DV_Ma=@DV_Ma,
		DV_MaTL=@DV_MaTL,
		CC_GIOTANGCA=@GioTangCa,
		CC_GIOTANGCAT = @GioTangCaTruoc,
		CC_GIOTANGCAS = @GioTangCaSau,
		CC_GIOAN = @GioAn, --Andrew
		CC_SOGIONGHI=8-@GioLamThuong,
		CC_GIOLAMDEM=@GioLamdem,
		CC_DITRE=@Tre,
		CC_QUENQUETTHE=@Quen
	where NV_MA=@NV_MA and QT_Ngay=@Ngay
	EXEC SP_CAPNHATSUATAN @Ngay, @NV_MA
	if exists(SELECT *  FROM ST_GIOQUETTHE  Where NV_MA=@NV_MA and QT_Ngay=@Ngay ANd CC_Hesongaycong=4 AND CC_GIOBINHTHUONG =8  AND NP_MA = 'O')  
		begin
			update ST_GIOQUETTHE
			set NP_MA=null
			where NV_MA=@NV_MA and QT_Ngay=@Ngay	
			and CC_Hesongaycong=4 
			AND CC_GIOBINHTHUONG = 8 AND NP_MA = 'O'
		end
						
	EXEC SP_VAORA_MACHINE_NGAY @NV_MA,@Ngay -- Nếu chay thu ben ngoai nen ko cap nhat qua machine, neu chay that thi phai co
				
END

