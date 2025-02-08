USE [P0104-TYTHAC]
Go
------------Thống Kê Ngày Công Trong Tháng------
---------------
Declare @Nam as Int, @Thang as Int, @Ngay  as Datetime,@NgayCuoiThang as Datetime
Set @Ngay='2022-02-01'
Set @Nam=Year(@Ngay)
Set @Thang=Month(@Ngay)
SET @NgayCuoiThang= DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,@Ngay)+1, 0)) --Để tìm ra ngày cuối cùng của tháng hiện tại, bạn chỉ việc lấy ngày đầu tiên của tháng sau rồi bớt đi 1 ngày


Select a.DV_MA,a.DV_TEN,a.TTCV,Sum(a.GioBT) As [Giờ Bình Thường],Sum(a.TangCa) As [Tăng Ca],Sum(a.Tong) As [Tổng]
From
	(	
	Select dd.DV_MA,dv.DV_TEN,cv.TTCV 
		,ISNULL(qt.CC_GIOBINHTHUONG,0)+ISNULL(qt.CC_GIOBINHTHUONGTAY,0) as [GioBT]
		,ISNULL(qt.CC_GIOTANGCA,0)+ISNULL(qt.CC_GIOTANGCATAY,0) as [TangCa]
		,ISNULL(qt.CC_GIOBINHTHUONG,0)+ISNULL(qt.CC_GIOBINHTHUONGTAY,0)+ISNULL(qt.CC_GIOTANGCA,0)+ISNULL(qt.CC_GIOTANGCATAY,0) as [Tong]
	From ST_GIOQUETTHE As qt Left Join ST_NHANVIEN As nv on qt.NV_MA=nv.NV_Ma
							 Left Join ST_CONGVIEC As cv on cv.CV_MA=nv.CV_MA
							 LEFT JOIN ST_DONVI AS dv ON nv.DV_MA_ = dv.DV_MA -- Đang thử lấy theo DV_Ma hay DV_Ma_ (Nếu lấy DV_Ma_ thì số tổng đúng nhưng chi tết từng DV lại lêch)
							 INNER JOIN IT_DIEMDANHHANGNGAY dd ON qt.NV_MA=dd.NV_Ma
	Where YEAR(qt.QT_NGAY)=@Nam and MONTH(qt.QT_NGAY)=@Thang
								and (qt.CC_GIOBINHTHUONG>='1' OR qt.CC_GIOTHUCTE>='1' or qt.CC_GIOBINHTHUONGTAY>='1')
								AND dd.NGAY=@NgayCuoiThang
	) As a
Where a.DV_MA not like 'NV%' AND a.DV_MA NOT LIKE 'BGD'
Group by a.DV_MA,a.DV_TEN,a.TTCV
Order by a.DV_MA,a.DV_TEN
---------------
Select a.DV_MA,a.DV_TEN,a.TTCV,sum(a.TANGCA)[Tăng Ca] 
From
	(
	Select nv.DV_MA,dv.DV_TEN,cv.TTCV --"DV_MA" Phải lấy bảng nhân viên để đảm bảo đủ hết các phòng
		,ISNULL(CC_GIOBINHTHUONG,0)+ISNULL(CC_GIOBINHTHUONGTAY,0) [GioBT]
		,ISNULL(CC_GIOTANGCA,0)+ISNULL(CC_GIOTANGCATAY,0) [TANGCA]
		,ISNULL(CC_GIOBINHTHUONG,0)+ISNULL(CC_GIOTANGCA,0)+ISNULL(CC_GIOBINHTHUONGTAY,0)+ISNULL(CC_GIOTANGCATAY,0) [Tong]
	From ST_GIOQUETTHE_ qt Left Join ST_NHANVIEN nv on qt.NV_MA=nv.NV_Ma 
						   Left join ST_CONGVIEC cv on cv.CV_MA=nv.CV_MA
						   LEFT JOIN ST_DONVI AS dv ON nv.DV_MA = dv.DV_MA
	Where YEAR(qt.QT_NGAY)=@Nam and MONTH(qt.QT_NGAY)=@Thang
	) a
Where a.DV_MA not like 'NV%'
Group by a.DV_MA,a.DV_TEN,TTCV
Order by a.DV_MA

