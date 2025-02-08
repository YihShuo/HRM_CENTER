
----------------- Đợi khi nào NS có yêu cầu sửa phần mềm thì tính
	--Andrew đã viết sẵn code Cập nhật lại trường hợp những người đi làm không thỏa đk ít nhất đủ 3 ngày liên tục trong SP_SP_DSNGHIHANHKINH_CHUYENDULIEU_I
SELECT * 
FROM IT_SOGIONGHIHANHKINH 
WHERE NV_MA = '339007' AND NAM = '2024'AND	 THANG = '08'

--UPDATE IT_SOGIONGHIHANHKINH 
SET TONGSOGIO = Null
WHERE NV_MA = '339007' AND NAM = '2024'AND	 THANG = '08'

select * 
FROM IT_PHUNUHANHKINH
WHERE NV_MA = '339007'

SELECT * 
FROM IT_SOGIONGHIHANHKINH 
WHERE  NAM = '2024'AND	 THANG = '08'