SELECT NV_Ma,NV_Ten,DV_MA
	   NV_NoiSinh
	   ,NV_DiaChi		--Hệ thống mới tạo thành, dựa vào đây để hiển thị bên cụm ĐỊA CHỈ ( "Ô ghép các Tỉnh,Xã,Phường")
	   ,NV_Thuongtru    --Hệ Thống Cũ Kéo Qua giữ nguyên, còn HT mới nhập vào thì sẽ lấy giống như NV_DiaChi
	   ,QT_MA
	   ,NV_QueQuan      --Hệ Thống Mới lấy theo QUÊ QUÁN  ( "Ô ghép các Tỉnh,Xã,Phường")
	   ,TT_MA ,QH_MA                                         --Bên HT Mới là Cột nhập theo CMND ở trên
	  ,0
	  ,NV_XaPhuongQQ,NV_QuanHuyenQQ,NV_TinhQQ				--Bên HT Mới là Dòng "Quê Quán"
	  ,0
	  ,NV_SoNhaDC,NV_XaPhuongDC,NV_QuanHuyenDC,NV_TinhDC    --Bên HT Mới dòng "Liên Hệ" ở dưới
FROM ST_NHANVIEN WHERE NV_Ma IN ( '316503','000010','300005')


----Lấy tên qui ước địa chỉ cho nhân sự nhập
SELECT qh.TT_MA, qh.QH_TEN, xp.XP_Ten
FROM ST_QUANHUYEN qh INNER JOIN ST_XAPHUONG xp ON qh.TT_MA=xp.TT_MA
												AND qh.QH_MA=xp.QH_MA
ORDER BY qh.TT_MA,qh.QH_TEN,xp.XP_Ten
------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------Chuyển DS Nhân sự nhập địa chỉ chữ chuyển thành số vào hệ thống-----------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------

SELECT a.*		
		--Quê Quán
		,(SELECT QH_MA 
			FROM ST_QUANHUYEN 
			WHERE a.NV_TinhQQ=ST_QUANHUYEN.TT_MA
				  AND a.NV_QuanHuyenQQ=ST_QUANHUYEN.QH_TEN
		  ) AS [Quận Huyện (QQ)]
		,(SELECT XP_Ma 
			FROM ST_XAPHUONG 
			WHERE a.NV_TinhQQ=ST_XAPHUONG.TT_MA
				  AND a.NV_XaPhuongQQ=ST_XAPHUONG.XP_Ten
		  ) AS [Xã Phường (QQ)]
		--Địa Chỉ
		,(SELECT QH_MA 
			FROM ST_QUANHUYEN 
			WHERE a.NV_TinhDC=ST_QUANHUYEN.TT_MA
				  AND a.NV_QuanHuyenDC=ST_QUANHUYEN.QH_TEN
		  ) AS [Quận Huyện (DC)]
		,(SELECT XP_Ma 
			FROM ST_XAPHUONG 
			WHERE a.NV_TinhDC=ST_XAPHUONG.TT_MA
				  AND a.NV_XaPhuongDC=ST_XAPHUONG.XP_Ten
		  ) AS [Xã Phường (DC)]
		-----------------Ghép địa chỉ (Hệ thống mới đang lấy cột này) và thường trú
		,' ' + a.NV_SoNhaDC + ', ' + a.NV_XaPhuongDC + ',' + a.NV_QuanHuyenDC + ', ' + (
																							SELECT	TT_TEN
																							FROM ST_TINHTHANH
																							WHERE ST_TINHTHANH.TT_Ma=a.NV_TinhDC
																							) 
			AS [NV_DiaChi (GHEP)]
		,' ' + a.NV_SoNhaDC + ', ' + a.NV_XaPhuongDC + ',' + a.NV_QuanHuyenDC + ', ' + (
																							SELECT	TT_TEN
																							FROM ST_TINHTHANH
																							WHERE ST_TINHTHANH.TT_Ma=a.NV_TinhDC
																							)
			AS [NV_ThuongTru (GHEP)]
		-----------------Ghép Quê Quán (Hệ thống mới chỉ lấy cấp quận huyện tỉnh)
		,' ' + a.NV_XaPhuongQQ + ',' + a.NV_QuanHuyenQQ + ', ' + (
																							SELECT	TT_TEN
																							FROM ST_TINHTHANH
																							WHERE ST_TINHTHANH.TT_Ma=a.NV_TinhQQ
																							) 
			AS [NV_QueQuan (GHEP)]


		,b.NV_Ma, b.NV_Ten, b.NV_SoNhaDC, b.TT_MA, b.QH_MA, b.NV_TinhQQ, b.NV_QuanHuyenQQ, b.NV_XaPhuongQQ, b.NV_TinhDC, b.NV_QuanHuyenDC, b.NV_XaPhuongDC
FROM A_NhapDcNhanVien a INNER JOIN ST_NHANVIEN b ON a.NV_Ma=b.NV_Ma
		
--UPDATE b
SET b.NV_SoNhaDC = a.NV_SoNhaDC
	-------------------Chứng minh
	--, b.TT_MA = a.TT_MA 
	--, b.QH_MA = a.QH_MA 
	-------------------Quê Quán
	--, b.NV_TinhQQ = a.NV_TinhQQ 
	--, b.NV_QuanHuyenQQ = (SELECT QH_MA 
	--					  FROM ST_QUANHUYEN 
	--					  WHERE a.NV_TinhQQ=ST_QUANHUYEN.TT_MA
	--						  AND a.NV_QuanHuyenQQ=ST_QUANHUYEN.QH_TEN )
	--, b.NV_XaPhuongQQ = (SELECT XP_Ma 
	--					 FROM ST_XAPHUONG 
	--					 WHERE a.NV_TinhQQ=ST_XAPHUONG.TT_MA
	--						  AND a.NV_XaPhuongQQ=ST_XAPHUONG.XP_Ten )
	-----------------Địa Chỉ
	, b.NV_TinhDC = a.NV_TinhDC 
	, b.NV_QuanHuyenDC = (SELECT QH_MA 
						  FROM ST_QUANHUYEN 
						  WHERE a.NV_TinhDC=ST_QUANHUYEN.TT_MA
							  AND a.NV_QuanHuyenDC=ST_QUANHUYEN.QH_TEN ) 
	, b.NV_XaPhuongDC = (SELECT XP_Ma 
						 FROM ST_XAPHUONG 
						 WHERE a.NV_TinhDC=ST_XAPHUONG.TT_MA
							  AND a.NV_XaPhuongDC=ST_XAPHUONG.XP_Ten )
	-----------------Ghép địa chỉ (Hệ thống mới đang lấy cột này) và thường trú
	,b.NV_DiaChi = ' ' + a.NV_SoNhaDC + ', ' + a.NV_XaPhuongDC + ',' + a.NV_QuanHuyenDC + ', ' + (
																									SELECT	TT_TEN
																									FROM ST_TINHTHANH
																									WHERE ST_TINHTHANH.TT_Ma=a.NV_TinhDC
																									)
	,b.NV_Thuongtru =' ' + a.NV_SoNhaDC + ', ' + a.NV_XaPhuongDC + ',' + a.NV_QuanHuyenDC + ', ' + (
																									SELECT	TT_TEN
																									FROM ST_TINHTHANH
																									WHERE ST_TINHTHANH.TT_Ma=a.NV_TinhDC
																									)
	-------------------Ghép Quê Quán (Hệ thống mới chỉ lấy cấp quận huyện tỉnh)
	--,b.NV_QueQuan = ' ' + a.NV_XaPhuongQQ + ',' + a.NV_QuanHuyenQQ + ', ' + (
	--																			SELECT	TT_TEN
	--																			FROM ST_TINHTHANH
	--																			WHERE ST_TINHTHANH.TT_Ma=a.NV_TinhQQ
	--																			) 
FROM A_NhapDcNhanVien a INNER JOIN ST_NHANVIEN b ON a.NV_Ma=b.NV_Ma
------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------
----Xử lý theo QUÊ QUÁN
--SELECT nvdc.NV_Ma,nvdc.NV_Ten,qh.QH_TEN,qh.QH_MA,xp.XP_Ten,xp.XP_Ma
--FROM  A_NhapDcNhanVien nvdc INNER JOIN ST_NhanVien nv ON nvdc.nv_ma = nv.nv_ma
--							LEFT JOIN ST_QUANHUYEN qh ON nvdc.NV_TinhQQ=qh.TT_MA AND nvdc.NV_QuanHuyenQQ=qh.QH_TEN
--							LEFT JOIN ST_XAPHUONG  xp ON nvdc.NV_TinhQQ=xp.TT_MA AND nvdc.NV_XaPhuongQQ=xp.XP_Ten
		
----UPDATE nv
--SET nv.NV_XaPhuongQQ=xp.XP_Ma,
--	nv.NV_QuanHuyenQQ=qh.QH_MA,
--	nv.NV_TinhQQ=qh.QH_MA
--FROM A_NhapDcNhanVien nvdc INNER JOIN ST_NhanVien nv ON nvdc.nv_ma = nv.nv_ma
--							LEFT JOIN ST_QUANHUYEN qh ON nvdc.NV_TinhQQ=qh.TT_MA AND nvdc.NV_QuanHuyenQQ=qh.QH_TEN
--							LEFT JOIN ST_XAPHUONG  xp ON nvdc.NV_TinhQQ=xp.TT_MA AND nvdc.NV_XaPhuongQQ=xp.XP_Ten
--------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------
------Xử lý theo ĐỊA CHỈ
----SELECT nvdc.NV_Ma,nvdc.NV_Ten,qh.QH_TEN,qh.QH_MA,xp.XP_Ten,xp.XP_Ma
----FROM  A_NhapDcNhanVien nvdc INNER JOIN 	ST_NhanVien nv ON nvdc.nv_ma = nv.nv_ma
----							LEFT JOIN ST_QUANHUYEN qh ON nvdc.NV_TinhDC=qh.TT_MA AND nvdc.NV_QuanHuyenDC=qh.QH_TEN
----							LEFT JOIN ST_XAPHUONG  xp ON nvdc.NV_TinhDC=xp.TT_MA AND nvdc.NV_XaPhuongDC=xp.XP_Ten
		
------UPDATE nv
----SET nv.NV_XaPhuongDC=xp.XP_Ma,
----	nv.NV_QuanHuyenDC=qh.QH_MA,
----	nv.NV_TinhDC=qh.QH_MA
----FROM A_NhapDcNhanVien nvdc INNER JOIN 	ST_NhanVien nv ON nvdc.nv_ma = nv.nv_ma
----							LEFT JOIN ST_QUANHUYEN qh ON nvdc.NV_TinhDC=qh.TT_MA AND nvdc.NV_QuanHuyenDC=qh.QH_TEN
----							LEFT JOIN ST_XAPHUONG  xp ON nvdc.NV_TinhDC=xp.TT_MA AND nvdc.NV_XaPhuongDC=xp.XP_Ten

----------------------------------------------------------------------
-------B1: Tạo Table Để chép Excel
------DROP TABLE  A_NhapDcNhanVien
----SELECT NV_Ma,NV_Ten
----	  ,NV_SoNhaDC
----	  ,TT_MA,QH_MA                              --Bên HT Mới là Cột nhập theo CMND ở trên
----	  ,NV_TinhQQ,NV_QuanHuyenQQ,NV_XaPhuongQQ	--Bên HT Mới là Dòng "Quê Quán"
----	  ,NV_TinhDC,NV_QuanHuyenDC,NV_XaPhuongDC   --Bên HT Mới dòng "Liên Hệ" ở dưới
----INTO A_NhapDcNhanVien
----FROM ST_NHANVIEN 
----WHERE NV_Ma IN ( '316503','000010','300005')
----------------------------------------------------------------------
-----Đối chiếu số lượng: Tạo Table Để chép Excel


------SELECT * FROM ST_TINHTHANH
----SELECT * FROM ST_QUANHUYEN
----SELECT * FROM ST_XAPHUONG

------Như vậy DS gửi IT quan trọng là cột TT_MA, XP_Ten copy ra từ Table ST_XaPhuong
--SELECT * FROM A_NhapDcNhanVien
--SELECT * FROM ST_QUANHUYEN
--SELECT * FROM ST_XAPHUONG

--------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------Làm Tạm Xuất EXCEL cho NS vì Phần Mềm chưa có tín năng này------------------------------------------
--------------------------------------------------------------------------------------------------------------------------------------

--SELECT [Quan/Huyen]=(qh.QH_TEN),[Xa/Phuong]=(xp.XP_Ten),NV_Ma,NV_Ten,DV_MA
--	   NV_NoiSinh,NV_DiaChi,QT_MA,NV_Thuongtru,NV_QueQuan 
--	   ,nv.TT_MA ,nv.QH_MA                                         --Bên HT Mới là Cột nhập theo CMND ở trên
--	  ,0
--	  ,NV_XaPhuongQQ,NV_QuanHuyenQQ,NV_TinhQQ				--Bên HT Mới là Dòng "Quê Quán"
--	  ,0
--	  ,NV_SoNhaDC,NV_XaPhuongDC,NV_QuanHuyenDC,NV_TinhDC    --Bên HT Mới dòng "Liên Hệ" ở dưới
--FROM ST_NHANVIEN nv  LEFT JOIN ST_QUANHUYEN qh ON nv.NV_TinhDC=qh.TT_MA AND nv.NV_QuanHuyenDC=qh.QH_MA                              --Đang lấy theo Dòng "Liên Hệ"
--				     LEFT JOIN ST_XAPHUONG  xp ON nv.NV_TinhDC=xp.TT_MA AND nv.NV_QuanHuyenDC=xp.QH_MA AND nv.NV_XaPhuongDC=xp.XP_Ma  --Đang lấy theo Dòng "Liên Hệ"
--WHERE nv.DV_MA='NS'--NV_Ma = '314844' 
