---------------------------------------Hằng Năm NS Yêu Cầu
--Bước 0: Xóa BBNT -> Dời BBHT vào BBNT -> Lấy Ds bình bầu NS gửi qua chép đè lên BBHT

-------------------------Cập Nhật DBL và DBL Promax
--Bước 1:==============Dời Tạm NV Đã Nhập ngày 1 vào ngày khác để chạy Inser Không bị Trùng
	 --UPDATE a
	 SET a.DBL_Ngaybatdau='2022/4/30'
	FROM IT_DIENBIENLUONG a INNER JOIN ST_HOPDONGLAODONG b ON a.NV_Ma = b.NV_Ma
	WHERE  b.TCBBNT >0 AND a.DBL_Ngaybatdau ='2022/4/01'

 --===========================
	 --UPDATE a
	 SET a.DBL_Ngaybatdau='2022/4/30'
	FROM ST_DIENBIENLUONG a INNER JOIN ST_HOPDONGLAODONG b ON a.NV_Ma = b.NV_Ma
	WHERE  b.TCBBNT >0 AND a.DBL_Ngaybatdau ='2022/4/01'


--Bước 2===========Con Trỏ Để Chạy Cách NV Có Phát Sinh thay đổi TCBBNN

--Khai báo bảng chứa cursor
--Khai báo bảng chứa cursor
Declare Cur_PhongIT Cursor For /*Tên bảng sẽ mở ra để cursor chạy xét duyệt*/ 
 
	   Select NV_Ma
	   From ST_HOPDONGLAODONG 
	   WHERE TCBBNT> 0 -- Có phát sinh TCBBNN
---------------Mở bảng Cursor
Open Cur_PhongIT
Declare @NV_MA char(6)
---------------Lấy dữ liệu
Fetch Next From Cur_PhongIT into @NV_MA
---------------Bắt đầu duyệt
While (@@FETCH_STATUS=0) --Biến này sẽ duyệt trong bảng thực nếu có thì sẽ bằng 0, đến khi nếu ko có thì sẽ bằng -1
Begin
	--INSERT Vào IT_DIENBIENLUONG
	INSERT into IT_DIENBIENLUONG(
	NV_MA,DBL_Ngaybatdau,DBL_Soquyetdinh,DBL_Heso,DBL_LuongCB
	,DBL_PhuCap,CV_MA,CVU_MA,DHNN,LDCM,DBL_PhuCapKhac,DBL_TrocapCV
	,DBL_TrocapUDMAY,DBL_TrocapCMNV,DBL_TrocapNN,DBL_TrocapHMPT,DBL_TrocapMOITRUONG
	,DBL_TroCapQLSX,DBL_TroCapCBVP,DBL_TroCapBBNT,DBL_TroCapBBHT,DBL_TroCapBBTHANG
	,DBL_TroCapCLGD,DBL_TroCapHTDP,DBL_TroCapQAQIP,DBL_TrocapThoRap,DBL_TrocapHSE
	,DBL_KHONGHUONGCHUYENCAN,DBL_NGAYTAO,DBL_NGUOITAO,DBL_PHUCLOI,DBL_HTNG,DBL_DQTV,DBL_PCCC)
	 SELECT TOP 1 
	 a.NV_MA,'2022/4/01',a.DBL_Soquyetdinh,a.DBL_Heso,a.DBL_LuongCB
	,a.DBL_PhuCap,a.CV_MA,a.CVU_MA,a.DHNN,a.LDCM,a.DBL_PhuCapKhac,a.DBL_TrocapCV
	,a.DBL_TrocapUDMAY,a.DBL_TrocapCMNV,a.DBL_TrocapNN,a.DBL_TrocapHMPT,a.DBL_TrocapMOITRUONG
	,a.DBL_TroCapQLSX,a.DBL_TroCapCBVP,b.TCBBNT,'0',a.DBL_TroCapBBTHANG
	,a.DBL_TroCapCLGD,a.DBL_TroCapHTDP,a.DBL_TroCapQAQIP,a.DBL_TrocapThoRap,a.DBL_TrocapHSE
	,a.DBL_KHONGHUONGCHUYENCAN,'2022/4/16 00:00:00','Andrew',a.DBL_PHUCLOI,a.DBL_HTNG,a.DBL_DQTV,a.DBL_PCCC 
	FROM IT_DIENBIENLUONG a INNER JOIN ST_HOPDONGLAODONG b ON a.NV_Ma = b.NV_Ma
	WHERE a.NV_Ma = @NV_MA 
	ORDER BY DBL_Ngaybatdau DESC

	--INSERT Vào ST_DIENBIENLUONG
	 INSERT INTO ST_DIENBIENLUONG ( 
	 NV_MA, DBL_NGAYBATDAU, DBL_SOQUYETDINH, DBL_HESO, DBL_LUONGCB
	 , DBL_PHUCAP, CV_MA, CVU_MA, DHNN, DBL_PhuCapKhac, DBL_TrocapCV
	 , DBL_TrocapUDMAY, DBL_TrocapCMNV, DBL_TrocapNN, DBL_TrocapHMPT
	 , DBL_TrocapMOITRUONG, DBL_TroCapQLSX, DBL_TroCapCBVP, DBL_TroCapBBNT
	 , DBL_TroCapBBHT, DBL_TroCapBBTHANG, DBL_TroCapCLGD, DBL_TroCapHTDP
	 , DBL_TroCapQAQIP, DBL_TrocapThoRap, DBL_TrocapHSE, LDCM, DBL_KHONGHUONGCHUYENCAN
	 , DBL_NGAYTAO, DBL_NGUOITAO, DBL_PHUCLOI, DBL_HTNG, DBL_DQTV, DBL_PCCC ) 
	 SELECT NV_MA, DBL_NGAYBATDAU, DBL_SOQUYETDINH, DBL_HESO, DBL_LUONGCB, DBL_PHUCAP
	 , CV_MA, CVU_MA, DHNN, DBL_PhuCapKhac, DBL_TrocapCV, DBL_TrocapUDMAY, DBL_TrocapCMNV
	 , DBL_TrocapNN, DBL_TrocapHMPT, DBL_TrocapMOITRUONG, DBL_TroCapQLSX, DBL_TroCapCBVP
	 , DBL_TroCapBBNT, DBL_TroCapBBHT, DBL_TroCapBBTHANG, DBL_TroCapCLGD, DBL_TroCapHTDP
	 , DBL_TroCapQAQIP, DBL_TrocapThoRap, DBL_TrocapHSE, LDCM, DBL_KHONGHUONGCHUYENCAN
	 ,'2022/4/16 00:00:00',N'Andrew',  DBL_PHUCLOI,  DBL_HTNG,  DBL_DQTV,  DBL_PCCC 
	 FROM IT_DIENBIENLUONG 
	 WHERE DBL_NGAYBATDAU= '2022/04/01' AND NV_MA = @NV_MA
	-------Chạy dòng kế tiếp 
	Fetch Next From Cur_PhongIT into @NV_MA--,@NV_TEN,@DV_MA,@CVU_MA -- Duyệt qua 1 record kế tiếp 
End
---------------Sau khi duyệt xong thì Đóng lại và Giải phóng cursor
Close Cur_PhongIT
Deallocate Cur_PhongIT

--Bước 1:==============Xóa Dòng Ngày Tạm
	 DELETE IT_DIENBIENLUONG
	 WHERE DBL_Ngaybatdau='2022/4/30'
	 

	 DELETE ST_DIENBIENLUONG
	 WHERE DBL_Ngaybatdau='2022/4/30'

