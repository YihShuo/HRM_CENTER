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
Public Class frmKhoanTruMobivi
    Dim obj As New objKhoanTruMobivi
    Friend WithEvents b As clsBKhoanTruMobivi
    Public Sub New()

        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmKhoanTruMobivi_Load)

        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub
    Private Sub frmKhoanTruMobivi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpNgay.Value = Now
        obj.T_MA = dtpNgay.Text
        Me.methodLoad()
    End Sub
    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBKhoanTruMobivi
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/KhoanTruMobivi.xml"), typeControl.Grid, "coldgrchucvu")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        If Me.dgrBC.Rows.Count > 0 Then
            Summary_gird()
        End If


    End Sub

    Private Sub dtpNgay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgay.ValueChanged
        obj.T_MA = Me.dtpNgay.Text
        Me.methodLoad()
    End Sub

    Private Sub btnLayDuLieu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayDuLieu.Click
        Dim Table_Mobivi As New DataTable
        Dim pathFile As String
        Dim wb As Microsoft.Office.Interop.Excel.Workbook
        ''xoa bang tam
        Me.b = New clsBKhoanTruMobivi
        If (MessageBox.Show(("Dữ liệu cũ sẽ bị xóa, bạn có đồng ý lấy dữ liệu không?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.No) Then

            obj.T_MA = dtpNgay.Text
            Me.b.DeleteInfo(obj)
            Me.OpenFile.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
            If Me.OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                pathFile = Me.OpenFile.FileName
            Else
                MessageBox.Show("Chưa chọn đường dẫn file excel!", "Thông báo")
                Exit Sub
            End If
            Dim dbexcel As ADODB.Connection, rsexcel As ADODB.Recordset
            Dim db As ADODB.Connection, rs As ADODB.Recordset
            dbexcel = New ADODB.Connection
            dbexcel.Provider = "Microsoft.Jet.OLEDB.4.0"
            dbexcel.ConnectionString = "Data Source='" + pathFile + "';Extended Properties=Excel 8.0"
            dbexcel.Open()
            rsexcel = New ADODB.Recordset
            rsexcel.Open("select * from [sheet1$]", dbexcel)
            If rsexcel.RecordCount = 0 Then
                MessageBox.Show("Sheet 1 file excel không có dữ liệu!", "Thông báo")
                Exit Sub
            End If

            db = New ADODB.Connection
            db.Provider = "SQLOLEDB.1"
            db.ConnectionString = "Data Source=127.0.0.1;Database=P0104-TYbach;User ID=sa;Password=123"
            ''db.ConnectionString = Application.CommonAppDataPath.ToString()
            db.Open()
            rs = New ADODB.Recordset
            rs.Open("IT_MOBIVI", db, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim tablet As DataTable
            ''=============== khoi tao datatable chua ds khong dung =========================
            Dim column1 As New DataColumn
            Dim column2 As New DataColumn
            Dim column3 As New DataColumn
            Dim column4 As New DataColumn
            Dim column5 As New DataColumn
            Table_Mobivi.Columns.Clear()
            Table_Mobivi.Columns.Add(column1)
            Table_Mobivi.Columns.Add(column2)
            Table_Mobivi.Columns.Add(column3)
            Table_Mobivi.Columns.Add(column4)

            Table_Mobivi.Columns(0).ColumnName = "NV_Ma"
            Table_Mobivi.Columns(1).ColumnName = "T_Ma"
            Table_Mobivi.Columns(2).ColumnName = "MB_SoTien"
            'Table_Mobivi.Columns(3).ColumnName = "MB_Vuot30PT"

            Table_Mobivi.Columns(0).DataType = Type.GetType("System.String")
            Table_Mobivi.Columns(1).DataType = Type.GetType("System.String")
            Table_Mobivi.Columns(2).DataType = Type.GetType("System.Double")
            'Table_Mobivi.Columns(3).DataType = Type.GetType("System.Boolean")
            ''===================================================================================
            While Not rsexcel.EOF
                rs.AddNew()
                rs.Fields("NV_Ma").Value = Trim(rsexcel.Fields("NV_Ma").Value)
                rs.Fields("T_Ma").Value = Trim(rsexcel.Fields("T_Ma").Value)
                If String.IsNullOrEmpty(rsexcel.Fields("MB_SoTien").Value.ToString()) Then
                    rs.Fields("MB_SoTien").Value = 0
                Else
                    rs.Fields("MB_SoTien").Value = Trim(rsexcel.Fields("MB_SoTien").Value)
                End If
                'rs.Fields("MB_Vuot30PT").Value = Trim(rsexcel.Fields("MB_Vuot30PT").Value)
                rs.Update()
                rsexcel.MoveNext()
                i = i + 1
                'End If
            End While
            rsexcel.Close()
            dbexcel.Close()
            'If j = 0 Then
            MessageBox.Show("Đã lấy dữ liệu thành công!", "Thông báo")
            obj.T_MA = dtpNgay.Text
            Me.methodLoad()
        End If
    End Sub
    Private Sub Summary_gird()
        Dim band As UltraGridBand = dgrBC.DisplayLayout.Bands.Item(0)
        Dim columnToSummarize1 As UltraGridColumn = band.Layout.Bands(0).Columns(4)
        Dim summary1 As SummarySettings = band.Layout.Bands(0).Summaries.Add("", SummaryType.Sum, columnToSummarize1)

        Dim columnToSummarize2 As UltraGridColumn = band.Layout.Bands(0).Columns(5)
        Dim summary2 As SummarySettings = band.Layout.Bands(0).Summaries.Add("", SummaryType.Sum, columnToSummarize2)

        band = Nothing
    End Sub

    Private Sub dgrBC_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgrBC.InitializeLayout
        e.Layout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(2).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(3).CellActivation = Activation.NoEdit
        e.Layout.Bands(0).Columns(4).CellActivation = Activation.NoEdit
    End Sub

    Private Sub btnIn_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Activate
        Me.SaveFileDialog1.Filter() = "Excell Files(*.xls)|*.xls|All Files(*.*)|*.*"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            Process.Start(Me.SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub dgrBC_InitializeRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgrBC.InitializeRow
        e.Row.Cells("STT").Value = e.Row.Index + 1
        e.Row.Update()
    End Sub
End Class