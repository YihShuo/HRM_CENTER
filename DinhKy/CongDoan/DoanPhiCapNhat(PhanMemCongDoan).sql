

SELECT * FROM CD_DOANPHI WHERE DP_THANGNAM='03-2022'

SELECT * FROM CD_DOANPHI WHERE DP_THANGNAM='03-2022' AND DP_MANV='315483'
------------ Trình Tự Cập Nhật Đoàn Phí Tháng

exec CD_LAPDANHSACHDOANPHI_D @DP_THANGNAM='03-2022'								-- Xóa tháng đang tính để chạy lại

exec CD_LAPDANHSACHDOANPHI_I @DP_THANGNAM='03-2022',@DP_TIEN=30700,@DP_THUKHAC=0 -- Cập nhật chung cả công ty

exec CD_LAPDANHSACHDOANPHI_CAPNHATTS @DP_THANGNAM='03-2022'                      -- Cập nhật danh sách đoàn phí đối tượng thai sản

exec CD_DANHSACHDOANPHI_S @DP_THANGNAM=N'03-2022'								 -- Load Danh sách đoàn phí

------------ Nếu Có Sai Xót Thì Chỉnh Tay
exec CD_LAPDANHSACHDOANPHI_U @DP_THANGNAM='03-2022',@DP_MANV=N'315483',@DP_TIEN=50000,@DP_THUKHAC=0 --Lưu ý không chỉnh được các đối tượng có nghỉ thai sản