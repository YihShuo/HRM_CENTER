Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports NJFLib.Controls
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports TD.SandBar
Imports System.DBNull
Imports System.Drawing.Bitmap
Public Class frmKiemTraCMND

    Private Sub txtSoCMND_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSoCMND.ValueChanged
        Dim TABLE As New DataTable
        Dim nRow As Integer = 0
        Dim manv As String
        Dim hoten As String
        Dim matu As String
        Dim donvi As String
        Dim gioitinh As Integer

        Dim soCMND As String
        Dim noicap As String
        Dim thuongtru As String
        Dim nharieng As String
        Dim didong As String
        Dim honnhan As Integer
        Dim socon As Integer
        Dim BSHS As Integer
        Dim diachi As String
        Dim quoctich As String
        Dim dantoc As String
        Dim tongiao As String
        Dim hocvan As String
        Dim ngoaingu As String
        Dim chuyenmon As String
        Dim tinhoc As String
        Dim congviec As String
        Dim chucvu As String
        Dim quanhuyen As String
        Dim tinhthanh As String
        Dim ndbs As String
        Dim dangvien1 As Integer
        Dim noivao As String
        Dim tnvn As Integer
        Dim tdct As String
        soCMND = Me.txtSoCMND.Text
        If Me.txtSoCMND.TextLength = 9 Or Me.txtSoCMND.TextLength = 12 Then

            obj.ChonBang = 16
            Dim Temp3 As New DataTable
            Me.b = New clsBKiemTraCMND
            obj.Table = "ST_NHANVIEN"
            Temp3 = Nothing
            obj.SoCMND = Me.txtSoCMND.Text
            If Me.txtSoCMND.Text = "" Then
                'obj.ChonBang = 1
                'Me.b = New clsBKiemTraCMND
                'Me.b.InsertInfo(obj)
                'MessageBox.Show("Đã Lưu Thành Công")
                'Exit Sub
            End If
            Temp3 = Me.b.LoadDS(obj)
            Dim CO As String

            If Temp3.Rows.Count > 0 Then ' co so cm trong bang nhan vien
                ' Kiem tra so cm
                CO = 1 ' CO SO CM
            Else
                CO = 0
            End If
            If CO = 1 Then

                obj.ChonBang = 22
                Dim Temp5 As New DataTable
                Me.b = New clsBKiemTraCMND
                obj.Table = "ST_NHANVIEN"
                Temp5 = Nothing
                obj.SoCMND = Me.txtSoCMND.Text
                Temp5 = Me.b.LoadDS(obj)
                Dim congayvao As Integer
                If Temp5.Rows.Count > 0 Then ' kIEM TRA SO CM DO VOI NGAY GAN DAY NHAT
                    congayvao = 1 ' co so cm trong bang nhan vien voi ngay vao gan day nhat
                Else
                    congayvao = 0
                End If
                If congayvao = 1 Then

                    Dim MANVTEMP As String = Temp5.Rows(0).Item("NV_MA")
                    Dim donvitemp As String = Temp5.Rows(0).Item("DV_MA")
                    Dim socmtemp As String = Temp5.Rows(0).Item("NV_CMND")
                    Dim hotentemp As String = Temp5.Rows(0).Item("NV_Ten")
                    Dim thoiviec As String

                    Dim gioitinhtemp As Boolean
                    If Temp5.Rows(0).Item("NV_THOIVIEC").ToString = Nothing Then
                        thoiviec = False
                    ElseIf Temp5.Rows(0).Item("NV_THOIVIEC") = True Then
                        thoiviec = True
                    Else
                        thoiviec = False
                    End If
                    If Temp5.Rows(0).Item("NV_GioiTinh") = True Then
                        gioitinhtemp = Me.radNam.Checked
                    Else
                        gioitinhtemp = Me.radNu.Checked
                    End If
                    Dim ngaysinh2 As Date
                    ngaysinh2 = Temp5.Rows(0).Item("NV_Ngaysinh")
                    Dim ngaysinhtemp As String = ngaysinh2.Year.ToString() + "/" + ngaysinh2.Month.ToString() + "/" + ngaysinh2.Day.ToString()

                    Dim noicaptemp As String = Temp5.Rows(0).Item("NV_NoiCapCMND")

                    Dim ngaycap2 As Date
                    ngaycap2 = Temp5.Rows(0).Item("NV_NgaycapCMND")
                    Dim ngaycaptemp As String = ngaycap2.Year.ToString() + "/" + ngaycap2.Month.ToString() + "/" + ngaycap2.Day.ToString()

                    Dim qttemp As String
                    Dim dttemp As String
                    Dim tgtemp As String
                    ' Kiem tra gia tri null
                    If Temp5.Rows(0).Item("QT_MA").ToString = Nothing Then
                        qttemp = quoctich
                    Else
                        qttemp = Temp5.Rows(0).Item("QT_MA")
                    End If
                    If Temp5.Rows(0).Item("DT_MA").ToString = Nothing Then
                        dttemp = dantoc
                    Else
                        dttemp = Temp5.Rows(0).Item("DT_MA")
                    End If
                    If Temp5.Rows(0).Item("TG_MA").ToString = Nothing Then
                        tgtemp = tongiao
                    Else
                        tgtemp = Temp5.Rows(0).Item("TG_MA")
                    End If

                    If soCMND = socmtemp Then ' kIEM TRA SO CM TRONG BANG NHAN VIEN
                        If donvitemp = "NV" Or donvitemp = "NV01" Or donvitemp = "T" Or donvitemp = "T01" Or donvitemp = "T02" Or donvitemp = "T03" Or thoiviec = True Then 'Kiem tra so cm
                            ' Neu nhan vien do da co di lam va nghi viec thi hien thong tin cua nhan vien do len
                            Me.txtHoten.Text = Temp5.Rows(0).Item("NV_Ten")
                            If Temp5.Rows(0).Item("NV_MaTu").ToString = "" Then
                                Me.txtMatu.Text = ""
                            Else
                                Me.txtMatu.Text = Temp5.Rows(0).Item("NV_MaTu")
                            End If

                            Me.cbDonvi.Text = Temp5.Rows(0).Item("DV_MA")
                            If Temp5.Rows(0).Item("NV_GioiTinh") = True Then
                                Me.radNam.Checked = True
                            Else
                                Me.radNu.Checked = True
                            End If
                            If Temp5.Rows(0).Item("NV_Ngaysinh").ToString = Nothing Then
                                Me.dtpNgaysinh.Text = ""
                            Else
                                Me.dtpNgaysinh.Text = Temp5.Rows(0).Item("NV_Ngaysinh")
                            End If

                            Me.txtSoCMND.Text = Temp5.Rows(0).Item("NV_CMND")
                            Me.txtNoicap.Text = Temp5.Rows(0).Item("NV_NoiCapCMND")

                            If Temp5.Rows(0).Item("NV_NgaycapCMND").ToString = Nothing Then
                                Me.dtpNgayCap.Text = ""
                            Else
                                Me.dtpNgayCap.Text = Temp5.Rows(0).Item("NV_NgaycapCMND")
                            End If

                            Me.txtDiachi.Text = Temp5.Rows(0).Item("NV_DiaChi")
                            Me.txtThuongtru.Text = Temp5.Rows(0).Item("NV_Thuongtru")
                            Me.txtdtnharieng.Text = Temp5.Rows(0).Item("NV_DTNhaRieng")
                            Me.txtdtdidong.Text = Temp5.Rows(0).Item("NV_DTDiDong")
                            If Temp5.Rows(0).Item("NV_Socon").ToString = Nothing Then
                                Me.txtSocon.Text = 0
                            Else
                                Me.txtSocon.Text = Temp5.Rows(0).Item("NV_Socon")
                            End If

                            If Temp5.Rows(0).Item("BSHS").ToString = Nothing Then
                                Me.txtLanBSHS.Text = 0
                            Else
                                Me.txtLanBSHS.Text = Temp5.Rows(0).Item("BSHS")
                            End If
                            Me.cboQuoctich.Value = Temp5.Rows(0).Item("QT_MA")
                            Me.cboDantoc.Value = Temp5.Rows(0).Item("DT_MA")
                            Me.cboTongiao.Value = Temp5.Rows(0).Item("TG_MA")
                            Me.cboTinhThanh.Value = Temp5.Rows(0).Item("TT_Ma")
                            Me.cboHocvan.Value = Temp5.Rows(0).Item("HV_MA")
                            Me.cboQuanHuyen.Value = Temp5.Rows(0).Item("QH_MA")
                            Me.cboChuyenMon.Value = Temp5.Rows(0).Item("CM_MA")
                            Me.cboNgoaingu.Value = Temp5.Rows(0).Item("NN_MA")
                            Me.cboTinhoc.Value = Temp5.Rows(0).Item("TH_MA")
                            Me.cboCongViec.Value = Temp5.Rows(0).Item("CV_MA")
                            Me.cboChucVu.Value = Temp5.Rows(0).Item("CVU_MA")
                            If Temp5.Rows(0).Item("NV_Ngayvao").ToString = Nothing Then
                                Me.dtpNgayvao.Text = ""
                            Else
                                Me.dtpNgayvao.Text = Temp5.Rows(0).Item("NV_Ngayvao")
                            End If
                            If Temp5.Rows(0).Item("NV_Ngaybonhiem").ToString = Nothing Then
                                Me.dtpNgaybonhiem.Text = ""
                            Else
                                Me.dtpNgaybonhiem.Text = Temp5.Rows(0).Item("NV_Ngaybonhiem")
                            End If
                            If Temp5.Rows(0).Item("NV_NgayTV").ToString = Nothing Then
                                Me.dtpNgayThoiViec.Text = ""
                            Else
                                Me.dtpNgayThoiViec.Text = Temp5.Rows(0).Item("NV_NGAYTV")
                            End If
                            Me.txtLoaiThoiViec.Text = Temp5.Rows(0).Item("LTV_MA").ToString
                            If Temp5.Rows(0).Item("NV_THOIVIEC").ToString = Nothing Then
                                Me.radDiLam.Checked = True
                            ElseIf Temp5.Rows(0).Item("NV_THOIVIEC") = True Then
                                Me.radThoiViec.Checked = True
                            Else
                                Me.radDiLam.Checked = True
                            End If
                            If Temp5.Rows(0).Item("NV_Honnhan").ToString = Nothing Then
                                Me.radChua.Checked = True
                            ElseIf Temp5.Rows(0).Item("NV_Honnhan") = True Then
                                Me.radCo.Checked = True
                            Else
                                Me.radChua.Checked = True
                            End If

                            Me.dtpNgayThoiViec.Enabled = True
                            Me.txtLoaiThoiViec.Enabled = True

                            ' NEU thang nghi viec cua so chung minh nay LON HON 6 MOI CHO LAM
                            Dim sthang As Integer
                            sthang = Temp5.Rows(0).Item("SOTHANG")
                            If sthang >= 6 Then
                                If Temp5.Rows(0).Item("LTV_MA").ToString = "HHHD" Then
                                    obj.ChonBang = 24
                                    Dim Temp4 As New DataTable
                                    Me.b = New clsBKiemTraCMND
                                    obj.Table = "ST_NHANVIEN"
                                    Temp4 = Nothing
                                    Temp4 = Me.b.LoadDS(obj)
                                    Dim SOLAN As Integer
                                    Dim loaithoiviec As String
                                    Dim j As Integer = 0
                                    Dim num As Integer = Temp4.Rows.Count
                                    While (j <= num - 1) ' LAY SO LAN CUA TUNG LOAI THOI VIEC TRONG BANG TAM
                                        If Temp4.Rows(j).Item("TV_LYDO").ToString = "HHHD" Then
                                            SOLAN = Temp4.Rows(j).Item("LTV_MA")
                                            loaithoiviec = Temp4.Rows(j).Item("TV_LYDO")
                                            If SOLAN <= 2 And loaithoiviec = "HHHD" Then
                                                'If (MessageBox.Show(("Số CMND này đã hết hạn hợp đồng nhỏ hơn 2 lần, bạn có muốn thêm không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                                '    'obj.ChonBang = 1
                                                '    'Me.b = New clsBKiemTraCMND
                                                '    'Me.b.InsertInfo(obj)
                                                MessageBox.Show("Số CMND này đã hết hạn hợp đồng nhỏ hơn 2 lần, có thể tuyển")
                                                'Else
                                                '    Exit Sub
                                                'End If
                                            ElseIf SOLAN > 2 Then
                                                MessageBox.Show("Số CMND này đã hết hạn hợp đồng hơn 2 lần, Không tuyển")
                                                Exit Sub
                                            End If
                                        End If
                                        j = j + 1
                                    End While


                                ElseIf Temp5.Rows(0).Item("LTV_MA").ToString = "BV" Then
                                    obj.ChonBang = 25
                                    Dim Temp4 As New DataTable
                                    Me.b = New clsBKiemTraCMND
                                    obj.Table = "ST_NHANVIEN"
                                    Temp4 = Nothing
                                    Temp4 = Me.b.LoadDS(obj)
                                    Dim SOLAN As Integer
                                    Dim loaitv As String

                                    Dim j2 As Integer = 0
                                    Dim num2 As Integer = Temp4.Rows.Count
                                    While (j2 <= num2 - 1)
                                        If Temp4.Rows(j2).Item("TV_LYDO").ToString = "BV" Then
                                            SOLAN = Temp4.Rows(j2).Item("LTV_MA")
                                            loaitv = Temp4.Rows(j2).Item("TV_LYDO")
                                            If SOLAN <= 1 And loaitv = "BV" Then
                                                'If (MessageBox.Show(("Số CMND này đã bỏ việc 1 lần, bạn có muốn thêm không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                                '    'obj.ChonBang = 1
                                                '    'Me.b = New clsBKiemTraCMND
                                                '    'Me.b.InsertInfo(obj)
                                                MessageBox.Show("Số CMND này đã bỏ việc 1 lần, có thể tuyển")
                                                'Else
                                                '    Exit Sub
                                                'End If
                                            ElseIf SOLAN > 1 Then
                                                MessageBox.Show("Số CMND này đã bỏ việc hơn 1 lần, Không tuyển")
                                                Exit Sub
                                            End If
                                        End If
                                        j2 = j2 + 1
                                    End While
                                    'so den
                                ElseIf Temp5.Rows(0).Item("LTV_MA").ToString = "SD" Then
                                    MessageBox.Show("Số CMND này đã vào sổ đen, Không tuyển")
                                    Exit Sub
                                Else
                                    obj.ChonBang = 26
                                    Dim Temp4 As New DataTable
                                    Me.b = New clsBKiemTraCMND
                                    obj.Table = "ST_NHANVIEN"
                                    Temp4 = Nothing
                                    Temp4 = Me.b.LoadDS(obj)
                                    Dim sothang As Integer
                                    sothang = Temp4.Rows(0).Item("NV_NGAYTHOIVIEC")
                                    If sothang >= 6 Then
                                        'If (MessageBox.Show(("Số CMND này đã nghỉ việc hơn 6 tháng, bạn có muốn thêm không?"), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                                        '    'obj.ChonBang = 1
                                        '    'Me.b = New clsBKiemTraCMND
                                        '    'Me.b.InsertInfo(obj)
                                        MessageBox.Show("Số CMND này đã nghỉ việc hơn 6 tháng, có thể tuyển")
                                        'Else
                                        '    Exit Sub
                                        'End If

                                    ElseIf sothang < 6 Then
                                        MessageBox.Show("Số CMND này nghỉ chưa đủ 6 tháng, Không tuyển")
                                        Exit Sub
                                    End If
                                End If
                            ElseIf Temp5.Rows(0).Item("LTV_MA").ToString = "BV" Then
                                MessageBox.Show("Số CMND này nghỉ chưa đủ 6 tháng, Không tuyển")
                                Exit Sub
                            ElseIf Temp5.Rows(0).Item("LTV_MA").ToString = "HHHD" Then
                                MessageBox.Show("Số CMND này nghỉ chưa đủ 6 tháng, Không tuyển")
                                Exit Sub
                            ElseIf Temp5.Rows(0).Item("LTV_MA").ToString = "CTV" Then
                                MessageBox.Show("Số CMND này nghỉ chưa đủ 6 tháng, Không tuyển")
                                Exit Sub
                            ElseIf Temp5.Rows(0).Item("LTV_MA").ToString = "SD" Then
                                MessageBox.Show("Số CMND này đã vào sổ đen, Không tuyển")
                                Exit Sub
                            End If

                        ElseIf donvitemp <> "NV" And donvitemp <> "NV01" Or donvitemp <> "T" Or donvitemp <> "T01" Or donvitemp <> "T02" Or donvitemp <> "T03" Or thoiviec = False Then
                            Me.TrangThaiThemMoi1()
                            MessageBox.Show("Số CMND này đang làm việc tại công ty.", "Thông báo", MessageBoxButtons.OK)
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf CO = 0 Then
                'MessageBox.Show("Số CMND này chưa có trong bảng nhân viên")
                Exit Sub
            End If
        ElseIf Me.txtSoCMND.Text = "" Then
            Me.TrangThaiThemMoi()
        End If


    End Sub
    Public Sub TrangThaiThemMoi()
        Me.txtHoten.Clear()
        Me.txtNDBS.Clear()
        Me.txtLanBSHS.Text = 0
        Me.txtMatu.Clear()
        Me.cbDonvi.Clear()
        Me.txtSoCMND.Clear()
        Me.txtNoicap.Clear()
        Me.dtpNgayCap.Text = Now
        Me.dtpNgaysinh.Text = Now
        Me.txtDiachi.Clear()
        Me.txtThuongtru.Clear()
        Me.txtdtnharieng.Clear()
        Me.txtdtdidong.Clear()
        Me.txtSocon.Text = 0
        Me.cboQuoctich.Clear()
        Me.cboDantoc.Clear()
        Me.cboTongiao.Clear()
        Me.cboTinhThanh.Clear()
        Me.cboHocvan.Clear()
        Me.cboQuanHuyen.Clear()
        Me.cboChuyenMon.Value = ""
        Me.cboNgoaingu.Clear()
        Me.cboCongViec.Clear()
        Me.cboTinhoc.Clear()
        Me.cboChucVu.Value = ""
        Me.dtpNgayvao.Text = Now
        Me.dtpNgayKHD.Value = Nothing
        Me.dtpNgayKHD.Enabled = False
        Me.dtpNgayThoiViec.Value = Nothing
        Me.txtMucLuong.Clear()
        Me.dtpNgaybonhiem.Text = Now
        Me.radThoiViec.Enabled = False
        Me.txtLoaiThoiViec.Enabled = False
        Me.dtpNgaycapdang.Enabled = False
        Me.txtNoivao.Enabled = False
        Me.dtpNgaycapdang.Value = Nothing
        Me.chkDangvien.Checked = False
        Me.chkTNVN.Checked = False
        Me.cbTDCT.Enabled = False
    End Sub
    Public Sub TrangThaiThemMoi1()
        Me.txtHoten.Clear()
        Me.txtNDBS.Clear()
        Me.txtLanBSHS.Text = 0
        Me.txtMatu.Clear()
        Me.cbDonvi.Clear()
        Me.txtNoicap.Clear()
        Me.dtpNgayCap.Text = Now
        Me.dtpNgaysinh.Text = Now
        Me.txtDiachi.Clear()
        Me.txtThuongtru.Clear()
        Me.txtdtnharieng.Clear()
        Me.txtdtdidong.Clear()
        Me.txtSocon.Text = 0
        Me.cboQuoctich.Clear()
        Me.cboDantoc.Clear()
        Me.cboTongiao.Clear()
        Me.cboTinhThanh.Clear()
        Me.cboHocvan.Clear()
        Me.cboQuanHuyen.Clear()
        Me.cboChuyenMon.Value = ""
        Me.cboNgoaingu.Clear()
        Me.cboCongViec.Clear()
        Me.cboTinhoc.Clear()
        Me.cboChucVu.Value = ""
        Me.dtpNgayvao.Text = Now
        Me.dtpNgayKHD.Value = Nothing
        Me.dtpNgayKHD.Enabled = False
        Me.dtpNgayThoiViec.Value = Nothing
        Me.txtMucLuong.Clear()
        Me.dtpNgaybonhiem.Text = Now
        Me.radThoiViec.Enabled = False
        Me.txtLoaiThoiViec.Enabled = False
        Me.dtpNgaycapdang.Enabled = False
        Me.txtNoivao.Enabled = False
        Me.dtpNgaycapdang.Value = Nothing
        Me.chkDangvien.Checked = False
        Me.chkTNVN.Checked = False
        Me.cbTDCT.Enabled = False
    End Sub
    'Bien
    Dim oldRow As Integer = 0
    Dim flag As Boolean
    Dim obj As New objKiemTraCMND
    Dim Table As String
    Dim Path As String
    Dim ReportID As String
    Friend WithEvents d As clsDKiemTraCMND    ' Nested Types
    Friend WithEvents b As clsBKiemTraCMND
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
End Class