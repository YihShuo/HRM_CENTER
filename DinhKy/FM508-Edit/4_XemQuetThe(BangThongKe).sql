USE [P0104-TYTHAC]
GO
DECLARE @Thang INT,@Ngay INT,@Nam INT,@Mcc INT
SET @Nam = '2024'
SET @Thang = '11'
SET @Ngay = DATEPART(DAY,GETDATE())
--SET @Mcc ='3'
SELECT  'A-1' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,1) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,1) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,1) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,1) AS HomNay
UNION
SELECT  'B-3' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,3) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,3) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,3) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,3) AS HomNay
UNION
SELECT  'C-4' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,4) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,4) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,4) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,4) AS HomNay
UNION
SELECT  'D-5'  AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,5) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,5) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,5) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,5) AS HomNay
UNION
SELECT  'E-6' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,6) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,6) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,6) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,6) AS HomNay
UNION
SELECT  'F-7' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,7) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,7) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,7) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,7) AS HomNay
UNION
SELECT  'G-8' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,8) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,8) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,8) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,8) AS HomNay
UNION
SELECT  'H-9' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,9) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,9) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,9) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,9) AS HomNay
UNION
SELECT  'K-10' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,10) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,10) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,10) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,10) AS HomNay
UNION
SELECT  'L-11' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,11) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,11) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,11) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,11) AS HomNay
UNION
SELECT  'L-15' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,15) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,15) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,15) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,15) AS HomNay
UNION
SELECT  'M-16' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,16) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,16) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,16) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,16) AS HomNay
UNION
SELECT  'M-20' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,20) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,20) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,20) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,20) AS HomNay
UNION
SELECT  'N-24' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,24) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,24) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,24) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,24) AS HomNay
UNION
SELECT  'M-26' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,26) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,26) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,26) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,26) AS HomNay
UNION
SELECT  'O-32' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,32) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,32) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,32) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,32) AS HomNay
UNION
SELECT  'O-52' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,52) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,52) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,52) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,52) AS HomNay
UNION
SELECT  'P-58' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,58) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,58) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,58) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,58) AS HomNay
UNION
SELECT  'O-60' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,60) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,60) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,60) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,60) AS HomNay
UNION
SELECT  'O-61' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,61) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,61) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,61) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,61) AS HomNay
UNION
SELECT  'Y_DC1-248' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,248) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,248) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,248) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,248) AS HomNay
UNION
SELECT  'Y_DC2-249' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,249) AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,249) AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,249) AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,249) AS HomNay
UNION
SELECT  'Z_TongSoTongSoTongSoTongSoTongSoTongSoTongSo' AS May
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,1) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,3) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,4) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,5) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,6) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,7) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,8) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,9) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,10) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,11)	
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,15)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,16)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,20)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,24)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,26)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,32)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,52)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,58) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,60)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,61)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,248) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-3,249) 
			AS HomKiaKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,1) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,3) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,4) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,5) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,6) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,7) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,8) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,9) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,10) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,11) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,15)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,16)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,20)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,24)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,26)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,32)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,52)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,58) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,60)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,61)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,248) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-2,249) 
			AS HomKia
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,1) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,3) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,4) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,5) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,6) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,7) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,8) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,9) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,10) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,11) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,15)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,16)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,20)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,24)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,26)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,32)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,52)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,58) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,60) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,61) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,248) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay-1,249) 
			AS HomQua
		,dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,1) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,3) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,4) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,5) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,6) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,7) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,8) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,9) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,10) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,11) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,15)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,16)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,20)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,24)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,26)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,32)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,58) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,60)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,61)
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,248) 
			+ dbo.fn_SoLuongQuetTheMCC(@Nam,@Thang,@Ngay,249) 
			AS HomNay
