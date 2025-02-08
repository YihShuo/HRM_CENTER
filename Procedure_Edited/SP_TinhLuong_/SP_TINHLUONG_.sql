USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_TINHLUONG_]    Script Date: 05/09/2024 9:22:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_TINHLUONG_] @NV_MA nvarchar(50), @T_MA nvarchar(50), @Loailuong int  AS
	declare
		@DV_MA nvarchar(50),
		@L_LUONGTRUOC float,
		@L_LUONGSAU float,
		@L_PHUCAPTRUOC float,
		@L_PHUCAPSAU float,
		@L_PHUCAPKHAC float,
		@L_PHUCAPDH float,
		@L_CONGKHAC float,
		@L_TRUKHAC float,
-- phu cap
		@L_PCTRNTRUOC float,
		@L_PCTRNSAU float,
		@L_PCCCAN float,
		@Chuyencan float,
		@L_PCMTruong float,
		@SONGAYBT INT,
		@NGAYDAU DATETIME,
		@NGAYCUOI DATETIME,
		@NGAYGIUA DATETIME,
		@NgayLe DATETIME,
		@NgayLeTam float,

		@GIOTAY FLOAT,
		@GIOMAY FLOAT,
		@GIOLE FLOAT,
		@L_CONGHS1 FLOAT,
		@L_CONGHS4 FLOAT,
		@L_CONGHS21 FLOAT,--Andrew
		@L_CONGHS27 FLOAT,--Andrew
		@L_CONGTCAHS4 FLOAT,
		@L_CONGTCAHS4A FLOAT,
		@L_CONGTCAHS4B FLOAT,
		@L_CONGHS2 FLOAT,
		@L_CONGHS2A FLOAT,
		@L_CONGHS2B FLOAT,
		@L_CONGHS2C FLOAT,
		@L_TCAHS2 FLOAT,
		@L_CONGHS3 FLOAT,
		@L_CONGHS3A FLOAT,
		@L_CONGHS3B FLOAT,
		@L_CONGHS15 FLOAT,
		@L_CONGHS15A FLOAT,
		@L_CONGHS15B FLOAT,
		@L_LAMDEM FLOAT,
		@L_NGUNGVIEC float,
        @L_NGHIDQ float,
		@L_NGHILE float,
		@L_NGHIP float,
		@L_NGHIR float,
		@L_NGHIRO float,
		@L_NGHIOM float,
        @L_NGHIST float,
		@L_NGHITS float,
		@L_NGHIHS float,
		@L_NGHIO float,
		@L_NGHINO float,
		@L_NGHITNLD float,
		@L_NGHIKHAMTHAI float,
		@L_NGHIDS float,
		@L_TAMUNG float,
		@L_BHXH bit,
		@L_BHYT bit,
		@L_SOPHANCOM float,
		@SOLANDITRE int,
		@SOLANQUENQUETTHE int,
		@HD_Ngayky datetime,
		@L_TraBH_P float,
		@L_LuongTraBH float,
        @L_TIENNUOICON6T FLOAT,
		--khai bao cac tham so trong cong thuc luong (rp_bangluong.rpt ,rp_phieuluongcanhan.rpt)
	
	@SODBL INT,
	@NGHI_TS_TUNGAY datetime,
	@NGHI_TS_DENNGAY datetime,
	@NV_TS nvarchar(50),	
	@LUONG_TU_ST_LUONG FLOAT,
	@CONGTT FLOAT,
	@SONGAYCONG FLOAT,
	@CONGCADEM FLOAT, 
	@GIOP FLOAT,
	@HS1 FLOAT,
	@HS2A FLOAT,
	@GIOR FLOAT,
	@GIOPR FLOAT,
	@GIONV FLOAT,
	@GIONO FLOAT,
	@TIENPHUCAPKHAC FLOAT,
	@NV_NGAYVAO datetime,
	@T_TUNGAY datetime,
	@GIOO_TH FLOAT,
	@GIORO_TH FLOAT,
	@GIOOM_TH FLOAT,
	@GIOST_TH FLOAT,
	@CONGTT_TH FLOAT,
	@SONGAYCONG_TH FLOAT,
	@CONGCADEM_TH FLOAT,
	@GIODS_TH FLOAT,
	@DITRE_TH FLOAT,
	@QUENQT_TH FLOAT,
	@GIOTS_TH FLOAT,
	@GIOKTHAI_TH FLOAT,
	@GIOTSKT_TH FLOAT,
	@SONGAY_TH FLOAT,
	@CHUYENCANDUOCHUONG_TH FLOAT,
	@GIOP_TH FLOAT,
	@GIOR_TH FLOAT,
	@GIOLE_TH FLOAT,
	@GIONO_TH FLOAT,
	@GIOTNLD_TH FLOAT,
	@GIODQ_TH FLOAT,
	@GIOKHHGD FLOAT,
	@GIOKHHGD_TH FLOAT,
	@PHUCAP FLOAT,
	@TIENPCDH FLOAT,
	@TCAHS4 FLOAT,
	@LUONG_PHUCAP FLOAT,
	@TIENHS1 FLOAT,
	@TIENHS15 FLOAT,
	@TIENHS2 FLOAT,
	@TIENHS3 FLOAT,
	@TIENTCHS4 FLOAT,
	@LUONGTHANG FLOAT,
	@TRABH_P_TH FLOAT,
	@PCKHAC_LONHON100 FLOAT,
	@TIENHS15TINHTHUE FLOAT,
	@TIENHS2TINHTHUE FLOAT,
	@TIENHS3TINHTHUE FLOAT,
	@TIENLAMDEMTINHTHUE FLOAT,
	@TIENLAMTHEMTINHTHUE FLOAT ,
	@CONGLUONGTINHTHUE FLOAT,
	@TAMUNG FLOAT,
	@THUETN FLOAT,
	@TIENBHXH FLOAT,
	@TIENBHYT FLOAT,
	@TIENBHTN FLOAT,
	@BHXH BIT,
	@BHYT BIT,
	@TIENBH FLOAT,
	@THUKHAC FLOAT,
	@TIENCD FLOAT,
	@LANHCUOIKY FLOAT,
	@LAMTRONPHANTRAM FLOAT,
	@SODUHANGTRAM FLOAT,
	@LAMTRONSOLE FLOAT,
	@THUCLANH FLOAT,
	@LUONGCHINH FLOAT,
	@PCTRACHNHIEM FLOAT,
	@PCCHUYENCAN FLOAT,
	@PCMOITRUONG FLOAT,
	@HS15 FLOAT,
	@HS195 FLOAT,
	@HS2 FLOAT,
	@HS3 FLOAT,
	@TIENLAMTHEM FLOAT,
	@GIOLAMDEM FLOAT,
	@TIENLAMDEM FLOAT,
	@GIOKHAC FLOAT,
	@TIENKHAC FLOAT,
	@GIORLE FLOAT,
	@TIENPR FLOAT,
	@TIENPN FLOAT,
	@CONGKHAC FLOAT,
	@CONGLUONG FLOAT,
	@SOPHANCOM FLOAT,
	@TIENCOM FLOAT,
	@TIENNV FLOAT,
	@TIENBB FLOAT,
	@TONTAI INT,
	@TIENNUOICON6T FLOAT,
	@LUONG_TU_IT_BANGLUONGMOI FLOAT,
	@THANG_SAU nvarchar(50),
	@THANG_S nvarchar(50),
	@TUNGAY_TSAU datetime,
	@DENNGAY_TSAU datetime,
	@GIOMAY_T FLOAT,
	@GIOTAY_T FLOAT,
	@GIOMAYB FLOAT,
	@GIOTAYB FLOAT,
-- khai bao cho cac tham so se dua vao bang IT_BANGLUONGMOI
	@M_DV_TEN  nvarchar(50),
	@M_NAM nvarchar(4),
	@M_THANG nvarchar(2),
	@M_TUNGAY datetime,
	@M_DENNGAY  datetime,
	@M_HOTEN nvarchar(50),
	@M_SOTHE nvarchar(50),
	@M_T_MA nvarchar(50),
	@M_LUONGCHINH float,
	@M_MASOTHUE nvarchar(50),
	@M_SOTAIKHOAN nvarchar(50),
	@M_CMON_CVIEC float,
	@M_UUDAI float,
	@M_CHUYENCAN  float,
	@M_MOITRUONG float,
	@M_LUONG_TCCMON_CVIEC float,
	@M_CONG_TT FLOAT,
	@M_LUONGTHANG float,
	@M_HS_15 FLOAT,
	@M_HS_195 FLOAT,
	@M_HS_2  FLOAT,
	@M_HS_3 FLOAT,
	@M_TIENLAMTHEM float,
	@M_GIOLAMDEM  FLOAT,
	@M_TIENLAMDEM  FLOAT,
	@M_GIOKHAC  FLOAT,
	@M_TIENKHAC  float,
	@M_GIO_R_LE  FLOAT,
	@M_TIENNGHI_R_LE  float,
	@M_PHEPNAM  FLOAT,
	@M_TIENPHEPNAM  float,
	@M_TIEN_NTRO_KHAC_SHP float,
	@M_SOPHANCOM  FLOAT,
	@M_TIENCOM float,
	@M_BINHBAU  float,
	@M_23PT_BH_PHEP float,
	@M_CONGLUONG float, 
	@M_DATAMUNG  float,
	@M_THUETHUNHAP  float,
	@M_TIENBH_YT_XH_TN  float,
	@M_TIENCONGDOAN float,
	@M_CONLANHCUOIKY  float,
	@M_THUCLANH  float,
	@M_KYNHAN  nvarchar(50),
	@M_GHICHU  nvarchar(50),
	@M_TIENNUOICON6T FLOAT,
	@M_CONGVIEC nvarchar(50),
	@M_TTCV BIT,
	@M_DV_MA nvarchar(50),
	@M_X_MA  nvarchar(50),
	@M_TIENLAMTHEMTINHTHUE FLOAT, 
	@M_CONGLUONGTINHTHUE FLOAT,
	@SODONG INT,
	@TIENLUONG1GIO FLOAT
	
	
	select @HD_Ngayky = HD_Ngayky from ST_HOPDONGLAODONG where nv_ma=@NV_MA
	-- L?y ngày d?u tháng và cu?i tháng
	-- neu nhu thang sau co dieu dong
	-- lay donvi=donvicu
	-- khac
	SELECT @THANG_SAU = SUBSTRING (CONVERT(CHAR(10),DATEADD(M,1,CONVERT (DATETIME,SUBSTRING(@T_MA,4,4) + '-'+ SUBSTRING(@T_MA,1,2) + '-01')),105),4,7)

	--lay ra @TUNGAY_TSAU, @DENNGAY_TSAU cua thang sau.
	SELECT @TUNGAY_TSAU= T_TUNGAY, @DENNGAY_TSAU = T_DENNGAY FROM ST_THANG WHERE T_MA=@THANG_SAU


	if EXISTS(select * from st_chuyendonvi where nv_ma=@NV_MA and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU)
		begin
			select @DV_MA=CDV_donvimoi from st_chuyendonvi where nv_ma=@NV_MA
															and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU
			if @DV_MA in ('NV','NV1','NV01','NV02','NV03','NV 04') -- Andrew
				select @DV_MA=CDV_donvimoi from st_chuyendonvi where nv_ma=@NV_MA
														and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU
		else
			select @DV_MA=CDV_donvicu from st_chuyendonvi where nv_ma=@NV_MA
														and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU
			if @DV_MA like 'CNM' -- Andrew
				SELECT @DV_MA = DV_MA FROM ST_NHANVIEN WHERE NV_MA=@NV_MA
		end
	else
		select @DV_MA=DV_MA  from ST_NHANVIEN where NV_MA=@NV_MA

 
	--==============================================================
	--select @DV_MA=DV_MA  from ST_NHANVIEN where NV_MA=@NV_MA
	select @L_CONGKHAC=Sotien  from ST_KHOANCONGKHAC where NV_MA=@NV_MA and T_Ma=@T_Ma
	select @L_TRUKHAC=TIENDP  from	IT_DOANPHI where SOTHE=@NV_MA and THANGNAM=@T_Ma
	Select @NgayDau=T_TuNgay, @NgayCuoi=T_DenNgay, @SONGAYBT = T_SONGAYCONG 
	From ST_THANG
	Where T_MA=@T_MA
	

 --========================
	if exists(select * from ST_NHANVIENTHOIVIEC where NV_MA=@NV_MA and month(TV_Ngaythoiviec)=month(@NgayDau) and year(TV_Ngaythoiviec)=year(@NgayDau) and day(TV_Ngaythoiviec)<=15)
		select @DV_Ma ='NV' -- Andrew	
	if exists(select * from ST_NHANVIENTHOIVIEC where NV_MA=@NV_MA and month(TV_Ngaythoiviec)=month(@NgayDau) and year(TV_Ngaythoiviec)=year(@NgayDau) and day(TV_Ngaythoiviec)>15 and day(TV_Ngaythoiviec)<=day(@NgayCuoi) )
		select @DV_Ma ='NV01' -- Andrew
	-- Xoá lương của nhân viên cần tính
	Delete ST_LUONG_ Where NV_MA=@NV_MA and T_MA=@T_MA
	-- Lay phu cap 
	select @L_PHUCAPKHAC=PC_Sotien  from ST_NHANVIENPHUCAP where T_Ma=@T_Ma and LPC_Ma='PCKH' and NV_Ma=@NV_Ma
	select @L_PHUCAPDH=PC_Sotien  from ST_NHANVIENPHUCAP where T_Ma=@T_Ma and LPC_Ma='PCDH' and NV_Ma=@NV_Ma
	--TIEN NUOI CON 6T
	IF EXISTS (SELECT * FROM IT_QT_TROCAPCONDUOI6TUOI WHERE MANV=@NV_MA AND T_MA=@T_MA)
		SELECT @L_TIENNUOICON6T=SUM(ISNULL(SOTIEN,0))*1000 FROM IT_QT_TROCAPCONDUOI6TUOI WHERE MANV=@NV_MA AND T_MA=@T_MA

	--LAY LUONG TRUOC VA LUONG SAU
	SELECT @SODBL=COUNT(*) FROM ST_DIENBIENLUONG 
	WHERE DBL_Ngaybatdau>=@NgayDau 
	and DBL_Ngaybatdau<=@NgayCuoi
	and NV_MA=@NV_MA
	
	------Dựa vào dòng DBL trong tháng để tính toán
	IF @SODBL =2
		BEGIN
			select @NGAYGIUA= DBL_Ngaybatdau,@L_LUONGSAU=DBL_LuongCB,@L_PHUCAPSAU=DBL_Phucap	 
			from ST_DIENBIENLUONG 
			where  NV_MA=@NV_MA
				AND DBL_Ngaybatdau>=@NgayDau and DBL_Ngaybatdau<=@NgayCuoi 
				AND DBL_Ngaybatdau =(SELECT MAX(DBL_Ngaybatdau) 
										FROM ST_DIENBIENLUONG 
										WHERE DBL_Ngaybatdau>=@NgayDau and DBL_Ngaybatdau<=@NgayCuoi AND NV_MA=@NV_MA)
				
			select @L_LUONGTRUOC=DBL_LuongCB,@L_PHUCAPTRUOC=DBL_Phucap 
			from ST_DIENBIENLUONG 
			where NV_MA=@NV_MA
				AND DBL_NGAYBATDAU in (select MIN(DBL_NGAYBATDAU) 
										from ST_DIENBIENLUONG 
										where DBL_Ngaybatdau>=@NgayDau and DBL_Ngaybatdau<=@NgayCuoi AND NV_MA=@NV_MA)
		END
	ELSE
		BEGIN
			select @NGAYGIUA= DBL_Ngaybatdau,@L_LUONGSAU=DBL_LuongCB,@L_PHUCAPSAU=DBL_Phucap
			from ST_DIENBIENLUONG 
			where DBL_Ngaybatdau>@NgayDau and DBL_Ngaybatdau<=@NgayCuoi 
			and NV_MA=@NV_MA
				
			
			select @L_LUONGTRUOC=DBL_LuongCB,@L_PHUCAPTRUOC=DBL_Phucap
			from ST_DIENBIENLUONG 
			where DBL_NGAYBATDAU in (select max(DBL_NGAYBATDAU) from ST_DIENBIENLUONG where DBL_NGAYBATDAU<=@Ngaydau and NV_MA=@NV_MA)
			and NV_MA=@NV_MA				
		END
	
-------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------Tính toán Dựa trên Ngày Giữa - Ngày phát sinh DBL (Begin)----------------------------------------------------	
	if @NGAYGIUA is not NULL -- truong hop cong nhan  moi va ky hop dong tron thang (co 2 dong luong)
		BEGIN		
			---Thang co 2 ngay le
			-----------------------------------------------------------------------TH: @NgayGiua < QT_NGAY  < @NgayCuoi--------------------------------------------------------
			-------------------------------------------- Công Hệ Số 1 ( @L_CONGHS1 )
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- GIO LE
			if exists(select *  from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
								and LE_Ngay>=@NGAYGIUA) and NV_Ma=@NV_MA)
					select @L_NGHILE=8*count(LE_NGAY) 
					From ST_LE
					Where LE_NGAY>=@NGAYGIUA
					and LE_NGAY <=@NgayCuoi
					and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)
					and LE_NGAY > (select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
								and LE_Ngay>=@NGAYGIUA) and NV_Ma=@NV_MA)
			else
					select @L_NGHILE=8*count(LE_NGAY) 
					From ST_LE
					Where LE_NGAY>=@NGAYGIUA
					and LE_NGAY <=@NgayCuoi
					and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)



			select  @NgayLeTam=8* count(*)  from ST_GIOQUETTHE_
			where QT_NGAY >=@NGAYGIUA and
				 QT_NGAY <=@NgayCuoi
				and NV_Ma =@NV_MA
				and (NP_Ma='TS' or  NP_Ma='HS' or  NP_Ma='ST' OR  NP_Ma='KHHGD' OR NP_Ma='CO' OR NP_Ma='OM')
				and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYGIUA and LE_NGAY <=@NgayCUOI)
			if @L_NGHILE-@NgayLeTam<0 
              			select @L_NGHILE=0
			else
					   select @L_NGHILE=@L_NGHILE-@NgayLeTam
		
			--------------------------------------------- Công Hệ Số 2 ( @L_CONGHS2 ) 
			--Bình Thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			----Tỷ Bách
			----====================CHINH SUA
			--SET @GIOTAY_T =0
			--select @GIOTAY =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >4 AND ST_GIOQUETTHE_.CC_GIOTANGCATAY <=5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY -4
			--			WHEN ST_GIOQUETTHE_.CC_GIOTANGCATAY >5.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCA IS NULL
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY>4
			
			--	-----==========chinh sua gio tang ca
			--select @GIOTAY_T =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >2.5 AND ST_GIOQUETTHE_.CC_GIOTANGCATAY <=3.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY-2.5
			--WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>3.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCATAY  >0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCA IS NULL
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY>2.5
			--	----==============================

			----select @GIOTAY=sum(case when CC_GIOTANGCATAY>=5.5 then 1.5 else CC_GIOTANGCATAY-4 end)
			----From ST_GIOQUETTHE_
			----Where QT_NGAY>=@NGAYGIUA
			----	and QT_NGAY <=@NgayCuoi
			----	and NV_MA=@NV_MA	
			----	and CC_GIOTANGCATAY is not null
			----	AND CC_HESONGAYCONG = 1
			----	AND CA_MA='Ca HC'
			----	and CC_GIOTANGCATAY>4
			--	-----CHINH SUA
	
			--SET @GIOMAY_T=0
			--select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >4 AND ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-4
			--			WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>5.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA =0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA>4
			
			-------==========chinh sua gio tang ca
			--select @GIOMAY_T=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >2.5 AND ST_GIOQUETTHE_.CC_GIOTANGCA<=3.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-2.5
			--WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>3.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA >0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA>2.5
			------==============================
			
			--SELECT @L_CONGHS2B=ISNULL(@GIOTAY,0)+ISNULL(@GIOTAY_T ,0) + ISNULL(@GIOMAY,0)+ ISNULL(@GIOMAY_T ,0)

			--select @L_CONGHS2=@L_CONGHS2A+@L_CONGHS2B

			-- Andrew
			select @GIOTAY=sum(case when CC_GIOBINHTHUONGTAY>13.5 then 13.5 else CC_GIOBINHTHUONGTAY end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(case when CC_GIOBINHTHUONG> 13.5 then 13.5 else CC_GIOBINHTHUONG end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--------------
			select @GIOTAY=sum(case when CC_GIOBINHTHUONGTAY>13.5 then CC_GIOBINHTHUONGTAY- 13.5 else 0 end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(case when CC_GIOBINHTHUONG> 13.5 then CC_GIOBINHTHUONG-13.5 else 0 end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
		
			select @L_CONGHS27=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			--====================CHINH SUA
			SET @GIOTAY_T =0
			select @GIOTAY =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >5.5  THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY -5.5
						 ELSE 0 END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				AND ST_GIOQUETTHE_.CC_GIOTANGCA IS NULL
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew

			SET @GIOMAY_T=0
			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-5.5
						 ELSE 0 END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCA =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCA>5.5			
			
			SELECT @L_CONGHS21=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-------------------------------------------------------------

			-------------------------------------------- Công Hệ Số 3 ( @L_CONGHS3 )
			--Bình thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 3		
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONG is not null
		
			SELECT @L_CONGHS3=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--Tăng ca
			select @GIOTAY=sum(CC_GIOTANGCATAY-4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA>4
			select @GIOMAY=sum(CC_GIOTANGCA-4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA>4
			SELECT @L_CONGHS3B = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			select @GIOTAY=sum(case when ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY ,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)>=5.5 
						then ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY ,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY ,0)-5.5 else 0 end)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA	
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY ,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY ,0)>4	

			--select @GIOTAY=sum(case when CC_GIOTANGCATAY>=5.5 then CC_GIOTANGCATAY-5.5 else 0 end)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY>4
			
			
			select @GIOMAY=sum(case when ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)>=5.5 
						then ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)-5.5 else 0 end)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA	
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)>4	
			--select @GIOMAY=sum(case when CC_GIOTANGCA>=5.5 then CC_GIOTANGCA-5.5 else 0 end)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA>4
			
			SELECT @L_CONGHS2C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			SELECT @L_CONGHS3A= @L_CONGHS3 + @L_CONGHS3B + @L_CONGHS2C
			-- TANG CA HE SO >1 and <4
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG > 1
				AND CC_HESONGAYCONG < 4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG > 1
				AND CC_HESONGAYCONG < 4
			SELECT @L_TCAHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--Tinh cong theo phu cap trach nhiem
			SELECT @L_CONGHS2A=@L_CONGHS2A+@L_CONGHS3+ @L_TCAHS2
			SELECT @L_CONGHS3=@L_CONGHS3+@L_TCAHS2

			-- TANG CA HE SO 15
			--select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY<=4
			--	and CA_MA<>'Ca 3'
			--====================CHINH SUA
			SET @GIOTAY =0
			select @GIOTAY= ISNULL(SUM (ST_GIOQUETTHE_.CC_GIOTANGCATAY ),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is  null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCATAY <=4 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY >0 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOTAY= @GIOTAY+ ISNULL(SUM(ST_GIOQUETTHE_.CC_GIOTANGCATAY ),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is  null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCATAY <=2.5 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY >0 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCATAY>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================	
			
			--select @GIOMAY=sum(CC_GIOTANGCA)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA<=4
			--	and CA_MA<>'Ca 3'
			--====================CHINH SUA
			SET @GIOMAY=0
			select @GIOMAY= ISNULL(SUM (ST_GIOQUETTHE_.CC_GIOTANGCA),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCA<=4 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCA>0 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCA=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOMAY= @GIOMAY+ ISNULL(SUM(ST_GIOQUETTHE_.CC_GIOTANGCA),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCA<=2.5 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCA>0
				and ST_GIOQUETTHE.CC_GIOTANGCA>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY>4
			--	and CA_MA<>'Ca 3'
			--====================CHINH SUA
			SET @GIOTAYB =0
			
			select @GIOTAYB= ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCATAY ) *4,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
			and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			and ST_GIOQUETTHE_.NV_MA=@NV_MA
			AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			and ST_GIOQUETTHE_.CC_GIOTANGCA is  null
			AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			and ST_GIOQUETTHE_.CC_GIOTANGCATAY >4
			and ST_GIOQUETTHE.CC_GIOTANGCATAY=0
			and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOTAYB=@GIOTAYB+ ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCATAY ) *2.5,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
			and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			and ST_GIOQUETTHE_.NV_MA=@NV_MA
			AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			and ST_GIOQUETTHE_.CC_GIOTANGCA is null
			AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			and ST_GIOQUETTHE_.CC_GIOTANGCATAY >2.5
			and ST_GIOQUETTHE.CC_GIOTANGCATAY >0
			and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================

			--select @GIOMAY=count(CC_GIOTANGCA) *4
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA>4
			--	and CA_MA<>'Ca 3'
				--====================CHINH SUA
			SET @GIOMAYB=0
			select @GIOMAYB= ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCA) *4,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCA>4
				and ST_GIOQUETTHE.CC_GIOTANGCA=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOMAYB=@GIOMAYB+ ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCA) *2.5,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
				Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCA>2.5
				and ST_GIOQUETTHE.CC_GIOTANGCA>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
		
			SELECT @L_CONGHS15B=ISNULL(@GIOTAYB ,0) + ISNULL(@GIOMAYB,0)

			--SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B --Tỷ Bách

			--Andrew	
			select @GIOTAY =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >5.5  THEN 5.5
					 ELSE ST_GIOQUETTHE_.CC_GIOTANGCATAY  END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				AND ST_GIOQUETTHE_.CC_GIOTANGCA IS NULL
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03'  OR ST_GIOQUETTHE_.CA_MA ='Ca 2' OR ST_GIOQUETTHE_.CA_MA ='Ca 3' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>0

			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5 THEN 5.5
						 ELSE ST_GIOQUETTHE_.CC_GIOTANGCA END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYGIUA
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCA =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03'  OR ST_GIOQUETTHE_.CA_MA ='Ca 2' OR ST_GIOQUETTHE_.CA_MA ='Ca 3'OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCA>0
			
			SELECT @L_CONGHS15=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Lam dem
			select @GIOTAY=sum(CC_GIOLAMDEMTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOLAMDEMTAY is not null
			select @GIOMAY=sum(CC_GIOLAMDEM)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOLAMDEMTAY IS NULL
				and CC_GIOLAMDEM is not null
			SELECT @L_LAMDEM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Ca dem
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOBINHTHUONGTAY IS NULL
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS4=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tang Ca dem
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA<=4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA<=4
			SELECT @L_CONGTCAHS4A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			select @GIOTAY=sum(4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA>4
			select @GIOMAY=sum(4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA>4
			SELECT @L_CONGTCAHS4B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGTCAHS4=@L_CONGTCAHS4A+@L_CONGTCAHS4B
		

			--select @L_LAMDEM=@L_LAMDEM+@L_CONGHS4
			-- Ngung viec
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='NV' or NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='NV' or NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGUNGVIEC=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi P
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi R
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0) 

			-- Nghi RO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIRO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)


			-- Nghi DQ
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIDQ=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi OM
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIOM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi ST
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIST=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi TS
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi HS
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIHS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi KTHAI
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIKHAMTHAI=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi NO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='NO' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='NO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi O
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='O' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='O')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		-- Nghi TNLD
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='TNLD' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='TNLD')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITNLD=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			 -- Nghi Ds
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIDS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi KHHGD
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='KHHGD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA= 'KHHGD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			SELECT @GIOKHHGD =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tam ung
			select @L_TAMUNG=TU_SOTIEN from ST_TAMUNG where NV_MA=@NV_MA and T_MA=@T_MA
					
			--- Dong BHXH,BHYT
			select @L_BHXH=HD_DongBHXH,@L_BHYT=HD_DongBHYT 
			from  ST_Hopdonglaodong inner join st_nhanvien on st_nhanvien.nv_ma=ST_Hopdonglaodong.nv_ma
			where ST_Hopdonglaodong.NV_Ma=@NV_MA 
			and 
				( convert(int,substring(bl_ma,5,2))> 1
					or (convert(char(7),HD_NGAYKY,21) = right(@t_ma,4) +'-' + left(@T_MA,2) and day(HD_NGAYKY)<=15 and convert(int,substring(bl_ma,5,2))=1)
					or ( convert(int,substring(bl_ma,5,2))<=1 and convert(char(7),HD_NGAYKY,21) < right(@t_ma,4) +'-' + left(@T_MA,2) )
					or  datediff(m,nv_ngayvao,HD_NGAYKY)>12
				 )
		 

			-- SUATAN
			select @L_SOPHANCOM=sum(CC_SUATAN)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_SUATAN is not null
			--- Tinh lai nga le tet neu truong hop co nghi thai san
					--if @L_NGHIHS>=@L_NGHILE 
					--	select @L_NGHILE=0
					--else
					--	select @L_NGHILE=@L_NGHILE-@L_NGHIHS

			--		if @L_NGHITS>=@L_NGHILE 
			--			select @L_NGHILE=0
			--		else
			--			select @L_NGHILE=@L_NGHILE-@L_NGHITS


			--- Tinh phu cap
			select @L_PCTRNSAU=@L_PHUCAPSAU
			--- Tinh chuyen can_,moi truong 
			select @SOLANQUENQUETTHE=sum(CC_QUENQUETTHE) , @SOLANDITRE=sum(CC_DITRE) from  ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_Hesongaycong =1
			select @L_PCMTruong=round((@L_CONGHS1+(@L_CONGHS2/8))*1800,0)

			if @L_NGHIRO+@L_NGHIOM+@L_NGHITS+@L_NGHINO+@L_NGHIO+@L_NGHIR+@L_NGHIP+@L_NGHIDS=0 
				select @Chuyencan=  40000
			else
				begin	
		   			if @L_NGHIOM=0 
		      				if @L_NGHIRO+ @L_NGHIOM <=8 
								select @Chuyencan= 20000-(@L_NGHITS+@L_NGHINO+@L_NGHIR+@L_NGHIP+@L_NGHIDS)/8*1500
						else
									select @Chuyencan=  0
					ELSE
		      			select @Chuyencan=  0
				end
			if @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)<0 
	    		select @L_PCCCAN=0
			else
				select @L_PCCCAN=   @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)

			--begin ----- Ngay le di lam thi gio nghi le=0-----------
			if @L_CONGHS3A <>0
				select @L_NGHILE =0 

			---end ------------------------
			if @L_NGHILE-@L_CONGHS3A<0 
				select @L_NGHILE =0 
			else
				select @L_NGHILE =@L_NGHILE-@L_CONGHS3A
			
			--@TIENLUONG1GIO
		   SELECT @TIENLUONG1GIO = L_TIENLUONG1GIO FROM ST_LUONG
       
			--Tinh L_TraBH_P
			if isnull(@L_LUONGTRUOC,0)>0
				select @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4)+@L_LAMDEM+@L_NGHIR+@L_NGHILE+@L_NGHIP+@L_NGHINO)/8)*0.25*isnull(@L_LUONGTRUOC,0)/26
			else
				select @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4)+@L_LAMDEM+@L_NGHIR+@L_NGHILE+@L_NGHIP+@L_NGHINO)/8)*0.25*isnull(@L_LUONGSAU,0)/26

			------------------------------------------------------------------------------------------------------
			------------------------------------------Thêm dòng vào ST_LUONG--------------------------------------
			------------------------------------------------------------------------------------------------------
			if (isnull(@L_LUONGSAU,0)>0) -- trường hợp: @NgayGiua < QT_NGAY  < @NgayCuoi
			begin
					insert into ST_LUONG_(NV_MA,T_MA,L_LUONGCHINH,L_PHUCAPKHAC,L_PCTRACHNHIEM,L_PCCHUYENCAN,L_PCMOITRUONG,L_PHUCAPDH
						,DV_MA,L_LOAI
						,L_CONGHS1,L_CONGHS2,L_CONGHS2A,L_CONGHS3,L_CONGHS15,L_CONGHS21,L_CONGHS27,L_CONGCADEM,L_CONGTCADEM,L_LAMDEM
						,L_NGUNGVIEC, L_NGHIDQ,L_NGHILE,L_NGHIP,L_NGHIR,L_NGHIRO,L_NGHIOM, L_NGHIST,L_NGHITS,L_NGHIKHAMTHAI,L_NGHIDS,L_NGHIKHHGD,L_NGHIO,L_NGHINO,L_NGHITNLD
						,L_TAMUNG,L_BHXH,L_BHYT,L_SOPHANCOM,L_SOLANDITRE,L_SOLANQUENQT,L_CONGKHAC,L_TRUKHAC,L_TraBH_P,L_TIENNUOICON6T) 
					values(@NV_MA,@T_MA,isnull(@L_LUONGSAU,0),@L_PHUCAPKHAC,@L_PCTRNSAU,@L_PCCCAN,@L_PCMTruong,@L_PHUCAPDH
						,@DV_MA,@LOAILUONG
						,@L_CONGHS1,@L_CONGHS2,@L_CONGHS2A,@L_CONGHS3A,@L_CONGHS15,@L_CONGHS21,@L_CONGHS27,@L_CONGHS4,@L_CONGTCAHS4,@L_LAMDEM
						,@L_NGUNGVIEC, @L_NGHIDQ,@L_NGHILE,@L_NGHIP,@L_NGHIR,@L_NGHIRO,@L_NGHIOM, @L_NGHIST,@L_NGHITS,@L_NGHIKHAMTHAI,@L_NGHIDS,@GIOKHHGD,@L_NGHIO,@L_NGUNGVIEC,@L_NGHITNLD
						,@L_TAMUNG,@L_BHXH,@L_BHYT,@L_SOPHANCOM,@SOLANDITRE,@SOLANQUENQUETTHE,@L_CONGKHAC,@L_TRUKHAC,@L_TraBH_P,@L_TIENNUOICON6T)

					--Cap nhat trang thai huong luong ky hop dong
		
					update ST_LUONG_ set L_HUONGLUONGKHD = 1, L_HUONGCHUYENCAN = 1
					where nv_ma  in 
					(select nv_ma from st_hopdonglaodong where month(hd_ngayky)!=convert(int,left(@t_ma,2))
					 or year(hd_ngayky)!=convert(int,right(@t_ma,4))) and nv_ma=@nv_ma and t_ma=@T_MA

					update ST_LUONG_ 
					set  L_HUONGCHUYENCAN = 1
					WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)
					AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)
					AND ST_LUONG_.nv_ma=@NV_MA and t_ma=@T_MA

					Update ST_LUONG_ Set L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1
					from ST_LUONG_
					inner join st_hopdonglaodong 
					on ST_LUONG_.nv_ma=st_hopdonglaodong.nv_ma
					and ST_LUONG_.l_luongchinh=st_hopdonglaodong.hd_luongcb
					where ST_LUONG_.nv_ma=@NV_MA
					and t_ma=@T_MA

					update ST_LUONG_ set L_DuocTraBH_P = 1
					where nv_ma in 
					(select nv_ma from st_hopdonglaodong where month(hd_ngayky)=convert(int,left(@t_ma,2)) 
					and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>15) and nv_ma=@nv_ma and t_ma=@T_MA

					update ST_LUONG_ set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
					where nv_ma not in 
					(select nv_ma from st_hopdonglaodong where hd_ngayky is not null )
					and nv_ma=@nv_ma and t_ma=@T_MA

					UPDATE ST_LUONG_ SET L_DuocTraBH_P = 0
					FROM ST_LUONG_ INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG_.NV_MA = ST_HOPDONGLAODONG.NV_MA
					INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
					where t_ma=@t_ma
					and ST_LUONG_.nv_ma=@nv_ma
					and  month(hd_ngayky)=convert(int,left(@t_ma,2)) 
					and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)<=15

					update ST_LUONG_ set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
					where nv_ma  in 
					(select nv_ma from st_hopdonglaodong where hd_ngayky is not null AND ( (YEAR(HD_NGAYKY) > RIGHT(T_MA,4)) 
					OR ( YEAR(HD_NGAYKY) = RIGHT(T_MA,4) AND MONTH(HD_NGAYKY) > LEFT(T_MA,2)) ) ) 
					and nv_ma=@nv_ma and t_ma=@T_MA

					--		update ST_LUONG set L_DuocTraBH_P = 1
					--		from st_luong
					--		inner join st_hopdonglaodong
					--		on st_luong.nv_ma=st_hopdonglaodong.nv_ma
					--		where t_ma=@t_ma
					--		and st_luong.nv_ma=@nv_ma
					--		and st_luong.l_luongchinh<st_hopdonglaodong.hd_luongcb

					UPDATE ST_LUONG_ SET  L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1,L_DuocTraBH_P = 0
					FROM ST_LUONG_ INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG_.NV_MA = ST_HOPDONGLAODONG.NV_MA
					INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
					where t_ma=@t_ma
					and ST_LUONG_.nv_ma=@nv_ma
					and DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY) >= 12

					UPDATE ST_LUONG_
					SET L_TRABH_P = 0
					WHERE DV_MA LIKE '%CG%'
					and nv_ma=@nv_ma and t_ma=@T_MA		
			end

		-----------------------------------------------------------------------TH:@NgayDau < QT_NGAY  < @NgayGiua --------------------------------------------------------

			-------------------------------------------- Công Hệ Số 1 ( @L_CONGHS1 )
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- GIO LE

			if exists(select *  from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NGAYGIUA
								and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
					select @L_NGHILE=8*count(LE_NGAY) 
					From ST_LE
					Where LE_NGAY>=@NGAYDAU
					and LE_NGAY <=@NGAYGIUA
					and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)
					and LE_NGAY > (select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NGAYGIUA
								and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
			else
					select @L_NGHILE=8*count(LE_NGAY) 
					From ST_LE
					Where LE_NGAY>=@NGAYDAU
					and LE_NGAY <=@NGAYGIUA
					and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)



			select  @NgayLeTam=8* count(*)  from ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
			and NV_Ma =@NV_MA
			and (NP_Ma='TS' or  NP_Ma='HS' or  NP_Ma='ST' OR  NP_Ma='KHHGD' OR NP_Ma='CO' OR NP_Ma='OM')
			and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYDAU and LE_NGAY <=@NGAYGIUA)
			if @L_NGHILE-@NgayLeTam<0 
				select @L_NGHILE=0
			else
				select @L_NGHILE=@L_NGHILE-@NgayLeTam

			--------------------------------------------- Công Hệ Số 2 ( @L_CONGHS2 ) 
			-- Bình Thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			----Tỷ Bách
			----	select @GIOTAY=sum(case when CC_GIOTANGCATAY>=5.5 then 1.5 else CC_GIOTANGCATAY-4 end)
			----From ST_GIOQUETTHE_
			----Where QT_NGAY>=@NGAYDAU
			----	and QT_NGAY <@NGAYGIUA
			----	and NV_MA=@NV_MA	
			----	and CC_GIOTANGCATAY is not null
			----	AND CC_HESONGAYCONG = 1
			----	AND CA_MA='Ca HC'
			----	and CC_GIOTANGCATAY>4
			----====================-----CHINH SUA
			--SET @GIOTAY_T =0
			--select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >4 AND ST_GIOQUETTHE_.CC_GIOTANGCATAY<=5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY-4
			--			WHEN ST_GIOQUETTHE_.CC_GIOTANGCATAY>5.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCATAY  =0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY>4
			
			--	-----==========chinh sua gio tang ca
			--select @GIOTAY_T =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >2.5 AND ST_GIOQUETTHE_.CC_GIOTANGCATAY<=3.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY-2.5
			--WHEN ST_GIOQUETTHE_.CC_GIOTANGCATAY>3.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCATAY >0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY is null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY>2.5
			--	----==============================
			----select @GIOMAY=sum(case when CC_GIOTANGCA>=5.5 then 1.5 else CC_GIOTANGCA-4 end)
			----From ST_GIOQUETTHE_
			----Where QT_NGAY>=@NGAYDAU
			----	and QT_NGAY <@NGAYGIUA
			----	and NV_MA=@NV_MA
			----	AND CC_GIOTANGCATAY IS NULL
			----	and CC_GIOTANGCA is not null
			----	AND CC_HESONGAYCONG = 1
			----	AND CA_MA='Ca HC'
			----	and CC_GIOTANGCA>4
			----===================-----CHINH SUA
			--SET @GIOMAY_T=0
			--select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >4 AND ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-4
			--			WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>5.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA =0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA>4
			
			--	-----==========chinh sua gio tang ca
			--select @GIOMAY_T=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >2.5 AND ST_GIOQUETTHE_.CC_GIOTANGCA<=3.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-2.5
			--WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>3.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA >0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA>2.5
			--	----==============================
			
			--SELECT @L_CONGHS2B=ISNULL(@GIOTAY,0)+ISNULL(@GIOTAY_T,0) + ISNULL(@GIOMAY,0)+ISNULL(@GIOMAY_T,0)
				
			--select @L_CONGHS2=@L_CONGHS2A+@L_CONGHS2B
			
			--Andrew			
			select @GIOTAY=sum(case when CC_GIOBINHTHUONGTAY >13.5 then 13.5 else CC_GIOBINHTHUONGTAY end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(case when CC_GIOBINHTHUONG >13.5 then 13.5 else CC_GIOBINHTHUONG end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not NULL
            -------------------------------   
			SELECT @L_CONGHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			select @GIOTAY=sum(case when CC_GIOBINHTHUONGTAY >13.5 then CC_GIOBINHTHUONGTAY - 13.5 else 0 end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(case when CC_GIOBINHTHUONG >13.5 then CC_GIOBINHTHUONG-13.5 else 0 end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
		
			select @L_CONGHS27=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--====================-----CHINH SUA
			SET @GIOTAY_T =0
			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >5.5  THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY-5.5
						 ELSE 0 END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCATAY  =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>5.5
						
			--===================-----CHINH SUA
			SET @GIOMAY_T=0
			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5  THEN ST_GIOQUETTHE_.CC_GIOTANGCA-5.5
						ELSE 0 END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCA =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
			
			
			SELECT @L_CONGHS21=ISNULL(@GIOTAY,0)+ ISNULL(@GIOMAY,0)

			-------------------------------------------- Công Hệ Số 3 ( @L_CONGHS3 )
			--Bình thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 3			
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONG is not null
		
			SELECT @L_CONGHS3=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--Tăng ca
			select @GIOTAY=sum(CC_GIOTANGCATAY-4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA>4
			select @GIOMAY=sum(CC_GIOTANGCA-4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA>4
			SELECT @L_CONGHS3B = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			select @GIOTAY=sum(case when ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)>=5.5 
			then ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)-5.5 else 0 end)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA	
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is  null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)>4	

			--select @GIOTAY=sum(case when CC_GIOTANGCATAY>=5.5 then CC_GIOTANGCATAY-5.5 else 0 end)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <@NGAYGIUA
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY>4
			
			select @GIOMAY=sum(case when ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)>=5.5 
			then ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)-5.5 else 0 end)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA	
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)>4	
			--select @GIOMAY=sum(case when CC_GIOTANGCA>=5.5 then CC_GIOTANGCA-5.5 else 0 end)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <@NGAYGIUA
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA>4
			
			SELECT @L_CONGHS2C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			SELECT @L_CONGHS3A= @L_CONGHS3 + @L_CONGHS3B + @L_CONGHS2C
			-- TANG CA HE SO >1 and <4
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG > 1
				AND CC_HESONGAYCONG < 4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG > 1
				AND CC_HESONGAYCONG < 4
			SELECT @L_TCAHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--Tinh cong theo phu cap trach nhiem
			SELECT @L_CONGHS2A=@L_CONGHS2A+@L_CONGHS3+ @L_TCAHS2
			SELECT @L_CONGHS3=@L_CONGHS3+@L_TCAHS2

			-- TANG CA HE SO 15
			--====================CHINH SUA
			SET @GIOTAY  =0
			select @GIOTAY= ISNULL(SUM (ST_GIOQUETTHE_.CC_GIOTANGCATAY)	,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=4 -- Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=5.5 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCATAY=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOTAY= @GIOTAY+ ISNULL(SUM(ST_GIOQUETTHE_.CC_GIOTANGCATAY),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=2.5 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=5.5 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCATAY>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			--		select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <@NGAYGIUA
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY<=4
			--	and CA_MA<>'Ca 3'
				
			--select @GIOMAY=sum(CC_GIOTANGCA)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <@NGAYGIUA
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA<=4
			--	and CA_MA<>'Ca 3'
				--====================CHINH SUA
			SET @GIOMAY =0
			select @GIOMAY= ISNULL(SUM (ST_GIOQUETTHE_.CC_GIOTANGCA)	,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCA<=4 -- Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5 -- Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCA=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOMAY= @GIOMAY+ ISNULL(SUM(ST_GIOQUETTHE_.CC_GIOTANGCA),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCA<=2.5-- Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5 -- Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCA>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		

			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <@NGAYGIUA
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY>4
			--	and CA_MA<>'Ca 3'

			--====================CHINH SUA
			SET @GIOTAYB =0
			select @GIOMAYB = ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCATAY) *4,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>4
				and ST_GIOQUETTHE.CC_GIOTANGCATAY=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOTAYB =@GIOTAYB + ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCATAY) *2.5,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>2.5
				and ST_GIOQUETTHE.CC_GIOTANGCATAY>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			--select @GIOMAY=count(CC_GIOTANGCA) *4
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <@NGAYGIUA
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA>4
			--	and CA_MA<>'Ca 3'
		
			--====================CHINH SUA
			SET @GIOMAYB =0
			select @GIOMAYB = ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCA) *4,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCA>4
				and ST_GIOQUETTHE.CC_GIOTANGCA=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOMAYB =@GIOMAYB + ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCA) *2.5,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCA>2.5
				and ST_GIOQUETTHE.CC_GIOTANGCA>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			SELECT @L_CONGHS15B=ISNULL(@GIOTAYB ,0) + ISNULL(@GIOMAYB,0)

			-- SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B -- Tỷ Bách
			-- Andrew
			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >5.5  THEN 5.5
					 ELSE ST_GIOQUETTHE_.CC_GIOTANGCATAY END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCATAY  =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03'  OR ST_GIOQUETTHE_.CA_MA ='Ca 2' OR ST_GIOQUETTHE_.CA_MA ='Ca 3' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew

			--select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5  THEN ST_GIOQUETTHE_.CC_GIOTANGCA-5.5
			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5  THEN 5.5
						ELSE ST_GIOQUETTHE_.CC_GIOTANGCA END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <@NGAYGIUA
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCA =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03'  OR ST_GIOQUETTHE_.CA_MA ='Ca 2' OR ST_GIOQUETTHE_.CA_MA ='Ca 3' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				
			SELECT @L_CONGHS15=ISNULL(@GIOTAY,0)+ ISNULL(@GIOMAY,0)

			-- Lam dem
			select @GIOTAY=sum(CC_GIOLAMDEMTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and CC_GIOLAMDEMTAY is not null
			select @GIOMAY=sum(CC_GIOLAMDEM)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_GIOLAMDEMTAY IS NULL
				and CC_GIOLAMDEM is not null
			SELECT @L_LAMDEM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
	-- Ca dem
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOBINHTHUONGTAY IS NULL
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS4=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tang Ca dem
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA<=4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA<=4
			SELECT @L_CONGTCAHS4A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			select @GIOTAY=sum(4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA>4
			select @GIOMAY=sum(4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA>4
			SELECT @L_CONGTCAHS4B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGTCAHS4=@L_CONGTCAHS4A+@L_CONGTCAHS4B
		

			--select @L_LAMDEM=@L_LAMDEM+@L_CONGHS4
			-- Ngung viec
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and (NP_MA='NV' or NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and (NP_MA='NV' or NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGUNGVIEC=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi P
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi R
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0) 

			-- Nghi RO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIRO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)


			-- Nghi DQ
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIDQ=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi OM
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIOM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi ST
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIST=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi TS
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi HS
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIHS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi KTHAI
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIKHAMTHAI=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi NO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and (NP_MA='NO' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and (NP_MA='NO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi O
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and (NP_MA='O' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and (NP_MA='O')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi TNLD
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and (NP_MA='TNLD' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and (NP_MA='TNLD')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITNLD=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			 -- Nghi Ds
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIDS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi KHHGD
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and NP_MA='KHHGD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA
				and NP_MA= 'KHHGD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			SELECT @GIOKHHGD =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tam ung
			select @L_TAMUNG=TU_SOTIEN from ST_TAMUNG where NV_MA=@NV_MA and T_MA=@T_MA
					
				-- Tam ung
			select @L_TAMUNG=0
			select @L_BHXH=0, @L_BHYT=0
			select @L_PCCCAN=0,@L_PHUCAPKHAC=0, @L_PCMTruong=0

			-- SUATAN
			select @L_SOPHANCOM=sum(CC_SUATAN)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and CC_SUATAN is not null
			--- Tinh lai nga le tet neu truong hop co nghi thai san
					--if @L_NGHIHS>=@L_NGHILE 
					--	select @L_NGHILE=0
					--else
					--	select @L_NGHILE=@L_NGHILE-@L_NGHIHS

			--		if @L_NGHITS>=@L_NGHILE 
			--			select @L_NGHILE=0
			--		else
			--			select @L_NGHILE=@L_NGHILE-@L_NGHITS


			--- Tinh phu cap
			select @L_PCTRNSAU=@L_PHUCAPTRUOC
			--- Tinh chuyen can_,moi truong 
			select @SOLANQUENQUETTHE=sum(CC_QUENQUETTHE) , @SOLANDITRE=sum(CC_DITRE) from  ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <@NGAYGIUA
				and NV_MA=@NV_MA	
				and CC_Hesongaycong =1
			select @L_PCMTruong=round((@L_CONGHS1+(@L_CONGHS2/8))*1800,0)

			if @L_NGHIRO+@L_NGHIOM+@L_NGHITS+@L_NGHINO+@L_NGHIO+@L_NGHIR+@L_NGHIP+@L_NGHIDS=0 
				select @Chuyencan=  40000
			else
				begin	
		   			if @L_NGHIOM=0 
		      			if @L_NGHIRO+ @L_NGHIOM <=8 
							SELECT @Chuyencan= 20000-(@L_NGHITS+@L_NGHINO+@L_NGHIR+@L_NGHIP+@L_NGHIDS)/8*1500
						else
							select @Chuyencan=  0
					ELSE
		      			select @Chuyencan=  0
				END
            
			if @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)<0 
	    		select @L_PCCCAN=0
			else
				select @L_PCCCAN=   @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)
			--begin ----- Ngay le di lam thi gio nghi le=0-----------
			if @L_CONGHS3A <>0
				select @L_NGHILE =0 
			---end ------------------------
			if @L_NGHILE-@L_CONGHS3A<0 
				select @L_NGHILE =0 
			else
				select @L_NGHILE =@L_NGHILE-@L_CONGHS3A
			--Tinh L_TraBH_P
			select @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4)+@L_LAMDEM+@L_NGHIR+@L_NGHILE+@L_NGHIP+@L_NGHINO)/8)*0.25*isnull(@L_LUONGTRUOC,0)/26

	------------------------------------------------------------------------------------------------------
	------------------------------------------Thêm dòng vào ST_LUONG--------------------------------------
	------------------------------------------------------------------------------------------------------
			--Thêm dòng vào ST_Luong (TH: @NgayDau < QT_NGAY  < @NgayGiua)
			if (isnull(@L_LUONGTRUOC,0)>0)
			begin
				insert into ST_LUONG_(NV_MA,T_MA,L_LUONGCHINH,L_PHUCAPKHAC,L_PCTRACHNHIEM,L_PCCHUYENCAN,L_PCMOITRUONG,L_PHUCAPDH
					,DV_MA,L_LOAI
					,L_CONGHS1,L_CONGHS2,L_CONGHS2A,L_CONGHS3,L_CONGHS15,L_CONGHS21,L_CONGHS27,L_CONGCADEM,L_CONGTCADEM,L_LAMDEM
					,L_NGUNGVIEC, L_NGHIDQ,L_NGHILE,L_NGHIP,L_NGHIR,L_NGHIRO,L_NGHIOM, L_NGHIST,L_NGHITS,L_NGHIKHAMTHAI,L_NGHIDS,L_NGHIKHHGD,L_NGHIO,L_NGHINO,L_NGHITNLD
					,L_TAMUNG,L_BHXH,L_BHYT,L_SOPHANCOM,L_SOLANDITRE,L_SOLANQUENQT,L_TraBH_P) 
				values(@NV_MA,@T_MA,isnull(@L_LUONGTRUOC,0),@L_PHUCAPKHAC,@L_PCTRNTRUOC,@L_PCCCAN,@L_PCMTruong,@L_PHUCAPDH
					,@DV_MA,@LOAILUONG
					,@L_CONGHS1,@L_CONGHS2,@L_CONGHS2A,@L_CONGHS3A,@L_CONGHS15,@L_CONGHS21,@L_CONGHS27,@L_CONGHS4,@L_CONGTCAHS4,@L_LAMDEM
					,@L_NGUNGVIEC,@L_NGHIDQ,@L_NGHILE,@L_NGHIP,@L_NGHIR,@L_NGHIRO,@L_NGHIOM, @L_NGHIST,@L_NGHITS,@L_NGHIKHAMTHAI,@L_NGHIDS,@GIOKHHGD,@L_NGHIO,@L_NGUNGVIEC,@L_NGHITNLD
					,@L_TAMUNG,@L_BHXH,@L_BHYT,@L_SOPHANCOM,@SOLANDITRE,@SOLANQUENQUETTHE,@L_TraBH_P)

		--Cap nhat trang thai huong luong ky hop dong

				update ST_LUONG_ set L_HUONGLUONGKHD = 1, L_HUONGCHUYENCAN = 1
				where nv_ma  in 
				(select nv_ma from st_hopdonglaodong where month(hd_ngayky)!=convert(int,left(@t_ma,2))
					or year(hd_ngayky)!=convert(int,right(@t_ma,4))) and nv_ma=@nv_ma and t_ma=@T_MA

				update ST_LUONG_ 
				set  L_HUONGCHUYENCAN = 1
				WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)
				AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)
				AND ST_LUONG_.nv_ma=@NV_MA and t_ma=@T_MA

				Update ST_LUONG_ Set L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1
				from ST_LUONG_
				inner join st_hopdonglaodong 
				on ST_LUONG_.nv_ma=st_hopdonglaodong.nv_ma
				and ST_LUONG_.l_luongchinh=st_hopdonglaodong.hd_luongcb
				where ST_LUONG_.nv_ma=@NV_MA
				and t_ma=@T_MA

		--        update ST_LUONG set L_DuocTraBH_P = 1
		--		where nv_ma in 
		--		(select nv_ma from st_hopdonglaodong where month(hd_ngayky)=convert(int,left(@t_ma,2)) 
		--		and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>=15)
		--		and nv_ma=@nv_ma and t_ma=@T_MA
		--		and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC

				update ST_LUONG_ set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
				where nv_ma not in 
				(select nv_ma from st_hopdonglaodong where hd_ngayky is not null )
				and nv_ma=@nv_ma and t_ma=@T_MA
				and ST_LUONG_.L_LUONGCHINH=@L_LUONGTRUOC


				update ST_LUONG_ set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
				where nv_ma  in 
				(select nv_ma from st_hopdonglaodong where hd_ngayky is not null AND ( (YEAR(HD_NGAYKY) > RIGHT(T_MA,4)) OR ( YEAR(HD_NGAYKY) = RIGHT(T_MA,4) AND MONTH(HD_NGAYKY) > LEFT(T_MA,2)) ) ) 
				and nv_ma=@nv_ma and t_ma=@T_MA
				and ST_LUONG_.L_LUONGCHINH=@L_LUONGTRUOC


				update ST_LUONG_ set L_DuocTraBH_P = 1
				from ST_LUONG_
				inner join st_hopdonglaodong
				on ST_LUONG_.nv_ma=st_hopdonglaodong.nv_ma
				where t_ma=@t_ma
				and ST_LUONG_.nv_ma=@nv_ma
				and ST_LUONG_.l_luongchinh<st_hopdonglaodong.hd_luongcb
				and ST_LUONG_.L_LUONGCHINH=@L_LUONGTRUOC


				UPDATE ST_LUONG_ SET  L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1,L_DuocTraBH_P = 0
				FROM ST_LUONG_ INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG_.NV_MA = ST_HOPDONGLAODONG.NV_MA
				INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
				where t_ma=@t_ma
				and ST_LUONG_.nv_ma=@nv_ma
				and DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY) >= 12
				and ST_LUONG_.L_LUONGCHINH=@L_LUONGTRUOC

				UPDATE ST_LUONG_
				SET L_TRABH_P = 0
				WHERE DV_MA LIKE '%CG%'
				and nv_ma=@nv_ma and t_ma=@T_MA
				--SELECT @L_CONGKHAC AS CONGTRUOC
			end		
		end-- Của If Ngày giữa Not Null
	else-- Ngày giữa Is Null --Trong tháng không phát sinh DBL-----------------------------------------------------------------------------------
		begin
		-- Tinh gio lam binh thuong  (của ngày giữa is Null)
			-----------------------------------------------------------------------TH:@NgayDau < QT_NGAY  < @NgayCuoi (Không có ngày giữa)--------------------------------------------------------
			-------------------------------------------- Công Hệ Số 1 ( @L_CONGHS1 )
			SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- GIO LE

			if exists(select *  from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
								and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
					select @L_NGHILE=8*count(LE_NGAY) 
					From ST_LE
					Where LE_NGAY>=@NGAYDAU
					and LE_NGAY <=@NgayCuoi
					and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)
					and LE_NGAY > (select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
								and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
			else
					select @L_NGHILE=8*count(LE_NGAY) 
					From ST_LE
					Where LE_NGAY>=@NGAYDAU
					and LE_NGAY <=@NgayCuoi
					and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)



			select  @NgayLeTam=8* count(*)  from ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
			and NV_Ma =@NV_MA
			and (NP_Ma='TS' or  NP_Ma='HS' or  NP_Ma='ST' OR  NP_Ma='KHHGD' OR NP_Ma='CO' OR NP_Ma='OM')
			and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYDAU and LE_NGAY <=@NgayCUOI)
			if @L_NGHILE-@NgayLeTam<0 
              			select @L_NGHILE=0
			else
					   select @L_NGHILE=@L_NGHILE-@NgayLeTam

		
			--------------------------------------------- Công Hệ Số 2 ( @L_CONGHS2 ) 
			--Bình Thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--Tỷ Bách
			----	select @GIOTAY=sum(case when CC_GIOTANGCATAY>=5.5 then 1.5 else CC_GIOTANGCATAY-4 end)
			----From ST_GIOQUETTHE_
			----Where QT_NGAY>=@NGAYDAU
			----	and QT_NGAY <=@NgayCuoi
			----	and NV_MA=@NV_MA	
			----	and CC_GIOTANGCATAY is not null
			----	AND CC_HESONGAYCONG = 1
			----	AND CA_MA='Ca HC'
			----	and CC_GIOTANGCATAY>4
			-------CHINH SUA
	
			--select @GIOTAY =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >4 AND ST_GIOQUETTHE_.CC_GIOTANGCATAY <=5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY -4
			--			WHEN ST_GIOQUETTHE_.CC_GIOTANGCATAY >5.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY>4
			
			--	-----==========chinh sua gio tang ca
			--	SET @GIOTAY_T=0
			--		select @GIOTAY_T=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY >2.5 AND ST_GIOQUETTHE_.CC_GIOTANGCATAY <=3.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY-2.5
			--WHEN ST_GIOQUETTHE_.CC_GIOTANGCATAY>3.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA >0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCATAY>2.5
			--	----==============================
			----select @GIOMAY=sum(case when CC_GIOTANGCA>=5.5 then 1.5 else CC_GIOTANGCA-4 end)
			----From ST_GIOQUETTHE_
			----Where QT_NGAY>=@NGAYDAU
			----	and QT_NGAY <=@NgayCuoi
			----	and NV_MA=@NV_MA
			----	AND CC_GIOTANGCATAY IS NULL
			----	and CC_GIOTANGCA is not null
			----	AND CC_HESONGAYCONG = 1
			----	AND CA_MA='Ca HC'
			----	and CC_GIOTANGCA>4
		
			-------CHINH SUA
	
			--select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >4 AND ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-4
			--			WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>5.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA =0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA>4
			
			--	-----==========chinh sua gio tang ca
			--	SET @GIOMAY_T=0
			--		select @GIOMAY_T=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >2.5 AND ST_GIOQUETTHE_.CC_GIOTANGCA<=3.5 THEN ST_GIOQUETTHE_.CC_GIOTANGCA-2.5
			--WHEN ST_GIOQUETTHE_.CC_GIOTANGCA>3.5 THEN 1.5 ELSE 0 END)
			--From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			--AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			--Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
			--	and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
			--	and ST_GIOQUETTHE_.NV_MA=@NV_MA
			--	and ST_GIOQUETTHE.CC_GIOTANGCA >0
			--	AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
			--	AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
			--	AND ST_GIOQUETTHE_.CA_MA='Ca HC'
			--	and ST_GIOQUETTHE_.CC_GIOTANGCA>2.5
			--	----==============================
			
			--SELECT @L_CONGHS2B=ISNULL(@GIOTAY,0)+ISNULL(@GIOTAY_T,0) + ISNULL(@GIOMAY,0)+ISNULL(@GIOMAY_T,0)
		
			--select @L_CONGHS2=@L_CONGHS2A+@L_CONGHS2B
			-----------------------------------------------

			--Andrew
			select @GIOTAY=sum(case when CC_GIOBINHTHUONGTAY>13.5 then 13.5 else CC_GIOBINHTHUONGTAY end )
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(case when CC_GIOBINHTHUONG>=13.5 then 13.5 else CC_GIOBINHTHUONG end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			select @GIOTAY=sum(case when CC_GIOBINHTHUONGTAY>13.5 then CC_GIOBINHTHUONGTAY-13.5 else 0 end )
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(case when CC_GIOBINHTHUONG>=13.5 then CC_GIOBINHTHUONG-13.5 else 0 end)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
				
			select @L_CONGHS27=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
	
			select @GIOTAY =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >5.5  THEN ST_GIOQUETTHE_.CC_GIOTANGCATAY -5.5
						ELSE 0 END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>5.5

			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5  THEN ST_GIOQUETTHE_.CC_GIOTANGCA-5.5
						 ELSE 0 END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCA =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCA>5.5	
					
			SELECT @L_CONGHS21=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			----------------------------------------

			-------------------------------------------- Công Hệ Số 3 ( @L_CONGHS3 )
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 3		
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONG is not null
		
			SELECT @L_CONGHS3=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			select @GIOTAY=sum(CC_GIOTANGCATAY-4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA>4
			select @GIOMAY=sum(CC_GIOTANGCA-4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA>4
			SELECT @L_CONGHS3B = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			select @GIOTAY =sum(case when ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)>=5.5 
			then ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)-5.5 else 0 end)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA	
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCATAY,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCATAY,0)>4

			--select @GIOTAY=sum(case when CC_GIOTANGCATAY>=5.5 then CC_GIOTANGCATAY-5.5 else 0 end)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY>4
			
			select @GIOMAY=sum(case when ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)>=5.5 
			then ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)-5.5 else 0 end)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA	
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ISNULL(ST_GIOQUETTHE_.CC_GIOTANGCA,0)+ISNULL(ST_GIOQUETTHE.CC_GIOTANGCA,0)>4	
			--select @GIOMAY=sum(case when CC_GIOTANGCA>=5.5 then CC_GIOTANGCA-5.5 else 0 end)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA>4
			
			SELECT @L_CONGHS2C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			SELECT @L_CONGHS3A= @L_CONGHS3 + @L_CONGHS3B + @L_CONGHS2C
			-- TANG CA HE SO >1 and <4
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG > 1
				AND CC_HESONGAYCONG < 4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG > 1
				AND CC_HESONGAYCONG < 4
			SELECT @L_TCAHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--Tinh cong theo phu cap trach nhiem
			SELECT @L_CONGHS2A=@L_CONGHS2A+@L_CONGHS3+ @L_TCAHS2
			SELECT @L_CONGHS3=@L_CONGHS3+@L_TCAHS2

			-- TANG CA HE SO 15
		
			--select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY<=4
			--	and CA_MA<>'Ca 3'
		--====================CHINH SUA
				SET @GIOTAY =0
				select @GIOTAY = ISNULL(SUM (ST_GIOQUETTHE_.CC_GIOTANGCATAY),0)	
				From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
				AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
				Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				----and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=4 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=5.5 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCATAY=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
				select @GIOTAY=@GIOTAY+ ISNULL(SUM(ST_GIOQUETTHE_.CC_GIOTANGCATAY),0)
				From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
				AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
				Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=2.5 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY<=5.5
				and ST_GIOQUETTHE.CC_GIOTANGCATAY>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			--select @GIOMAY=sum(CC_GIOTANGCA)
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA<=4
			--	and CA_MA<>'Ca 3'
				--====================CHINH SUA
				SET @GIOMAY=0
				select @GIOMAY= ISNULL(SUM (ST_GIOQUETTHE_.CC_GIOTANGCA),0)	
				From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
				AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
				Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCA<= --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5--Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCA=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOMAY=@GIOMAY+ ISNULL(SUM(ST_GIOQUETTHE_.CC_GIOTANGCA),0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				--and ST_GIOQUETTHE_.CC_GIOTANGCA<=2.5 --Tỷ Bách
				and ST_GIOQUETTHE_.CC_GIOTANGCA<=5.5 --Andrew
				and ST_GIOQUETTHE.CC_GIOTANGCA>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		

			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCATAY>4
			--	and CA_MA<>'Ca 3'

			--====================CHINH SUA
			SET @GIOTAYB =0
		
			select  @GIOTAYB = ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCATAY ) *4,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>4
				and ST_GIOQUETTHE.CC_GIOTANGCATAY=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOTAYB =@GIOTAYB + ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCATAY) *2.5,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY >2.5
				and ST_GIOQUETTHE.CC_GIOTANGCATAY >0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			--select @GIOMAY=count(CC_GIOTANGCA) *4
			--From ST_GIOQUETTHE_
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	and CC_GIOTANGCA>4
			--	and CA_MA<>'Ca 3'
		
			--====================CHINH SUA
			SET @GIOMAYB =0
				select  @GIOMAYB = ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCA) *4,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCA>4
				and ST_GIOQUETTHE.CC_GIOTANGCA=0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			
			select @GIOMAYB =@GIOMAYB + ISNULL(count(ST_GIOQUETTHE_.CC_GIOTANGCA) *2.5,0)
			From  ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA 
			AND ST_GIOQUETTHE_.QT_NGAY = ST_GIOQUETTHE.QT_NGAY 
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				and ST_GIOQUETTHE_.CC_GIOTANGCA>2.5
				and ST_GIOQUETTHE.CC_GIOTANGCA>0
				and ST_GIOQUETTHE_.CA_MA<>'Ca 3'
			---==============================
			SELECT @L_CONGHS15B=ISNULL(@GIOTAYB ,0) + ISNULL(@GIOMAYB,0)
			-- SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B -- Tỷ Bách

			--Andrew
			select @GIOTAY =sum(case when ST_GIOQUETTHE_.CC_GIOTANGCATAY  >5.5  THEN 5.5
					ELSE ST_GIOQUETTHE_.CC_GIOTANGCATAY END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCATAY =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NOT NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 2'  OR ST_GIOQUETTHE_.CA_MA ='Ca 3'  OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCATAY>0
			
	
			select @GIOMAY=sum(case when ST_GIOQUETTHE_.CC_GIOTANGCA >5.5  THEN 5.5
						 ELSE ST_GIOQUETTHE_.CC_GIOTANGCA END)
			From ST_GIOQUETTHE_ INNER JOIN ST_GIOQUETTHE ON ST_GIOQUETTHE_.NV_MA = ST_GIOQUETTHE.NV_MA
			AND ST_GIOQUETTHE_.QT_NGAY  = ST_GIOQUETTHE.QT_NGAY
			Where ST_GIOQUETTHE_.QT_NGAY>=@NGAYDAU
				and ST_GIOQUETTHE_.QT_NGAY <=@NgayCuoi
				and ST_GIOQUETTHE_.NV_MA=@NV_MA
				and ST_GIOQUETTHE.CC_GIOTANGCA =0
				AND ST_GIOQUETTHE_.CC_GIOTANGCATAY IS NULL
				and ST_GIOQUETTHE_.CC_GIOTANGCA is not null
				AND ST_GIOQUETTHE_.CC_HESONGAYCONG = 1
				AND (ST_GIOQUETTHE_.CA_MA='Ca HC' OR ST_GIOQUETTHE_.CA_MA ='Ca01' OR ST_GIOQUETTHE_.CA_MA ='Ca02' OR ST_GIOQUETTHE_.CA_MA ='Ca03' OR ST_GIOQUETTHE_.CA_MA ='Ca 2' OR ST_GIOQUETTHE_.CA_MA ='Ca 3'OR ST_GIOQUETTHE_.CA_MA ='Ca 6' OR ST_GIOQUETTHE_.CA_MA ='Ca 7')--Andrew
				and ST_GIOQUETTHE_.CC_GIOTANGCA>0		
			
			SELECT @L_CONGHS15=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Lam dem
			select @GIOTAY=sum(CC_GIOLAMDEMTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOLAMDEMTAY is not null
			select @GIOMAY=sum(CC_GIOLAMDEM)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOLAMDEMTAY IS NULL
				and CC_GIOLAMDEM is not null
			SELECT @L_LAMDEM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
	-- Ca dem
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOBINHTHUONGTAY IS NULL
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS4=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tang Ca dem
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA<=4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA<=4
			SELECT @L_CONGTCAHS4A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			select @GIOTAY=sum(4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				and CC_GIOTANGCATAY is not null
				and CC_GIOTANGCA>4
			select @GIOMAY=sum(4)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND (CC_HESONGAYCONG = 4 or CA_MA='Ca 3')
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				and CC_GIOTANGCA>4
			SELECT @L_CONGTCAHS4B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGTCAHS4=@L_CONGTCAHS4A+@L_CONGTCAHS4B
		

			--select @L_LAMDEM=@L_LAMDEM+@L_CONGHS4
			-- Ngung viec
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='NV' or NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='NV' or NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGUNGVIEC=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi P
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi R
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0) 

			-- Nghi RO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIRO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi DQ
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIDQ=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi OM
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIOM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi ST
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIST=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi TS
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi HS
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIHS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi KTHAI
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIKHAMTHAI=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi NO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='NO' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='NO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi O
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='O' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='O')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		-- Nghi TNLD
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='TNLD' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='TNLD')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITNLD=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			 -- Nghi Ds
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIDS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi KHHGD
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='KHHGD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA= 'KHHGD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			SELECT @GIOKHHGD =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tam ung
			select @L_TAMUNG=TU_SOTIEN from ST_TAMUNG where NV_MA=@NV_MA and T_MA=@T_MA
					
			--- Dong BHXH,BHYT
			select @L_BHXH=HD_DongBHXH,@L_BHYT=HD_DongBHYT 
			from  ST_Hopdonglaodong inner join st_nhanvien on st_nhanvien.nv_ma=ST_Hopdonglaodong.nv_ma
			where ST_Hopdonglaodong.NV_Ma=@NV_MA 
			and 
			(
			convert(int,substring(bl_ma,5,2))> 1
			or
			(convert(char(7),HD_NGAYKY,21) = right(@t_ma,4) +'-' + left(@T_MA,2) and day(HD_NGAYKY)<=15 and convert(int,substring(bl_ma,5,2))=1)
			or  
			( convert(int,substring(bl_ma,5,2))<=1 and convert(char(7),HD_NGAYKY,21) < right(@t_ma,4) +'-' + left(@T_MA,2) )
			 or  datediff(m,nv_ngayvao,HD_NGAYKY)>12)
				 
			-- SUATAN
			select @L_SOPHANCOM=sum(CC_SUATAN)
			From ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_SUATAN is not null
			--- Tinh lai nga le tet neu truong hop co nghi thai san
					--if @L_NGHIHS>=@L_NGHILE 
					--	select @L_NGHILE=0
					--else
					--	select @L_NGHILE=@L_NGHILE-@L_NGHIHS

			--		if @L_NGHITS>=@L_NGHILE 
			--			select @L_NGHILE=0
			--		else
			--			select @L_NGHILE=@L_NGHILE-@L_NGHITS


			--- Tinh phu cap
			select @L_PCTRNTRUOC=@L_PHUCAPTRUOC
			--- Tinh chuyen can_,moi truong 
			select @SOLANQUENQUETTHE=sum(CC_QUENQUETTHE) , @SOLANDITRE=sum(CC_DITRE) from  ST_GIOQUETTHE_
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_Hesongaycong =1
			select @L_PCMTruong=round((@L_CONGHS1+(@L_CONGHS2/8))*1800,0)

			if @L_NGHIRO+@L_NGHIOM+@L_NGHITS+@L_NGHINO+@L_NGHIO+@L_NGHIR+@L_NGHIP+@L_NGHIDS=0 
				select @Chuyencan=  40000
			else
			begin	
		   		 if @L_NGHIOM=0 
		      			 if @L_NGHIRO+ @L_NGHIOM <=8 
							   select @Chuyencan= 20000-(@L_NGHITS+@L_NGHINO+@L_NGHIR+@L_NGHIP+@L_NGHIDS)/8*1500
					 else
				            		select @Chuyencan=  0
				else
		      			select @Chuyencan=  0
			end
			if @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)<0 
	    			select @L_PCCCAN=0
			else
				select @L_PCCCAN=   @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)
			--begin ----- Ngay le di lam thi gio nghi le=0-----------
			if @L_CONGHS3A <>0
				select @L_NGHILE =0 
			---end ------------------------
			if @L_NGHILE-@L_CONGHS3A<0 
				select @L_NGHILE =0 
			else
				select @L_NGHILE =@L_NGHILE-@L_CONGHS3A
			--Tinh L_TraBH_P
			select @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4)+@L_LAMDEM+@L_NGHIR+@L_NGHILE+@L_NGHIP+@L_NGHINO)/8)*0.25*isnull(@L_LUONGTRUOC,0)/26


	if (isnull(@L_LUONGTRUOC,0)>0)
	begin
			insert into ST_LUONG_(NV_MA,T_MA,L_LUONGCHINH,L_PHUCAPKHAC,L_PCTRACHNHIEM,L_PCCHUYENCAN,L_PCMOITRUONG,L_PHUCAPDH
				,DV_MA,L_LOAI
				,L_CONGHS1,L_CONGHS2,L_CONGHS2A,L_CONGHS3,L_CONGHS15,L_CONGHS21,L_CONGHS27,L_CONGCADEM,L_CONGTCADEM,L_LAMDEM
				,L_NGUNGVIEC, L_NGHIDQ,L_NGHILE,L_NGHIP,L_NGHIR,L_NGHIRO,L_NGHIOM, L_NGHIST,L_NGHITS,L_NGHIKHAMTHAI,L_NGHIDS,L_NGHIKHHGD,L_NGHIO,L_NGHINO,L_NGHITNLD
				,L_TAMUNG,L_BHXH,L_BHYT,L_SOPHANCOM,L_SOLANDITRE,L_SOLANQUENQT,L_CONGKHAC,L_TRUKHAC,L_TraBH_P,L_TIENNUOICON6T) 
			values(@NV_MA,@T_MA,isnull(@L_LUONGTRUOC,0),@L_PHUCAPKHAC,@L_PCTRNTRUOC,@L_PCCCAN,@L_PCMTruong,@L_PHUCAPDH
				,@DV_MA,@LOAILUONG
				,@L_CONGHS1,@L_CONGHS2,@L_CONGHS2A,@L_CONGHS3A,@L_CONGHS15,@L_CONGHS21,@L_CONGHS27,@L_CONGHS4,@L_CONGTCAHS4,@L_LAMDEM
				,@L_NGUNGVIEC, @L_NGHIDQ,@L_NGHILE,@L_NGHIP,@L_NGHIR,@L_NGHIRO,@L_NGHIOM, @L_NGHIST,@L_NGHITS,@L_NGHIKHAMTHAI,@L_NGHIDS,@GIOKHHGD,@L_NGHIO,@L_NGUNGVIEC,@L_NGHITNLD
				,@L_TAMUNG,@L_BHXH,@L_BHYT,@L_SOPHANCOM,@SOLANDITRE,@SOLANQUENQUETTHE,@L_CONGKHAC,@L_TRUKHAC,@L_TraBH_P,@L_TIENNUOICON6T) 
			Delete From ST_LUONG_ Where NV_Ma=@NV_MA AND T_MA=@T_MA AND L_LUONGCHINH=0
			--Cap nhat trang thai huong luong ky hop dong
		


			update ST_LUONG_ set L_HUONGLUONGKHD = 1, L_HUONGCHUYENCAN = 1
			where nv_ma  in 
			(select nv_ma from st_hopdonglaodong where month(hd_ngayky)!=convert(int,left(@t_ma,2))
			 or year(hd_ngayky)!=convert(int,right(@t_ma,4))) and nv_ma=@nv_ma and t_ma=@T_MA

			update ST_LUONG_ 
			set  L_HUONGCHUYENCAN = 1
			WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)
			AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)
			AND ST_LUONG_.nv_ma=@NV_MA and t_ma=@T_MA

			Update ST_LUONG_ Set L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1
			from ST_LUONG_
			inner join st_hopdonglaodong 
			on ST_LUONG_.nv_ma=st_hopdonglaodong.nv_ma
			and ST_LUONG_.l_luongchinh=st_hopdonglaodong.hd_luongcb
			where ST_LUONG_.nv_ma=@NV_MA
			and t_ma=@T_MA

			update ST_LUONG_ set L_DuocTraBH_P = 1
			where nv_ma in 
			(select nv_ma from st_hopdonglaodong where month(hd_ngayky)=convert(int,left(@t_ma,2)) 
			and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>15) and nv_ma=@nv_ma and t_ma=@T_MA

			update ST_LUONG_ set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
			where nv_ma not in 
			(select nv_ma from st_hopdonglaodong where hd_ngayky is not null )
			and nv_ma=@nv_ma and t_ma=@T_MA


			update ST_LUONG_ set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
			where nv_ma  in 
			(select nv_ma from st_hopdonglaodong where hd_ngayky is not null AND ( (YEAR(HD_NGAYKY) > RIGHT(T_MA,4)) OR ( YEAR(HD_NGAYKY) = RIGHT(T_MA,4) AND MONTH(HD_NGAYKY) > LEFT(T_MA,2)) ) ) 
			and nv_ma=@nv_ma and t_ma=@T_MA

			Update ST_LUONG_ set L_DuocTraBH_P = 1
			from ST_LUONG_
			inner join st_hopdonglaodong
			on ST_LUONG_.nv_ma=st_hopdonglaodong.nv_ma
			where t_ma=@t_ma
			and ST_LUONG_.nv_ma=@nv_ma
			and ST_LUONG_.l_luongchinh<st_hopdonglaodong.hd_luongcb

			UPDATE ST_LUONG_ SET  L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1,L_DuocTraBH_P = 0
			FROM ST_LUONG_ INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG_.NV_MA = ST_HOPDONGLAODONG.NV_MA
			INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
			where t_ma=@t_ma
			and ST_LUONG_.nv_ma=@nv_ma
			and DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY) >= 12

			UPDATE ST_LUONG_
			SET L_TRABH_P = 0
			WHERE DV_MA LIKE '%CG%'
			and nv_ma=@nv_ma and t_ma=@T_MA


			END

		END-- Của If Ngày giữa Is Null
-------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------Tính toán Dựa trên Ngày Giữa (End)-------------------------------------------------------------


----dua du lieu vao bang IT_BANGLUONGMOI ,cac cong thuc trong bao bao phai cai theo dung thu tu
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	--xoa du lieu trong bang IT_BANGLUONGMOI
	DELETE FROM IT_BANGLUONGMOI_ 
	WHERE SOTHE = @NV_MA and T_MA=@T_MA

--\\\\\CONG VIEC VA TINH TRANG CONG VIEC
		IF EXISTS (SELECT * FROM IT_CHUYENCONGVIEC WHERE NV_MA=@NV_MA)
			IF EXISTS (SELECT * FROM IT_CHUYENCONGVIEC WHERE NV_MA=@NV_MA AND MONTH(NGAY)=CONVERT (INT,(LEFT(@T_MA,2))) AND YEAR(NGAY)=CONVERT (INT,(RIGHT(@T_MA,4)))    )
				SELECT @M_CONGVIEC = CCV_CVMOI FROM IT_CHUYENCONGVIEC WHERE NV_MA=@NV_MA 
						AND MONTH(NGAY)=CONVERT (INT,(LEFT(@T_MA,2))) AND YEAR(NGAY)=CONVERT (INT,(RIGHT(@T_MA,4)))
																	  
			ELSE
				SELECT @M_CONGVIEC = CCV_CVMOI FROM IT_CHUYENCONGVIEC WHERE NV_MA=@NV_MA AND NGAY = (SELECT MAX(NGAY) FROM IT_CHUYENCONGVIEC WHERE NV_MA=@NV_MA)
		ELSE 
			SELECT @M_CONGVIEC = CV_MA FROM ST_NHANVIEN WHERE NV_MA=@NV_MA

	--TINH TRANG
	SELECT @M_TTCV =  TTCV FROM ST_CONGVIEC WHERE CV_MA=@M_CONGVIEC
--\\\\\\\\\\
	--lay so dong luong chinh trong bang ST_LUONG_
	DECLARE CUR_LUONGCHINH
	CURSOR FOR SELECT DISTINCT L_LUONGCHINH FROM ST_LUONG_
	WHERE NV_MA=@NV_MA and T_MA=@T_MA

	OPEN CUR_LUONGCHINH

	FETCH NEXT FROM CUR_LUONGCHINH
	INTO @LUONG_TU_ST_LUONG
	--@M_DV_MA nvarchar(50)
	SELECT @M_DV_MA = DV_MA
	FROM ST_LUONG_
	WHERE  NV_MA=@NV_MA and T_MA=@T_MA
	--@M_X_MA nvarchar(50)
	SELECT @M_X_MA = X_MA_
	FROM ST_DONVI 
	WHERE  DV_MA=@M_DV_MA 
	--@M_DV_TEN  nvarchar(50) 
	SELECT @M_DV_TEN = B.DV_TEN
	FROM ST_LUONG_ AS A INNER JOIN ST_DONVI AS B ON A.DV_MA=B.DV_MA
	WHERE  A.NV_MA=@NV_MA AND T_MA=@T_MA

	--@M_NAM nvarchar(4)
	SELECT @M_NAM = RIGHT(@T_MA,4)

	--@M_THANG nvarchar(2)
	SELECT @M_THANG = LEFT(@T_MA,2)

	--@M_TUNGAY datetime
	SELECT @M_TUNGAY = T_TUNGAY
	FROM ST_THANG
	WHERE T_MA = @T_MA

	--@M_DENNGAY  datetime
	SELECT @M_DENNGAY = T_DENNGAY
	FROM ST_THANG
	WHERE T_MA = @T_MA

	--@M_HOTEN nvarchar(50)
	SELECT @M_HOTEN = NV_TEN
	FROM ST_NHANVIEN
	WHERE NV_MA = @NV_MA

	--@M_SOTHE nvarchar(50)
	SELECT @M_SOTHE = @NV_MA

	--@M_T_MA nvarchar(50)
	SELECT @M_T_MA = @T_MA

	--@M_MASOTHUE nvarchar(50)
	SELECT @M_MASOTHUE = MASOTHUE
	FROM ST_NHANVIEN
	WHERE NV_MA = @NV_MA

	--@M_SOTAIKHOAN nvarchar(50)
	SELECT @M_SOTAIKHOAN = SOTAIKHOAN
	FROM ST_NHANVIEN
	WHERE NV_MA = @NV_MA

	--@NV_NGAYVAO datetime
	SELECT @NV_NGAYVAO = NV_NGAYVAO
	FROM ST_NHANVIEN
	WHERE NV_MA = @NV_MA

	--@T_TUNGAY datetime
	SELECT @T_TUNGAY = T_TUNGAY
	FROM ST_THANG
	WHERE  T_MA = @T_MA

	--@GIOO_TH int
	SELECT @GIOO_TH = ROUND(ISNULL(L_NGHIO,0),1)
	FROM ST_LUONG_
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	--	@GIORO_TH int
	SELECT @GIORO_TH = ROUND(ISNULL(L_NGHIRO,0),1)
	FROM ST_LUONG_
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOOM_TH int
	SELECT @GIOO_TH = ROUND(ISNULL(L_NGHIO,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--	@GIORO_TH int
	SELECT @GIORO_TH = ROUND(ISNULL(L_NGHIRO,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOOM_TH int
	SELECT @GIOOM_TH = ROUND(ISNULL(L_NGHIOM,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOST_TH int
	SELECT @GIOST_TH = ROUND(ISNULL(L_NGHIST,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@CONGTT_TH int
	SELECT @CONGTT_TH = ROUND(ISNULL(L_CONGHS1,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	--@CONGCADEM_TH int
	SELECT @CONGCADEM_TH = ROUND(ISNULL(L_CONGCADEM,0)/8,1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@SONGAYCONG_TH int
	SET @SONGAYCONG_TH = (@CONGTT_TH + @CONGCADEM_TH)/8


	IF EXISTS(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
	SET @SONGAYCONG_TH = 0

	

	--@GIODS_TH int
	SELECT @GIODS_TH = ROUND(ISNULL(L_NGHIDS,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@DITRE_TH int
	SELECT @DITRE_TH = ISNULL(L_SOLANDITRE,0)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@QUENQT_TH int
	SELECT @QUENQT_TH = ISNULL(L_SOLANQUENQT,0)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOTS_TH int
	SELECT @GIOTS_TH = ROUND(ISNULL(L_NGHITS,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOLE_TH int
	SELECT @GIOLE_TH = ROUND(ISNULL(L_NGHILE,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOKTHAI_TH int
	SELECT @GIOKTHAI_TH = ROUND(ISNULL(L_NGHIKHAMTHAI,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA


	--@GIOTSKT_TH int
	SET @GIOTSKT_TH = @GIOTS_TH + @GIOKTHAI_TH

	--@SONGAY_TH int
	SELECT @SONGAY_TH = ISNULL(T_SONGAYCONG,0)
	FROM ST_THANG
	WHERE T_MA = @T_MA
	
	--@GIOP_TH int
	SELECT @GIOP_TH = ROUND(ISNULL(L_NGHIP,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOR_TH int
	SELECT @GIOR_TH = ROUND(ISNULL(L_NGHIR,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIONO_TH int
	SELECT @GIONO_TH = ROUND(ISNULL(L_NGHINO,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOTNLD_TH int
	SELECT @GIOTNLD_TH = ROUND(ISNULL(L_NGHITNLD,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIODQ_TH int
	SELECT @GIODQ_TH = ROUND(ISNULL(L_NGHIDQ,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	--@GIOKHHGD_TH INT
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE_
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYCUOI
			and NV_MA=@NV_MA	
			and (NP_MA='KHHGD')
			and CC_GIOBINHTHUONGTAY is not null
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE_
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYCUOI
			and NV_MA=@NV_MA
			and (NP_MA='KHHGD')
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null

		SELECT @GIOKHHGD_TH = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)


	--@CHUYENCANDUOCHUONG_TH FLOAT
	IF ( @GIOO_TH <> 0 ) 
        SET @CHUYENCANDUOCHUONG_TH = 0
    ELSE
    IF ( @SONGAYCONG_TH  + @GIOLE_TH / 8 + @GIOP_TH /8 >= @SONGAY_TH )  
        SET @CHUYENCANDUOCHUONG_TH = 260000
    ELSE
        IF (@GIOO_TH = 0) 
            IF (@GIORO_TH + @GIOOM_TH + @GIOST_TH =0) 
                SET @CHUYENCANDUOCHUONG_TH = 260000
            ELSE IF ( @GIORO_TH + @GIOOM_TH + @GIOST_TH<=8 ) 
                 SET @CHUYENCANDUOCHUONG_TH = 170000
            ELSE IF (@GIORO_TH + @GIOOM_TH + @GIOST_TH > 8 AND @GIORO_TH+@GIOOM_TH+@GIOST_TH<=16 ) 
                 SET @CHUYENCANDUOCHUONG_TH = 90000
            ELSE IF (@GIORO_TH+@GIOOM_TH+@GIOST_TH>16)
                SET @CHUYENCANDUOCHUONG_TH = 0
        ELSE
            SET @CHUYENCANDUOCHUONG_TH = 0

	IF exists(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
	SET @CHUYENCANDUOCHUONG_TH = 0

	--	@TRABH_P_TH FLOAT ******************************88
	--	SELECT @TRABH_P_TH  = ROUND(ISNULL(L_TraBH_P,0),0)
	--	FROM v_BangluongTH
	--	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
		--****************************************************8
		--******************************************************8
		--******************************************************8888
	--	select @TRABH_P_TH  = ROUND(ISNULL(L_TraBH_P,0),0)
	--	from ST_LUONG_ where nv_ma=@nv_ma and t_ma=@t_ma and l_luongchinh=@LUONG_TU_ST_LUONG
	--
	--	IF exists(SELECT * FROM  ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND ( NV_MA = '00100' OR L_HUONGLUONGKHD = 1 OR ISNULL(L_DuocTraBH_P,0) = 0) )
	--	SET @TRABH_P_TH = 0


WHILE (@@FETCH_STATUS = 0)
	BEGIN

		--@PCCHUYENCAN FLOAT
		IF ( @NV_NGAYVAO > @T_TUNGAY )  
            IF ( @GIOO_TH <> 0 ) 
                SET @PCCHUYENCAN = 0
            ELSE  
                    IF  (@GIORO_TH + @GIOOM_TH + @GIOST_TH = 0) 
                         IF ((( @SONGAYCONG_TH  +( @GIODS_TH /8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 +  @GIODS_TH /8*10000 ))<0 )
                            SET @PCCHUYENCAN = 0
                         ELSE
                            SET @PCCHUYENCAN = round((( @SONGAYCONG_TH  +( @GIODS_TH /8))*(260000/26))-(( @DITRE_TH *10000 +  @QUENQT_TH *10000 +  @GIODS_TH /8*10000 )),-3)
                    
                   ELSE IF ( @GIORO_TH + @GIOOM_TH + @GIOST_TH  <= 8 ) 
                         IF ((( @SONGAYCONG_TH +(( @GIORO_TH + @GIOOM_TH + @GIOST_TH + @GIODs_TH )/8))*(260000/26))-(( @DITRE_TH *10000 +  @QUENQT_TH *10000 + 90000  +  @GIODS_TH /8*10000 ))< 0) 
                            SET @PCCHUYENCAN = 0
                         ELSE
                            SET @PCCHUYENCAN = round((( @SONGAYCONG_TH  +(( @GIORO_TH + @GIOOM_TH + @GIOST_TH + @GIODS_TH )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 90000 + @GIODS_TH /8*10000 )),-3)
                 
                    ELSE IF ( @GIORO_TH + @GIOOM_TH + @GIOST_TH >8 and  @GIORO_TH + @GIOOM_TH + @GIOST_TH <=16) 
                         IF ((( @SONGAYCONG_TH  +(( @GIORO_TH + @GIOOM_TH + @GIOST_TH + @GIODs_TH )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 170000  + @GIODS_TH /8*10000 ))<0 )
                            SET @PCCHUYENCAN = 0
                         ELSE
                            SET @PCCHUYENCAN = round((( @SONGAYCONG_TH +(( @GIORO_TH + @GIOOM_TH + @GIOST_TH + @GIODS_TH )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 170000  + @GIODS_TH /8*10000 )),-3)
                    ELSE  
                        SET @PCCHUYENCAN = 0 
    ELSE IF  (@GIOTSKT_TH <> 0) 
        IF  (@CHUYENCANDUOCHUONG_TH -(  @GIOTS_TH /8*(260000/26) + @GioST_TH/8*(260000/26)+  @DITRE_TH *10000+ @QUENQT_TH *10000+( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH + @GIOTNLD_TH + @GIODQ_TH + @GIOKHHGD_TH )/8*5000 + @GIODS_TH /8*10000)<0 )
          SET @PCCHUYENCAN = 0
        ELSE
           SET @PCCHUYENCAN = round( @CHUYENCANDUOCHUONG_TH -(  @GIOTS_TH /8*(260000/26) + @GioST_TH/8*(260000/26)+ @DITRE_TH *10000+ @QUENQT_TH *10000+(( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH + @GIOTNLD_TH  + @GIODQ_TH + @GIOKHHGD_TH)/8*5000 + @GIODS_TH /8*10000)),0)
    ELSE
        IF ( @CHUYENCANDUOCHUONG_TH -( @DITRE_TH *10000+ @QUENQT_TH *10000+( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH + @GIOTNLD_TH  + @GIODQ_TH + @GIOKHHGD_TH )/8*5000 + @GIODS_TH /8*10000)<0 )
          SET @PCCHUYENCAN = 0
       ELSE
    SET @PCCHUYENCAN = round( @CHUYENCANDUOCHUONG_TH -( @DITRE_TH *10000+ @QUENQT_TH *10000+(( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH + @GIOTNLD_TH  + @GIODQ_TH + @GIOKHHGD_TH )/8*5000 + @GIODS_TH /8*10000)),0)


	IF exists(SELECT  * FROM ST_LUONG_ WHERE ISNULL(L_HUONGCHUYENCAN,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG)
	SET @PCCHUYENCAN  = 0

	IF exists(SELECT  * FROM ST_NHANVIENKHONGPHUCAP WHERE NV_PCCHUYENCAN = 1 AND NV_MA = @NV_MA )
	SET @PCCHUYENCAN  = 0
	

	IF exists(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
	SET @PCCHUYENCAN  = 0


	--@M_CHUYENCAN  float
	SET @M_CHUYENCAN = @PCCHUYENCAN

		--@CONGTT int
		SELECT @CONGTT = ROUND(ISNULL(ST_LUONG_.L_CONGHS1,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
		--@CONGCADEM int 
		SELECT @CONGCADEM = ROUND(ISNULL(ST_LUONG_.L_CONGCADEM,0)/8,1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@SONGAYCONG int
		SELECT @SONGAYCONG = (@CONGTT +@CONGCADEM) /8

		SELECT @SONGAYCONG = 0
		FROM ST_NHANVIEN
		WHERE NV_MA = @NV_MA AND DV_MA = 'KB'

	

		--@GIOP int
		SELECT @GIOP = ROUND(ISNULL(ST_LUONG_.L_NGHIP,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@LUONGCHINH float
		
	
		SELECT @LUONGCHINH = ROUND(ISNULL(L_LUONGCHINH,0),-2)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		IF EXISTS(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
		SET @LUONGCHINH = 0

		--@M_LUONGCHINH float
		SET @M_LUONGCHINH = @LUONGCHINH

		--@HS2A int
		SELECT @HS2A = ROUND(ISNULL(ST_LUONG_.L_CONGHS2A,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@GIOR int
		SELECT @GIOR = ROUND(ISNULL(ST_LUONG_.L_NGHIR,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@GIOLE int
		SELECT @GIOLE = ROUND(ISNULL(ST_LUONG_.L_NGHILE,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@GIONV int
		SELECT @GIONV = ROUND(ISNULL(ST_LUONG_.L_NGUNGVIEC,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@GIONV FLOAT,
		SELECT @GIONO = ROUND(ISNULL(ST_LUONG_.L_NGHINO,0),1)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG	
		
		--@PCTRACHNHIEM FLOAT
		IF @SONGAYBT >= 26 
		
			SELECT @PCTRACHNHIEM = ROUND( ISNULL(ST_LUONG_.L_PCTRACHNHIEM,0)/26 *( @SONGAYCONG  + @HS2A/8 + (@GIOP + @GIOR + @GIOLE + @GioNV )/8)  ,0)
			FROM ST_LUONG_ 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
	    ELSE
	        SELECT @PCTRACHNHIEM = ROUND( ISNULL(ST_LUONG_.L_PCTRACHNHIEM,0)/@SONGAYBT *( @SONGAYCONG  + @HS2A/8 + (@GIOP + @GIOR + @GIOLE + @GioNV )/8)  ,0)
			FROM ST_LUONG_ 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		SELECT @PCTRACHNHIEM = 0
		FROM ST_LUONG_ AS A INNER JOIN ST_NHANVIENKHONGPHUCAP AS B ON A.NV_MA = B.NV_MA
		WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		AND ( 
		A.L_PCTRACHNHIEM IS NULL 
			OR 
		B.NV_PCTRACHNHIEM = 1  
			)

		--@M_CMON_CVIEC FLOAT
		SET @M_CMON_CVIEC = @PCTRACHNHIEM

		--@TIENPHUCAPKHAC FLOAT
		SELECT @TIENPHUCAPKHAC = ISNULL(L_PHUCAPKHAC,0)
		FROM ST_LUONG_ 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--PCKHAC_LONHON100 FLOAT
		SET @PCKHAC_LONHON100 = @TIENPHUCAPKHAC
		
		IF @PCKHAC_LONHON100>=300000 
		     IF @SONGAYBT >= 26
		     		SELECT @PCKHAC_LONHON100 = ROUND( @TIENPHUCAPKHAC /26 *( @SONGAYCONG +  @HS2A / 8 + ( @GIOP + @GIOR + @GIOLE +@GIONO ) / 8 ),0)
		     ELSE
		           SELECT @PCKHAC_LONHON100 = ROUND( @TIENPHUCAPKHAC /@SONGAYBT *( @SONGAYCONG +  @HS2A / 8 + ( @GIOP + @GIOR + @GIOLE +@GIONO ) / 8 ),0)
		     		
--			FROM ST_NHANVIEN
--			WHERE NV_MA = @NV_MA 
--			AND (CV_MA = 'PD' OR CV_MA = 'TPho' OR  CV_MA ='TT' OR CV_MA ='TB' OR CV_MA ='TN' OR CV_MA ='PN' )
		ELSE 
			SET @PCKHAC_LONHON100 = @TIENPHUCAPKHAC

		SELECT @PCKHAC_LONHON100 = 0
		FROM ST_LUONG AS A INNER JOIN ST_NHANVIENKHONGPHUCAP AS B ON A.NV_MA = B.NV_MA
		WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		AND ( A.L_PHUCAPKHAC IS NULL OR B.NV_PCKHAC = 1  )

		--@M_UUDAI float
		SET @M_UUDAI = @PCKHAC_LONHON100

		--@PCMOITRUONG
		SET @PCMOITRUONG = ROUND((ISNULL(@SONGAYCONG,0)  +  ISNULL(@HS2,0) /8 +  ISNULL(@HS3,0) /8)*1500,0)

		--@TONTAI INT
		IF EXISTS(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB' )
		SET @PCMOITRUONG = 0

		IF EXISTS(SELECT * FROM ST_NHANVIENKHONGPHUCAP WHERE NV_MA = @NV_MA  AND NV_PCMOITRUONG = 1)
		SET @PCMOITRUONG = 0


		--@M_MOITRUONG FLOAT
		SET @M_MOITRUONG = @PCMOITRUONG

		--@PHUCAP FLOAT
		SELECT @PHUCAP = ISNULL(L_PCTRACHNHIEM,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@TIENPCDH FLOAT
		SELECT @TIENPCDH = ISNULL(L_PHUCAPDH,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@LUONG_PHUCAP FLOAT
		SET @LUONG_PHUCAP = @LUONGCHINH + @PHUCAP + @TIENPCDH

		--@M_LUONG_TCCMON_CVIEC float
		SET @M_LUONG_TCCMON_CVIEC = @LUONG_PHUCAP
	
		SELECT @M_LUONG_TCCMON_CVIEC = 0
		FROM ST_NHANVIEN
		WHERE NV_MA =@NV_MA AND DV_MA = 'KB'


		--@M_CONG_TT INT
		SET @M_CONG_TT = @SONGAYCONG

		--@LUONGTHANG FLOAT
		IF @SONGAYBT>= 26
		       SET @LUONGTHANG = ROUND((@SONGAYCONG)* @LUONGCHINH / 26,0)
		ELSE
		       SET @LUONGTHANG = ROUND((@SONGAYCONG)* @LUONGCHINH / @SONGAYBT,0)

		--@M_LUONGTHANG float
		SET @M_LUONGTHANG = @LUONGTHANG

		--@HS15 INT
		SELECT @HS15 = ROUND(ISNULL(L_CONGHS15,0),1)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@M_HS_15 FLOAT
		SET @M_HS_15= @HS15
		

		--@TCAHS4 INT
		SELECT @TCAHS4 = ROUND(ISNULL(ST_LUONG_.L_CONGTCADEM,0),1)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@M_HS_195 INT
		SET @M_HS_195 = @TCAHS4

		--@HS2 INT
		SELECT @HS2 = ROUND(ISNULL(L_CONGHS2,0),1)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@M_HS_2  INT
		SET @M_HS_2  = @HS2

		--@HS3 INT
		SELECT @HS3 = ROUND(ISNULL( L_CONGHS3,0),1)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@M_HS_3 int
		SET @M_HS_3 = @HS3
		--TIENHS1 FLOAT
		
		--TIEN LUONG 1 GIO
		SELECT @TIENLUONG1GIO = ISNULL(L_TIENLUONG1GIO ,0)
		FROM ST_LUONG 
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
		UPDATE ST_LUONG_ 
		SET L_TIENLUONG1GIO = @TIENLUONG1GIO
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
		SET @TIENHS1=@LUONGTHANG
		--@TIENHS15 FLOAT
				SET @TIENHS15 = round(@TIENLUONG1GIO*  @HS15 *1.5,0)

		--@TIENHS2 FLOAT
		
				SET @TIENHS2 = round(@TIENLUONG1GIO* @HS2*2,0)



		--@TIENHS3 FLOAT

				SET @TIENHS3 = round(@TIENLUONG1GIO* @HS3 *4  ,0)

		--@TIENTCHS4 FLOAT
			
				SET @TIENTCHS4 = round(@TIENLUONG1GIO* @TCAHS4 *2.45,0)

		--@TIENLAMTHEM FLOAT
			SET @TIENLAMTHEM =  @TIENHS15 + @TIENHS2 + @TIENHS3 + @TIENTCHS4

		--@M_TIENLAMTHEM float
			SET @M_TIENLAMTHEM = @TIENLAMTHEM

		--@GIOLAMDEM FLOAT
		SELECT @GIOLAMDEM = ROUND(ISNULL(L_CONGCADEM,0),1)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		--@M_GIOLAMDEM  INT
		SET @M_GIOLAMDEM = @GIOLAMDEM

		--@TIENLAMDEM  FLOAT
		IF @SONGAYBT >=26 
		       SET @TIENLAMDEM = ROUND(@M_GIOLAMDEM * ( @LUONGCHINH /(26*8)*0.5),0)
		ELSE
		       SET @TIENLAMDEM = ROUND(@M_GIOLAMDEM * ( @LUONGCHINH /(@SONGAYBT*8)*0.5),0)

		--@M_TIENLAMDEM  FLOAT
		SET @M_TIENLAMDEM = @TIENLAMDEM

		--@GIOKHAC FLOAT
		SELECT @GIOKHAC = ROUND(ISNULL(L_NGUNGVIEC,0),1)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@M_GIOKHAC  FLOAT
		SET @M_GIOKHAC = @GIOKHAC


		--@TIENNV FLOAT
		IF @SONGAYBT >=26 
		      SET @TIENNV =  ROUND(@GIOKHAC*(@LUONGCHINH/(26*8)),0)
		ELSE
		      SET @TIENNV =  ROUND(@GIOKHAC*(@LUONGCHINH/(@SONGAYBT*8)),0)
		--@TIENKHAC FLOAT
		SET @TIENKHAC = @TIENNV
		--@M_TIENKHAC  FLOAT
		SET @M_TIENKHAC = @TIENKHAC
	
		--@GIORLE FLOAT 
		SET @GIORLE = @GIOLE + @GIOR 
		--@M_GIO_R_LE  int
		SET @M_GIO_R_LE = @GIORLE

		--@TIENPR FLOAT
		IF @SONGAYBT >=26 
		      SET @TIENPR = ROUND(( @GIOR + @GIOLE)*( @LUONGCHINH /(26*8)),0)
		ELSE
		      SET @TIENPR = ROUND(( @GIOR + @GIOLE)*( @LUONGCHINH /(@SONGAYBT*8)),0)

		--@M_TIENNGHI_R_LE  float
		SET @M_TIENNGHI_R_LE = @TIENPR
	

		--@M_PHEPNAM  int
		SET @M_PHEPNAM = @GIOP
		--@M_TIENNUOICON6T FLOAT
		SELECT @TIENNUOICON6T=ISNULL(L_TIENNUOICON6T,0) FROM ST_LUONG_ WHERE NV_MA=@NV_MA AND T_MA=@T_MA AND L_LUONGCHINH=@LUONG_TU_ST_LUONG
		
		SELECT @TIENNUOICON6T=0 
		FROM ST_LUONG_ WHERE NV_MA=@NV_MA AND T_MA=@T_MA AND L_LUONGCHINH=@LUONG_TU_ST_LUONG AND ISNULL(L_HUONGLUONGKHD,0)=0
		
		SET @M_TIENNUOICON6T=@TIENNUOICON6T
		--@TIENPN
		IF @SONGAYBT>=26
				SET @TIENPN = ROUND(@GIOP/8*( @LUONGCHINH /26),0)
	    ELSE 
	            SET @TIENPN = ROUND(@GIOP/8*( @LUONGCHINH /@SONGAYBT),0)
		--@M_TIENPHEPNAM  float la @TIENPN
		SET @M_TIENPHEPNAM = @TIENPN


		--@M_TIEN_NTRO_KHAC_SHP float
		SELECT @CONGKHAC = ISNULL(ST_LUONG_.L_CONGKHAC,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		SET @M_TIEN_NTRO_KHAC_SHP = @CONGKHAC

		--@SOPHANCOM FLOAT
		SELECT @SOPHANCOM = ISNULL(ST_LUONG_.L_SOPHANCOM,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		SELECT @SOPHANCOM = 0
		FROM ST_NHANVIEN
		WHERE NV_MA = @NV_MA AND DV_MA = 'KB'

		--@M_SOPHANCOM  FLOAT
		SET  @M_SOPHANCOM  = @SOPHANCOM
	
		--@TIENCOM FLOAT
		SET @TIENCOM = @M_SOPHANCOM * 9800
	
		--@M_TIENCOM float
		SET @M_TIENCOM = @TIENCOM

		--@TIENBB FLOAT
		SELECT @TIENBB = ISNULL(TU_THUONGABC,0)
		FROM V_TAMUNGTHANGSAU
		WHERE NV_MA = @NV_MA AND THANGSAU = @T_MA

		SELECT @TIENBB = 0
		FROM ST_LUONG_
		WHERE ISNULL(L_HUONGLUONGKHD,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@M_BINHBAU  float 
		SET @M_BINHBAU = @TIENBB

		--@M_23PT_BH_PHEP float
--	@TRABH_P_TH FLOAT
	select @TRABH_P_TH  = ISNULL(L_TraBH_P,0)
	from ST_LUONG_ where nv_ma=@nv_ma and t_ma=@t_ma and l_luongchinh=@LUONG_TU_ST_LUONG

	IF not exists (SELECT * FROM ST_HOPDONGLAODONG , ST_NHANVIEN WHERE ST_HOPDONGLAODONG.NV_MA=@NV_MA AND month(hd_ngayky)=convert(int,left(@t_ma,2)) and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>=15 AND ST_HOPDONGLAODONG.NV_MA=ST_NHANVIEN.NV_MA AND DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY)<12)
		IF exists(SELECT * FROM  ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND ( NV_MA = '00100' OR L_HUONGLUONGKHD = 1 OR ISNULL(L_DuocTraBH_P,0) = 0) )
		SET @TRABH_P_TH = 0

---------------------------------------------------------------- 
		IF (@NV_MA = '21123')
		SET @TRABH_P_TH = 0
--Huong 23PT_BH_P=0 khi L_Dtra_BH_P =0
select @L_TraBH_P=isnull(L_DuocTraBH_P,0) from ST_LUONG_ where nv_ma=@nv_ma and t_ma=@t_ma AND ST_LUONG_.L_LUONGCHINH=@LUONG_TU_ST_LUONG

if @L_TraBH_P=0 
SET @TRABH_P_TH = 0
------------------
		SET  @M_23PT_BH_PHEP = @TRABH_P_TH
		
		--@TIENHS15TINHTHUE FLOAT

				SET @TIENHS15TINHTHUE = round(@TIENLUONG1GIO *  @HS15 ,0)
				
		--@TIENHS2TINHTHUE FLOAT

				SET @TIENHS2TINHTHUE = round(@TIENLUONG1GIO* @HS2,0)
				
		--@TIENHS3TINHTHUE FLOAT
			
				SET @TIENHS3TINHTHUE = round(@TIENLUONG1GIO* @HS3  ,0)
		--@TIENLAMDEMTINHTHUE FLOAT
		
		--@TIENLAMTHEMTINHTHUE FLOAT 
		SET @TIENLAMTHEMTINHTHUE = ISNULL(@TIENHS15TINHTHUE,0) +ISNULL( @TIENHS2TINHTHUE,0) + ISNULL( @TIENHS3TINHTHUE,0) 
		--@M_TIENLAMTHEMTINHTHUE FLOAT
		SET @M_TIENLAMTHEMTINHTHUE =@TIENLAMTHEMTINHTHUE


		--@CONGLUONGTINHTHUE FLOAT
		SET @CONGLUONGTINHTHUE = ISNULL(@LUONGTHANG,0) + ISNULL(@TRABH_P_TH,0) + ISNULL(@M_BINHBAU,0)
								 + ISNULL(@TIENHS15TINHTHUE,0)+ ISNULL(@TIENTCHS4,0)
								+ ISNULL( @TIENHS2TINHTHUE,0) + ISNULL( @TIENHS3TINHTHUE,0) + ISNULL(@TIENNV,0)
								+ ISNULL(@TIENPR,0) +  ISNULL(@M_TIENPHEPNAM,0)+ISNULL(@PCKHAC_LONHON100,0)
								+ ISNULL(@PCCHUYENCAN,0)+ISNULL(@PCMOITRUONG,0) +ISNULL(@PCTRACHNHIEM,0)
								+ ISNULL(@PCTRACHNHIEM,0)+ISNULL(@CONGKHAC,0)+ISNULL (@TIENNUOICON6T,0)
		--@M_CONGLUONGTINHTHUE
		SET @M_CONGLUONGTINHTHUE = @CONGLUONGTINHTHUE

		--@CONGLUONG FLOAT 
		SET @CONGLUONG =   ISNULL(@M_TIENLAMTHEM,0)
					 
	--@M_CONGLUONG float
		SET @M_CONGLUONG = @CONGLUONG

		--@TAMUNG FLOAT
		SELECT @TAMUNG = ISNULL(L_TAMUNG,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
	
		--@M_DATAMUNG  float
		SET @M_DATAMUNG = @TAMUNG 

		--@THUETN FLOAT 
		SELECT @THUETN = ISNULL(ST_LUONG_.L_ThueTNCN,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		SELECT @THUETN = 0
		FROM ST_LUONG_ AS A INNER JOIN ST_NHANVIEN AS B ON A.NV_MA = B.NV_MA
		WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		AND (  L_HUONGCHUYENCAN IS NULL OR  L_HUONGCHUYENCAN = 0  OR   L_HUONGLUONGKHD IS NULL OR L_HUONGLUONGKHD = 0  )
	
		--@M_THUETHUNHAP  float
		SET @M_THUETHUNHAP = @THUETN

		--@BHXH FLOAT
		SELECT @BHXH = ISNULL(L_BHXH,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

		--@BHYT FLOAT
		SELECT @BHYT = ISNULL(L_BHYT,0)
		FROM ST_LUONG_
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG



		--@TIENBHXH FLOAT
		IF EXISTS(SELECT * FROM ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA IN ('T','T01','TST','T01ST') )
		SET @TIENBHXH = ROUND(( @LUONGCHINH + @TIENPCDH )*0.08,0)
	
		IF (@SONGAYCONG + ( @GIOLE /8) + ( @GIOPR /8) <15 ) 
        SET @TIENBHXH = 0
	
		IF EXISTS( SELECT * FROM ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA NOT IN ('T','T01','TST','T01ST') )
		SET @TIENBHXH = ROUND(( @LUONGCHINH + @TIENPCDH )* 0.08,0)

		IF (@BHXH = 0)
		SET @TIENBHXH = 0

		--@TIENBHYT FLOAT
		IF EXISTS(SELECT * FROM ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA IN ('T','T01','TST','T01ST') )
		SET @TIENBHYT = ROUND(( @LUONGCHINH + @TIENPCDH )*0.015,0)
	
		IF (@SONGAYCONG+ ( @GIOLE /8) + ( @GIOPR /8) <15 ) 
        SET @TIENBHYT = 0
	
		IF EXISTS(SELECT * FROM ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA NOT IN ('T','T01','TST','T01ST') )
		SET @TIENBHYT = ROUND(( @LUONGCHINH + @TIENPCDH )*0.015,0)

		IF (@BHYT = 0)
		SET @TIENBHYT = 0

		--@TIENBHTN FLOAT
		IF EXISTS(SELECT * FROM ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA IN ('T','T01','TST','T01ST') )
		SET @TIENBHTN = ROUND(@LUONGCHINH * 0.01,0)
	
		IF (@SONGAYCONG+ ( @GIOLE /8) + ( @GIOPR /8) <15 ) 
         SET @TIENBHTN = 0
	
		IF EXISTS(SELECT * FROM ST_LUONG_ WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA NOT IN ('T','T01','TST','T01ST') )
		SET @TIENBHTN = ROUND( @LUONGCHINH * 0.01,0)

		IF( @BHXH = 0)
		SET @TIENBHTN = 0

		--@TIENBH FLOAT
		SET @TIENBH = @TIENBHXH + @TIENBHYT + @TIENBHTN

		--@M_TIENBH_YT_XH_TN  float
		SET @M_TIENBH_YT_XH_TN = @TIENBH




		--@THUKHAC FLOAT
		SELECT @THUKHAC = ISNULL(CD_DOANPHI.DP_THUKHAC,0)
		FROM CD_DOANPHI
		WHERE DP_MANV = @NV_MA AND DP_MANV != '00100'

		--@TIENCD FLOAT
		SET @TIENCD = 0
		
		SELECT @TIENCD = ISNULL(CD_DOANPHI.DP_TIEN,0)
		FROM CD_DOANPHI
		WHERE DP_MANV = @NV_MA AND DP_THANGNAM = @T_MA

		SET @TIENCD =@TIENCD + @THUKHAC

		IF EXISTS(SELECT * FROM ST_LUONG_ WHERE ISNULL(L_HUONGLUONGKHD,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG)
		SET @TIENCD = 0

		IF (@NV_MA = '00100') 
		SET @TIENCD = 0


		--@M_TIENCONGDOAN float
		SET @M_TIENCONGDOAN = @TIENCD

		--@LANHCUOIKY FLOAT
		SET @LANHCUOIKY = @CONGLUONG
		
		IF @LANHCUOIKY < 0
			SET @LANHCUOIKY =0
		--@M_CONLANHCUOIKY  float
		
			SET @M_CONLANHCUOIKY = @LANHCUOIKY
		
			
		--@SODUHANGTRAM FLOAT
		SET @SODUHANGTRAM = CONVERT(INT,@LANHCUOIKY) % 1000

		--@LAMTRONPHANTRAM FLOAT
		SET @LAMTRONPHANTRAM = @LANHCUOIKY - @SODUHANGTRAM

		--@LAMTRONSOLE FLOAT

		IF (@SODUHANGTRAM >= 1 AND  @SODUHANGTRAM  <= 500) 
			SET @LAMTRONSOLE = 500
		ELSE
			IF (@SODUHANGTRAM > 500 AND @SODUHANGTRAM <= 999 )
			SET @LAMTRONSOLE =  1000
		ELSE
			SET @LAMTRONSOLE =  0

		--@THUCLANH FLOAT
		SET @THUCLANH = @LAMTRONPHANTRAM + @LAMTRONSOLE

		--@M_THUCLANH  float
		SET @M_THUCLANH = @THUCLANH

		--@M_KYNHAN  nvarchar(50)
		SET @M_KYNHAN = ''

		--@M_GHICHU  nvarchar(50)   
		SET @M_GHICHU = ''
		


	
	INSERT INTO [IT_BANGLUONGMOI_]
	([X_MA],[DV_MA],[DV_TEN],[NAM],[THANG],[TUNGAY],[DENNGAY],[HOTEN],[SOTHE],[T_MA],[LUONGCHINH]
	,[MASOTHUE],[SOTAIKHOAN],[CMON_CVIEC],[UUDAI],[CHUYENCAN],[MOITRUONG],[LUONG_TCCMON_CVIEC]
	,[CONG_TT],[LUONGTHANG],[HS_15],[HS_195],[HS_2],[HS_3],[TIENLAMTHEM],[GIOLAMDEM]
    ,[TIENLAMDEM],[TIENNUOICON6T],[GIOKHAC],[TIENKHAC],[GIO_R_LE],[TIENNGHI_R_LE],[PHEPNAM],[TIENPHEPNAM]
	,[TIEN_NTRO_KHAC_SHP],[SOPHANCOM],[TIENCOM],[BINHBAU],[23PT_BH_PHEP],[CONGLUONG]
    ,[DATAMUNG],[THUETHUNHAP],[TIENBH_YT_XH_TN],[TIENCONGDOAN],[CONLANHCUOIKY],[THUCLANH],[KYNHAN],[GHICHU],[CV_MA],[TT_CV],[CONGLUONGTINHTHUE],[TIENLAMTHEMTINHTHUE])
     VALUES
    (@M_X_MA,@M_DV_MA,@M_DV_TEN,@M_NAM,@M_THANG,@M_TUNGAY,@M_DENNGAY,@M_HOTEN,@M_SOTHE,@M_T_MA,@M_LUONGCHINH
	,@M_MASOTHUE,@M_SOTAIKHOAN,@M_CMON_CVIEC,@M_UUDAI,@M_CHUYENCAN,@M_MOITRUONG,@M_LUONG_TCCMON_CVIEC
	,@M_CONG_TT,@M_LUONGTHANG,@M_HS_15,@M_HS_195,@M_HS_2,@M_HS_3,@M_TIENLAMTHEM,@M_GIOLAMDEM,@M_TIENLAMDEM,@M_TIENNUOICON6T
	,@M_GIOKHAC,@M_TIENKHAC,@M_GIO_R_LE,@M_TIENNGHI_R_LE,@M_PHEPNAM,@M_TIENPHEPNAM
	,@M_TIEN_NTRO_KHAC_SHP,@M_SOPHANCOM,@M_TIENCOM,@M_BINHBAU,round(@M_23PT_BH_PHEP,0),round(@M_CONGLUONG,0)
	,@M_DATAMUNG,@M_THUETHUNHAP,@M_TIENBH_YT_XH_TN,@M_TIENCONGDOAN,@M_CONLANHCUOIKY,@M_THUCLANH,@M_KYNHAN,@M_GHICHU,@M_CONGVIEC, @M_TTCV,@M_CONGLUONGTINHTHUE, @M_TIENLAMTHEMTINHTHUE)


--XOA NHAN VIEN NGHI THAI SAN
    IF EXISTS( SELECT * FROM ST_NHANVIENNGHIPHEP WHERE NV_MA=@NV_MA AND NP_MA='TS')
	BEGIN  
		SET @NV_TS=NULL
		SELECT @NGHI_TS_TUNGAY = NP_TUNGAY FROM ST_NHANVIENNGHIPHEP 
		WHERE NP_MA='TS' AND NV_MA=@NV_MA
			  AND NP_TUNGAY =(SELECT MAX(NP_TUNGAY) FROM ST_NHANVIENNGHIPHEP WHERE NP_MA='TS' AND NV_MA=@NV_MA )
		
		SELECT @NGHI_TS_DENNGAY = NP_DENNGAY FROM ST_NHANVIENNGHIPHEP 
		WHERE NP_MA='TS' AND NV_MA=@NV_MA
			  AND NP_TUNGAY =(SELECT MAX(NP_TUNGAY) FROM ST_NHANVIENNGHIPHEP WHERE NP_MA='TS' AND NV_MA=@NV_MA )
		
		--THOI GIAN NGHI TRONG NAM
		IF YEAR(@NGHI_TS_TUNGAY) = YEAR(@NGHI_TS_DENNGAY)

			SELECT @NV_TS = SOTHE FROM ST_NHANVIENNGHIPHEP INNER JOIN IT_BANGLUONGMOI_ ON NV_MA = SOTHE AND T_MA=@T_MA
			WHERE NV_MA=@NV_MA 
			  AND NP_MA='TS' 
			  AND ISNULL(CONG_TT,0)=0
			  AND NP_TUNGAY =@NGHI_TS_TUNGAY
			  AND CONVERT(INT, LEFT(@T_MA,2)) BETWEEN MONTH(@NGHI_TS_TUNGAY)AND MONTH(@NGHI_TS_DENNGAY)
			  AND YEAR(@NGHI_TS_TUNGAY)=CONVERT(INT, RIGHT(@T_MA,4))
		--THOI GIAN NGHI KEO DAI WA NAM SAU
		IF YEAR(@NGHI_TS_TUNGAY) < YEAR(@NGHI_TS_DENNGAY)
		BEGIN
			IF CONVERT(INT, RIGHT(@T_MA,4))=YEAR(@NGHI_TS_TUNGAY)
				SELECT @NV_TS =  SOTHE FROM ST_NHANVIENNGHIPHEP INNER JOIN IT_BANGLUONGMOI_ ON NV_MA = SOTHE AND T_MA=@T_MA
				WHERE NV_MA=@NV_MA
					 AND NP_MA='TS' 
					 AND ISNULL(CONG_TT,0)=0
					 AND NP_TUNGAY =@NGHI_TS_TUNGAY
					 AND CONVERT(INT, LEFT(@T_MA,2)) >= MONTH(@NGHI_TS_TUNGAY)
					 AND (YEAR(@NGHI_TS_TUNGAY) =CONVERT(INT, RIGHT(@T_MA,4)) OR YEAR(@NGHI_TS_DENNGAY)=CONVERT(INT, RIGHT(@T_MA,4)))

			IF CONVERT(INT, RIGHT(@T_MA,4))=YEAR(@NGHI_TS_DENNGAY)
				SELECT  @NV_TS = SOTHE FROM ST_NHANVIENNGHIPHEP INNER JOIN IT_BANGLUONGMOI_ ON NV_MA = SOTHE AND T_MA=@T_MA
				WHERE NV_MA=@NV_MA 
				     AND NP_MA='TS' 
					 AND ISNULL(CONG_TT,0)=0
					 AND NP_TUNGAY =@NGHI_TS_TUNGAY
					 AND CONVERT(INT, LEFT(@T_MA,2)) <= MONTH(@NGHI_TS_DENNGAY)
					 AND (YEAR(@NGHI_TS_TUNGAY) =CONVERT(INT, RIGHT(@T_MA,4)) OR YEAR(@NGHI_TS_DENNGAY)=CONVERT(INT, RIGHT(@T_MA,4)))

		END
		--XOA NHAN VIEN NAY TRONG IT_BANGLUONGMOI
		if @GIORLE =0 and @GIOP =0
		DELETE FROM IT_BANGLUONGMOI_ WHERE SOTHE=@NV_TS AND T_MA=@T_MA
	END

	FETCH NEXT FROM CUR_LUONGCHINH INTO @LUONG_TU_ST_LUONG  
	END
CLOSE CUR_LUONGCHINH
DEALLOCATE CUR_LUONGCHINH

	--TAO CURSOR MOI CHUA LUONG CHINH
	--DUYET CURSOR:CONG CAC THONG SO
	--XOA DONG CU TRONG IT_BANGLUONGMOI_ 
	--INSERT CAC THONG SO VUA CONG VAO IT_BANGLUONGMOI_

   SELECT @SODONG=COUNT(*) FROM IT_BANGLUONGMOI_ WHERE SOTHE=@NV_MA AND T_MA=@T_MA
	IF @SODONG = 2
	BEGIN 
		 SET @M_TIENBH_YT_XH_TN = 0
		 SET @M_THUETHUNHAP = 0
		 SET @M_CONGLUONG = 0
		 SET @M_23PT_BH_PHEP =0
		 SET @M_TIENCOM = 0
		 SET @M_SOPHANCOM =0
		 SET @M_TIENPHEPNAM =0
		 SET @M_PHEPNAM = 0
		 SET @M_TIENNGHI_R_LE =0
		 SET @M_GIO_R_LE =0
		 SET @M_TIENKHAC =0
		 SET @M_GIOKHAC = 0
		 SET @M_TIENNUOICON6T =0
		 SET @M_GIOLAMDEM =0
		 SET @M_LUONGTHANG =0
		 SET @M_CONG_TT = 0
		 SET @M_UUDAI =0
		 SET @M_MOITRUONG =0 
		 SET @M_CMON_CVIEC=0
		 SET @M_TIENLAMTHEM=0
		 SET @M_TIENLAMDEM=0
		 SET @M_CONLANHCUOIKY =0
		 SET @M_THUCLANH =0
		 SET @M_HS_15=0
		 SET @M_HS_195 =0
		 SET @M_HS_2=0
		 SET @M_HS_3 =0
		 SET @M_CONGLUONGTINHTHUE = 0
		 SET @M_TIENLAMTHEMTINHTHUE =0
		 
	

		DECLARE CUR_LUONGCHINH_MOI
		CURSOR FOR SELECT DISTINCT LUONGCHINH FROM IT_BANGLUONGMOI_
		WHERE SOTHE=@NV_MA and T_MA=@T_MA

		OPEN CUR_LUONGCHINH_MOI

		FETCH NEXT FROM CUR_LUONGCHINH_MOI
		INTO @LUONG_TU_IT_BANGLUONGMOI
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
		SELECT @M_TIENBH_YT_XH_TN = @M_TIENBH_YT_XH_TN +ISNULL(TIENBH_YT_XH_TN,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_THUETHUNHAP =@M_THUETHUNHAP +ISNULL(THUETHUNHAP,0)  FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_CONGLUONG = @M_CONGLUONG +ISNULL(CONGLUONG,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_23PT_BH_PHEP =@M_23PT_BH_PHEP + ISNULL([23PT_BH_PHEP],0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_TIENCOM = @M_TIENCOM + ISNULL(TIENCOM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_SOPHANCOM = @M_SOPHANCOM +ISNULL(SOPHANCOM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_TIENPHEPNAM = @M_TIENPHEPNAM + ISNULL(TIENPHEPNAM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_PHEPNAM = @M_PHEPNAM+ISNULL(PHEPNAM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_TIENNGHI_R_LE= @M_TIENNGHI_R_LE + ISNULL(TIENNGHI_R_LE,0) FROM IT_BANGLUONGMOI_
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_GIO_R_LE = @M_GIO_R_LE+ ISNULL(GIO_R_LE,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_TIENKHAC =@M_TIENKHAC +ISNULL(TIENKHAC,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_GIOKHAC =@M_GIOKHAC +ISNULL(GIOKHAC,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_TIENNUOICON6T = @M_TIENNUOICON6T+ ISNULL(TIENNUOICON6T,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_GIOLAMDEM=@M_GIOLAMDEM+ISNULL(GIOLAMDEM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_LUONGTHANG = @M_LUONGTHANG + ISNULL(LUONGTHANG,0)  FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_CONG_TT = @M_CONG_TT + ISNULL(CONG_TT,0)  FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
		SELECT @M_MOITRUONG = @M_MOITRUONG + ISNULL(MOITRUONG,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_UUDAI= @M_UUDAI+ ISNULL(UUDAI,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_CMON_CVIEC=@M_CMON_CVIEC + ISNULL(CMON_CVIEC,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_HS_15 =@M_HS_15+ISNULL(HS_15,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
		SELECT @M_HS_195 =@M_HS_195 +ISNULL(HS_195,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_HS_2 =@M_HS_2 +ISNULL(HS_2,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_HS_3 =@M_HS_3 +ISNULL(HS_3,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
		SELECT @M_TIENLAMTHEM = @M_TIENLAMTHEM+ ISNULL(TIENLAMTHEM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
		SELECT @M_TIENLAMDEM = @M_TIENLAMDEM+ ISNULL(TIENLAMDEM,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		SELECT @M_CONGLUONGTINHTHUE = @M_CONGLUONGTINHTHUE + ISNULL(CONGLUONGTINHTHUE,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
		SELECT @M_TIENLAMTHEMTINHTHUE = @M_TIENLAMTHEMTINHTHUE + ISNULL(TIENLAMTHEMTINHTHUE,0) FROM IT_BANGLUONGMOI_ 
		WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

		

		FETCH NEXT FROM CUR_LUONGCHINH_MOI INTO @LUONG_TU_IT_BANGLUONGMOI  
		END
		--@M_CONLANHCUOIKY float
		SELECT @M_CONLANHCUOIKY = @M_CONGLUONG

		--@SODUHANGTRAM FLOAT
		SET @SODUHANGTRAM = CONVERT(INT,@M_CONLANHCUOIKY) % 1000

		--@LAMTRONPHANTRAM FLOAT
		SET @LAMTRONPHANTRAM = @M_CONLANHCUOIKY - @SODUHANGTRAM

		--@LAMTRONSOLE FLOAT

		IF (@SODUHANGTRAM >= 1 AND  @SODUHANGTRAM  <= 500) 
			SET @LAMTRONSOLE = 500
		ELSE
			IF (@SODUHANGTRAM > 500 AND @SODUHANGTRAM <= 999 )
			SET @LAMTRONSOLE =  1000
		ELSE
			SET @LAMTRONSOLE =  0

		--@THUCLANH FLOAT
		SET @THUCLANH = @LAMTRONPHANTRAM + @LAMTRONSOLE

		--@M_THUCLANH  float
		SET @M_THUCLANH = @THUCLANH

		DELETE FROM IT_BANGLUONGMOI_
		WHERE SOTHE = @NV_MA and T_MA=@T_MA

	INSERT INTO [IT_BANGLUONGMOI_]
	([X_MA],[DV_MA],[DV_TEN],[NAM],[THANG],[TUNGAY],[DENNGAY],[HOTEN],[SOTHE],[T_MA],[LUONGCHINH]
	,[MASOTHUE],[SOTAIKHOAN],[CMON_CVIEC],[UUDAI],[CHUYENCAN],[MOITRUONG],[LUONG_TCCMON_CVIEC]
	,[CONG_TT],[LUONGTHANG],[HS_15],[HS_195],[HS_2],[HS_3],[TIENLAMTHEM],[GIOLAMDEM]
    ,[TIENLAMDEM],[TIENNUOICON6T],[GIOKHAC],[TIENKHAC],[GIO_R_LE],[TIENNGHI_R_LE],[PHEPNAM],[TIENPHEPNAM]
	,[TIEN_NTRO_KHAC_SHP],[SOPHANCOM],[TIENCOM],[BINHBAU],[23PT_BH_PHEP],[CONGLUONG]
    ,[DATAMUNG],[THUETHUNHAP],[TIENBH_YT_XH_TN],[TIENCONGDOAN],[CONLANHCUOIKY],[THUCLANH],[KYNHAN],[GHICHU],[CV_MA],[TT_CV],[CONGLUONGTINHTHUE],[TIENLAMTHEMTINHTHUE])
     VALUES
    (@M_X_MA,@M_DV_MA,@M_DV_TEN,@M_NAM,@M_THANG,@M_TUNGAY,@M_DENNGAY,@M_HOTEN,@M_SOTHE,@M_T_MA,@M_LUONGCHINH
	,@M_MASOTHUE,@M_SOTAIKHOAN,@M_CMON_CVIEC,@M_UUDAI,@M_CHUYENCAN,@M_MOITRUONG,@M_LUONG_TCCMON_CVIEC
	,@M_CONG_TT,@M_LUONGTHANG,@M_HS_15,@M_HS_195,@M_HS_2,@M_HS_3,@M_TIENLAMTHEM,@M_GIOLAMDEM,@M_TIENLAMDEM,@M_TIENNUOICON6T
	,@M_GIOKHAC,@M_TIENKHAC,@M_GIO_R_LE,@M_TIENNGHI_R_LE,@M_PHEPNAM,@M_TIENPHEPNAM
	,@M_TIEN_NTRO_KHAC_SHP,@M_SOPHANCOM,@M_TIENCOM,@M_BINHBAU,@M_23PT_BH_PHEP,@M_CONGLUONG
	,@M_DATAMUNG,@M_THUETHUNHAP,@M_TIENBH_YT_XH_TN,@M_TIENCONGDOAN,@M_CONLANHCUOIKY,@M_THUCLANH,@M_KYNHAN,@M_GHICHU,@M_CONGVIEC, @M_TTCV, @M_CONGLUONGTINHTHUE, @M_TIENLAMTHEMTINHTHUE)
		
		CLOSE CUR_LUONGCHINH_MOI
		DEALLOCATE CUR_LUONGCHINH_MOI

	END

