-------Nhân viên có thêm 5 năm làm việc thì được cộng 1 ngày phép năm------------------------
----------Khai Báo---------
Declare @NGAYHIENTAI Date
Set @NGAYHIENTAI='2025-02-16'
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
