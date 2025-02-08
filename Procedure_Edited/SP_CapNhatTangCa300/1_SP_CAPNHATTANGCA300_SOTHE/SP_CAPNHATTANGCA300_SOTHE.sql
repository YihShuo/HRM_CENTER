USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_CAPNHATTANGCA300_SOTHE]    Script Date: 03/01/2025 7:34:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_CAPNHATTANGCA300_SOTHE]
	@NGAY datetime,@SOTHE NVARCHAR(50)
AS
Begin
	declare @NhanVien_ma nvarchar(50),
			@Total float,
			@Ca_ma nvarchar(10),
			@Overtime float,
			@Overtimesau float,
			@OvertimeT float,
			@GIORA DATETIME,
			@GIORA_OLD DATETIME,
			@GIOTANGCA float,
			@GIOAN FLOAT,
			@Ngaytruoc datetime,@i int = 0

	--Khai báo bảng chứa cursor
	Declare NhanVien_Cur /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/
	CURSOR	FOR	
		Select NV_Ma 
		From ST_NhanVien
		where NV_MA not in(Select NV_MA from ST_NhanvienThoiViec where TV_Ngaythoiviec<@NGAY)
					AND DV_MA NOT LIKE 'DT%'
					AND DV_MA NOT IN ('BGD','BGDX') 
					AND NV_Ma=@SOTHE

---------------Mở bảng Cursor
	Open NhanVien_Cur
	---------------Lấy dữ liệu
	Fetch next from NhanVien_Cur into @NhanVien_ma
	While(@@Fetch_Status=0)
		Begin
			set @Ngaytruoc=DATEADD(DAY,-1,@NGAY)
			declare @nt int
			declare @tt int
			set @nt=YEAR(@Ngaytruoc)
			set @tt=MONTH(@Ngaytruoc)
			DECLARE @D INT
			DECLARE @T INT
			DECLARE @N INT
			DECLARE @SQL NVARCHAR(4000)
			DECLARE @DV_MA NVARCHAR(20)
			SET @D=DAY(@NGAY)
			SET @T=MONTH(@NGAY)
			SET @N=YEAR(@NGAY)
		
			--EXEC SP_VAORA_MACHINE_TAY @NhanVien_ma,@nt,@tt
		
			-- ẩn để kiểm tra thai sản 7h (07/01/2022)
			--exec SP_CHAMCONGN  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,30,0,0,1,1,0,0,1
		
			EXEC [SP_TONGGIOTANGCA_NHANVIEN] @NhanVien_ma,@Ngaytruoc,@Total OUTPUT

			--Neu tong gio cong tang ca+tang ca ngay>300 hoac di ca co tang ca
			Select @Overtime=CC_Giotangca From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay=@Ngay
			Select @OvertimeT = CC_GIOTANGCAT From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay=@Ngay
			Select @Overtimesau = CC_GIOTANGCAS From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay=@Ngay
			Select @GIOAN = CC_GIOAN FROM ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay=@Ngay
			Select @Ca_ma=Ca_ma,@DV_MA=DV_MA From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay=@Ngay
		
		
			SELECT @GIORA_OLD=QT_GIORA
			FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
														AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
														AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
			WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
										 AND ST_VAORA.NV_MA=@Nhanvien_ma
			
			-----------------------------
			Declare @NgayDT datetime
			Declare @NgayCT datetime
			Declare @NgayDauThang datetime
			Declare @NgayCuoiThang datetime
			Declare @Giotangcatuan float
			Declare @Giotangcathang float
			Declare @Tonggiocongtuan float
			Declare @Giailao FLOAT
            
			exec sp_tinhsongaytrongtuan @Ngaytruoc,@NgayDT output,@NgayCT output
		
			Select @NgayDauThang = T_TuNgay, @NgayCuoiThang = T_DenNgay
			From ST_THANG
			Where MONTH(@NGAY)= LEFT(T_MA,2) AND YEAR(@NGAY)= RIGHT(T_MA ,4)
	    
			Select @Giotangcatuan=sum(isnull(CC_GIOTANGCA,0)) From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay between @NgayDT and @NGAY
		
			Select @Giotangcathang=sum(isnull(CC_GIOTANGCA,0)) From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay between @NgayDauThang and @NGAY
		
			--if DATEPART(DW,@NgayDT)= 1
			-- 		Select @Tonggiocongtuan=sum(isnull(CC_GIOBINHTHUONG,0)+isnull(CC_GIOTANGCA,0)) 
			-- 		From ST_GIOQUETTHE where nv_ma=@Nhanvien_ma and qt_ngay between DATEADD(D,1,@NgayDT) and @NGAY
			--else 
				  SELECT @Tonggiocongtuan=sum(isnull(CC_GIOBINHTHUONG,0)+isnull(CC_GIOTANGCA,0)) 
				  From ST_GIOQUETTHE 
				  WHERE nv_ma=@Nhanvien_ma and qt_ngay between @NgayDT and @NGAY
		
			----Phân loại Trường hợp có hay không tăng ca trên 2 tiếng bị trừ 30 giờ ăn------
			IF (@Overtime >=2 AND @GIOAN > 0)
				SET @Giailao = 0.5 --nữa tiếng
			ELSE 
				SET @Giailao = 0
			---------------------------------------------------------------------------------	 
	SELECT  Total=@Total, Overtime=@Overtime, NgayDT=@NgayDT, NgayCT=@NgayCT,Giotangcatuan=@Giotangcatuan,Tonggiocongtuan=@Tonggiocongtuan,Giotangcathang=@Giotangcathang--,giailao = @Giailao,overtimesau=@Overtimesau,giora_old=@GIORA_OLD
			--Tang ca qua 300h/nam
			If (@Total+@Overtime>300)--------------------------------------------------------------VƯỢT CÔNG NGOÀI--------------------------------------------------------------
			-- Di ca tang ca (Tỷ Thạc cũ đang dùng)
			--(@Overtime>=1 and @Ca_ma = 'Ca 4') ---sau nay bat len
			----------------------------------------
			-- Tang ca vuot qua 4h/ngay
			OR (@Overtime >= 4) --Từ 4 tiếng trở lên cắt công ngày, do đã bị trừ 30 đi ăn tăng ca, nếu ko cắt nhìn time làm tới hơn 4h30) 
			OR (@Overtime>=1 and DATEPART(DW,@Ngay)= 1)
			-- Tang ca vuot qua 12h/tuan
			or (@Giotangcatuan>12) 
			-- Tong gio cong vuot qua 60h/tuan
			or (@Tonggiocongtuan>60 and DATEPART(DW,@Ngay)<> 1 )
			-- Tong gio vuot qua trong thang khong qua 40
			or (@Giotangcathang > 40)		
				Begin
					select Giotangcatuan=@Giotangcatuan,NgayDT=@NgayDT,NgayCT=@NgayCT,NgayDauThang=@NgayDauThang,NgayCuoiThang=@NgayCuoiThang,Giotangcatuan=@Giotangcatuan,Giotangcathang=@Giotangcathang
					-------------------------UPDATE ST_VAORA_MACHINE---------------
					IF (@Giailao = 0.5 AND @Overtimesau >= 2) --Tăng ca từ 2 tiếng trở lên, bì trờ 0.5 tiếng giải lao đi ăn
						BEGIN
							SELECT @GIORA=DATEADD(MI,-(CC_GIOTANGCAS*60),QT_GIORA)
							FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
							WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
														AND ST_VAORA.NV_MA=@Nhanvien_ma
						END
					 ELSE
						BEGIN
							SELECT @GIORA=DATEADD(MI,-((CC_GIOTANGCAS*60)+30),QT_GIORA)
							FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
							WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
														AND ST_VAORA.NV_MA=@Nhanvien_ma
						END
					------------------------------------------------------------------
	
					-------------------------Cắt Giờ Tăng Ca Sau ST_VAORA---------------
					IF (@Giailao = 0.5 ) --Tăng ca từ 2 tiếng trở lên, bì trừ 0.5 tiếng giải lao đi ăn
						BEGIN
							IF @Overtimesau >= 2 --Cần cắt giờ ra trừ 0.5 tiếng giải lao
								BEGIN
									UPDATE ST_VAORA
								SET QT_GIORA=DATEADD(MI,-(CC_GIOTANGCAS*60),QT_GIORA),
									QT_GIOVAO = DATEADD(MI,(CC_GIOTANGCAT*60),QT_GIOVAO)
								FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																			AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																			AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
								WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
																AND ST_VAORA.NV_MA=@Nhanvien_ma
								END
							ELSE
								BEGIN			--Cần cắt giờ ra không cần trừ 0.5 tiếng giải lao (Có tăng ca trước)
									IF (@OvertimeT > 0)
										BEGIN
											UPDATE ST_VAORA
											SET QT_GIORA=DATEADD(MI,-((CC_GIOTANGCAS*60)),QT_GIORA),
												QT_GIOVAO = DATEADD(MI,(CC_GIOTANGCAT*60),QT_GIOVAO)
											FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																						AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																						AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
											WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
																			AND ST_VAORA.NV_MA=@Nhanvien_ma
										END	
									ELSE
										BEGIN
											UPDATE ST_VAORA
											SET QT_GIORA=DATEADD(MI,-((CC_GIOTANGCAS*60)-30),QT_GIORA),
												QT_GIOVAO = DATEADD(MI,(CC_GIOTANGCAT*60),QT_GIOVAO)
											FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																						AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																						AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
											WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
																			AND ST_VAORA.NV_MA=@Nhanvien_ma
										end
									
								END
						END
					ELSE				--Tăng ca dưới 2 tiếng
						BEGIN
									UPDATE ST_VAORA
									SET QT_GIORA=DATEADD(MI,-(CC_GIOTANGCAS*60),QT_GIORA),
										QT_GIOVAO = DATEADD(MI,(CC_GIOTANGCAT*60),QT_GIOVAO)
									FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																				AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																				AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
									WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
																	AND ST_VAORA.NV_MA=@Nhanvien_ma
						END

					--------------------------
				
					UPDATE ST_VAORA_
					SET QT_GIORA=@GIORA_OLD
					--, QT_GIOVAO = DATEADD(MI,@OvertimeT*60,QT_GIOVAO )
					FROM ST_VAORA_ INNER JOIN ST_GIOQUETTHE_ ON ST_VAORA_.NV_MA=ST_GIOQUETTHE_.NV_MA
																AND ST_VAORA_.QT_NGAY=ST_GIOQUETTHE_.QT_NGAY
																AND ST_VAORA_.CA_MA=ST_GIOQUETTHE_.CA_MA
					WHERE ST_VAORA_.QT_NGAY=@Ngay AND ST_VAORA_.CA_MA=@Ca_ma
												  AND ST_VAORA_.NV_MA=@Nhanvien_ma
				
					UPDATE ST_VAORA_MACHINE_NEW
					SET ST_VAORA_MACHINE_NEW.QT_GIORA=ST_VAORA.QT_GIORA
					FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
								  INNER JOIN ST_VAORA_MACHINE_NEW ON ST_VAORA.NV_MA=ST_VAORA_MACHINE_NEW.NV_MA
																AND ST_VAORA.QT_NGAY=ST_VAORA_MACHINE_NEW.QT_NGAY
					WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
												 AND ST_VAORA.NV_MA=@Nhanvien_ma
				

					exec SP_CHAMCONGN  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1

					--Cap nhat ST_VAORA_MACHINE
				
					SET @SQL='UPDATE ST_VAORA_MACHINE SET GIOTANGCA_' + RTRIM(CONVERT(CHAR(2),@D))+ '=0, '
					SET @SQL=@SQL+'GIORA_' + RTRIM(CONVERT(CHAR(2),@D))+ '=' + '''' + CONVERT(CHAR(19),@GIORA,21) + ''' '
					SET @SQL=@SQL+'WHERE NAM=' + RTRIM(CONVERT(CHAR(4),@N)) + ' AND THANG=' + RTRIM(CONVERT(CHAR(2),@T)) + ' '
					SET @SQL=@SQL+'AND MANV=' + '''' + @Nhanvien_ma + ''''
					EXEC (@SQL)

					UPDATE ST_GIOQUETTHE_
					SET Ca_ma=@Ca_ma
					WHERE QT_NGAY=@Ngay and nv_ma =@Nhanvien_ma
				
					--exec SP_CHAMCONGN_  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,30,0,0,1,1,0,0,0
					--exec SP_CHAMCONGN_  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,0
					exec SP_CHAMCONGN_  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1
					

				
					Select @GIOTANGCA= CC_GIOTANGCA FROM ST_GIOQUETTHE_ 
					WHERE NV_MA=@NhanVien_ma AND QT_NGAY=@NGAY 
			
				End
			Else--------------------------------------------------------------KHÔNG CÓ VƯỢT CÔNG NGOÀI--------------------------------------------------------------
				Begin
					select Giotangcatuan=@Giotangcatuan,NgayDT=@NgayDT,NgayCT=@NgayCT,NgayDauThang=@NgayDauThang,NgayCuoiThang=@NgayCuoiThang,Giotangcatuan=@Giotangcatuan,Giotangcathang=@Giotangcathang
					/*Khi quẹt lần đầu chưa tính cắt công thì QT_GioRa của ST_VaoRa và ST_VaoRa_ đều là số giờ quẹt nguyên thủy trễ nhấts*/
					DECLARE @GIORA_NEW DATETIME --Là giờ ra TRONG sau khi bị cắt tăng ca
					DECLARE @GIORA_ DATETIME    --Là giờ ra NGOÀI sau khi bị cắt tăng ca
			
					SELECT @GIORA_NEW=DATEADD(MI,-(@Overtimesau+@Giailao)*60,@GIORA_OLD)
					--SELECT @GIORA_NEW=DATEADD(MI,-@Overtimesau*60,@GIORA_OLD)

					SELECT @GIORA_=DATEADD(MI,-(@Overtimesau+@Giailao)*60,QT_GIORA)
					--SELECT @GIORA_ =DATEADD(MI,-@Overtimesau*60,QT_GIORA)
					FROM ST_VAORA_ INNER JOIN ST_GIOQUETTHE_ ON ST_VAORA_.NV_MA=ST_GIOQUETTHE_.NV_MA
																AND ST_VAORA_.QT_NGAY=ST_GIOQUETTHE_.QT_NGAY
																AND ST_VAORA_.CA_MA=ST_GIOQUETTHE_.CA_MA
					WHERE ST_VAORA_.QT_NGAY=@Ngay AND ST_VAORA_.CA_MA=@Ca_ma
												  AND ST_VAORA_.NV_MA=@Nhanvien_ma
					
					--Nếu giờ ra TRONG và NGOÀI sau khi bị cắt tăng ca bằng nhau và có tăng ca từ 0.5 tiếng trở lên thì (tức nguyên thủy , chưa bị cắt)
					IF (@GIORA_NEW=@GIORA_) AND (@Overtime>=0.5) 			
						Begin
							DECLARE @FIXTIME DATETIME --@FIXTIME  là giờ ra chuẩn HC
							--SELECT @FIXTIME = DATEADD(MI,-(@Overtimesau+@Giailao)*60,QT_GIORA)
							--Trừ 30' giải lao đi ăn (tăng ca trên 2 tiếng) --Andrew
							--IF @Overtimesau > 2 OR (@Overtimesau = 2 AND @GIOAN > 0) --Tăng ca hơn 2 tiếng và bị trừ 30' giờ ăn
							IF (@Giailao = 0.5 AND @Overtimesau >= 2) --Tăng ca hơn 2 tiếng và bị trừ 30' giờ ăn								
								BEGIN
									PRINT 'Tăng ca hơn 2 tiếng'
									SELECT @FIXTIME = DATEADD(MI,-(@Overtimesau+@Giailao)*60,QT_GIORA)                      
									FROM ST_VAORA_ INNER JOIN ST_GIOQUETTHE_ ON ST_VAORA_.NV_MA=ST_GIOQUETTHE_.NV_MA
																			AND ST_VAORA_.QT_NGAY=ST_GIOQUETTHE_.QT_NGAY
																			AND ST_VAORA_.CA_MA=ST_GIOQUETTHE_.CA_MA
									WHERE ST_VAORA_.QT_NGAY=@Ngay AND ST_VAORA_.CA_MA=@Ca_ma
														  AND ST_VAORA_.NV_MA=@Nhanvien_ma

									--Set giờ ra ngoài về HC (FIXTIME)
									UPDATE ST_VAORA_
									SET QT_GIORA=DATEADD(MI,30,@FIXTIME)
									FROM ST_VAORA_ INNER JOIN ST_GIOQUETTHE_ ON ST_VAORA_.NV_MA=ST_GIOQUETTHE_.NV_MA
																				AND ST_VAORA_.QT_NGAY=ST_GIOQUETTHE_.QT_NGAY
																				AND ST_VAORA_.CA_MA=ST_GIOQUETTHE_.CA_MA
									WHERE ST_VAORA_.QT_NGAY=@Ngay AND ST_VAORA_.CA_MA=@Ca_ma
																	AND ST_VAORA_.NV_MA=@Nhanvien_ma
							
									--Set tăng ca trong theo thực tế
									UPDATE ST_VAORA
									SET QT_GIORA=DATEADD(MI,(@Overtimesau*60)+30,@FIXTIME)								
									FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																				AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																				AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
									WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
																	AND ST_VAORA.NV_MA=@Nhanvien_ma								
								END						
							ELSE -- Không có tăng ca quá 2 tiếng								
								BEGIN
									PRINT 'Không Tăng Ca Hơn 2 Tiếng'
									SELECT @FIXTIME = DATEADD(MI,-(@Overtimesau*60),QT_GIORA)                      
									FROM ST_VAORA_ INNER JOIN ST_GIOQUETTHE_ ON ST_VAORA_.NV_MA=ST_GIOQUETTHE_.NV_MA
																			AND ST_VAORA_.QT_NGAY=ST_GIOQUETTHE_.QT_NGAY
																			AND ST_VAORA_.CA_MA=ST_GIOQUETTHE_.CA_MA
									WHERE ST_VAORA_.QT_NGAY=@Ngay AND ST_VAORA_.CA_MA=@Ca_ma
														  AND ST_VAORA_.NV_MA=@Nhanvien_ma

									--Set giờ ra ngoài về HC (FIXTIME)
									UPDATE ST_VAORA_
									SET QT_GIORA=@FIXTIME
									FROM ST_VAORA_ INNER JOIN ST_GIOQUETTHE_ ON ST_VAORA_.NV_MA=ST_GIOQUETTHE_.NV_MA
																				AND ST_VAORA_.QT_NGAY=ST_GIOQUETTHE_.QT_NGAY
																				AND ST_VAORA_.CA_MA=ST_GIOQUETTHE_.CA_MA
									WHERE ST_VAORA_.QT_NGAY=@Ngay AND ST_VAORA_.CA_MA=@Ca_ma
																	AND ST_VAORA_.NV_MA=@Nhanvien_ma
							
									--Set tăng ca trong theo thực tế
									UPDATE ST_VAORA
									SET QT_GIORA=DATEADD(MI,(@Overtimesau*60),@FIXTIME)					
									FROM ST_VAORA INNER JOIN ST_GIOQUETTHE ON ST_VAORA.NV_MA=ST_GIOQUETTHE.NV_MA
																				AND ST_VAORA.QT_NGAY=ST_GIOQUETTHE.QT_NGAY
																				AND ST_VAORA.CA_MA=ST_GIOQUETTHE.CA_MA
									WHERE ST_VAORA.QT_NGAY=@Ngay AND ST_VAORA.CA_MA=@Ca_ma
																	AND ST_VAORA.NV_MA=@Nhanvien_ma
								END									

							exec SP_CHAMCONGN_  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,0
							exec SP_CHAMCONGN   @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,1
				
							--Cap nhat ST_VAORA_MACHINE

							SET @SQL='UPDATE ST_VAORA_MACHINE SET GIOTANGCA_' + RTRIM(CONVERT(CHAR(2),@D))+ '='+ RTRIM(CONVERT(CHAR(8),@Overtime))+ ', '
							SET @SQL=@SQL+'GIORA_' + RTRIM(CONVERT(CHAR(2),@D))+ '=' + '''' + CONVERT(CHAR(19),@GIORA,21) + ''' '
							SET @SQL=@SQL+'WHERE NAM=' + RTRIM(CONVERT(CHAR(4),@N)) + ' AND THANG=' + RTRIM(CONVERT(CHAR(2),@T)) + ' '
							SET @SQL=@SQL+'AND MANV=' + '''' + @Nhanvien_ma + ''''
							EXEC (@SQL)

							UPDATE ST_GIOQUETTHE_
							SET Ca_ma=@Ca_ma
							WHERE QT_NGAY=@Ngay and nv_ma =@Nhanvien_ma
				
							--exec SP_CHAMCONGN_  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,30,0,0,1,1,0,0,0
							exec SP_CHAMCONGN_  @NGAY,@NhanVien_ma,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,0
							------------------------------
							--Select @GIOTANGCA=CC_GIOTANGCA FROM ST_GIOQUETTHE_ 
							--WHERE NV_MA=@NhanVien_ma AND QT_NGAY=@NGAY 
							--	IF @GIOTANGCA=0.5
							--		Update ST_GIOQUETTHE_ Set CC_GIOTANGCA=0 ,CC_GIOTANGCAS = 0 From ST_GIOQUETTHE_
							--		Where NV_Ma=@NhanVien_ma and QT_Ngay=@NGAY
				
									
						End
				End
			set @i = @i+1
			select SONGUOI=@i
			Fetch next from NhanVien_Cur into @NhanVien_Ma -- Duyệt qua 1 record kế tiếp 
		End
	Close NhanVien_Cur
	---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
	DEALLOCATE  NhanVien_Cur
End









