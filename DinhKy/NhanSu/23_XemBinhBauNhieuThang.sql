-----------------------Thống Kê  Bình Bầu Nhiều Tháng
--Dùng Left không dùng Inner vì Inner khi gộp với trường Null sẽ lấy toàn bộ Null (Các tháng chưa tới sẽ null)
Select Distinct a.NV_MA,a.NV_Ten,a.DV_Ma,Thang1= T1.BB_MA,Thang2= T2.BB_MA,Thang3= T3.BB_MA,Thang4= T4.BB_MA,Thang5= T5.BB_MA,Thang6= T6.BB_MA
						,Thang7= T7.BB_MA,Thang8= T8.BB_MA,Thang9= T9.BB_MA,Thang10= T10.BB_MA,Thang11= T11.BB_MA,Thang12= T12.BB_MA
						,Tong_A=Sum(Case When b.BB_MA='A'then 1 else 0  end)
						,Tong_B=Sum(Case When b.BB_MA='B'then 1 else 0  end)
						,Tong_C=Sum(Case When b.BB_MA='C'then 1 else 0  end)
						,Tong_D=Sum(Case When b.BB_MA='D'then 1 else 0  end)	
						,Tong_OX=Sum(Case When b.BB_MA='OX'then 1 else 0  end)	
From ST_NHANVIEN a  Left Join ST_BINHBAUTHANG b on a.NV_Ma=b.NV_MA and b.T_MA like '%2024'
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='01-2024') T1 on a.NV_MA=T1.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='02-2024') T2 on a.NV_MA=T2.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='03-2024') T3 on a.NV_MA=T3.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='04-2024') T4 on a.NV_MA=T4.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='05-2024') T5 on a.NV_MA=T5.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='06-2024') T6 on a.NV_MA=T6.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='07-2024') T7 on a.NV_MA=T7.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='08-2024') T8 on a.NV_MA=T8.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='09-2024') T9 on a.NV_MA=T9.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='10-2024') T10 on a.NV_MA=T10.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='11-2024') T11 on a.NV_MA=T11.NV_MA
					Left Join (Select NV_Ma,T_Ma,BB_Ma From ST_BinhBauThang Where  T_MA='12-2024') T12 on a.NV_MA=T12.NV_MA
Where  a.DV_MA not in ('CGX','BGD')	and a.DV_MA not like 'NV%' 
		AND a.DV_MA LIKE 'IT' 
		--AND a.NV_Ma='310148'
Group by a.NV_Ma,a.NV_Ten,a.DV_MA,T1.BB_MA,T2.BB_MA,T3.BB_MA,T4.BB_MA,T5.BB_MA,T6.BB_MA,T7.BB_MA,T8.BB_MA,T9.BB_MA,T10.BB_MA,T11.BB_MA,T12.BB_MA
Order by a.DV_MA 


 