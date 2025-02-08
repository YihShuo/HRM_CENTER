-------Xem hình  thực tế đã chép lên máy 
--select dev_id,COUNT(emp_id) AS TongSo
--		,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh
--		,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh
--FROM t_deviceemp
--WHERE dev_id = '1'
--GROUP BY dev_id


-------Xem hình  thực tế đã chép lên máy 

select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '1' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '203' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '204' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '205' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '206' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '207' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '225' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '227' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '228' GROUP BY dev_id
select dev_id,COUNT(emp_id) AS TongSo,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh FROM t_deviceemp WHERE dev_id = '231' GROUP BY dev_id

---------------------------------------------------------------------------------------------------------
-----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '1'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
-----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '203'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
 -----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '204'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
 -----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '205'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
 -----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '206'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
 -----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '207'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
 -----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '225'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
 -----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '227'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
-----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '228'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
-----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT * FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid WHERE dev_id = '231'	AND (a.itype = 0 AND b.photo IS NOT NULL) ORDER BY a.emp_id
   