ALTER FUNCTION A_EncryptCustom_Break(@encrypted VARCHAR(MAX), @originalLength INT)
/*
-------------------Đây là hàm Đọc 1 đoạn mã hóa, sau đó dịch ra để lấythông tin chuỗi kết nối
------Dùng cho HRM, hoặc phần mềm QLNR mỗi khi mất kết nối
 Sử dụng: SELECT dbo.A_EncryptCustom_Break('-686-855-800-782-882-1026-1120-966-1210-1127-1104-1225-1352',13) AS EncryptedValue
					với 13 là độ dài của chuổi đầu vào được đếm bằng số lượng các nhóm số được cách bằng dấu cách khoảng
*/
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @result VARCHAR(MAX) = '';
    DECLARE @index INT = 1;
    DECLARE @num INT;
    DECLARE @pos INT;
    DECLARE @length INT = LEN(@encrypted);
    DECLARE @start INT = 1;
    DECLARE @part VARCHAR(255);
    DECLARE @factor INT;

    WHILE @start <= @length
    BEGIN
        SET @pos = CHARINDEX('-', @encrypted, @start);
        IF @pos = 0
            SET @pos = @length + 1;
        
        SET @part = SUBSTRING(@encrypted, @start, @pos - @start);
        IF @part <> ''
        BEGIN
            SET @num = CAST(@part AS INT);
            SET @factor = @originalLength + @index;
            SET @result = @result + CHAR(@num / @factor);
            SET @index = @index + 1;
        END

        SET @start = @pos + 1;
    END

    RETURN @result;
END;
GO