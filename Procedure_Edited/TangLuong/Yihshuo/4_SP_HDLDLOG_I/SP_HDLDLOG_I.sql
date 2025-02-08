USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_HDLDLOG_I]    Script Date: 05/07/2024 10:02:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_HDLDLOG_I]
(@T_MA NVARCHAR(50))
AS
BEGIN
IF NOT EXISTS (SELECT * FROM ST_HOPDONGLAODONGLOG WHERE T_MA =@T_MA)
INSERT INTO ST_HOPDONGLAODONGLOG
           (NV_Ma
           ,HD_So
           ,L_Ma
           ,HD_KHONGHUONGCHUYENCAN
           ,HD_NgayKy
           ,HD_NgayHetHan
           ,BB_TT
           ,BB_A
           ,BB_B
           ,BB_C
           ,RO
           ,OM
           ,BANGL
           ,TENBANGLUONG
           ,TENNGACH
           ,NGACH
           ,BAC
           ,BL_MA
           ,HD_LuongCB
           ,HD_HeSo
           ,HD_PhuCap
           ,HD_PhuCapkhac
           ,HD_DongBHXH
           ,HD_DongBHYT
           ,HD_CongviecDH
           ,HD_TrocapCV
           ,HD_TrocapUD
           ,HD_TrocapCMNV
           ,HD_TrocapNN
           ,HD_TrocapHMPT
           ,HD_Luongtoithieu
           ,HD_DongBHTN
           ,HD_GIAHAN
           ,HD_NGAYBATDAUGIAHAN
           ,HD_NGAYKETTHUCGIAHAN
           ,HD_LYDOGIAHAN
           ,TCCM_VPX
           ,TCCBTS
           ,TCCBVP
           ,TCBBNT
           ,TCBBHT
           ,TCBBTHANG
           ,HD_BAC1
           ,HD_BAC2
           ,HD_BAC3
           ,HD_TCCHAMLOGIADINH
           ,HD_TCHOTRODONGPHUC
           ,HD_TroCapQAQIP
           ,HD_TrocapThoRap
           ,HD_TrocapHSE
           ,HD_HTNG
           ,HD_DQTV
           ,HD_PCCC           
           ,T_MA)
SELECT ST_HOPDONGLAODONG.NV_Ma
      ,HD_So
      ,L_Ma
      ,HD_KHONGHUONGCHUYENCAN  
      ,ST_HOPDONGLAODONG.HD_NgayKy
      ,HD_NgayHetHan
      ,BB_TT
      ,BB_A
      ,BB_B
      ,BB_C
      ,RO
      ,OM
      ,BANGL
      ,TENBANGLUONG
      ,TENNGACH
      ,ST_HOPDONGLAODONG.NGACH
      ,BAC
      ,BL_MA
      ,HD_LuongCB
      ,HD_HeSo
      ,HD_PhuCap
      ,HD_PhuCapkhac
      ,HD_DongBHXH
      ,HD_DongBHYT
      ,HD_CongviecDH
      ,HD_TrocapCV
      ,HD_TrocapUD
      ,HD_TrocapCMNV
      ,HD_TrocapNN
      ,HD_TrocapHMPT
      ,HD_Luongtoithieu
      ,HD_DongBHTN
      ,HD_GIAHAN
      ,HD_NGAYBATDAUGIAHAN
      ,HD_NGAYKETTHUCGIAHAN
      ,HD_LYDOGIAHAN
      ,TCCM_VPX
      ,TCCBTS
      ,TCCBVP
      ,TCBBNT
      ,TCBBHT
      ,TCBBTHANG
      ,HD_BAC1
      ,HD_BAC2
      ,HD_BAC3
      ,HD_TCCHAMLOGIADINH
      ,HD_TCHOTRODONGPHUC
      ,HD_TroCapQAQIP
      ,HD_TrocapThoRap
      ,HD_TrocapHSE
      ,HD_HTNG
      ,HD_DQTV
      ,HD_PCCC   
      ,T_MA
FROM ST_HOPDONGLAODONG INNER JOIN  IT_BANGLUONGTHANG0109 ON ST_HOPDONGLAODONG.NV_Ma = IT_BANGLUONGTHANG0109.NV_Ma
WHERE  T_MA = @T_MA and IT_BANGLUONGTHANG0109.LOAI_TL = 'TT'
AND ST_HOPDONGLAODONG.NV_Ma not in ('000998')
AND IT_BANGLUONGTHANG0109.DV_MA NOT LIKE N'%CG%'
AND IT_BANGLUONGTHANG0109.DV_MA NOT LIKE N'%BGD%'
--and IT_BANGLUONGTHANG0109.NV_Ma in
--('001947', '004371', '004400', '004668', '005169', '005212', '005366', '005501', '005506', '006286', '006548', '006707', '006810', '006973', '006985', '007057', '007200', '007298', '007606', '007731', '007755', '007879', '007894', '008000', '008055', '008096', '008097', '008099', '008168', '008176', '008359', '008367', '008440', '008541', '008566', '008586', '008612', '008642', '008657', '008690', '008716', '008751', '008757', '008762', 
--'008764')
END

