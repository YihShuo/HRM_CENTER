SELECT TongDV= COUNT(DeptID),Clock_ID
FROM t_DeptClocks
--WHERE Clock_ID='1'
GROUP BY Clock_ID