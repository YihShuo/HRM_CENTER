SELECT * 
FROM employee
WHERE DeptID IN (SELECT deptid FROM departs)

