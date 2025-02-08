----Ví Dụ Về Con Trỏ----
---------------------------
--Khai báo bảng chứa cursor
----Ví Dụ Về Con Trỏ----
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
	   Select NV_Ma--,NV_Ten,DV_MA,CVU_MA
	   From ST_Nhanvien 
	   Where DV_MA='IT' and DV_MA not like 'NV'
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA char(6)--,@NV_Ten Nvarchar(30),@DV_MA char(6),@CVU_MA char(6) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	DECLARE @ChucVu NVARCHAR(50),@TrinhDo NVARCHAR(50)
	-------Lập bảng tạm
	SELECT @ChucVu = CVU_MA
	FROM dbo.ST_NHANVIEN
	WHERE NV_Ma=@NV_MA --AND NV_Ten=@NV_Ten 
	-------Xét điều kiện
	IF @ChucVu='TT'
		SET @TrinhDo=N'Cán bộ'
	ELSE
		SET @TrinhDo=N'Nhân Viên'
	--PRINT @NV_MA + '-' + @NV_Ten+SPACE(20)+ '-' +@ChucVu + '-' + @TrinhDo 
	-----Update bảng chính
	UPDATE dbo.ST_NHANVIEN
	SET TRINHDOCHINHTRI=@TrinhDo
	--Select * 
    FROM dbo.ST_NHANVIEN
	WHERE NV_Ma=@NV_MA 
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
-------------Vi du tham khao------
Declare  NhanVien_Cur 
CURSOR for

select nv_ma,nv_ngayvao,NV_NGAYKHD from st_nhanvien
where 
st_nhanvien.nv_ma not in (select nv_ma from st_nhanvienthoiviec)
and st_nhanvien.dv_ma <>'bgd'
and st_nhanvien.dv_ma not like 'nv%'
--AND DV_MA='NS'
------Mo bang Cusor
Open NhanVien_Cur
declare @NhanVien_ma nvarchar(50)
declare @nv_ngayvao DATETIME
declare @nv_ngaykhd datetime

-----Lay DL
Fetch next from NhanVien_Cur into @NhanVien_ma,@nv_ngayvao,@nv_ngaykhd
---------------Bắt đầu duyệt
While(@@Fetch_Status=0)
BEGIN
declare @sothang FLOAT
	IF @nv_ngayvao < '2020-01-01'
		select @sothang=DATEDIFF(m,'2020-01-01','2020-09-30')+1
		FROM st_nhanvien where nv_ma=@Nhanvien_ma
	ELSE  -- Nhan vien Moi vao trong nam
		--select @sothang=DATEDIFF(m,NV_NGAYKHD,'2020-09-30')+1
		--from st_nhanvien where nv_ma=@Nhanvien_ma
		IF DAY(@nv_ngaykhd) < '15' --tinh du thang
			select @sothang=DATEDIFF(m,NV_NGAYKHD,'2020-09-30')+1
			FROM st_nhanvien where nv_ma=@Nhanvien_ma
		ELSE -- Tinh 0.5 thang
			select @sothang=DATEDIFF(m,NV_NGAYKHD,'2020-09-30')+0.5
			FROM st_nhanvien where nv_ma=@Nhanvien_ma
-----Update bảng chính		
	--UPDATE st_nhanvien
	--SET  nv_sothang=@sothang 
	--where nv_ma=@Nhanvien_ma
	PRINT @NhanVien_ma +  ' + ' + CONVERT(NVARCHAR,@sothang) -- lưu ý lệnh Print không thể ghép lẫn lỗn các kiểu dữ liệu mà phải định dạng về 1 kiểu duy nhất
		
Fetch next from NhanVien_Cur into @NhanVien_Ma,@nv_ngayvao,@nv_ngaykhd
End--While
Close NhanVien_Cur
DEALLOCATE  NhanVien_Cur

------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
-------------Vi du tham khao------



USE [P0104-TYXUAN]
GO
/****** Object:  StoredProcedure [dbo].[SP_Ardrew_CapNhatTangCaChoMachine]    Script Date: 26/11/2020 11:13:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Ardrew_CapNhatTangCaChoMachine]
AS
Begin
	DECLARE @GIOTANGCA FLOAT
	DECLARE @SQL NVARCHAR(4000)
	DECLARE @I INT
	DECLARE @T INT
	DECLARE @N INT
	-----------------------
		--Gan cac bien

	-----------------------------------
	Declare Cur_DuyetTangCa300 /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
	Cursor For 
		   Select NV_MA,QT_NGAY,CC_GIOTANGCA
		   From ST_GioQuetThe_Temp

	---------------Mở bảng Cursor
	Open Cur_DuyetTangCa300
	DECLARE @NV_MA NVARCHAR(50)
	DECLARE @QT_NGAY DATETIME --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.
	DECLARE @QT_GIOTANGCA FLOAT
	---------------Lấy dữ liệu
	Fetch Next From Cur_DuyetTangCa300 into @NV_MA,@QT_NGAY,@GIOTANGCA -- Gán tham số từ bảng thực vào bảng tạm
	---------------Bắt đầu duyệt
	While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
	BEGIN
	----Gan gia tri tam
		SELECT @I=DAY(@QT_NGAY)	FROM ST_GioQuetThe_Temp
		SELECT @T=MONTH(@QT_NGAY) FROM ST_GioQuetThe_Temp
		SELECT @N=YEAR(@QT_NGAY) FROM ST_GioQuetThe_Temp
	---Chay cau lenh SQL
		SET @SQL= 'UPDATE ST_VAORA_MACHINE'
		SET @SQL=@SQL+ ' SET giotangca_'+ RTRIM(CONVERT(CHAR(2),@I))+'=' + ''''+RTRIM(CONVERT(CHAR(2),@GIOTANGCA))+''''
		SET @SQL=@SQL+ ' FROM ST_VAORA_MACHINE'
		SET @SQL=@SQL+ ' WHERE MaNV='+''''+@NV_MA+'''' + ' AND Nam='+''''+RTRIM(CONVERT(CHAR(4),@N))+''''+'AND Thang='+''''+RTRIM(CONVERT(CHAR(2),@T))+''''

		EXEC (@Sql)
	-------Chạy dòng kế tiếp 
		Fetch Next From Cur_DuyetTangCa300 into @NV_MA,@QT_NGAY,@GIOTANGCA -- Duyệt qua 1 record kế tiếp 
	End
	---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
	Close Cur_DuyetTangCa300
	Deallocate Cur_DuyetTangCa300
End


------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------
-------------Vi du tham khao------
-- Mô tả 
----Bảng 
------SinhVien
------DeTai
------SinhVienDeTai      (Ghi lại kết quả điểm cuối cùng từ đề tài sinh viên)
------GV_HDDT            (GV hướng dẫn đề tài)
------GV_PBDT            (Gv phản biện đề tài)
------GV_HoiDong         (Gồm có 3 GV trong hội đồng cùng chấm điểm)
------GiaoVien
--Yêu cầu: Lấy bình quân "điểm trung bình" của 3 gv trên và "xếp loại"  đưa vào bảng Sinh Viên

--Khai báo bảng chứa cursor
﻿DECLARE CUR_UPDATED_DIEM CURSOR FOR 
         SELECT MASV, MADT FROM SINHVIEN_DETAI

---------------Mở bảng Cursor
OPEN  CUR_UPDATED_DIEM
DECLARE @MaSV char(6), @MaDT char(6) --Khai báo biến sử dụng trong bảng duyệt để hứng tham số từ bảng thực trên.

Fetch next From CUR_UPDATED_DIEM into @MaSV,@MaDT -- Gán tham số từ bảng thực vào bảng tạm
---------------Bắt đầu duyệt
WHILE(@@FETCH_STATUS=0)
BEGIN
		DECLARE @Diem1 float, @Diem2 float,@Diem3 float, @DiemTB float, @XepLoai NVARCHAR(15) -- @Diem1,2,3 lần lượt tạm lưu điểm của 3 loại GV 

		--LẤY ĐIỂM HƯỚNG DẪN
		SELECT @Diem1 = DIEM 
		FROM GV_HDDT
		WHERE MASV= @MaSV AND MADT=@MaDT

		--LẤY ĐIỂM PHẢN BIỆN
		SELECT @Diem2 = DIEM 
		FROM GV_PBDT
		WHERE MASV= @MaSV AND MADT=@MaDT

		--LẤY ĐIỂM TỪ 3 GIÁO VIÊN HỘI ĐỒNG 
		SELECT @Diem3 = SUM(DIEM) 
		FROM GV_HOIDONG
		WHERE MASV= @MaSV AND MADT=@MaDT

		-- TRUNG BÌNH DIỂM
		SET @DiemTB = (@Diem1 + @Diem2 + @Diem3)/5

	    -- XẾP LOẠI
		IF @DiemTB <5
			SET @XepLoai = N'Không đạt'
		ELSE IF @DiemTB >= 5 AND @DiemTB < 7
			SET @XepLoai = N'Trung Binh'
		ELSE IF  @DiemTB >= 7 AND @DiemTB < 8
			SET @XepLoai = N'Khá'
		ELSE 
			SET @XepLoai = N'Giỏi'

        -- UPDATE ĐIỂM VÀ XẾP LOẠI
        UPDATE  [dbo].[SINHVIEN_DETAI]
		   SET DIEM_TB =@DiemTB,
		   LOAI= @XepLoai
		WHERE MASV= @MaSV AND MADT=@MaDT

	Fetch next From CUR_UPDATED_DIEM into @MaSV,@MaDT
END
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
CLOSE CUR_UPDATED_DIEM
Deallocate CUR_UPDATED_DIEM
