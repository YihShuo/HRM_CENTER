USE [P0104-TYTHAC]
GO
/****** Object:  UserDefinedFunction [dbo].[TINHSONGAYPHEPTRONGTHANG_]    Script Date: 07/07/2025 下午 12:43:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[TINHSONGAYPHEPTRONGTHANG_]
(
	@Thang int,
	@Nam int
)
RETURNS TABLE
AS
RETURN 
(
	select ST_NHANVIENNGHIPHEP.NV_Ma ,TONGSONGAY= 
										SUM(
											(
												CASE	--TH: Nghỉ phép kéo dài Qua 2 Tháng (Nghỉ Bắt đầu từ tháng đang tính, không tính tháng trước đó)
														WHEN month (np_tungay) <>  month (np_denngay) 
																AND  month (np_tungay) = @Thang 
																AND  month(np_denngay) <> @Thang
																AND YEAR(np_tungay) = YEAR(np_denngay) 
																AND YEAR(np_tungay) =  @NAM 
																AND NP_MA = 'P'
															THEN (datediff (day,np_tungay,(DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,NP_TuNgay)+1, 0)))  ) +1) /*Tính ra ngày cuối tháng là đoạn: 
																																											DATEADD(DAY, -1, DATEADD(MONTH, DATEDIFF(MONTH, 0, np_tungay) + 1, 0))
																																										=> Tính số ngày nghỉ từ np_tungay đến hết tháng (Cộng thêm 1 để tính cả ngày bắt đầu):
																																											DATEDIFF(DAY, np_tungay, ngày_cuối_tháng) + 1*/
																- DateDiff(WW ,NP_TuNgay,NP_DenNgay)/*Trừ số ngày CN trong khoảng đó, chú ý: Hàm DATEIFF(WW,...) 
																									Mỗi lần đi qua một Chủ Nhật → Thứ Hai → tính là 1. Nó không đếm số lượng Chủ Nhật thực sự trong khoảng.
																									Nếu Nghỉ liên tục hơn 1 tuần mà trùng nghỉ từ CN-CN thì nó bỏ, không đếm(DateDiff(WW ,'2025-07-05' ,'2025-07-12')=1).*/
														ELSE 0
												END
											)        
									+
											(
												CASE	--TH: Nghỉ Qua Tháng (Nghỉ kết thúc trong tháng, tính tháng trước đó)
														WHEN month (np_tungay) <>  month (np_denngay) 
																AND  month(np_tungay) <> @Thang
																AND  month (np_denngay) = @Thang 																
																AND YEAR(np_tungay) = YEAR(np_denngay) 
																AND YEAR(np_tungay) =  @NAM  
																AND NP_MA = 'P'
															THEN (datediff (day,(DATEADD(d,0, DATEADD(mm, DATEDIFF(mm, 0 ,np_denngay), 0))),np_denngay) +1)   /*Tính ra ngày đầu tháng là đoạn:
																																											DATEADD(DAY, 0, DATEADD(MONTH, DATEDIFF(MONTH, 0, np_denngay), 0))
																																										=>Tính số ngày từ đầu tháng tới ngày nghỉ kết thúc, bao gồm cả ngày kết thúc
																																											DATEDIFF(DAY, ngày_đầu_tháng, np_denngay) + 1
																																									*/       
															---- trừ cho số ngày chủ nhật từ ngày kt đến ngày cuối 
																- DateDiff(WW ,DATEADD(DAY, 0, DATEADD(MONTH, DATEDIFF(MONTH, 0, np_denngay), 0)),NP_DenNgay) /*Tính số ngày CN từ Đầu tháng đến ngày kết thúc nghỉ: */
														ELSE 0
												END
												) 
									+				
											(
												CASE	--TH: Nghỉ Trong Tháng
														WHEN month (np_tungay) =  month (np_denngay) 
																and  month (np_tungay) = @Thang
																and YEAR(np_tungay) = YEAR(np_denngay) 
																and YEAR(np_tungay) =  @NAM AND NP_MA = 'P'															
															THEN 
																(CASE 
																	WHEN np_ghichu like N'%0.5%' 
																		THEN 0.5
																	ELSE (DATEDIFF(day,NP_TuNgay ,NP_DenNgay ) + 1)
																END) 
																- DateDiff(WW ,NP_TuNgay,NP_DenNgay)
														ELSE 0
												END
											) 
											)			
		,TONGSONGAY_CTDUYET= 
						SUM(
							(
								CASE 
									WHEN month (np_tungay)<>  month (np_denngay) 
										  and  month (np_tungay) = @Thang and  month(np_denngay) <> @Thang
										  and YEAR(np_tungay) = YEAR(np_denngay) and YEAR(np_tungay) =  @NAM  AND NP_MA = 'P' and NP_CONGTYDUYET = '1'
									THEN (datediff (day,np_tungay,(DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,NP_TuNgay)+1, 0)))  ) +1)
										  ---- trừ cho số ngày chủ nhật từ ngày ngày đầu tháng đến ngày kết thúc nghỉ phép
										  - ( DateDiff(WW ,(DATEADD(d,-1, DATEADD(mm, DATEDIFF(mm, 0 ,NP_TuNgay)+1, 0))) ,NP_TuNgay)  )
          
									ELSE 0
								END
							)        
						+
							(
								CASE 
									WHEN month (np_tungay)<>  month (np_denngay) 
										  and  month (np_denngay) = @Thang and  month(np_tungay) <> @Thang
										  and YEAR(np_tungay) = YEAR(np_denngay) 
										  and YEAR(np_tungay) =  @NAM  AND NP_MA = 'P' and NP_CONGTYDUYET = '1'
										THEN (datediff (day,(DATEADD(d,0, DATEADD(mm, DATEDIFF(mm, 0 ,np_denngay), 0))),np_denngay) +1)
											  ---- trừ cho số ngày chủ nhật từ ngày kt đến ngày cuối 
											  - ( DateDiff(WW ,(DATEADD(d,0, DATEADD(mm, DATEDIFF(mm, 0 ,np_denngay), 0))),np_denngay  ))
									ELSE 0
								END
							) 
						 +
							(
								CASE 
									WHEN month (np_tungay) =  month (np_denngay) 
										  and  month (np_tungay) = @Thang
										  and YEAR(np_tungay) = YEAR(np_denngay) 
										  and YEAR(np_tungay) =  @NAM AND NP_MA = 'P' and NP_CONGTYDUYET = '1'
										THEN (DATEDIFF(day,NP_TuNgay ,NP_DenNgay ) + 1) - DateDiff(WW ,NP_TuNgay,NP_DenNgay)
									ELSE 0
								END
							) 
						 )
FROM ST_NHANVIENNGHIPHEP
WHERE YEAR(np_tungay) = @NAM
	AND (MONTH(NP_TuNgay) = @Thang or MONTH (NP_DenNgay) = @Thang 
	AND NP_MA = 'P')
GROUP BY ST_NHANVIENNGHIPHEP.NV_Ma 
)

