----------------Do nhân viên khi thêm mới xã phường không thêm được từ "Phường" nên nhờ IT Chỉnh thêm vào
SELECT * FROM ST_XAPHUONG WHERE TT_MA = 'HoaBinh' AND XP_LOAI IS NULL
SELECT * FROM ST_QUANHUYEN WHERE TT_MA ='HoaBinh' AND QH_MA='7'
SELECT * FROM ST_XAPHUONG WHERE TT_MA = 'HoaBinh' AND QH_MA= '7'
SELECT * FROM ST_XAPHUONG WHERE TT_MA = 'HoaBinh' AND QH_MA= '7' AND XP_Ma = '21' AND XP_LOAI IS NULL


--UPDATE ST_XAPHUONG
  SET xp_loai = N'Xã',XP_TAM = N'Thanh Sơn'
  WHERE TT_MA = 'HoaBinh' AND QH_MA= '7' AND XP_Ma = '21' AND XP_LOAI IS NULL


