--===============Thêm Xã/Phường không Quận Huyện===============
SELECT * FROM ST_TINHTHANH WHERE TT_Ma = 'ANGIANG'
SELECT * FROM ST_QUANHUYEN WHERE TT_MA ='ANGIANG' AND QH_MA = '100'
SELECT * FROM ST_XAPHUONG WHERE TT_MA = 'ANGIANG' AND QH_MA = '100'

--Thêm Không Quận Huyện
--INSERT INTO ST_QUANHUYEN (QH_MA, TT_MA, QH_TEN, QH_LOAI, QH_TAM)
VALUES (N'100',  -- QH_MA - nvarchar(50)
        N'ANGIANG',  -- TT_MA - nvarchar(50)
        N'NONE',  -- QH_TEN - nvarchar(50)
        N'NONE',  -- QH_LOAI - nvarchar(50)
        N''  -- QH_TAM - nvarchar(50)       
    )
--INSERT INTO	 ST_XAPHUONG (XP_Ma, QH_MA, TT_MA, XP_Ten, XP_GhiChu, XP_LOAI, XP_TAM)
VALUES (N'1', -- XP_Ma - nvarchar(50)
        N'100', -- QH_MA - nvarchar(50)
        N'ANGIANG', -- TT_MA - nvarchar(50)
        N'Tịnh Biên', -- XP_Ten - nvarchar(100)
        N'', -- XP_GhiChu - nvarchar(100)
        N'Xã', -- XP_LOAI - nvarchar(50)
        N'Tịnh Biên' -- XP_TAM - nvarchar(50)
    )

--==============
  SELECT TOP 10 * FROM ST_XAPHUONG 
SELECT TOP 10  * FROM ST_QUANHUYEN
SELECT TOP 10 * FROM ST_XAPHUONG 

--==================
SELECT NV_Ma,NV_Ten,DV_MA
		NV_NoiSinh
		,TT_MA ,QH_MA										--Bên HT Mới là Cột nhập theo CMND ở trên
		,0
	  --===========================
		,NV_XaPhuongQQ,NV_QuanHuyenQQ,NV_TinhQQ				--Bên HT Mới là Dòng "QUÊ QUÁN"
	   --===========================
		,NV_SoNhaDC,NV_XaPhuongDC,NV_QuanHuyenDC,NV_TinhDC  --Bên HT Mới dòng "LIÊN HỆ" ở dưới
	   --===========================
		,NV_DiaChi											--Hệ thống mới tạo thành,cột ẩn mờ,hiển thị bên cụm "LIÊN HỆ" ( "Ô ghép các Tỉnh,Xã,Phường")		
		,0
	  --===========================
	   ,NV_QueQuan											--Hệ Thống Mới lấy theo "QUÊ QUÁN"  ( "Ô ghép các Tỉnh,Xã,Phường")
	   ,NV_Thuongtru										--Hệ Thống Cũ Kéo Qua giữ nguyên, còn HT mới nhập vào thì sẽ lấy giống như NV_DiaChi
	   --===========================
	   ,QT_MA	   	  
FROM ST_NHANVIEN WHERE NV_Ma IN('341445')

SELECT *FROM ST_NHANVIEN WHERE NV_Ma IN('341445')
--============
---Câu lện thêm mới
exec SP_THEMMOI_NHANVIEN_S @MaNV=N'341446',@HoTen=N'GIK',@DonVi=N'CNM',@MaTu=N''
,@GioiTinh=0,@NgaySinh=N'2025/8/14',@TinhThanh=N'BACLIEU'
,@DiaChi=N', Bắc Lý, Hiệp Hoà, Bắc Giang',@Mail=N'',@QuocTich=N'VIE'
,@DanToc=N'K',@TonGiao=N'KHONG',@ThuongTru=N', Bắc Lý, Hiệp Hoà, Bắc Giang'
,@HonNhan=0,@SoCon=0,@NOIDUNGBS=N'',@BSHS=0,@SoCMND=N'',@NgayCap=N'2025/8/14'
,@NoiCap=N'',@DTNhaRieng=N'',@DTDD=N'',@NgayVao=N'2025/8/14',@TDHocVan=N''
,@TinHoc=N'',@NgoaiNgu=N'',@CongViec=N'A13-075',@ChucVu=N'CN',@NgayBoNhiem=N'2025/8/14'
,@ChuyenMon=N'',@QuanHuyen=N'6',@DANGVIEN=0,@NgayVaoDang=N'',@NOIVAO=N'',@TNVN=0,@TDCT=N''
,@TTQQ=N'BARIAVUNGTAU',@QHQQ=N'7',@XAQQ=N'3',@QUEQUAN=N'Bàu Chinh, Châu Đức, Bà Rịa-Vũng Tàu'
,@TTDC=N'BACGIANG',@QHDC=N'7',@XADC=N'21',@SONHA=N'',@KHUA=1,@KHUB=0,@NAMSINH=0,@NGUOITAO=N'admin'
,@TenVaccine_1=N'',@NgayVaccine_1=N'2025/8/14',@TenVaccine_2=N'',@NgayVaccine_2=N'2025/8/14'
,@TenVaccine_3=N'',@NgayVaccine_3=N'2025/8/14',@TenVaccine_4=N'',@NgayVaccine_4=N'2025/8/14'
,@TenVaccine_5=N'',@NgayVaccine_5=N'2025/8/14',@TenVaccine_6=N'',@NgayVaccine_6=N'2025/8/14'

