SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
ALTER FUNCTION [dbo].[fn_LayNNDH]
(
	@NV_MA as nvarchar(50),
	@THANG as nvarchar(7),--'2015-11'
	@NGAYHIENTAI  as datetime
)
RETURNS int
AS
BEGIN
	declare @kq as int
	declare @DHNN as bit,@DBL_Ngaybatdau as datetime,@NV_Ma1 as nvarchar(50),@CV_DOCHAI as bit
	declare @DHNN1 as bit,@DBL_Ngaybatdau1 as datetime,@NV_Ma2 as nvarchar(50),@CV_DOCHAI1 as bit
	declare @NgayBatDau as DATE
    /*
	-@NgayBatDau  là ngày 15 làm điều kiện lọc của tháng đang xét
	-@NgayHienTai là ngày 16  mỗi tháng chỉ định chạy khi hàm được gọi ra để xét
	*/
	set @NgayBatDau=@THANG +'-15' 
	set @kq=0
	set @DHNN=0
	if EXISTS(select * from ST_NHANVIENTHOIVIEC where NV_Ma=@NV_MA and CAST(TV_NgayThoiViec as date)<@NgayBatDau)return 0--NV đã nghỉ việc, không xét.
	if(@NgayBatDau>@NGAYHIENTAI) return 0-- Nếu NgayHienTai của tháng đang xét được gọi ra chưa qua 15 tây thì trả về 0
	if EXISTS -- Nếu tồn tại dòng DBL mới nhất <= NgayBatDau (15 tây tháng đang chạy) thì xét tiếp
			(select Top 1 NV_Ma, DBL_Ngaybatdau, DHNN,ST_DIENBIENLUONG.CV_MA,CV_DOCHAI
					from ST_DIENBIENLUONG  left join ST_CONGVIEC on  ST_CONGVIEC.CV_MA=ST_DIENBIENLUONG.CV_MA 
					where NV_Ma=@NV_MA and CAST(DBL_Ngaybatdau as date)<=@NgayBatDau 
					order by DBL_Ngaybatdau desc
			)
				BEGIN 
					select Top 1 @NV_Ma1=NV_Ma, @DBL_Ngaybatdau=DBL_Ngaybatdau, @DHNN=DHNN,@CV_DOCHAI=CV_DOCHAI --lấy các biến tạm @DBL_Ngaybatdau, @DHNN, @CV_DOCHAI của dòng DBL trên tạm gọi là dòng DBL(A)
					from ST_DIENBIENLUONG left join ST_CONGVIEC on  ST_CONGVIEC.CV_MA=ST_DIENBIENLUONG.CV_MA 
					where NV_Ma=@NV_MA and CAST(DBL_Ngaybatdau as date)<=@NgayBatDau 
					order by DBL_Ngaybatdau desc
					if(@CV_DOCHAI=1 or @DHNN=1)				--Nếu đang đang hưởng DHNN thì
									begin
										---Xét trường hợp chuyển từ công việc NNDH sang CV ko nặng nhọc độc hại
											----Nếu Tồn Tại dòng DBL lớn hơn dòng DBL(A) đang xét ở trên và bé hơn Ngày Bắt Đầu của tháng sau thì lấy ra dòng DBL(B) và xét
											if EXISTS( select Top 1 NV_Ma, DBL_Ngaybatdau, DHNN,ST_DIENBIENLUONG.CV_MA,CV_DOCHAI
														from ST_DIENBIENLUONG left join ST_CONGVIEC on  ST_CONGVIEC.CV_MA=ST_DIENBIENLUONG.CV_MA 
														where NV_Ma=@NV_MA and CAST(DBL_Ngaybatdau as date)>CAST(@DBL_Ngaybatdau as date) --Mau chot o cho nay: Lọc chọn lấy dòng DBL(B) lớn hơn dòng DBL(A) đã chọn ban đầu
																			and CAST(DBL_Ngaybatdau as date)<DATEADD(MONTH ,1,@NgayBatDau) --Dong DBL(B) nay phai chỉ được nằm trong tháng sau liên kề
																			AND ST_DIENBIENLUONG.CV_MA <> 'CBTS'
														order by DBL_Ngaybatdau DESC
														)
												BEGIN
													select Top 1  @DHNN1=DHNN,@CV_DOCHAI1=CV_DOCHAI
													from ST_DIENBIENLUONG left join ST_CONGVIEC on  ST_CONGVIEC.CV_MA=ST_DIENBIENLUONG.CV_MA 
													where NV_Ma=@NV_MA and CAST(DBL_Ngaybatdau as date)>CAST(@DBL_Ngaybatdau as date) 
																		and CAST(DBL_Ngaybatdau as date)<DATEADD(MONTH ,1,@NgayBatDau) 
													order by DBL_Ngaybatdau DESC
                                                    --Nếu dòng DBL(B)Này là đang hưởng DHNN thì cho dòng DBL(A) hưởng DHNN, ngược lại thì sửa lại cho không cho hưởng												
													if(@CV_DOCHAI1=1 or @DHNN1=1)
														SET @kq=1 
													else 
														SET @kq=0 
												END
										---Ngược lại nếu không có DBL(B) cua thang sau thang dang xet
											else
												begin		
													if(@DHNN=1 or @CV_DOCHAI=1)
														SET @kq=1
													else 
														SET @kq=0
												end
									 end
				END--
	else--Nếu không EXISTS
		begin	
			SET @kq=0
		end
			
	RETURN @kq
END
GO