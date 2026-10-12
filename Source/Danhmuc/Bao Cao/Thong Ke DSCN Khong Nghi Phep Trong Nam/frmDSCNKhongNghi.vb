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

Public Class frmDSCNKhongNghi
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmDSCNKhongNghi_Load)
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
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDSCNKhongNghi))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNam = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdKhongnghitrongnam = New System.Windows.Forms.RadioButton
        Me.rdLamtren6thangduoi1namkhongnghi = New System.Windows.Forms.RadioButton
        Me.rdNghikhongqua1ngay = New System.Windows.Forms.RadioButton
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
        Me.btXem = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtNam)
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(548, 118)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(297, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Năm :"
        '
        'txtNam
        '
        Me.txtNam.Location = New System.Drawing.Point(337, 27)
        Me.txtNam.MaxLength = 4
        Me.txtNam.Name = "txtNam"
        Me.txtNam.Size = New System.Drawing.Size(36, 20)
        Me.txtNam.TabIndex = 4
        Me.txtNam.Text = "2009"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdKhongnghitrongnam)
        Me.GroupBox1.Controls.Add(Me.rdLamtren6thangduoi1namkhongnghi)
        Me.GroupBox1.Controls.Add(Me.rdNghikhongqua1ngay)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'rdKhongnghitrongnam
        '
        Me.rdKhongnghitrongnam.AutoSize = True
        Me.rdKhongnghitrongnam.Location = New System.Drawing.Point(22, 19)
        Me.rdKhongnghitrongnam.Name = "rdKhongnghitrongnam"
        Me.rdKhongnghitrongnam.Size = New System.Drawing.Size(159, 18)
        Me.rdKhongnghitrongnam.TabIndex = 0
        Me.rdKhongnghitrongnam.TabStop = True
        Me.rdKhongnghitrongnam.Text = "DSCN không nghỉ trong năm"
        Me.rdKhongnghitrongnam.UseVisualStyleBackColor = True
        '
        'rdLamtren6thangduoi1namkhongnghi
        '
        Me.rdLamtren6thangduoi1namkhongnghi.AutoSize = True
        Me.rdLamtren6thangduoi1namkhongnghi.Location = New System.Drawing.Point(22, 67)
        Me.rdLamtren6thangduoi1namkhongnghi.Name = "rdLamtren6thangduoi1namkhongnghi"
        Me.rdLamtren6thangduoi1namkhongnghi.Size = New System.Drawing.Size(245, 18)
        Me.rdLamtren6thangduoi1namkhongnghi.TabIndex = 2
        Me.rdLamtren6thangduoi1namkhongnghi.TabStop = True
        Me.rdLamtren6thangduoi1namkhongnghi.Text = "DSCN làm trên 6 tháng dưới 1 năm không nghỉ"
        Me.rdLamtren6thangduoi1namkhongnghi.UseVisualStyleBackColor = True
        '
        'rdNghikhongqua1ngay
        '
        Me.rdNghikhongqua1ngay.AutoSize = True
        Me.rdNghikhongqua1ngay.Location = New System.Drawing.Point(22, 43)
        Me.rdNghikhongqua1ngay.Name = "rdNghikhongqua1ngay"
        Me.rdNghikhongqua1ngay.Size = New System.Drawing.Size(216, 18)
        Me.rdNghikhongqua1ngay.TabIndex = 1
        Me.rdNghikhongqua1ngay.TabStop = True
        Me.rdNghikhongqua1ngay.Text = "DSCN nghỉ không quá 1 ngày trong năm"
        Me.rdNghikhongqua1ngay.UseVisualStyleBackColor = True
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(558, 168)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(558, 144)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(552, 141)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Chi tiết DSCN không nghỉ phép"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(548, 118)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(558, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thông tin chi tiết DSCN không nghỉ phép"
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
        Me.ImageList1.Images.SetKeyName(6, "excel.ico")
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 176)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(558, 266)
        Me.pnlList.TabIndex = 13
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 64)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(558, 202)
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
        Me.pnlButton.Size = New System.Drawing.Size(558, 64)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnExcel, Me.btXem})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(558, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnExcel
        '
        Me.btnExcel.ImageIndex = 6
        Me.btnExcel.Text = "Excel"
        '
        'btXem
        '
        Me.btXem.ImageIndex = 2
        Me.btXem.Text = "Xem"
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(558, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách công nhân không nghỉ phép"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(564, 445)
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
        Me.splDetail.Location = New System.Drawing.Point(3, 168)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'frmDSCNKhongNghi
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(564, 445)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmDSCNKhongNghi"
        Me.Text = "Danh sach cong nhan khong nghi"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.grpDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Me.b = New clsBDSCNKhongNghi
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC

        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/KhongNghiTrongNam.xml"), typeControl.Grid, "coldgrkhongnghi")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)

    End Sub

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub



    ' Fields
    Friend WithEvents b As clsBDSCNKhongNghi
    Friend WithEvents btnExcel As ButtonItem
    Friend WithEvents dgrBC As UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pnlButton As Panel
    Friend WithEvents pnlDetail As Panel
    Friend WithEvents pnlList As Panel
    Friend WithEvents splDetail As CollapsibleSplitter
    Friend WithEvents tolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents UltraGroupBox1 As UltraGroupBox
    Friend WithEvents UltraTabControl1 As UltraTabControl
    Friend WithEvents UltraTabPageControl1 As UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage1 As UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As XPCaption
    Friend WithEvents XpCaption2 As XPCaption
    Private components As System.ComponentModel.IContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdKhongnghitrongnam As System.Windows.Forms.RadioButton
    Friend WithEvents rdLamtren6thangduoi1namkhongnghi As System.Windows.Forms.RadioButton
    Friend WithEvents rdNghikhongqua1ngay As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNam As System.Windows.Forms.TextBox
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btXem As TD.SandBar.ButtonItem
    Public ThemSua As Integer

    Private Sub frmDSCNKhongNghi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        Me.rdKhongnghitrongnam.Checked = True
    End Sub

    Dim obj As New objDSCNKhongNghi

    Private Sub rdKhongnghitrongnam_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdKhongnghitrongnam.CheckedChanged
        'obj.setvalue(1, Me.txtNam.Text)
    End Sub

    Private Sub rdNghikhongqua1ngay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNghikhongqua1ngay.CheckedChanged
        'obj.setvalue(2, Me.txtNam.Text)
    End Sub

    Private Sub rdLamtren6thangduoi1namkhongnghi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdLamtren6thangduoi1namkhongnghi.CheckedChanged
        'obj.setvalue(3, Me.txtNam.Text)
    End Sub

    Private Sub btnExcel_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Activate
        Me.SaveFileDialog1.Filter() = "Excel Files(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.UltraGridExcelExporter1.Export(Me.dgrBC, Me.SaveFileDialog1.FileName)
            MessageBox.Show("Xuất file excel thành công", "Xuất Excel", MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btXem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btXem.Activate
        Me.dgrBC.DataSource = Nothing

        If Me.rdKhongnghitrongnam.Checked = True Then
            obj.setvalue(1, Me.txtNam.Text)
        End If

        If Me.rdNghikhongqua1ngay.Checked = True Then
            obj.setvalue(2, Me.txtNam.Text)
        End If

        If Me.rdLamtren6thangduoi1namkhongnghi.Checked = True Then
            obj.setvalue(3, Me.txtNam.Text)
        End If

        Me.methodLoad()
    End Sub
End Class

