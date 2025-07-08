										/*Dưới đây là hướng dẫn từng bước để bạn chuyển database sang chế độ SIMPLE
													, thu nhỏ file log .ldf, và giữ hệ thống ổn định — phù hợp với 
													tình hình hiện tại của bạn (backup .bak mỗi ngày, file log đang phình to).*/
-- 1. Kiểm tra tên Logical của file log,và dung lượng 
USE [P0104-TYTHAC];
GO
EXEC sp_helpfile;

SELECT name, recovery_model_desc 
FROM sys.databases 
WHERE name = 'P0104-TYTHAC';


-- 2. Chuyển sang chế độ SIMPLE
ALTER DATABASE [P0104-TYTHAC] SET RECOVERY SIMPLE WITH NO_WAIT;


--3. Thu nhỏ file log (SHRINKFILE)
USE [P0104-TYTHAC];
GO
DBCC SHRINKFILE('P0104-TYTHAC_log', 1024);  -- Giới hạn log còn khoảng 1 GB

--4. (Tùy chọn) Đặt giới hạn tăng trưởng log,Nếu log bị phình quá nhiều trong tương lai, bạn nên đặt giới hạn tăng trưởng:
ALTER DATABASE [P0104-TYTHAC]
MODIFY FILE (
    NAME = 'P0104-TYTHAC_log',
    MAXSIZE = 5GB,        -- Tối đa 5GB
    FILEGROWTH = 256MB     -- Tăng dần 256MB mỗi lần
);
/*
🧠 Sau đó, bạn chỉ cần tiếp tục:
Backup full .bak hàng ngày như bạn đang làm
Không cần lo về backup log nữa
File .ldf sẽ giữ ở mức nhỏ, ổn định
*/