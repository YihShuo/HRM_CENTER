---------------------Chuyên cần và trực nhật của CNH và PCN đều bằng 0
/*
	Lấy vd lương T7 2024, đv XVD, nv_ma= 311050																												(Sửa OK)
	Chỉnh lại CNH, PCN phụ cấp Chuyên cần và Trực nhật đều = 0																								(Sửa OK)
*/
---------------------Lương Nghỉ Việc
/*
	Lấy vd lương T7 2024, đv NV01, nv_ma= 338910
	Hiện tại hệ thống chưa tính được lương nghỉ việc (Kế toán vẫn đang tính trên Excel)
	Nhu cầu: tính lương trên hệ thống:
		- Hiện tại tính lương ĐN NV... còn sai cột:     Chuyên Cần (Cần sửa giống CNM: tức đi làm 1 ngày được 10k) trong khi hiện tại đang chạy dư			(Sửa OK)
														, Nhà Trọ (Cần sửa giống CNM,nhưng lấy thực tế không phân biệt trên hay dưới 15 ngày)               (Sửa OK)
														, Con Nhỏ (Cần sửa giống CNM,nhưng lấy thực tế không phân biệt trên hay dưới 15 ngày)               (Sửa OK)
														, Tiền BHXH,BHYT,BHTN																				(Sửa OK)
														, Tiền CD (Không Thu)																					(Sửa OK)
*/

SELECT * FROM ST_LUONG WHERE NV_MA = '338910' AND T_MA  = '07-2024'
SELECT CVU_MA FROM ST_NHANVIEN WHERE NV_Ma = '325070'
SELECT * FROM ST_DONVI WHERE DV_MA LIKE 'NV%'