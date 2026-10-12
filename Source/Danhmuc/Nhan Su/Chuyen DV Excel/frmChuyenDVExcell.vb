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
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports System.IO

Public Class frmChuyenDVExcell

    Inherits Form
    Dim obj As New objChuyenDVExcel
    Public ThemSua As Integer
    Public dtExcel As New DataTable()
    Public dt As New DataTable()
    'Khai báo biến sử dụng cho hàm xuất/in
    Public para As Object()
    Public issysReport As Boolean
    Dim ReportID As String
    Dim flag As Boolean
    Dim Table As String
    Dim Path2 As String
    Dim Path3 As String
    'Dim pathFile As String
    Public Delegate Sub _errorRaiseEventHandler(ByVal messege As String)
    Friend WithEvents d As ClsDChuyenDV

    ' Methods
    Public Sub New()
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New ClsBChuyenDVExcel
        Me.Path2 = "/layout/ChuyenDVExcell.xml"
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path2), typeControl.Grid, "coldgrtieuchuan")
    End Sub

    Public Sub methodLoad2()
        Dim grid As New clsTformatGrid
        Me.b = New ClsBChuyenDVExcel
        Me.Path3 = "/layout/ChuyenDonVi.xml"
        obj.ChonBang = 4
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & Me.Path3), typeControl.Grid, "coldgrtieuchuan")
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(3).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(4).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(5).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(6).CellActivation = Activation.NoEdit

        Me.dgrBC.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgrBC.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(&HAF, &HF0, &HA0)
        Me.dgrBC.DisplayLayout.Override.SelectedRowAppearance.ForeColor = Color.Blue
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub

    Private Sub txtMa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMa.ValueChanged

    End Sub
    Private Sub UltraLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel1.Click

    End Sub

    Private Sub frmChuyenDVExcell_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.methodLoad()
    End Sub

    Public Function GetConnectionString(ByVal excelFileName As String) As String
        Dim strConnectionString As String = ""
        If Path.GetExtension(excelFileName).ToLower() = ".xlsx" Then
            strConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";", excelFileName)
        ElseIf Path.GetExtension(excelFileName).ToLower() = ".xls" Then
            strConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";", excelFileName)
        End If
        Return (strConnectionString)
    End Function
    Public Sub LoadData(ByVal excelFileName As String)
        dt.Clear()
        Dim cmdText As String = "SELECT * FROM [Sheet1$]"
        Using adapter As New OleDbDataAdapter(cmdText, GetConnectionString(excelFileName))
            adapter.Fill(dt)
        End Using
        Me.dgrBC.DataSource = dt
    End Sub

    Private Sub btd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btd.Click
        Me.dgrBC.DataSource = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = Application.StartupPath
        openFileDialog1.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            LoadData(openFileDialog1.FileName)
            txtMa.Text = openFileDialog1.FileName
        End If

    End Sub

    Private Sub btex_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btex.Activate

        Dim obj As New objChuyenDVExcel
        Me.b = New ClsBChuyenDVExcel
        Dim clsD As New ClsDChuyenDVExcel
        Dim tblTam As DataTable

        If Me.txtMa.Text = "" Then
            MessageBox.Show("Chưa chọn đường dẫn file excel, hoặc file không chứa dữ liệu phù hợp!", "Thông báo")
        Else
            obj.ChonBang = 2
            tblTam = Me.b.LoadDS(obj)

            If tblTam.Rows.Count > 0 Then
                If (MessageBox.Show(("Đã có dữ liệu , xoá dữ liệu cũ và nhập lại?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    ''xoá nếu có dữ liệu cũ
                    Me.b.DeleteInfo(obj)
                    GoTo LuuDL
                Else
                    GoTo Thoat
                End If
            Else
                If (MessageBox.Show(("Bạn muốn lưu dữ liệu từ file excel này ?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then
                    GoTo LuuDL
                Else
                    GoTo Thoat
                End If
            End If
LuuDL:

            Dim constring As String = "Data Source=127.0.0.1;Initial Catalog=P0104-TYBACH;Persist Security Info=True;User ID=sa;Password=123"
            Try
                Using dbConnection As New SqlConnection(constring)
                    dbConnection.Open()
                    Using s As SqlBulkCopy = New SqlBulkCopy(dbConnection)
                        s.DestinationTableName = "tam_chuyendonvi"

                        For Each col As DataColumn In dt.Columns
                            s.ColumnMappings.Add(col.ToString(), col.ToString())
                        Next
                        s.WriteToServer(dt)
                    End Using
                    dbConnection.Close()
                End Using
                MessageBox.Show("Đã insert dữ liệu xong.")
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                Dim exception As Exception = ex
                MessageBox.Show(exception.Message, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
                ProjectData.ClearProjectError()
            End Try
Thoat:
        End If
    End Sub

    Private Sub btcn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcn.Activate
        Dim nguoitao, nguoicapnhat As String
        nguoitao = MAIN.userclient
        nguoicapnhat = MAIN.userclient
        If (MessageBox.Show(("Xác nhận cập nhật đơn vị điều động?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes) Then
            Exit Sub
        Else
            obj.NGAYCD = Now.Year.ToString() + "/" + Now.Month.ToString() + "/01"
            obj.ChonBang = 3
            Dim tba As DataTable
            tba = Me.b.LoadDS(obj)
            If tba.Rows.Count > 0 Then
                MessageBox.Show("Có " & tba.Rows.Count & " người đã được chuyển đơn vị trước đó trong tháng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If (MessageBox.Show(("Bạn có muốn cập nhật đơn vị điều động?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.Yes) Then
                    Exit Sub
                Else
                    obj.ChonBang = 5
                    Dim tbkt As DataTable
                    tbkt = Me.b.LoadDS(obj)
                    If tbkt.Rows.Count > 0 Then
                        MessageBox.Show("Có " & tbkt.Rows.Count & " dòng dữ liệu đã chuyển trong tháng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        If Me.b.InsertInfo(obj, nguoicapnhat) Then
                            obj.ChonBang = 8
                            Me.b.UpdateInfo(obj, nguoicapnhat)
                            MessageBox.Show("Đã cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Không thể cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ButtonItem1_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btx.Activate
        Me.methodLoad2()
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As TD.SandBar.ToolBarItemEventArgs) Handles ToolBar1.ButtonClick

    End Sub

    Private Sub btnexcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexcel.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If (Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
        End If
    End Sub
End Class