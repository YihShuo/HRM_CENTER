USE [P0104-TYTHAC]
Go
------------Thống Kê Ngày Công Trong Tháng------
---------------
Declare @Nam as Int, @Thang as Int, @Ngay as Datetime
Set @Ngay='2022-02-01'
Set @Nam=Year(@Ngay)
Set @Thang=Month(@Ngay)


Select a.NV_Ma,a.NV_Ten,a.DV_MA_,a.CVU_MA,a.TTCV,Sum(a.GioBT) As [Giờ Bình Thường],Sum(a.TangCa) As [Tăng Ca],Sum(a.Tong) As [Tổng]
From
	(	
	Select nv.NV_Ma,nv.NV_Ten,nv.DV_MA_,nv.CVU_MA,cv.TTCV --"DV_MA" Phải lấy bảng nhân viên để đảm bảo đủ hết các phòng
		,ISNULL(qt.CC_GIOBINHTHUONG,0)+ISNULL(qt.CC_GIOBINHTHUONGTAY,0) as [GioBT]
		,ISNULL(qt.CC_GIOTANGCA,0)+ISNULL(qt.CC_GIOTANGCATAY,0) as [TangCa]
		,ISNULL(qt.CC_GIOBINHTHUONG,0)+ISNULL(qt.CC_GIOBINHTHUONGTAY,0)+ISNULL(qt.CC_GIOTANGCA,0)+ISNULL(qt.CC_GIOTANGCATAY,0) as [Tong]
	From ST_GIOQUETTHE As qt Left Join ST_NHANVIEN As nv on qt.NV_MA=nv.NV_Ma
							 Left Join ST_CONGVIEC As cv on cv.CV_MA=nv.CV_MA
	Where YEAR(qt.QT_NGAY)=@Nam and MONTH(qt.QT_NGAY)=@Thang
								and (qt.CC_GIOBINHTHUONG>='1' OR qt.CC_GIOTHUCTE>='1' or qt.CC_GIOBINHTHUONGTAY>='1')
	) As a
Where a.DV_MA_ not like 'NV%'
Group by a.NV_Ma,a.NV_Ten,a.DV_MA_,a.TTCV,a.CVU_MA
Order by DV_MA_
---------------
Select a.NV_Ma,a.NV_Ten,a.DV_MA,a.CVU_MA,a.TTCV,sum(a.TANGCA)[Tăng Ca] 
From
	(
	Select nv.NV_Ma,nv.NV_Ten,nv.DV_MA,nv.CVU_MA,cv.TTCV --"DV_MA" Phải lấy bảng nhân viên để đảm bảo đủ hết các phòng
		,ISNULL(CC_GIOBINHTHUONG,0)+ISNULL(CC_GIOBINHTHUONGTAY,0) [GioBT]
		,ISNULL(CC_GIOTANGCA,0)+ISNULL(CC_GIOTANGCATAY,0) [TANGCA]
		,ISNULL(CC_GIOBINHTHUONG,0)+ISNULL(CC_GIOTANGCA,0)+ISNULL(CC_GIOBINHTHUONGTAY,0)+ISNULL(CC_GIOTANGCATAY,0) [Tong]
	From ST_GIOQUETTHE_ qt Left Join ST_NHANVIEN nv on qt.NV_MA=nv.NV_Ma 
						   Left join ST_CONGVIEC cv on cv.CV_MA=nv.CV_MA
	Where YEAR(qt.QT_NGAY)=@Nam and MONTH(qt.QT_NGAY)=@Thang
	--Order by nv.DV_MA 
	) a
Where a.DV_MA not like 'NV%'
Group by a.NV_Ma,a.NV_Ten,DV_MA,TTCV,a.CVU_MA
Order by DV_MA