-------------------------------------------------------Xử lý trường hợp đặc biệt khi ký hợp đồng lương lại thấp hơn so với lúc thử việc------------------------------
----------------------------------------------------------------dẫn tới hệ thống đánh lộn bảo hiểm lên dòng lương thấp nhất-------------------------------------
SELECT L_DuocTraBH_P,L_TraBH_P,L_BHYT,L_BHXH,* FROM ST_LUONG WHERE T_MA='04-2022' AND NV_MA ='322090'
--Cập nhật lại dòng Luong Chính Thức
UPDATE   ST_LUONG 
SET L_DuocTraBH_P='0',L_BHXH='1', L_BHYT='1'
WHERE T_MA='04-2022' AND NV_MA ='322090'
AND L_LUONGCHINH = '3450680.00'
--Cập nhật lại dòng lương thử việc
UPDATE   ST_LUONG 
SET L_DuocTraBH_P='1',L_BHXH='0', L_BHYT='0'
WHERE T_MA='04-2022' AND NV_MA ='322090'
AND L_LUONGCHINH = '3776100.00'