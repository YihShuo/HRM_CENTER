SELECT * FROM t_DeviceEmp WHERE  emp_id = '314844'--AND dev_id = '203' 

UPDATE t_DeviceEmp 
SET itype = 2 --2 tức là Admin của máy, 1 tức là user bình thường và đã có hình, 0 chức là chưa có hình
WHERE  emp_id = '314844'
