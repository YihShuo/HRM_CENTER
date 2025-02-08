------ Xuất diễn biến lương Tháng 7
Use [P0104-TYTHAC]
GO
DECLARE @thangnam VARCHAR(7)
SET @thangnam='03-2022'
-- Phụ cấp: là trợ cấp chuyên môn; Trợ cấp UD: là trợ cấp khác bên bảng ST_NhanVienPhuCap
Select  a.NV_Ma, b.DV_MA,a.DBL_Ngaybatdau, a.DBL_Heso, a.DBL_LuongCB, a.DBL_PhuCap
		, a.CV_MA, a.CVU_MA, a.DHNN, a.LDCM, a.DBL_PhuCapKhac, a.DBL_TrocapCV, a.DBL_TrocapUDMAY
		, a.DBL_TrocapCMNV, a.DBL_TrocapNN, a.DBL_TrocapHMPT, a.DBL_TroCapQLSX, a.DBL_TroCapCBVP, a.DBL_TroCapBBNT
		, a.DBL_TroCapBBHT, a.DBL_TroCapBBTHANG, a.DBL_TroCapCLGD, a.DBL_TroCapHTDP, a.DBL_TroCapQAQIP
		, a.DBL_TrocapThoRap, a.DBL_TrocapHSE, a.DBL_TrocapMOITRUONG, a.DBL_KHONGHUONGCHUYENCAN		
		, a.DBL_PHUCLOI, a.DBL_HTNG, a.DBL_DQTV, a.DBL_PCCC
		--b.NV_Ma as [Số Thẻ],b.NV_Ten as [Họ Tên],b.DV_MA as [Đơn Vị],convert(date,b.NV_Ngayvao,105) as [Ngày Vào],b.CVU_MA as [Chức Vụ]
		--,a.CV_MA as [Công Việc],convert(date,a.DBL_Ngaybatdau,105) as [Ngày Nhập Lương],a.DBL_LuongCB as [Lương Lương Chính]
		--,a.DBL_Heso as [Hệ Số],DBL_PhuCap as [Phụ Cấp] 
From ST_DIENBIENLUONG as a Inner Join ST_NHANVIEN as b on a.NV_Ma=b.NV_Ma 						
						  
Where year( a.DBL_Ngaybatdau)=SUBSTRING(@thangnam,4,4) and month(a.DBL_Ngaybatdau) =SUBSTRING(@thangnam,1,2)
Order by b.NV_Ma

--SELECT CV_TEN,* FROM ST_NhanVien WHERE NV_Ten LIKE N'% Hân' AND DV_MA NOT LIKE 'NV'

-------- Xuất diễn biến lương Tháng 7
--Use [P0104-TYTHAC]
--GO
--DECLARE @thangnam VARCHAR(7)
--SET @thangnam='09-2021'
---- Phụ cấp: là trợ cấp chuyên môn; Trợ cấp UD: là trợ cấp khác bên bảng ST_NhanVienPhuCap
--Select  b.NV_Ma as [Số Thẻ],b.NV_Ten as [Họ Tên],b.DV_MA as [Đơn Vị],convert(date,b.NV_Ngayvao,105) as [Ngày Vào],b.CVU_MA as [Chức Vụ]
--						  ,a.CV_MA as [Công Việc],convert(date,a.DBL_Ngaybatdau,105) as [Ngày Nhập Lương],a.DBL_LuongCB as [Lương Lương Chính]
--						  ,a.DBL_Heso as [Hệ Số],DBL_PhuCap as [Phụ Cấp] , IsNull(c.[Uu Dai],0) as [Trợ Cấp UD]
--From ST_DIENBIENLUONG as a Inner Join ST_NHANVIEN as b on a.NV_Ma=b.NV_Ma 						
--						   Left Join (Select NV_Ma,T_Ma, Max(PC_Sotien) as [Uu Dai]
--									  From ST_NHANVIENPHUCAP -- Đây là phần Ưu đãi trong bảng lương, NS phải kéo trước qua tháng cần tính thì mới chạy đủ được
--									  Where T_Ma=@thangnam							
--									  Group by NV_Ma,T_MA,PC_Sotien
--									) as c on a.NV_Ma=c.NV_Ma
--Where year( a.DBL_Ngaybatdau)=SUBSTRING(@thangnam,4,4) and month(a.DBL_Ngaybatdau) =SUBSTRING(@thangnam,1,2)
--Order by b.NV_Ma

----SELECT CV_TEN,* FROM ST_NhanVien WHERE NV_Ten LIKE N'% Hân' AND DV_MA NOT LIKE 'NV'
