-----------------Các Trường  Họp Làm Sau 12h, có quẹt thẻ Ca 3 nhưng không được tính công (Đưa vào ca HC)------
----------------------Lý Do Sau 12h đêm chỉ cho 15 phút để quẹt thẻ, ngoài thời gian trên được tính là ngày mới nên không tính
---------Kiểm tra số lượng
Declare @ngay As Datetime
Set @ngay='2024-10-31'
Select a.NV_MA,NgayVao=Convert(nvarchar,a.QT_NGay,103),a.CA_MA,GioVaoHC=Convert(nvarchar,(a.QT_GIOVAO),108)
											  ,GioRaHC=Convert(nvarchar,a.QT_GIORA,108)
											  ,b.NV_MA
											  ,NgayRa=Convert(nvarchar,DateAdd(DAY,1,b.QT_Ngay),103)
											  ,b.CA_MA
											  ,GioVaoCa=Convert(nvarchar,b.QT_GIOVAO,108)
											  ,GioRaCa=Convert(nvarchar,b.QT_GIORA,108)
From ST_VAORA As a Inner Join (Select *
								From ST_VAORA
								Where QT_NGAY=@ngay
								AND QT_GIOVAO is NULL
								AND QT_GIORA IS NOT NULL
								AND CA_MA ='Ca 3'
								) AS b ON a.NV_MA=b.NV_MA
WHERE a.QT_NGAY=@ngay 
		AND a.QT_GioVao IS NOT NULL
		AND a.CA_MA ='Ca HC'---Do công nhân nên ca chắc chắn phải là HC và phải có quẹt giờ vào
		AND (
				(a.QT_GIORA is NULL AND Convert(nvarchar,b.QT_GIORA,108) >= '00:00:00')
				OR (CONVERT(DATE,a.QT_GIORA)>@ngay)
			)
Order by a.NV_MA
/*					   
Union All
Select a.NV_MA,NgayVao=Convert(nvarchar,a.QT_NGay,103),a.CA_MA,GioVaoHC=Convert(nvarchar,(a.QT_GIOVAO),108)
											  ,GioRaHC=Convert(nvarchar,a.QT_GIORA,108)
											  ,b.NV_MA
											  ,NgayRa=Convert(nvarchar,DateAdd(DAY,1,b.QT_Ngay),103)
											  ,b.CA_MA
											  ,GioVaoCa=Convert(nvarchar,b.QT_GIOVAO,108)
											  ,GioRaCa=Convert(nvarchar,b.QT_GIORA,108)
From ST_VAORA As a Inner Join (Select *
								From ST_VAORA
								Where QT_NGAY='2020-06-02' 
								and QT_GIOVAO is Null and QT_GIORA is not NULL And CA_MA ='Ca 4'
								) As b On a.NV_MA=b.NV_MA
Where a.QT_NGAY='2020-06-02' and a.QT_GioVao is not Null and a.QT_GIORA is NULL And a.CA_MA ='Ca HC'---Do công nhân nên ca chắc chắn phải là HC và phải có quẹt giờ vào
						     and Convert(nvarchar,b.QT_GIORA,108) >= '00:00:00'
*/

/*Tham Khảo hàm Lên ca - Xuống Ca
-----LENCA---
((datepart(hh,ST_VAORA.QT_GIOVAO)<7)
OR ((datepart(hh,ST_VAORA.QT_GIOVAO)=7 and datepart(mi,ST_VAORA.QT_GIOVAO)<15))
OR ((datepart(mi,ST_VAORA.QT_GIOVAO)>30 AND datepart(mi,ST_VAORA.QT_GIOVAO)<=45 )))
---XUONGCA-- 
and(datepart(hh,ST_VAORA.QT_GIORA)=16 and ((datepart(mi,ST_VAORA.QT_GIORA)>30)AND (datepart(mi,ST_VAORA.QT_GIORA)<=45)))
and ST_NHANVIEN.NV_Ma not in(select NV_Ma FROM ST_NHANVIENTHOIVIEC)
and ST_VAORA.CA_MA='Ca HC'
and ST_NHANVIEN.DV_MA not like '%CG%' and ST_NHANVIEN.DV_MA not like '%GD%' 
and ST_NHANVIEN.DV_MA not like 'DT%' and ST_NHANVIEN.DV_MA not in ('T','T01','T02','T03','T04')
*/