-------------------- Xem Tổng Tăng Ca Tính Theo ST_GIOQUETTHE------------------------
DECLARE @TOTAL FLOAT;
DECLARE @Nv_Ma NVARCHAR(10);
DECLARE @MaTu NVARCHAR(50);
DECLARE @Ngay DATETIME;

SELECT @Nv_Ma = '322194'
SET @MaTu = (SELECT NV_MaTu FROM ST_NHANVIEN WHERE NV_Ma =@Nv_Ma)
SET @Ngay = '2025-09-08 00:00:00'

--EXEC SP_TONGGIOTANGCA_NHANVIEN @MANV=@Nv_Ma, @NGAY=@Ngay, @TOTAL=@TOTAL OUTPUT -- float
SELECT @Ngay,@MaTu
EXEC A_SP_CAPNHATTANGCA300_NHANVIEN_A_XemTongTangCa @NGAY=@Ngay,  @MATU=@MaTu;

---------------Xem-------------------
-------------------------------------
------------------------------------C獼g Trong
SELECT * FROM ST_VAORA WHERE      NV_MA = '322194' AND QT_NGAY = '2025-09-08' --AND CA_MA = 'Ca HC'
SELECT * FROM ST_GIOQUETTHE WHERE NV_MA = '322194' AND QT_NGAY = '2025-09-08' 
------------------------------------C獼g Ngo跬
SELECT * FROM ST_VAORA_ WHERE      NV_MA = '322194' AND QT_NGAY = '2025-09-08' --AND CA_MA = 'Ca HC'
SELECT * FROM ST_GIOQUETTHE_ WHERE NV_MA = '322194' AND QT_NGAY = '2025-09-08'

-------------------- Xem Tổng Tăng Ca Tính Theo ST_VAORA_MACHINE-------------------------
SELECT V.NV_Ma,TOTAL=sum(TONGGIOTC)
FROM (SELECT NV_Ma,TONGGIOTC=sum(isnull(giotangca_1,0)+isnull(giotangca_2,0)+isnull(giotangca_3,0)+isnull(giotangca_4,0)+isnull(giotangca_5,0)+isnull(giotangca_6,0)+isnull(giotangca_7,0)
							+isnull(giotangca_8,0)+isnull(giotangca_9,0)+isnull(giotangca_10,0)+isnull(giotangca_11,0)+isnull(giotangca_12,0)+isnull(giotangca_13,0)+isnull(giotangca_14,0)
							+isnull(giotangca_15,0)+isnull(giotangca_16,0)+isnull(giotangca_17,0)+isnull(giotangca_18,0)+isnull(giotangca_19,0)+isnull(giotangca_20,0)+isnull(giotangca_21,0)
							+isnull(giotangca_22,0)+isnull(giotangca_23,0)+isnull(giotangca_24,0)+isnull(giotangca_25,0)+isnull(giotangca_26,0)+isnull(giotangca_27,0)+isnull(giotangca_28,0)
							+isnull(giotangca_29,0)+isnull(giotangca_30,0)+isnull(giotangca_31,0)) 
	  FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA 
	  WHERE DV_MA<>'VPCT' AND NAM=2025 AND THANG<12 AND MANV='322194' 
	  GROUP BY NV_Ma
	  UNION 
	  SELECT NV_Ma,TONGGIOTC=sum(isnull(giotangca_1,0)+isnull(giotangca_2,0)+isnull(giotangca_3,0)+isnull(giotangca_4,0)+isnull(giotangca_5,0)+isnull(giotangca_6,0)+isnull(giotangca_7,0)+isnull(giotangca_8,0)
						  +isnull(giotangca_9,0)+isnull(giotangca_10,0)+isnull(giotangca_11,0)+isnull(giotangca_12,0)+isnull(giotangca_13,0)+isnull(giotangca_14,0)+isnull(giotangca_15,0)+isnull(giotangca_16,0)
						  +isnull(giotangca_17,0)+isnull(giotangca_18,0)+isnull(giotangca_19,0)+isnull(giotangca_20,0)+isnull(giotangca_21,0)+isnull(giotangca_22,0)+isnull(giotangca_23,0)+isnull(giotangca_24,0)
						  +isnull(giotangca_25,0)+isnull(giotangca_26,0)+isnull(giotangca_27,0)+isnull(giotangca_28,0)+isnull(giotangca_29,0)) 
	  FROM ST_VAORA_MACHINE INNER JOIN ST_NHANVIEN ON ST_VAORA_MACHINE.MANV=ST_NHANVIEN.NV_MA
	  WHERE DV_MA<>'VPCT' AND MANV='322194' AND NAM=2025 AND THANG=12
	  GROUP BY NV_Ma
	  ) AS V 
GROUP BY V.NV_Ma
ORDER BY TOTAL DESC
