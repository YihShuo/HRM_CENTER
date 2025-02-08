USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_TINHLUONG]    Script Date: 20/07/2022 10:00:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- mới thay đổi vụ phụ cấp khác ngày 06/02/2017
--exec SP_TINHLUONG_CACHMOI_2017 '65793','02-2016','1'
--select * from ST_LUONG where NV_MA =65793
--select * from ST_LUONG where NV_MA =73244
-- mới thay đổi THAI SẢN 1 KHONG TRỪ CHUYÊN CẦN khác ngày 29/08/2017

--EXEC SP_TINHLUONG '001031', '01-2019', 1, '2018/4/18 8:38:47', 'ADMIN'

ALTER PROCEDURE [dbo].[SP_TINHLUONG] @NV_MA nvarchar(50), @T_MA nvarchar(50), @Loailuong int  ,
    @NGAYTAO DATETIME,
	@NGUOITAO NVARCHAR(50)
AS  
DECLARE
	@DV_MA nvarchar(50),
	@L_LUONGTRUOC float,
	@L_LUONGSAU float,
	@L_PHUCAPTRUOC float,
	@L_PHUCAPSAU float,
	@T_L_PCMTruongT float,
	@T_L_PCMTruongS float,
	@L_PHUCAPKHACT float,
	@L_PHUCAPKHACS float,
	@L_PHUCLOI float,
	@L_HTNGOAIGIO float,
	@L_PHUCLOI_T float,
	@L_HTNGOAIGIO_T float,
	@L_PHUCLOI_S float,
	@L_HTNGOAIGIO_S float,
	@L_PHUCAPDH float,
	@L_CONGKHAC float,
	@L_TRUKHAC float,
-- phu cap
	@L_DQTV_T FLOAT,
	@L_DQTV_S FLOAT,
	@L_PCCC_T FLOAT,
	@L_PCCC_S FLOAT,
	@L_PCTRNTRUOC float,
	@L_PCTRNSAU float,
	@L_PCCCAN float,
	@Chuyencan float,
	@L_PCMTruong float,
	@NGAYDAU DATETIME,
	@SONGAYBT INT,
	@NGAYCUOI DATETIME,
	@NGAYGIUA DATETIME,
	@NgayLe DATETIME,
	@NgayLeTam float,
	@NgayLeTam1 float,
	@NgayLeTam2 float,

	@GIOTAY FLOAT,
	@GIOMAY FLOAT,
	@GIOLE FLOAT,
	@L_CONGHS1 FLOAT,
	@L_CONGHS4 FLOAT,
	@L_CONGTCAHS4 FLOAT,
	@L_CONGTCAHS4A FLOAT,
	@L_CONGTCAHS4B FLOAT,
	@L_CONGTCAHS4C FLOAT,
	@L_CONGHS2 FLOAT,
	@L_CONGHS2A FLOAT,
	@L_CONGHS2B FLOAT,
	@L_TCAHS2 FLOAT,
	@L_CONGHS3 FLOAT,
	@L_CONGHS530 FLOAT,
	@L_CONGHS3_CA2_3 FLOAT,
	@L_CONGHS3A FLOAT,
	@L_CONGHS15 FLOAT,
	@L_CONGHS15A FLOAT,
	@L_CONGHS15B FLOAT,
	@L_CONGHS15C FLOAT,
	@L_CONGHS15D FLOAT,
	@L_CONGHS15E FLOAT,
	@L_CONGHS15F FLOAT,
	@L_LAMDEM FLOAT,
	@L_NGUNGVIEC float,
    @L_NGHIDQ float,
	@L_NGHILE float,
	@L_NGHIP float,
	@L_NGHIP1 float,
	@L_NGHIPo float,
	@L_NGHIPD float,
	@L_NGHIR float,
	@L_NGHIR1 float,
	@L_NGHIRO float,
	@L_NGHIOM float,
	@L_NGHICO float,--Andrew
    @L_NGHIST float,
    @L_NGHIPt float,
    --@L_NGHIHK float,
	@L_NGHITS float,
	@L_NGHITS1 float,
	@L_NGHIHS float,
	@L_NGHIO float,
	@L_NGHINO float,
	@L_NGHINO1 float,
	@L_NGHINO2 float,
	@L_NGHIN FLOAT,--Andrew
	@L_NGHIN1 FLOAT,--Andrew
	@L_NGHITNLD float,
	@L_NGHIKHAMTHAI float,
	@L_NGHIDS float,
	@L_TAMUNG float,
	@L_BHXH bit,
	@L_BHYT bit,
	@L_SOPHANCOM float,
	@L_TRUMOBIVI float,
	@MAXTRUMOBIVI float,
	@TRUMOBIVI float,
	@TRUMOBIVI_VUOT float,
	@SOLANDITRE int,
	@SOLANQUENQUETTHE int,
		
	@HD_Ngayky datetime,
	@L_TraBH_P float,
	@L_LuongTraBH float,
    @L_TIENNUOICON6T FLOAT,
    @LDCM_TRUOC bit,
    @LDCM_SAU bit,
        
	--khai bao cac tham so trong cong thuc luong (rp_bangluong.rpt ,rp_phieuluongcanhan.rpt)
	@SODBL INT,
	@HUONGLUONGKHD_T INT,
	@L_NHATROSHP_T INT,
	@HUONGCHUYENCAN_T INT,
	@HUONGCHUYENCAN_S INT,
	@L_NHATROSHP_S INT,
	@HUONGLUONGKHD_S INT,
	@KHONGHUONGCHUYENCAN_T INT,
	@KHONGHUONGCHUYENCAN_S INT,
	@L_HUONGHANHKINH INT,
	@L_VUOTSL INT,
	
	@NGHI_TS_TUNGAY datetime,
	@NGHI_TS_DENNGAY datetime,
	@NV_TS nvarchar(50),
	@LUONG_TU_ST_LUONG FLOAT,
	@HD_PhuCapkhac_T FLOAT,
	@HD_PhuCapkhac_S FLOAT,
	@HD_TCBBHT_T FLOAT,
	@HD_TCBBHT_S FLOAT,
	@CONGTT FLOAT,
	@SONGAYCONG_KHD FLOAT,
	@SONGAYCONG FLOAT,
	@CONGCADEM FLOAT, 
	@GIOP FLOAT,
	@HS2A FLOAT,
	@GIOR FLOAT,
	@GIOR1 FLOAT,
	@GIOP1 FLOAT,
	@GIOPT FLOAT,
	@GIOPo FLOAT,
	@GIOPD FLOAT,
	@GIOPR FLOAT,
	@GIOTS FLOAT,
	@GIONV FLOAT,
	@GIONO FLOAT,
	@GIONO1 FLOAT,
	@GIONO2 FLOAT,
	@TIENPHUCAPKHAC FLOAT,
	@NV_NGAYVAO datetime,
	@T_TUNGAY datetime,
	@HS2A_TH FLOAT,
	@HS3_TH FLOAT,
	@GIOO_TH FLOAT,
	@GIORO_TH FLOAT,
	@GIOOM_TH FLOAT,
	@GIOOM1_TH FLOAT,
	@GIOOM2_TH FLOAT,
	@GIOST_TH FLOAT,
	@SONGAYST FLOAT,
	@SONGAY_ST_HUONGCC FLOAT,
	@CONGTT_TH FLOAT,
	@SONGAYCONG_TH FLOAT,
	@CONGCADEM_TH FLOAT,
	@GIODS_TH FLOAT,
	@DITRE_TH FLOAT,
	@QUENQT_TH FLOAT,
	@GIOTS_TH FLOAT,
	@GIOTS1_TH FLOAT,
	@GIOKTHAI_TH FLOAT,
	@GIOTSKT_TH FLOAT,
	@SONGAY_TH FLOAT,
	@CHUYENCANDUOCHUONG_TH FLOAT,
	@GIOP_TH FLOAT,
	@GIOP1_TH FLOAT,
	@GIOPT_TH FLOAT,
	@GIOPo_TH FLOAT,
	@GIOPD_TH FLOAT,
	@GIOR_TH FLOAT,
	@GIOR1_TH FLOAT,
	@GIOLE_TH FLOAT,
	@GIONO_TH FLOAT,
	@GIONO1_TH FLOAT,
	@GIONO2_TH FLOAT,
	@GION_TH FLOAT,
	@GION1_TH FLOAT,--Andrew
	@GIOTNLD_TH FLOAT,
	@GIODQ_TH FLOAT,
	@GIOKHHGD FLOAT,
	@GIOTS1 FLOAT,
	@GIOHK FLOAT,
	@TIENHK FLOAT,
	@GIOKHHGD_TH FLOAT,
	@PHUCAP FLOAT,
	@TIENPCDH FLOAT,
	@TCAHS4 FLOAT,
	@LUONG_PHUCAP FLOAT,
	@LUONGPT_PHUCAP FLOAT,
	@TIENHS1 FLOAT,
	@TIENHS15 FLOAT,
	@TIENHS2 FLOAT,
	@TIENHS3 FLOAT,
	@TIENHS530 FLOAT,
	@TIENTCHS4 FLOAT,
	@LUONGTHANG FLOAT,
	@TRABH_P_TH FLOAT,
	@PCKHAC_LONHON100 FLOAT,
	@TIENHS15TINHTHUE FLOAT,
	@TIENHS2TINHTHUE FLOAT,
	@TIENHS3TINHTHUE FLOAT,
	@TIENHS530TINHTHUE FLOAT,
	@TIENTCHS4TINHTHUE FLOAT,
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
	@HS1 FLOAT,
	@HS15 FLOAT,
	@HS195 FLOAT,
	@HS2 FLOAT,
	@HS3 FLOAT,
	@HS530 FLOAT,
	@TIENLAMTHEM FLOAT,
	@GIOLAMDEM FLOAT,
	@TIENLAMDEM FLOAT,
	@GIOKHAC FLOAT,
	@TIENKHAC FLOAT,
	@GIORLE FLOAT,
	@TIENPR FLOAT,
	@TIENNO2 FLOAT,
	@TIENP1 FLOAT,
	@TIENPT FLOAT,
	@TIENPo FLOAT,
	@TIENPD FLOAT,
	@TIENPN FLOAT,
	@CONGKHAC_CN FLOAT,
	@CONGKHAC FLOAT,
	@PHUCLOI FLOAT,
	@HTNGOAIGIO FLOAT,
	@PHUCLOI_HTNGOAIGIO FLOAT,
	@CONGKHAC_PCN FLOAT,
	
	@CONGLUONG FLOAT,
	@SOPHANCOM FLOAT,
	@TIENCOM FLOAT,
	@TIENNV FLOAT,
	@TIENBB FLOAT,
	@TONTAI INT,
	@TIENNUOICON6T FLOAT,
	@TIENVUOTSL FLOAT,
	@LUONG_TU_IT_BANGLUONGMOI FLOAT,
	@THANG_SAU nvarchar(50),
	@THANG_S nvarchar(50),
	@TUNGAY_TSAU datetime,
	@DENNGAY_TSAU datetime,
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
	@M_HS_1 FLOAT,
	@M_HS_15 FLOAT,
	@M_HS_195 FLOAT,
	@M_HS_2  FLOAT,
	@M_HS_3 FLOAT,
	@M_HS_530 FLOAT,
	@M_TIENHS_530  float,
	@M_TIENLAMTHEM float,
	@M_GIOLAMDEM  FLOAT,
	@M_TIENLAMDEM  FLOAT,
	@M_GIOKHAC  FLOAT,
	@M_GIOHK  FLOAT,
	@M_TIENHK  FLOAT,
	@M_TIENVUOTSL  FLOAT,
	@M_TIENKHAC  float,
	@M_GIO_R_LE  FLOAT,
	@M_TIENNGHI_R_LE  float,
	@M_PHEPNAM  FLOAT,
	@M_P1  FLOAT,
	@M_Po  FLOAT,
	@M_Pd  FLOAT,
	@M_PT  FLOAT,
	@M_R1  FLOAT,
	@M_TIENPHEPNAM  float,
	@M_TIENP1  float,
	@M_TIENPD  float,
	@M_TIEN_NTRO_KHAC_SHP float,
	@M_TIEN_NTRO_KHAC_SHP_ float,
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
	@M_TIENLUONG1GIO FLOAT,
	@M_CONGVIEC nvarchar(50),
	@M_TTCV BIT,
	@M_DV_MA nvarchar(50),
	@M_X_MA  nvarchar(50),
	@M_TIENLAMTHEMTINHTHUE FLOAT, 
	@M_CONGLUONGTINHTHUE FLOAT,
	@M_TIENLUONG1GIOTC FLOAT,
	@M_TRUMOBIVI float,
	@SODONG INT,
	@MOIKHD BIT,
	@TIENLUONG1GIO FLOAT,
	@TIENCHUYENCANTONG FLOAT,
	@TCBBHT FLOAT,
	@M_LUONG_BHXH float,
	@HD_PHUCAPKHAC FLOAT,
	@M_HUONGLUONGKHD BIT,
	@M_HUONGHANHKINH BIT,
	@M_HUONGVUOTSL BIT,
	@SODONGKHD INT,
	---------------Andrew----------
	@SONGAYBT27TINH26 INT,
	@SONGAYCONG27TINH26 FLOAT,
	@L_SONGAYLAMVIECKHIKHD FLOAT,
	@TIENCHUYENCAN float,
	@L_HUONGLUONGKHD BIT,	
	@HOMEWORK BIT --Làm việc tại nhà

	select @TRUMOBIVI  = ISNULL(MB_SoTien,0) from IT_MOBIVI where nv_ma=@NV_MA AND T_MA = @T_Ma

	select @L_CONGKHAC=Sotien  from ST_KHOANCONGKHAC where NV_MA=@NV_MA and T_Ma=@T_Ma
	select @L_TRUKHAC=TIENDP  from	IT_DOANPHI where SOTHE=@NV_MA and THANGNAM=@T_Ma

	Select @NgayDau=T_TuNgay, @NgayCuoi=T_DenNgay, @SONGAYBT = T_SONGAYCONG 
	From ST_THANG
	Where T_MA=@T_MA

	------Andrew----------------------
	if @SONGAYBT >26
	begin
	set @SONGAYBT27TINH26= 26
	end
	else 
	begin
	set @SONGAYBT27TINH26= @SONGAYBT
	END
    
	-------Làm việc tại nhà-------
	SELECT @HOMEWORK = 0
	IF EXISTS (SELECT * FROM A_HomeWorkSalary WHERE NV_MA = @NV_MA AND T_MA = @T_MA)
		SELECT @HOMEWORK = 1
	-------------------------------------
	SELECT @THANG_SAU = SUBSTRING (CONVERT(CHAR(10),DATEADD(M,1,CONVERT (DATETIME,SUBSTRING(@T_MA,4,4) + '-'+ SUBSTRING(@T_MA,1,2) + '-01')),105),4,7)

	--lay ra @TUNGAY_TSAU, @DENNGAY_TSAU cua thang sau.
	SELECT @TUNGAY_TSAU= T_TUNGAY, @DENNGAY_TSAU = T_DENNGAY FROM ST_THANG WHERE T_MA=@THANG_SAU

	--thang sau co chuyen dvi
	if EXISTS(select * from st_chuyendonvi where nv_ma=@NV_MA and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU)
		begin
			select @DV_MA=CDV_donvimoi from st_chuyendonvi where nv_ma=@NV_MA
															and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU
			if @DV_MA in ('NV','NV1','NV01','NV02','NV03','NV 04') -- Andrew
					select @DV_MA=CDV_donvimoi from st_chuyendonvi where nv_ma=@NV_MA
															AND Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU
		else
			select @DV_MA=CDV_donvicu from st_chuyendonvi where nv_ma=@NV_MA
														and Ngay between @TUNGAY_TSAU and @DENNGAY_TSAU
			if @DV_MA like 'CNM' -- Andrew
			select @DV_MA = DV_MA FROM ST_NHANVIEN WHERE NV_MA=@NV_MA
		end
	else
		select @DV_MA=DV_MA  from ST_NHANVIEN where NV_MA=@NV_MA
	--==============================================================

	if exists(select * from ST_NHANVIENTHOIVIEC where NV_MA=@NV_MA and month(TV_Ngaythoiviec)=month(@NgayDau) and year(TV_Ngaythoiviec)=year(@NgayDau) and day(TV_Ngaythoiviec)<=15)
		select @DV_Ma ='NV' -- Andrew
	if exists(select * from ST_NHANVIENTHOIVIEC where NV_MA=@NV_MA and month(TV_Ngaythoiviec)=month(@NgayDau) and year(TV_Ngaythoiviec)=year(@NgayDau) and day(TV_Ngaythoiviec)>15 and day(TV_Ngaythoiviec)<=day(@NgayCuoi) )
		select @DV_Ma ='NV01' -- Andrew

	-- Xóa lương nhân viên cần tính
	Delete ST_LUONG Where NV_MA=@NV_MA and T_MA=@T_MA

	--TIEN NUOI CON 6T
	IF EXISTS (SELECT * FROM IT_QT_TROCAPCONDUOI6TUOI WHERE MANV=@NV_MA AND T_MA=@T_MA)
		SELECT @L_TIENNUOICON6T=SUM(ISNULL(SOTIEN,0))*1000 FROM IT_QT_TROCAPCONDUOI6TUOI WHERE MANV=@NV_MA AND T_MA=@T_MA
		
		
	--LAY LUONG TRUOC VA LUONG SAU
	--Đếm dòng của diễn biến lương của tháng đang xét cho biến @SODBL
	SELECT @SODBL=COUNT(*) FROM ST_DIENBIENLUONG 
	WHERE DBL_Ngaybatdau>=@NgayDau 
	and DBL_Ngaybatdau<=@NgayCuoi
	and NV_MA=@NV_MA

	------Dựa vào dòng DBL trong tháng để tính toán
	IF @SODBL =2 -- Trong tháng có 2 dòng diễn biến lương (công nhân mới vào 1 dòng, 6 ngày sau KHD thêm 1 dòng)
		BEGIN
			--huong luong khd(edit by vinh)
			select @HUONGLUONGKHD_S = 1,@HUONGCHUYENCAN_S = 1, @L_NHATROSHP_S= 1,@NGAYGIUA= DBL_Ngaybatdau,@L_LUONGSAU=DBL_LuongCB
					,@L_PHUCAPSAU=(isnull(dbl_trocapcv,0) + isnull(dbl_trocapcmnv,0)+ isnull(dbl_trocapqlsx,0)), @LDCM_SAU  = ISNULL(LDCM,0),@T_L_PCMTruongS  = ISNULL(DBL_TROCAPMOITRUONG,0)
					,@L_PHUCAPKHACS=(isnull(dbl_trocapcbvp,0) + isnull(dbl_trocapudmay,0)+ isnull(dbl_trocapqaqip,0)+ isnull(dbl_trocapthorap,0)+ isnull(dbl_trocaphse,0)+ isnull(dbl_trocapnn,0))
					,@KHONGHUONGCHUYENCAN_S = isnull(DBL_KHONGHUONGCHUYENCAN,0)
					,@HD_PhuCapkhac_S = (isnull(dbl_phucapkhac,0) + isnull(dbl_trocaphmpt,0)+ isnull(dbl_trocapbbthang,0)+ isnull(dbl_trocapclgd,0)+ isnull(dbl_trocaphtdp,0))
					,@HD_TCBBHT_S = isnull(dbl_trocapbbht,0),@L_PHUCLOI_S = DBL_PHUCLOI , @L_HTNGOAIGIO_S = DBL_HTNG, @L_DQTV_S = isnull(DBL_DQTV,0), @L_PCCC_S=isnull(DBL_PCCC,0) 
			from ST_DIENBIENLUONG 
			where  NV_MA=@NV_MA
					AND DBL_Ngaybatdau>=@NgayDau and DBL_Ngaybatdau<=@NgayCuoi 
					AND DBL_Ngaybatdau =(SELECT MAX(DBL_Ngaybatdau) 
										FROM ST_DIENBIENLUONG 
										WHERE DBL_Ngaybatdau>=@NgayDau and DBL_Ngaybatdau<=@NgayCuoi AND NV_MA=@NV_MA)
				

			select @HUONGLUONGKHD_T = NULL,@HUONGCHUYENCAN_T = NULL, @L_NHATROSHP_T = NULL,@L_LUONGTRUOC=DBL_LuongCB
					,@L_PHUCAPTRUOC=(isnull(dbl_trocapcv,0) + isnull(dbl_trocapcmnv,0)+ isnull(dbl_trocapqlsx,0)), @LDCM_TRUOC  = ISNULL(LDCM,0),@T_L_PCMTruongT  = ISNULL(DBL_TROCAPMOITRUONG,0)
					,@L_PHUCAPKHACT=(isnull(dbl_trocapcbvp,0) + isnull(dbl_trocapudmay,0)+ isnull(dbl_trocapqaqip,0)+ isnull(dbl_trocapthorap,0)+ isnull(dbl_trocaphse,0)+ isnull(dbl_trocapnn,0))
					,@KHONGHUONGCHUYENCAN_T = isnull(DBL_KHONGHUONGCHUYENCAN,0)
					,@HD_PhuCapkhac_T = (isnull(dbl_phucapkhac,0) + isnull(dbl_trocaphmpt,0)+ isnull(dbl_trocapbbthang,0)+ isnull(dbl_trocapclgd,0)+ isnull(dbl_trocaphtdp,0))
					,@HD_TCBBHT_T = isnull(dbl_trocapbbht,0),@L_PHUCLOI_T = DBL_PHUCLOI , @L_HTNGOAIGIO_T = DBL_HTNG,@L_DQTV_T=isnull(DBL_DQTV,0),@L_PCCC_T=isnull(DBL_PCCC,0) 
			from ST_DIENBIENLUONG 
			where NV_MA=@NV_MA
					AND DBL_NGAYBATDAU in (select MIN(DBL_NGAYBATDAU) 
											from ST_DIENBIENLUONG 
											where DBL_Ngaybatdau>=@NgayDau and DBL_Ngaybatdau<=@NgayCuoi AND NV_MA=@NV_MA)
		END
	ELSE --@SODBL != 2  (chỉ có 1 dòng hoặc không có) 
		BEGIN
			----------------------------------------------------- Số dòng DBL trong tháng đang tính lương = 1---------------------------------------------------------------
			--lao động chuyên môn khi ký hợp đồng lao động thì số dòng dbl chỉ có 1 dòng
			--huong luong khd(edit by vinh)
			--BAT DAU DU -- cong nhan moi ----vo trong thang
			select @HUONGLUONGKHD_S = 1,@HUONGCHUYENCAN_S = 1, @L_NHATROSHP_S = 1,@NGAYGIUA= DBL_Ngaybatdau,@L_LUONGSAU=DBL_LuongCB
					,@L_PHUCAPSAU=(isnull(dbl_trocapcv,0) + isnull(dbl_trocapcmnv,0)+ isnull(dbl_trocapqlsx,0)), @LDCM_SAU  = ISNULL(LDCM,0),@T_L_PCMTruongS  = ISNULL(DBL_TROCAPMOITRUONG,0)
					,@L_PHUCAPKHACS=(isnull(dbl_trocapcbvp,0) + isnull(dbl_trocapudmay,0)+ isnull(dbl_trocapqaqip,0)+ isnull(dbl_trocapthorap,0)+ isnull(dbl_trocaphse,0)+ isnull(dbl_trocapnn,0))
					,@KHONGHUONGCHUYENCAN_S = isnull(DBL_KHONGHUONGCHUYENCAN,0)	 
					,@HD_PhuCapkhac_S = (isnull(dbl_phucapkhac,0) + isnull(DBL_TrocapHMPT,0)+ isnull(dbl_trocapbbthang,0)+ isnull(dbl_trocapclgd,0)+ isnull(dbl_trocaphtdp,0))
					,@HD_TCBBHT_S = isnull(dbl_trocapbbht,0),@L_PHUCLOI_S = DBL_PHUCLOI , @L_HTNGOAIGIO_S = DBL_HTNG ,@L_DQTV_S = isnull(DBL_DQTV,0), @L_PCCC_S=isnull(DBL_PCCC,0)
			from ST_DIENBIENLUONG 
			where DBL_Ngaybatdau>@NgayDau and DBL_Ngaybatdau<=@NgayCuoi 
					AND NV_MA=@NV_MA
				
			--đang định xét ngày vào, nếu dbl_ngaybatdau = tháng ngày vào thì = null, còn qua tháng sau = 1
			select @HUONGLUONGKHD_S = NULL,  @L_NHATROSHP_S = NULL, @L_NHATROSHP_S = 1,@HUONGCHUYENCAN_S = 1   -- Andrew xem lại lỗi vô lý của @L_NHATROSHP_S (2 lần)
			from ST_DIENBIENLUONG inner join st_nhanvien on st_dienbienluong.nv_ma = st_nhanvien.nv_ma
			where DBL_Ngaybatdau>@NgayDau and DBL_Ngaybatdau<=@NgayCuoi 
					and ST_DIENBIENLUONG.NV_MA=@NV_MA
					and month(st_nhanvien.nv_ngayvao ) = month(DBL_Ngaybatdau)
				
			select @HUONGLUONGKHD_S = 1
			FROM ST_NHANVIEN A INNER JOIN ST_DIENBIENLUONG B ON A.NV_Ma=B.NV_Ma
								INNER JOIN ST_HOPDONGLAODONG C ON A.NV_Ma=C.NV_Ma
			where DBL_Ngaybatdau>@NgayDau and DBL_Ngaybatdau<=@NgayCuoi 
					and DBL_Ngaybatdau=NV_Ngayvao
					and DBL_Ngaybatdau=HD_NgayKy
					and B.NV_MA=@NV_MA
			
			----------------------------------------------------- Số dòng DBL trong tháng đang tính lương = 0---------------------------------------------------------------	
			--KET THUC DU --nguoi cu,cong nhan moi vo qua thang sau
			select @HUONGLUONGKHD_T = NULL,@HUONGCHUYENCAN_T = NULL,@L_NHATROSHP_T = NULL,@L_LUONGTRUOC=DBL_LuongCB
					,@L_PHUCAPTRUOC=(isnull(dbl_trocapcv,0) + isnull(dbl_trocapcmnv,0)+ isnull(dbl_trocapqlsx,0)) , @LDCM_TRUOC  = ISNULL(LDCM,0),@T_L_PCMTruongT = ISNULL(DBL_TROCAPMOITRUONG,0)
					,@L_PHUCAPKHACT=(isnull(dbl_trocapcbvp,0) + isnull(dbl_trocapudmay,0)+ isnull(dbl_trocapqaqip,0)+ isnull(dbl_trocapthorap,0)+ isnull(dbl_trocaphse,0)+ isnull(dbl_trocapnn,0))
					,@KHONGHUONGCHUYENCAN_T = isnull(DBL_KHONGHUONGCHUYENCAN,0)
					,@HD_PhuCapkhac_T = (isnull(dbl_phucapkhac,0) + isnull(DBL_TrocapHMPT,0)+ isnull(dbl_trocapbbthang,0)+ isnull(dbl_trocapclgd,0)+ isnull(dbl_trocaphtdp,0))
					,@HD_TCBBHT_T = isnull(dbl_trocapbbht,0),@L_PHUCLOI_T = DBL_PHUCLOI , @L_HTNGOAIGIO_T = DBL_HTNG ,@L_DQTV_T=isnull(DBL_DQTV,0),@L_PCCC_T=isnull(DBL_PCCC,0)
			from ST_DIENBIENLUONG 
			where DBL_NGAYBATDAU in (select max(DBL_NGAYBATDAU) from ST_DIENBIENLUONG where DBL_NGAYBATDAU<=@Ngaydau and NV_MA=@NV_MA)
					AND NV_MA=@NV_MA
				
			----huong luong khd(edit by vinh)
			--select @HUONGLUONGKHD_T = 1,@HUONGCHUYENCAN_T = 1,@L_NHATROSHP_T = 1 from ST_DIENBIENLUONG where DBL_NGAYBATDAU in (select max(DBL_NGAYBATDAU) from ST_DIENBIENLUONG where DBL_NGAYBATDAU<=@Ngaydau and NV_MA=@NV_MA)
			--and NV_MA=@NV_MA AND ISNULL(LDCM,0) <> 1
			--huong luong khd(edit by vinh)------NEW
				
			select @HUONGLUONGKHD_T = 1,@HUONGCHUYENCAN_T = 1,@L_NHATROSHP_T = 1 
			FROM ST_DIENBIENLUONG 
			WHERE DBL_NGAYBATDAU in (select max(DBL_NGAYBATDAU) from ST_DIENBIENLUONG where DBL_NGAYBATDAU<=@Ngaydau and NV_MA=@NV_MA)
					AND NV_MA=@NV_MA AND ISNULL(LDCM,0) <> 1
			
			--KET THUC DU --nguoi cu,cong nhan moi vo qua thang sau
			--đang định xét ngày vào, nếu dbl_ngaybatdau = tháng ngày vào thì = null, còn qua tháng sau = 1
			select @HUONGLUONGKHD_T = NULL,@HUONGCHUYENCAN_T = NULL, @L_NHATROSHP_T = NULL
			from ST_DIENBIENLUONG inner join st_nhanvien on st_dienbienluong.nv_ma = st_nhanvien.nv_ma
			where DBL_NGAYBATDAU in (select max(DBL_NGAYBATDAU) from ST_DIENBIENLUONG where DBL_NGAYBATDAU<=@Ngaydau and NV_MA=@NV_MA)
					and ST_DIENBIENLUONG.NV_MA=@NV_MA
					and ST_DIENBIENLUONG.NV_MA not in ('010644','011128','011133','011139')
					and st_nhanvien.nv_ngayvao  = DBL_Ngaybatdau
				
				
			select @HUONGLUONGKHD_T = NULL,@HUONGCHUYENCAN_T = 1 , @L_NHATROSHP_T = 1 
			FROM ST_DIENBIENLUONG 
			WHERE DBL_NGAYBATDAU in (select max(DBL_NGAYBATDAU) from ST_DIENBIENLUONG where DBL_NGAYBATDAU<=@Ngaydau and NV_MA=@NV_MA)
					AND NV_MA=@NV_MA AND ISNULL(LDCM,0) = 1

			select @HUONGLUONGKHD_T=1,@L_NHATROSHP_T = 1
			from st_NHANVIEN inner join ST_hopdonglaodong on ST_NHANVIEN.nv_ma = ST_HOPDONGLAODONG.nv_ma
			where ST_HOPDONGLAODONG.HD_NgayKy=ST_NHANVIEN.NV_Ngayvao AND ST_NHANVIEN.NV_Ma=@NV_MA

			SELECT 	 @HUONGLUONGKHD_T , @HUONGLUONGKHD_S	
		END
-------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------Tính toán Dựa trên Ngày Giữa - Ngày phát sinh DBL (Begin)----------------------------------------------------	
	if @NGAYGIUA is not null -- truong hop cong nhan  moi va ky hop dong tron thang (co 2 dong luong)
		begin		
			---Thang co 2 ngay le
			-----------------------------------------------------------------------TH: @NgayGiua < QT_NGAY  < @NgayCuoi--------------------------------------------------------
			-------------------------------------------- Công Hệ Số 1 ( @L_CONGHS1 )
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
				
			--------------------------------------------- Công Hệ Số 2 ( @L_CONGHS2 ) 
			--Bình Thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--Tăng ca
			select @GIOTAY=sum(CC_GIOTANGCATAY-4)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCATAY>4
			select @GIOMAY=sum(CC_GIOTANGCA-4) 
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCA>4
			SELECT @L_CONGHS2B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			select @L_CONGHS2=@L_CONGHS2A + @L_CONGHS2B --Andrew
			--select @L_CONGHS2=@L_CONGHS2B -- Tỷ Bách

			-------------------------------------------- Công Hệ Số 3 ( @L_CONGHS3 )
			--Bình thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS3=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGHS3A= @L_CONGHS3
		
			
			--------------------HS3-----------------------------
			-- ( CA HE SO >1 and <4)
			-- Tăng Ca Hệ Số 2 ( @L_TCAHS2 )
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG = 2
		
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG = 2

			SELECT @L_TCAHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			--Tinh cong theo phu cap trach nhiem -- (thêm vào) -- Adrew
			SELECT @L_CONGHS2A=@L_CONGHS2A+@L_CONGHS3+ @L_TCAHS2

			-- Công Hệ Số 3 ( @L_CONGHS3 ) (Tổng bao gồm tăng ca hệ số 2)
			SELECT @GIOMAY=sum(CC_GIOBINHTHUONG)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is not null
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND (CA_MA ='Ca 6' or CA_MA ='Ca 7' or CA_MA ='Ca 2' or CA_MA ='Ca 3' or CA_MA ='Ca 1' or CA_MA ='Ca HC' or CA_MA ='Ca01' or CA_MA ='Ca02' or CA_MA ='Ca03')
		
			SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is null
			AND CC_GIOBINHTHUONGTAY IS NOT NULL
			AND (CA_MA ='Ca 6' or CA_MA ='Ca 7' or CA_MA ='Ca 2' or CA_MA ='Ca 3' or CA_MA ='Ca 1' or CA_MA ='Ca HC' or CA_MA ='Ca01' or CA_MA ='Ca02' or CA_MA ='Ca03')
			SELECT @L_CONGHS3_CA2_3 = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGHS3=@L_CONGHS3_CA2_3+@L_TCAHS2
			---------------------------------------HET HS3--------
		
			--------------------HS530-----------------------------
			SELECT @GIOMAY=sum(CC_GIOBINHTHUONG)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is not null
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND CA_MA ='Ca 4'
		
			SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is null
			AND CC_GIOBINHTHUONGTAY IS NOT NULL
			AND CA_MA ='Ca 4'
			SELECT @L_CONGHS530 = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-------------------- HET HS530------------------------
		
			-------------------------------Tăng Ca Hệ Số 1.5 ( @L_TCAHS15 )-------------------------------
			----Tỷ Bách
			--SELECT @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01', 'Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCATAY<=4
			--select @GIOMAY=sum(CC_GIOTANGCA)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01', 'Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCA<=4
			--SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCATAY>4
			--select @GIOMAY=count(CC_GIOTANGCA) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01', 'Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCA>4
			--SELECT @L_CONGHS15B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--	---
			--select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCATAY<=4
			--select @GIOMAY=sum(CC_GIOTANGCAS)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAS is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCAS<=4
			--SELECT @L_CONGHS15C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCATAY>4
			--select @GIOMAY=count(CC_GIOTANGCAS) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAS is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCAS>4
			--SELECT @L_CONGHS15D=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--	---
			--	select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCATAY<=4
			--select @GIOMAY=sum(CC_GIOTANGCAT)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAT is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCAT<=4
			--SELECT @L_CONGHS15E=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCATAY>4
			--select @GIOMAY=count(CC_GIOTANGCAT) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYGIUA
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAT is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCAT>4
			--SELECT @L_CONGHS15F=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
				
			--SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B +@L_CONGHS15C+@L_CONGHS15D+@L_CONGHS15E+@L_CONGHS15F
			----------------------------------

			--Andrew
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCATAY<=4
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCA<=4
			SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			select @GIOTAY=count(CC_GIOTANGCATAY) *4
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCATAY>4
			select @GIOMAY=count(CC_GIOTANGCA) *4
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCA>4 
			SELECT @L_CONGHS15B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B
			---------------------------------------Hết Tăng Ca 1.5---------------------------------------

			-- Lam dem
			select @GIOTAY=sum(CC_GIOLAMDEMTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOLAMDEMTAY is not null
			select @GIOMAY=sum(CC_GIOLAMDEM)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOLAMDEMTAY IS NULL
				and CC_GIOLAMDEM is not null
			SELECT @L_LAMDEM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Ca dem
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOBINHTHUONGTAY IS NULL
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS4=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tang Ca dem
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOTANGCATAY is not null
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
			SELECT @L_CONGTCAHS4A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
					--
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CA_MA ='Ca 2'
				and CC_GIOTANGCATAY is not null
			select @GIOMAY=sum(CC_GIOTANGCAT)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CA_MA ='Ca 2'			
				and CC_GIOTANGCAT is not null
			SELECT @L_CONGTCAHS4B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
					--
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CA_MA ='Ca 3'
				and CC_GIOTANGCATAY is not null
			select @GIOMAY=sum(CC_GIOTANGCAS)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CA_MA ='Ca 3'			
				and CC_GIOTANGCAS is not null
			SELECT @L_CONGTCAHS4C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGTCAHS4 =@L_CONGTCAHS4A +@L_CONGTCAHS4B +@L_CONGTCAHS4C

		
			-- GIO LE
			SELECT @L_NGHILE=SUM(
					CASE WHEN CC_GIOBINHTHUONG=0 AND CC_HESONGAYCONG=3 
					THEN 8 - 
					( CASE WHEN CC_HESONGAYCONG=1 THEN ISNULL(CC_GIOBINHTHUONG,0) ELSE 0 END ) 
					ELSE 0 END
			)
			FROM ST_GIOQUETTHE 
			WHERE 
			QT_NGAY BETWEEN @NGAYGIUA AND @NgayCuoi
			AND NV_MA=@NV_MA
			GROUP BY NV_MA
		
		--	if exists(select *  from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
		--						and LE_Ngay>=@NGAYGIUA) and NV_Ma=@NV_MA)
		--			select @L_NGHILE=8*count(LE_NGAY) 
		--			From ST_LE
		--			Where LE_NGAY>=@NGAYGIUA
		--			and LE_NGAY <=@NgayCuoi
		--			and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)
		--			and LE_NGAY > (select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
		--						and LE_Ngay>=@NGAYGIUA) and NV_Ma=@NV_MA)
		--	else
		--				select @L_NGHILE=8*count(LE_NGAY) 
		--				From ST_LE
		--				Where LE_NGAY>=@NGAYGIUA
		--				and LE_NGAY <=@NgayCuoi
		--				and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)

		

		--	select  @NgayLeTam1=8* count(*)  from ST_GIOQUETTHE
		--	where QT_NGAY >=@NGAYGIUA 
		--	and QT_NGAY <=@NgayCuoi
		--	and NV_Ma =@NV_MA
		--	and (NP_Ma='TS' or  NP_Ma='HS' or  NP_Ma='ST' OR NP_Ma='KHHGD' OR NP_Ma='DS')-- or CC_HESONGAYCONG=3)
		--	and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYGIUA and LE_NGAY <=@NgayCUOI)
		
		--	set @NgayLeTam2=0
		--	if (@L_CONGHS1 + @L_CONGHS4) <=0
		--			select  @NgayLeTam2=8* count(*)  from ST_GIOQUETTHE
		--			where QT_NGAY >=@NGAYGIUA 
		--			and QT_NGAY <=@NgayCuoi
		--			and NV_Ma =@NV_MA
		--			and ( NP_Ma='TS1'  OR  NP_Ma='TNLD'OR  NP_Ma='RO'OR NP_MA='QS')
		--			and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYGIUA and LE_NGAY <=@NgayCUOI)
		
		--	set @NgayLeTam = @NgayLeTam1+@NgayLeTam2
		
		--	if @L_NGHILE-@NgayLeTam<0 
	 --             		select @L_NGHILE=0
		--	else
		--	           select @L_NGHILE=@L_NGHILE-@NgayLeTam
		--SELECT @NgayLeTam
				-- Ngung viec
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='No' or NP_MA='QS')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGUNGVIEC=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0) 

			-- Nghi P
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi P1
		
			select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='P1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY = sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='P1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)	
			-- Nghi Pt
		
			select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Pt'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY = sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Pt'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIPt=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)	
			-- Nghi Po
		
			select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Po'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY = sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Po'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIPo=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)	
		
			-- Nghi PD
		
			--select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			select @GIOTAY= sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='PD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			--select @GIOMAY = sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			select @GIOMAY = sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='PD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIPD=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)	
		
			-- Nghi R
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		
			-- Nghi R1
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='R1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='R1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi RO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='NO' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='NO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi NO1
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='No1' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='No1')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO1 =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi NO2
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='No2'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='No2'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi N
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='N'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='N'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIN=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi N1
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='N1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='N1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIN1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi O
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='O' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='TNLD' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='TS1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA= 'TS1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			SELECT @L_NGHITS1  =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='KHHGD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA= 'KHHGD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			SELECT @GIOKHHGD = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Tam ung
			select @L_TAMUNG=TU_SOTIEN from ST_TAMUNG where NV_MA=@NV_MA and T_MA=@T_MA
			
			
			SELECT @L_CONGHS1, @L_CONGHS4

			--- Dong BHXH,BHYT
			select @L_BHXH=HD_DongBHXH,@L_BHYT=HD_DongBHYT 
			from  ST_Hopdonglaodong inner join st_nhanvien on st_nhanvien.nv_ma=ST_Hopdonglaodong.nv_ma
			where ST_Hopdonglaodong.NV_Ma=@NV_MA 
			and (convert(int,substring(bl_ma,5,2))> 1 AND (HD_NgayKy<=DATEADD(MONTH,-1,dateadd(Day,14,DATEADD(dd,-(DAY(GETDATE())-1),GETDATE()))))
					OR (convert(char(7),HD_NGAYKY,21) = right(@t_ma,4) +'-' + left(@T_MA,2) and day(HD_NGAYKY)<16 and convert(int,substring(bl_ma,5,2))=1)				  
					--Tang luong sau KHDLDL: bac dau tien cua muc luong can bo là 0(khoi diem), hoac nam 1
					OR (convert(int,substring(bl_ma,5,2))<=1 and convert(char(7),HD_NGAYKY,21) < right(@t_ma,4) +'-' + left(@T_MA,2) )
					OR datediff(m,nv_ngayvao,HD_NGAYKY)>=12
				 )		 

			-- SUATAN
			select @L_SOPHANCOM=sum(CC_SUATAN)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_SUATAN is not null

			--- Tinh phu cap
			select @L_PCTRNSAU=@L_PHUCAPSAU
			--- Tinh chuyen can_,moi truong 
			select @SOLANQUENQUETTHE=sum(CC_QUENQUETTHE) , @SOLANDITRE=sum(CC_DITRE) from  ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYGIUA
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
			select @L_PCMTruong=@T_L_PCMTruongS

			if @L_NGHIRO+@L_NGHIOM+@L_NGHITS+@L_NGHINO+@L_NGHIO+@L_NGHIR+@L_NGHIR1+@L_NGHIP+@L_NGHINO2+@L_NGHIDS=0 
				select @Chuyencan=  40000
			else
				begin	
		   			 if @L_NGHIOM=0 
		      				if @L_NGHIRO+ @L_NGHIOM <=8 
								SELECT @Chuyencan= 20000-(@L_NGHITS+@L_NGHINO+@L_NGHIR+@L_NGHIR1+@L_NGHIP+@L_NGHINO2+@L_NGHIDS)/8*1500
							ELSE
				            	select @Chuyencan=  0
					else
		      				select @Chuyencan=  0
				end
			if @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)<0 
	    			select @L_PCCCAN=0
			else
				select @L_PCCCAN=   @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)
			--begin ----- Ngay le di lam thi gio nghi le=0-----------
			--		if @L_CONGHS3A <>0
			--			select @L_NGHILE =0 
			-----end ------------------------
			--		if @L_NGHILE-@L_CONGHS3A<0 
			--			select @L_NGHILE =0 
			--		else
			--			select @L_NGHILE =@L_NGHILE-@L_CONGHS3A
	
			----Tinh L_TraBH_P --Ty Bach
			--	select @L_TraBH_P = 0

			----Tinh L_TraBH_P -- Andrew 
			if isnull(@L_LUONGTRUOC,0)>0
				SELECT @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4) +@L_LAMDEM+@L_NGHIR+@L_NGHIR1+@L_NGHILE+@L_NGHIP+@L_NGHINO+@L_NGHINO2+@L_NGHIN+@L_NGHIN1)/8)*0.245*isnull(@L_LUONGTRUOC,0)/@SONGAYBT27TINH26 
			ELSE
				SELECT @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4) +@L_LAMDEM+@L_NGHIR+@L_NGHIR1+@L_NGHILE+@L_NGHIP+@L_NGHINO+@L_NGHINO2+@L_NGHIN+@L_NGHIN1)/8)*0.245*isnull(@L_LUONGSAU,0)/@SONGAYBT27TINH26 
			
			-----Tính @L_SONGAYLAMVIECKHIKHD-----------------------
			select @L_SONGAYLAMVIECKHIKHD=DATEDIFF(dd,@NGAYGIUA,@NgayCuoi)-dbo.NumberOfSundays(@NGAYGIUA,@NgayCuoi)+1
			----------------------------

			--Moi KHD
			SELECT @L_PHUCAPKHACS
			set @MOIKHD =1
			select @L_BHXH,@L_BHYT
	------------------------------------------------------------------------------------------------------
	------------------------------------------Thêm dòng vào ST_LUONG--------------------------------------
	------------------------------------------------------------------------------------------------------
	if (isnull(@L_LUONGSAU,0)>0) -- trường hợp: @NgayGiua < QT_NGAY  < @NgayCuoi
	begin
		select L_NGHILE = @L_NGHILE
		--edit by vinh (người có 2 dbl và đây là lương sau, từ ngày ký hd tới cuối tháng, mặ định lao động chuyên môn được hưởng lương ký hđ = 1)
		insert into ST_LUONG(NV_MA,T_MA,L_LUONGCHINH,L_PHUCAPKHAC,L_PCTRACHNHIEM,L_PCCHUYENCAN,L_PCMOITRUONG,L_PHUCAPDH
			,DV_MA,L_LOAI
			,L_CONGHS1,L_CONGHS2,L_CONGHS2A,L_CONGHS3,L_CONGHS15,L_CONGCADEM,L_CONGTCADEM,L_LAMDEM
			,L_NGUNGVIEC, L_NGHIDQ,L_NGHILE,L_NGHIP,L_NGHIR,L_NGHIRO,L_NGHIOM, L_NGHIST,L_NGHITS,L_NGHIKHAMTHAI,L_NGHIDS,L_NGHIKHHGD,L_NGHIO,L_NGHINO,L_NGHITNLD
			,L_TAMUNG,L_BHXH,L_BHYT,L_SOPHANCOM,L_SOLANDITRE,L_SOLANQUENQT,L_CONGKHAC,L_TRUKHAC,L_TIENNUOICON6T,L_TraBH_P, L_NGHINO1,L_NGHINO2,L_NGHIN,L_NGHIN1, L_CONGHS530, L_NGHIP1
			, L_NGHIPt, L_NGHIPo, L_NGHIPD,L_MOIKHD, L_HUONGHANHKINH,L_HUONGLUONGKHD,L_KHONGHUONGCHUYENCAN,L_HUONGCHUYENCAN,L_HD_PHUCAPKHAC,L_HD_TCBBHT, L_NGHITS1, L_VUOTSL
			, L_NHATROSINHHOATPHI, L_PHUCLOI, L_HTNGOAIGIO,L_DQTV,L_PCCC ,L_NGHIR1, NGAYCAPNHAT ,NGUOICAPNHAT,L_SONGAYLAMVIECKHIKHD,HOMEWORK )--Andrew
		values(@NV_MA,@T_MA,isnull(@L_LUONGSAU,0),@L_PHUCAPKHACS,@L_PCTRNSAU,@L_PCCCAN,@L_PCMTruong,@L_PHUCAPDH
			,@DV_MA,@LOAILUONG
			,@L_CONGHS1,@L_CONGHS2,@L_CONGHS2A,@L_CONGHS3,@L_CONGHS15,@L_CONGHS4,@L_CONGTCAHS4,@L_LAMDEM
			,@L_NGUNGVIEC, @L_NGHIDQ,@L_NGHILE,@L_NGHIP,@L_NGHIR,@L_NGHIRO,@L_NGHIOM, @L_NGHIST,@L_NGHITS,@L_NGHIKHAMTHAI,@L_NGHIDS,@GIOKHHGD,@L_NGHIO,@L_NGUNGVIEC,@L_NGHITNLD
			,@L_TAMUNG,@L_BHXH,@L_BHYT,@L_SOPHANCOM,@SOLANDITRE,@SOLANQUENQUETTHE,@L_CONGKHAC,@L_TRUKHAC,@L_TIENNUOICON6T,@L_TraBH_P, @L_NGHINO1,@L_NGHINO2,@L_NGHIN,@L_NGHIN1, @L_CONGHS530, @L_NGHIP1
			, @L_NGHIPt, @L_NGHIPo, @L_NGHIPD, @MOIKHD,@L_HUONGHANHKINH,@HUONGLUONGKHD_S,@KHONGHUONGCHUYENCAN_S,@HUONGCHUYENCAN_S,@HD_PhuCapkhac_S,@HD_TCBBHT_S, @L_NGHITS1 ,@L_VUOTSL
			, @L_NHATROSHP_S,@L_PHUCLOI_S, @L_HTNGOAIGIO_S,@L_DQTV_S,@L_PCCC_S,@L_NGHIR1,@NGAYTAO,@NGUOITAO,@L_SONGAYLAMVIECKHIKHD,@HOMEWORK)--Andrew

		-- Tỷ Bách
		--IF @LDCM_SAU =0  -- xét
		--	BEGIN
		--	-- xet lđcm L_DuocTraBH_P = 1					
		--		Update ST_LUONG Set L_DuocTraBH_P = 0
		--		from ST_LUONG
		--		inner join (select MAX(dbl_ngaybatdau) as maxdate,NV_Ma,DBL_LuongCB from st_dienbienluong
		--		where  DBL_Ngaybatdau >= @NGAYDAU and DBL_Ngaybatdau <= @NGAYCUOI and NV_Ma= @NV_MA group by NV_Ma,DBL_LuongCB ) dbl
		--		on ST_LUONG.nv_ma=dbl.NV_Ma
		--		and ST_LUONG.l_luongchinh=dbl.DBL_LuongCB
		--		where ST_LUONG.nv_ma=@NV_MA
		--		and t_ma=@T_MA		
		--		and day(dbl.maxdate) > 15
					
		--		Update ST_LUONG Set L_DuocTraBH_P = 0
		--		from ST_LUONG
		--		inner join (select MAX(dbl_ngaybatdau) as maxdate,NV_Ma,DBL_LuongCB from st_dienbienluong
		--		where  DBL_Ngaybatdau >= @NGAYDAU and DBL_Ngaybatdau <= @NGAYCUOI and NV_Ma= @NV_MA group by NV_Ma,DBL_LuongCB ) dbl
		--		on ST_LUONG.nv_ma=dbl.NV_Ma
		--		and ST_LUONG.l_luongchinh=dbl.DBL_LuongCB
		--		where ST_LUONG.nv_ma=@NV_MA
		--		and t_ma=@T_MA		
		--		and day(dbl.maxdate) <= 15
					
		--		-- cập nhật lại nếu là công nhân
		--		Update ST_LUONG Set L_DuocTraBH_P = 0
		--		from ST_LUONG
		--		inner join (select MAX(dbl_ngaybatdau) as maxdate,NV_Ma,DBL_LuongCB from st_dienbienluong
		--		where  DBL_Ngaybatdau >= @NGAYDAU and DBL_Ngaybatdau <= @NGAYCUOI and NV_Ma= @NV_MA group by NV_Ma,DBL_LuongCB ) dbl
		--		on ST_LUONG.nv_ma=dbl.NV_Ma
		--		and ST_LUONG.l_luongchinh=dbl.DBL_LuongCB
		--		INNER JOIN ST_NHANVIEN ON  ST_LUONG.NV_MA = ST_NHANVIEN.NV_MA
		--		where ST_LUONG.nv_ma=@NV_MA
		--		and t_ma=@T_MA		
		--		and DATEDIFF(day,NV_NGAYVAO,dbl.maxdate) < 29				
					
		--	END
		--Else
		--	begin
		--		-- cũ L_DuocTraBH_P =1
		--		UPDATE ST_LUONG SET  L_DuocTraBH_P =0
		--		FROM ST_LUONG
		--		where t_ma=@t_ma
		--		and ST_LUONG.nv_ma=@nv_ma				
		--	end		
		
		---------------------------------------- Andrew Sửa lại theo Tỷ Thạc----------------------------------------------------------
		update ST_LUONG set L_HUONGLUONGKHD = 1, L_HUONGCHUYENCAN = 1
		where nv_ma  in 
		(select nv_ma from st_hopdonglaodong where month(hd_ngayky)!=convert(int,left(@t_ma,2))
			or year(hd_ngayky)!=convert(int,right(@t_ma,4))) and nv_ma=@nv_ma and t_ma=@T_MA

		update ST_LUONG 
		set  L_HUONGCHUYENCAN = 1
		WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)
		AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)
		AND st_luong.nv_ma=@NV_MA and t_ma=@T_MA

		Update ST_LUONG Set L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1
		from st_luong
		inner join st_hopdonglaodong 
		on st_luong.nv_ma=st_hopdonglaodong.nv_ma
		and st_luong.l_luongchinh=st_hopdonglaodong.hd_luongcb
		where st_luong.nv_ma=@NV_MA
		and t_ma=@T_MA

		UPDATE ST_LUONG set L_DuocTraBH_P = 1
		where nv_ma in 
		(select nv_ma from st_hopdonglaodong where month(hd_ngayky)=convert(int,left(@t_ma,2)) 
		and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>=15) and nv_ma=@nv_ma and t_ma=@T_MA

		update ST_LUONG set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
		where nv_ma not in 
		(select nv_ma from st_hopdonglaodong where hd_ngayky is not null )
		and nv_ma=@nv_ma and t_ma=@T_MA

		UPDATE ST_LUONG SET L_DuocTraBH_P = 0--hUONG
		FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
						INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
		where t_ma=@t_ma
		and st_luong.nv_ma=@nv_ma
		and  month(hd_ngayky)=convert(int,left(@t_ma,2)) 
		and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)<15

		update ST_LUONG set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
		where nv_ma  in (select nv_ma 
							FROM st_hopdonglaodong 
							WHERE hd_ngayky is not null 
									AND ( (YEAR(HD_NGAYKY) > RIGHT(T_MA,4)) 
									OR ( YEAR(HD_NGAYKY) = RIGHT(T_MA,4) 
									AND MONTH(HD_NGAYKY) > LEFT(T_MA,2)) ) ) 
			AND nv_ma=@nv_ma and t_ma=@T_MA

		UPDATE ST_LUONG SET  L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1,L_DuocTraBH_P = 0
		FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
		INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
		where t_ma=@t_ma
		and st_luong.nv_ma=@nv_ma
		and DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY) >= 12
		
		--ky HDLD sau 6 ngay thì ko dc huong 25% phep
		--đã KHD thi xét ngày ký và ngày vào
		IF EXISTS (SELECT 1 FROM ST_HOPDONGLAODONG  WHERE NV_MA =@NV_MA)
			UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
			FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
			INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
			where t_ma=@t_ma
			and st_luong.nv_ma=@nv_ma
			and DATEDIFF(day,NV_NGAYVAO,HD_NGAYKY) <27
		ELSE --chưa KHD: lao động phổ thông thì cập nhật L_DuocTraBH_P = 0
			BEGIN
				IF @LDCM_SAU =0  -- xét
					UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
					FROM ST_LUONG
					where t_ma=@t_ma
					and st_luong.nv_ma=@nv_ma
			END	
		------------------------------------------------------------------------------------------------------	
		UPDATE ST_LUONG
		SET L_TRABH_P = 0
		WHERE DV_MA LIKE '%CG%'
		and nv_ma=@nv_ma and t_ma=@T_MA
		--------------------------------------------Andrew-----------------------------------------------------
		------Xét trường hợp 2 dòng lương, dòng mới phải đóng thu bảo hiểm đối với người có ngày đi làm như sau trở lên
		--sẽ thu BH: tháng 24 ngày đi làm từ 12 ngày, tháng 25,26 ngày làm từ 13 ngày, tháng 27 ngày làm từ 14 ngày	
		--"ngày đi làm" bao gồm luôn các ngày nghỉ phép vì nó đã được tính vào ngày đóng bảo hiểm
		--do lấy mới ký hợp đồng nên có  @L_BHXH IS NULL và @L_BHYT IS NULL do không lấy ra được đối tượng này
		IF @SONGAYBT='24' AND (@L_CONGHS1+@L_NGHIRO+@L_NGHIP+@L_NGHIR+@L_NGHILE+@L_NGHIR1+@L_NGHINO+@L_NGHIO+@L_NGHIOM+@L_NGHITNLD)/8 >= '12' AND @L_BHXH IS NULL AND @L_BHYT IS NULL
			UPDATE ST_LUONG SET L_BHYT = '1', L_BHXH='1' 	WHERE nv_ma=@nv_ma and t_ma=@T_MA
		ELSE IF (@SONGAYBT='25' OR @SONGAYBT='26') AND (@L_CONGHS1+@L_NGHIRO+@L_NGHIP+@L_NGHIR+@L_NGHILE+@L_NGHIR1+@L_NGHINO+@L_NGHIO+@L_NGHIOM+@L_NGHITNLD)/8 >= '13' AND @L_BHXH IS NULL AND @L_BHYT IS NULL
			UPDATE ST_LUONG SET L_BHYT = '1', L_BHXH='1' 	WHERE nv_ma=@nv_ma and t_ma=@T_MA
		ELSE IF @SONGAYBT='27'  AND (@L_CONGHS1+@L_NGHIRO+@L_NGHIP+@L_NGHIR+@L_NGHILE+@L_NGHIR1+@L_NGHINO+@L_NGHIO+@L_NGHIOM+@L_NGHITNLD)/8 >= '14' AND @L_BHXH IS NULL AND @L_BHYT IS NULL
			UPDATE ST_LUONG SET L_BHYT = '1', L_BHXH='1' 	WHERE nv_ma=@nv_ma and t_ma=@T_MA
	END

	-----------------------------------------------------------------------TH:@NgayDau < QT_NGAY  < @NgayGiua --------------------------------------------------------

		-------------------------------------------- Công Hệ Số 1 ( @L_CONGHS1 ) 
		select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			AND CC_HESONGAYCONG = 1
			and CC_GIOBINHTHUONGTAY is not null
		select @GIOMAY=sum(CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA

			and NV_MA=@NV_MA
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND CC_HESONGAYCONG = 1
			and CC_GIOBINHTHUONG is not null
		SELECT @L_CONGHS1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
	
		--------------------------------------------- Công Hệ Số 2 ( @L_CONGHS2 ) 
		--Bình thường
		select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	

			AND CC_HESONGAYCONG = 2
			and CC_GIOBINHTHUONGTAY is not null
		select @GIOMAY=sum(CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND CC_HESONGAYCONG = 2
			and CC_GIOBINHTHUONG is not null
		SELECT @L_CONGHS2A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		--Tăng ca
		select @GIOTAY=sum(CC_GIOTANGCATAY-4)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and CC_GIOTANGCATAY is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCATAY>4
		select @GIOMAY=sum(CC_GIOTANGCA-4) 
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCA>4
		SELECT @L_CONGHS2B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		select @L_CONGHS2=@L_CONGHS2A+@L_CONGHS2B --Andrew
		--select @L_CONGHS2=@L_CONGHS2B --Tỷ Bách

		-------------------------------------------- Công Hệ Số 3 ( @L_CONGHS3 )
		--Bình thường
		select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONGTAY is not null
		select @GIOMAY=sum(CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is not null
		SELECT @L_CONGHS3=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		SELECT @L_CONGHS3A= @L_CONGHS3
			
		----------------------HS3-----------------------------
		-- ( CA HE SO >1 and <4)
		-- Tăng Ca Hệ Số 2 ( @L_TCAHS2 )
		select @GIOTAY=sum(CC_GIOTANGCATAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and CC_GIOTANGCATAY is not null
			AND CC_HESONGAYCONG = 2
		select @GIOMAY=sum(CC_GIOTANGCA)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
			AND CC_HESONGAYCONG = 2
		SELECT @L_TCAHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		--Tinh cong theo phu cap trach nhiem -- (thêm vào) -- Adrew
		SELECT @L_CONGHS2A=@L_CONGHS2A+@L_CONGHS3+ @L_TCAHS2

		-- Công Hệ Số 3 ( @L_CONGHS3 ) (Tổng bao gồm tăng ca hệ số 2)		
		SELECT @GIOMAY=sum(CC_GIOBINHTHUONG)
		FROM ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
		and QT_NGAY <@NGAYGIUA
		and NV_MA=@NV_MA
		AND CC_HESONGAYCONG = 3
		and CC_GIOBINHTHUONG is not null
		AND CC_GIOBINHTHUONGTAY IS NULL
		AND (CA_MA ='Ca 6' or CA_MA ='Ca 7' or CA_MA ='Ca 2' or CA_MA ='Ca 3' or CA_MA ='Ca 1' or CA_MA ='Ca HC' or CA_MA = 'Ca01' or CA_MA = 'Ca02' or CA_MA = 'Ca03')
		
		SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
		FROM ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
		and QT_NGAY <@NGAYGIUA
		and NV_MA=@NV_MA
		AND CC_HESONGAYCONG = 3
		and CC_GIOBINHTHUONG is null
		AND CC_GIOBINHTHUONGTAY IS NOT NULL
		AND (CA_MA ='Ca 6' or CA_MA ='Ca 7' or CA_MA ='Ca 2' or CA_MA ='Ca 3' or CA_MA ='Ca 1' or CA_MA ='Ca HC' or CA_MA = 'Ca01' or CA_MA = 'Ca02' or CA_MA = 'Ca03')
		SELECT @L_CONGHS3_CA2_3 = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		SELECT @L_CONGHS3=@L_CONGHS3_CA2_3+@L_TCAHS2
		---------------------------------------HET HS3--------
		
		--------------------HS530-----------------------------
		SELECT @GIOMAY=sum(CC_GIOBINHTHUONG)
		FROM ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
		and QT_NGAY <@NGAYGIUA
		and NV_MA=@NV_MA
		AND CC_HESONGAYCONG = 3
		and CC_GIOBINHTHUONG is not null
		AND CC_GIOBINHTHUONGTAY IS NULL
		AND CA_MA ='Ca 4'
		
		SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
		FROM ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
		and QT_NGAY <@NGAYGIUA
		and NV_MA=@NV_MA
		AND CC_HESONGAYCONG = 3
		and CC_GIOBINHTHUONG is null
		AND CC_GIOBINHTHUONGTAY IS NOT NULL
		AND CA_MA ='Ca 4'
		SELECT @L_CONGHS530 = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		-------------------- HET HS530------------------------

		-------------------------------Tăng Ca Hệ Số 1.5 ( @L_TCAHS15 )-------------------------------
		----Tỷ Bách
		--select @GIOTAY=sum(CC_GIOTANGCATAY)
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA	
		--	and CC_GIOTANGCATAY is not null
		--	AND CC_HESONGAYCONG = 1
		--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
		--	and CC_GIOTANGCATAY<=4
		--select @GIOMAY=sum(CC_GIOTANGCA)
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA
		--	AND CC_GIOTANGCATAY IS NULL
		--	and CC_GIOTANGCA is not null
		--	AND CC_HESONGAYCONG = 1
		--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
		--	and CC_GIOTANGCA<=4
		--SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		--select @GIOTAY=count(CC_GIOTANGCATAY) *4
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA	
		--	and CC_GIOTANGCATAY is not null
		--	AND CC_HESONGAYCONG = 1
		--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
		--	and CC_GIOTANGCATAY>4
		--select @GIOMAY=count(CC_GIOTANGCA) *4
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA
		--	AND CC_GIOTANGCATAY IS NULL
		--	and CC_GIOTANGCA is not null
		--	AND CC_HESONGAYCONG = 1
		--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
		--	and CC_GIOTANGCA>4
		--SELECT @L_CONGHS15B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		--	---
		--select @GIOTAY=sum(CC_GIOTANGCATAY)
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA	
		--	and CC_GIOTANGCATAY is not null
		--	AND CA_MA ='Ca 2'
		--	and CC_GIOTANGCATAY<=4
		--select @GIOMAY=sum(CC_GIOTANGCAS)
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA
		--	and CC_GIOTANGCAS is not null
		--	AND CA_MA ='Ca 2'
		--	and CC_GIOTANGCAS<=4
		--SELECT @L_CONGHS15C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		--select @GIOTAY=count(CC_GIOTANGCATAY) *4
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA	
		--	and CC_GIOTANGCATAY is not null
		--	AND CA_MA ='Ca 2'
		--	and CC_GIOTANGCATAY>4
		--select @GIOMAY=count(CC_GIOTANGCAS) *4
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA
		--	and CC_GIOTANGCAS is not null
		--	AND CA_MA ='Ca 2'
		--	and CC_GIOTANGCAS>4
		--SELECT @L_CONGHS15D=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		--	---
		--	select @GIOTAY=sum(CC_GIOTANGCATAY)
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA	
		--	and CC_GIOTANGCATAY is not null
		--	AND CA_MA ='Ca 3'
		--	and CC_GIOTANGCATAY<=4
		--select @GIOMAY=sum(CC_GIOTANGCAT)
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA
		--	and CC_GIOTANGCAT is not null
		--	AND CA_MA ='Ca 3'
		--	and CC_GIOTANGCAT<=4
		--SELECT @L_CONGHS15E=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		--select @GIOTAY=count(CC_GIOTANGCATAY) *4
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA	
		--	and CC_GIOTANGCATAY is not null
		--	AND CA_MA ='Ca 3'
		--	and CC_GIOTANGCATAY>4
		--select @GIOMAY=count(CC_GIOTANGCAT) *4
		--From ST_GIOQUETTHE
		--Where QT_NGAY>=@NGAYDAU
		--	and QT_NGAY <@NGAYGIUA
		--	and NV_MA=@NV_MA
		--	and CC_GIOTANGCAT is not null
		--	AND CA_MA ='Ca 3'
		--	and CC_GIOTANGCAT>4
		--SELECT @L_CONGHS15F=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
				
		--SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B +@L_CONGHS15C+@L_CONGHS15D+@L_CONGHS15E+@L_CONGHS15F
		----------------------------------

		--Andrew
		select @GIOTAY=sum(CC_GIOTANGCATAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and CC_GIOTANGCATAY is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCATAY<=4
		select @GIOMAY=sum(CC_GIOTANGCA)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCA<=4
		SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		select @GIOTAY=count(CC_GIOTANGCATAY) *4
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and CC_GIOTANGCATAY is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCATAY>4
		select @GIOMAY=count(CC_GIOTANGCA) *4
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCA>4
		SELECT @L_CONGHS15B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B
		---------------------------------------Hết Tăng Ca 1.5---------------------------------------

		-- Lam dem
		select @GIOTAY=sum(CC_GIOLAMDEMTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and CC_GIOLAMDEMTAY is not null
		select @GIOMAY=sum(CC_GIOLAMDEM)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_GIOLAMDEMTAY IS NULL
			and CC_GIOLAMDEM is not null
		SELECT @L_LAMDEM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Ca dem
		select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			AND CC_HESONGAYCONG = 4
			and CC_GIOBINHTHUONGTAY is not null
		select @GIOMAY=sum(CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 4
			AND CC_GIOBINHTHUONGTAY IS NULL
			and CC_GIOBINHTHUONG is not null
		SELECT @L_CONGHS4=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Tang Ca dem
		select @GIOTAY=sum(CC_GIOTANGCATAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			AND CC_HESONGAYCONG = 4
			and CC_GIOTANGCATAY is not null
		select @GIOMAY=sum(CC_GIOTANGCA)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 4
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
		SELECT @L_CONGTCAHS4A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
				--
		select @GIOTAY=sum(CC_GIOTANGCATAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			AND CA_MA ='Ca 2'
			and CC_GIOTANGCATAY is not null
		select @GIOMAY=sum(CC_GIOTANGCAT)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CA_MA ='Ca 2'			
			and CC_GIOTANGCAT is not null
		SELECT @L_CONGTCAHS4B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
				--
		select @GIOTAY=sum(CC_GIOTANGCATAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			AND CA_MA ='Ca 3'
			and CC_GIOTANGCATAY is not null
		select @GIOMAY=sum(CC_GIOTANGCAS)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			AND CA_MA ='Ca 3'			
			and CC_GIOTANGCAS is not null
		SELECT @L_CONGTCAHS4C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		SELECT @L_CONGTCAHS4 =@L_CONGTCAHS4A +@L_CONGTCAHS4B +@L_CONGTCAHS4C

		
		-- NGHI LE
		SELECT @L_NGHILE=SUM(
							CASE WHEN CC_GIOBINHTHUONG=0 AND CC_HESONGAYCONG=3 
									THEN 8 - ( CASE WHEN CC_HESONGAYCONG=1 THEN ISNULL(CC_GIOBINHTHUONG,0) ELSE 0 END ) 
							ELSE 0 END
							)
		FROM ST_GIOQUETTHE 
		WHERE QT_NGAY BETWEEN @NGAYDAU AND @NgayGIUA
				AND NV_MA=@NV_MA
		GROUP BY NV_MA
		
		--if exists(select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<@NgayGIUA
		--					and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
		--select @L_NGHILE=8*count(LE_NGAY)
		--From ST_LE
		--Where LE_NGAY>=@NGAYDAU
		--	and LE_NGAY <@NgayGIUA
		--	and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)
		--	and LE_NGAY > (select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<@NgayGIUA
		--					and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
		--else
		--			select @L_NGHILE=8*count(LE_NGAY)
		--			From ST_LE
		--			Where LE_NGAY>=@NGAYDAU
		--			and LE_NGAY <@NgayGIUA
		--			and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)

		--select  @NgayLeTam1=8* count(*)  from ST_GIOQUETTHE
		--where QT_NGAY >=@NGAYDAU and
		-- QT_NGAY <@NgayGIUA
		--and NV_Ma =@NV_MA
		--and (NP_Ma='TS' or  NP_Ma='HS' or NP_Ma='ST' OR NP_Ma='KHHGD'  OR NP_Ma='DS')-- or CC_HESONGAYCONG=3)
		--and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYDAU and LE_NGAY <@NgayGIUA)
		
		--set @NgayLeTam2=0
		--if (@L_CONGHS1 + @L_CONGHS4) <=0
		--		select  @NgayLeTam2=8* count(*)  from ST_GIOQUETTHE
		--		where QT_NGAY >=@NGAYDAU and
		--		 QT_NGAY <@NgayGIUA
		--		and NV_Ma =@NV_MA
		--		and (NP_Ma='TS1'  OR  NP_Ma='TNLD'OR  NP_Ma='RO' OR NP_MA='QS')
		--		and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYDAU and LE_NGAY <@NgayGIUA)
	     
		--    set @NgayLeTam = @NgayLeTam1+@NgayLeTam2
	     
		--          if @L_NGHILE-@NgayLeTam<0 

	--            		select @L_NGHILE=0
		--else
		--           select @L_NGHILE=@L_NGHILE-@NgayLeTam


		
		-- Ngung viec
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='No' or NP_MA='QS' )
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and (NP_MA='No' or NP_MA='QS' )
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGUNGVIEC=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Nghi P		
		select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='P'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		
		select @GIOMAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='P'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIP=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Nghi P1
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='P1'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='P1'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIP1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		-- Nghi Pt
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='Pt'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='Pt'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIPt = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		-- Nghi Po
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='Po'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='Po'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIPo=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		-- Nghi Pd
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='PD'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='PD'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIPD=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		-- Nghi R
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='R'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='R'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIR=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		
		-- Nghi R1
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='R1'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='R1'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIR1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Nghi RO
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='RO'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYGIUA
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA	
			and NP_MA='Dq'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='OM' or NP_MA='CO')
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='ST'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='TS'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='HS'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='KTHAI' or NP_MA='S')
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='NO' )
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and (NP_MA='NO')
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHINO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Nghi NO1
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='No1' )
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and (NP_MA='No1')
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHINO1 =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		-- Nghi NO2
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='No2'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='No2'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHINO2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Nghi N
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='N'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='N'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIN=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		-- Nghi N1
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='N1'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='N1'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIN1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- Nghi O
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='O' )
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and (NP_MA='TNLD' )
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
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
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='Ds'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA='Ds'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHIDS=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
		-- Tam ung
		select @L_TAMUNG=0
		select @L_BHXH=0, @L_BHYT=0
		select @L_PCCCAN=0, @L_PCMTruong=0
		IF @DV_MA not LIKE '%CG%'
			SET @L_PHUCAPKHACT=0
			
		-- Nghi KHHGD
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='TS1'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA= 'TS1'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
		SELECT @L_NGHITS1 =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			
		select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYGIUA
			and NV_MA=@NV_MA	
			and NP_MA='KHHGD'
			and CC_GIOBINHTHUONGTAY is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

		select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYGIUA
			and NV_MA=@NV_MA
			and NP_MA= 'KHHGD'
			and CC_GIOBINHTHUONGTAY is null
			and CC_GIOBINHTHUONG is not null
			and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

		SELECT @GIOKHHGD =  ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		-- SUATAN
		select @L_SOPHANCOM=sum(CC_SUATAN)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <@NGAYGIUA
			and NV_MA=@NV_MA	
			and CC_SUATAN is not null

		--TInh phu cap
		select @L_PCTRNTRUOC=@L_PHUCAPTRUOC--/26*(@L_CONGHS1/8+@L_CONGHS2/8+@L_NGHIP/8+@L_NGHIR/8-@L_NGHIRO/8)

		--- Tinh chuyen can_,moi truong 
		select @SOLANQUENQUETTHE=sum(CC_QUENQUETTHE) , @SOLANDITRE=sum(CC_DITRE) from  ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NGAYGIUA
			and NV_MA=@NV_MA	
		select @L_PCMTruong=@T_L_PCMTruongT

		if @L_NGHIRO+@L_NGHIOM+@L_NGHITS+@L_NGHINO+@L_NGHIO+@L_NGHIR+@L_NGHIR1+@L_NGHIP+@L_NGHINO2+@L_NGHIDS=0 
			select @Chuyencan=  40000
		else
		begin	
		   		if @L_NGHIOM=0 
		      			if @L_NGHIRO+ @L_NGHIOM <=8 
							select @Chuyencan= 20000-(@L_NGHITS+@L_NGHINO+@L_NGHIR+@L_NGHIR1+@L_NGHIP+@L_NGHINO2+@L_NGHIDS)/8*1500
					else
				            	select @Chuyencan=  0
			else
		      		select @Chuyencan=  0
		end
		if @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)<0 
	    		select @L_PCCCAN=0
		else
			select @L_PCCCAN=   @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)

		if not exists (select * from ST_LUONG where NV_MA=@NV_MA and T_MA=@T_MA and L_LUONGCHINH=isnull(@L_LUONGTRUOC,0))		
		and exists(select count(NV_MA) from ST_DIENBIENLUONG where NV_MA=@NV_MA
		group by (NV_MA) having count(NV_MA)>1)
		--if @L_CONGHS3A <>0
		--	select @L_NGHILE =0 


		--if @L_NGHILE-@L_CONGHS3A<0 
		--	select @L_NGHILE =0 
		--else
		--	select @L_NGHILE =@L_NGHILE-@L_CONGHS3A

		------Tinh L_TraBH_P --Ty Bach
		--if @SONGAYBT > = 26
		--	select @L_TraBH_P = 0
		--else
		--	select @L_TraBH_P = 0

		----Tinh L_TraBH_P -- Andrew
		SELECT @L_TraBH_P = ((  (@L_CONGHS1 + @L_CONGHS4) +@L_LAMDEM+@L_NGHIR+@L_NGHIR1+@L_NGHILE+@L_NGHIP+@L_NGHINO+@L_NGHINO2+ @L_NGHIN+@L_NGHIN1)/8)*0.245*isnull(@L_LUONGTRUOC,0)/@SONGAYBT27TINH26 -- Andrew
		SELECT @L_PHUCAPKHACT

------------------------------------------------------------------------------------------------------
------------------------------------------Thêm dòng vào ST_LUONG--------------------------------------
------------------------------------------------------------------------------------------------------
		--Thêm dòng vào ST_Luong (TH: @NgayDau < QT_NGAY  < @NgayGiua)
		if (isnull(@L_LUONGTRUOC,0)>0)
			begin
				SELECT L_NGHILE = @L_NGHILE
				insert into ST_LUONG(NV_MA,T_MA,L_LUONGCHINH,L_PHUCAPKHAC,L_PCTRACHNHIEM,L_PCCHUYENCAN,L_PCMOITRUONG,L_PHUCAPDH
					,DV_MA,L_LOAI
					,L_CONGHS1,L_CONGHS2,L_CONGHS2A,L_CONGHS3,L_CONGHS15,L_CONGCADEM,L_CONGTCADEM,L_LAMDEM
					,L_NGUNGVIEC, L_NGHIDQ,L_NGHILE,L_NGHIP,L_NGHIR,L_NGHIRO,L_NGHIOM, L_NGHIST,L_NGHITS,L_NGHIKHAMTHAI,L_NGHIDS,L_NGHIKHHGD,L_NGHIO,L_NGHINO,L_NGHITNLD
					,L_TAMUNG,L_BHXH,L_BHYT,L_SOPHANCOM,L_SOLANDITRE,L_SOLANQUENQT,L_TraBH_P, L_NGHINO1,L_NGHINO2,L_NGHIN,L_NGHIN1, L_CONGHS530, L_NGHIP1, L_NGHIPt, L_NGHIPo, L_NGHIPD,L_HUONGHANHKINH,L_HUONGLUONGKHD,L_KHONGHUONGCHUYENCAN,L_HUONGCHUYENCAN,L_HD_PHUCAPKHAC,L_HD_TCBBHT, L_NGHITS1, L_VUOTSL,L_NHATROSINHHOATPHI, L_PHUCLOI, L_HTNGOAIGIO,L_DQTV,L_PCCC, L_NGHIR1 ,NGAYCAPNHAT,NGUOICAPNHAT,HOMEWORK) 
				values(@NV_MA,@T_MA,isnull(@L_LUONGTRUOC,0),@L_PHUCAPKHACT,@L_PCTRNTRUOC,@L_PCCCAN,@L_PCMTruong,@L_PHUCAPDH
					,@DV_MA,@LOAILUONG
					,@L_CONGHS1,@L_CONGHS2,@L_CONGHS2A,@L_CONGHS3,@L_CONGHS15,@L_CONGHS4,@L_CONGTCAHS4,@L_LAMDEM
					,@L_NGUNGVIEC,@L_NGHIDQ,@L_NGHILE,@L_NGHIP,@L_NGHIR,@L_NGHIRO,@L_NGHIOM, @L_NGHIST,@L_NGHITS,@L_NGHIKHAMTHAI,@L_NGHIDS,@GIOKHHGD,@L_NGHIO,@L_NGUNGVIEC,@L_NGHITNLD
					,@L_TAMUNG,@L_BHXH,@L_BHYT,@L_SOPHANCOM,@SOLANDITRE,@SOLANQUENQUETTHE,@L_TraBH_P, @L_NGHINO1,@L_NGHINO2,@L_NGHIN,@L_NGHIN1, @L_CONGHS530, @L_NGHIP1, @L_NGHIPt, @L_NGHIPo, @L_NGHIPD,@L_HUONGHANHKINH,@HUONGLUONGKHD_T,@KHONGHUONGCHUYENCAN_T,@HUONGCHUYENCAN_T,@HD_PhuCapkhac_T,@HD_TCBBHT_T, @L_NGHITS1, @L_VUOTSL, @L_NHATROSHP_T, @L_PHUCLOI_T, @L_HTNGOAIGIO_T,@L_DQTV_T,@L_PCCC_T, @L_NGHIR1,@NGAYTAO,@NGUOITAO,@HOMEWORK)
				
				--Tỷ Bách
				----cũ L_DuocTraBH_P = 1		
				--Update ST_LUONG set L_DuocTraBH_P = 0,L_HUONGCHUYENCAN = NULL
				--from ST_LUONG
				--where ST_LUONG.nv_ma=@NV_MA
				--and ST_LUONG.t_ma=@T_MA
				--and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC
		
				--Update ST_LUONG Set L_DuocTraBH_P = 0
				--from ST_LUONG
				--inner join (select MAX(dbl_ngaybatdau) as maxdate,NV_Ma,DBL_LuongCB from st_dienbienluong
				--where  DBL_Ngaybatdau >= @NGAYDAU and DBL_Ngaybatdau <= @NGAYCUOI and NV_Ma= @NV_MA group by NV_Ma,DBL_LuongCB ) dbl
				--on ST_LUONG.nv_ma=dbl.NV_Ma
				--and ST_LUONG.l_luongchinh=dbl.DBL_LuongCB
				--INNER JOIN ST_NHANVIEN ON  ST_LUONG.NV_MA = ST_NHANVIEN.NV_MA
				--where ST_LUONG.nv_ma=@NV_MA
				--and t_ma=@T_MA		
				--and DATEDIFF(day,NV_NGAYVAO,dbl.maxdate) < 29
				--and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC
				
				

				--IF @LDCM_TRUOC =0  -- xét
				--BEGIN
				--	UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
				--	FROM ST_LUONG
				--	where t_ma=@t_ma
				--	and ST_LUONG.nv_ma=@nv_ma
				--	and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC
				--END

				----------------------------------------- Andrew sửa lại theo Tỷ Thạc---------------------------
				update ST_LUONG set L_HUONGLUONGKHD = 1, L_HUONGCHUYENCAN = 1
				where nv_ma  in 
				(select nv_ma from st_hopdonglaodong where month(hd_ngayky)!=convert(int,left(@t_ma,2))
				 or year(hd_ngayky)!=convert(int,right(@t_ma,4))) and nv_ma=@nv_ma and t_ma=@T_MA

				update ST_LUONG 
				set  L_HUONGCHUYENCAN = 1
				WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)
				AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)
				AND st_luong.nv_ma=@NV_MA and t_ma=@T_MA

				Update ST_LUONG Set L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1
				from st_luong
				inner join st_hopdonglaodong 
				on st_luong.nv_ma=st_hopdonglaodong.nv_ma
				and st_luong.l_luongchinh=st_hopdonglaodong.hd_luongcb
				where st_luong.nv_ma=@NV_MA
				and t_ma=@T_MA

				update ST_LUONG set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
				where nv_ma not in 
				(select nv_ma from st_hopdonglaodong where hd_ngayky is not null )
				and nv_ma=@nv_ma and t_ma=@T_MA
				and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC


				update ST_LUONG set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
				where nv_ma  in 
				(select nv_ma from st_hopdonglaodong where hd_ngayky is not null AND ( (YEAR(HD_NGAYKY) > RIGHT(T_MA,4)) OR ( YEAR(HD_NGAYKY) = RIGHT(T_MA,4) AND MONTH(HD_NGAYKY) > LEFT(T_MA,2)) ) ) 
				and nv_ma=@nv_ma and t_ma=@T_MA
				and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC


				update ST_LUONG set L_DuocTraBH_P = 1
				from st_luong
				inner join st_hopdonglaodong
				on st_luong.nv_ma=st_hopdonglaodong.nv_ma
				where t_ma=@t_ma
				and st_luong.nv_ma=@nv_ma
				and st_luong.l_luongchinh<st_hopdonglaodong.hd_luongcb
				and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC


				UPDATE ST_LUONG SET  L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1,L_DuocTraBH_P = 0
				FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
				INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
				where t_ma=@t_ma
				and st_luong.nv_ma=@nv_ma
				and DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY) >= 12
				and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC
		
				--ky HDLD sau 6 ngay thì ko dc huong 25% phep
				--đã KHD thi xét ngày ký và ngày vào
				IF EXISTS (SELECT 1 FROM ST_HOPDONGLAODONG  WHERE NV_MA =@NV_MA)
					UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
					FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
					INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
					where t_ma=@t_ma
					and st_luong.nv_ma=@nv_ma
					and DATEDIFF(day,NV_NGAYVAO,HD_NGAYKY) <27
					and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC
				ELSE --chưa KHD: lao động phổ thông thì cập nhật L_DuocTraBH_P = 0
					BEGIN
						IF @LDCM_TRUOC =0  
							UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
							FROM ST_LUONG
							where t_ma=@t_ma
							and st_luong.nv_ma=@nv_ma
							and ST_LUONG.L_LUONGCHINH=@L_LUONGTRUOC				
					END
			------------------------------------------------------------------------------------------------------------
				UPDATE ST_LUONG
				SET L_TRABH_P = 0
				WHERE DV_MA LIKE '%CG%'
				and nv_ma=@nv_ma and t_ma=@T_MA
			end		
		end-- Của If Ngày giữa Not Null
	else-- Ngày giữa Is Null --Trong tháng không phát sinh DBL-----------------------------------------------------------------------------------
		begin
			-- Tinh gio lam binh thuong  (của ngày giữa is Null)
			-----------------------------------------------------------------------TH:@NgayDau < QT_NGAY  < @NgayCuoi (Không có ngày giữa)--------------------------------------------------------
			-------------------------------------------- Công Hệ Số 1 ( @L_CONGHS1 )
			SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND  CC_HESONGAYCONG = 1
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)		

			--------------------------------------------- Công Hệ Số 2 ( @L_CONGHS2 ) 
			--Bình thường
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 2
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS2A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--Tăng ca
			select @GIOTAY=sum(CC_GIOTANGCATAY-4)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCATAY>4
			select @GIOMAY=sum(CC_GIOTANGCA-4) 
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG = 1
				and CC_GIOTANGCA>4
			SELECT @L_CONGHS2B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			select @L_CONGHS2=@L_CONGHS2A+@L_CONGHS2B --Adrew
			--select @L_CONGHS2= @L_CONGHS2B --Tỷ Bách

			-------------------------------------------- Công Hệ Số 3 ( @L_CONGHS3 )
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOBINHTHUONGTAY IS NULL
				AND CC_HESONGAYCONG = 3
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS3=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGHS3A= @L_CONGHS3

			----------------------HS3-----------------------------
			-- TANG CA HE SO >1 and <4
			-- Tăng Ca Hệ Số 2 ( @L_TCAHS2 )
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOTANGCATAY is not NULL
                AND CC_HESONGAYCONG = 2 -- Andrew
				--AND CC_HESONGAYCONG > 1 --Tỷ Bách
				--AND CC_HESONGAYCONG <4 --Tỷ Bách
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
				AND CC_HESONGAYCONG = 2 -- Andrew
				--AND CC_HESONGAYCONG > 1 --Tỷ Bách
				--AND CC_HESONGAYCONG <4 --Tỷ Bách
			SELECT @L_TCAHS2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--Tinh cong theo phu cap trach nhiem -- (thêm vào) -- Adrew
			SELECT @L_CONGHS2A=@L_CONGHS2A+@L_CONGHS3+ @L_TCAHS2

			-- Công Hệ Số 3 ( @L_CONGHS3 ) (Tổng bao gồm tăng ca hệ số 2)
			SELECT @GIOMAY=sum(CC_GIOBINHTHUONG)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is not null
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND (CA_MA ='Ca 6' or CA_MA ='Ca 7' or CA_MA ='Ca 2' or CA_MA ='Ca 3' or CA_MA ='Ca 1' or CA_MA ='Ca HC' or CA_MA ='Ca01'or CA_MA ='Ca02' or CA_MA ='Ca03')
		
			SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is null
			AND CC_GIOBINHTHUONGTAY IS NOT NULL
			AND (CA_MA ='Ca 6' or CA_MA ='Ca 7' or CA_MA ='Ca 2' or CA_MA ='Ca 3' or CA_MA ='Ca 1' or CA_MA ='Ca HC' or CA_MA = 'Ca01' or CA_MA ='Ca02' or CA_MA ='Ca03')
			SELECT @L_CONGHS3_CA2_3 = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGHS3=@L_CONGHS3_CA2_3+@L_TCAHS2
			---------------------------------------HET HS3--------
		
			--------------------HS530-----------------------------
			SELECT @GIOMAY=sum(CC_GIOBINHTHUONG)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is not null
			AND CC_GIOBINHTHUONGTAY IS NULL
			AND CA_MA ='Ca 4'
		
			SELECT @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			FROM ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_HESONGAYCONG = 3
			and CC_GIOBINHTHUONG is null
			AND CC_GIOBINHTHUONGTAY IS NOT NULL
			AND CA_MA ='Ca 4'
			SELECT @L_CONGHS530 = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-------------------- HET HS530------------------------

			-------------------------------Tăng Ca Hệ Số 1.5 ( @L_TCAHS15 )-------------------------------
			----Tỷ Bách
			--select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCATAY<=4
			--select @GIOMAY=sum(CC_GIOTANGCA)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCA<=4
			--SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCATAY>4

			--select @GIOMAY=count(CC_GIOTANGCA) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	AND CC_GIOTANGCATAY IS NULL
			--	and CC_GIOTANGCA is not null
			--	AND CC_HESONGAYCONG = 1
			--	AND CA_MA in ('Ca HC','Ca01','Ca02','Ca03','Ca 6','Ca 7')
			--	and CC_GIOTANGCA>4
			--SELECT @L_CONGHS15B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--	---
			--select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCATAY<=4
			--select @GIOMAY=sum(CC_GIOTANGCAS)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAS is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCAS<=4
			--SELECT @L_CONGHS15C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCATAY>4
			--select @GIOMAY=count(CC_GIOTANGCAS) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAS is not null
			--	AND CA_MA ='Ca 2'
			--	and CC_GIOTANGCAS>4
			--SELECT @L_CONGHS15D=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			--	---
			--	select @GIOTAY=sum(CC_GIOTANGCATAY)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCATAY<=4
			--select @GIOMAY=sum(CC_GIOTANGCAT)
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAT is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCAT<=4
			--SELECT @L_CONGHS15E=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			--select @GIOTAY=count(CC_GIOTANGCATAY) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA	
			--	and CC_GIOTANGCATAY is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCATAY>4
			--select @GIOMAY=count(CC_GIOTANGCAT) *4
			--From ST_GIOQUETTHE
			--Where QT_NGAY>=@NGAYDAU
			--	and QT_NGAY <=@NgayCuoi
			--	and NV_MA=@NV_MA
			--	and CC_GIOTANGCAT is not null
			--	AND CA_MA ='Ca 3'
			--	and CC_GIOTANGCAT>4
			--SELECT @L_CONGHS15F=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
				
			--SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B +@L_CONGHS15C+@L_CONGHS15D+@L_CONGHS15E+@L_CONGHS15F

			--Andrew
			select @GIOTAY=sum(CC_GIOTANGCATAY)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA	
			and CC_GIOTANGCATAY is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCATAY<=4
		select @GIOMAY=sum(CC_GIOTANGCA)
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCA<=4
		SELECT @L_CONGHS15A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

		select @GIOTAY=count(CC_GIOTANGCATAY) *4
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA	
			and CC_GIOTANGCATAY is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCATAY>4

		select @GIOMAY=count(CC_GIOTANGCA) *4
		From ST_GIOQUETTHE
		Where QT_NGAY>=@NGAYDAU
			and QT_NGAY <=@NgayCuoi
			and NV_MA=@NV_MA
			AND CC_GIOTANGCATAY IS NULL
			and CC_GIOTANGCA is not null
			AND CC_HESONGAYCONG = 1
			and CC_GIOTANGCA>4
		SELECT @L_CONGHS15B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		SELECT @L_CONGHS15=@L_CONGHS15A+@L_CONGHS15B
			---------------------------------------Hết Tăng Ca 1.5---------------------------------------

			-- Lam dem
			select @GIOTAY=sum(CC_GIOLAMDEMTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_GIOLAMDEMTAY is not null
			select @GIOMAY=sum(CC_GIOLAMDEM)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_GIOLAMDEMTAY IS NULL
				and CC_GIOLAMDEM is not null

			SELECT @L_LAMDEM=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Ca dem
			select @GIOTAY=sum(CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOBINHTHUONGTAY is not null
			select @GIOMAY=sum(CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOBINHTHUONGTAY IS NULL
				and CC_GIOBINHTHUONG is not null
			SELECT @L_CONGHS4=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Tang Ca dem
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CC_HESONGAYCONG = 4
				and CC_GIOTANGCATAY is not null
			select @GIOMAY=sum(CC_GIOTANGCA)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CC_HESONGAYCONG = 4
				AND CC_GIOTANGCATAY IS NULL
				and CC_GIOTANGCA is not null
			SELECT @L_CONGTCAHS4A=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
					--
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CA_MA ='Ca 2'
				and CC_GIOTANGCATAY is not null
			select @GIOMAY=sum(CC_GIOTANGCAT)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CA_MA ='Ca 2'			
				and CC_GIOTANGCAT is not null
			SELECT @L_CONGTCAHS4B=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
					--
			select @GIOTAY=sum(CC_GIOTANGCATAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				AND CA_MA ='Ca 3'
				and CC_GIOTANGCATAY is not null
			select @GIOMAY=sum(CC_GIOTANGCAS)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				AND CA_MA ='Ca 3'			
				and CC_GIOTANGCAS is not null
			SELECT @L_CONGTCAHS4C=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			SELECT @L_CONGTCAHS4 =@L_CONGTCAHS4A +@L_CONGTCAHS4B +@L_CONGTCAHS4C

		
			-- NGHI LE
			SELECT @L_NGHILE=SUM(
					CASE WHEN CC_GIOBINHTHUONG=0 AND CC_HESONGAYCONG=3 
					THEN 8 - 
					( CASE WHEN CC_HESONGAYCONG=1 THEN ISNULL(CC_GIOBINHTHUONG,0) ELSE 0 END ) 
					ELSE 0 END
			)
			FROM ST_GIOQUETTHE 
			WHERE 
			QT_NGAY BETWEEN @NGAYDAU AND @NgayCuoi
			AND NV_MA=@NV_MA
			GROUP BY NV_MA
		
		--	if exists(select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
		--						and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
		--	select @L_NGHILE=8* count(LE_NGAY)
		--	From ST_LE
		--	Where LE_NGAY>=@NGAYDAU
		--		and LE_NGAY <=@NgayCUOI
		--		and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)
		--		and LE_NGAY > (select TV_Ngaythoiviec from ST_nhanvienthoiviec where TV_Ngaythoiviec <(select max(LE_Ngay) from ST_le  where LE_Ngay<=@NgayCUOI
		--						and LE_Ngay>=@NGAYDAU) and NV_Ma=@NV_MA)
		--	else
		--				select @L_NGHILE=8* count(LE_NGAY)
		--				From ST_LE
		--				Where LE_NGAY>=@NGAYDAU
		--				and LE_NGAY <=@NgayCUOI
		--				and  exists (select *  from  ST_nhanvien where NV_MA=@NV_MA and NV_Ngayvao <= LE_NGAY)

		--	select  @NgayLeTam1=8* count(*)  from ST_GIOQUETTHE
		--	where QT_NGAY >=@NGAYDAU and
		--	 QT_NGAY <=@NgayCuoi
		--	and NV_Ma =@NV_MA
		--	and (NP_Ma='TS' or  NP_Ma='HS' or  NP_Ma='ST' OR NP_Ma='KHHGD'  OR NP_Ma='DS')-- or CC_HESONGAYCONG=3)
		--	and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYDAU and LE_NGAY <=@NgayCUOI)
		
		--	set @NgayLeTam2=0
		--	if (@L_CONGHS1 + @L_CONGHS4) <=0
		--	select  @NgayLeTam2=8* count(*)  from ST_GIOQUETTHE
		--			where QT_NGAY >=@NGAYDAU and
		--			 QT_NGAY <=@NgayCuoi
		--			and NV_Ma =@NV_MA
		--			and (NP_Ma='TS1'    OR  NP_Ma='TNLD'OR  NP_Ma='RO' OR NP_MA='QS')
		--			and QT_Ngay in (select LE_Ngay from ST_Le where LE_NGAY>=@NGAYDAU and LE_NGAY <=@NgayCUOI)

		--	set @NgayLeTam=@NgayLeTam1 + @NgayLeTam2
		--SELECT @L_NGHILE, @NgayLeTam,@NgayLeTam1 , @NgayLeTam2	
		--	if @L_NGHILE-@NgayLeTam<0 
	 --             		select @L_NGHILE=0
		--	else
		--	           select @L_NGHILE=@L_NGHILE-@NgayLeTam
		           
			-- Ngung viec
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='No' or NP_MA='QS' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='No' or NP_MA='QS' )
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGUNGVIEC=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0) 
		
			-- Nghi P
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='P'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi P1
		
			select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='P1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

		
			select @GIOMAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='P1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIP1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi Pt
		
			select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Pt'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

		
			select @GIOMAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Pt'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIPt=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi Po
		
			select @GIOTAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONGTAY END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Po'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

		
			select @GIOMAY= sum( case when CC_SOGIONGHI =2 THEN 2 ELSE 8-CC_GIOBINHTHUONG END)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='Po'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIPo = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi PD
		
			select @GIOTAY= sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='PD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY= sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='PD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIPD = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
			-- Nghi R
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='R'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi R1
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='R1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='R1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIR1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi RO
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='RO'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Dq'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='OM' or NP_MA='CO')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='ST'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='TS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='HS'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='KTHAI' or NP_MA='S')
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	

				and (NP_MA='NO' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='NO')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi NO1
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	

				and (NP_MA='No1' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and (NP_MA='No1')
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO1 =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi NO2
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='No2'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='No2'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHINO2=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi N
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='N'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='N'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIN=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Nghi N1
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='N1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='N1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHIN1=ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)
		
			-- Nghi O
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='O' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and (NP_MA='TNLD' )
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE

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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='Ds'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
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
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='TS1'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='TS1'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @L_NGHITS1 =ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)	
		
			select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and NP_MA='KHHGD'
				and CC_GIOBINHTHUONGTAY is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

			select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA
				and NP_MA='KHHGD'
				and CC_GIOBINHTHUONGTAY is null
				and CC_GIOBINHTHUONG is not null
				and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)
			SELECT @GIOKHHGD = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

			-- Tam ung
			select @L_TAMUNG=TU_SOTIEN from ST_TAMUNG where NV_MA=@NV_MA and T_MA=@T_MA
		
			--Dong BH
			select @L_BHXH=HD_DongBHXH,@L_BHYT=HD_DongBHYT 
			from  ST_Hopdonglaodong inner join st_nhanvien on st_nhanvien.nv_ma=ST_Hopdonglaodong.nv_ma
			where ST_Hopdonglaodong.NV_Ma=@NV_MA 
			and (convert(int,substring(bl_ma,5,2))> 1 AND (HD_NgayKy<=DATEADD(MONTH,-1,dateadd(Day,14,DATEADD(dd,-(DAY(GETDATE())-1),GETDATE()))))
					OR (convert(char(7),HD_NGAYKY,21) = right(@t_ma,4) +'-' + left(@T_MA,2) and day(HD_NGAYKY)<16 and convert(int,substring(bl_ma,5,2))=1)
					--Tang luong sau KHDLDL: bac dau tien cua muc luong can bo là 0(khoi diem), hoac nam 1
					OR (convert(int,substring(bl_ma,5,2))<=1 and convert(char(7),HD_NGAYKY,21) < right(@t_ma,4) +'-' + left(@T_MA,2) )
					OR DATEDIFF(m,nv_ngayvao,HD_NGAYKY)>=12
				)

			-- SUATAN
			select @L_SOPHANCOM=sum(CC_SUATAN)
			From ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				and CC_SUATAN is not null

			--Tinh phu cap
			select @L_PCTRNTRUOC=@L_PHUCAPTRUOC

			--- Tinh chuyen can_,moi truong 
			select @SOLANQUENQUETTHE=sum(CC_QUENQUETTHE) , @SOLANDITRE=sum(CC_DITRE) from  ST_GIOQUETTHE
			Where QT_NGAY>=@NGAYDAU
				and QT_NGAY <=@NgayCuoi
				and NV_MA=@NV_MA	
				--and CC_Hesongaycong =1
			select @L_PCMTruong=@T_L_PCMTruongT

			if @L_NGHIRO+@L_NGHIOM+@L_NGHITS+@L_NGHINO+@L_NGHIO+@L_NGHIR+@L_NGHIR1+@L_NGHIP+@L_NGHINO2+@L_NGHIDS=0 
				select @Chuyencan=  40000
			else
			begin	
		   		 if @L_NGHIOM=0 
		      			 if @L_NGHIRO+ @L_NGHIOM <=8 
							   select @Chuyencan= 20000-(@L_NGHITS+@L_NGHINO+@L_NGHIR+@L_NGHIR1+@L_NGHIP+@L_NGHINO2+@L_NGHIDS)/8*1500
					 else
				            		select @Chuyencan=  0
				else
		      			select @Chuyencan=  0
			end
			if @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)<0 
	    			select @L_PCCCAN=0
			else
				select @L_PCCCAN=   @Chuyencan-(@SOLANDITRE*10000+@SOLANQUENQUETTHE*5000)


			--if @L_CONGHS3A <>0
				--select @L_NGHILE =0 

			--if @L_NGHILE-@L_CONGHS3A<0 
			--	select @L_NGHILE =0 
			--else
			--	select @L_NGHILE =@L_NGHILE-@L_CONGHS3A

			------Tinh L_TraBH_P --Ty Bach
			--SELECT @L_TraBH_P = 0

			--Tinh L_TraBH_P -- Andrew
			SELECT @L_TraBH_P = (( (@L_CONGHS1 + @L_CONGHS4) +@L_LAMDEM+@L_NGHIR+@L_NGHIR1+@L_NGHILE+@L_NGHIP+@L_NGHINO+@L_NGHINO2+@L_NGHIN+@L_NGHIN1)/8)*0.245*isnull(@L_LUONGTRUOC,0)/@SONGAYBT27TINH26 
	      
			SELECT @L_PHUCAPKHACT
			------------------------------------------------------------------------------------------------------
			------------------------------------------Thêm dòng vào ST_LUONG--------------------------------------
			------------------------------------------------------------------------------------------------------
			if (isnull(@L_LUONGTRUOC,0)>0)-- Tức trong tháng không có tồn tại dòng DBL------TH:@NgayDau < QT_NGAY  < @NgayCuoi (Không có ngày giữa)
				BEGIN
					SELECT L_NGHILE=@L_NGHILE
					insert into ST_LUONG(NV_MA,T_MA,L_LUONGCHINH,L_PHUCAPKHAC,L_PCTRACHNHIEM,L_PCCHUYENCAN,L_PCMOITRUONG,L_PHUCAPDH
						,DV_MA,L_LOAI
						,L_CONGHS1,L_CONGHS2,L_CONGHS2A,L_CONGHS3,L_CONGHS15,L_CONGCADEM,L_CONGTCADEM,L_LAMDEM
						,L_NGUNGVIEC, L_NGHIDQ,L_NGHILE,L_NGHIP,L_NGHIR,L_NGHIRO,L_NGHIOM, L_NGHIST,L_NGHITS,L_NGHIKHAMTHAI,L_NGHIDS,L_NGHIKHHGD,L_NGHIO,L_NGHINO,L_NGHITNLD
						,L_TAMUNG,L_BHXH,L_BHYT,L_SOPHANCOM,L_SOLANDITRE,L_SOLANQUENQT,L_CONGKHAC,L_TRUKHAC,L_TraBH_P,L_TIENNUOICON6T, L_NGHINO1,L_NGHINO2,L_NGHIN,L_NGHIN1, L_CONGHS530, L_NGHIP1, L_NGHIPt, L_NGHIPo, L_NGHIPD,L_HUONGLUONGKHD,L_HUONGCHUYENCAN,L_KHONGHUONGCHUYENCAN,L_HD_PHUCAPKHAC,L_HD_TCBBHT, L_NGHITS1, L_NHATROSINHHOATPHI, L_PHUCLOI, L_HTNGOAIGIO, L_DQTV,L_PCCC,L_NGHIR1,NGAYCAPNHAT,NGUOICAPNHAT,HOMEWORK) 
					values(@NV_MA,@T_MA,isnull(@L_LUONGTRUOC,0),@L_PHUCAPKHACT,@L_PCTRNTRUOC,@L_PCCCAN,@L_PCMTruong,@L_PHUCAPDH
						,@DV_MA,@LOAILUONG
						,@L_CONGHS1,@L_CONGHS2,@L_CONGHS2A,@L_CONGHS3,@L_CONGHS15,@L_CONGHS4,@L_CONGTCAHS4,@L_LAMDEM
						,@L_NGUNGVIEC, @L_NGHIDQ,@L_NGHILE,@L_NGHIP,@L_NGHIR,@L_NGHIRO,@L_NGHIOM, @L_NGHIST,@L_NGHITS,@L_NGHIKHAMTHAI,@L_NGHIDS,@GIOKHHGD,@L_NGHIO,@L_NGUNGVIEC,@L_NGHITNLD
						,@L_TAMUNG,@L_BHXH,@L_BHYT,@L_SOPHANCOM,@SOLANDITRE,@SOLANQUENQUETTHE,@L_CONGKHAC,@L_TRUKHAC,@L_TraBH_P,@L_TIENNUOICON6T, @L_NGHINO1,@L_NGHINO2,@L_NGHIN,@L_NGHIN1, @L_CONGHS530 ,@L_NGHIP1,@L_NGHIPt,@L_NGHIPo,@L_NGHIPD,@HUONGLUONGKHD_T,@HUONGCHUYENCAN_T,@KHONGHUONGCHUYENCAN_T,@HD_PhuCapkhac_T,@HD_TCBBHT_T, @L_NGHITS1, @L_NHATROSHP_T, @L_PHUCLOI_T, @L_HTNGOAIGIO_T, @L_DQTV_T,@L_PCCC_T, @L_NGHIR1,@NGAYTAO,@NGUOITAO,@HOMEWORK) 

					Delete From ST_LUONG Where NV_Ma=@NV_MA AND T_MA=@T_MA AND L_LUONGCHINH=0

					-- --Tỷ Bách
					--IF @LDCM_TRUOC = 1
					--	begin
					--		--cũ L_DuocTraBH_P = 1
					--		UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
					--		FROM ST_LUONG
					--		where t_ma=@t_ma
					--		and ST_LUONG.nv_ma=@nv_ma
					--	end
					--else
					--	begin
					--		UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
					--		FROM ST_LUONG
					--		where t_ma=@t_ma
					--		and ST_LUONG.nv_ma=@nv_ma
					--	end

					---------------------------------------- Andrew sửa lại theo hệ thống Tỷ Thạc----------------------------------------------------
					update ST_LUONG set L_HUONGLUONGKHD = 1, L_HUONGCHUYENCAN = 1
					where nv_ma  in 
					(select nv_ma from st_hopdonglaodong where month(hd_ngayky)!=convert(int,left(@t_ma,2))
					 or year(hd_ngayky)!=convert(int,right(@t_ma,4))) and nv_ma=@nv_ma and t_ma=@T_MA

					update ST_LUONG 
					set  L_HUONGCHUYENCAN = 1
					WHERE NV_MA NOT IN (SELECT NV_MA FROM ST_HOPDONGLAODONG)
					AND NV_MA NOT IN (SELECT NV_MA FROM ST_NHANVIENTHOIVIEC)
					AND st_luong.nv_ma=@NV_MA and t_ma=@T_MA

					Update ST_LUONG Set L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1
					from st_luong
					inner join st_hopdonglaodong 
					on st_luong.nv_ma=st_hopdonglaodong.nv_ma
					and st_luong.l_luongchinh=st_hopdonglaodong.hd_luongcb
					where st_luong.nv_ma=@NV_MA
					and t_ma=@T_MA

					update ST_LUONG set L_DuocTraBH_P = 1
					where nv_ma in 
					(select nv_ma from st_hopdonglaodong where month(hd_ngayky)=convert(int,left(@t_ma,2)) 
					and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>=15) and nv_ma=@nv_ma and t_ma=@T_MA

					update ST_LUONG set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
					where nv_ma not in 
					(select nv_ma from st_hopdonglaodong where hd_ngayky is not null )
					and nv_ma=@nv_ma and t_ma=@T_MA


					update ST_LUONG set L_DuocTraBH_P = 1,L_HUONGLUONGKHD=NULL
					where nv_ma  in 
					(select nv_ma from st_hopdonglaodong where hd_ngayky is not null AND ( (YEAR(HD_NGAYKY) > RIGHT(T_MA,4)) OR ( YEAR(HD_NGAYKY) = RIGHT(T_MA,4) AND MONTH(HD_NGAYKY) > LEFT(T_MA,2)) ) ) 
					and nv_ma=@nv_ma and t_ma=@T_MA

					update ST_LUONG set L_DuocTraBH_P = 1
					from st_luong
					inner join st_hopdonglaodong
					on st_luong.nv_ma=st_hopdonglaodong.nv_ma
					where t_ma=@t_ma
					and st_luong.nv_ma=@nv_ma
					and st_luong.l_luongchinh<st_hopdonglaodong.hd_luongcb

					UPDATE ST_LUONG SET  L_HUONGLUONGKHD = 1,L_HUONGCHUYENCAN = 1,L_DuocTraBH_P = 0
					FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
					INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
					where t_ma=@t_ma
					and st_luong.nv_ma=@nv_ma
					and DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY) >= 12
		
					--ky HDLD sau 6 ngay thì ko dc huong 25% phep
					--đã KHD thi xét ngày ký và ngày vào
					IF EXISTS (SELECT 1 FROM ST_HOPDONGLAODONG  WHERE NV_MA =@NV_MA)
						UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
						FROM ST_LUONG INNER JOIN ST_HOPDONGLAODONG ON ST_LUONG.NV_MA = ST_HOPDONGLAODONG.NV_MA
						INNER JOIN ST_NHANVIEN ON  ST_HOPDONGLAODONG.NV_MA = ST_NHANVIEN.NV_MA
						where t_ma=@t_ma
						and st_luong.nv_ma=@nv_ma
						and DATEDIFF(day,NV_NGAYVAO,HD_NGAYKY) <30
			
					ELSE --chưa KHD: lao động phổ thông thì cập nhật L_DuocTraBH_P = 0
						BEGIN
							IF @LDCM_TRUOC =0  
								UPDATE ST_LUONG SET  L_DuocTraBH_P = 0
								FROM ST_LUONG
								where t_ma=@t_ma
								and st_luong.nv_ma=@nv_ma				
						END		
					-------------------------------------------------------------------------------

					UPDATE ST_LUONG
					SET L_TRABH_P = 0
					WHERE DV_MA LIKE '%CG%'
					and nv_ma=@nv_ma and t_ma=@T_MA
					SELECT 	  @L_BHXH, @L_BHYT
				end
		END-- Của If Ngày giữa Is Null
-------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------Tính toán Dựa trên Ngày Giữa (End)-------------------------------------------------------------
	--xet hưởng lương hành kinh
	SELECT @SODONGKHD = COUNT(NV_MA)
	FROM ST_LUONG
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA GROUP BY NV_MA
	
	IF @SODONGKHD = 1 
		BEGIN
		UPDATE ST_LUONG
		SET L_HUONGHANHKINH = 1
		WHERE NV_MA = @NV_MA AND T_MA = @T_MA
		END	

	UPDATE ST_LUONG
	SET L_HUONGHANHKINH = 0
	from ST_LUONG INNER JOIN ST_NHANVIEN ON  ST_LUONG.NV_MA = ST_NHANVIEN.NV_MA
	and ST_LUONG.NV_MA = @NV_MA AND ST_LUONG.T_MA = @T_MA
	where ST_NHANVIEN.NV_GIOITINH = 1


-----------Bắt đầu chèn vào it_bangluongmoi------------------------------------------

----dua du lieu vao bang IT_BANGLUONGMOI ,cac cong thuc trong bao bao phai cai theo dung thu tu
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--xoa du lieu trong bang IT_BANGLUONGMOI
	DELETE FROM IT_BANGLUONGMOI 
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

--lay so dong luong chinh trong bang ST_LUONG
	DECLARE CUR_LUONGCHINH 	CURSOR FOR				-- khai báo con trỏ cursorProduct
		SELECT DISTINCT L_LUONGCHINH 
		FROM ST_LUONG
		WHERE NV_MA=@NV_MA and T_MA=@T_MA

	OPEN CUR_LUONGCHINH								-- Mở con trỏ

	FETCH NEXT FROM CUR_LUONGCHINH					-- Đọc dòng đầu tiên
	INTO @LUONG_TU_ST_LUONG
	--@M_DV_MA nvarchar(50)
	SELECT @M_DV_MA = DV_MA
	FROM ST_LUONG
	WHERE  NV_MA=@NV_MA AND T_MA=@T_MA

	--@M_X_MA nvarchar(50)
	SELECT @M_X_MA = X_MA_
	FROM ST_DONVI 
	WHERE  DV_MA=@M_DV_MA
	--@M_DV_TEN  nvarchar(50) 
	SELECT @M_DV_TEN = B.DV_TEN
	FROM ST_LUONG AS A INNER JOIN ST_DONVI AS B ON A.DV_MA=B.DV_MA
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
	
	--@HS2A_TH int
	SELECT @HS2A_TH = ROUND(ISNULL(L_CONGHS2A ,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	--@HS3_TH int
	SELECT @HS3_TH = ROUND(ISNULL(L_CONGHS3 ,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	--@GIOO_TH int
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
	
	--@GIOOM_TH int
	SELECT @GIOOM1_TH = ROUND(ISNULL(L_NGHIOM1,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
--@GIOOM_TH int
	SELECT @GIOOM2_TH = ROUND(ISNULL(L_NGHIOM2,0),1)
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
	SELECT @CONGCADEM_TH =ROUND(ISNULL(L_CONGCADEM,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@SONGAYCONG_TH int
	SET @SONGAYCONG_TH =  (@CONGTT_TH + @CONGCADEM_TH + @HS2A_TH + @HS3_TH)/8 


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
	SET @GIOTSKT_TH = @GIOTS_TH + @GIOKTHAI_TH + @GIOST_TH

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
	
		--@GIOR1_TH int
	SELECT @GIOR1_TH = ROUND(ISNULL(L_NGHIR1,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIONO_TH int
	SELECT @GIONO_TH = ROUND(ISNULL(L_NGHINO,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	--@GIONO1_TH int
	SELECT @GIONO1_TH = ROUND(ISNULL(L_NGHINO1,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIONO2_TH int
	SELECT @GIONO2_TH = ROUND(ISNULL(L_NGHINO2,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GION_TH int
	SELECT @GION_TH = ROUND(ISNULL(L_NGHIN,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GION1_TH int
	SELECT @GION1_TH = ROUND(ISNULL(L_NGHIN1,0),1)
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
	SELECT @GIOKHHGD_TH = ROUND(ISNULL(L_NGHIKHHGD,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA

	--@GIOP1_TH INT
	SELECT @GIOP1_TH = ROUND(ISNULL(L_NGHIP1,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	
	--@GIOPT_TH INT
	SELECT @GIOPT_TH = ROUND(ISNULL(L_NGHIPT,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	
		--@GIOPo_TH INT
	SELECT @GIOPo_TH = ROUND(ISNULL(L_NGHIPo,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
		--@GIOPD_TH INT
	SELECT @GIOPD_TH = ROUND(ISNULL(L_NGHIPD,0),1)
	FROM v_BangluongTH
	WHERE NV_MA = @NV_MA AND T_MA = @T_MA
	
	-- SONGAYST
	SET @SONGAYST = @GIOST_TH/8
	
	IF @SONGAYST <= 20 
       SET @SONGAY_ST_HUONGCC = 0
    ELSE
       SET @SONGAY_ST_HUONGCC = @GIOST_TH

	--@GIOTS1_TH INT --Andrew
	select @GIOTAY=sum(8-CC_GIOBINHTHUONGTAY)
	From ST_GIOQUETTHE
	Where QT_NGAY>=@NGAYDAU
		and QT_NGAY <=@NGAYCUOI
		and NV_MA=@NV_MA	
		and (NP_MA='TS1')
		and CC_GIOBINHTHUONGTAY is not null
		and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

	select @GIOMAY=sum(8-CC_GIOBINHTHUONG)
	From ST_GIOQUETTHE
	Where QT_NGAY>=@NGAYDAU
		and QT_NGAY <=@NGAYCUOI
		and NV_MA=@NV_MA
		and (NP_MA='TS1')
		and CC_GIOBINHTHUONGTAY is null
		and CC_GIOBINHTHUONG is not null
		and ( CC_Hesongaycong =1 or CC_Hesongaycong =4)

	SELECT @GIOTS1_TH = ISNULL(@GIOTAY,0) + ISNULL(@GIOMAY,0)

 	--@CHUYENCANDUOCHUONG_TH FLOAT
	IF ( @GIOO_TH <> 0 ) 
        SET @CHUYENCANDUOCHUONG_TH = 0 
    ELSE
    IF ( @SONGAYCONG_TH + @GIOLE_TH / 8 + @GIOP_TH /8  +@GIONO2_TH/8 +@GION_TH/8 +@GIOPo_TH/8>= @SONGAY_TH )  
        SET @CHUYENCANDUOCHUONG_TH = 260000   
    ELSE
        IF (@GIOO_TH = 0) 
            IF (@GIORO_TH + @GIOOM_TH+ @GIOOM1_TH + @GIOTNLD_TH =0) 
                SET @CHUYENCANDUOCHUONG_TH = 260000
            ELSE IF ( @GIORO_TH + @GIOOM_TH + @GIOOM1_TH + @GIOTNLD_TH<=8 ) 
                 SET @CHUYENCANDUOCHUONG_TH = 170000
            ELSE IF (@GIORO_TH + @GIOOM_TH + @GIOOM1_TH + @GIOTNLD_TH > 8 AND @GIORO_TH + @GIOOM_TH + @GIOOM1_TH + @GIOTNLD_TH<=16 ) 
                 SET @CHUYENCANDUOCHUONG_TH = 90000
            ELSE IF (@GIORO_TH + @GIOOM_TH + @GIOOM1_TH + @GIOTNLD_TH>16)
                SET @CHUYENCANDUOCHUONG_TH = 0
        ELSE
            SET @CHUYENCANDUOCHUONG_TH = 0

	IF exists(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
	SET @CHUYENCANDUOCHUONG_TH = 0

	WHILE (@@FETCH_STATUS = 0)						--vòng lặp WHILE khi đọc Cursor thành công
		BEGIN
			--Andrew
			--@PCCHUYENCAN FLOAT
			IF ( @NV_NGAYVAO > @T_TUNGAY )  ----------------------------TH: Vào Chưa đủ tháng tính lương----------------------------
				IF ( @GIOO_TH <> 0 ) --Nghỉ O Phép
					SET @PCCHUYENCAN = 0
				ELSE  
					IF  ( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH  = 0) 
						IF                          ((( @SONGAYCONG_TH  +( @GioDs_TH + @GIOLE_TH + @GIOP_TH  + @GIOPo_TH + @GioNo_TH + @GioNo1_TH + @GioNo2_TH + @GION_TH )/8) * (260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 +  (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH )/8*10000 + @GIONO_TH /8*5000 + @GIONO1_TH /8*5000))<0 )											 
							SET @PCCHUYENCAN = 0
						ELSE 
							SET @PCCHUYENCAN = ROUND((( @SONGAYCONG_TH +( @GioDs_TH + @GIOLE_TH + @GIOP_TH  + @GIOPo_TH + @GioNo_TH + @GioNo1_TH + @GioNo2_TH + @GION_TH )/8) *(260000/26))-(( @DITRE_TH *10000 +  @QUENQT_TH *10000 +  (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000 + @GIONO_TH /8*5000+ @GIONO1_TH /8*5000)),-3)                   
					ELSE IF ( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH <= 8 ) --Nghỉ các phép bên từ 1 Ngày đổ lại
						IF                          ((( @SONGAYCONG_TH  +(( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH + @GioDs_TH +@GIONO2_TH+@GION_TH)/8))*(260000/26))-(( @DITRE_TH *10000 +  @QUENQT_TH *10000 + 90000  +  (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000 ))< 0) 								          
							SET @PCCHUYENCAN = 0
						ELSE
							SET @PCCHUYENCAN = round((( @SONGAYCONG_TH  +(( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH + @GioDs_TH+@GIONO2_TH+@GION_TH )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 90000 + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000)),-3)
					ELSE IF ( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH >8 and   @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH  <=16) --Nghỉ các phép bên từ 2 Ngày đổ lại
						IF                          ((( @SONGAYCONG_TH  +(( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH + @GioDs_TH+@GIONO2_TH+@GION_TH  )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 170000  + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000 ))<0 )											 
							SET @PCCHUYENCAN = 0
						ELSE
							SET @PCCHUYENCAN = round((( @SONGAYCONG_TH  +(( @GioRo_TH + @GioOM_TH + @GioOM1_TH + @GioTNLD_TH + @GioDs_TH+@GIONO2_TH+@GION_TH) /8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 170000  + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000)),-3) 
					ELSE  
						SET @PCCHUYENCAN = 0 
			ELSE IF  (@GIOTSKT_TH <> 0)       ----------------------------TH: Thai sản, khám thai----------------------------
				IF                          ( @CHUYENCANDUOCHUONG_TH -(  @GIOTS_TH /8*(260000/26) + @GIOST_TH /8*(260000/26) + @DITRE_TH *10000+ @QUENQT_TH *10000 +( @GIOR1_TH + @GioNo_TH+@GioNo1_TH+@GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH + @GIOPo_TH) /8*5000 + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000)<0 )
					SET @PCCHUYENCAN = 0
				ELSE
					SET @PCCHUYENCAN = round( @CHUYENCANDUOCHUONG_TH -(  @GIOTS_TH /8*(260000/26) + @GIOST_TH /8*(260000/26) + @DITRE_TH *10000+ @QUENQT_TH *10000 +((@GIOR1_TH + @GioNo_TH+@GioNo1_TH +@GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH + @GIOPo_TH)/8*5000 + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000)),0) 
			ELSE							  ----------------------------TH: bình thường , đủ tháng----------------------------
				IF                          ( @CHUYENCANDUOCHUONG_TH -( @DITRE_TH *10000+ @QUENQT_TH *10000+(  @GIOR1_TH + @GioNo_TH + @GioNo1_TH + @GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH +  @GIOPo_TH )/8*5000 + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000)<0 )
					SET @PCCHUYENCAN = 0
				ELSE
					SET @PCCHUYENCAN = round( @CHUYENCANDUOCHUONG_TH -( @DITRE_TH *10000+ @QUENQT_TH *10000+(( @GIOR1_TH + @GIONO_TH + @GIONO1_TH + @GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH + @GIOPo_TH)/8*5000 + (@GIODS_TH+@GIONO2_TH+@GION_TH+@GION1_TH)/8*10000)),0) 

			--	--Andrew (Hệ thống cũ)
			----@PCCHUYENCAN FLOAT
			--IF ( @NV_NGAYVAO > @T_TUNGAY )  --------------TH: Vào Chưa đủ tháng tính lương--------------
			--	IF ( @GIOO_TH <> 0 ) 
			--		SET @PCCHUYENCAN = 0
			--	ELSE  
			--		IF  (@GIORO_TH + @GIOOM_TH + @GIOTNLD_TH = 0) 
			--			IF ((( @SONGAYCONG_TH  +( @GIODS_TH /8)+ (@GIONO_TH/8) + (@GIONO1_TH/8)+(@GIOP_TH/8) )*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 +  (@GIODS_TH + @GIOP1_TH)/8*10000 + @GIONO_TH /8*5000 + @GIONO1_TH /8*5000+@GIOP_TH /8*5000 ))<0 )
			--				SET @PCCHUYENCAN = 0
			--			ELSE 
			--				SET @PCCHUYENCAN = ROUND((( @SONGAYCONG_TH +(@GIOLE_TH+@GIOR_TH)/8 +( @GIODS_TH /8) + (@GIONO_TH/8)+ (@GIONO1_TH/8)+(@GIOP_TH/8) )*(260000/26))-(( @DITRE_TH *10000 +  @QUENQT_TH *10000 +  (@GIODS_TH + @GIOP1_TH)/8*10000 + @GIONO_TH /8*5000+ @GIONO1_TH /8*5000 + (@GIOLE_TH+@GIOR_TH+@GIOP_TH)/8*5000)),-3)
                    
			--		ELSE IF ( @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH  <= 8 ) 
			--			IF ((( @SONGAYCONG_TH  +(( @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH + @GIODs_TH )/8))*(260000/26))-(( @DITRE_TH *10000 +  @QUENQT_TH *10000 + 90000  +  (@GIODS_TH + @GIOP1_TH)/8*10000 ))< 0) 
			--				SET @PCCHUYENCAN = 0
			--			ELSE
			--				SET @PCCHUYENCAN = ROUND((( @SONGAYCONG_TH  +(( @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH + @GIODS_TH +@GIOP_TH )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 90000 + (@GIODS_TH + @GIOP1_TH)/8*10000+@GIOP_TH/8*5000 )),-3)
                 
			--		ELSE IF ( @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH >8 and  @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH <=16) 
			--			IF ((( @SONGAYCONG_TH  +(( @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH + @GIODs_TH )/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 170000  + (@GIODS_TH + @GIOP1_TH)/8*10000 ))<0 )
			--				SET @PCCHUYENCAN = 0
			--			ELSE
			--				SET @PCCHUYENCAN = ROUND((( @SONGAYCONG_TH  +(( @GIORO_TH + @GIOOM_TH + @GIOTNLD_TH + @GIODS_TH +@GIOP_TH)/8))*(260000/26))-(( @DITRE_TH *10000+ @QUENQT_TH *10000 + 170000  + (@GIODS_TH + @GIOP1_TH)/8*10000 +@GIOP_TH/8*5000)),-3)
			--		ELSE  
			--			SET @PCCHUYENCAN = 0 
			--ELSE IF  (@GIOTSKT_TH <> 0)       --------------TH: Thai sản, khám thai--------------
			--	IF  (@CHUYENCANDUOCHUONG_TH -(  @GIOTS_TH /8*(260000/26) + @GIOST_TH /8*(260000/26) +  @DITRE_TH *10000+ @QUENQT_TH *10000+( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH+ @GIONO1_TH + @GIOTNLD_TH + @GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH)/8*5000 + (@GIODS_TH + @GIOP1_TH)/8*10000)<0 )
			--		SET @PCCHUYENCAN = 0
			--	ELSE
			--		SET @PCCHUYENCAN = ROUND( @CHUYENCANDUOCHUONG_TH -(  @GIOTS_TH /8*(260000/26 ) + @GIOST_TH /8*(260000/26) + @DITRE_TH *10000+ @QUENQT_TH *10000+(( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH + @GIONO1_TH + @GIOTNLD_TH  + @GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH)/8*5000 + (@GIODS_TH + @GIOP1_TH)/8*10000)),0)
			--ELSE							  --------------TH: bình thường , đủ tháng--------------
			--	IF ( @CHUYENCANDUOCHUONG_TH -( @DITRE_TH *10000+ @QUENQT_TH *10000+( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH+ @GIONO1_TH +  @GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH)/8*5000 + (@GIODS_TH + @GIOP1_TH)/8*10000)<0 )
			--		SET @PCCHUYENCAN = 0
			--	ELSE
			--		SET @PCCHUYENCAN = ROUND( @CHUYENCANDUOCHUONG_TH -( @DITRE_TH *10000+ @QUENQT_TH *10000+(( @GIOP_TH + @GIOR_TH + @GIOLE_TH + @GIONO_TH+ @GIONO1_TH +  @GIODQ_TH + @GIOKHHGD_TH + @GIOTS1_TH)/8*5000 + (@GIODS_TH + @GIOP1_TH)/8*10000)),0)

			------------------------------------------------------------
			SET @TIENCHUYENCANTONG = @PCCHUYENCAN
	
			----Tỷ Bách
			--IF exists(SELECT  * FROM ST_LUONG WHERE ISNULL(L_HUONGCHUYENCAN,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG)
			--	SET @PCCHUYENCAN  = 0

			-- lấy bên bảng st_lương theo cấu trúc mới
			IF exists(SELECT  * FROM ST_LUONG WHERE L_KHONGHUONGCHUYENCAN = 1 AND NV_MA = @NV_MA )
				BEGIN
					SET @PCCHUYENCAN  = 0
					SET @TIENCHUYENCANTONG =0
				END

			IF exists(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
				BEGIN
					SET @PCCHUYENCAN  = 0
					SET @TIENCHUYENCANTONG =0
				END

			-- Andrew
			IF exists(SELECT  * FROM ST_NHANVIENKHONGPHUCAP WHERE NV_PCCHUYENCAN = 1 AND NV_MA = @NV_MA )
				BEGIN
					SET @PCCHUYENCAN  = 0
					SET @TIENCHUYENCANTONG =0
				END
			-------------

			--@CONGTT int
			SELECT @CONGTT = ROUND(ISNULL(ST_LUONG.L_CONGHS1,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@CONGCADEM int 
			SELECT @CONGCADEM = ROUND(ISNULL(ST_LUONG.L_CONGCADEM,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@HS2A int
			SELECT @HS2A = ROUND(ISNULL(ST_LUONG.L_CONGHS2A,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@HS1 FLOAT 
			SET @HS1 = @HS2A
			--@HS3 int
			SELECT @HS3 = ROUND(ISNULL( L_CONGHS3,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
				
			--@SONGAYCONG int
			SELECT @SONGAYCONG =(@CONGTT +@CONGCADEM + @HS2A + @HS3)/8 

			SELECT @SONGAYCONG = 0
			FROM ST_NHANVIEN
			WHERE NV_MA = @NV_MA AND DV_MA = 'KB'

				------Andrew---------------------
			IF @SONGAYCONG>26
				SELECT @SONGAYCONG27TINH26=26
			ELSE
				SELECT @SONGAYCONG27TINH26=@SONGAYCONG

			----@MOIKHD BIT -- Tỷ Bách
			--SELECT @MOIKHD =ISNULL(L_MOIKHD,0)
			--FROM ST_LUONG 
			--WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			------Andrew------
			SELECT @MOIKHD =ISNULL(L_MOIKHD,0) 
			FROM ST_LUONG
			WHERE ISNULL(L_HUONGLUONGKHD,0) = 1 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			------------------

			----@M_CHUYENCAN  float --Tỷ Bách
			--SET @M_CHUYENCAN = ROUND(@SONGAYCONG*@TIENCHUYENCANTONG/@SONGAYCONG_TH ,0)

			--@M_CHUYENCAN  float -- Andrew
			if ISNULL(@MOIKHD,0)= 0 
				if (@SONGAYCONG_TH>0 and (@SONGAYCONG>=0 or (@GIOP+ @GIORLE+@GIONV+@GIONO+@HS2+@HS3+@HS530)>0)) 
						SET @TIENCHUYENCAN=round((@PCCHUYENCAN * @SONGAYCONG)/@SONGAYCONG_TH,0)
				else if(@SONGAYCONG+@GIOP+ @GIORLE+@GIONV+@GIONO+@HS2+@HS3+@HS530>0) 
						SET @TIENCHUYENCAN=@PCCHUYENCAN 
				else SET @TIENCHUYENCAN=0
			else 
			SET @TIENCHUYENCAN=ROUND((@PCCHUYENCAN * @SONGAYCONG)/@SONGAYCONG_TH,0)
			SET @M_CHUYENCAN=@TIENCHUYENCAN

			--@GIOP int
			SELECT @GIOP = ROUND(ISNULL(ST_LUONG.L_NGHIP,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@GIOP1 int
			SELECT @GIOP1 = ROUND(ISNULL(ST_LUONG.L_NGHIP1,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--@GIOPT int
			SELECT @GIOPT = ROUND(ISNULL(ST_LUONG.L_NGHIPT,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--@GIOPo int
			SELECT @GIOPo = ROUND(ISNULL(ST_LUONG.L_NGHIPo,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@GIOPD int
			SELECT @GIOPD = ROUND(ISNULL(ST_LUONG.L_NGHIPD,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@LUONGCHINH float
			SELECT @LUONGCHINH = ROUND(ISNULL(L_LUONGCHINH,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			IF EXISTS(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB')
			SET @LUONGCHINH = 0

			--@M_LUONGCHINH float
			SET @M_LUONGCHINH = @LUONGCHINH
	
			--@HS2 int
			SELECT @HS2 = ROUND(ISNULL(ST_LUONG.L_CONGHS2,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@HS530 int
			SELECT @HS530 = ROUND(ISNULL( L_CONGHS530,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--@GIOR int
			SELECT @GIOR = ROUND(ISNULL(ST_LUONG.L_NGHIR,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@GIOR int
			SELECT @GIOR1 = ROUND(ISNULL(ST_LUONG.L_NGHIR1,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@GIOLE int
			SELECT @GIOLE = ROUND(ISNULL(ST_LUONG.L_NGHILE,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@GIONV int
			SELECT @GIONV = ROUND(ISNULL(ST_LUONG.L_NGUNGVIEC,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--@GIO FLOAT,
			SELECT @GIONO = ROUND(ISNULL(ST_LUONG.L_NGHINO,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG	
		
			--@GIO1 FLOAT,
			SELECT @GIONO1 = ROUND(ISNULL(ST_LUONG.L_NGHINO1,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG		
		
			--@PCTRACHNHIEM FLOAT
			SELECT @PCTRACHNHIEM = ISNULL(ST_LUONG.L_PCTRACHNHIEM,0)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG


			--lấy cách củ là lấy theo bảng nhân viên không phụ cấp. Giờ gán thẳng vào dbl lương nên không cần xét đoạn này
			--SELECT @PCTRACHNHIEM = 0
			--FROM ST_LUONG AS A INNER JOIN ST_NHANVIENKHONGPHUCAP AS B ON A.NV_MA = B.NV_MA
			--WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--AND ( 
			--A.L_PCTRACHNHIEM IS NULL 
			--	OR 
			--B.NV_PCTRACHNHIEM = 1  
			--	)

			--@M_CMON_CVIEC FLOAT
			SET @M_CMON_CVIEC = @PCTRACHNHIEM

			--@TIENPHUCAPKHAC FLOAT --Adrew
			SELECT @TIENPHUCAPKHAC = ISNULL(L_PHUCAPKHAC,0)+ISNULL(L_DQTV,0)+ISNULL(L_PCCC,0)+ISNULL(L_HD_TCBBHT,0)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			----PCKHAC_LONHON100 FLOAT -- Tỷ Thạc
			--SELECT @PCKHAC_LONHON100 = @TIENPHUCAPKHAC

			--PCKHAC_LONHON100 FLOAT --Andrew
			SELECT @PCKHAC_LONHON100 = @TIENPHUCAPKHAC

			IF @PCKHAC_LONHON100 >= 300000 
				SELECT @PCKHAC_LONHON100 = ROUND( @TIENPHUCAPKHAC /@SONGAYBT *( @SONGAYCONG  + @HS2A / 8 + ( @GIOP + @GIOR + @GIOR1+ @GIOLE + @GIONO) / 8 ),0) -- Andrew

			ELSE 
				SELECT @PCKHAC_LONHON100 = ROUND(@M_TIENBH_YT_XH_TN/@SONGAYBT*(@SONGAYBT - @GIOP1/8),0)

			SELECT @PCKHAC_LONHON100 = 0
			FROM ST_LUONG AS A INNER JOIN ST_NHANVIENKHONGPHUCAP AS B ON A.NV_MA = B.NV_MA
			WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
					AND ( A.L_PHUCAPKHAC IS NULL OR B.NV_PCKHAC = 1  )
		
		
		
			-- TIỀN VƯỢT SẢN LƯỢNG
			SELECT @M_HUONGVUOTSL = ISNULL(L_VUOTSL,0) , @M_HUONGLUONGKHD = ISNULL(L_HUONGLUONGKHD,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			--		IF  @M_HUONGVUOTSL = 1 AND (ISNULL({Command.L_HUONGLUONGKHD}) OR {Command.L_HUONGLUONGKHD} = FALSE)  THEN
			--    {@SOTIENVUOTSL}
			--ELSE iF {Command.L_HUONGLUONGKHD} = true AND (isnull({Command.L_VUOTSL}) OR {Command.L_VUOTSL} = FALSE) THEN
			--     {@SOTIENVUOTSL}
			--ELSE iF {Command.L_HUONGLUONGKHD} = true AND {Command.L_VUOTSL} = TRUE THEN
			--     {@SOTIENVUOTSL}
			--else 0

			IF ((@M_HUONGVUOTSL = 1 AND @M_HUONGLUONGKHD = 0) OR (@M_HUONGVUOTSL = 0 AND @M_HUONGLUONGKHD = 1)OR (@M_HUONGVUOTSL = 1 AND @M_HUONGLUONGKHD = 1))
				BEGIN
					SELECT @TIENVUOTSL = ISNULL(SOTIEN,0)
					FROM IT_TIENVUOTSANLUONG 
					WHERE NV_MA = @NV_MA AND T_MA = @T_MA 
				END
			ELSE 
				SET @TIENVUOTSL = 0
				SET @M_TIENVUOTSL = @TIENVUOTSL

			SELECT @M_TIENVUOTSL

			--lấy cách củ là lấy theo bảng nhân viên không phụ cấp. Giờ gán thẳng vào dbl lương nên không cần xét đoạn này
			--SELECT @PCKHAC_LONHON100 = 0
			--FROM ST_LUONG AS A INNER JOIN ST_NHANVIENKHONGPHUCAP AS B ON A.NV_MA = B.NV_MA
			--WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--AND ( A.L_PHUCAPKHAC IS NULL OR B.NV_PCKHAC = 1  )

			--@M_UUDAI float
			SELECT @M_UUDAI = @PCKHAC_LONHON100

			----@PCMOITRUONG-- Tỷ Bách
			--SET @PCMOITRUONG = ROUND((ISNULL(@SONGAYCONG+@GIOP1_TH/8 + @GIOPD_TH/8+ @GIOPT_TH/8,0))*1500,0)
		
			--@PCMOITRUONG-- Andrew
			SET @PCMOITRUONG =ROUND((ISNULL(@SONGAYCONG,0))*1500,0)
		
			--@TONTAI INT
			IF EXISTS(SELECT * FROM ST_NHANVIEN WHERE NV_MA = @NV_MA AND DV_MA = 'KB' )
			SET @PCMOITRUONG = 0

			----Tỷ Bách
			--IF EXISTS(SELECT L_PCMOITRUONG FROM ST_LUONG 
			--WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG and (L_PCMOITRUONG is null or L_PCMOITRUONG = 0))
			--SET @PCMOITRUONG = 0

			--Andrew
			IF EXISTS(SELECT * FROM ST_NHANVIENKHONGPHUCAP WHERE NV_MA = @NV_MA  AND NV_PCMOITRUONG = 1)
				SET @PCMOITRUONG = 0
		
			--DON VI TVKTX LÀ @PCMOITRUONG=39000
			IF EXISTS(SELECT NV_MA FROM ST_LUONG WHERE T_MA =@T_MA  AND NV_MA =@NV_MA AND DV_MA ='TVKTX')
			SET @PCMOITRUONG = 39000

			--@M_MOITRUONG FLOAT
			SET @M_MOITRUONG = @PCMOITRUONG

			--@PHUCAP FLOAT
			SELECT @PHUCAP = ISNULL(L_PCTRACHNHIEM,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@TIENPCDH FLOAT
			SELECT @TIENPCDH = ISNULL(L_PHUCAPDH,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@LUONG_PHUCAP FLOAT
			SET @LUONG_PHUCAP = @LUONGCHINH + @M_CMON_CVIEC + @M_UUDAI
			SET @LUONGPT_PHUCAP = 2900000 + @M_CMON_CVIEC + @M_UUDAI
			--@M_LUONG_TCCMON_CVIEC float
			SET @M_LUONG_TCCMON_CVIEC = @LUONG_PHUCAP
			--SET @M_LUONG_TCCMON_CVIEC_MT = @LUONG_PHUCAP + @M_MOITRUONG
	
			SELECT @M_LUONG_TCCMON_CVIEC = 0
			FROM ST_NHANVIEN
			WHERE NV_MA =@NV_MA AND DV_MA = 'KB'


			--@M_CONG_TT INT
			SET @M_CONG_TT = @SONGAYCONG 

			-- LAY MỨC LUONG DONG BHXH
			IF  (@PCMOITRUONG <= 0 or  @PCMOITRUONG is null)   
				SET @M_LUONG_BHXH = @LUONG_PHUCAP
			ELSE
				SET  @M_LUONG_BHXH = @LUONG_PHUCAP + 39000
	
			----Tỷ Bách
			--IF @SONGAYBT >= 26 
			--   SET @LUONGTHANG = ROUND( @SONGAYCONG * @M_LUONG_TCCMON_CVIEC / 26,0)
			--ELSE
			--   SET @LUONGTHANG = ROUND( @SONGAYCONG * @M_LUONG_TCCMON_CVIEC / @SONGAYBT,0)

			--Andrew
			SET @LUONGTHANG = ROUND((@SONGAYCONG)*( @LUONGCHINH + @PHUCAP + @TIENPHUCAPKHAC)/ @SONGAYBT27TINH26,0) 
			
			--@M_LUONGTHANG float
			SET @M_LUONGTHANG = @LUONGTHANG
				 --select    @SONGAYCONG,@LUONGTHANG,@SONGAYBT
		
			----@TIENBB FLOAT -- Tỷ Thạc
			--SELECT @TIENBB = ISNULL(TU_THUONGABC,0)
			--FROM V_TAMUNGTHANGSAU
			--WHERE NV_MA = @NV_MA AND THANGSAU = @T_MA

			--SELECT @TIENBB = 0
			--FROM ST_LUONG
			--WHERE ISNULL(L_HUONGLUONGKHD,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			----@TCBBHT FLOAT
		
			----cách curl lấy bên hđlđ
			----SELECT @TCBBHT = ISNULL(TCBBHT,0)
			----FROM ST_HOPDONGLAODONG
			----WHERE NV_MA = @NV_MA
			---- cách mới lấy thẳng bên ST_LUONG
			--SELECT @TCBBHT = ISNULL(L_HD_TCBBHT,0)
			--FROM ST_LUONG
			--WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			----cách củ xét cách mới đã xét lúc thêm vào ST_LUONG
			----IF not exists(SELECT  1 FROM ST_HOPDONGLAODONG WHERE NV_MA = @NV_MA )
		 ----   SET @TCBBHT  = 0
		
			----@M_BINHBAU  float 
			--SET @M_BINHBAU = @TIENBB + @TCBBHT

			--@TIENBB FLOAT ----------------------- Andrew---------
				SELECT @TIENBB = ISNULL(TU_THUONGABC,0)
				FROM V_TAMUNGTHANGSAU
				WHERE NV_MA = @NV_MA AND THANGSAU = @T_MA

				SELECT @TIENBB = 0
				FROM ST_LUONG
				WHERE ISNULL(L_HUONGLUONGKHD,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
	
				SELECT @MOIKHD =L_MOIKHD ---THANHTU
				FROM ST_LUONG
				WHERE ISNULL(L_HUONGLUONGKHD,0) = 1 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

				SELECT @L_HUONGLUONGKHD =L_HUONGLUONGKHD ---Andrew
				FROM ST_LUONG
				WHERE NV_MA = @NV_MA AND T_MA = @T_MA 

				SELECT @L_SONGAYLAMVIECKHIKHD=L_SONGAYLAMVIECKHIKHD
				FROM ST_LUONG
				WHERE ISNULL(L_HUONGLUONGKHD,0) = 1 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
				--@M_BINHBAU  float 
				if ISNULL(@MOIKHD,0)= 0
				SET @M_BINHBAU = @TIENBB
				else SET @M_BINHBAU = ROUND((@TIENBB *isnull( @L_SONGAYLAMVIECKHIKHD,0))/ @SONGAYBT,0)
			-----------------------------------------------------------
		
			--SELECT @M_LUONGTHANG, @SONGAYCONG, @M_CHUYENCAN, @M_MOITRUONG, @M_BINHBAU

			----Tính lương 1 Giờ --Tỷ Bách
			--IF @MOIKHD =1
			--	SET @TIENLUONG1GIO = ROUND((@M_LUONGTHANG/@SONGAYCONG + @M_CHUYENCAN/@SONGAYCONG + @M_MOITRUONG/@SONGAYCONG  + @M_BINHBAU/(@SONGAYCONG + (@GIOP + @GIOR + @GIOR1 +@GIOLE + @GIONV+ @GIOPT)/8)    )/8 ,0)
			--ELSE
			--	IF @SONGAYBT >= 26 
			--		SET @TIENLUONG1GIO = ROUND((@M_LUONGTHANG/@SONGAYCONG + @M_CHUYENCAN/@SONGAYCONG  + @M_MOITRUONG/@SONGAYCONG  + @M_BINHBAU/26   )/8 ,0)
			--	ELSE
			--		SET @TIENLUONG1GIO = ROUND((@M_LUONGTHANG/@SONGAYCONG + @M_CHUYENCAN/@SONGAYCONG  + @M_MOITRUONG/@SONGAYCONG  + @M_BINHBAU/@SONGAYBT   )/8 ,0)
			---------------------------------
			-------------------------Andrew-TinhLuong1Gio-----------------------
			IF(ISNULL(@MOIKHD,0)= 1 )--Mới KHD lại (Dòng thứ 2 của người có 2 dòng lương)		
				IF @SONGAYCONG <= 0
					SET @TIENLUONG1GIO=0 
				ELSE
					SET @TIENLUONG1GIO=ROUND((((@LUONGTHANG+@TIENCHUYENCAN+@PCMOITRUONG)/@SONGAYCONG27TINH26) + (@TIENBB/@SONGAYBT27TINH26))/8,0)
			ELSE --L_MOIKHD = false (CÓ 2 trường hợp: hoặc những người đang làm chưa có thay đổi HD hoặc, đang thử việc là dòng thứ 1 có 2 dòng lương
				IF @SONGAYCONG =0 --Không có ngày công
					SET @TIENLUONG1GIO=ROUND(((@TIENBB/@SONGAYBT27TINH26))/8,0) 
				ELSE			  --Có ngày công
					IF (ISNULL(@L_HUONGLUONGKHD,0)= 1 ) -- Đang làm chưa có thay đổi HD
						SET @TIENLUONG1GIO=ROUND((((@LUONGTHANG+@TIENCHUYENCAN+@PCMOITRUONG)/@SONGAYCONG27TINH26) + (@TIENBB/@SONGAYBT27TINH26))/8,0) 
					ELSE
						SET @TIENLUONG1GIO=ROUND(((@LUONGTHANG+@TIENCHUYENCAN+@PCMOITRUONG)/@SONGAYCONG27TINH26)/8,0) 

	
		   --SELECT @TIENLUONG1GIO

			UPDATE ST_LUONG
			SET L_TIENLUONG1GIO = @TIENLUONG1GIO
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			SELECT @M_TIENLUONG1GIO = L_TIENLUONG1GIO
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			SELECT @HS1 = ROUND(ISNULL(L_CONGHS1,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			SET @M_HS_1= @HS1
			--@HS15 INT
			SELECT @HS15 = ROUND(ISNULL(L_CONGHS15,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
		

			--@M_HS_15 FLOAT
			SET @M_HS_15= @HS15
		

			--@TCAHS4 INT
			SELECT @TCAHS4 = ROUND(ISNULL(ST_LUONG.L_CONGTCADEM,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@M_HS_195 INT
			SET @M_HS_195 = @TCAHS4

			--@HS2 INT
			SELECT @HS2 = ROUND(ISNULL(L_CONGHS2,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@M_HS_2  INT
			SET @M_HS_2  = @HS2

			--@HS3 INT
			SELECT @HS3 = ROUND(ISNULL( L_CONGHS3,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@M_HS_3 int
			SET @M_HS_3 = @HS3
		
			--@HS530 INT
			SELECT @HS530 = ROUND(ISNULL( L_CONGHS530,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@M_HS_530 int
			SET @M_HS_530 = @HS530

			--@GIOTS
			SELECT @GIOTS = ROUND(ISNULL(ST_LUONG.L_NGHITS,0),1)
			FROM ST_LUONG 
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			IF @HS3<>0 
				SET @GIOPR =0
			ELSE 
				IF @GIOTS <>0
					SET @GIOPR =0
				ELSE
					SELECT @GIOPR =@GIOP + @GIOR + @GIOR1

			--@TIENHS1 FLOAT
			SET @TIENHS1 = round(@TIENLUONG1GIO* @HS2A,0) 

			--@TIENHS15 FLOAT
			SET @TIENHS15 = round(@TIENLUONG1GIO* @HS15*1.5,0) 

			--@TIENHS2 FLOAT
			SET @TIENHS2 = round(@TIENLUONG1GIO* @HS2*2,0)
							
			--@TIENHS3 FLOAT
			SET @TIENHS3 = round(@TIENLUONG1GIO* @HS3 *3,0)
				
			--@TIENHS530 FLOAT
			SET @TIENHS530 = round(@TIENLUONG1GIO* @HS530 *5.3,0)

			--@TIENTCHS4 FLOAT 
			SET @TIENTCHS4 = round(@TIENLUONG1GIO* @TCAHS4 *2.45,0)

	
			SET @TIENLAMTHEM = @TIENHS1 + @TIENHS15 + @TIENHS2 + @TIENHS3 + @TIENHS530 + @TIENTCHS4 

			select @TIENLAMTHEM
			SET @M_TIENLAMTHEM = @TIENLAMTHEM

			--@GIOLAMDEM FLOAT
			SELECT @GIOLAMDEM = ROUND(ISNULL(L_CONGCADEM,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--@M_GIOLAMDEM  INT
			SET @M_GIOLAMDEM = @GIOLAMDEM

			--@TIENLAMDEM  FLOAT
			SET @TIENLAMDEM = ROUND(@M_GIOLAMDEM * @TIENLUONG1GIO *0.5,0)

			--@M_TIENLAMDEM  FLOAT
			SET @M_TIENLAMDEM = @TIENLAMDEM

			--@GIOKHAC FLOAT
			SELECT @GIOKHAC = ROUND(ISNULL(L_NGUNGVIEC,0),1)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@M_GIOKHAC  FLOAT
			SET @M_GIOKHAC = @GIOKHAC


			--@TIENNV FLOAT
			IF  @SONGAYBT >= 26
		 		SET @TIENNV =  ROUND((@GIOKHAC)*(@M_LUONG_TCCMON_CVIEC/(26*8)),0)
			ELSE 
				SET @TIENNV =  ROUND((@GIOKHAC)*(@M_LUONG_TCCMON_CVIEC/(@SONGAYBT*8)),0)
			IF  @SONGAYBT >= 26 
				SET @TIENP1 =  ROUND((@GIOP1)*(@M_LUONG_BHXH/(26*8)),0)
			ELSE
				SET @TIENP1 =  ROUND((@GIOP1)*(@M_LUONG_BHXH/(@SONGAYBT*8)),0)
			IF  @SONGAYBT >= 26 
				SET @TIENPo =  ROUND((@GIOPo)*(@M_LUONG_BHXH/(26*8)),0)
			ELSE
				SET @TIENPo =  ROUND((@GIOPo)*(@M_LUONG_BHXH/(@SONGAYBT*8)),0)
			IF  @SONGAYBT >= 26 
				SET @TIENPD =  ROUND((@GIOPD)*(@M_LUONG_BHXH/(26*8))*1.5,0)
			ELSE
				SET @TIENPD =  ROUND((@GIOPD)*(@M_LUONG_BHXH/(@SONGAYBT*8))*1.5,0)
			IF  @SONGAYBT >= 26 
				SET @TIENPT =  ROUND((@GIOPT)*(@LUONGPT_PHUCAP/(26*8)),0)
			ELSE
				SET @TIENPT =  ROUND((@GIOPT)*(@LUONGPT_PHUCAP/(@SONGAYBT*8)),0)
		   --TIEN HANH KINH----------------------------------------------
       
		   -- đã xét và insert lúc tính bên ST_LUONG
			--SET @TIENHK = 0
			--SELECT @SODONGKHD = COUNT(NV_MA)
			--FROM ST_LUONG
			--WHERE NV_MA = @NV_MA AND T_MA = @T_MA GROUP BY NV_MA
		
			--IF @SODONGKHD = 1 
			--   BEGIN
			--        UPDATE ST_LUONG
			--        SET L_HUONGHANHKINH = 1
			--        WHERE NV_MA = @NV_MA AND T_MA = @T_MA
			--   END	 
			--SELECT  @GIOR , @GIOLE , @GIOP
			SELECT @M_HUONGLUONGKHD = ISNULL(L_HUONGLUONGKHD,0) , @M_HUONGHANHKINH = ISNULL(L_HUONGHANHKINH,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			IF ((@M_HUONGHANHKINH = 1 AND @M_HUONGLUONGKHD = 0) OR (@M_HUONGHANHKINH = 0 AND @M_HUONGLUONGKHD = 1)OR (@M_HUONGHANHKINH = 1 AND @M_HUONGLUONGKHD = 1))
				 BEGIN
					SELECT @GIOHK = ISNULL(TONGSOGIO,0) 
					from IT_SOGIONGHIHANHKINH
					where NV_MA=@NV_MA 
					AND NAM = RIGHT(@T_Ma,4) AND THANG = CASE WHEN LEFT(LEFT(@T_Ma,2),1) = 0 THEN RIGHT(LEFT(@T_Ma,2),1) ELSE LEFT(@T_Ma,2) END
				 END
			ELSE 
				SET @GIOHK = 0

			IF ((@M_HUONGHANHKINH = 1 AND @M_HUONGLUONGKHD = 0) OR (@M_HUONGHANHKINH = 0 AND @M_HUONGLUONGKHD = 1) OR (@M_HUONGHANHKINH = 1 AND @M_HUONGLUONGKHD = 1))
				 BEGIN
						--IF  @SONGAYBT >= 26
 					--		SET @TIENHK =  ROUND(@GIOHK*@TIENLUONG1GIO,0)
						--ELSE 
							SET @TIENHK =  ROUND(@GIOHK*@TIENLUONG1GIO,0)
							--SET @TIENHK =  ROUND((@GIOHK)*(@M_LUONG_TCCMON_CVIEC/(@SONGAYBT*8)),0)
				 END
			ELSE 
				SET @TIENHK = 0

			IF (@CONGTT_TH + @CONGCADEM_TH < 24) 
				BEGIN
					SET @TIENHK = 0
					SET @GIOHK = 0
				END
			SET @M_GIOHK = @GIOHK 
			SET @M_TIENHK = @TIENHK
			SET @TIENKHAC = 0
			SET @M_TIENKHAC = @TIENKHAC
			SET @GIORLE = @GIOLE + @GIOR 
			SET @M_GIO_R_LE = @GIORLE
			SET @M_R1 =  @GIOR1 

			IF  @SONGAYBT >= 26 
				SET @TIENPR = ROUND((@GIOR1+ @GIOR + @GIOLE + @GIOP)*( @M_LUONG_TCCMON_CVIEC /(26*8)),0)
			ELSE 
				SET @TIENPR = ROUND(( @GIOR1+ @GIOR + @GIOLE + @GIOP)*( @M_LUONG_TCCMON_CVIEC /(@SONGAYBT*8)),0)

			SET @M_TIENNGHI_R_LE = ISNULL(@TIENPR,0) + ISNULL(@TIENNV,0)+ ISNULL(@TIENP1,0)+ ISNULL(@TIENPo,0) + ISNULL(@TIENPD,0)+ ISNULL(@TIENPT,0)
		
			SET @M_PHEPNAM = @GIOP
			SET @M_P1 = @GIOP1
			SET @M_Po = @GIOPo
			SET @M_PD = @GIOPD
			SET @M_PT = @GIOPT
			SELECT @TIENNUOICON6T=ISNULL(L_TIENNUOICON6T,0) FROM ST_LUONG WHERE NV_MA=@NV_MA AND T_MA=@T_MA AND L_LUONGCHINH=@LUONG_TU_ST_LUONG
		
			SELECT @TIENNUOICON6T=0 
			FROM ST_LUONG WHERE NV_MA=@NV_MA AND T_MA=@T_MA AND L_LUONGCHINH=@LUONG_TU_ST_LUONG AND ISNULL(L_HUONGLUONGKHD,0)=0
			IF  @SONGAYBT >= 26 		 
				 SET @M_TIENNUOICON6T= ROUND(@TIENNUOICON6T,0)
			ELSE 
				 SET @M_TIENNUOICON6T= ROUND(@TIENNUOICON6T,0)
		
			SET @M_TIENPHEPNAM=0

			--@M_TIEN_NTRO_KHAC_SHP float
			SELECT @CONGKHAC = ISNULL(ST_LUONG.L_CONGKHAC,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
			-- PHÚC LỢI
			SELECT @PHUCLOI = ISNULL(ST_LUONG.L_PHUCLOI,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
				-- HỔ TRỢ NGOÀI GIỜ
			SELECT @HTNGOAIGIO = ISNULL(ST_LUONG.L_HTNGOAIGIO ,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			--cách củ lấy bên hđlđ
			--HD_PHUCAPKHAC FLOAT trong HDLD
			--SELECT @HD_PHUCAPKHAC = ISNULL(HD_PHUCAPKHAC,0)+ISNULL(HD_TrocapHMPT,0)+ISNULL(TCBBTHANG,0)+ISNULL(HD_TCCHAMLOGIADINH,0)+ISNULL(HD_TCHOTRODONGPHUC,0)
			--FROM ST_HOPDONGLAODONG
			--WHERE NV_MA = @NV_MA
			IF @SONGAYBT >= 26 
					SET @PHUCLOI_HTNGOAIGIO  = 	round( (@SONGAYCONG+(@GIOLE+@GioP+@GIOR +@GIOR1)/8) *(@PHUCLOI + @HTNGOAIGIO) /26,0)
				 ELSE
					 SET @PHUCLOI_HTNGOAIGIO  = 	round( (@SONGAYCONG+(@GIOLE+@GioP+@GIOR +@GIOR1)/8) *(@PHUCLOI + @HTNGOAIGIO) /@SONGAYBT,0)
			   
		
			-- @CONGKHAC_CN
			SET @CONGKHAC_CN = @CONGKHAC + @PHUCLOI_HTNGOAIGIO
		
		
			--IF not exists(SELECT  1 FROM ST_HOPDONGLAODONG WHERE NV_MA = @NV_MA )
		 --   SET @HD_PHUCAPKHAC  = 0
		
			-- cách mới lấy bên ST_LUONG
			SELECT @HD_PHUCAPKHAC = ISNULL(ST_LUONG.L_HD_PHUCAPKHAC,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
		
		
		
			IF @SONGAYBT >= 26 
					SET @CONGKHAC_PCN  = 	round( (@SONGAYCONG+(@GIOLE+@GioP+@GIOP1 +@GIOR1)/8) *@HD_PHUCAPKHAC /26,0)
				 ELSE
					 SET @CONGKHAC_PCN  = 	round( (@SONGAYCONG+(@GIOLE+@GioP+@GIOP1 +@GIOR1)/8) *@HD_PHUCAPKHAC /@SONGAYBT,0)
			   
	
		
			SET @M_TIEN_NTRO_KHAC_SHP = @CONGKHAC_CN + @CONGKHAC_PCN
		
			IF @GIOP1 + @GIOPo + @GIOPD > 0
				IF  @SONGAYBT = 24
				   SET @M_TIEN_NTRO_KHAC_SHP_ = @M_TIEN_NTRO_KHAC_SHP - ( @GIOPo )/8*25000
				ELSE IF  @SONGAYBT = 25
				   SET @M_TIEN_NTRO_KHAC_SHP_ = @M_TIEN_NTRO_KHAC_SHP - ( @GIOPo )/8*24000
				ELSE 
				   SET @M_TIEN_NTRO_KHAC_SHP_ = @M_TIEN_NTRO_KHAC_SHP - (@GIOPo )/8*23077
			ELSE SET @M_TIEN_NTRO_KHAC_SHP_ = @M_TIEN_NTRO_KHAC_SHP


			--@SOPHANCOM FLOAT
			SELECT @SOPHANCOM = ISNULL(ST_LUONG.L_SOPHANCOM,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			SELECT @SOPHANCOM = 0
			FROM ST_NHANVIEN
			WHERE NV_MA = @NV_MA AND DV_MA = 'KB'

			--@M_SOPHANCOM  FLOAT
			SET  @M_SOPHANCOM  = @SOPHANCOM
	
			----@TIENCOM FLOAT -- Tỷ Bách
			--SET @TIENCOM = @M_SOPHANCOM * 11300
			
			--@TIENCOM FLOAT - Andrew
			if(@M_DV_MA='HCM-BAOVE' OR @M_DV_MA='HCM-HR' OR @M_DV_MA='HCM-KCS' OR @M_DV_MA='HCM-KHAITHAC' OR @M_DV_MA='HCM-KVT' 
					OR @M_DV_MA='HCM-MAY' OR @M_DV_MA='HCM-NGHIEPVU' OR @M_DV_MA='HCM-NS' OR @M_DV_MA='HCM-PHONGRAP' OR @M_DV_MA='HCM-PM' 
					OR @M_DV_MA='HCM-SOP' OR @M_DV_MA='HCM-SQ' OR @M_DV_MA='HCM-THUMUA' OR @M_DV_MA='HCM-TONGVU' OR @M_DV_MA='HCM-TVKTX' 
					OR @M_DV_MA='HCM-TVX' OR @M_DV_MA='HCM-TX' OR @M_DV_MA='HCM-BAOGIA' OR @M_DV_MA='HCM-INNOVATION'	)
				SET @TIENCOM = @M_SOPHANCOM * 21500
			else
				SET @TIENCOM = @M_SOPHANCOM * 20000

			--@M_TIENCOM float
			SET @M_TIENCOM = @TIENCOM

			--@M_23PT_BH_PHEP float
			--	@TRABH_P_TH FLOAT
			SELECT @TRABH_P_TH  = ISNULL(L_TraBH_P,0)
			FROM ST_LUONG where nv_ma=@nv_ma and t_ma=@t_ma and l_luongchinh=@LUONG_TU_ST_LUONG
			--cách củ xét bên hđlđ cách mới không cần vì bên st_lương đã xét rồi
			--IF not exists (SELECT * FROM ST_HOPDONGLAODONG , ST_NHANVIEN WHERE ST_HOPDONGLAODONG.NV_MA=@NV_MA AND month(hd_ngayky)=convert(int,left(@t_ma,2)) and year(hd_ngayky)=convert(int,right(@t_ma,4)) and day(hd_ngayky)>=15 AND ST_HOPDONGLAODONG.NV_MA=ST_NHANVIEN.NV_MA AND DATEDIFF(MONTH,NV_NGAYVAO,HD_NGAYKY)<12)
			--	IF exists(SELECT * FROM  ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND ( NV_MA = '00100' OR L_HUONGLUONGKHD = 1 OR ISNULL(L_DuocTraBH_P,0) = 0) )
			--	SET @TRABH_P_TH = 0

	---------------------------------------------------------------- 
			--Huong 23PT_BH_P=0 khi L_Dtra_BH_P =0
			SELECT @L_TraBH_P=isnull(L_DuocTraBH_P,0) from ST_LUONG where nv_ma=@nv_ma and t_ma=@t_ma AND ST_LUONG.L_LUONGCHINH=@LUONG_TU_ST_LUONG

			IF @L_TraBH_P=0 
			SET @TRABH_P_TH = 0
			------------------
			SET  @M_23PT_BH_PHEP = @TRABH_P_TH
		
	
			--@TIENLAMTHEMTINHTHUE FLOAT 
			SET @TIENLAMTHEMTINHTHUE = ROUND((@HS15 + @HS2  + @HS530 + @TCAHS4)* @TIENLUONG1GIO,0)
			--@M_TIENLAMTHEMTINHTHUE FLOAT
			SET @M_TIENLAMTHEMTINHTHUE =@TIENLAMTHEMTINHTHUE

			--@CONGLUONGTINHTHUE FLOAT
			SET @CONGLUONGTINHTHUE =  ISNULL(@LUONGTHANG,0) + ISNULL(@TRABH_P_TH,0) + ISNULL(@M_BINHBAU,0)
									+ ISNULL(@TIENLAMTHEMTINHTHUE,0)+ @M_TIENNGHI_R_LE + @M_TIENKHAC 		
									+ ISNULL(@M_CHUYENCAN,0)+ISNULL(@PCMOITRUONG,0) 
									+ ISNULL(@M_TIEN_NTRO_KHAC_SHP_,0)+ISNULL (@TIENNUOICON6T,0)+ ISNULL(@TIENHK,0)+ISNULL(@M_TIENVUOTSL,0) -- Andrew ko biết có nên đưa tiền cơm vào không
								

			--@M_CONGLUONGTINHTHUE
			SET @M_CONGLUONGTINHTHUE = @CONGLUONGTINHTHUE


			--@CONGLUONG FLOAT 
			select @LUONGTHANG,@TRABH_P_TH,@M_BINHBAU,@M_TIENLAMDEM,@M_TIENLAMTHEM,@M_TIENKHAC,@M_TIENNGHI_R_LE,@M_CHUYENCAN,@PCMOITRUONG
					,@TIENPCDH,@M_TIEN_NTRO_KHAC_SHP_,@M_TIENNUOICON6T,@TIENHK,@M_TIENVUOTSL,@M_TIENCOM
			SET @CONGLUONG = ISNULL(@LUONGTHANG,0) + ISNULL(@TRABH_P_TH,0) + ISNULL(@M_BINHBAU,0) + ISNULL(@M_TIENLAMDEM,0)
						+ ISNULL(@M_TIENLAMTHEM,0) + ISNULL(@M_TIENKHAC,0) + ISNULL(@M_TIENNGHI_R_LE,0) 
						+ ISNULL(@M_CHUYENCAN,0) + ISNULL(@PCMOITRUONG,0)
						+ ISNULL(@TIENPCDH,0) + ISNULL(@M_TIEN_NTRO_KHAC_SHP_,0)
						+ ISNULL (@M_TIENNUOICON6T,0)+ ISNULL(@TIENHK,0)+ ISNULL(@M_TIENVUOTSL,0)+ROUND(@M_TIENCOM,0) -- Andrew

	--SELECT  ISNULL(@LUONGTHANG,0) , ISNULL(@TRABH_P_TH,0) , ISNULL(@M_BINHBAU,0) , ISNULL(@M_TIENLAMDEM,0)
	--					, ISNULL(@M_TIENLAMTHEM,0), ISNULL(@M_TIENKHAC,0) ,ISNULL(@M_TIENNGHI_R_LE,0) 
	--					, ISNULL(@M_CHUYENCAN,0) , ISNULL(@PCMOITRUONG,0)
	--					, ISNULL(@TIENPCDH,0) , ISNULL(@M_TIEN_NTRO_KHAC_SHP_,0)
	--					, ISNULL (@M_TIENNUOICON6T,0), ISNULL(@TIENHK,0), ISNULL(@M_TIENVUOTSL,0)
			--@M_CONGLUONG float
			SET @M_CONGLUONG = @CONGLUONG
			SELECT @CONGLUONG
			SELECT @TAMUNG = ISNULL(L_TAMUNG,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
	
			--@M_DATAMUNG  float
			SET @M_DATAMUNG = @TAMUNG 

			--@THUETN FLOAT 
			SELECT @THUETN = ISNULL(ST_LUONG.L_ThueTNCN,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			SELECT @THUETN = 0
			FROM ST_LUONG AS A INNER JOIN ST_NHANVIEN AS B ON A.NV_MA = B.NV_MA
			WHERE A.NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
			AND (  L_HUONGCHUYENCAN IS NULL OR  L_HUONGCHUYENCAN = 0  OR   L_HUONGLUONGKHD IS NULL OR L_HUONGLUONGKHD = 0  )
	
			--@M_THUETHUNHAP  float
			SET @M_THUETHUNHAP = @THUETN

			--@BHXH FLOAT
			SELECT @BHXH = ISNULL(L_BHXH,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@BHYT FLOAT
			SELECT @BHYT = ISNULL(L_BHYT,0)
			FROM ST_LUONG
			WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG

			--@M_LUONG_BHXH float
			IF  NOT EXISTS(SELECT L_PCMOITRUONG FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG and (L_PCMOITRUONG is null or L_PCMOITRUONG = 0))
					SET @M_LUONG_BHXH = @M_LUONG_TCCMON_CVIEC +39000
			ELSE
					SET @M_LUONG_BHXH = @M_LUONG_TCCMON_CVIEC 
				
			--@TIENBHXH FLOAT
			IF EXISTS(SELECT * FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA IN ('T','T01','TST','T01ST') )
			SET @TIENBHXH = ROUND(@M_LUONG_BHXH*0.08,0)
	
			IF ( @SONGAYCONG + ( @GIOLE /8) + ( @GIOPR /8) <15 ) 
			SET @TIENBHXH = 0

			IF EXISTS( SELECT * FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA NOT IN ('T','T01','TST','T01ST') )
			SET @TIENBHXH = ROUND(@M_LUONG_BHXH* 0.08,0)

			IF (@BHXH = 0)
			SET @TIENBHXH = 0

			--@TIENBHYT FLOAT
			IF EXISTS(SELECT * FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA IN ('T','T01','TST','T01ST') )
			SET @TIENBHYT = ROUND(@M_LUONG_BHXH*0.015,0)
	
			IF ( @SONGAYCONG + ( @GIOLE /8) + ( @GIOPR /8) <15 ) 
			SET @TIENBHYT = 0
	
			IF EXISTS(SELECT * FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA NOT IN ('T','T01','TST','T01ST') )
			SET @TIENBHYT = ROUND(@M_LUONG_BHXH*0.015,0)

			IF (@BHYT = 0)
			SET @TIENBHYT = 0

			--@TIENBHTN FLOAT
			IF EXISTS(SELECT * FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA IN ('T','T01','TST','T01ST') )
			SET @TIENBHTN = ROUND(@M_LUONG_BHXH * 0.01,0)
	
			IF ( @SONGAYCONG + ( @GIOLE /8) + ( @GIOPR /8) <15 ) 
			 SET @TIENBHTN = 0
	
			IF EXISTS(SELECT * FROM ST_LUONG WHERE NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG AND DV_MA NOT IN ('T','T01','TST','T01ST') )
			SET @TIENBHTN = ROUND(@M_LUONG_BHXH * 0.01,0)

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
		

			IF EXISTS(SELECT * FROM ST_LUONG WHERE ISNULL(L_HUONGLUONGKHD,0) = 0 AND NV_MA = @NV_MA AND T_MA = @T_MA AND L_LUONGCHINH = @LUONG_TU_ST_LUONG)
			SET @TIENCD = 0

			IF (@NV_MA = '00100') 
			SET @TIENCD = 0


			--@M_TIENCONGDOAN float
			SET @M_TIENCONGDOAN = @TIENCD
			
			--@M_TRUMOBIVI
			SET @MAXTRUMOBIVI =ROUND ((@CONGLUONG*0.3) - (@TAMUNG + @THUETN + @TIENBH + ISNULL(@TIENCD,0)),-3)
			--select @CONGLUONG AS congluong,@TAMUNG AS tamung,@THUETN AS thncn,@TIENBH AS baohiem, @TIENCD AS tiencd, @MAXTRUMOBIVI as maxx,@TRUMOBIVI AS nhap

			if @TRUMOBIVI IS null 
				BEGIN 
					SET @M_TRUMOBIVI = 0
					SET @TRUMOBIVI_VUOT =0
				END
			ELSE 
				IF @MAXTRUMOBIVI>0
					BEGIN
						IF @TRUMOBIVI <= @MAXTRUMOBIVI
							BEGIN
								SET @M_TRUMOBIVI = @TRUMOBIVI
								SET @TRUMOBIVI_VUOT =0
							END 
						ELSE
							BEGIN
								SET @M_TRUMOBIVI = @MAXTRUMOBIVI
								SET @TRUMOBIVI_VUOT =@TRUMOBIVI -@MAXTRUMOBIVI
							END 
					END 
				ELSE 
					BEGIN 
						SET @M_TRUMOBIVI = 0
						SET @TRUMOBIVI_VUOT =@TRUMOBIVI
					END
			
				
			UPDATE ST_LUONG
			SET L_TRUMOBIVI = 0
			WHERE NV_MA = @NV_MA 
			AND T_MA = @T_MA 
				
			UPDATE ST_LUONG
			SET L_TRUMOBIVI = @M_TRUMOBIVI
			WHERE NV_MA = @NV_MA 
			AND T_MA = @T_MA 
			AND L_LUONGCHINH = @LUONG_TU_ST_LUONG
				
			UPDATE IT_MOBIVI
			SET MB_SoTien_Vuot = @TRUMOBIVI_VUOT
			WHERE NV_MA = @NV_MA 
			AND T_MA = @T_MA

			SELECT @CONGLUONG
			--@LANHCUOIKY
			SET @LANHCUOIKY = ROUND( @CONGLUONG - @TAMUNG - @TIENBH - @THUETN - ISNULL(@TIENCD,0)- @M_TRUMOBIVI ,0)
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
		

			SELECT L_NGHILE = @L_NGHILE
	
			INSERT INTO [IT_BANGLUONGMOI]
			([X_MA],[DV_MA],[DV_TEN],[NAM],[THANG],[TUNGAY],[DENNGAY],[HOTEN],[SOTHE],[T_MA],[LUONGCHINH]
			,[MASOTHUE],[SOTAIKHOAN],[CMON_CVIEC],[UUDAI],[CHUYENCAN],[MOITRUONG],[LUONG_TCCMON_CVIEC]
			,[CONG_TT],[LUONGTHANG],[HS_1],[HS_15],[HS_195],[HS_2],[HS_3],[TIENLAMTHEM],[GIOLAMDEM]
			,[TIENLAMDEM],[TIENNUOICON6T],[GIOKHAC],[TIENKHAC],[GIO_R_LE],[TIENNGHI_R_LE],[PHEPNAM],[TIENPHEPNAM]
			,[TIEN_NTRO_KHAC_SHP],[SOPHANCOM],[TIENCOM],[BINHBAU],[23PT_BH_PHEP],[CONGLUONG]
			,[DATAMUNG],[THUETHUNHAP],[TIENBH_YT_XH_TN],[TIENCONGDOAN],[CONLANHCUOIKY],[THUCLANH],[KYNHAN],[GHICHU],[CV_MA],[TT_CV],[CONGLUONGTINHTHUE],[TIENLAMTHEMTINHTHUE],HS530,TIEN_HS530 , TRUMOBIVI, NGHIP1 , NGHIPo, NGHIPD, GIOPT, GIOHK, TIENHK, TIENVUOTSL, L_TIENLUONG1GIO, NGHI_R1 )
			 VALUES
			(@M_X_MA,@M_DV_MA,@M_DV_TEN,@M_NAM,@M_THANG,@M_TUNGAY,@M_DENNGAY,@M_HOTEN,@M_SOTHE,@M_T_MA,@M_LUONGCHINH
			,@M_MASOTHUE,@M_SOTAIKHOAN,@M_CMON_CVIEC,@M_UUDAI,@M_CHUYENCAN,@M_MOITRUONG,@M_LUONG_TCCMON_CVIEC
			,@M_CONG_TT,@M_LUONGTHANG,@M_HS_1,@M_HS_15,@M_HS_195,@M_HS_2,@M_HS_3,@M_TIENLAMTHEM,@M_GIOLAMDEM,@M_TIENLAMDEM,@M_TIENNUOICON6T
			,@M_GIOKHAC,@M_TIENKHAC,@M_GIO_R_LE,@M_TIENNGHI_R_LE,@M_PHEPNAM,@M_TIENPHEPNAM
			,@M_TIEN_NTRO_KHAC_SHP_,@M_SOPHANCOM,@M_TIENCOM,@M_BINHBAU,ROUND(@M_23PT_BH_PHEP,0),ROUND(@M_CONGLUONG,0)
			,@M_DATAMUNG,@M_THUETHUNHAP,@M_TIENBH_YT_XH_TN,@M_TIENCONGDOAN,@M_CONLANHCUOIKY,@M_THUCLANH,@M_KYNHAN,@M_GHICHU,@M_CONGVIEC, @M_TTCV, @M_CONGLUONGTINHTHUE, @M_TIENLAMTHEMTINHTHUE, @M_HS_530,@TIENHS530, @M_TRUMOBIVI, @M_P1, @M_Po, @M_PD, @M_PT, @GIOHK, @M_TIENHK,@M_TIENVUOTSL, @M_TIENLUONG1GIO, @M_R1)

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

						SELECT @NV_TS = SOTHE FROM ST_NHANVIENNGHIPHEP INNER JOIN IT_BANGLUONGMOI ON NV_MA = SOTHE AND T_MA=@T_MA
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
							SELECT @NV_TS =  SOTHE FROM ST_NHANVIENNGHIPHEP INNER JOIN IT_BANGLUONGMOI ON NV_MA = SOTHE AND T_MA=@T_MA
							WHERE NV_MA=@NV_MA
								 AND NP_MA='TS' 
								 AND ISNULL(CONG_TT,0)=0 --AND (ISNULL(GIO_R_LE,0)+ ISNULL(PHEPNAM,0) =0)
								 AND NP_TUNGAY =@NGHI_TS_TUNGAY
								 AND CONVERT(INT, LEFT(@T_MA,2)) >= MONTH(@NGHI_TS_TUNGAY)
								 AND (YEAR(@NGHI_TS_TUNGAY) =CONVERT(INT, RIGHT(@T_MA,4)) OR YEAR(@NGHI_TS_DENNGAY)=CONVERT(INT, RIGHT(@T_MA,4)))

						IF CONVERT(INT, RIGHT(@T_MA,4))=YEAR(@NGHI_TS_DENNGAY)
							SELECT  @NV_TS = SOTHE FROM ST_NHANVIENNGHIPHEP INNER JOIN IT_BANGLUONGMOI ON NV_MA = SOTHE AND T_MA=@T_MA
							WHERE NV_MA=@NV_MA 
								 AND NP_MA='TS' 
								 AND ISNULL(CONG_TT,0)=0 --AND (ISNULL(GIO_R_LE,0)+ ISNULL(PHEPNAM,0) =0)
								 AND NP_TUNGAY =@NGHI_TS_TUNGAY
								 AND CONVERT(INT, LEFT(@T_MA,2)) <= MONTH(@NGHI_TS_DENNGAY)
								 AND (YEAR(@NGHI_TS_TUNGAY) =CONVERT(INT, RIGHT(@T_MA,4)) OR YEAR(@NGHI_TS_DENNGAY)=CONVERT(INT, RIGHT(@T_MA,4)))

					END
					--XOA NHAN VIEN NAY TRONG IT_BANGLUONGMOI
					if @GIORLE =0 and @GIOP =0 
						DELETE FROM IT_BANGLUONGMOI WHERE SOTHE=@NV_TS AND T_MA=@T_MA 
				END

				FETCH NEXT FROM CUR_LUONGCHINH INTO @LUONG_TU_ST_LUONG  
			END

	CLOSE CUR_LUONGCHINH						-- Đóng Cursor
	DEALLOCATE CUR_LUONGCHINH					-- Giải phóng tài nguyên
-------------------------------------------Hết con trỏ CUR_LUONGCHINH -------------------------------------------



-----------------------------------------bắt đầu cộng 2 dòng lương ----------------------------------------------

-------------------------------------------Con trỏ CUR_LUONGCHINH_MOI -------------------------------------------
	--TAO CURSOR MOI CHUA LUONG CHINH
	--DUYET CURSOR:CONG CAC THONG SO
	--XOA DONG CU TRONG IT_BANGLUONGMOI 
	--INSERT CAC THONG SO VUA CONG VAO IT_BANGLUONGMOI

   SELECT @SODONG=COUNT(*) FROM IT_BANGLUONGMOI WHERE SOTHE=@NV_MA AND T_MA=@T_MA
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
		SET @M_P1 = 0
		SET @M_GIOHK = 0
		SET @M_TIENNGHI_R_LE =0
		SET @M_TIENHK =0
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
		SET @M_HS_1=0
		SET @M_HS_15=0
		SET @M_HS_195 =0
		SET @M_HS_2=0
		SET @M_HS_3 =0
		SET @M_HS_530  =0
		SET @M_LUONGTHANG=0
		SET @TAMUNG =0
		SET @M_CHUYENCAN =0
		SET @M_BINHBAU =0
		SET @TIENBH =0
		SET @THUETN =0
		SET @TIENCD =0
		SET @CONGKHAC_CN =0
		SET @CONGKHAC =0
		SET @PHUCLOI =0
		SET @HTNGOAIGIO =0
		SET @CONGKHAC_PCN =0
		SET @M_LUONGTHANG =0
		SET @M_CONGLUONGTINHTHUE = 0
		SET @M_TIENLAMTHEMTINHTHUE =0
		SET @M_TIENLUONG1GIOTC =0

		DECLARE CUR_LUONGCHINH_MOI
		CURSOR FOR SELECT DISTINCT LUONGCHINH FROM IT_BANGLUONGMOI
		WHERE SOTHE=@NV_MA and T_MA=@T_MA

		OPEN CUR_LUONGCHINH_MOI

		FETCH NEXT FROM CUR_LUONGCHINH_MOI
		INTO @LUONG_TU_IT_BANGLUONGMOI
		WHILE (@@FETCH_STATUS = 0)
		BEGIN

			SELECT @M_TIENBH_YT_XH_TN = @M_TIENBH_YT_XH_TN +ISNULL(TIENBH_YT_XH_TN,0) FROM IT_BANGLUONGMOI
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_THUETHUNHAP =@M_THUETHUNHAP +ISNULL(THUETHUNHAP,0)  FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			--SELECT @M_23PT_BH_PHEP =ISNULL(L_TRABH_P,0) FROM v_BangluongTH where nv_ma=@NV_MA AND T_MA=@T_MA
			SELECT @M_23PT_BH_PHEP =@M_23PT_BH_PHEP +ISNULL([23PT_BH_PHEP],0)  FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_TIENCOM = @M_TIENCOM + ISNULL(TIENCOM,0) FROM IT_BANGLUONGMOI
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_SOPHANCOM = @M_SOPHANCOM +ISNULL(SOPHANCOM,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_TIENPHEPNAM = @M_TIENPHEPNAM + ISNULL(TIENPHEPNAM,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_PHEPNAM = @M_PHEPNAM+ISNULL(PHEPNAM,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_P1 = @M_P1 + ISNULL(NGHIP1,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_TIENNGHI_R_LE= @M_TIENNGHI_R_LE + ISNULL(TIENNGHI_R_LE,0) FROM IT_BANGLUONGMOI
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			---HANH KINH
			SELECT @M_GIOHK = @M_GIOHK + ISNULL(GIOHK,0) FROM IT_BANGLUONGMOI
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI


			SELECT @M_TIENHK = @M_TIENHK + ISNULL(TIENHK,0) FROM IT_BANGLUONGMOI
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI


			SELECT @M_GIO_R_LE = @M_GIO_R_LE+ ISNULL(GIO_R_LE,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_TIENKHAC =@M_TIENKHAC +ISNULL(TIENKHAC,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_GIOKHAC =@M_GIOKHAC +ISNULL(GIOKHAC,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_TIENNUOICON6T = @M_TIENNUOICON6T+ ISNULL(TIENNUOICON6T,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_GIOLAMDEM= @M_GIOLAMDEM+ ISNULL(GIOLAMDEM,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_LUONGTHANG = @M_LUONGTHANG + ISNULL(LUONGTHANG,0)  FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_CONG_TT = @M_CONG_TT + ISNULL(CONG_TT,0)  FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_MOITRUONG = @M_MOITRUONG + ISNULL(MOITRUONG,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_UUDAI= ISNULL(UUDAI,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_CMON_CVIEC=ISNULL(CMON_CVIEC,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_HS_1 =@M_HS_1+ISNULL(HS_1,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_HS_15 =@M_HS_15+ISNULL(HS_15,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_HS_195 =@M_HS_195 +ISNULL(HS_195,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_HS_2 =@M_HS_2 +ISNULL(HS_2,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_HS_3 =@M_HS_3 +ISNULL(HS_3,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_HS_530  =@M_HS_530  +ISNULL(HS530,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_TIENLAMTHEM = @M_TIENLAMTHEM+ ISNULL(TIENLAMTHEM,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
	
			SELECT @M_TIENLAMDEM = @M_TIENLAMDEM+ ISNULL(TIENLAMDEM,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
 
			SELECT @M_BINHBAU = @M_BINHBAU+ ISNULL(BINHBAU,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_CHUYENCAN = @M_CHUYENCAN+ ISNULL(CHUYENCAN,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @TAMUNG = @TAMUNG + ISNULL(DATAMUNG,0)  FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @TIENBH = @TIENBH +ISNULL(TIENBH_YT_XH_TN,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @THUETN = @THUETN + ISNULL(THUETHUNHAP,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @TIENCD = @TIENCD + ISNULL(TIENCONGDOAN,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			SELECT @M_TIENLUONG1GIOTC = @M_TIENLUONG1GIOTC + ISNULL(L_TIENLUONG1GIO,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
		
			SELECT @CONGKHAC_CN = @CONGKHAC_CN + ISNULL(TIEN_NTRO_KHAC_SHP,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_CONGLUONGTINHTHUE = @M_CONGLUONGTINHTHUE + ISNULL(CONGLUONGTINHTHUE,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
		
			SELECT @M_TIENLAMTHEMTINHTHUE = @M_TIENLAMTHEMTINHTHUE + ISNULL(TIENLAMTHEMTINHTHUE,0) FROM IT_BANGLUONGMOI 
			WHERE SOTHE = @NV_MA AND T_MA = @T_MA AND LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI

			FETCH NEXT FROM CUR_LUONGCHINH_MOI INTO @LUONG_TU_IT_BANGLUONGMOI  
		END
		--SELECT @CONGKHAC

		DELETE FROM IT_BANGLUONGMOI 
		WHERE SOTHE = @NV_MA and T_MA=@T_MA
		
		--@TIENCOM FLOAT - Andrew (Phần này Tỷ Bách ko có)
		if(@M_DV_MA='HCM-BAOVE' OR @M_DV_MA='HCM-HR' OR @M_DV_MA='HCM-KCS' OR @M_DV_MA='HCM-KHAITHAC' OR @M_DV_MA='HCM-KVT' 
				OR @M_DV_MA='HCM-MAY' OR @M_DV_MA='HCM-NGHIEPVU' OR @M_DV_MA='HCM-NS' OR @M_DV_MA='HCM-PHONGRAP' OR @M_DV_MA='HCM-PM' 
				OR @M_DV_MA='HCM-SOP' OR @M_DV_MA='HCM-SQ' OR @M_DV_MA='HCM-THUMUA' OR @M_DV_MA='HCM-TONGVU' OR @M_DV_MA='HCM-TVKTX' 
				OR @M_DV_MA='HCM-TVX' OR @M_DV_MA='HCM-TX' OR @M_DV_MA='HCM-BAOGIA' OR @M_DV_MA='HCM-INNOVATION'	)
			SET @TIENCOM = @M_SOPHANCOM * 21500
		else
			SET @TIENCOM = @M_SOPHANCOM * 20000

		--@M_TIENCOM float - Andrew (Phần này Tỷ Bách ko có)
		SET @M_TIENCOM = @TIENCOM

			--PHUCAPDOCHAI			
			--không sử dụng
			--SELECT @TIENPCDH = PC_Sotien  from ST_NHANVIENPHUCAP where T_MA=@T_MA and LPC_Ma='PCDH' and NV_MA=@NV_MA
			--CONGLUONG

		SELECT @M_CONGLUONG = ISNULL(@M_LUONGTHANG,0) + ISNULL(@M_23PT_BH_PHEP,0) + ISNULL(@M_BINHBAU,0)
				+ ISNULL(@M_TIENLAMDEM,0) + ISNULL(@M_TIENLAMTHEM,0)
				+  ISNULL(@M_TIENKHAC,0) + ISNULL(@M_TIENNGHI_R_LE,0) 
				+ ISNULL(@M_CHUYENCAN,0) + ISNULL(@M_MOITRUONG,0)
				+ ISNULL(@TIENPCDH,0) + ISNULL(@CONGKHAC_CN,0)+ ISNULL(@CONGKHAC_PCN,0)+ISNULL (@M_TIENNUOICON6T,0)+ @M_TIENHK+ @M_TIENVUOTSL + ROUND(@M_TIENCOM,0) --Andrew

		SET @MAXTRUMOBIVI =ROUND ((@M_CONGLUONG*0.3) - (@TAMUNG + @TIENBH + @THUETN + ISNULL(@TIENCD,0)),-3)
		--	@M_TRUMOBIVI	
		IF @TRUMOBIVI IS null
			BEGIN 
				SET @M_TRUMOBIVI = 0
				SET @TRUMOBIVI_VUOT =0
			END
		ELSE 
			IF @MAXTRUMOBIVI >0
				BEGIN
					IF @TRUMOBIVI <= @MAXTRUMOBIVI
						BEGIN
							SET @M_TRUMOBIVI = @TRUMOBIVI
							SET @TRUMOBIVI_VUOT =0
						END 
					ELSE
						BEGIN
							SET @M_TRUMOBIVI = @MAXTRUMOBIVI
							SET @TRUMOBIVI_VUOT =@TRUMOBIVI -@MAXTRUMOBIVI
						END 
				END 
			ELSE 
				BEGIN 
					SET @M_TRUMOBIVI = 0
					SET @TRUMOBIVI_VUOT =@TRUMOBIVI
				END
			
				
		UPDATE ST_LUONG
		SET L_TRUMOBIVI = 0
		WHERE NV_MA = @NV_MA 
		AND T_MA = @T_MA 
				
		UPDATE ST_LUONG
		SET L_TRUMOBIVI = @M_TRUMOBIVI
		WHERE NV_MA = @NV_MA 
		AND T_MA = @T_MA 
		AND L_LUONGCHINH = @LUONG_TU_IT_BANGLUONGMOI
				
		UPDATE IT_MOBIVI
		SET MB_SoTien_Vuot = @TRUMOBIVI_VUOT
		WHERE NV_MA = @NV_MA 
		AND T_MA = @T_MA
	
			
		--@LANHCUOIKY
		SET @LANHCUOIKY = ROUND( @M_CONGLUONG - @TAMUNG - @TIENBH- @THUETN - ISNULL(@TIENCD,0)-@M_TRUMOBIVI ,0)

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
			--
		SELECT @THUCLANH
	
		SELECT L_NGHILE = @L_NGHILE
		INSERT INTO [IT_BANGLUONGMOI]
		([X_MA],[DV_MA],[DV_TEN],[NAM],[THANG],[TUNGAY],[DENNGAY],[HOTEN],[SOTHE],[T_MA],[LUONGCHINH]
		,[MASOTHUE],[SOTAIKHOAN],[CMON_CVIEC],[UUDAI],[CHUYENCAN],[MOITRUONG],[LUONG_TCCMON_CVIEC]
		,[CONG_TT],[LUONGTHANG],[HS_1],[HS_15],[HS_195],[HS_2],[HS_3],[TIENLAMTHEM],[GIOLAMDEM]
		,[TIENLAMDEM],[TIENNUOICON6T],[GIOKHAC],[TIENKHAC],[GIO_R_LE],[TIENNGHI_R_LE],[PHEPNAM],[TIENPHEPNAM]
		,[TIEN_NTRO_KHAC_SHP],[SOPHANCOM],[TIENCOM],[BINHBAU],[23PT_BH_PHEP],[CONGLUONG]
		,[DATAMUNG],[THUETHUNHAP],[TIENBH_YT_XH_TN],[TIENCONGDOAN],[CONLANHCUOIKY],[THUCLANH],[KYNHAN],[GHICHU],[CV_MA],[TT_CV],[CONGLUONGTINHTHUE],[TIENLAMTHEMTINHTHUE], HS530, TRUMOBIVI, NGHIP1,GIOHK, TIENHK, L_TIENLUONG1GIO)
		 VALUES
		(@M_X_MA,@M_DV_MA,@M_DV_TEN,@M_NAM,@M_THANG,@M_TUNGAY,@M_DENNGAY,@M_HOTEN,@M_SOTHE,@M_T_MA,@M_LUONGCHINH
		,@M_MASOTHUE,@M_SOTAIKHOAN,@M_CMON_CVIEC,@M_UUDAI,@M_CHUYENCAN,@M_MOITRUONG,@M_LUONG_TCCMON_CVIEC
		,@M_CONG_TT,@M_LUONGTHANG,@M_HS_1,@M_HS_15,@M_HS_195,@M_HS_2,@M_HS_3,@M_TIENLAMTHEM,@M_GIOLAMDEM,@M_TIENLAMDEM,@M_TIENNUOICON6T
		,@M_GIOKHAC,@M_TIENKHAC,@M_GIO_R_LE,@M_TIENNGHI_R_LE,@M_PHEPNAM,@M_TIENPHEPNAM
		,@M_TIEN_NTRO_KHAC_SHP_,@M_SOPHANCOM,@M_TIENCOM,@M_BINHBAU,round(@M_23PT_BH_PHEP,0),round(@M_CONGLUONG,0)
		,@M_DATAMUNG,@M_THUETHUNHAP,@M_TIENBH_YT_XH_TN,@M_TIENCONGDOAN,@M_CONLANHCUOIKY,@M_THUCLANH,@M_KYNHAN,@M_GHICHU,@M_CONGVIEC, @M_TTCV, @M_CONGLUONGTINHTHUE, @M_TIENLAMTHEMTINHTHUE,@M_HS_530, @M_TRUMOBIVI, @M_P1, @M_GIOHK, @M_TIENHK, @M_TIENLUONG1GIOTC)
		
		CLOSE CUR_LUONGCHINH_MOI
		DEALLOCATE CUR_LUONGCHINH_MOI

		
	END
	
	----------------------kết thúc cộng 2 dòng lương-----------------------------


-----------Kết thúc chèn vào it_bangluongmoi------------------------------------------


--	IF EXISTS (SELECT * FROM ST_NHANVIENTHOIVIEC WHERE NV_MA = @NV_MA AND TV_NgayThoiViec < @M_TUNGAY)
--	DELETE FROM IT_BANGLUONGMOI WHERE SOTHE = @NV_MA AND T_MA = @T_MA

--select @HUONGLUONGKHD_S,@HUONGLUONGKHD_T,@SODBL,@NGAYGIUA,@L_LUONGSAU,@L_LUONGTRUOC,@HD_PhuCapkhac_T ,
--	@HD_PhuCapkhac_S ,
--	@HD_TCBBHT_T ,
--	@HD_TCBBHT_S ,@LDCM_SAU,@LDCM_TRUOC

