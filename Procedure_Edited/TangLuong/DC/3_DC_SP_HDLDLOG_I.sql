--Kiểm tra xem có tháng cần làm chưa, nếu có thì xóa
DECLARE @T_MA NVARCHAR(50)
SET @T_MA= '2024-07'
SELECT * FROM ST_HOPDONGLAODONGLOG a INNER JOIN ST_NHANVIEN b ON a.NV_Ma=b.NV_Ma WHERE  T_MA =@T_MA AND b.DV_MA LIKE  ('HCM%')
--DELETE FROM ST_HOPDONGLAODONGLOG a INNER JOIN ST_NHANVIEN b ON a.NV_Ma=b.NV_Ma WHERE  T_MA =@T_MA AND b.DV_MA LIKE  ('HCM%')

DECLARE @T_MA NVARCHAR(50)
SET @T_MA= '2024-07'
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
	AND IT_BANGLUONGTHANG0109.DV_MA NOT LIKE N'%CG%'
	AND IT_BANGLUONGTHANG0109.DV_MA NOT LIKE N'%BGD%'
	AND	IT_BANGLUONGTHANG0109.DV_MA LIKE('HCM%')
