----------------------------------Đôi khi cần chấm công lại 1 số trường hợp không rõ nguyên nhân mà bị cắt công sai
------------------------------------------Cách chấm này vẫn giữ lại các giá trị trong MF_RECORD, cách tính lấy giờ quẹt vào sớm nhất, giờ quẹt ra trễ nhất
-------------------------------------------------Chấm Nhiều Người Dựa Theo Danh Sách A_NV_MA
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
		SELECT NV_Ma,NgayThang
		FROM A_NV_MA
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA char(6),@NGAY_T DATETIME  --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA,@NGAY_T -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	--------------
	DECLARE  @Ngay DATE, @QuetVao DATETIME, @QuetVao_CL NVARCHAR(19), @QuetRa DATETIME,@QuetRa_CL NVARCHAR(19), @MaTu NVARCHAR(18) 


	SET @Ngay = CONVERT(DATE,@NGAY_T)
	SET @QuetVao = (Select MIN(MatTime) FROM MF_Record WHERE UserNo=@NV_MA AND CONVERT(DATE,MatTime)= @Ngay)
	SET @QuetVao_CL = CONVERT(NVARCHAR(19),@QuetVao,120)
	SET @QuetRa = (Select MAX(MatTime) FROM MF_Record WHERE UserNo=@NV_MA AND CONVERT(DATE,MatTime)= @Ngay)
	SET @QuetRa_CL = CONVERT(NVARCHAR(19),@QuetRa,120)
	SET @MaTu = (SELECT NV_MaTu FROM ST_NHANVIEN WHERE NV_Ma = @NV_MA)

	SELECT @QuetVao,@QuetRa,@QuetVao_CL,@QuetRa_CL
	----------------
	Delete From ST_VaoRa WHERE		NV_Ma=@NV_MA AND QT_Ngay=@NGAY_T
	DELETE FROM ST_GioQuetThe WHERE NV_Ma=@NV_MA AND QT_Ngay=@NGAY_T
	------------------------------------Công Ngoài
	Delete From ST_VaoRa_ WHERE		 NV_Ma=@NV_MA AND QT_Ngay=@NGAY_T
	DELETE FROM ST_GioQuetThe_ WHERE NV_Ma=@NV_MA AND QT_Ngay=@NGAY_T
	------------------------------------MF_RECORD
	DELETE MF_Record WHERE UserNo=@NV_MA AND  MatTime = @QuetVao
	DELETE MF_Record WHERE UserNo=@NV_MA AND  MatTime = @QuetRa
	--------------
	DECLARE @ErrorCode INT;
	EXEC mfsp_save_access_record 
	@DevNo=0, -- int
	@DevType=0, -- int
	@UserNo=@NV_MA, -- nvarchar(32)
	@CardNo=@MaTu, -- nvarchar(32)
	@MatTime=@QuetVao_CL, -- nvarchar(19)
	@MiSec=37086, -- int
	@Score=153, -- int
	@EventNo=0, -- int
	@ReaderNo=0, -- int
	@Offline=0, -- int
	@Interval=0, -- int
	@ErrorCode=@ErrorCode OUTPUT -- int
	--------------
	EXEC mfsp_save_access_record 
	@DevNo=0, -- int
	@DevType=0, -- int
	@UserNo=@NV_MA, -- nvarchar(32)
	@CardNo=@MaTu, -- nvarchar(32)
	@MatTime=@QuetRa_CL, -- nvarchar(19)
	@MiSec=37086, -- int
	@Score=153, -- int
	@EventNo=0, -- int
	@ReaderNo=0, -- int
	@Offline=0, -- int
	@Interval=0, -- int
	@ErrorCode=@ErrorCode OUTPUT -- int
	--------------
	Fetch Next From Cur_PhongIT into @NV_MA,@NGAY_T--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT
