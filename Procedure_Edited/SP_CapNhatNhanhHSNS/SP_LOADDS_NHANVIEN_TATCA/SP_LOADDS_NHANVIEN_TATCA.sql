USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_LOADDS_NHANVIEN_TATCA]    Script Date: 14/02/2022 11:16:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- vinh
--23/03/2016
ALTER PROCEDURE [dbo].[SP_LOADDS_NHANVIEN_TATCA]
AS
begin	
	SELECT MTCV = 'Xem',
            PTCV = 'Xem',
            NHOMMTCV = 'XemNhom',
            NHOMPTCV = 'XemNhom',
            NV.NV_Ma AS NV_MA ,
            NHOMCV_MA = 'NHOMCV_MA' ,
            NV.NV_Ten AS NV_TEN,
            NV.NV_MaQL AS NV_MAQL,
            NV.DV_MA AS DV_MA,
            NV.DV_MA_ AS DV_MA_,
            NV.NV_MaTu AS NV_MATU,
            NV.NV_GioiTinh AS NV_GIOITINH,
            (CASE WHEN ISNULL(NV_NAMSINH,0) = 0  THEN (CONVERT(NVARCHAR(10),NV.NV_Ngaysinh,105)) ELSE (LEFT(CONVERT(NVARCHAR(10),NV.NV_Ngaysinh,21),4)) END) AS NV_NGAYSINH,
            NV_TUOI,
            NV.NV_NoiSinh AS NV_NOISINH,
            NV.NV_DiaChi AS NV_DIACHI,
			NV.Mail AS Mail,
            NV.TT_MA AS TT_MA,
            NV.QT_MA AS QT_MA,
            NV.DT_MA AS DT_MA,
            NV.TG_MA AS TG_MA,
            NV.NV_Thuongtru AS NV_THUONGTRU,
            NV.NV_Honnhan AS NV_HONNHAN,
            NV.NV_Socon AS NV_SOCON ,
            NV.NOIDUNGBS AS NOIDUNGBS,
            NV.NV_CMND AS NV_CMND,
            NV.NV_NgayCapCMND AS NV_NGAYCAPCMND,
            NV.NV_NoiCapCMND AS NV_NOICAPCMND,
            NV.NV_DTNhaRieng AS NV_DTNHARIENG,
            NV.NV_DTDiDong AS NV_DTDIDONG,
            NV.NV_Ngayvao AS NV_NGAYVAO,
            NV.NV_Ngayvao AS TUNGAY,
            NV.NV_Ngayvao AS DENNGAY,
            NV.NV_Hinh AS NV_HINH,
            NV.HV_MA AS HV_MA,
            NV.TH_MA AS TH_MA,
            NV.NN_MA AS NN_MA,
            ST_CONGVIEC.CV_TEN AS CV_TEN,
            NV.CVU_MA AS CVU_MA,
            NV.NV_Ngaybonhiem AS NV_NGAYBONHIEM,
            NV.CM_MA AS CM_MA,
            NV.NV_Congdoan AS NV_CONGDOAN,
            NV.NV_NgayvaoCD AS NV_NGAYVAOCD,
            NV.NV_THOIVIEC AS NV_THOIVIEC,
            NV.NV_NgayTV AS NV_NGAYTV,
            NV.NV_NGAYKHD AS NV_NGAYKHD,
            NV.QH_MA AS QH_MA,
            ST_NHANVIENTHOIVIEC.LTV_MA AS LTV_MA,
            ST_HOPDONGLAODONG.HD_LUONGCB AS HD_LUONGCB,
            NV.NV_DAKYHDLD AS NV_DAKYHDLD,
            NV.BSHS AS BSHS,
            NV.DANGVIEN AS DANGVIEN,
            NV.NGAYVAODANG AS NGAYVAODANG,
            NV.NOIVAO AS NOICONGTAC,
            NV.HLHTNVN AS TNVN,
            NV.TRINHDOCHINHTRI AS TRINHDO,
            NV.CV_MA AS CV_MA,
            ST_HOPDONGLAODONG.L_MA,
            L_TEN,ST_NHANVIENTHOIVIEC.LTV_MA,
            TV_LYDO,
            CHK_DOANVIEN= (CASE WHEN IT_CONGDOAN.SOTHE IS NOT NULL THEN 1 ELSE 0 END),
            NV.MASOTHUE ,
            NV.SOTAIKHOAN,
            NV_NAMSINH,
            NV_Ngaysinh AS NV_NGAYSINHTT,
			-------------------------Địa Chỉ---------------------------
			--------Quê Quán
            NV_TinhQQ ,
            NV_QuanHuyenQQ AS QuanHuyen_QQ ,
            NV_XaPhuongQQ  AS XaPhuong_QQ,
			--Andrew
			dbo.fn_LayTenQuanHuyen(NV_TinhQQ,NV_QuanHuyenQQ) AS TenQH_QQ,
			dbo.fn_LayTenXaPhuong(NV_TinhQQ,NV_QuanHuyenQQ,NV_XaPhuongQQ) AS TenXP_QQ,
			--------Thường Trú
            NV_TinhDC ,
			NV_QuanHuyenDC AS QuanHuyen_DC,
			NV_XaPhuongDC AS XaPhuong_DC,
			--Andrew
			dbo.fn_LayTenQuanHuyen(NV_TinhDC,NV_QuanHuyenDC) AS TenQH_DC,
			dbo.fn_LayTenXaPhuong(NV_TinhDC,NV_QuanHuyenDC,NV_XaPhuongDC) AS TenXP_DC,
            NV_SoNhaDC,
			-----------------------------------------------------------
			NV.KHUA AS KHUA ,
			NV.KHUB AS KHUB,
			NV.IT_DDNGHIVIEC AS CHUYENTAM,
			TenVaccine_1,
			NgayVaccine_1,
			TenVaccine_2,
			NgayVaccine_2,
			TenVaccine_3,
			NgayVaccine_3,
			TenVaccine_4,
			NgayVaccine_4,
			TenVaccine_5,
			NgayVaccine_5,
			TenVaccine_6,
			NgayVaccine_6
	FROM ST_NHANVIEN NV LEFT JOIN ST_NHANVIENTHOIVIEC ON NV.NV_MA = ST_NHANVIENTHOIVIEC.NV_MA
						LEFT JOIN ST_HOPDONGLAODONG ON NV.NV_MA = ST_HOPDONGLAODONG.NV_MA
						LEFT JOIN ST_CONGVIEC ON ST_CONGVIEC.CV_MA = NV.CV_MA
						LEFT JOIN ST_HOPDONG_LOAI ON ST_HOPDONGLAODONG.L_MA = ST_HOPDONG_LOAI.L_MA
						LEFT JOIN IT_CONGDOAN ON NV.NV_MA = IT_CONGDOAN.SOTHE
	-- WHERE 
	-- NV.DV_MA  IN (SELECT DV_MA FROM ST_DONVI WHERE DV_LocBB = 0)
	ORDER BY NV.NV_MA ASC 
END

