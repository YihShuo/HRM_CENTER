------------------ Xuất theo năm
SELECT a.NV_Ma As [Mã Nhân Viên],[Họ Tên]=b.NV_Ten,
								[Giới Tính]= Case When b.NV_GioiTinh=1 Then 'Nam' else N'Nữ' end,
								[Đơn Vị]=b.DV_MA,
								[Nghỉ Từ Ngày]=convert(nvarchar,NP_TuNgay,103),
								[Nghỉ Đến Ngày]=convert(nvarchar,NP_DenNgay,103),
								[Loại Phép]=a.NP_Ma
From ST_NHANVIENNGHIPHEP As a Inner Join ST_NhanVien As b on (a.NV_Ma=b.NV_Ma and b.DV_MA not like 'NV%')
Where Year(NP_TuNgay)='2022'  
Order by a.NP_DenNgay

------------------Xuất theo tháng
SELECT a.NV_Ma As [Mã Nhân Viên],[Họ Tên]=b.NV_Ten,
								[Giới Tính]= Case When b.NV_GioiTinh=1 Then 'Nam' else N'Nữ' end,
								[Đơn Vị]=b.DV_MA,
								[Nghỉ Từ Ngày]=convert(nvarchar,NP_TuNgay,103),
								[Nghỉ Đến Ngày]=convert(nvarchar,NP_DenNgay,103),
								[Loại Phép]=a.NP_Ma
From ST_NHANVIENNGHIPHEP As a Inner Join ST_NhanVien As b on (a.NV_Ma=b.NV_Ma and b.DV_MA not like 'NV%')
Where Year(NP_TuNgay)='2022'  
		AND MONTH(a.NP_TuNgay)='2'
		--AND a.NP_Ma !='P'
Order by a.NP_DenNgay

------------------
--Select a.NV_Ma ,
--				b.DV_MA,
--				COUNT(a.NP_Ma)
--From ST_NHANVIENNGHIPHEP As a Inner Join ST_NhanVien As b on (a.NV_Ma=b.NV_Ma and b.DV_MA not like 'NV%')
--Where Year(NP_TuNgay)='2022' AND MONTH(a.NP_TuNgay) ='6'
--GROUP BY a.NV_Ma, b.DV_MA

-------------Sữa lỗi excel không gộp theo tháng
Select a.NV_Ma As [Mã Nhân Viên],[Họ Tên]=b.NV_Ten,
								[Giới Tính]= Case When b.NV_GioiTinh=1 Then 'Nam' else N'Nữ' end,
								[Đơn Vị]=b.DV_MA,
								[Nghỉ Từ Ngày]=NP_TuNgay,
								[Nghỉ Đến Ngày]=NP_DenNgay,
								[Loại Phép]=a.NP_Ma
From ST_NHANVIENNGHIPHEP As a Inner Join ST_NhanVien As b on (a.NV_Ma=b.NV_Ma and b.DV_MA not like 'NV%')
Where  
	-------
	--YEAR(NP_TuNgay)='2022' AND MONTH(a.NP_TuNgay)='12' )
	 (Year(NP_TuNgay)='2022' AND MONTH(a.NP_TuNgay)='01' )
	--AND a.NP_Ma='RO'
	-------

	--a.NP_TuNgay>='2021-01-01' AND a.NP_DenNgay <='2021-06-30'
	--------

Order by a.NP_DenNgay