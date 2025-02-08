USE [P0104-TYTHAC]
GO
/****** Object:  StoredProcedure [dbo].[SP_PHANCA_TUDONG]    Script Date: 25/05/2022 12:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC SP_PHANCA_TUDONG '001136' , '2019-04-20'
ALTER PROCEDURE [dbo].[SP_PHANCA_TUDONG]
	@NV_Ma nvarchar(6), @NGAY datetime
AS

Begin

declare @QT_GIOVAO datetime,
		@QT_GIORA datetime,
		@QT_GIOVAONT datetime,
		@QT_GIOVAONTC4 datetime,
		@QT_GIOVAONTC8 datetime,
		@CA_MA nvarchar(5),
		@CHONCA nvarchar(5),
		@SOGIO INT,
		@SOGIONT INT,
		@NGAYTRUOC datetime,
		@DV_MA NVARCHAR(50),
		@X_MA_ nvarchar(10)
Declare  VAORA_Cur cursor for
	Select CA_MA,QT_GIOVAO,QT_GIORA
	From ST_VAORA
	where (NV_MA = @NV_MA AND QT_NGAY = @NGAY AND CA_MA IN ('Ca01', 'Ca02', 'Ca03', 'Ca 2','Ca HC','Ca 3','Ca 4','Ca 6','Ca 7', 'Ca 8'))
	
	select @X_MA_ from ST_DONVI where DV_MA = @DV_MA 
	
	Open VAORA_Cur
	Fetch next from VAORA_Cur into @CA_MA, @QT_GIOVAO , @QT_GIORA
	While(@@Fetch_Status=0)
		begin
			SELECT @X_MA_= B.X_MA_ FROM ST_NHANVIEN A INNER JOIN ST_DONVI B ON A.DV_MA=B.DV_MA WHERE NV_Ma=@NV_Ma
			if @QT_GIOVAO is not null
				begin
					--SELECT @CA_MA, @QT_GIOVAO , @QT_GIORA,  DATEDIFF(HH,@QT_GIOVAO,@QT_GIORA),@SOGIO
					SET @SOGIO = DATEDIFF(HH,@QT_GIOVAO,@QT_GIORA)
					SET @NGAYTRUOC = DATEADD(D,-1,@NGAY)
					SELECT @DV_MA = DV_MA FROM ST_NHANVIEN WHERE NV_Ma=@NV_Ma
					IF DATEDIFF(HH,@QT_GIOVAO,@QT_GIORA) IS NULL
						BEGIN
							SET @SOGIO = 0
						END
					SELECT @QT_GIOVAONT = QT_GIOVAO FROM ST_VAORA WHERE NV_MA=@NV_MA AND QT_NGAY=@NGAYTRUOC AND CA_MA='Ca 2'
					SELECT @QT_GIOVAONTC4 = QT_GIOVAO FROM ST_VAORA WHERE NV_MA=@NV_MA AND QT_NGAY=@NGAYTRUOC AND CA_MA='Ca 4'
					--SELECT @QT_GIOVAONTC8 = QT_GIOVAO FROM ST_VAORA WHERE NV_MA=@NV_MA AND QT_NGAY=@NGAYTRUOC AND CA_MA='Ca 8'
				
					--Trường hợp đối tượng là Tạp Vụ Ký Túc Xá			   
					If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='04:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) <= '05:30:00' AND @SOGIO<15  AND @DV_MA='TVKTX')
					BEGIN	            
						Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 6'
					END
				
					If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='07:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) <= '12:30:00' AND @SOGIO<15   AND @DV_MA='TVKTX')
					BEGIN	            
						Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 7'
					END
					---Xử lý Ca4
					If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='05:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '06:15:00' AND @SOGIO<15)
					BEGIN	            
						Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 2'
						If @SOGIONT IS NULL	AND @QT_GIOVAONTC4>0
						BEGIN  
							Update ST_VAORA Set QT_CHONCA = NULL Where NV_Ma=@NV_MA and QT_Ngay=@NGAYTRUOC And Ca_Ma = 'Ca 2'          
							Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAYTRUOC And Ca_Ma = 'Ca 4'
						END
					END
				
					If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='07:29:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '07:39:00' AND @SOGIO<15  AND @DV_MA='BV')
					BEGIN	            
						Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 2'
						If @SOGIONT IS NULL	AND @QT_GIOVAONTC4>0
						BEGIN  
							Update ST_VAORA Set QT_CHONCA = NULL Where NV_Ma=@NV_MA and QT_Ngay=@NGAYTRUOC And Ca_Ma = 'Ca 2'          
							Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAYTRUOC And Ca_Ma = 'Ca 4'
						END
					END
					---Xử lý Ca8
					If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='18:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '19:15:00' AND @SOGIO<15 )
					BEGIN	            
						Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 8'						
					END
					-------------------
					PRINT @QT_GIOVAONTC4

					IF (CONVERT(CHAR(8),@QT_GIOVAO,108) >='06:00:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '08:00:00' AND @SOGIO>0 AND @SOGIO<16)	
								Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca HC'
					else If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='12:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '14:30:00' AND @SOGIO>0 )
								Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 3'
					else if (CONVERT(CHAR(8),@QT_GIOVAO,108) >='21:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '22:30:00' AND @SOGIO>0 AND @SOGIO<15)
								Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 4'
						
					--If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='06:15:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '08:30:00' AND @SOGIO>0 AND @SOGIO<13)
					--			Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca HC'
					--else If (CONVERT(CHAR(8),@QT_GIOVAO,108) >='12:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '14:30:00' AND @SOGIO>0 )
					--			Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 3'
					--else if (CONVERT(CHAR(8),@QT_GIOVAO,108) >='21:30:00' AND CONVERT(CHAR(8),@QT_GIOVAO,108) < '22:30:00' AND @SOGIO>0 AND @SOGIO<15)
					--			Update ST_VAORA Set QT_CHONCA = 1 Where NV_Ma=@NV_MA and QT_Ngay=@NGAY And Ca_Ma = 'Ca 4'
			
				END
			Fetch next from VAORA_Cur into @CA_MA, @QT_GIOVAO, @QT_GIORA
		end
		select sogio=@SOGIO,qt_giovaont=@QT_GIOVAONT,qt_giovaontc4=@QT_GIOVAONTC4,qt_giovao=@QT_GIOVAO,qt_giora=@QT_GIORA,DV_MA = @DV_MA, X_MA_ = @X_MA_
Close VAORA_Cur
DEALLOCATE  VAORA_Cur
end

