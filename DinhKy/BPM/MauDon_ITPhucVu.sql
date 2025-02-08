Select * from 
(SELECT 
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="LNO"]/@fieldValue)[1]', 'nvarchar(max)') AS LNO,
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="Tel"]/@fieldValue)[1]', 'nvarchar(max)') AS Tel,
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="UserID"]/@fieldValue)[1]', 'nvarchar(max)') AS UserID,
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="UserDep"]/@fieldValue)[1]', 'nvarchar(max)') AS UserDep,
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="SoftHard"]/@fieldValue)[1]', 'nvarchar(max)') AS SoftHard,
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="Requirements"]/@fieldValue)[1]', 'nvarchar(max)') AS Requirements,
    T.CURRENT_DOC.value('(/Form/FormFieldValue/FieldItem[@fieldId="Desription"]/@fieldValue)[1]', 'nvarchar(max)') AS Desription
FROM 
    [UOF].[dbo].[TB_WKF_TASK] T
WHERE 
DOC_NBR like 'TT-ITSE%'
	) TB

	Where Desription like '%BAOSU%'