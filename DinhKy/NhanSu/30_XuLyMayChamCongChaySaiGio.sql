------------------------------------------------------------Do máy chấm công chạy sai giờ nên đồng loạt chỉnh giờ lại những người quẹt thẻ-------------------------
-----------------------------------------------Nhân sự sẽ gửi các số thẻ bị chấm sớm hoặc trể để IT đồng loạt cộng hoặc trừ giờ bù lại
----B1: Cập nhật lại ST_VaoRa
SELECT DATEADD(MINUTE,-60,b.QT_GIOVAO),* 
From A_NV_MA a INNER JOIN ST_VAORA b  ON a.NV_Ma = b.NV_MA
WHERE b.QT_NGAY ='2024-03-21'
	AND b.CA_MA  = a.DV_MA

--UPDATE b
SET b.QT_GIOVAO = DATEADD(MINUTE,-60,b.QT_GIOVAO)
From A_NV_MA a INNER JOIN ST_VAORA b  ON a.NV_Ma = b.NV_MA
WHERE b.QT_NGAY ='2024-03-21'
	AND b.CA_MA  = a.DV_MA

SELECT DATEADD(MINUTE,-60,b.QT_GIOVAO),* 
From A_NV_MA a INNER JOIN ST_VAORA_ b  ON a.NV_Ma = b.NV_MA
WHERE b.QT_NGAY ='2024-03-21'
	AND b.CA_MA  = a.DV_MA

--UPDATE b
SET b.QT_GIOVAO = DATEADD(MINUTE,-60,b.QT_GIOVAO)
From A_NV_MA a INNER JOIN ST_VAORA_ b  ON a.NV_Ma = b.NV_MA
WHERE b.QT_NGAY ='2024-03-21'
	AND b.CA_MA  = a.DV_MA

----B2: Để nhân sự tự chấm tay lại