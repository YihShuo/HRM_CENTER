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

Public Class frmGioCongVuotQua_Thang
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmQTKhacThuongLC_Thang_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGioCongVuotQua_Thang))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.cbThang = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNam = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.grpDetail = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.tolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btnExcel = New TD.SandBar.ButtonItem
        Me.btnCapnhat = New TD.SandBar.ButtonItem
        Me.btnXem = New TD.SandBar.ButtonItem
        Me.btnXembaocao = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.cbThang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraTabSharedControlsPage1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.ProgressBar1)
        Me.UltraTabPageControl1.Controls.Add(Me.cbThang)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtNam)
        Me.UltraTabPageControl1.Controls.Add(Me.Label3)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(619, 109)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(179, 62)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(348, 19)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 11
        Me.ProgressBar1.Value = 1
        Me.ProgressBar1.Visible = False
        '
        'cbThang
        '
        Me.cbThang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "ValueListItem0"
        ValueListItem1.DisplayText = "01"
        ValueListItem2.DataValue = "ValueListItem1"
        ValueListItem2.DisplayText = "02"
        ValueListItem3.DataValue = "ValueListItem2"
        ValueListItem3.DisplayText = "03"
        ValueListItem4.DataValue = "ValueListItem3"
        ValueListItem4.DisplayText = "04"
        ValueListItem5.DataValue = "ValueListItem4"
        ValueListItem5.DisplayText = "05"
        ValueListItem6.DataValue = "ValueListItem5"
        ValueListItem6.DisplayText = "06"
        ValueListItem7.DataValue = "ValueListItem6"
        ValueListItem7.DisplayText = "07"
        ValueListItem8.DataValue = "ValueListItem7"
        ValueListItem8.DisplayText = "08"
        ValueListItem9.DataValue = "ValueListItem8"
        ValueListItem9.DisplayText = "09"
        ValueListItem10.DataValue = "ValueListItem9"
        ValueListItem10.DisplayText = "10"
        ValueListItem11.DataValue = "ValueListItem10"
        ValueListItem11.DisplayText = "11"
        ValueListItem12.DataValue = "ValueListItem11"
        ValueListItem12.DisplayText = "12"
        Me.cbThang.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12})
        Me.cbThang.Location = New System.Drawing.Point(73, 18)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(39, 21)
        Me.cbThang.TabIndex = 9
        Me.cbThang.Text = "01"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tháng :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNam
        '
        Me.txtNam.AcceptsReturn = True
        Me.txtNam.Enabled = False
        Me.txtNam.Location = New System.Drawing.Point(179, 18)
        Me.txtNam.MaxLength = 100
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(39, 21)
        Me.txtNam.TabIndex = 8
        Me.txtNam.Text = "2009"
        Me.tolTip.SetToolTip(Me.txtNam, "Nơi trả lương")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(136, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Năm :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(629, 160)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 25)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(629, 135)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.txtNam, Me.Label3})
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(623, 132)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Chi tiết giờ công vượt quá"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.txtNam)
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.Label3)
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(619, 109)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(629, 25)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thống kê giờ công vượt quá trong tháng"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "0.add.ico")
        Me.ImageList1.Images.SetKeyName(1, "1.xoa.ico")
        Me.ImageList1.Images.SetKeyName(2, "2.note.ico")
        Me.ImageList1.Images.SetKeyName(3, "3.PRINTER.ico")
        Me.ImageList1.Images.SetKeyName(4, "4.save.ico")
        Me.ImageList1.Images.SetKeyName(5, "5.a91.ico")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "")
        Me.ImageList1.Images.SetKeyName(10, "")
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 168)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(629, 215)
        Me.pnlList.TabIndex = 13
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 64)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(629, 151)
        Me.dgrBC.TabIndex = 1
        Me.dgrBC.Text = "UltraGrid1"
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(629, 64)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnExcel, Me.btnCapnhat, Me.btnXem, Me.btnXembaocao})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(629, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnExcel
        '
        Me.btnExcel.ImageIndex = 7
        Me.btnExcel.Text = "Excel"
        '
        'btnCapnhat
        '
        Me.btnCapnhat.ImageIndex = 2
        Me.btnCapnhat.Text = "Cập Nhật"
        '
        'btnXem
        '
        Me.btnXem.ImageIndex = 6
        Me.btnXem.Text = "Xem"
        '
        'btnXembaocao
        '
        Me.btnXembaocao.ImageIndex = 3
        Me.btnXembaocao.Text = "Xem Báo Cáo"
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(629, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh mục chi tiết giờ công vượt quá"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(635, 386)
        Me.UltraGroupBox1.TabIndex = 14
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 160)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'frmGioCongVuotQua_Thang
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(635, 386)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmGioCongVuotQua_Thang"
        Me.Text = "Thong ke gio cong vuot qua trong thang"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.cbThang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.PerformLayout()
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objGioCongVuotQua
        obj.ChonBang = 1
        obj.Thang = Me.cbThang.Text
        obj.Nam = Me.txtNam.Text
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/ThongKeGioCongVuotQua_TrongThang.xml"), typeControl.Grid, "coldgrGioCongVuotQua")
        'Me.dgrBC = DirectCast(dgrBC, UltraGrid)
    End Sub

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub




    ' Fields
    Friend WithEvents b As clsBGioCongVuotQua
    Friend WithEvents btnXembaocao As ButtonItem
    Friend WithEvents btnXem As ButtonItem
    Friend WithEvents btnCapnhat As ButtonItem
    Friend WithEvents btnExcel As ButtonItem
    Friend WithEvents dgrBC As UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlButton As Panel
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents pnlList As Panel
    Friend WithEvents splDetail As CollapsibleSplitter
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents txtNam As UltraTextEditor
    Friend WithEvents UltraGroupBox1 As UltraGroupBox
    Friend WithEvents UltraTabControl1 As UltraTabControl
    Friend WithEvents UltraTabPageControl1 As UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage1 As UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As XPCaption
    Friend WithEvents XpCaption2 As XPCaption
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbThang As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Public ThemSua As Integer

    Private Sub frmQTKhacThuongLC_Thang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.rdKhilenca.Checked = True
    End Sub

    'Private Sub rdKhilenca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhilenca.CheckedChanged

    'End Sub

    'Private Sub rdKhixuongca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhixuongca.CheckedChanged

    'End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnCapnhat_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapnhat.Activate
        'Xoa du lieu cu=====================================================
        Dim obj As New objGioCongVuotQua
        obj.ChonBang = 1
        obj.Thang = Me.cbThang.Text
        obj.Nam = Me.txtNam.Text
        Me.b = New clsBGioCongVuotQua
        Me.b.DeleteInfo(obj)
        'Chen du lieu moi===================================================
        Me.ProgressBar1.Visible = True

        Dim sncua_thang As Integer = 0

        Select Case Val(obj.Thang)
            Case 1, 3, 5, 7, 8, 10, 12 : sncua_thang = 31
            Case 4, 6, 9, 11 : sncua_thang = 30
            Case 2
                If Val(obj.Nam) Mod 4 = 0 Then
                    sncua_thang = 29
                Else
                    sncua_thang = 28
                End If
        End Select

        Dim day As Integer = 1
        While day <= sncua_thang
            obj.Ngay = obj.Nam.ToString() + "/" + obj.Thang.ToString() + "/" + day.ToString()
            Me.b.InsertInfo(obj)
            If (day * 100) / sncua_thang < 100 Then
                Me.ProgressBar1.Value = (day * 100) / sncua_thang
            End If
            day += 1

        End While
        Me.ProgressBar1.Visible = False
        Me.ProgressBar1.Value = 0

    End Sub

    Private Sub btnXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXem.Activate
        clsTools.GridTheme1(Me.dgrBC)
        Me.b = New clsBGioCongVuotQua
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Me.methodLoad()
    End Sub

    Private Sub btnXembaocao_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXembaocao.Activate
        Dim report As New FrmReport
        report.reportID = "669"
        Dim strArray As String() = New String() {"'" + Me.txtNam.Text + "'", "'" + Me.cbThang.Text + "'"}
        report.para = strArray
        report.issysReport = True
        report.Show()
    End Sub
End Class

