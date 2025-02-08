SELECT * DELETE FROM MauCau1 WHERE STT = '1887'
SELECT * FROM MauCau WHERE MauCau LIKE N'%别瞎担心%'

---Thêm vào MauCau1
INSERT INTO MauCau1(MauCau, PhienAm, PhienDich, CumTu, NghiaCumTu, GhiChu, PhanLoai)
select MauCau, PhienAm, PhienDich, CumTu, NghiaCumTu, GhiChu, PhanLoai From MauCau WHERE MauCau NOT IN (SELECT MauCau FROM MauCau1)
------------------
--UPDATE MauCau
SET PhienDich=N'Bạn đừng có lo xa vớ vẩn nữa',
	CumTu = N'瞎担心',
	NghiaCumTu = N'Lo xa'
WHERE MauCau LIKE N'%别瞎担心%'

--INSERT INTO MauCau(MauCau, PhienAm, PhienDich, CumTu, NghiaCumTu, GhiChu, PhanLoai)
VALUES(N'IT单位考量工厂未来人力配置以及技术人才难招募。2023年1月份合同到期李忠效(工号321541)员工请予续签合同留任', -- MauCau - nvarchar(500)
N'T dānwèi kǎoliáng gōngchǎng wèilái rénlì pèizhì yǐjí jìshù réncái nán zhāomù.2023 Nián 1 yuèfèn hétóng dào qí lǐzhōngxiào (gōng hào 321541) yuángōng qǐng yǔ xùqiān hétóng liúrèn' , -- PhienAm - nvarchar(500)
N'Đơn vị IT sau khi xem xét việc bố trí nhân lực của nhà máy trong tương lai và vấn đề khó khăn trong việc tuyển dụng nhân lực IT nên đề nghị tiếp tục gia hạn hợp đồng vào tháng 01 năm 2023 với nhân viên Lý Trung Hiếu ( số thẻ 321541)' , -- PhienDich - nvarchar(500)
N'截至' , -- CumTu - nvarchar(500)
N'tính đến' , -- NghiaCumTu - nvarchar(500)
N'' , -- GhiChu - nvarchar(500)
N'CHAT' -- PhanLoai - nvarchar(50)
    )
