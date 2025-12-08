/*											You can connect to 40.9 and run these queries using the tyx user.															 */
--=====================================================================================================================================-
/*							     Number of Employees Who Left  Less than 1 year, 1? years, Over 3 years (Monthly Statistics)		                     */
--=====================================================================================================================================-
DECLARE @DENNGAY1 DATE
SELECT @DENNGAY1=T_DENNGAY
FROM [P0104-TYTHAC].dbo.ST_THANG WHERE T_MA='10-2025'

SELECT C.X_MA_ AS Factory,C.DV_MA AS Dept,C.DV_TEN AS DeptName,
LessThan1Year=SUM((CASE WHEN DATEDIFF(DAY,B.TV_NgayThoiViec,@DENNGAY1) < 365 THEN 1 ELSE 0 END)),
From1To3Years =SUM((CASE WHEN (DATEDIFF(DAY,B.TV_NgayThoiViec,@DENNGAY1) BETWEEN 365 AND 1095) THEN 1 ELSE 0 END)),
MoreThan3Years =SUM((CASE WHEN DATEDIFF(DAY,B.TV_NgayThoiViec,@DENNGAY1) > 1095 THEN 1 ELSE 0 END))
FROM [P0104-TYTHAC].dbo.ST_NHANVIEN A INNER JOIN [P0104-TYTHAC].dbo.ST_NHANVIENTHOIVIEC B ON A.NV_Ma=B.NV_Ma
INNER JOIN [P0104-TYTHAC].dbo.ST_DONVI C ON A.DV_MA_=C.DV_MA
GROUP BY C.X_MA_,C.DV_MA,C.DV_TEN

--=====================================================================================================================================-
/*											     Number of Employees Who Left  by Production Line (Monthly Statistics)							                 */
--=====================================================================================================================================-
DECLARE @TUNGAY2 DATE,@DENNGAY2 DATE
SELECT @TUNGAY2=T_TUNGAY,@DENNGAY2=T_DENNGAY
FROM [P0104-TYTHAC].dbo.ST_THANG WHERE T_MA='10-2025'

SELECT C.X_MA_ AS Factory,C.DV_MA AS Dept,C.DV_TEN AS DeptName,
NumOfLeaves=SUM((CASE WHEN B.TV_NgayThoiViec IS NOT NULL THEN 1 ELSE 0 END))
FROM [P0104-TYTHAC].dbo.ST_NHANVIEN A INNER JOIN [P0104-TYTHAC].dbo.ST_NHANVIENTHOIVIEC B ON A.NV_Ma=B.NV_Ma
INNER JOIN [P0104-TYTHAC].dbo.ST_DONVI C ON A.DV_MA_=C.DV_MA
WHERE B.TV_NgayThoiViec BETWEEN @TUNGAY2 AND @DENNGAY2
GROUP BY C.X_MA_,C.DV_MA,C.DV_TEN



--=====================================================================================================================================-
/*															 Attendance Rate by Production Line (Daily Statistics)														    */
--=====================================================================================================================================-
DECLARE @GIOBD DATETIME, @GIOKT DATETIME
SET @GIOBD = '2025-11-13 00:00:00.000'
SET @GIOKT = '2025-11-13 23:59:59.999'


IF OBJECT_ID(N'tempdb..#TONGHOP') IS NOT NULL 
    DROP TABLE #TONGHOP

SELECT DISTINCT nv_ma 
INTO #TONGHOP 
FROM (
    SELECT DISTINCT nv_ma 
    FROM [P0104-TYTHAC].dbo.ST_VAORA WITH (NOLOCK)
    WHERE QT_NGAY = @GIOBD
    
    UNION
    
    SELECT distinct UserNo AS NV_MA 
    FROM FM508..t_mf_RecData1 WITH (NOLOCK)
    WHERE Rectime BETWEEN @GIOBD AND @GIOKT 
    
    UNION
    
    SELECT DISTINCT USERNO AS NV_MA 
    FROM [P0104-TYTHAC].dbo.MF_Record WITH (NOLOCK)
    WHERE MatTime BETWEEN @GIOBD AND @GIOKT
) A

-- Tao clustered index toi uu toc do select
CREATE CLUSTERED INDEX IX_TONGHOP_NVMA ON #TONGHOP(nv_ma)

IF OBJECT_ID(N'tempdb..#NHANVIEN_FILTER') IS NOT NULL 
    DROP TABLE #NHANVIEN_FILTER

SELECT 
    NV.NV_MA,
    NV.DV_MA
INTO #NHANVIEN_FILTER
FROM [P0104-TYTHAC].dbo.ST_NHANVIEN NV WITH (NOLOCK)
WHERE (NV.IT_DDNGHIVIEC IS NULL OR NV.IT_DDNGHIVIEC = 0)
  AND NOT EXISTS (
      SELECT 1 
      FROM [P0104-TYTHAC].dbo.ST_NHANVIENTHOIVIEC C WITH (NOLOCK)
      WHERE C.NV_Ma = NV.NV_Ma
  )

-- Tao 2 index toi uu toc do select 
CREATE CLUSTERED INDEX IX_NV_FILTER ON #NHANVIEN_FILTER(NV_MA)
CREATE NONCLUSTERED INDEX IX_NV_DVMA ON #NHANVIEN_FILTER(DV_MA)

-- Query chinh
SELECT 
    DV.KHU AS Area, 
    DV.DV_MA AS Dept,
    @GIOBD AS Check_in_out_date,
    COUNT(DISTINCT TH.NV_MA) AS The_number_of_employees_working_each_day,
    ISNULL(TS_TOTAL.Total_Employees, 0) AS Total_Employees,
    CASE 
        WHEN ISNULL(TS_TOTAL.Total_Employees, 0) = 0 THEN 0
        ELSE CAST(COUNT(DISTINCT TH.NV_MA) * 100.0 / TS_TOTAL.Total_Employees AS DECIMAL(5,2))
    END AS Attendance_Rate_Percent
FROM [P0104-TYTHAC].dbo.ST_DONVI DV WITH (NOLOCK)
LEFT JOIN #NHANVIEN_FILTER NVF 
    ON NVF.DV_MA = DV.DV_MA
LEFT JOIN #TONGHOP TH 
    ON TH.NV_MA = NVF.NV_MA
LEFT JOIN (
    SELECT 
        DV.DV_MA, 
        COUNT(DDHN.NV_MA) AS Total_Employees
    FROM [P0104-TYTHAC].dbo.IT_DIEMDANHHANGNGAY DDHN WITH (NOLOCK)
    INNER JOIN [P0104-TYTHAC].dbo.ST_DONVI DV WITH (NOLOCK)
        ON DV.DV_MA = DDHN.DV_MA
    WHERE DDHN.NGAY = @GIOBD
    GROUP BY DV.DV_MA
) TS_TOTAL 
    ON TS_TOTAL.DV_MA = DV.DV_MA
WHERE DV.X_MA_ <> 'TAM'
		AND TH.NV_MA IS NOT NULL  
GROUP BY DV.KHU, DV.DV_MA, TS_TOTAL.Total_Employees
ORDER BY DV.KHU, DV.DV_MA

-- Cleanup
DROP TABLE #TONGHOP
DROP TABLE #NHANVIEN_FILTER