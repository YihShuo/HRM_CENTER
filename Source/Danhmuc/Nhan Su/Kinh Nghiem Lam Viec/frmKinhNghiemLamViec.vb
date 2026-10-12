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
Imports System.Configuration
Public Class frmKinhNghiemLamViec
    Dim Table As String
    Dim Tabletemp1 As DataTable
    Dim Tabletemp2 As DataTable
    Dim Tabletemp3 As DataTable
    Dim Flag As Boolean = False
    Dim obj As New objKinhNghiemLamViec
    Friend WithEvents d As clsDKinhNghiemLamViec    ' Nested Types
    Friend WithEvents b As clsBKinhNghiemLamViec
    Private Sub frmKinhNghiemLamViec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBKinhNghiemLamViec
        Me.cbTinh1.DataSource = Me.b.LoadDS(obj)
        Me.cbTinh1.DisplayMember() = "TT_Ten"
        Me.cbTinh1.ValueMember() = "TT_Ma"
        Me.cbTinh1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBKinhNghiemLamViec
        Me.cboTinh2.DataSource = Me.b.LoadDS(obj)
        Me.cboTinh2.DisplayMember() = "TT_Ten"
        Me.cboTinh2.ValueMember() = "TT_Ma"
        Me.cboTinh2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest

        obj.ChonBang = 1
        'Load Don Vi
        Me.b = New clsBKinhNghiemLamViec
        Me.cbTinh3.DataSource = Me.b.LoadDS(obj)
        Me.cbTinh3.DisplayMember() = "TT_Ten"
        Me.cbTinh3.ValueMember() = "TT_Ma"
        Me.cbTinh3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest


        
        obj.ChonBang = 5
        'Load Don Vi
        Me.b = New clsBKinhNghiemLamViec
        Me.Tabletemp1 = Me.b.LoadDS(obj)
        Me.Tabletemp1.Rows.Add("", " ")
        Me.cbLydo1.DataSource = Me.Tabletemp1
        Me.cbLydo1.DisplayMember() = "LTV_Ten"
        Me.cbLydo1.ValueMember() = "LTV_Ma"
        Me.cbLydo1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cbLydo1.Value = ""


        obj.ChonBang = 5
        'Load Don Vi
        Me.b = New clsBKinhNghiemLamViec
        Me.Tabletemp2 = Me.b.LoadDS(obj)
        Me.Tabletemp2.Rows.Add("", " ")
        Me.cbLydo2.DataSource = Me.Tabletemp2
        Me.cbLydo2.DisplayMember() = "LTV_Ten"
        Me.cbLydo2.ValueMember() = "LTV_Ma"
        Me.cbLydo2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cbLydo2.Value = ""
        obj.ChonBang = 5
        'Load Don Vi
        Me.b = New clsBKinhNghiemLamViec
        Me.Tabletemp3 = Me.b.LoadDS(obj)
        Me.Tabletemp3.Rows.Add("", " ")
        Me.cbLydo3.DataSource = Me.Tabletemp3
        Me.cbLydo3.DisplayMember() = "LTV_Ten"
        Me.cbLydo3.ValueMember() = "LTV_Ma"
        Me.cbLydo3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cbLydo3.Value = ""
        methodLoad()
    End Sub
    Dim bNamSinh As Boolean = False
    Dim bNamSinhQH As Boolean = False
    '' biến toàn cục tách chuỗi ngày tháng năm từ lưới (đã định dạng thành ngày/tháng/năm; kiểu chuỗi) (khi định dạng ngày trên máy không đúng kiểu dd/MM/yyyy)
    Dim ngaythangnam, ngaythang, ngay, thang, nam, tungay As String
    Private Function DoiDinhDangNgay(ByVal sNgay As String) As String
        Dim chuoingay As String = ""
        Dim kieu_phancachngay As String = "-"
        If sNgay <> "" Then
            ngaythangnam = sNgay
            ngaythang = ngaythangnam.Substring(0, ngaythangnam.LastIndexOf("-"))

            ngay = ngaythang.Substring(0, ngaythang.LastIndexOf("-"))
            thang = ngaythang.Substring(ngaythang.LastIndexOf("-") + 1)
            nam = ngaythangnam.Substring(ngaythangnam.LastIndexOf("-") + 1)
            chuoingay = nam + "-" + thang + "-" + ngay
        End If
        Return chuoingay
    End Function
    Private Sub txtManvTab2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManvTab2.ValueChanged
        Dim ngaysinhNV As String ''======= ngày sinh format định dạng khi sai ngày trong máy người dùng
        Dim dNgaysinhNV As Date
        If txtManvTab2.TextLength = 6 Then
            ''================
            obj.Setnull()

            obj.ChonBang = 2
            Dim Temp2 As New DataTable
            Me.b = New clsBKinhNghiemLamViec
            obj.Table = "ST_NHANVIEN"
            Temp2 = Nothing
            obj.NV_MA = Me.txtManvTab2.Text
            Temp2 = Me.b.LoadDS(obj)

            If Temp2.Rows.Count > 0 Then

                Me.btXoa.Enabled = True
                Me.btThem.Enabled = True
                Me.btCapNhat.Enabled = False
                Me.txtTenTab2.Text = Temp2.Rows(0).Item(1).ToString()
                Me.dtpNgayVaoTab2.Text = Temp2.Rows(0).Item(2).ToString()
                Me.txtDiachitab2.Text = Temp2.Rows(0).Item(3).ToString()
                Me.txtDVTab2.Text = Temp2.Rows(0).Item(4).ToString()
                Me.txtCVtab2.Text = Temp2.Rows(0).Item(5).ToString()
                Me.txtChucVutab2.Text = Temp2.Rows(0).Item(6).ToString()
                Me.txtchuyenmon.Text = Temp2.Rows(0).Item(7).ToString()
                If IsDBNull(Temp2.Rows(0).Item("NV_NAMSINH")) Then
                    ngaysinhNV = DoiDinhDangNgay(Temp2.Rows(0).Item("NV_NGAYSINH").Value.ToString)
                    dNgaysinhNV = Date.Parse(ngaysinhNV)
                    Me.dtpNgaysinhtab2.Text = dNgaysinhNV
                    dtpNgaysinhtab2.CustomFormat = "dd/MM/yyyy"

                ElseIf Convert.ToBoolean(Temp2.Rows(0).Item("NV_NAMSINH").ToString()) = True Then
                    dNgaysinhNV = Date.Parse(Temp2.Rows(0).Item("NV_NGAYSINHTT").ToString())
                    ngaysinhNV = dNgaysinhNV.Year.ToString()
                    Me.dtpNgaysinhtab2.Text = dNgaysinhNV
                    dtpNgaysinhtab2.CustomFormat = "yyyy"
                Else
                    ngaysinhNV = DoiDinhDangNgay(Temp2.Rows(0).Item("NV_NGAYSINH").ToString)
                    dNgaysinhNV = Date.Parse(ngaysinhNV)
                    Me.dtpNgaysinhtab2.Text = dNgaysinhNV
                    dtpNgaysinhtab2.CustomFormat = "dd/MM/yyyy"
                End If
                Me.dtpNgaykyHD.Text = Temp2.Rows(0).Item("NV_NGAYKHD").ToString()
                Me.txtMucluongtab2.Text = Temp2.Rows(0).Item("HD_LUONGCB").ToString()
                Me.txtTenTab2.ReadOnly = True
                Me.dtpNgayVaoTab2.ReadOnly = True
                Me.txtDiachitab2.ReadOnly = True
                Me.txtDVTab2.ReadOnly = True
                Me.txtCVtab2.ReadOnly = True
                Me.txtChucVutab2.ReadOnly = True
                Me.txtchuyenmon.ReadOnly = True
                Me.dtpNgaysinhtab2.Enabled = False
                Me.dtpNgaykyHD.ReadOnly = True
                Me.txtMucluongtab2.ReadOnly = True
                Me.GroupBox1.Enabled = True '
                Me.btXoa.Enabled = False
                'methodLoad()
            End If
        End If
        'End Select
    End Sub
    Dim Path As String
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim b As New clsBKinhNghiemLamViec
        Me.Path = "/layout/KinhNghiemLamViec.xml"
        obj.Setnull()
        obj.ChonBang = 4
        'obj.NV_MA = Me.txtManvTab2.Text.Trim()
        Me.dgrBC.DataSource = Nothing
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path), typeControl.Grid, "coldgrhoso")

    End Sub
    Public Sub LuuDuLieu()
        Dim ma As String
        Dim tencty1 As String
        Dim tinh1 As String
        Dim tunam1 As String
        Dim dennam1 As String
        Dim cv1 As String
        Dim lydo1 As String

        Dim tencty2 As String
        Dim tinh2 As String
        Dim tunam2 As String
        Dim dennam2 As String
        Dim cv2 As String
        Dim lydo2 As String

        Dim tencty3 As String
        Dim tinh3 As String
        Dim tunam3 As String
        Dim dennam3 As String
        Dim cv3 As String
        Dim lydo3 As String
        obj.Setnull()
        If Me.txtManvTab2.Text = "" Then
            MessageBox.Show("Chưa nhập số thẻ", "Thông Báo", MessageBoxButtons.OK)
            Me.txtManvTab2.Focus()
            Exit Sub
        End If
        obj.NV_MA = Me.txtManvTab2.Text
        If Me.txtTenCongTy1.Text = "" Then
            obj.KNLV_TENCONGTY1 = ""
        Else
            obj.KNLV_TENCONGTY1 = Me.txtTenCongTy1.Text
        End If
        If Me.cbTinh1.Value = "" Then
            obj.KNLV_TINH1 = ""
        Else
            obj.KNLV_TINH1 = Me.cbTinh1.Value
        End If
        If Me.txtTuNam1.Text = "" Then
            obj.KNLV_TUNAM1 = ""
        Else
            obj.KNLV_TUNAM1 = Me.txtTuNam1.Text
        End If
        If Me.txtDenNam1.Text = "" Then
            obj.KNLV_DENNAM1 = ""
        Else
            obj.KNLV_DENNAM1 = Me.txtDenNam1.Text
        End If
        If Me.txtCongViec1.Text = "" Then
            obj.KNLV_CV1 = ""
        Else
            obj.KNLV_CV1 = Me.txtCongViec1.Text
        End If
        If Me.cbLydo1.Text = "" Then
            obj.KNLV_LYDOTHOIVIEC1 = ""
        Else
            obj.KNLV_LYDOTHOIVIEC1 = Me.cbLydo1.Value
        End If
        If Me.txtTenCongTy2.Text = "" Then
            obj.KNLV_TENCONGTY2 = ""
        Else
            obj.KNLV_TENCONGTY2 = Me.txtTenCongTy2.Text
        End If

        If Me.cboTinh2.Value = "" Then
            obj.KNLV_TINH2 = ""
        Else
            obj.KNLV_TINH2 = Me.cboTinh2.Value
        End If

        If Me.txtTuNam2.Text = "" Then
            obj.KNLV_TUNAM2 = ""
        Else
            obj.KNLV_TUNAM2 = Me.txtTuNam2.Text
        End If
        If Me.txtDenNam2.Text = "" Then
            obj.KNLV_DENNAM2 = ""
        Else
            obj.KNLV_DENNAM2 = Me.txtDenNam2.Text
        End If
        If Me.txtCongViec2.Text = "" Then
            obj.KNLV_CV2 = ""
        Else
            obj.KNLV_CV2 = Me.txtCongViec2.Text
        End If
        If Me.cbLydo2.Text = "" Then
            obj.KNLV_LYDOTHOIVIEC2 = ""
        Else
            obj.KNLV_LYDOTHOIVIEC2 = Me.cbLydo2.Value
        End If

        If Me.txtTenCongTy3.Text = "" Then
            obj.KNLV_TENCONGTY3 = ""
        Else
            obj.KNLV_TENCONGTY3 = Me.txtTenCongTy3.Text
        End If

        If Me.cbTinh3.Value = "" Then
            obj.KNLV_TINH3 = ""
        Else
            obj.KNLV_TINH3 = Me.cbTinh3.Value
        End If

        If Me.txtTuNam3.Text = "" Then
            obj.KNLV_TUNAM3 = ""
        Else
            obj.KNLV_TUNAM3 = Me.txtTuNam3.Text
        End If
        If Me.txtDenNam3.Text = "" Then
            obj.KNLV_DENNAM3 = ""
        Else
            obj.KNLV_DENNAM3 = Me.txtDenNam3.Text
        End If
        If Me.txtCongViec3.Text = "" Then
            obj.KNLV_CV3 = ""
        Else
            obj.KNLV_CV3 = Me.txtCongViec3.Text
        End If
        If Me.cbLydo3.Text = "" Then
            obj.KNLV_LYDOTHOIVIEC3 = ""
        Else
            obj.KNLV_LYDOTHOIVIEC3 = Me.cbLydo3.Value
        End If
        obj.setvalue(obj.NV_MA, obj.KNLV_TENCONGTY1, obj.KNLV_TINH1, obj.KNLV_TUNAM1, obj.KNLV_DENNAM1, obj.KNLV_CV1, obj.KNLV_LYDOTHOIVIEC1, obj.KNLV_TENCONGTY2, obj.KNLV_TINH2, obj.KNLV_TUNAM2, obj.KNLV_DENNAM2, obj.KNLV_CV2, obj.KNLV_LYDOTHOIVIEC2, obj.KNLV_TENCONGTY3, obj.KNLV_TINH3, obj.KNLV_TUNAM3, obj.KNLV_DENNAM3, obj.KNLV_CV3, obj.KNLV_LYDOTHOIVIEC3, 0)


        If Flag = True Then
            obj.ChonBang = 3
            Dim Temp As New DataTable
            Me.b = New clsBKinhNghiemLamViec
            Temp = Nothing
            obj.NV_MA = Me.txtManvTab2.Text
            Temp = Me.b.LoadDS(obj)
            If Temp.Rows.Count > 0 Then
                MessageBox.Show("Nhân viên này đã có kinh nghiệm làm việc")
                Exit Sub
            Else
                obj.ChonBang = 1
                Me.b = New clsBKinhNghiemLamViec
                If Me.b.InsertInfo(obj) Then
                    MessageBox.Show("Đã Lưu Thành Công")
                Else
                    MessageBox.Show("Không thể thêm.")
                End If
            End If
        Else
           
            obj.ChonBang = 1
            Me.b = New clsBKinhNghiemLamViec
            If Me.b.UpdateInfo(obj) Then
                MessageBox.Show("Đã Lưu Thành Công")
            Else
                MessageBox.Show("Không thể sửa")
            End If
        End If

        Me.methodLoad()

    End Sub
    Private Sub btThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btThem.Activate
        Flag = True
        LuuDuLieu()
    End Sub

    Private Sub txtTuNam1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTuNam1.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtDenNam1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDenNam1.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtTuNam2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTuNam2.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtDenNam2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDenNam2.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtTuNam3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTuNam3.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtDenNam3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDenNam3.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 46 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        Dim i As Integer

        For i = 0 To e.Layout.Bands(0).Columns.Count - 1
            e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
        Next
    End Sub
    Public Sub TrangThaiThemMoi()
        Me.txtTenCongTy1.Clear()
        Me.cbTinh1.Clear()
        Me.txtTuNam1.Clear()
        Me.txtDenNam1.Clear()
        Me.txtCongViec1.Clear()
        Me.cbLydo1.Clear()

        Me.txtTenCongTy2.Clear()
        Me.cboTinh2.Clear()
        Me.txtTuNam2.Clear()
        Me.txtDenNam2.Clear()
        Me.txtCongViec2.Clear()
        Me.cbLydo2.Clear()

        Me.txtTenCongTy3.Clear()
        Me.cbTinh3.Clear()
        Me.txtTuNam3.Clear()
        Me.txtDenNam3.Clear()
        Me.txtCongViec3.Clear()
        Me.cbLydo3.Clear()

        Me.btThem.Enabled = True
        Me.btCapNhat.Enabled = False
        Me.btXoa.Enabled = False
       
        'End Select
    End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        Me.TrangThaiThemMoi()
        Me.btCapNhat.Enabled = False
        Me.btThem.Enabled = True
        Me.btXoa.Enabled = False
    End Sub
    Dim ma As String
    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                ''========= lay so the co nhan than vua chon ========''
                ma = activeRow.Cells.Item("NV_MA").Value.ToString
                Me.txtTenCongTy1.Text = activeRow.Cells.Item("KNLV_TENCONGTY1").Value.ToString
                Me.cbTinh1.Value = activeRow.Cells.Item("KNLV_TINH1").Value.ToString
                Me.txtTuNam1.Text = activeRow.Cells.Item("KNLV_TUNAM1").Value.ToString
                Me.txtDenNam1.Text = activeRow.Cells.Item("KNLV_DENNAM1").Value.ToString
                Me.txtCongViec1.Text = activeRow.Cells.Item("KNLV_CV1").Value.ToString
                Me.cbLydo1.Value = activeRow.Cells.Item("KNLV_LYDOTHOIVIEC1").Value.ToString


                Me.txtTenCongTy2.Text = activeRow.Cells.Item("KNLV_TENCONGTY2").Value.ToString
                Me.cboTinh2.Value = activeRow.Cells.Item("KNLV_TINH2").Value.ToString
                Me.txtTuNam2.Text = activeRow.Cells.Item("KNLV_TUNAM2").Value.ToString
                Me.txtDenNam2.Text = activeRow.Cells.Item("KNLV_DENNAM2").Value.ToString
                Me.txtCongViec2.Text = activeRow.Cells.Item("KNLV_CV2").Value.ToString
                Me.cbLydo2.Value = activeRow.Cells.Item("KNLV_LYDOTHOIVIEC2").Value.ToString


                Me.txtTenCongTy3.Text = activeRow.Cells.Item("KNLV_TENCONGTY3").Value.ToString
                Me.cbTinh3.Value = activeRow.Cells.Item("KNLV_TINH3").Value.ToString
                Me.txtTuNam3.Text = activeRow.Cells.Item("KNLV_TUNAM3").Value.ToString
                Me.txtDenNam3.Text = activeRow.Cells.Item("KNLV_DENNAM3").Value.ToString
                Me.txtCongViec3.Text = activeRow.Cells.Item("KNLV_CV3").Value.ToString
                Me.cbLydo3.Value = activeRow.Cells.Item("KNLV_LYDOTHOIVIEC3").Value.ToString
                
            End If

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click
        Me.HieuChinh()
        Me.btCapNhat.Enabled = True
        Me.btThem.Enabled = False
        Me.btXoa.Enabled = True
    End Sub
    Public Sub XoaDuLieu()
        Try
            Dim jFunction As New objKinhNghiemLamViec

            Dim ma As String
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                ma = StringType.FromObject(activeRow.Cells.Item("NV_MA").Value)
                jFunction.NV_MA = ma

                If (MessageBox.Show(("Bạn có muốn xóa kinh nghiệm làm việc của nhân viên: " & ma & "?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    If Me.b.DeleteInfo(jFunction) Then
                        MessageBox.Show("Đã xóa thành công")
                    End If
                End If
            End If
            Me.methodLoad()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Private Sub btCapNhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCapNhat.Activate
        Flag = False
        Me.LuuDuLieu()
        Me.TrangThaiThemMoi()
    End Sub

    Private Sub btXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXoa.Activate
        Me.XoaDuLieu()
        Me.TrangThaiThemMoi()
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class