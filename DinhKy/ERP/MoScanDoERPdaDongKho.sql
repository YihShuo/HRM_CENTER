/*
VDH: kho sx đại trà
VDK: kho kỷ thuật - khai thác - phòng mẫu
VDX: kho tổng vụ
VDKX: kho tổng vụ DC
VDz: không biết
VGC: kho hóa chất

*/
---------------------------------Thường hợp 1-------------------------------------
					/*
						Do hàng về cuối tháng, hệ thống ERP đã đóng kho để kiểm kê, nên chưa nhập xuất kho kịp, dựa theo tiến độ
					của sinh quản để đáp ứng nhu cầu sản xuất hiện trường nên kho phát hàng trước dẫn đến lệnh đơn hàng trên hệ thống
					bị Scan, nhở IT mở Scan để kho xuất đủ định mức trên hệ thống, không ảnh hưởng đến xuất hàng.
						DDZL: Dữ liệu đơn hàng của cty sx cho khách hàng (Quang trọng)
						**Lưu ý: 
							Khi cập nhật thì Shipdate phải trong trạng thái tương lai, do nó có ảnh hưởng đến SSID cập nhật định kỳ.
						Ví dụ đến điểm cập nhật liên quan Shipdate, tấc cả các dữ liệu Scand trước đó sẽ được cập nhật ok. Qua thời điểm
						này rồi thì nó không cập nhật được nữa. Nếu can thiệp cho mở scan thì SSID sẽ bỏ qua các dữ liệu không đối chiếu
						được trước đó
							Trạng thái YN: 1 là cho thao tác, 5 là khóa
							Mở lệnh chỉ có giá trị trong ngày. Mỗi sáng sớm SSIS sẽ quét ShipDate nếu qua ngày, hoặc lệnh đã scan rồi là sẽ khóa
					*/

SELECT yn,ShipDate, * FROM DDZL where ddbh='jhs2502-307' 
--Update 
ddzl set yn=1 where ddbh='jhs2502-307'
---------------------------------Thường hợp 2-------------------------------------
                    /*
						Do sinh quản cần lên phiếu bù trừ tiền nhà cung ứng nhưng hệ thống đã bị khóa không kéo định mức được.
						Cần đề nghị IT mở hệ thống lệnh  JHS2502-110
					*/
SELECT yn,ShipDate, * FROM DDZL where ddbh='JHS2502-110'
--Update 
ddzl set yn=1 where ddbh='JHS2502-110'
---------------------------------Thường hợp 3-------------------------------------
					/*
						 Do đơn đặt mua hàng 20241101072 trên hệ thống của nhà cung ứng KURARAY mã K020072193 cần mua MOQ , 
					mã vật tư K020072192 cần hủy đơn trên hệ thống ERP 
					và đơn đặt mua 20241201013 trên hệ thống của nhà cung ứng TIONG LIONG mã A110023147 cần mua MOQ ,
					nhưng đơn hàng đã quá 7 ngày không thể chỉnh sửa , nhờ IT cập nhật lại ngày của đơn đặt mua hàng 20241101072, 20241201013.
						Chi tiết xem file đính kèm
						Đường dẫn vào VDH 系統的操作 purchase - N2-N21-N213 
						Đơn 20241101072
						Đường dẫn vào VDH 系統的操作 purchase - N2-N21-N211 
						Đơn 20241201013
						CGZL: là bảng đặt mua hàng của cty đối với NCU
						Chú ý:
							CGDate không được sửa ngày, do kiểm toán yêu cầu
							Cập nhật lại USERDate để không quá 7 ngày, từ đó có thể scan lại
							YN: 1 tức là mở scan chưa nhập kho
								5 tức là khóa scan do hàng đã vào kho

					*/
SELECT * FROM CGZL WHERE CGNO = '20241101072' 
--UPDATE  CGZL 
SET USERDate = GETDATE()
	,YN = '1'.
WHERE CGNO = '20241101072'
---------------------------------Thường hợp 3-------------------------------------
					/*
						Do nhập sai giá và số lượng nhờ IT mở phiếu mua hàng trên hệ thống ERP để sửa 
						Purchase-N2-N21-N213 mã 20241000828, 20241000831, 20241100415, 20241100563
						Trước khi sửa 修改前
						V101021224 giá 119.726
						V101021343 số lượng 6
						V101021689 giá 58.923
						V101021879 giá 86.475
						Sau khi sửa 修改后 
						V101021224 价 59.863
						V101021343 数量 8
						V101021689 价 29.462
						V101021879 价 43.238
					*/
SELECT * FROM CGZL WHERE CGNO = '20241000828' 
SELECT * FROM CGZLs WHERE CGNO = '20241000828' AND CLBH = 'V101021224'
--UPDATE  CGZL 
SET USERDate = GETDATE()
	,YN = '1'.
WHERE CGNO = '20241000828'


SELECT * FROM Busers WHERE USERID = '314844'

