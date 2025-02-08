
CREATE  PROCEDURE [dbo].[SP_TINHVAORA] --Andrew		
	@MATU nvarchar(20), @NGAY datetime, @GIO datetime
AS
Begin
Declare 

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
		from ST_CALAMVIEC WHERE CA_MA IN ('Ca HC','Ca 2','Ca 3','Ca 4')
	---
	open Ca_Cur 
	---
	Fetch next from Ca_Cur into @CA_MA,@CA_GIOBATDAU,@CA_GIOKETTHUC
	---
	While(@@Fetch_Status=0)
	BEGIN
		--Gán các biến (Lúc này chỉ mới đối chiếu và lấy  dữ liệt thực từ ngày, chưa đụng tới giờ thực)
		select @NGAYTRUOC=dateadd(dd,-1, @NGAY)									--Trừ cho ngày hiện tại đi 1 ngày (KQ: Mar  1 2020 12:00AM)
		select @VAOTRUOC=dateadd(hh,datepart(hh,@CA_GIOBATDAU),@NGAYTRUOC)		--Lấy và Thêm Giờ Chuẩn của ngày trước          (KQ: Mar  1 2020  7:00AM)
		select @VAOTRUOC=dateadd(n,datepart(n,@CA_GIOBATDAU),@VAOTRUOC)			--Lấy và Thêm Phút Chuẩn của ngày trước         (KQ: Mar  1 2020  7:30AM)
		--Xét điều kiện 
		if datepart(hh,@VAOTRUOC)<5
			select @VAOTRUOC=dateadd(hh,24,@VAOTRUOC)							--Nếu Giờ <5 thì cộng thêm 24 tiếng vào giờ vào 


		select @RATRUOC=dateadd(hh,datepart(hh,@CA_GIOKETTHUC),@NGAYTRUOC)
		select @RATRUOC=dateadd(n,datepart(n,@CA_GIOKETTHUC),@RATRUOC)

		if @VAOTRUOC>@RATRUOC 
			select @RATRUOC=dateadd(hh,24,@RATRUOC)

		select @VAOSAU=dateadd(hh,datepart(hh,@CA_GIOBATDAU),@NGAY)
		select @VAOSAU=dateadd(n,datepart(n,@CA_GIOBATDAU),@VAOSAU)

		if datepart(hh,@VAOSAU)<5
			select @VAOSAU=dateadd(hh,24,@VAOSAU)			

		select @RASAU=dateadd(hh,datepart(hh,@CA_GIOKETTHUC),@NGAY)
		select @RASAU=dateadd(n,datepart(n,@CA_GIOKETTHUC),@RASAU)

		if @VAOSAU>@RASAU
			select @RASAU=dateadd(hh,24,@RASAU)

		if dateadd(hh,-2,@VAOTRUOC)<@GIO and @GIO<dateadd(hh,8,@RATRUOC)
		begin
			if not exists (select *
					 from ST_GIOQUETTHE
					where NV_MA=@NhanVien_ma
					and QT_NGAY=@NGAYTRUOC)
				insert into ST_GIOQUETTHE (NV_MA,QT_NGAY,CA_MA,DV_MA)
				values (@NhanVien_ma,@NGAYTRUOC,@CA_NV,@DV_MA)
--		select @VAOTRUOC
			select @VAO=null,@RA=null
			select @VAO=QT_GIOVAO, @RA=QT_GIORA
				from ST_VAORA
				where NV_MA=@NhanVien_ma
				and QT_NGAY=@NGAYTRUOC
				and CA_MA=@CA_MA

			if @GIO<dateadd(hh,4, @VAOTRUOC)
			begin
				if @VAO=null
					select @VAO=@GIO	
				else
					if @VAO>@GIO 
					begin
						if @RA=null  and @VAO>dateadd(hh,1, @VAOTRUOC)
							select @RA=@VAO
						select @VAO=@GIO	
					end 
					else
						if (@GIO>dateadd(hh,1, @VAOTRUOC)) and (@RA=null or @RA<@GIO)
							select @RA=@GIO
			end
			else
			begin
				if @RA=null
					select @RA=@GIO	
				else
					if @RA<@GIO
					begin
						if @VAO=null  and @RA<dateadd(hh,-1, @RATRUOC)
							select @VAO=@RA
						select @RA=@GIO	
					end
					else
						if (@GIO<dateadd(hh,-1, @RATRUOC)) and (@VAO=null or @VAO>@GIO)
							select @VAO=@GIO

			end
			if exists (select *
					 from ST_VAORA
					where NV_MA=@NhanVien_ma
					and QT_NGAY=@NGAYTRUOC
					and CA_MA=@CA_MA)
				update ST_VAORA set QT_GIOVAO=@VAO, QT_GIORA=@RA
					where NV_MA=@NhanVien_ma
					and QT_NGAY=@NGAYTRUOC
					and CA_MA=@CA_MA	
			else
				insert into ST_VAORA (QT_GIOVAO,QT_GIORA,NV_MA,QT_NGAY,CA_MA)
				--values (@VAO,null,@NhanVien_ma,@NGAYTRUOC,@CA_MA)
				values (@VAO,@RA,@NhanVien_ma,@NGAYTRUOC,@CA_MA)
				
		end
			select @VAOSAU,@GIO
		if dateadd(hh,-2,@VAOSAU)<@GIO and @GIO<dateadd(hh,8,@RASAU)  
		begin
			if not exists (select *
					 from ST_GIOQUETTHE
					where NV_MA=@NhanVien_ma
					and QT_NGAY=@NGAY)
				insert into ST_GIOQUETTHE (NV_MA,QT_NGAY,CA_MA,DV_MA)
				values (@NhanVien_ma,@NGAY,@CA_NV,@DV_MA)

			select @VAO=null,@RA=null
			select @VAO=QT_GIOVAO, @RA=QT_GIORA
				from ST_VAORA
				where NV_MA=@NhanVien_ma
				and QT_NGAY=@NGAY
				and CA_MA=@CA_MA

			if @GIO<dateadd(hh,4, @VAOSAU)
			begin
				if @VAO=null
					select @VAO=@GIO	
				else
					if @VAO>@GIO
					begin
						if @RA=null  and @VAO>dateadd(hh,1, @VAOSAU)
							select @RA=@VAO 
						select @VAO=@GIO	
					end
					else
						if (@GIO>dateadd(hh,1, @VAOSAU)) and ( @RA=null or @RA<@GIO)
							select @RA=@GIO
				
			end 
			else
			begin
				if @RA=null
					select @RA=@GIO	
				else
					if @RA<@GIO
					begin
						if @VAO=null  and @RA<dateadd(hh,-1, @RASAU)
							select @VAO=@RA
						select @RA=@GIO	
					end
					else
						if (@GIO<dateadd(hh,-1, @RASAU)) and (@VAO=null or @VAO>@GIO)
							select @VAO=@GIO
			end

			if exists (select *
					 from ST_VAORA
					where NV_MA=@NhanVien_ma
					and QT_NGAY=@NGAY
					and CA_MA=@CA_MA)
				update ST_VAORA set QT_GIOVAO=@VAO, QT_GIORA=@RA
					where NV_MA=@NhanVien_ma
					and QT_NGAY=@NGAY
					and CA_MA=@CA_MA	
			else
				insert into ST_VAORA (QT_GIOVAO,QT_GIORA,NV_MA,QT_NGAY,CA_MA)
				values (@VAO,@RA,@NhanVien_ma,@NGAY,@CA_MA)
		end
		
		
	Fetch next from	Ca_Cur into @CA_MA,@CA_GIOBATDAU,@CA_GIOKETTHUC
	end
	Close Ca_Cur
	DEALLOCATE  Ca_Cur

Fetch next from NhanVien_Cur into @NhanVien_Ma
End--While
Close NhanVien_Cur
DEALLOCATE  NhanVien_Cur

end

