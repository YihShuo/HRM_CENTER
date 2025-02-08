USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_BINHBAUTHANGTRUOC]    Script Date: 25/07/2024 9:11:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_BINHBAUTHANGTRUOC]
	@NV_MA nvarchar(50),@T_Ma nvarchar(10)
AS
BEGIN
	declare 
		@Tungay  datetime,
		@Denngay datetime ,
		@CV_MA NVARCHAR(50),
		@BB_SogioOO nvarchar(10),
		@BB_SogioRO nvarchar(10),
		@BB_SogioCO nvarchar(10),
		@BB_SogioO nvarchar(10),
		@BB_SogioOTC nvarchar(10),
		@BB_SogioP nvarchar(10),
		@BB_SogioKThai nvarchar(10),
		@BB_SogioR nvarchar(10),
		@BB_SogioNo nvarchar(10),
		@BB_SogioTSan nvarchar(10),
		@BB_SogioTNLD nvarchar(10),
		@BB_Ditre nvarchar(10),
		@BB_Binhbautruoc nvarchar(10),
		@BB_Binhbau nvarchar(10),
		@DV_Ma nvarchar (20),
		@SoThang nvarchar(10), 
		@ThangHT nvarchar(10), 
		@Thang int , 
		@TienBB float, 
		@Nam nvarchar(10),
		@BB_SogioS nvarchar(10)
	-- don vi
	select @DV_Ma=DV_Ma from ST_Nhanvien where NV_Ma=@NV_Ma
	select  @Tungay =T_Tungay ,@Denngay=T_Denngay from ST_Thang where T_Ma=@T_Ma
	-- Nghi Ro
	select  	@BB_SogioRO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='RO' and CC_Hesongaycong=1
	-- Nghi P
	select  	@BB_SogioP =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='P'  and CC_Hesongaycong=1
	-- Nghi O
	select  	@BB_SogioO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='O' and CC_Hesongaycong=1
	-- Nghi R
	select  	@BB_SogioR =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='R' and CC_Hesongaycong=1
	-- Nghi ?m
	select  	@BB_SogioOO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='Om' and CC_Hesongaycong=1
	-- Nghi Kham thai
	select  	@BB_SogioKThai =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='KThai' and CC_Hesongaycong=1
	-- Nghi thai san
	select  	@BB_SogioTSan=sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='TSan' and CC_Hesongaycong=1
	-- Nghi TNLD
	select  	@BB_SogioTNLD=sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='TNLD' and CC_Hesongaycong=1
	-- Khong tang ca
	select  	@BB_SogioOTC =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='OTC' and CC_Hesongaycong=1
	-- Khong tang ca
	select  	@BB_SogioCO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='CO' and CC_Hesongaycong=1
	-- Say thai
	select  	@BB_SogioS =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='S' and CC_Hesongaycong=1
	--No
	select  	@BB_SogioNo =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='NO' and CC_Hesongaycong=1
	-- Binh bau thang truoc 
	SELECT @Thang= left(@T_Ma,2)  
	IF @Thang='01'
		BEGIN
			SELECT @Thang=12
			--lay nam
			SELECT @Nam=right( @T_Ma,4)-1 
		END
	ELSE
		BEGIN
			SELECT @Thang= left(@T_Ma,2)-1 
			SELECT @Nam=right( @T_Ma,4)
		END

	IF @Thang  < 10 
		SELECT @SoThang='0'+cast( @Thang as nvarchar( 10))
	ELSE
		SELECT @SoThang=@Thang

	SELECT @ThangHT=cast( @SoThang as nvarchar( 10))+'-'+cast( @Nam as nvarchar( 10))
	 
	IF not exists(select * from ST_BINHBAUTHANG where NV_MA=@NV_MA and T_Ma=@T_Ma)
		BEGIN
				SELECT  @BB_Binhbautruoc=BB_Ma  from dbo.ST_BINHBAUTHANG
				WHERE NV_Ma=@NV_Ma
					AND T_Ma =@ThangHT

				INSERT	INTO ST_BINHBAUTHANG(NV_MA,T_Ma,DV_Ma,BB_Truoc,BB_SongayOO
					,BB_SongayRO,BB_SongayCO,BB_SongayO,BB_SongayOTC,BB_SongayP,BB_SongayKThai,BB_SongayR,BB_SongayS,BB_SongayNo,BB_SongayTNLD,BB_SongayTSan)
				VALUES (@NV_MA,@T_Ma,@DV_Ma,@BB_Binhbautruoc,@BB_SogioOO,@BB_SogioRO
					,@BB_SogioCO,@BB_SogioO,@BB_SogioOTC,@BB_SogioP,@BB_SogioKThai,@BB_SogioR,@BB_SogioS,@BB_SogioNo,@BB_SogioTNLD,@BB_SogioTSan)
		END
	ELSE
		BEGIN		
			SELECT  @BB_Binhbautruoc=BB_Ma  from dbo.ST_BINHBAUTHANG
			WHERE NV_Ma=@NV_Ma
				AND T_Ma = @ThangHT 
		
			SELECT  @BB_Binhbau = BB_Ma  from dbo.ST_BINHBAUTHANG
			WHERE NV_Ma=@NV_Ma
				AND T_Ma =@T_Ma 

			UPDATE ST_BINHBAUTHANG
			SET NV_MA=@NV_MA,
				T_Ma=@T_Ma,
				DV_Ma=@DV_Ma,
				BB_Truoc=@BB_Binhbautruoc,
				BB_SongayOO=@BB_SogioOO,
				BB_SongayRO=@BB_SogioRO,
				BB_SongayCO=@BB_SogioCO,
				BB_SongayO=@BB_SogioO,
				BB_SongayOTC=@BB_SogioOTC,
				BB_SongayP=@BB_SogioP,
				BB_SongayKThai=@BB_SogioKThai,
				BB_SongayR=@BB_SogioR,
				BB_SongayNo=@BB_SogioNo,
				BB_SongayTSan=@BB_SogioTSan,
				BB_SongayTNLD=@BB_SogioTNLD,
				BB_SongayS=@BB_SogioS
			WHERE NV_MA=@NV_MA and T_Ma=@T_Ma
		END
        
	--------------------------- Cap nhat tien thuong----------------------------- 	
	SELECT @TienBB=Sotien
	FROM ST_BinhBauThang,ST_BinhBauChucVu,ST_Nhanvien,ST_Binhbau
	WHERE ST_BinhBauThang.NV_Ma=ST_Nhanvien.NV_Ma
			and ST_BinhBauChucVu.CVU_Ma=ST_Nhanvien.CVU_Ma
			and ST_BinhBauThang.NV_Ma=@NV_MA
			and ST_Binhbau.bb_Ma=ST_BinhBauThang.bb_ma
			and ST_BinhBauThang.T_Ma=@ThangHT
			and ST_BinhBauChucVu.BBCV_Ma=@BB_Binhbautruoc

	IF exists ( select * from ST_Tamung where NV_MA=@NV_MA and T_Ma=@T_Ma )
		IF exists ( select * from ST_HOPDONGLAODONG where NV_MA=@NV_MA )
			IF @BB_Binhbautruoc  <>'' 
				SELECT  @TienBB=@TienBB
			ELSE
				SELECT  @TienBB=0
	ELSE
		SELECT  @TienBB=0

	--Trường hợp là Chủ Nhiệm, Phó Chủ Nhiệm thì luôn có tiền BB là 150.000
	SELECT @CV_MA = CV_MA FROM ST_NHANVIEN WHERE NV_Ma = @NV_MA

	IF @CV_MA = 'CNH' OR @CV_MA = 'PCN'
			SELECT @TienBB='150000'
		
	UPDATE ST_Tamung
	SET TU_ThuongABC=@TienBB
	WHERE NV_MA=@NV_MA and T_Ma=@T_Ma
	SELECT  @TienBB, @BB_Binhbautruoc
	--------------------------- Cap nhat tien thuong (END)----------------------------- 	
END

