SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
--EXEC SP_CHAMCONGBINHTHUONG_IN '00047256054185'	,'10-10-2013'	,'11:53:40',	'01', '03',	'0084'

ALTER  PROCEDURE [dbo].[SP_CHAMCONGBINHTHUONG_IN]
	@MATU nvarchar(20), @NGAY datetime, @GIO datetime,@INOUT nvarchar(2),@SHIFT nvarchar(1),@SOMAY nvarchar(2)
AS

Begin

declare @NV_Ma nvarchar(50),
		@CHUYENGIA bit,
		@THAISAN bit,
		@NUOICON bit,
		@GIOVAO datetime,
		@NGAYSANH NVARCHAR(10),
		@CA nvarchar(5),
		@X_MA nvarchar(20),
		@DV_MA NVARCHAR(20)
Declare  NhanVien_Cur cursor for
	Select NV_Ma 
	From ST_NhanVien
	where (NV_MA not in(Select NV_MA from ST_NhanvienThoiViec where TV_Ngaythoiviec<@NGAY))
			AND NV_MATU=@MATU 

	Open NhanVien_Cur
	Fetch next from NhanVien_Cur into @NV_Ma
	While(@@Fetch_Status=0)
		BEGIN
			SELECT @X_MA= B.X_MA_ FROM ST_NHANVIEN A INNER JOIN ST_DONVI B ON A.DV_MA=B.DV_MA WHERE NV_Ma=@NV_Ma
			SELECT @DV_MA = DV_MA FROM ST_NHANVIEN WHERE NV_Ma=@NV_Ma

			if @NV_Ma is not null
				BEGIN					
					SELECT @Ca = 'Ca HC'
					----------------------------------------------Các ca HC--------------------------------------------------------
					If @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='06:00:00' AND CONVERT(CHAR(8),@GIO,108)<='06:50:00' AND @X_MA<>'VP' AND @X_MA<>'TAM' AND @X_MA<>'CNM'
						begin
							Select @Ca = 'Ca01'
							Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
							Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
						end
					Else 
						IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='05:30:00' AND CONVERT(CHAR(8),@GIO,108)<='06:30:00' AND @X_MA='C3' AND @DV_MA='VPNA'
							begin
								Select @Ca = 'Ca02'
								Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
								Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
							end
						Else 
							IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='04:30:00' AND CONVERT(CHAR(8),@GIO,108)<='05:30:00' AND @X_MA<>'C3' AND @DV_MA='TVKTX'
								begin
									Select @Ca = 'Ca 6'
									Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
									Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
								end
							Else 
								IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='11:00:00' AND CONVERT(CHAR(8),@GIO,108)<='12:00:00' AND @X_MA<>'C3' AND @DV_MA='TVKTX'
									begin
										Select @Ca = 'Ca 7'
										Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
										Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
									end
								Else 
									IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='06:00:00' AND CONVERT(CHAR(8),@GIO,108)<='08:00:00' 
										begin
											Select @Ca = 'Ca HC'
											Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
											Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
										END
                       ----------------------------------------------(Ca 2: từ 05:45:00) --------------------------------------------------------
									Else 
										IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='03:45:00' AND CONVERT(CHAR(8),@GIO,108)<='06:30:00' AND @X_MA<>'C3' AND @DV_MA<>'VPNA'
											begin
												Select @Ca = 'Ca 2'						
												Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
												Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
											END
                                            
					   ----------------------------------------------(Ca 3: từ 10:45:00) ---------------------------------------------------------
										Else 
											IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='10:45:00' AND CONVERT(CHAR(8),@GIO,108)<='14:30:00'
												begin
					    							Select @Ca = 'Ca 3'
													Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
													Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
												end
											Else 
						---------------------------------------------- (Ca 4: từ 21:45:00) --------------------------------------------------------
												IF @INOUT='01' AND CONVERT(CHAR(8),@GIO,108) >='21:45:00' AND CONVERT(CHAR(8),@GIO,108)<='22:30:00'
													begin
														Select @Ca = 'Ca 4'
														Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
														Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 						
													END

					----------Có Đăng ký riêng bên Table IT_CHONCALAMVIEC----------------                              
					IF EXISTS(SELECT NV_MA from IT_CHONCALAMVIEC WHERE NV_MA=@NV_MA  AND CA_MA = 'Ca01' )
					  begin
						Select @Ca = 'Ca01'
						Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
						Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
					  END
                  
					IF EXISTS(SELECT NV_MA from IT_CHONCALAMVIEC WHERE NV_MA=@NV_MA AND CA_MA = 'Ca02' )
					  begin
						Select @Ca = 'Ca02'
						Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
						Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
					  END
                  
					IF EXISTS(SELECT NV_MA from IT_CHONCALAMVIEC WHERE NV_MA=@NV_MA AND CA_MA = 'Ca03' )
					  begin
						Select @Ca = 'Ca03'
						Update ST_GIOQUETTHE Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
						Update ST_GIOQUETTHE_ Set CA_MA=@Ca Where NV_Ma=@NV_MA and QT_Ngay=@NGAY 
					  END                   
				end
			Fetch next from NhanVien_Cur into @NV_Ma
		END
Close NhanVien_Cur
DEALLOCATE  NhanVien_Cur
end

GO