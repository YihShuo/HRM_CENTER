--------------Backup
--DELETE FROM [TEMPANDREW]..JELL_QUYENTRUYCAP
--INSERT INTO [TEMPANDREW]..JELL_QUYENTRUYCAP SELECT * FROM [P0104-TYTHAC]..JELL_QUYENTRUYCAP
--------------
SELECT * FROM JELL_QUYENTRUYCAP WHERE Ten_DangNhap = '111' --Bên cũ
SELECT * FROM JELL_QUYENTRUYCAP WHERE Ten_DangNhap = '340023' --Bên mới


Declare Cur_CopyUser /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
Cursor For 
	   Select Ma_DM,Ten_DangNhap,Allow,Them,Sua,Xoa
	   From JELL_QUYENTRUYCAP 
	   Where  Ten_DangNhap = '111'
---------------Mở bảng Cursor
Open Cur_CopyUser
Declare @Ma_DM NVARCHAR(250),@Ten_DangNhap char(6),@Allow BIT, @Them BIT,@Sua BIT, @Xoa BIT --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_CopyUser into @Ma_DM ,@Ten_DangNhap,@Allow , @Them ,@Sua , @Xoa  -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	INSERT INTO JELL_QUYENTRUYCAP
	(
	    Ma_DM,
	    Ten_DangNhap,
	    Allow,
	    Them,
	    Sua,
	    Xoa,
	    KHUA,
	    KHUB
	)
	VALUES
	(   @Ma_DM,  -- Ma_DM - nvarchar(250)
	    '340023',  -- Ten_DangNhap - nvarchar(50)
	    @Allow, -- Allow - bit
	    @Them, -- Them - bit
	    @Sua, -- Sua - bit
	    @Xoa, -- Xoa - bit
	    '0', -- KHUA - bit
	    '0'  -- KHUB - bit
	    )
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_CopyUser into @Ma_DM ,@Ten_DangNhap,@Allow , @Them ,@Sua , @Xoa -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_CopyUser
Deallocate Cur_CopyUser


--------------------------Thử tìm chức năng của chưa biết của user ----------------
--------------------------------------------------------------------------------

SELECT * FROM JELL_QUYENTRUYCAP WHERE Ten_DangNhap = '111'
--DELETE JELL_QUYENTRUYCAP WHERE Ten_DangNhap = '111'

Declare Cur_CopyUser /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
Cursor For 
	   Select Ma_DM
	   From JELL_DANHMUC 
	  -- WHERE Nhom_DM = 'NHANSU'

---------------Mở bảng Cursor
Open Cur_CopyUser
Declare @Ma_DM NVARCHAR(250) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_CopyUser into @Ma_DM  -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	INSERT INTO JELL_QUYENTRUYCAP
	(
	    Ma_DM,
	    Ten_DangNhap,
	    Allow,
	    Them,
	    Sua,
	    Xoa,
	    KHUA,
	    KHUB
	)
	VALUES
	(   @Ma_DM,  -- Ma_DM - nvarchar(250)
	    '111',  -- Ten_DangNhap - nvarchar(50)
	    '1', -- Allow - bit
	    '1', -- Them - bit
	    '1', -- Sua - bit
	    '1', -- Xoa - bit
	    '1', -- KHUA - bit
	    '1'  -- KHUB - bit
	    )
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_CopyUser into @Ma_DM  -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_CopyUser
Deallocate Cur_CopyUser