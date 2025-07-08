------------------------------------Do y tế nhập ngày mang thai sai nên xóa để y tế nhâp ngày mang thai lại------------
SELECT * FROM IT_PNMT WHERE NV_MA='315823' AND NGAYMANGTHAI='2023-08-28 00:00:00.000'
--DELETE FROM IT_PNMT WHERE NV_MA='315823' AND NGAYMANGTHAI='2023-08-28 00:00:00.000'

SELECT * FROM it_pnmt_khamthai WHERE NV_MA='315823' AND NGAYMANGTHAI='2023-08-28 00:00:00.000'
--DELETE FROM it_pnmt_khamthai WHERE NV_MA='315823' AND NGAYMANGTHAI='2023-08-28 00:00:00.000'


--SELECT * FROM ST_GIOQUETTHE
--WHERE NV_MA = '315823'
--AND QT_NGAY ='2023-09-01'
----------------------------------Xử lý trường hợp Nhập Sai Giờ Về Sớm 15h30 - Hoặc được về sớm do mang thai nhưng sau đó sẩy thai, và hủy bỏ chế độ này-----------
------------------------------------sau khi xóa trong IT_THAITHANGTHU7------------
------------------------------------thì sẽ không còn được tình đủ công khi về sớm-------------
SELECT *
FROM IT_THAITHANGTHU7
WHERE NV_MA = '340240'

--DELETE IT_THAITHANGTHU7
WHERE NV_MA = '340240'


