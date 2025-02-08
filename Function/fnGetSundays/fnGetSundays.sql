-----------------------------------------Hàm Tìm Các Ngày Chủ Nhật Trong Năm
---Tạo Func
CREATE FUNCTION fnGetSundays(@Year INT)
RETURNS TABLE
AS
RETURN (
    WITH AllDays AS (
        SELECT DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1, DATEFROMPARTS(@Year, 1, 1)) AS Date
        FROM master.dbo.spt_values
    )
    SELECT Date
    FROM AllDays
    WHERE YEAR(Date) = @Year AND DATEPART(WEEKDAY, Date) = 1
);
---Truy Vấn
SELECT * FROM GetSundays(2024);
/*
Giải thích:
master.dbo.spt_values: Dùng để tạo danh sách các số liên tiếp (nếu không có, bạn có thể sử dụng bảng số khác).
DATEFROMPARTS: Tạo ngày đầu tiên của năm.
ROW_NUMBER(): Tạo danh sách các ngày từ 1/1 đến 31/12.
DATEPART(WEEKDAY, Date): Kiểm tra ngày nào là Chủ nhật (WEEKDAY = 1 tương ứng với SQL Server, có thể thay đổi với cấu hình khác).
*/