
------------------------------------------------
------------B1:Tạo Table Temp------------------
Delete From ST_VaoRa_Temp
Delete From ST_GioQuetThe_Temp
Delete From ST_VaoRa___Temp
Delete From ST_GioQuetThe___Temp

----------------Cong Trong---------------------
Select * From ST_VaoRa_Temp ORDER BY NV_MA
Select * From ST_GioQuetThe_Temp ORDER BY NV_MA
----------------Cong Ngoai--------------------
Select * From ST_VaoRa___Temp
Select * From ST_GioQuetThe___Temp

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
SELECT * 
FROM ST_VAORA a INNER JOIN ST_VaoRa_Temp b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY
WHERE a.CA_MA=b.CA_MA

SELECT * 
FROM ST_VAORA_ a INNER JOIN ST_VaoRa___Temp b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY
WHERE a.CA_MA=b.CA_MA

SELECT a.*
FROM ST_GIOQUETTHE a INNER JOIN ST_GioQuetThe_Temp b ON a.NV_MA=b.NV_MA AND	a.QT_NGAY=b.QT_NGAY

SELECT * 
FROM ST_GIOQUETTHE_ a INNER JOIN ST_GioQuetThe___Temp b ON a.NV_MA=b.NV_MA AND	a.QT_NGAY=b.QT_NGAY

----------------------------------------------------------------------------------------------------------(TRƯỜNG HỢP CHỈ CẬP NHẬT)------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------
------------Ghép Nối Thử Bảng Chính Và Bảng Temp------------------
----------------Cong Trong---------------------
  
------------------------------------------------
------------B3:Update Bang Chinh-----------------

/*

Update a
Set a.QT_GIOVAO=b.QT_GIOVAO, a.QT_GIORA=b.QT_GIORA
From ST_VAORA As a inner join ST_VaoRa_Temp As b on  a.NV_ma=b.NV_ma
Where a.QT_NGAY = b.QT_NGAY and a.CA_MA = b.CA_MA
Update a
Set  a.CA_MA=b.CA_MA,a.CC_GIOBINHTHUONG=b.CC_GIOBINHTHUONG, a.CC_GIOTANGCA=b.CC_GIOTANGCA, a.CC_HESONGAYCONG=b.CC_HESONGAYCONG,a.CC_SUATAN=b.CC_SUATAN,a.CC_GIOTANGCAS=b.CC_GIOTANGCAS,a.CC_GIOAN=b.CC_GIOAN
From ST_GioQuetThe As a inner join ST_GioQuetThe_Temp As b on a. NV_ma=b.NV_ma
Where a.QT_NGAY=b.QT_NGAY
Update a
Set a.QT_GIOVAO=b.QT_GIOVAO,a.QT_GIORA=b.QT_GIORA
From ST_VaoRa_ As a inner join ST_VaoRa___Temp As b on a.NV_MA=b.NV_MA
Where a.QT_NGAY=b.QT_NGAY and a.CA_MA=b.CA_MA
Update a
Set  a.CA_MA=b.CA_MA,a.CC_GIOBINHTHUONG=b.CC_GIOBINHTHUONG, a.CC_GIOTANGCA=b.CC_GIOTANGCA, a.CC_HESONGAYCONG=b.CC_HESONGAYCONG,a.CC_SUATAN=b.CC_SUATAN,a.CC_GIOTANGCAS=b.CC_GIOTANGCAS,a.CC_GIOAN=b.CC_GIOAN
From ST_GioQuetThe_ As a inner join ST_GioQuetThe___Temp As b on a.NV_MA=b.NV_MA
Where a.QT_NGAY=b.QT_NGAY

*/
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------(TRƯỜNG HỢP NHẬP HẾT FILE TỪ NHÂN SỰ GỬI QUA)------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------Xem File NS gửi có bị lỗi trùng ko------------------------
Select NV_MA,QT_NGAY,COUNT(QT_GIOVAO)
FROM ST_VaoRa_Temp
GROUP BY NV_MA,QT_NGAY
HAVING COUNT(QT_GIOVAO) >1

------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------Xử lý lỗi trùng quẹt thẻ------------------------
-------------------------------------VAORA----------------------------------
--------Xóa Các dòng chính
SELECT * 
FROM ST_VAORA a INNER JOIN ST_VaoRa_Temp b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY
WHERE a.CA_MA=b.CA_MA

--DELETE a
FROM ST_VAORA a INNER JOIN ST_VaoRa_Temp b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY
WHERE a.CA_MA=b.CA_MA

--------Chèn vào
--INSERT INTO ST_VAORA(NV_MA, QT_NGAY, CA_MA, QT_GIOVAO, QT_GIORA,QT_NGAYCAPNHAT,QT_NGUOICAPNHAT)
SELECT NV_MA, QT_NGAY, CA_MA, QT_GIOVAO, QT_GIORA,GETDATE(),'Andrew'
FROM ST_VaoRa_Temp

-------------------------------------VAORA_----------------------------------
--------Xóa Các dòng chính
SELECT * 
FROM ST_VAORA_ a INNER JOIN ST_VaoRa___Temp b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY
WHERE a.CA_MA=b.CA_MA

--DELETE a
FROM ST_VAORA_ a INNER JOIN ST_VaoRa___Temp b ON a.NV_MA = b.NV_MA AND a.QT_NGAY=b.QT_NGAY
WHERE a.CA_MA=b.CA_MA

--------Chèn vào
--INSERT INTO	ST_VAORA_(NV_MA, QT_NGAY, CA_MA, QT_GIOVAO, QT_GIORA)
SELECT NV_MA, QT_NGAY, CA_MA, QT_GIOVAO, QT_GIORA
FROM  ST_VaoRa___Temp

-------------------------------------GioQuetThe------(Làm Theo Cách Inser từ đầu)----------------------------
SELECT a.*
FROM ST_GIOQUETTHE a INNER JOIN ST_GioQuetThe_Temp b ON a.NV_MA=b.NV_MA AND	a.QT_NGAY=b.QT_NGAY

--DELETE a
FROM ST_GIOQUETTHE a INNER JOIN ST_GioQuetThe_Temp b ON a.NV_MA=b.NV_MA AND	a.QT_NGAY=b.QT_NGAY

--------Chèn vào
--INSERT INTO	ST_GIOQUETTHE(NV_MA, QT_NGAY, CA_MA, CC_GIOBINHTHUONG, CC_GIOTANGCA, CC_HESONGAYCONG,CC_SUATAN, DV_MA, CC_GIOTANGCAS,  QT_NGUOICAPNHAT, DV_MATL,CC_GIOAN)
SELECT a.NV_MA,a.QT_NGAY,a.CA_MA,a.CC_GIOBINHTHUONG,a.CC_GIOTANGCA,a.CC_HESONGAYCONG,a.CC_SUATAN,b.DV_MA_,a.CC_GIOTANGCAS,'Andrew',b.DV_MA,a.CC_GIOAN
FROM ST_GioQuetThe_Temp a LEFT JOIN ST_NHANVIEN b ON a.NV_MA=b.NV_Ma                

-------------------------------------GioQuetThe_-------(Làm Theo Cách Insert từ đầu)---------------------------
SELECT * 
FROM ST_GIOQUETTHE_ a INNER JOIN ST_GioQuetThe___Temp b ON a.NV_MA=b.NV_MA AND	a.QT_NGAY=b.QT_NGAY

--DELETE a 
FROM ST_GIOQUETTHE_ a INNER JOIN ST_GioQuetThe___Temp b ON a.NV_MA=b.NV_MA AND	a.QT_NGAY=b.QT_NGAY


--INSERT INTO	ST_GIOQUETTHE_(NV_MA, QT_NGAY, CA_MA, CC_GIOBINHTHUONG, CC_GIOTANGCA, CC_HESONGAYCONG,CC_SUATAN, DV_MA, CC_GIOTANGCAS,CC_GIOAN)
SELECT a.NV_MA,a.QT_NGAY,a.CA_MA,a.CC_GIOBINHTHUONG,a.CC_GIOTANGCA,a.CC_HESONGAYCONG,a.CC_SUATAN,b.DV_MA,a.CC_GIOTANGCAS,a.CC_GIOAN
FROM ST_GioQuetThe___Temp a LEFT JOIN ST_NHANVIEN b ON a.NV_MA=b.NV_Ma                
------------------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------(HẾT)----------------------------

