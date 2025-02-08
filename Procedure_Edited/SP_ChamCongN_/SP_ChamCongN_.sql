USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_CHAMCONGN_]    Script Date: 02/01/2025 5:38:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec SP_CHAMCONGN_  '2014-02-10','00283',0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1
ALTER PROCEDURE [dbo].[SP_CHAMCONGN_]
@Ngay datetime,@NV_MA nvarchar(50),
@CHK_TINHDUCONG bit,@CHK_TINHTANGCA bit,@CHK_TINHLAMDEM bit,
@CHK_DUCONGKHIDU bit,@CHK_GIOIHANTANGCA bit,@CHK_GIAILAOTANGCA bit,
@DUCONGKHIDU real,@GIOIHANTANGCA real,@GIAILAOTANGCA real,@TINHLAMDEM datetime,
@HESONGAYCONG int,@CHK_DITRE bit,@CHK_QUEN bit,@CHK_LUONDITRE bit,@CHK_LUONQUENQT bit,@CHK_Som bit 
AS
Begin
Declare 
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
	@GioTangCa real,
	@GioTangCaSau real,
	@GioAn REAL, --Andrew
	@GioTangCaTruoc real,
	@GiolamDem real,
	@Sogionghi float,	
	@NP_MA nvarchar(10),
	@DV_MA nvarchar(20),
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
	@Lamdemtam real	

--------------------------
---------------------------Chọn ra NT từ mã từ----------------------------------
--------------------------
	select @Matu =NV_Matu,@DV_Ma =DV_Ma from ST_Nhanvien where NV_Ma=@NV_MA

	if exists(select * from ST_NHANVIENTHOIVIEC where NV_MA=@NV_MA and TV_Ngaythoiviec<@Ngay)
		select @DV_Ma ='NV'

--------------------------
---------------------------Lấy Ca Làm Việc bên ST_GIOQUETTHE_ Để Chấm Công  "DÒNG" Trong ST_VaoRa của Ngày Đó-------------------
--------------------------
 	if  exists(select * from ST_GIOQUETTHE_ where NV_MA=@NV_MA and QT_Ngay=@Ngay)
		select  @CA_MA =CA_MA  from ST_GIOQUETTHE_ where NV_MA=@NV_MA and QT_Ngay=@Ngay
	else
		select @CA_MA='Ca HC'

--------------------------
---------------------------Update HeSoNgayCong----------------------------------
--------------------------
	if @HESONGAYCONG=0
		begin
			select @HESONGAYCONG=1 
			if datepart(dw,@Ngay)=1 select @HESONGAYCONG=2								--Ngày CN
			if exists(select * from ST_LE where LE_NGAY=@Ngay) select @HESONGAYCONG=3   --Ngày Lễ
			if  @CA_MA='Ca 4'  or @CA_MA='Ca 5'  select @HESONGAYCONG=4
		END  
	------------------------------------------------------ 

	if not exists(select * from ST_GIOQUETTHE_ where NV_MA=@NV_MA and QT_Ngay=@Ngay)
		insert into ST_GIOQUETTHE_(NV_MA,QT_Ngay,Ca_MA, CC_HESONGAYCONG)
		values (@NV_MA,@Ngay,@CA_MA, @HESONGAYCONG)
	else
		update ST_GIOQUETTHE_
		set CC_HESONGAYCONG=@HESONGAYCONG
		where NV_MA=@NV_MA and QT_Ngay=@Ngay

--------------------------
---------------------------Update NghiPhep----------------------------------
--------------------------
	select @NP_MA=null
	
	select @NP_MA=NP_MA from ST_NHANVIENNGHIPHEP 
	where NV_MA=@NV_MA and NP_TUNGAY<=@Ngay and NP_DENNGAY>=@Ngay

	update ST_GIOQUETTHE_
	set NP_MA=@NP_MA
	where NV_MA=@NV_MA and QT_Ngay=@Ngay		

--------------------------
-------------Lay gio qui dinh		
--------------------------
	select @CA_GIOBATDAU=CA_GIOBATDAU,
		    @CA_GIOKETTHUC=CA_GIOKETTHUC,
		    @CA_GIOGIAILAO=CA_GIOGIAILAO,
		    @CA_SOPHUTGIAILAO=CA_SOPHUTGIAILAO
	from ST_CALAMVIEC,ST_GIOQUETTHE_
	Where ST_GIOQUETTHE_.NV_MA=@NV_MA and ST_GIOQUETTHE_.QT_Ngay=@Ngay
		and ST_CALAMVIEC.CA_MA=ST_GIOQUETTHE_.CA_MA

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

--------------------------
-------------Lay gio thuc te			---(@VaoTT,@RaTT)---
--------------------------
	select @VaoTT=null,@RaTT=null,@VaotayTT=null,@RatayTT=null
	select @VaoTT=QT_GIOVAO
			,@RaTT=QT_GIORA
			,@VaotayTT=QT_GIOVAOTAY
			,@RatayTT=QT_GIORATAY
	from ST_GIOQUETTHE_ left outer join ST_VAORA_ on
		ST_GIOQUETTHE_.NV_MA=ST_VAORA_.NV_MA 
		and ST_GIOQUETTHE_.QT_Ngay=ST_VAORA_.QT_Ngay
		and ST_GIOQUETTHE_.CA_MA=ST_VAORA_.CA_MA
	Where ST_GIOQUETTHE_.NV_MA=@NV_MA and ST_GIOQUETTHE_.QT_Ngay=@Ngay

--------------------------
-------------Lay Giovao & GiovaoSomQD			---(@Giovao)---
--------------------------
									-----------------Xet ben ST_VaoRa (Co quet the)------------------
	IF @VaoTT is null
		select @Giovao=0
	else
		begin						-----------------Xet ben ST_VaoRa (Lấy quẹt thẻ thực tế)------------------
			IF @CHK_Som = 0									--Không tính tăng ca sớm (@Giovao Ép về theo QĐ) 
				BEGIN
					IF @CA_MA in ('Ca 4', 'Ca 3', 'Ca 2', 'Ca HC', 'Ca01', 'Ca02')
						BEGIN
							SELECT @GiovaoSomQD = datepart(hh,@VaoTT) * 60 + datepart(n,@VaoTT)
		    				if datepart(hh,@VaoTT)<4 AND @CA_MA <> 'Ca 2'
								SELECT @GiovaoSomQD=@GiovaoSomQD+1440	
						END
					ELSE
						BEGIN
							--Trường hợp quẹt sớm hơn qui định thì ép về vào theo QĐ
							if datepart(hh,@VaoTT)< datepart(hh,@CA_GIOBATDAU)
		   					  select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
							if datepart(hh,@CA_GIOBATDAU)<4 
								select @GiovaoSomQD=@GiovaoSomQD+1440
						end
					SELECT @Giovao = @GiovaoSomQD												--Ép về Qui định
				end		
			else											--Tính tăng ca sớm 
				BEGIN
					SELECT @CA_MA 
					if @CA_MA = 'Ca 2'
						select @Giovao = datepart(hh,@VaoTT) * 60 + datepart(n,@VaoTT)			--Lấy theo làm sớm
					else
						begin
							select @Giovao = datepart(hh,@VaoTT) * 60 + datepart(n,@VaoTT)		--Lấy theo làm sớm
		    				if datepart(hh,@VaoTT)<4 
								select @Giovao=@Giovao+1440	
						END
                    -----------------
					if datepart(hh,@VaoTT)< datepart(hh,@CA_GIOBATDAU)
		   				select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					if datepart(hh,@CA_GIOBATDAU)<4 
						select @GiovaoSomQD=@GiovaoSomQD+1440	
				end				
		end
	SELECT @Giovao, @GiovaoSomQD, @VaotayTT
									-----------------Xet ben ST_GioQueThe (Co nhap tay)------------------
	if @VaotayTT is not null
		begin
			--- moi sua
			if @CHK_Som = 0									--Không tính tăng ca sớm (Ép @Giovao về theo QĐ)
				BEGIN
					if @CA_MA in ('Ca 4', 'Ca 3', 'Ca 2', 'Ca HC', 'Ca01', 'Ca02')
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
						select @Giovao =     DATEPART(hh,@VaotayTT) * 60 + datepart(n,@VaotayTT)		 --Lấy theo làm sớm
					ELSE
						BEGIN
							select @Giovao = datepart(hh,@VaotayTT) * 60 + datepart(n,@VaotayTT)		 --Lấy theo làm sớm
		    				if datepart(hh,@VaotayTT)<4 
								select @Giovao=@Giovao+1440	
						END
					-----------------
					--if datepart(hh,@VaotayTT)< datepart(hh,@CA_GIOBATDAU)
		   --				select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					IF Convert(time,@VaotayTT)< Convert (time,@CA_GIOBATDAU)
		   				select @GiovaoSomQD = datepart(hh,@CA_GIOBATDAU) * 60 + datepart(n,@CA_GIOBATDAU)
					if datepart(hh,@CA_GIOBATDAU)<4 
						select @GiovaoSomQD=@GiovaoSomQD+1440	
				end						
		end
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
		end
									-----------------Xet ben ST_GioQueThe (Co nhap tay)------------------	
	if @RatayTT is not null
		begin
			--chi hien gio ra tay neu co
			update st_vaora_ set qt_giora=null where nv_ma=@nv_ma and qt_ngay=@ngay and ca_ma=@ca_ma
			select @Giora=datepart(hh,@RatayTT) * 60 + datepart(n,@RatayTT)
			if @Giovao>@Giora
				select @Giora=@Giora+1440
		end

--------------------------
-------------Tinh toan GioVaoTam,GioGiaiLaoQd,GioRaTam de tinh duoc GioLamThuong
--------------------------	
									------GioVaoTam					 -- Vd: Đổi ra phut cua GioVaoQD(5h)  :5*60=300    =>@GioVaoTam=300 Giovaotam 5h	
	if (@GioVao<@GioVaoQD)--Vào sớm hoặc đúng giờ											GioVaoQD(6h30):6*60+30=390 =>@GioVaoTam=360 Giovaotam 6h
		Select @GioVaoTam=CEILING(((@GioVaoQD/60)-0.1)*2)/2*60		--					    GioVaoQD(7h30):7*60+30=450 =>@GioVaoTam=420 Giovaotam 7h
	else																			   --=>Nếu vào sớm thì lấy chỉ phần giờ vào qui định ca đó
		select @GioVaoTam=CEILING(((@GioVao/60)-0.1)*2)/2*60								--và nếu Vào trễ thì GioVaoTam= số giờ thực thế chia 	
																						--  GioVaoQD(7h59):7*60+30=479 =>@GioVaoTam=420 Giovaotam 7h
																	--Vậy công thức trên sẽ tính GioVaoTam luôn là phần giờ nguyên không tính phút của khung giờ quẹt thẻ
									------GiailaoQD
	if @CA_SOPHUTGIAILAO is null
		select  @GiailaoQD=0
	else
		select  @GiailaoQD=@CA_SOPHUTGIAILAO

									------GioRaTam		
	if (@GioRa<@GioGLQD)						--ra trước giờ giải lao
		begin
			Select @GioRaTam=FLOOR(((@GioRa/60)+0.25)*2)/2*60
			select @GiailaoQD=0
		end
	else 
		IF @GioRa<@GioGLQD+@CA_SOPHUTGIAILAO	--ra trong giờ giải lao
			begin
				Select @GioRaTam=FLOOR(((@GioGLQD/60)+0.1)*2)/2*60
				select @GiailaoQD=0
			end
		ELSE 									--ra sau giờ giải lao
			SELECT @GioRaTam=FLOOR(((@GioRa/60)+0.1)*2)/2*60

	-- SUA --------
	if (@GioVao>=@GioGLQD+@CA_SOPHUTGIAILAO)	--vào sau giờ giải lao	(vào làm từ nữa ngày sau giờ GL)	
		begin
			select @GiailaoQD=0
		end
	else
		if (@GioVao>=@GioGLQD)					--vào trong giờ giải lao
		begin
			Select @GioVaoTam=FLOOR(((@GioGLQD/60)+0.1)*2)/2*60
			select @GiailaoQD=@CA_SOPHUTGIAILAO
		END
        
--------------------------
------Tinh GioLamThuong--GioTangCaTruoc--GioTangCaSau--GioLamDem--GioThucTe 
--------------------------  
	select @GioLamThuong=0,@GioTangCaTruoc=0,@GioTangCaSau=0,@GiolamDem=0,@GioAn = 0 --Andrew
	if @GioVao=0 or @GioRa=0  
		begin
			Select @GioVaoTam=0
			Select @GioRaTam=0
		end
	
	select @Giovaotam Giovaotam,@Gioratam Gioratam, @GioraQD GioraQD

	if  @Giovaotam<@Gioratam
		BEGIN
			------------------------------
			IF @Gioratam>=@GioraQD  ------------------------------------------------ Ra đúng giờ hoặc tăng ca------------------------------------------------------------------
				begin
					select @Giolamthuong=(@GioraQD-@Giovaotam-@GiailaoQD)/60
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
				end
			else                    ------------------------------------------------- Ra sớm hơn giờ ra ca QĐ------------------------------------------------------------------
				begin
					select @Giolamthuong=(@Gioratam-@Giovaotam-@GiailaoQD)/60
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
			if (@CHK_DUCONGKHIDU=1 and @DUCONGKHIDU<8) or exists(select * from ST_CONDUOI12THANG where NV_MA=@NV_MA and D12_NGHITUNGAY<=@NGAY and D12_NGHIDENNGAY>=@NGAY)
				if @Giolamthuong<@DUCONGKHIDU  --làm chưa đủ công được về sớm
					select @Giolamthuong=@Giolamthuong+8-@DUCONGKHIDU
				else						   --làm đủ công được về sớm hoặc hơn
					begin
						--select @Giotangca=@Giotangca+@Giolamthuong-@DUCONGKHIDU
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
		END
        
-------------------------------------- TINH CHO NHUNG TRUONG HOP DAC BIET-------------------------------------------
										-------- Tinh Du Cong------------------	
	if @CHK_TINHDUCONG=1 
	begin
		select @Giolamthuong=8
	end
										-------- Tinh Lam Dem------------------
	if @CHK_TINHLAMDEM=1 
	begin
		select @Giolamdem=(@Gioratam-datepart(hh,@Tinhlamdem)*60+datepart(n,@Tinhlamdem))/60
		if @Giolamdem>8 select @Giolamdem=8
		if @Giolamdem<0 select @Giolamdem=0
	end			
										-------- Không Cho Tăng Ca Sau----------			
	if @CHK_TINHTANGCA=0 
	begin
		select @Giotangca=0
	end
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

	select @GioQDKT=datepart(hh,@CA_GIOKETTHUC)*60+datepart(n,@CA_GIOKETTHUC)
	select @GioRaQT=datepart(hh,@Ra)*60+datepart(n,@Ra)

									--Tinh Quen&Tre--
	if @Matu is null or @Matu ='' 
		begin
			select @Quen=0
			select @Tre =0
		end			
	else
		begin
			if  @Vao = null
				if @Ra = null
					begin
						if @NP_Ma = null  
						if exists(select * from ST_Nhanvien where NV_MA=@NV_MA and  NV_Ngayvao<@Ngay)
							update ST_GIOQUETTHE_
							set NP_MA='O'
							where NV_MA=@NV_MA and QT_Ngay=@Ngay	
							and (CC_Hesongaycong=1 or CC_Hesongaycong=4)	
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
									update ST_GIOQUETTHE_
									set NP_MA='O'
									where NV_MA=@NV_MA and QT_Ngay=@Ngay	
									and (CC_Hesongaycong=1 or CC_Hesongaycong=4)	
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

----- Luon tinh di tre va quet the  (Do NS check tay ben bang cham cong chu ko phai he thong tu tinh------------------  
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

			update ST_GIOQUETTHE_
			set NP_MA=null
			where NV_MA=@NV_MA and QT_Ngay=@Ngay	
			and (CC_Hesongaycong=1 or CC_Hesongaycong=4)
		end
	
	--- end--------
	if (isnull(@CHK_Som,0) = 0)
		select @GioTangCaTruoc =0
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
	IF (@CA_MA = 'Ca 4' AND @GioTangCaTruoc > 0)
		begin
			SELECT @GioTangCaTruoc = 0
		end
	IF (@CA_MA = 'Ca01' AND @GioTangCaTruoc > 0)
		begin
			SELECT @GioTangCaTruoc = 0
		end
	IF (@CA_MA = 'Ca02' AND @GioTangCaTruoc > 0)
		begin
			SELECT @GioTangCaTruoc = 0
		end
		
------------------------------------------------ Update ST_GioQuetThe--------------------------------------------------------------		
	update ST_GIOQUETTHE_
	set CC_GIOBINHTHUONG=@GioLamThuong,
	DV_Ma=@DV_Ma,
	CC_GIOTANGCA= @GioTangCa ,
	CC_GIOTANGCAT = @GioTangCaTruoc,
	CC_GIOTANGCAS = @GioTangCaSau,
	CC_GIOAN = @GioAn, --Andrew
	CC_SOGIONGHI=8-@GioLamThuong,
	CC_GIOLAMDEM=@GioLamdem,
	CC_DITRE=@Tre,
	CC_QUENQUETTHE=@Quen
	where NV_MA=@NV_MA and QT_Ngay=@Ngay
	--Update Vao Ra Machine
	EXEC SP_VAORA_MACHINE_NGAY @NV_MA,@Ngay
end

