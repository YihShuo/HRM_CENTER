USE LYS_ERP
GO
--------------------------------------
-- Biến tạm tính ngày hôm qua
DECLARE @RawYesterday DATE = DATEADD(DAY, -1, CAST(GETDATE() AS DATE))

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
SELECT PerHours.dates,PerHours.DepNo,PerHours.DepName,PerHours.GXLB,SCBZCL.PlanQty ,PerDay.TotQty, (PerDay.TotQty-SCBZCL.PlanQty) as Variance
       ,(PerDay.TotQty*100/SCBZCL.PlanQty) as Person
,sum(case  when Hours='7'
 then Qty  end) as '7'
,sum(case  when Hours='8'
 then Qty  end) as '8'
,sum(case  when Hours='9'
 then Qty  end) as '9'
,sum(case  when Hours='10'
 then Qty  end) as '10'
,sum(case  when Hours='11'
 then Qty  end) as '11'
,sum(case  when Hours='12'
 then Qty  end) as '12'
,sum(case  when Hours='13'
 then Qty  end) as '13'
,sum(case  when Hours='14'
 then Qty  end) as '14'
,sum(case  when Hours='15'
 then Qty  end) as '15'
,sum(case  when Hours='16'
 then Qty  end) as '16'
,sum(case  when Hours='17'
 then Qty  end) as '17'
from (select convert(varchar,SMZL.ScanDate,111) as Dates,SMZL.DepNO,BDepartment.DepName,SMDDSS.GXLB,datepart(Hour,SMZL.ScanDate) as Hours,sum(SMZL.CTS*SMDDSS.Qty) as Qty 
      from SMZL 
      left join BDepartment on BDepartment.ID=SMZL.DepNO 
      left join SMDDSS on SMDDSS.CODEBAR=SMZL.CODEBAR 
      where BDepartment.DepName like '%%'
            and BDepartment.ID like '%%'
            and BDepartment.GSBH='VDH'
            and SMZL.ScanDate between   convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
      group by convert(varchar,SMZL.ScanDate,111),SMZL.DepNO,BDepartment.DepName,SMDDSS.GXLB,datepart(Hour,SMZL.ScanDate) 
      union 
      select convert(varchar,SMZL.ScanDate,111) as Dates,'zTot' as DepNo,'zTot' as DepName,SMDDSS.GXLB,datepart(Hour,SMZL.ScanDate) as Hours,sum(SMZL.CTS*SMDDSS.Qty) as Qty 
      from SMZL 
      left join BDepartment on BDepartment.ID=SMZL.DepNO 
      left join SMDDSS on SMDDSS.CODEBAR=SMZL.CODEBAR 
      where BDepartment.DepName like '%%'
            and BDepartment.ID like '%%'
            and BDepartment.GSBH='VDH'
            and SMZL.ScanDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
      group by convert(varchar,SMZL.ScanDate,111),datepart(Hour,SMZL.ScanDate),SMDDSS.GXLB 
     ) PerHours 
left join (select convert(varchar,SMZL.ScanDate,111) as Dates,SMZL.DepNO,SMDDSS.GXLB,sum(SMZL.CTS*SMDDSS.Qty) as TotQty 
           from SMZL 
           left join BDepartment on BDepartment.ID=SMZL.DepNO 
           left join SMDDSS on SMDDSS.CODEBAR=SMZL.CODEBAR 
           where BDepartment.DepName like '%%'
                 and BDepartment.ID like '%%'
                 and BDepartment.GSBH='VDH'
                 and SMZL.ScanDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
           group by convert(varchar,SMZL.ScanDate,111),SMZL.DepNO,SMDDSS.GXLB 
           union 
           select convert(varchar,SMZL.ScanDate,111) as Dates,'zTot' as DepNo,SMDDSS.GXLB,sum(SMZL.CTS*SMDDSS.Qty) as TotQty 
           from SMZL 
           left join BDepartment on BDepartment.ID=SMZL.DepNO 
           left join SMDDSS on SMDDSS.CODEBAR=SMZL.CODEBAR 
           where BDepartment.DepName like '%%'
                 and BDepartment.ID like '%%'
                 and BDepartment.GSBH='VDH'
                 and SMZL.ScanDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
           group by convert(varchar,SMZL.ScanDate,111),SMDDSS.GXLB 
          ) PerDay on PerDay.DepNO=PerHours.DepNO and PerDay.GXLB=PerHours.GXLB and PerDay.Dates=PerHours.Dates
left join (select convert(varchar,SCBZCL.BZDate,111) as Dates,SCBZCL.DepNo,Bdepartment.GXLB,SCBZCL.Qty as PlanQty 
           from SCBZCL 
           left join BDepartment on BDepartment.ID=SCBZCL.DepNo 
           where BDepartment.DepName like '%%'
                 and BDepartment.ID like '%%'
                 and BDepartment.GSBH='VDH'
                 and BDepartment.ProYN=1 
                 and SCBZCL.BZDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
           union 
           select convert(varchar,SCBZCL.BZDate,111) as Dates,'zTot' as DepNo,Bdepartment.GXLB,sum(SCBZCL.Qty) as PlanQty 
           from SCBZCL 
           left join BDepartment on BDepartment.ID=SCBZCL.DepNo 
           where BDepartment.DepName like '%%'
                 and BDepartment.ID like '%%'
                 and BDepartment.GSBH='VDH'
                 and BDepartment.ProYN=1 
                 and SCBZCL.BZDate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
                 and SCBZCL.DepNo in (select distinct smzl.depno from smzl inner join smddss on smzl.codebar=smddss.codebar where smddss.gxlb in('C','S','A','O') 
                                      and smzl.scandate between convert(smalldatetime,@YesterdayStart) and convert(smalldatetime,@YesterdayEnd) 
           )group by convert(varchar,SCBZCL.BZDate,111),Bdepartment.GXLB 
           ) SCBZCL on SCBZCL.DepNo=PerHours.DepNO and SCBZCL.GXLB=PerHours.GXLB and SCBZCL.Dates=PerHours.Dates
group by PerHours.dates,PerHours.DepNo,PerHours.DepName,PerHours.GXLB,SCBZCL.PlanQty,PerDay.TotQty 
order by PerHours.GXLB,RIGHT(PerHours.DepName,2),SCBZCL.PlanQty,PerDay.TotQty 
