DECLARE @NGAYDAUTHANG DATETIME,
        @NGAYCUOITHANG DATETIME,
        @DP_THANGNAM VARCHAR(7),
        @NGAYCUOITHANGTRUOC DATETIME;


SET @DP_THANGNAM = '08-2025';
SET @NGAYDAUTHANG = RIGHT(@DP_THANGNAM, 4) + '-' + LEFT(@DP_THANGNAM, 2) + '-01';
SET @NGAYCUOITHANG
    = CONVERT(   NVARCHAR(10),
      (
          SELECT DATEADD(d, -1, DATEADD(mm, DATEDIFF(mm, 0, CONVERT(DATE, @NGAYDAUTHANG)) + 1, 0))
      ),
                 21
             );
SET @NGAYCUOITHANGTRUOC = DATEADD(MONTH, -1, @NGAYDAUTHANG);

SELECT NV_Ten,
       CD_CONGDOAN.CD_MANV,
       THANGNAM = @DP_THANGNAM,
       ST_NHANVIEN.DV_MA,
       HD_LuongCB,
       HD_TrocapCMNV,
       HD_TrocapCV,
       TCCBVP,
       HD_TrocapNN,
       TCBBHT,
       TCCBTS,
       HD_TroCapQAQIP,
       HD_TROCAPMOITRUONG,
       HD_TrocapHSE,
       HD_TrocapThoRap,
       HD_PCCC,
       HD_TrocapUD,
       DP_TIEN = CASE
                     WHEN CD_MANV = '300005' THEN
                         0
                     ELSE
                         --@DP_TIEN /*Do mức đóng đoàn phí không cố định nên không sử dụng nữa*/
                         ROUND(
                                  ((ISNULL(HD_LuongCB, 0) + ISNULL(HD_TrocapCMNV, 0) + ISNULL(TCCBVP, 0)
                                    + ISNULL(HD_TrocapNN, 0) + ISNULL(TCBBHT, 0) + ISNULL(TCCBTS, 0)
                                    + ISNULL(HD_TroCapQAQIP, 0) 
                                    + ISNULL(HD_TrocapHSE, 0) + ISNULL(HD_TrocapThoRap, 0) + ISNULL(HD_TrocapCV, 0)
                                    + ISNULL(HD_PCCC, 0) + ISNULL(HD_TrocapUD, 0)
                                   ) * 0.5
                                  ) / 100,
                                  0
                              )
                 END,
       NGAYTAO = GETDATE()
FROM CD_CONGDOAN
    INNER JOIN ST_NHANVIEN
        ON ST_NHANVIEN.NV_Ma = CD_CONGDOAN.CD_MANV
    INNER JOIN ST_HOPDONGLAODONG
        ON CD_CONGDOAN.CD_MANV = ST_HOPDONGLAODONG.NV_Ma
WHERE CD_CONGDOAN.CD_NGAYVAODOAN <= @NGAYCUOITHANG
      AND ST_NHANVIEN.NV_Ma NOT IN
          (
              SELECT NV_Ma
              FROM ST_NHANVIENTHOIVIEC
              WHERE TV_NgayThoiViec <= @NGAYCUOITHANGTRUOC
          )
      AND ST_NHANVIEN.DV_MA NOT LIKE '%CG%'
      --AND ST_NHANVIEN.DV_MA NOT LIKE '%BGD%'
      AND ST_NHANVIEN.DV_MA NOT LIKE 'NV%'
      AND ST_NHANVIEN.NV_Ma IN ( '338103' );
--AND ST_NHANVIEN.DV_Ma ='IT'