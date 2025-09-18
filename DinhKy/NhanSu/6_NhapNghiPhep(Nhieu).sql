SELECT *    FROM ST_NHANVIENNGHIPHEP --WHERE NV_Ma='313597' AND YEAR(NP_TuNgay)='2021' AND MONTH(NP_TuNgay)='9'

--B1:----------Xóa dữ liệu bảng tạm
SELECT * FROM A_ST_NHANVIENNGHIPHEP-- WHERE	NV_Ma IN('313597') AND NP_TuNgay = '2021-09-04 00:00:00.000'
--DELETE FROM A_ST_NHANVIENNGHIPHEP -- WHERE	NV_Ma IN('313597') AND NP_TuNgay = '2021-09-04 00:00:00.000'

-----------Xử lý NV Trùng hệ thống

SELECT a.NV_Ma,a.NP_TuNgay,a.NP_DenNgay,a.NP_Ma,b.NV_Ma,b.NP_TuNgay,b.NP_DenNgay,b.NP_Ma
FROM ST_NHANVIENNGHIPHEP a INNER JOIN A_ST_NHANVIENNGHIPHEP b ON a.NV_Ma = b.NV_Ma AND a.NP_TuNgay=b.NP_TuNgay

--DELETE a
FROM ST_NHANVIENNGHIPHEP a INNER JOIN A_ST_NHANVIENNGHIPHEP b ON a.NV_Ma = b.NV_Ma AND a.NP_TuNgay=b.NP_TuNgay


--B2:----------Xử lý NV Trùng từ file nhập
SELECT NV_Ma,NP_TuNgay,COUNT(NP_TuNgay) 
FROM A_ST_NHANVIENNGHIPHEP
GROUP BY NV_Ma,NP_TuNgay
HAVING COUNT(NP_TuNgay) >1

SELECT * FROM A_ST_NHANVIENNGHIPHEP WHERE NV_Ma IN (
													SELECT NV_Ma
													FROM A_ST_NHANVIENNGHIPHEP
													GROUP BY NV_Ma,NP_TuNgay
													HAVING COUNT(NP_TuNgay) >1
													)

--DELETE FROM A_ST_NHANVIENNGHIPHEP WHERE NV_Ma IN (
													SELECT NV_Ma
													FROM A_ST_NHANVIENNGHIPHEP
													GROUP BY NV_Ma,NP_TuNgay
													HAVING COUNT(NP_TuNgay) >1
													)
--B3:----------Nhập phép
INSERT INTO ST_NHANVIENNGHIPHEP(NV_Ma, NP_TuNgay, NP_DenNgay, DV_Ma, NP_Ma, NP_GhiChu, NP_NGAYNHAPPHEP,NP_CONGTYDUYET,SN_CHUNHAT)
SELECT NV_Ma, NP_TuNgay, NP_DenNgay, DV_Ma, NP_Ma, NP_GhiChu, NP_NGAYNHAPPHEP,NP_CONGTYDUYET,SN_CHUNHAT
FROM A_ST_NHANVIENNGHIPHEP



--B(Phụ):Nên để NS tự chấm----------Cập nhật phép cả cty vào Công theo tháng (Con Trỏ)
--SELECT * FROM ST_THANG WHERE T_MA = '11-2021'
--EXEC SP_CAPNHATNGHIPHEP_MACHINE @NGAY='2021-11-10'       -- Phần mềm chấm công chạy cả cty
--EXEC SP_CAPNHATNGHIPHEP @Ngay='2021-11-100 07:36:11',@NV_MA=N'' -- Phần mềm nhân sự chạy theo yêu cầu chỉ định của nhân viên

--EXEC SP_A_CapNhatPhepTheoThang @T_MA=N'11-2021' -- nvarchar(7)
