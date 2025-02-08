
--------------------------------------------------------XỬ LÝ LỖI LẤY GIỜ QUẸT THẺ TỪ MF_RECORD VÀO ST_VÀO RA BỊ SAI GIỜ BẰNG GIẢI PHÁP CẬP NHẬT LẠI TỪ MF_RECORD VÀO ST VAO RA
--Lọc đối tượng chấm công sai,đễ tiến hành xử lý đảm bảo số lượng 3 bảng dưới phải bằng nhau hếu mới ok

SELECT * FROM ST_GIOQUETTHE WHERE QT_NGAY = '2024-09-21' AND CC_GIOBINHTHUONG = '7.5'

SELECT * FROM ST_VAORA
WHERE  QT_NGAY = '2024-09-21'
		AND QT_CHONCA = 1
		AND NV_MA IN (SELECT NV_Ma FROM A_NV_MA)


SELECT UserNo,* FROM MF_Record 
WHERE  MatTime > '2024-09-21 05:00:00'AND MatTime < '2024-09-21 08:00:00'
	AND UserNo IN (SELECT NV_Ma FROM A_NV_MA) ORDER BY MF_Record.UserNo

SELECT * FROM A_NV_MA

--A:------------------------------CẬP NHẬT BẢNG TẠM A_NV_MA CÁC SỐ THẺ QUẸT VÀO NHIỀU HƠN 1 LẦN
-----B1:Tạo bảng Tạm Common Table Expression (CTE) là 1 biểu thức tạm thời để xóa các thẻ có quẹt thẻ từ lần thứ 2 trở lên

WITH CTE AS 
	(
	SELECT * ,ROW_NUMBER() OVER (ORDER BY MatTime ASC) AS RowNum
	FROM MF_Record
	WHERE  MatTime > '2024-09-21 05:00:00'AND MatTime < '2024-09-21 08:00:00'
		AND UserNo = '314650'
	)
SELECT * FROM CTE WHERE CTE.RowNum > 1


-----B2: Xóa các dòng quẹt thẻ thứ 2 giờ vào, do tính lần quẹt đầu tiên
----Ví Dụ Về Con Trỏ----
---------------------------
--Khai báo bảng chứa cursor
----Ví Dụ Về Con Trỏ----
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
	   Select NV_Ma
	   FROM A_NV_MA
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA char(6)--,@NV_Ten Nvarchar(30),@DV_MA char(6),@CVU_MA char(6) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	WITH CTE AS 
	(
	SELECT * ,ROW_NUMBER() OVER (ORDER BY MatTime ASC) AS RowNum
	FROM MF_Record
	WHERE  MatTime > '2024-09-21 05:00:00'AND MatTime < '2024-09-21 08:00:00'
		AND UserNo = @NV_MA
	)
    DELETE FROM CTE WHERE CTE.RowNum > 1
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
END
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT

------Kiểm tra số làn quẹt sau khi xóa của các thẻ quẹt nhiều lần
SELECT UserNo,COUNT(UserNo) FROM MF_Record 
WHERE  MatTime > '2024-09-21 05:00:00'AND MatTime < '2024-09-21 08:00:00'
	AND UserNo IN (SELECT NV_Ma FROM A_NV_MA)
GROUP BY UserNo

--B:------------------------------CẬP NHẬT BẢNG TẠM A_NV_MA CÁC SỐ THẺ QUẸT VÀO NHIỀU HƠN 1 LẦN, SAU ĐÓ UPDATE LẠI ST_VAORA CHO DÚNG VỚI MF_RECORD

SELECT * FROM ST_VAORA
WHERE  QT_NGAY = '2024-09-21'
		AND QT_CHONCA = 1
		AND NV_MA IN (SELECT NV_Ma FROM A_NV_MA)


SELECT UserNo FROM MF_Record 
WHERE  MatTime > '2024-09-21 05:00:00'AND MatTime < '2024-09-21 08:00:00'
	AND UserNo IN (SELECT NV_Ma FROM A_NV_MA)
--CẬP NHẬT
SELECT A.QT_GIOVAO,B.MatTime,A.CA_MA
FROM ST_VAORA A INNER JOIN MF_Record B ON A.NV_MA = B.UserNo
WHERE  A.QT_NGAY = '2024-09-21'
		AND A.QT_CHONCA = 1
		AND A.NV_MA IN (SELECT NV_Ma FROM A_NV_MA)
		AND B.MatTime > '2024-09-21 05:00:00'AND B.MatTime < '2024-09-21 08:00:00'

--UPDATE A
SET A.QT_GIOVAO = B.MatTime
FROM ST_VAORA A INNER JOIN MF_Record B ON A.NV_MA = B.UserNo
WHERE  A.QT_NGAY = '2024-09-21'
		AND A.QT_CHONCA = 1
		AND A.NV_MA IN (SELECT NV_Ma FROM A_NV_MA)
		AND B.MatTime > '2024-09-21 05:00:00'AND B.MatTime < '2024-09-21 08:00:00'

--C:-----------------------------CHẤM CÔNG LẠI CÁC ĐỐI TƯỢNG SAI
----Ví Dụ Về Con Trỏ----
---------------------------
--Khai báo bảng chứa cursor
----Ví Dụ Về Con Trỏ----
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
	   Select NV_Ma
	   FROM A_NV_MA
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA_1 char(6)--,@NV_Ten Nvarchar(30),@DV_MA char(6),@CVU_MA char(6) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA_1--,@NV_TEN,@DV_MA,@CVU_MA -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	exec SP_CHAMCONGN  '2024-09-21 00:00:00',@NV_MA_1,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1
	EXEC SP_CAPNHATTANGCA300_SOTHE '2024-09-21 00:00:00',@NV_MA_1	
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA_1--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
END
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT