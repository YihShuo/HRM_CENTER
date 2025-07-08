USE LYS_ERP
GO
--------------------------------------
-- Biến tạm tính ngày hôm qua
DECLARE @RawYesterday DATE = DATEADD(DAY, -1, CAST(GETDATE() AS DATE))
DECLARE @DepName NVARCHAR(50) = 'DT_G-LINE 9'

-- Kiểm tra nếu là Chủ nhật thì lùi thêm 1 ngày
DECLARE @AdjustedDate DATE = 
    CASE 
        WHEN DATEPART(WEEKDAY, @RawYesterday) = 1 
            THEN DATEADD(DAY, -1, @RawYesterday) 
        ELSE @RawYesterday 
    END

-- Khởi tạo 2 biến kết quả
DECLARE @YesterdayStart DATETIME = CAST(@AdjustedDate AS DATETIME)
DECLARE @YesterdayEnd DATETIME = DATEADD(SECOND, 86399, @YesterdayStart)

---- Kết quả
--SELECT 
--    @YesterdayStart AS YesterdayStart,
--    @YesterdayEnd AS YesterdayEnd
--------------------------------------
SELECT PerHours.dates,PerHours.DepNo,PerHours.DepName,PerHours.GXLB,SCBZCL.PlanQty ,PerDay.TotQty,(PerDay.TotQty*100/SCBZCL.PlanQty) as Person

from (select convert(varchar,SMZL.ScanDate,111) as Dates,SMZL.DepNO,BDepartment.DepName,SMDDSS.GXLB,datepart(Hour,SMZL.ScanDate) as Hours,sum(SMZL.CTS*SMDDSS.Qty) as Qty 
      from SMZL 
      left join BDepartment on BDepartment.ID=SMZL.DepNO 
      left join SMDDSS on SMDDSS.CODEBAR=SMZL.CODEBAR 
      where BDepartment.DepName like '%%'
            and BDepartment.ID like '%%'
            and BDepartment.GSBH='VDH'
			AND SMDDSS.GXLB = 'A'
            and SMZL.ScanDate between   convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
			AND DepName = @DepName
      group by convert(varchar,SMZL.ScanDate,111),SMZL.DepNO,BDepartment.DepName,SMDDSS.GXLB,datepart(Hour,SMZL.ScanDate) 
     ) PerHours 
----------------------------------------------------------------------------------------------------------------------------------------
left join (select convert(varchar,SMZL.ScanDate,111) as Dates,SMZL.DepNO,SMDDSS.GXLB,sum(SMZL.CTS*SMDDSS.Qty) as TotQty 
           from SMZL 
           left join BDepartment on BDepartment.ID=SMZL.DepNO 
           left join SMDDSS on SMDDSS.CODEBAR=SMZL.CODEBAR 
           where BDepartment.DepName like '%%'
                 and BDepartment.ID like '%%'
                 and BDepartment.GSBH='VDH'
				 AND SMDDSS.GXLB = 'A'
				 AND DepName = @DepName
                 and SMZL.ScanDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
           group by convert(varchar,SMZL.ScanDate,111),SMZL.DepNO,SMDDSS.GXLB          
          ) PerDay on PerDay.DepNO=PerHours.DepNO and PerDay.GXLB=PerHours.GXLB and PerDay.Dates=PerHours.Dates
----------------------------------------------------------------------------------------------------------------------------------------
left join (select convert(varchar,SCBZCL.BZDate,111) as Dates,SCBZCL.DepNo,Bdepartment.GXLB,SCBZCL.Qty as PlanQty 
           from SCBZCL 
           left join BDepartment on BDepartment.ID=SCBZCL.DepNo 
           where BDepartment.DepName like '%%'
                 and BDepartment.ID like '%%'
                 and BDepartment.GSBH='VDH'
                 and BDepartment.ProYN=1 
				 AND DepName =  @DepName
                 and SCBZCL.BZDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
           ) SCBZCL on SCBZCL.DepNo=PerHours.DepNO and SCBZCL.GXLB=PerHours.GXLB and SCBZCL.Dates=PerHours.Dates
group by PerHours.dates,PerHours.DepNo,PerHours.DepName,PerHours.GXLB,SCBZCL.PlanQty,PerDay.TotQty 
order by PerHours.GXLB,RIGHT(PerHours.DepName,2),SCBZCL.PlanQty,PerDay.TotQty 
