SELECT * FROM Busers WHERE USERID = '314844'
-----------------------------
select distinct XieMing, smdd.DDBH, smdd.Qty from smdd left join CutDispatchSSSS on SMDD.DDBH=CutDispatchSSSS.DDBH
  where CONVERT (date, CutDispatchSSSS.USERDATE,111)=CONVERT(date, GETDATE(),111)

select BDepartment.DepName, * from CutDispatchSSSS left join BDepartment on BDepartment.ID=CutDispatchSSSS.DepID  
	where Status='IN' and CONVERT (date, CutDispatchSSSS.USERDATE,111)=CONVERT(date, GETDATE(),111)

select BDepartment.DepName, * from CutDispatchSSSS left join BDepartment on BDepartment.ID=CutDispatchSSSS.DepID  
	where Status='OUT' and CONVERT (date, CutDispatchSSSS.USERDATE,111)=CONVERT(date, GETDATE(),111)



SELECT * FROM CutDispatchSSSS WHERE DDBH = 'JHS2507-108-002'
SELECT * FROM CutDispatchSSS WHERE DDBH = 'JHS2507-108-002'
--DELETE CutDispatchSSSS WHERE DDBH = 'JHS2507-108-002'
--DELETE CutDispatchSSS WHERE DDBH = 'JHS2507-108-002'

SELECT * FROM SMDDSS WHERE DDBH = 'JHS2507-108-002'
SELECT * FROM SMZL WHERE CODEBAR IN  (SELECT CODEBAR FROM SMDDSS WHERE DDBH = 'JHS2507-108-002')

