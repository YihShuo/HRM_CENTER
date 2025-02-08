--------------------------------------------------------Cập nhật tay Các Phụ Cấp Chuyên Cần Nhà Trọ Con Nhỏ Các CN Đi Làm Ở Nhà
-----------------------------------------------------------Tạo Và Cập Nhât Tay Vô Table A_HomeWorkSalary sau đó cập nhật trạng thái của ST_Luong để tham chiếu qua
--------------------------------------------------------------Cách này mỗi lần chấm lương sẽ bị mất, cần cập lại
SELECT * FROM A_HomeWorkSalary --WHERE NV_MA = '314321'
--DELETE  A_HomeWorkSalary
---Kiểm tra bảng lương
SELECT * 
FROM ST_LUONG AS a INNER JOIN A_HomeWorkSalary b ON a.NV_MA =b.NV_MA AND a.T_MA=b.T_MA

--Có 2 dòng lương
--                    
SELECT a.NV_MA,COUNT(a.NV_MA) 
FROM ST_LUONG AS a INNER JOIN A_HomeWorkSalary b ON a.NV_MA =b.NV_MA AND a.T_MA=b.T_MA
GROUP BY a.NV_MA
HAVING COUNT(a.NV_MA) >1
--
SELECT a.*
FROM ST_LUONG AS a INNER JOIN A_HomeWorkSalary b ON a.NV_MA =b.NV_MA AND a.T_MA=b.T_MA
WHERE a.NV_MA IN (
					SELECT a.NV_MA--,COUNT(a.NV_MA) 
					FROM ST_LUONG AS a INNER JOIN A_HomeWorkSalary b ON a.NV_MA =b.NV_MA AND a.T_MA=b.T_MA
					GROUP BY a.NV_MA
					HAVING COUNT(a.NV_MA) >1
				 )

------------Cập Nhật Trạng Thái
--UPDATE a
SET a.HOMEWORK = 'True'
FROM ST_LUONG AS a INNER JOIN A_HomeWorkSalary b ON a.NV_MA =b.NV_MA AND a.T_MA=b.T_MA

-------------------------------------------------------------

--SELECT * FROM A_HomeWorkSalary WHERE NV_MA = '314321'
----UPDATE A_HomeWorkSalary 
--SET	 ConNho ='0'
--WHERE NV_MA = '314321'

--SELECT * FROM A_HomeWorkSalary WHERE NV_MA = '315423'
----UPDATE A_HomeWorkSalary 
--SET	 ConNho ='15385'
--WHERE NV_MA = '315423'