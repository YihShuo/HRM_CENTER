-- =============================================
-- Author:		<Andrew>
-- Create date: <2025-02-11>
-- Description:	<Trigger kiểm tra có dòng phép nào update có bao gồm chủ nhật hay không, nếu có thì cập nhật vào SN_CHUNHAT>
-- =============================================
CREATE TRIGGER UPDATE_UpdateSN_CHUNHAT_Update
ON ST_NHANVIENNGHIPHEP
AFTER UPDATE
AS
BEGIN
	IF UPDATE (NP_TUNGAY) OR UPDATE(NP_DenNgay) -- Kiểm tra xem cột NP_TuNgay hoặc NP_DenNgay có bị cập nhật không
	BEGIN
		DECLARE @TuNgay DATE, @DenNgay DATE, @SN_CHUNHAT INT
		SELECT @TuNgay = NP_TuNgay, @DenNgay = NP_DenNgay FROM INSERTED

		-- Khởi tạo biến đếm số ngày chủ nhật
		SET @SN_CHUNHAT = 0

		-- Duyệt từ ngày nghỉ phép (NP_TuNgay) đến ngày kết thúc nghỉ phép (NP_DenNgay)
		WHILE @TuNgay <= @DenNgay
		BEGIN
			-- Kiểm tra nếu là Chủ Nhật (Ngày Chủ Nhật có giá trị 1 trong hàm DATEPART)
			IF DATEPART(WEEKDAY, @TuNgay) = 1
			BEGIN
				SET @SN_CHUNHAT = @SN_CHUNHAT + 1
			END

			-- Tăng thêm 1 ngày
			SET @TuNgay = DATEADD(DAY, 1, @TuNgay)
		END

		-- Cập nhật số ngày Chủ Nhật vào cột SN_CHUNHAT
		UPDATE ST_NHANVIENNGHIPHEP
		SET SN_CHUNHAT = @SN_CHUNHAT
		WHERE NV_MA IN (SELECT NV_MA FROM INSERTED)
		AND NP_TuNgay IN (SELECT NP_TuNgay FROM Inserted)
	END 
END
