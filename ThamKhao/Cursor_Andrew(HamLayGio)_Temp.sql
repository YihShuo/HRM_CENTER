

Declare 

	@MATU nvarchar(20),
	 @NGAY datetime, @GIO DATETIME,
    -----
	@NhanVien_ma nvarchar(50),		
	@CA_MA nvarchar(50),
	@CA_GIOBATDAU datetime,
	@CA_GIOKETTHUC datetime,
	@NGAYTRUOC datetime,
	@VAOTRUOC datetime,
	@RATRUOC datetime,    
	@VAOSAU datetime,
	@RASAU datetime,
	@VAO datetime,
	@RA datetime,
	@SOLANDITRE int,
	@DV_Ma nvarchar(50),
	@CA_NV nvarchar(50)
SET @MATU='00064465246776'
Set   @NGAY='2020-03-02'
Set   @GIO='07:32:11'
--Khai báo bảng chứa cursor
Declare  NhanVien_Cur 
CURSOR FOR
	Select NV_Ma 
	From ST_NhanVien
	where (NV_MA not in(Select NV_MA from ST_NhanvienThoiViec where TV_Ngaythoiviec<@NGAY)) --Lấy những nhân viên có ngày thôi việc nhỏ hơn ngày đang lấy dữ liệu.(Bỏ ra NV thôi việc)
			AND NV_MATU=@MATU 
---------------Mở bảng Cursor
Open NhanVien_Cur
---------------Lấy dữ liệu
Fetch next from NhanVien_Cur into @NhanVien_ma
---------------Bắt đầu duyệt
While(@@Fetch_Status=0)
Begin
	select @DV_Ma =DV_Ma from ST_Nhanvien where NV_Ma=@NhanVien_ma
	select @CA_NV=null
	select @CA_NV=CA_MA from ST_HESOCHAMCONG where NV_MA=@NhanVien_ma
	if @CA_NV=NULL SELECT @CA_NV='Ca HC'
	--Con trỏ lồng	
	DECLARE  Ca_Cur 
	CURSOR FOR 
		select CA_MA,CA_GIOBATDAU,CA_GIOKETTHUC
		from ST_CALAMVIEC WHERE CA_MA IN ('Ca HC')--,'Ca 2','Ca 3','Ca 4')
	---
	open Ca_Cur 
	---
	Fetch next from Ca_Cur into @CA_MA,@CA_GIOBATDAU,@CA_GIOKETTHUC
	---
	While(@@Fetch_Status=0)
	BEGIN
		--Gán các biến
		select @NGAYTRUOC=dateadd(dd,-1, @NGAY)									--Trừ cho ngày hiện tại đi 1 ngày (KQ: Mar  1 2020 12:00AM)
		select @VAOTRUOC=dateadd(hh,datepart(hh,@CA_GIOBATDAU),@NGAYTRUOC)		--Them Giờ của ngày trước          (KQ: Mar  1 2020  7:00AM)
		select @VAOTRUOC=dateadd(n,datepart(n,@CA_GIOBATDAU),@VAOTRUOC)			--Them Phút của ngày trước         (KQ: Mar  1 2020  7:30AM)
		--Xét điều kiện 		
		--PRINT @NGAYTRUOC
		PRINT @VAOTRUOC
		
	Fetch next from	Ca_Cur into @CA_MA,@CA_GIOBATDAU,@CA_GIOKETTHUC
	end
	Close Ca_Cur
	DEALLOCATE  Ca_Cur

Fetch next from NhanVien_Cur into @NhanVien_Ma
End--While
Close NhanVien_Cur
DEALLOCATE  NhanVien_Cur


