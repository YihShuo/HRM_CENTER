SELECT *
	FROM (Select ROW_NUMBER() over (order by deptid) as sTT,deptid
			FROM departs
			) as A
	WHERE 
	A.deptid = 'GCN-EPCAOTANG'
	--AND a.sTT>=31 and a.sTT<=45

-----
--INSERT INTO t_DeptClocks(DeptID, Clock_ID)
SELECT deptid,'207'
FROM departs
WHERE deptid = 'GCN-EPCAOTANG'

-------
SELECT   *
FROM      t_DeviceEmp a INNER JOIN employee b ON a.emp_id = b.EmpID
WHERE dev_id ='207'
ORDER BY dev_id
-------- Xử lý người trùng để không gây lỗi
WITH cte AS (
			 SELECT	dev_id, emp_id ,
			 ROW_NUMBER() OVER (PARTITION BY dev_id, emp_id ORDER BY dev_id, emp_id ) row_num
			 FROM t_deviceemp
			)
DELETE FROM cte
WHERE row_num > 1;

SELECT *
From(
			 SELECT	dev_id, emp_id ,
			 ROW_NUMBER() OVER (PARTITION BY dev_id, emp_id ORDER BY dev_id, emp_id ) row_num
			 FROM t_deviceemp
			) AS A

WHERE row_num > 1;
