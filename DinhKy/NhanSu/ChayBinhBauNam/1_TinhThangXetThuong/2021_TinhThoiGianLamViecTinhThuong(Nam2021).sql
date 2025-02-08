------------------------------------------------Cách Tính Số Tháng Được "Tính Thưởng"----------------------------
SELECT a.NV_MA,b.NV_Ten,b.NV_Ngayvao,b.DV_MA
		--Nếu CN cũ thì  Thời gian tính lương =        (5thang x 26ngay x 8tieng) + (thời gian tính lương từ tháng 6)
		--Nếu CN mới thì Thời gian tính lương = (tháng thực tế x 26ngay x 8tieng) + (thời gian tính lương từ tháng 6)
		--Tháng thực tế vào trước 15 được làm tròn 1 tháng, vào sau thì không được làm tròn
		,CASE 
			WHEN  b.NV_Ngayvao<='2021-01-01' then SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0)) --CN làm đủ năm
													+ (8*26*5) -- Được tính giờ công 6 tháng cuối + giờ công đủ 5 tháng đầu
			ELSE																															 --CN mới
				CASE
					WHEN b.NV_Ngayvao >='2021-06-01'  --Vào làm trong thời điểm bắt đầu phát dịch
						THEN SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0))
					ELSE							  --Vào làm trước thời điểm bắt đầu phát dịch
						SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0))
						+																	-- Được tính giờ công 6 tháng cuối + giờ công tháng đầu thực tế làm
						CASE     
							WHEN DATEPART(DAY,NV_Ngayvao) <=15 
								THEN (DATEDIFF(MONTH,NV_Ngayvao,'2021-05-31')+1)*8*26
							ELSE 
								(DATEDIFF(MONTH,NV_Ngayvao,'2021-05-31')+0.5)*8*26
						END
				END 		   
		 END AS [Giờ Tính Thưởng]
		,CASE 
			WHEN  b.NV_Ngayvao<='2021-01-01' then ROUND(
														(
														 (SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0)) --CN làm đủ năm
															+ (8*26*5) -- Được tính giờ công 6 tháng cuối + giờ công đủ 5 tháng đầu
														 )/8
														)/26,1
													   )
			ELSE		       																														 --CN mới
				CASE
					WHEN b.NV_Ngayvao >='2021-06-01'  --Vào làm trong thời điểm bắt đầu phát dịch
						THEN ROUND(
									(
									 (SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0))
									 )/8
									)/26,1
								  )
					ELSE							  --Vào làm trước thời điểm bắt đầu phát dịch
							ROUND(
									((SUM(ISNULL(a.CC_GIOBINHTHUONG,0)+ISNULL(a.CC_GIOBINHTHUONGTAY,0)+ISNULL(a.CC_SOGIONGHI,0))
									  +															-- Được tính giờ công 6 tháng cuối + giờ công tháng đầu thực tế làm
									  CASE     -- Được tính giờ công 6 tháng cuối + giờ công tháng đầu thực tế làm
										WHEN DATEPART(DAY,NV_Ngayvao) <=15 
											THEN (DATEDIFF(MONTH,NV_Ngayvao,'2021-05-31')+1)*8*26
										ELSE 
											(DATEDIFF(MONTH,NV_Ngayvao,'2021-05-31')+0.5)*8*26
									  END
									  )/8
									)/26,1
								 )
			END	
		 END AS [Tháng Tính Thưởng]
FROM ST_GIOQUETTHE a INNER JOIN ST_NHANVIEN b ON a.NV_MA=b.NV_Ma
WHERE YEAR(a.QT_NGAY)='2021' 
	AND QT_NGAY>='2021-06-01'
	--Chọn thời gian tính là có phát sinh giờ làm việc hoặc các phép TS,P,R
	AND (NP_MA IN ('TS','P','R') 
		 OR CC_GIOBINHTHUONG >=1
		 OR CC_GIOBINHTHUONGTAY >=1
		)
	--AND  a.DV_MA='NS'
	--AND a.NV_MA IN ('316199','311708')
	AND b.DV_MA NOT LIKE ('NV%')
	AND a.CA_MA IN ('Ca HC','Ca 2','Ca 3','Ca 4')
GROUP BY a.NV_MA,b.NV_Ngayvao,b.NV_Ten,b.DV_MA
ORDER BY b.DV_MA

