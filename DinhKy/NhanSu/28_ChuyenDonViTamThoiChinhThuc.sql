---------------------------Do số lượng nhiều nên NS nhờ IT điều động bằng tay
------------------Bước 1: Điều Động Tạm Thời, vào cuối tháng không ảnh hưởng đến kế toán
------------Cập nhật trên ST_NhanVien
SELECT * FROM A_CHUYENDONVI --WHERE DV_MA_ChuyenToi NOT IN (SELECT DV_MA FROM ST_DONVI)
SELECT * FROM ST_NHANVIEN a INNER JOIN A_CHUYENDONVI b ON a.NV_Ma = b.NV_MA
--DELETE FROM A_CHUYENDONVI
--UPDATE a
SET	a.DV_MA_ = b.DV_MA_ChuyenToi
FROM ST_NHANVIEN a INNER JOIN A_CHUYENDONVI b ON a.NV_Ma = b.NV_MA

--------------Cập nhật trên IT_CHUYENDONVI
SELECT NV_MA,Ngay_DDTamThoi,DV_MA_ChuyenToi FROM A_CHUYENDONVI 

--INSERT INTO IT_CHUYENDONVI(NV_MA, NGAY, DV_MA)
SELECT NV_MA,Ngay_DDTamThoi,DV_MA_ChuyenToi FROM A_CHUYENDONVI 

------------------Bước 2: Điều Động Chính Thức, vào đầu tháng sau, khi kế toán tính lương xong, thường từ 10-15 tây
--------------------Trước khi điều động chính thức, nếu NS có báo đối tượng trước kia điều động tạm thời đã nghĩ việc
----------------------thì cập nhật lại cột "CapNhat_NV" lại thành "True" hoặc "1" để Bỏ ra các đối tượng nghỉ việc do từ lúc điều tạm thời tới điều 9 thức có thể có người nghỉ việc
------------Cập nhật trên ST_NhanVien
SELECT * FROM ST_NHANVIEN a INNER JOIN A_CHUYENDONVI b ON a.NV_Ma = b.NV_MA WHERE b.CapNhat_NV ='FALSE' OR b.CapNhat_NV IS NULL

--UPDATE a
SET	a.DV_MA = b.DV_MA_ChuyenToi
FROM ST_NHANVIEN a INNER JOIN A_CHUYENDONVI b ON a.NV_Ma = b.NV_MA
WHERE b.CapNhat_NV ='FALSE' OR b.CapNhat_NV IS NULL

--------------Cập nhật trên ST_CHUYENDONVI
SELECT NV_MA,Ngay_DDChinhThuc,CDV_Donvimoi,CDV_donvicu,CDV_Chucvucu,CDV_Chucvumoi FROM A_CHUYENDONVI 

--INSERT INTO ST_CHUYENDONVI(NV_Ma, Ngay, CDV_Donvimoi, CDV_donvicu, CDV_Chucvucu, CDV_Chucvumoi, NGAYTAO, NGUOITAO, NGAYCAPNHAT, NGUOICAPNHAT)
SELECT NV_MA,Ngay_DDChinhThuc,CDV_Donvimoi,CDV_donvicu,CDV_Chucvucu,CDV_Chucvumoi,
		GETDATE(),
		'IT',
		GETDATE(),
		'IT'
FROM A_CHUYENDONVI 
WHERE CapNhat_NV ='FALSE' OR CapNhat_NV IS NULL
------------------------------------------HET------------------------------------
------------------------------------------------------------------------------------------------------------------------------------

SELECT IT_DDNGHIVIEC,* 
FROM ST_NHANVIEN
WHERE NV_Ma = '320194'
SELECT * 
FROM IT_CHUYENDONVI
WHERE NV_Ma = '320194'
SELECT * 
FROM ST_CHUYENDONVI
WHERE NV_Ma = '320194'