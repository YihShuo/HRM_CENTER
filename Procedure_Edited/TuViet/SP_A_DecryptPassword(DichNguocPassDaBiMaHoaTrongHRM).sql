--EXEC A_DecryptPassword '-440-520-702',3
ALTER PROCEDURE A_DecryptPassword
    @EncryptedPass NVARCHAR(MAX), -- Chuỗi mật khẩu đã mã hóa
    @OriginalLength INT            -- Độ dài ban đầu của mật khẩu
AS
BEGIN
    DECLARE @DecryptedPass NVARCHAR(MAX) = '';
    DECLARE @Index INT = 1;
    DECLARE @Part NVARCHAR(20);
    DECLARE @EncryptedValue BIGINT;
    DECLARE @AsciiValue INT;
    DECLARE @Pos INT = 1;
    DECLARE @Start INT = 2;
    DECLARE @End INT;

    -- Bỏ qua dấu "-" đầu tiên, bắt đầu từ vị trí thứ 2
    WHILE @Pos <= @OriginalLength
    BEGIN
        -- Tìm vị trí của dấu "-" tiếp theo
        SET @End = CHARINDEX('-', @EncryptedPass, @Start);
        
        -- Nếu không tìm thấy dấu "-", thì lấy đến hết chuỗi
        IF @End = 0 
            SET @End = LEN(@EncryptedPass) + 1;
        
        -- Lấy phần tử mã hóa
        SET @Part = SUBSTRING(@EncryptedPass, @Start, @End - @Start);
        
        -- Chuyển đổi phần tử mã hóa thành giá trị số
        SET @EncryptedValue = CAST(@Part AS BIGINT);
        
        -- Tính lại giá trị ASCII ban đầu
        SET @AsciiValue = @EncryptedValue / (@OriginalLength + @Index);

        -- Thêm ký tự giải mã vào chuỗi kết quả
        SET @DecryptedPass = @DecryptedPass + CHAR(@AsciiValue);

        -- Cập nhật vị trí bắt đầu và chỉ số
        SET @Start = @End + 1;
        SET @Index = @Index + 1;
        SET @Pos = @Pos + 1;
    END

    -- Trả về chuỗi mật khẩu đã giải mã
    SELECT @DecryptedPass AS DecryptedPassword;
END;

/* Đây là hàm mã hóa nhúng trong Code HRM
    Public Shared Function Encrypt1(ByVal varPass As String) As String
        Dim str As String
        Dim num4 As Integer
        Dim num5 As Integer
        ProjectData.ClearProjectError()
        num5 = 1
        Dim num2 As Integer = Strings.Len(varPass)
        If (num2 > 30) Then
            varPass = Strings.Left(varPass, 30)
        End If
        Dim str2 As String = ""
        Dim num6 As Integer = num2
        Dim i As Integer = 1
        Do While (i <= num6)
            Dim num3 As Long = Strings.Asc(Strings.Mid(varPass, i, 1))
            str2 = (str2 & "-" & StringType.FromLong((num3 * (num2 + i))))
            i += 1
        Loop
        str = str2

Label_00A4:
        If (num4 <> 0) Then
            ProjectData.ClearProjectError()
        End If
        Return str
    End Function
*/