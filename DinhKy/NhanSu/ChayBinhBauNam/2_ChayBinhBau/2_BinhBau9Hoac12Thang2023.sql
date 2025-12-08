	
SELECT * FROM IT_TABLE_BBCT WHERE NAM ='2025'
--Cập nhật lên các Table loại BB lưu ý và BBB phải chạy cuối cùng
-------------Bước A: Cập nhật---------------

EXEC [dbo].[SP_BINHBAUA] '2025','01-2025','12-2025'      --Lưu ý chỉnh trong SP Mốc Thời Gian Lấy là 9 và 3 chổ: chỉnh số xét số tháng làm việc; chỉnh điều kiện đánh liệt số ngày nghỉ; chỉnh điều kiện xét tổng A
Exec [dbo].[SP_BINHBAUANEW]'2025','01-2025','12-2025'    --Lưu ý chỉnh trong SP Mốc Thời Gian Lấy là 9 và 3 chổ: chỉnh số xét số tháng làm việc; chỉnh điều kiện đánh liệt số ngày nghỉ; chỉnh điều kiện chọn loại bỏ tháng bị OX
EXEC [dbo].[SP_BINHBAUC] '2025','01-2025','12-2025'      --Lưu ý chỉnh trong SP Mốc Thời Gian Lấy là 9 và 3 chổ:  chỉnh số xét số tháng làm việc; chỉnh điều kiện tổng số loại bình bầu bị đánh liệt; chỉnh điều kiện tổng số ngày nghỉ bị đánh liệt
EXEC [dbo].[SP_BINHBAUCNEW] '2025','01-2025','12-2025'   --Lưu ý chỉnh trong SP Mốc Thời Gian Lấy là 9 và 2 chổ:  chỉnh số xét số tháng làm việc； chỉnh điều kiện chọn loại bỏ tháng bị OX
EXEC [dbo].[SP_BINHBAUOx] '2025','01-2025','12-2025'
EXEC [dbo].[SP_BINHBAUB] '2025','01-2025','12-2025'
-------------Bước B: Cập nhật lên table tạm "IT_Table_BB_2013" để NS so chiếu từ CN (Phần mềm:Đánh giá hiệu quả công việc\Nhân sự\Bình Bầu\Danh Sách Bình Bầu Cuối Năm\Bình Bầu Tổng Hợp( rp_BB2011_CT_CB_CNV_DV.rpt )
SELECT * FROM IT_TABLE_BB2013 WHERE NAM = '2025' --AND DV_MA = 'IT'
--DELETE FROM IT_TABLE_BB2013 WHERE NAM = '2025'
EXEC [dbo].[SP_BINHBAUTONG] '2025'
EXEC [dbo].[SP_BINHBAUCT] '2025','12-2025'              -- Thể hiện bình bầu chi tiết từng tháng của nhân viên(trên HRM là sau khi click "Bình bầu chi tiết và bấm nút XEM"

----------Xem Chấm Trùng Dẫn Đến Không Thể Chạy Cập Nhật Vào Bình Bầu Tổng ([dbo].[SP_BINHBAUTONG]) -------
DECLARE @NAM INT,@NVMA NVARCHAR(6)
SET @NAM='2025'
SET @NVMA = '310765'
SELECT STT AS BinhBau_A,* FROM IT_Table_BBA WHERE NAM = @NAM AND NV_MA = @NVMA
SELECT STT AS BinhBau_ANew,* FROM IT_TABLE_BBANEW WHERE  NAM = @NAM AND NV_MA = @NVMA
SELECT STT AS BinhBau_C,* FROM IT_TABLE_BBC WHERE  NAM = @NAM AND NV_MA = @NVMA
SELECT STT AS BinhBau_CNew,* FROM IT_TABLE_BBCNEW WHERE  NAM = @NAM AND NV_MA = @NVMA
SELECT STT AS BinhBau_OX,* FROM IT_Table_BBOX WHERE  NAM = @NAM AND NV_MA = @NVMA
SELECT STT AS BinhBau_B,* FROM IT_Table_BBB WHERE  NAM = @NAM AND NV_MA = @NVMA

SELECT *
FROM IT_TABLE_BBANEW WHERE NV_MA IN (SELECT NV_MA FROM IT_TABLE_BBA) AND NAM = '2025'
SELECT *
FROM IT_TABLE_BBANEW WHERE NV_MA IN (SELECT NV_MA FROM IT_TABLE_BBC) AND NAM = '2025'

-----------------------------------


/*

-------------Bước D: Cập nhật Bằng Tay Các đối tượng đặt biệt (Có vướng nghỉ RO trong thời gian thử việc nhưng sau KHD trong tháng, lại bị gôm chung chấm;.....)
--Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
	   SELECT NV_MA,BB_Dung 
	   FROM A_BB2011_ChamTay
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA NVARCHAR(50), @BB_Dung NVARCHAR(50)
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA , @BB_Dung-- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	
	-----Update bảng chính
	UPDATE IT_TABLE_BBA SET BBN = @BB_Dung WHERE NV_MA = @NV_MA
	UPDATE IT_TABLE_BBANEW SET BBN = @BB_Dung WHERE NV_MA = @NV_MA
	UPDATE IT_TABLE_BBC SET BBN = @BB_Dung WHERE NV_MA = @NV_MA
	UPDATE IT_TABLE_BBCNEW SET BBN = @BB_Dung WHERE NV_MA = @NV_MA
	UPDATE IT_TABLE_BBB SET BBN = @BB_Dung WHERE NV_MA = @NV_MA
	UPDATE IT_TABLE_BBOX SET BBN = @BB_Dung WHERE NV_MA = @NV_MA
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA, @BB_Dung
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT
---------------Cập Nhật Vào BB Tổng và BB Chi Tiết
EXEC [dbo].[SP_BINHBAUTONG] '2025'
EXEC [dbo].[SP_BINHBAUCT] '2025','12-2025'              -- Thể hiện bình bầu chi tiết từng tháng của nhân viên
-------------------------------------------------------------------------------

*/

/*
-------------------------------------Hết----Tham Khảo--------------------------------------------------
-------------------------Xem Bảng Load Ben HRM:( HR\Bình Bầu\Danh sách bình bầu cuối năm(xem toàn bộ))
SELECT STT=0, ST_NHANVIEN.NV_TEN,ST_NHANVIEN.NV_NGAYVAO ,NAM ,NU,ST_NHANVIEN.NV_MA,ST_NHANVIEN.DV_MA, ST_NHANVIEN.NV_NGAYSINH
		, ST_NHANVIEN.NV_SOTHANG,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, 
		SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
FROM (SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA, NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
	  FROM IT_TABLE_BBA  
	  UNION 
	  SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA, NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
	  FROM IT_TABLE_BBANEW 
	  UNION 
	  SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA, NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
	  FROM IT_TABLE_BBC 
	  UNION 
	  SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA, NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
	  FROM IT_TABLE_BBCNEW 
	  UNION 
	  SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA, NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
	  FROM IT_TABLE_BBOX 
	  UNION 
	  SELECT STT=0, NV_TEN,NV_NGAYVAO ,NAM ,NU,NV_MA,DV_MA, NV_NGAYSINH,BBN,BBA ,BBB,BBC ,BBD,BBOX,BBHS,SONGAYOO,SONGAYRO,SONGAYCO,SONGAYO, SONGAYOTC,SONGAYP ,SONGAYKTHAI,SONGAYR,SONGAYS,SONGAYNO,SONGAYKHHGD,SONGAYQS,SONGAYTSAN, SONGAYTNLD,SONGAYDQ,SONGAYDS,SONGAYST 
	  FROM IT_TABLE_BBB) AS BB  
	  INNER JOIN ST_NHANVIEN ON BB.NV_MA = ST_NHANVIEN.NV_MA   
WHERE ST_NHANVIEN.DV_MA NOT IN ('T','T01','T02','T03','T04')  AND BB.NAM = '2025' ORDER BY  ST_NHANVIEN.NV_MA



--------------- Xem Load bên Report rp_BB2011_CT_CB_CNV_DV.rpt-----------------------
SELECT IT_TABLE_BB2013.*,IT_TABLE_BBCT.* 
		,ST_NHANVIEN.DV_MA,ST_NHANVIEN.NV_Ten 
		,CVU_MA , NV_SOTHANG , X_MA_ 
FROM ST_NHANVIEN INNER JOIN IT_TABLE_BB2013 ON ST_NHANVIEN.NV_Ma = IT_TABLE_BB2013.NV_MA AND IT_TABLE_BB2013.NAM ='2025'
				 INNER JOIN IT_TABLE_BBCT ON ST_NHANVIEN .NV_Ma = IT_TABLE_BBCT.NV_MA AND IT_TABLE_BBCT.NAM  = '2025'
				 INNER JOIN ST_DONVI ON ST_NHANVIEN.DV_MA = ST_DONVI .DV_MA
WHERE 
--ST_NHANVIEN.NV_Ma NOT IN (SELECT NV_Ma FROM ST_NHANVIENNGHIPHEP WHERE NP_MA = 'TS'
--AND NP_TuNgay <= '2014-01-25'
--AND NP_DenNgay>= '2014-01-25')
--AND
	ST_NHANVIEN.DV_MA NOT IN ('NV', 'NV01', 'NV02', 'NV03') 
ORDER BY ST_NHANVIEN.NV_MA

*/