SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[SP_BINHBAUTHANG]
	@NV_MA nvarchar(50),@T_Ma nvarchar(10),@Binhbau nvarchar(10)
AS
Begin
	declare 
		@Tungay  datetime,
		@Denngay datetime ,
		@BB_SogioOO nvarchar(10),
		@BB_SogioRO nvarchar(10),
		@BB_SogioCO nvarchar(10),
		@BB_SogioO nvarchar(10),
		@BB_SogioOTC nvarchar(10),
		@BB_SogioP nvarchar(10),
		@BB_SogioP1 nvarchar(10),
		@BB_SogioPo nvarchar(10),
		@BB_SogioPD nvarchar(10),
		@BB_SogioPt nvarchar(10),
		@BB_SogioKThai nvarchar(10),
		@BB_SogioR nvarchar(10),
		@BB_SogioNo nvarchar(10),
        @BB_SogioKHHGD nvarchar(10),
        @BB_SogioQS nvarchar(10),
		@BB_SogioTSan nvarchar(10),
		@BB_SogioTNLD nvarchar(10),
		@BB_Ditre nvarchar(10),
		@BB_SogioDQ nvarchar(10),
		@BB_SogioOM1 nvarchar(10),
		@BB_SogioOM2 nvarchar(10),
		@BB_SogioDS nvarchar(10),
		@BB_SogioST nvarchar(10),
		@BB_Binhbautruoc nvarchar(10),
		@DV_Ma nvarchar (20),
		@SoThang nvarchar(10), 
		@BB_SogioS nvarchar(10)
	-- don vi
	select @DV_Ma=DV_Ma from ST_Nhanvien where NV_Ma=@NV_Ma
	select  @Tungay =T_Tungay ,@Denngay=T_Denngay from ST_Thang where T_Ma=@T_Ma
	-- Nghi Ro
	select  	@BB_SogioRO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='RO' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi P
	select  	@BB_SogioP =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='P'  and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi P1
	select  	@BB_SogioP1 =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='P1'  and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi Po
	select  	@BB_SogioPo =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='Po'  and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi PD
	select  	@BB_SogioPD =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='PD'  and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi Pt
	select  	@BB_SogioPt =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='Pt'  and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi O
	select  	@BB_SogioO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='O' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi R
	select  	@BB_SogioR =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='R' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi Ốm
	select  	@BB_SogioOO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='OM' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi OM1
	select  	@BB_SogioOM1  =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='OM1' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi OM2
	select  	@BB_SogioOM2  =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='OM2' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi Kham thai
	select  	@BB_SogioKThai =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='KThai' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi thai san
	select  	@BB_SogioTSan=sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='TS' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Nghi TNLD
	select  	@BB_SogioTNLD=sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='TNLD' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Khong tang ca
	select  	@BB_SogioOTC =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='OTC' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Khong tang ca
	select  	@BB_SogioCO =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='CO' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	-- Say thai
	select  	@BB_SogioS =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='S' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)
	--No
	select  	@BB_SogioNo =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='NO' and (CC_Hesongaycong=1  or CC_Hesongaycong=4)

	--KHHGD
	select  	@BB_SogioKHHGD =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='KHHGD' and CC_Hesongaycong=1
	--QS
	select  	@BB_SogioQS =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='QS' and CC_Hesongaycong=1

	--DQ
	select  	@BB_SogioDQ =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='DQ' and CC_Hesongaycong=1
	--DS
	select  	@BB_SogioDS =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='DS' and CC_Hesongaycong=1
	
	--ST
	select  	@BB_SogioST =sum(CC_Sogionghi) from ST_Gioquetthe where QT_Ngay >=@Tungay and 
				QT_Ngay <=@Denngay and NV_Ma=@NV_Ma  and 
				NP_Ma='ST' and CC_Hesongaycong=1

	SELECT @BB_SogioO

	if not exists(select * from ST_BINHBAUTHANG where NV_MA=@NV_MA and T_Ma=@T_Ma)
		begin
			select  @BB_Binhbautruoc=BB_Ma  from dbo.ST_BINHBAUTHANG 
			where NV_Ma=@NV_Ma
					and right(T_Ma,2)=right(@T_Ma,2)	--Phải thỏa điều kiện cùng năm
					and T_Ma =( select max(T_Ma)		--Lấy tháng lớn nhất
								FROM ST_BINHBAUTHANG 
								WHERE NV_Ma=@NV_Ma
									  AND right(T_Ma,2)=right(@T_Ma,2))

			insert into ST_BINHBAUTHANG(NV_MA,T_Ma,DV_Ma,BB_Ma,BB_SongayOO,BB_SongayRO,BB_SongayCO,BB_SongayO,BB_SongayOTC,BB_SongayP
						,BB_SongayKThai,BB_SongayR,BB_SongayS,BB_SongayNo, BB_SONGAYKHHGD, BB_SONGAYQS,BB_SongayTNLD,BB_SongayTSan
						,BB_SongayDQ,BB_SongayDS,BB_SongayST,BB_SongayP1,BB_SongayPo,BB_SongayPD,BB_SongayPt,BB_SONGAYOM1,BB_SONGAYOM2)
			values (@NV_MA,@T_Ma,@DV_Ma,@Binhbau,@BB_SogioOO,@BB_SogioRO,@BB_SogioCO,@BB_SogioO,@BB_SogioOTC,@BB_SogioP
						,@BB_SogioKThai,@BB_SogioR,@BB_SogioS,@BB_SogioNo, @BB_SogioKHHGD, @BB_SogioQS,@BB_SogioTNLD,@BB_SogioTSan
						, @BB_SogioDQ, @BB_SogioDS, @BB_SogioST,@BB_SogioP1,@BB_SogioPo,@BB_SogioPD,@BB_SogioPt,@BB_SogioOM1,@BB_SogioOM2)
		end
	else
		begin
			update ST_BINHBAUTHANG
			set NV_MA=@NV_MA,
				T_Ma=@T_Ma,
				DV_Ma=@DV_Ma,
				BB_Ma=@Binhbau,
				BB_SongayOO=@BB_SogioOO,
				BB_SongayRO=@BB_SogioRO,
				BB_SongayCO=@BB_SogioCO,
				BB_SongayO=@BB_SogioO,
				BB_SongayOTC=@BB_SogioOTC,
				BB_SongayP=@BB_SogioP,
				BB_SongayP1=@BB_SogioP1,
				BB_SongayPo=@BB_SogioPo,
				BB_SongayPD=@BB_SogioPD,
				BB_SongayPt=@BB_SogioPt,
				BB_SongayKThai=@BB_SogioKThai,
				BB_SongayR=@BB_SogioR,
				BB_SongayNo=@BB_SogioNo,
				BB_SongayKHHGD=@BB_SogioKHHGD,
				BB_SongayQS=@BB_SogioQS,
				BB_SongayTSan=@BB_SogioTSan,
				BB_SongayTNLD=@BB_SogioTNLD,
				BB_SongayS=@BB_SogioS,
				BB_SongayDQ=@BB_SogioDQ,
				BB_SongayDS=@BB_SogioDS,
				BB_SongayST=@BB_SogioST,
				BB_SONGAYOM1 = @BB_SogioOM1,
				BB_SONGAYOM2 = @BB_SogioOM2
			where NV_MA=@NV_MA and T_Ma=@T_Ma
		end
end

GO