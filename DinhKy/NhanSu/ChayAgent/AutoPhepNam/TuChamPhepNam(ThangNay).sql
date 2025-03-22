													/*
													Nhờ IT thiết lập tính năng tự động tính phép năm của NLĐ trên HRM theo mốc thời gian:
														-Ngày 4 tây hàng tháng sẽ cập nhật phép năm của tháng trước đó.
														-Ngày 15 tây hàng tháng sẽ cập nhật phép của tháng hiện tại.
													*/
------------------------------------------------------------------------------PHÉP NĂM HẰNG THÁNG (THÁNG HIỆN TẠI)-----------------------------------------------------------------------
-----------Khai Báo Biến-------------
-------
USE [P0104-TYTHAC]
GO

Declare @NgayHienTai As Date,
		@NgayDauNam As Date
Set @NgayHienTai=CAST(FORMAT(CAST(GETDATE() AS DATE),'yyyy-MM') AS CHAR(7)) + '-16'
Set @NgayDauNam=Cast(Year(@NgayHienTai) As varchar(4))+'-01-01'

SELECT @NgayHienTai,@NgayDauNam
------------------------------------------------------------------------------------------
-------------------Cập nhật nhân viên mới ký hợp đồng vào ST_PHEPNAM----------------------
--B1: Thêm vào bảng ST_PHEPNAM
INSERT INTO ST_PHEPNAM(PN_Nam, NV_Ma, PN_Songaynamtruoc, PN_Songaynamnay,  PN_NangnhocDH, PN_PhepTren5Nam)
Select CAST(YEAR(@NgayDauNam) As nvarchar(10)),a.NV_Ma,0,0,0,0
From ST_NHANVIEN As a Inner Join ST_HOPDONGLAODONG As b on a.NV_Ma=b.NV_Ma -- Inner Join để loại NV chưa ký hợp đồng
Where a.NV_Ma not in (Select NV_Ma From ST_PhepNam Where PN_Nam=YEAR(@NgayDauNam)) 
			and a.DV_MA not in('NV','BGD','CGX')
			and a.NV_Ma not in (Select NV_MA From ST_NHANVIENTHOIVIEC)
-------------------------------------------------------------------------------------------
Update a
Set a.PN_Songaynamnay = b.PN_SoNgayNamNay
From ST_PHEPNAM As a Inner Join
	(
    --TH1: Làm trước năm hiện tại
	Select nv.NV_Ma,PN_SoNgayNamNay=DATEDIFF(month,@NgayDauNam,@NgayHienTai)+1
	From ST_NHANVIEN As nv Inner Join ST_HOPDONGLAODONG As hd on nv.NV_Ma=hd.NV_Ma
	Where nv.NV_Ma not in (Select NV_Ma From ST_NHANVIENTHOIVIEC)
		and nv.DV_MA not in ('NV','BGD','CGX')
		and (
			   (YEAR(nv.NV_Ngayvao)<YEAR(@NgayDauNam) AND nv.CVU_MA LIKE 'CN')--Công nhân thì phép năm tính từ Ngày Vào
			OR (YEAR(hd.HD_NgayKy)<YEAR(@NgayDauNam) AND nv.CVU_MA NOT LIKE 'CN')--Nhân viên thì phép năm tính từ Ngày KHD
			OR (YEAR(nv.NV_NGAYKHD_)<YEAR(@NgayDauNam) AND nv.CVU_MA NOT LIKE 'CN')--Nhân viên đáo hạn thì phép năm tính từ lần KHD trước đó
			)
		and NV.NV_Ma in (Select NV_Ma From ST_HOPDONGLAODONG)
	Union All
	--TH2: Làm từ năm hiện tại (Nhân Viên) -- Ngày làm việc trong tháng = Tổng ngày của tháng - Ngày vào + 1
													                --Tổng ngày của tháng= Chênh lêch của ( Tháng ngay ngày tính và Tháng kế Tiếp đó)
	Select nv.NV_Ma,PN_SoNgayNamNay=case 
										when Round(Cast((DATEDIFF(DAY,NV_NGAYKHD,DATEADD(MONTH,1,NV_NGAYKHD))-DAY(NV_NGAYKHD)+1 ) As Float)-- Phải dùng Cast để lấy phần thập phân nếu 0 sẽ bị làm tròn thành 0 dẫn tới sót KQ
											/(DATEDIFF(DAY,NV_NGAYKHD,DATEADD(MONTH,1,NV_NGAYKHD))),3) --Nếu ngày làm việc / Tổng ngày của tháng đủ từ 1/2 thì xem như đủ điều kiện hưởng 1 ngày phép năm của tháng đó
											>=0.5
										then (DATEDIFF(MONTH,NV_NGAYKHD,@NgayHienTai))+1 --Tính đủ tháng
									else (DATEDIFF(MONTH,NV_NGAYKHD, @NGAYHIENTAI))--Tính trừ tháng có ngày KHD
									end
	From ST_NHANVIEN As nv Inner Join ST_HOPDONGLAODONG As hd on nv.NV_Ma=hd.NV_Ma
	Where nv.NV_Ma not in (Select NV_Ma From ST_NHANVIENTHOIVIEC)
		and nv.DV_MA not in ('NV','BGD','CGX')
		and (nv.CVU_MA not like 'CN' AND DATEDIFF(DAY,nv.NV_Ngayvao,nv.NV_NGAYKHD) >=25) --Lấy chức vụ không phải là CN và thời gian thử việc ít nhất 25 ngày (do có thể tháng 2 ko đủ 30 ngày)
		and (
				YEAR(nv.NV_NGAYKHD)>=YEAR(@NgayDauNam)--Nhân viên mới, không tính NV đáo hạn hợp đồng
				AND ((nv.NV_NGAYKHD=nv.NV_NGAYKHD_) OR nv.NV_NGAYKHD_ IS NULL)
			)
		and NV.NV_Ma in (Select NV_Ma From ST_HOPDONGLAODONG)
	Union All
	--TH3: Làm từ năm hiện tại (Công Nhân) -- Ngày làm việc trong tháng = Tổng ngày của tháng - Ngày vào + 1
													                --Tổng ngày của tháng= Chênh lêch của ( Tháng ngay ngày tính và Tháng kế Tiếp đó)
	Select nv.NV_Ma,PN_SoNgayNamNay=case 
									when Round(Cast((DATEDIFF(DAY,NV_Ngayvao,DATEADD(MONTH,1,NV_Ngayvao))-DAY(NV_Ngayvao)+1 ) As Float)-- Phải dùng Cast để lấy phần thập phân nếu 0 sẽ bị làm tròn thành 0 dẫn tới sót KQ
										/(DATEDIFF(DAY,NV_Ngayvao,DATEADD(MONTH,1,NV_Ngayvao))),3) --Nếu ngày làm việc / Tổng ngày của tháng đủ từ 1/2 thì xem như đủ điều kiện hưởng 1 ngày phép năm của tháng đó
										>=0.5
										then (DATEDIFF(MONTH,NV_Ngayvao,@NgayHienTai))+1 --Tính đủ tháng
									else (DATEDIFF(MONTH,NV_Ngayvao,@NgayHienTai))--Tính từ ngày vào
									end
	From ST_NHANVIEN As nv Inner Join ST_HOPDONGLAODONG As hd on nv.NV_Ma=hd.NV_Ma
	Where nv.NV_Ma not in (Select NV_Ma From ST_NHANVIENTHOIVIEC)
		and nv.DV_MA not in ('NV','BGD','CGX')
		and (nv.CVU_MA like 'CN' OR DATEDIFF(DAY,nv.NV_Ngayvao,nv.NV_NGAYKHD) <20)--Lấy chức vụ không phải là CN và thời gian thử việc dưới 20 ngày (tuy CN chỉ TV 6 ngày nhưng trừ hao có ngày nghỉ lễ)
		and YEAR(nv.NV_Ngayvao)>=YEAR(@NgayDauNam) --Công nhân mới vào thì có ngay phép năm 
		and NV.NV_Ma in (Select NV_Ma From ST_HOPDONGLAODONG)
	) As b on a.NV_Ma=b.NV_Ma and a.PN_Nam=Year(@NgayDauNam) 
------------------------------------------------------------------------------PHÉP NĂM THÂM NIÊN-----------------------------------------------------------------------
-------Nhân viên có thêm 5 năm làm việc thì được cộng 1 ngày phép năm------------------------
-----------B1:Select các đối tượng để kiểm tra
---TH: Được 1 ngày phép năm ( 5<= Năm làm <10)
Select *
From ST_PhepNam As pn Inner join
	(
	Select NV_Ma,DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI) AS [Số Tháng],DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 As [Tổng số tháng]
	From ST_NHANVIEN 
	Where NV_Ma not in (select NV_Ma from ST_NHANVIENTHOIVIEC)
		and DV_MA not in('NV','BGD','CGX')
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 >=5 
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 <10
	) As nv on pn.NV_Ma=nv.NV_Ma and pn.PN_Nam=year(@NGAYHIENTAI)

---Được 2 ngày phép năm ( Năm làm >10 )
Select *
From ST_PhepNam As pn Inner join
	(
	Select NV_Ma,DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI) AS [Số Tháng],DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 As [Tổng số tháng]
	From ST_NHANVIEN 
	Where NV_Ma not in (select NV_Ma from ST_NHANVIENTHOIVIEC)
		and DV_MA not in('NV','BGD','CGX')
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 >=10 
	) As nv on pn.NV_Ma=nv.NV_Ma and pn.PN_Nam=year(@NGAYHIENTAI)

-----------B2: Cập nhật các trường hợp-----------
---TH: Được 1 ngày phép năm ( 5<= Năm làm <10)
Update pn
Set pn.PN_PhepTren5Nam='1'
From ST_PhepNam As pn Inner join
	(
	Select NV_Ma,DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI) AS [Số Tháng],DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 As [Tổng số tháng]
	From ST_NHANVIEN 
	Where NV_Ma not in (select NV_Ma from ST_NHANVIENTHOIVIEC)
		and DV_MA not in('NV','BGD','CGX')
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 >=5 
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 <10
	) As nv on pn.NV_Ma=nv.NV_Ma and pn.PN_Nam=year(@NGAYHIENTAI)
---Được 2 ngày phép năm ( Năm làm >=10 )
Update pn
Set pn.PN_PhepTren5Nam='2'
From ST_PhepNam As pn Inner join
	(
	Select NV_Ma,DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI) AS [Số Tháng],DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 As [Tổng số tháng]
	From ST_NHANVIEN 
	Where NV_Ma not in (select NV_Ma from ST_NHANVIENTHOIVIEC)
		and DV_MA not in('NV','BGD','CGX')
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 >=10 
	) As nv on pn.NV_Ma=nv.NV_Ma and pn.PN_Nam=year(@NGAYHIENTAI)
---Được 3 ngày phép năm ( Năm làm >=15 )
Update pn
Set pn.PN_PhepTren5Nam='3'
From ST_PhepNam As pn Inner join
	(
	Select NV_Ma,DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI) AS [Số Tháng],DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 As [Tổng số tháng]
	From ST_NHANVIEN 
	Where NV_Ma not in (select NV_Ma from ST_NHANVIENTHOIVIEC)
		and DV_MA not in('NV','BGD','CGX')
		and DATEDIFF(MONTH,NV_NGAYVAO, @NGAYHIENTAI)/12 >=15 
	) As nv on pn.NV_Ma=nv.NV_Ma and pn.PN_Nam=year(@NGAYHIENTAI)