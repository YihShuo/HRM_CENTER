
ALTER FUNCTION A_EncryptCustom(@varPass VARCHAR(255))
/*
-------------------Đây là hàm Đọc 1 chuỗi ký tự, sau đó mã hóa ra để làm thông tin chuỗi kết nối
------Dùng cho HRM, hoặc phần mềm QLNR mỗi khi mất kết nối
 Sử dụng: SELECT dbo.A_EncryptCustom('192.168.71.14') AS EncryptedValue

*/
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @result VARCHAR(MAX) = '';
    DECLARE @i INT = 1;
    DECLARE @num2 INT = LEN(@varPass);
    DECLARE @num3 INT;
    DECLARE @char CHAR(1);

    IF @num2 > 30
    BEGIN
        SET @varPass = LEFT(@varPass, 30);
        SET @num2 = 30;
    END

    WHILE @i <= @num2
    BEGIN
        SET @char = SUBSTRING(@varPass, @i, 1);
        SET @num3 = ASCII(@char);
        SET @result = CONCAT(@result, '-', @num3 * (@num2 + @i));
        SET @i = @i + 1;
    END

    RETURN @result;
END;
GO
