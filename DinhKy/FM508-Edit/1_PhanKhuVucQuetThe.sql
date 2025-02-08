------------------------------------Chia khu vực máy quẹt thẻ
-------------------Cập nhật đơn vị lại trên dữ liệu máy chấm côm FM-830
SELECT a.UserNo,a.Part,b.NV_Ten,b.DV_MA, CASE WHEN a.Part = b.DV_MA THEN 'Roi' ELSE 'Chua' END AS 'ChuaCapNhatDV'
FROM MF_Users a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
ORDER BY ChuaCapNhatDV

SELECT a.UserNo,a.Part,b.NV_Ten,b.DV_MA,b.DV_MA_
FROM MF_Users a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
WHERE a.Part <> b.DV_MA

--UPDATE a 
SET  a.Part=b.DV_MA
FROM MF_Users a INNER JOIN ST_NHANVIEN b ON a.UserNo = b.NV_Ma
--WHERE b.NV_Ma = '311066'
-------------------Cập nhật đơn vị lại trên dữ liệu máy chấm côm FM-508
SELECT *
FROM FM508..t_DeptClocks
WHERE Clock_ID='204' AND DeptID ='IT'

--DELETE FM508..t_DeptClocks
WHERE Clock_ID='204' AND DeptID <>'IT'

--INSERT INTO FM508..t_DeptClocks(DeptID, Clock_ID)
SELECT deptid,'204'
FROM FM508..departs
WHERE deptid IN ('CHAT 1','CHAT 2','CHUANBI','GCN2'
			,'GCN3','GCN5','GCN-EPCAOTANG','XVGCN'
			,'CHIEUXA-RUADE','DE-L01','DE-L02','DE-L03'
			,'DE-L04','DE-L05','DE-L06','MAIDE','XVDE','CNM','IT','BV')

-----Xem hình  thực tế đã chép lên máy 
select dev_id,COUNT(emp_id) AS TongSo
		,SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS CoHinh
		,COUNT(emp_id) - SUM(CASE WHEN itype = 1 THEN 1 ELSE 0 END) AS ChuaCoHinh
FROM t_deviceemp
WHERE dev_id = '203'
GROUP BY dev_id
-----Xem hình chép lên máy CC còn thiếu mặc dù đã chụp
SELECT *
FROM t_deviceemp a INNER JOIN empphoto b ON a.emp_id = b.empid
WHERE dev_id = '203'
	AND (a.itype = 0 AND b.photo IS NOT NULL)
ORDER BY a.emp_id

-------------------------------------------Khu vực xưởng B
SELECT * 
FROM MF_Users 
WHERE Part IN ('CHAT 1','CHAT 2','CHUANBI','GCN2'
			,'GCN3','GCN5','GCN-EPCAOTANG','XVGCN'
			,'CHIEUXA-RUADE','DE-L01','DE-L02','DE-L03'
			,'DE-L04','DE-L05','DE-L06','MAIDE','XVDE','CNM')

SELECT Part
FROM MF_Users
WHERE Part IN ('CHAT 1','CHAT 2','CHUANBI','GCN2'
			,'GCN3','GCN5','GCN-EPCAOTANG','XVGCN'
			,'CHIEUXA-RUADE','DE-L01','DE-L02','DE-L03'
			,'DE-L04','DE-L05','DE-L06','MAIDE','XVDE','CNM')
GROUP BY Part
ORDER BY Part

SELECT *
FROM ST_DONVI
WHERE DV_MA IN ('CHAT 1','CHAT 2','CHUANBI','GCN2'
			,'GCN3','GCN5','GCN-EPCAOTANG','XVGCN'
			,'CHIEUXA-RUADE','DE-L01','DE-L02','DE-L03'
			,'DE-L04','DE-L05','DE-L06','MAIDE','XVDE','CNM')
ORDER BY DV_MA

SELECT *
FROM ST_NHANVIEN 
WHERE DV_MA = 'CHAT 1'

SELECT * 
FROM MF_Users 
WHERE  UserNo = '311066'
