-- Ngày làm việc kế tiếp (bỏ qua Chủ nhật & ngày lễ trong ST_LE)
ALTER FUNCTION dbo.fn_NgayHetHanHD
(
    @Ngay DATE
)
RETURNS DATE
AS
BEGIN
    DECLARE @d DATE = @Ngay;

    WHILE (
              DATEPART(WEEKDAY, @d) = 1 -- CN khi DATEFIRST = 7(DF=1 thì CN=7; DF=7 thì CN = 1)
              OR EXISTS
                 (
                     SELECT 1 FROM dbo.ST_LE AS L WHERE CONVERT(DATE, L.LE_NGAY) = @d -- trùng ngày lễ
                 )
          )
    BEGIN
        SET @d = DATEADD(DAY, 1, @d); -- đẩy sang ngày kế tiếp
    END;
	SET @d = DATEADD(DAY,6,@d)
    RETURN @d;
END;
GO
