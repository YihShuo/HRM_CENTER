--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------Do nhân sự có yêu cầu nhập công trước các ngày cuối năm từ 26-30/12-----------------------------------------------------------
------------------------------------------------------------để kịp làm công, nên khi thực tế đế ngày này vẫn phải xử lý các -----------------------------------------------------------
------------------------------------------------------------trường hợp không như đăng ký trước-----------------------------------------------------------
															   /*Các trường hợp như sau:
															    -Không có quẹt giờ nào hết
																-Thiếu quẹt vào hoặc ra
																-Làm không đủ 8 tiếng
															   */
/*
SELECT *
FROM ST_VAORA
WHERE QT_NGAY IN ('2024-12-31','2024-12-31','2024-12-31','2024-12-31','2024-12-31')
AND NV_MA = '316249'

SELECT *
FROM ST_GIOQUETTHE
WHERE QT_NGAY IN ('2024-12-31','2024-12-31','2024-12-31','2024-12-31','2024-12-31')
	AND CC_GIOTANGCA <> '0'
*/

------------------------------------------------------------------------------
/*Bắt đầu lọc ra các trường hợp */
------------------------------------------------------------------------------
 --Không có quẹt giờ nào
		SELECT NV_MA,QT_NGAY
		FROM ST_VaoRa_Temp
		WHERE QT_NGAY = '2024-12-31'
			AND NOT EXISTS (SELECT 1 FROM MF_Record WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd')='2024-12-31' AND MF_Record.UserNo = ST_VaoRa_Temp.NV_MA)
 --Thiếu Quẹt Vào hoặc Quẹt Ra (OK)
		/*--Giải pháp tìm
		SELECT UserNo,DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) 
		FROM MF_Record
		WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31'
		 AND UserNo IN ( SELECT NV_MA FROM ST_VaoRa_Temp WHERE QT_NGAY = '2024-12-31')
		 --AND UserNo = '316249'
		GROUP BY UserNo
		HAVING DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) <= 0
		ORDER BY DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) 
		*/
		
		--Ứng dụng
		SELECT UserNo,MatTime,DevNo 
		FROM MF_Record 
		WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31' 
		AND UserNo in (SELECT UserNo 
						FROM MF_Record
						WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31'
						 AND UserNo IN ( SELECT NV_MA FROM ST_VaoRa_Temp WHERE QT_NGAY = '2024-12-31')
						 --AND UserNo = '316249'
						GROUP BY UserNo
						HAVING DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) <= 0
						)
						ORDER BY UserNo,MatTime

--Có Làm không đủ 8 tiếng (OK)
		/*--Giải pháp tìm
		SELECT UserNo,DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) 
		FROM MF_Record
		WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31'
		 AND UserNo IN ( SELECT NV_MA FROM ST_VaoRa_Temp WHERE QT_NGAY = '2024-12-31')
		 --AND UserNo = '316249'
		GROUP BY UserNo
		HAVING 
			DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) > 0
			and
			DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) <= 8
		ORDER BY DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) 
		*/

		
		--Ứng dụng
		SELECT UserNo,MatTime,DevNo 
		FROM MF_Record 
		WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31' 
		AND UserNo in (SELECT UserNo 
						FROM MF_Record
						WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31'
						 AND UserNo IN ( SELECT NV_MA FROM ST_VaoRa_Temp WHERE QT_NGAY = '2024-12-31')
						 --AND UserNo = '316249'
						GROUP BY UserNo
						HAVING 
							DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) > 0
							and
							DATEDIFF(HOUR,Min(MatTime),MAX(MatTime)) <= 8)
		ORDER BY UserNo,MatTime







--SELECT FORMAT(MatTime,'HH:mm:ss'),FORMAT(MatTime,'yyyy-MM-dd'),FORMAT(MatTime,'dd-MM-yyyy'),FORMAT(CONVERT(DATE,MatTime),''),* 
--FROM MF_Record
--WHERE FORMAT(CONVERT(DATE,MatTime),'yyyy-MM-dd') = '2024-12-31'
-- AND UserNo = '316249'

