-----------Xét trong tháng 6 nếu trong năm đủ 6 tháng thì được nghỉ 1 ngày, nếu hơn 6 tháng thì được hưởng 2 ngày- 
--------------------Nên Lấy Từ sau giữa tháng 6 trở đi mỗi năm, vì NS sẽ tính phép để gửi KT Tính Lương
-----------Khai Báo Biến-------------
-------
Declare @NgayHienTai As Date,
		@NgayDauNam As Date
Set @NgayHienTai='2025-06-16'--Ngày phải từ giửa tháng trở lên
Set @NgayDauNam=Cast(Year(@NgayHienTai) As varchar(4))+'-01-01'

---------------------------------------Update Table ST_PhepNam
--TH Update 0 ngày
UPDATE a
Set a.PN_NangnhocDH=0,a.PN_SothanglamNNDH=b.TCSOTHANGNNDH
From ST_PHEPNAM As a Inner Join
								(
								select NV_Ma
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)Thang_01
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)Thang_02 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)Thang_03
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)Thang_04 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)Thang_05 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)Thang_06 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)Thang_07 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)Thang_08 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)Thang_09 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)Thang_10
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)Thang_11 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)Thang_12   
								,TCSOTHANGNNDH= sum( dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)
													) 
								from ST_PHEPNAM 
								Group by NV_Ma,PN_Nam
								having PN_Nam=cast(YEAR(@NGAYHIENTAI) as nvarchar(4)) and sum(dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)	
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)
																							)<6
								)As b on a.NV_Ma=b.NV_Ma and a.PN_Nam=(Year(@NgayDauNam))

--TH Update 1 ngày
UPDATE a
Set a.PN_NangnhocDH=1,a.PN_SothanglamNNDH=b.TCSOTHANGNNDH
From ST_PHEPNAM As a Inner Join
								(
								select NV_Ma
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)Thang_01
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)Thang_02 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)Thang_03
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)Thang_04 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)Thang_05 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)Thang_06 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)Thang_07 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)Thang_08 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)Thang_09 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)Thang_10
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)Thang_11 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)Thang_12   
								,TCSOTHANGNNDH= sum( dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)
													) 
								from ST_PHEPNAM 
								Group by NV_Ma,PN_Nam
								having PN_Nam=cast(YEAR(@NGAYHIENTAI) as nvarchar(4)) and sum(dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)	
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)
																							)=6
								)As b on a.NV_Ma=b.NV_Ma and a.PN_Nam=(Year(@NgayDauNam))
--TH Update 2 ngày
Update a
Set a.PN_NangnhocDH=2,a.PN_SothanglamNNDH=b.TCSOTHANGNNDH
From ST_PHEPNAM As a Inner Join
								(
								select NV_Ma
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)Thang_01
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)Thang_02 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)Thang_03
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)Thang_04 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)Thang_05 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)Thang_06 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)Thang_07 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)Thang_08 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)Thang_09 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)Thang_10
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)Thang_11 
								,dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)Thang_12   
								,TCSOTHANGNNDH= sum( dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)
													+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)
													) 
								from ST_PHEPNAM 
								Group by NV_Ma,PN_Nam
								having PN_Nam=cast(YEAR(@NGAYHIENTAI) as nvarchar(4)) and sum(dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-01',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-02',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-03',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-04',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-05',@NGAYHIENTAI)	
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-06',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-07',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-08',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-09',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-10',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-11',@NGAYHIENTAI)
																							+dbo.fn_LayNNDH(NV_Ma,cast(YEAR(@NGAYHIENTAI) as nvarchar(4))+'-12',@NGAYHIENTAI)
																							)>6
								)As b on a.NV_Ma=b.NV_Ma and a.PN_Nam=(Year(@NgayDauNam))