----------------------------------------------Xóa lỗi chuyên gia bị đồng loạt chấm công----------------------------------------------
--------------------------------------------------Nguyên nhân do có NV có mã thẻ, có đơn vị đang làm việc, nhưng không có mã từ
--------------------------------------------------dẫn đến thủ tục SP_TINHVAORA chấm ko ra được MANV cụ thể, nên cho lên cùng giờ hết
--------------------------------------------------các đối tượng này
SELECT * 
FROM ST_VAORA a INNER JOIN ST_NHANVIEN b ON a.NV_MA = b.NV_Ma
WHERE  b.DV_MA = 'CG' 
OR(b.DV_MA NOT LIKE 'NV%' AND b.NV_MaTu !=NULL) 
 AND a.QT_NGAY >= '2023-01-01'

 SELECT *
 FROM ST_NHANVIEN
 WHERE --DV_MA !='NV' AND NV_MaTu IS NULL
      --NV_MaTu IS NOT NULL
	  NV_MaTu !=''

--DELETE a 
FROM ST_VAORA a INNER JOIN ST_NHANVIEN b ON a.NV_MA = b.NV_Ma
WHERE  b.DV_MA = 'CG'
 AND a.QT_NGAY >= '2023-01-01'