-----------------------------------------------------------------------------------------------------------------------------
------------------------------Lỗi Là Các Đối Tượng Tăng Ca Vượt Bị Cắt Ra Công Ngoài Nhưng Không Tính Được Tăng Ca-----------
-----------------------------------Giải Pháp Là Cho Chép Chồng Lại Giờ Ra Rồi Tính------------------------------------------
-------------------------------------Tìm Đối Tượng Lỗi Trong Từng Ngày (Lổi Đa Phần Vào Ngày Thứ 7)--------------------------
--DECLARE @user NVARCHAR(18);
--DECLARE @ngay DATETIME;
--DECLARE @tinhTC DATETIME;
----SET @user = '325472'
--SET @ngay = '2022-10-08'
--SET @tinhTC = DATEADD(HOUR,17,@ngay)

--SELECT a.UserNo,a.MatTime,b.CC_GIOTANGCA AS [TangCaTrong],c.CC_GIOTANGCA AS [TangCaNgoai],*
--FROM (
--		SELECT UserNo,MAX(MatTime) AS MatTime
--		FROM MF_Record
--		WHERE  MatTime >= @ngay AND MatTime <(@ngay+1)
--		GROUP BY UserNo,MatTime
--		HAVING MatTime > @tinhTC --Có giờ quẹt ra từ 17h trở lên
--	 ) a INNER JOIN ST_GIOQUETTHE b ON	a.UserNo = b.NV_MA  AND B.QT_NGAY = @ngay
--	     INNER JOIN ST_GIOQUETTHE_ c ON	a.UserNo = c.NV_MA AND C.QT_NGAY = @ngay
--		 INNER JOIN ST_VAORA d ON a.UserNo = d.NV_MA AND d.QT_NGAY = @ngay AND d.CA_MA = 'Ca HC' AND d.QT_GIOVAO IS NOT NULL AND d.QT_GIORA IS NOT NULL
--WHERE ISNULL(b.CC_GIOTANGCA,0) = 0 AND ISNULL(c.CC_GIOTANGCA,0) =0
--	AND b.DV_MA NOT LIKE ('BV')
--	AND b.DV_MA NOT LIKE ('%BAOVE')
--ORDER BY a.UserNo

-------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-------------------------------------Chạy Con Trỏ Theo Từng Ngày Để Sửa Lỗi--------------------------
DECLARE @ngay DATETIME;
DECLARE @tinhTC DATETIME;
--SET @user = '325472'
SET @ngay = GETDATE()
SET @tinhTC = DATEADD(HOUR,17,@ngay)
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
	--Lọc ra bản để chạy con trỏ
		SELECT a.UserNo
		FROM (
				SELECT UserNo,MAX(MatTime) AS MatTime
				FROM MF_Record
				WHERE  MatTime >= @ngay AND MatTime <(@ngay+1)
				GROUP BY UserNo,MatTime
				HAVING MatTime > @tinhTC --Có giờ quẹt ra từ 17h trở lên
			 ) a INNER JOIN ST_GIOQUETTHE b ON	a.UserNo = b.NV_MA  AND B.QT_NGAY = @ngay
				 INNER JOIN ST_GIOQUETTHE_ c ON	a.UserNo = c.NV_MA AND C.QT_NGAY = @ngay
				 INNER JOIN ST_VAORA d ON a.UserNo = d.NV_MA AND d.QT_NGAY = @ngay AND d.CA_MA = 'Ca HC' AND d.QT_GIOVAO IS NOT NULL AND d.QT_GIORA IS NOT NULL
		WHERE ISNULL(b.CC_GIOTANGCA,0) = 0 AND ISNULL(c.CC_GIOTANGCA,0) =0
			AND b.DV_MA NOT LIKE ('BV')
			AND b.DV_MA NOT LIKE ('%BAOVE')
		ORDER BY a.UserNo
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA char(6)--Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	PRINT N'Các Mã Bị Lỗi:  ' + @NV_MA

	DECLARE @MaTu NVARCHAR(30), @GioRa DateTime;
	SET @MaTu = (SELECT NV_MaTu FROM ST_NHANVIEN WHERE NV_Ma=@NV_MA)

	--Tìm giờ ra trễ nhất bên máy chấm công
	SET @GioRa= (SELECT MAX(MatTime) FROM MF_Record WHERE UserNo = @NV_MA AND (MatTime >= @ngay AND MatTime < (@ngay +1)))
	SELECT @MaTu,@GioRa

	--Tính lại giờ ra
	exec SP_TINHVAORA              @MATU=@MaTu,@NGAY=@ngay,@GIO=@GioRa
	exec SP_TINHVAORA_             @MATU=@MaTu,@NGAY=@ngay,@GIO=@GioRa
	exec SP_TINHVAORA_MACHINE_NEW  @MATU=@MaTu,@NGAY=@ngay,@GIO=@GioRa,@InOut=N'02',@Shift=N'0',@Somay=N'09'
	exec SP_CHAMCONGBINHTHUONG_IN  @MATU=@MaTu,@NGAY=@ngay,@GIO=@GioRa,@InOut=N'02',@Shift=N'0',@Somay=N'09'
	exec SP_CHAMCONGBINHTHUONG_OUT @MATU=@MaTu,@NGAY=@ngay,@GIO=@GioRa,@InOut=N'02',@Shift=N'0',@Somay=N'09'

EXEC SP_CAPNHATTANGCA300_NHANVIEN_A @NGAY=@ngay,  @MATU=@MaTu 


	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT

