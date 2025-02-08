-------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------Kết Nối Remote Server---------------------------------------------------------
--Vào Server OBJECT > LINKED SERVER > New LINKED SERVER (tạo kết nối mới)
---- Sa khi 2 server đã thông thì có thể trực tiếp chép
-------------------------------------------------------------------------------------------------------------------------------------------------
SELECT NV_Ma,NV_Ten,DV_MA
	   NV_NoiSinh,NV_DiaChi,QT_MA,NV_Thuongtru,NV_QueQuan 
	   ,TT_MA ,QH_MA                                         --Bên HT Mới là Cột nhập theo CMND ở trên
	  ,NV_XaPhuongQQ,NV_QuanHuyenQQ,NV_TinhQQ				--Bên HT Mới là Dòng "Quê Quán"
	  ,NV_SoNhaDC,NV_XaPhuongDC,NV_QuanHuyenDC,NV_TinhDC
FROM ST_NHANVIEN WHERE DV_MA = 'NS'

SELECT NV_Ma,NV_Ten,DV_MA
	   NV_NoiSinh,NV_DiaChi,QT_MA,NV_Thuongtru,NV_QueQuan 
	   ,TT_MA ,QH_MA                                         --Bên HT Mới là Cột nhập theo CMND ở trên
	  ,NV_XaPhuongQQ,NV_QuanHuyenQQ,NV_TinhQQ				--Bên HT Mới là Dòng "Quê Quán"
	  ,NV_SoNhaDC,NV_XaPhuongDC,NV_QuanHuyenDC,NV_TinhDC
 FROM [27.12_SERVER].[P0104-TYTHAC].dbo.ST_NHANVIEN WHERE DV_MA = 'NS'
 ------------------------------Cap Nhat
UPDATE main
SET main.NV_DiaChi=sub.NV_DiaChi,
	main.NV_Thuongtru=sub.NV_Thuongtru,
	main.NV_QueQuan=sub.NV_QueQuan,
	main.QH_MA=sub.QH_MA,
	main.NV_XaPhuongQQ=sub.NV_XaPhuongQQ,
	main.NV_QuanHuyenQQ=sub.NV_QuanHuyenQQ,
	main.NV_TinhQQ=sub.NV_TinhQQ,
	main.NV_SoNhaDC=sub.NV_SoNhaDC,
	main.NV_XaPhuongDC=sub.NV_XaPhuongDC,
	main.NV_QuanHuyenDC=sub.NV_QuanHuyenDC
 FROM ST_NHANVIEN AS main INNER JOIN [27.12_SERVER].[P0104-TYTHAC].dbo.ST_NHANVIEN AS sub ON main.NV_Ma=sub.NV_Ma
 WHERE main.DV_MA='NS'