-----------------------------------Xóa dữ liệu hình máy quẹt thẻ các nhân viên đã nghĩ việc Trên Máy F-830
SELECT 
	Face1,
	Face2,
	Face3,
	Face4,
	Face5,
	FaceImg11,
	FaceImg21,
	FaceImg31,
	FaceImg41,
	FaceImg51,
	* FROM MF_Users a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
	WHERE b.DV_MA like 'NV%'
	--AND a.UserNo = '325961'

UPDATE a
SET	Face1= null,
	Face2= null,
	Face3= null,
	Face4= null,
	Face5= null,
	FaceImg11= null,
	FaceImg21= null,
	FaceImg31= null,
	FaceImg41= null,
	FaceImg51= null
	FROM MF_Users a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
	WHERE b.DV_MA like 'NV%'
	--AND a.UserNo='325961'

--SELECT NV_NgayTV,NV_Ngayvao,NV_NGAYKHD,* FROM ST_NHANVIEN WHERE DV_MA ='NV'
--SELECT * FROM MF_Users WHERE UserNo = '325961'