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

Public Class frmMayChamCong
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmMayChamCong_Load)
        Me.ThemSua = 0
        Me.InitializeComponent()
    End Sub

    Public Sub b__errorRaise(ByVal messege As String)
        Interaction.MsgBox(messege, MsgBoxStyle.OkOnly, Nothing)
    End Sub

    'Public Sub btnIn_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles btnIn.Activate
    '    Dim report As New FrmReport
    '    report.reportID = "024"
    '    Dim strArray As String() = New String() {"Tỷ Xuân", "Khu Công Nghiệp Hòa Phú - Long Hồ - Vĩnh Long", "Tel: (070)962052 - Fax: (070)962051"}
    '    report.para = strArray
    '    report.issysReport = True
    '    report.Show()
    'End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    Public Sub HieuChinh()
        Try
            Dim grid As New clsTformatGrid
            Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow

            If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                If activeRow.Cells.Item("GIAOTHUC").Value = True Then
                    Me.rdTcpip.Checked = True
                    Me.txtIp.Enabled = True
                    Me.txtSocong.Enabled = False
                Else
                    Me.rdUdp.Checked = True
                    Me.txtSocong.Enabled = True
                    Me.txtIp.Enabled = False
                End If
                Me.txtSomay.Text = activeRow.Cells.Item("SOMAY").Value.ToString
                Me.txtTenmay.Text = activeRow.Cells.Item("TENMAY").Value.ToString
                Me.txtTinhtrang.Text = activeRow.Cells.Item("TINHTRANGSUDUNG").Value.ToString
                Me.txtGhichu.Text = activeRow.Cells.Item("GHICHU").Value.ToString
                Me.txtVitri.Text = activeRow.Cells.Item("VITRI").Value.ToString
                Me.txtIp.Text = activeRow.Cells.Item("IP").Value.ToString
                Me.txtSocong.Text = activeRow.Cells.Item("SOCONG").Value.ToString

                Me.txtSomay.ReadOnly = True
                Me.ThemSua = 1
            End If

        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Public Sub InitControl()
        Me.btnThem.Enabled = False
        Me.btnSua.Enabled = False
        Me.btnXoa.Enabled = False
        Me.btnLuu.Enabled = False
        Me.ThemSua = 0
    End Sub

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMayChamCong))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtIp = New System.Windows.Forms.TextBox
        Me.txtSocong = New System.Windows.Forms.TextBox
        Me.rdTcpip = New System.Windows.Forms.RadioButton
        Me.txtGhichu = New System.Windows.Forms.TextBox
        Me.rdUdp = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtVitri = New System.Windows.Forms.TextBox
        Me.txtTinhtrang = New System.Windows.Forms.TextBox
        Me.txtTenmay = New System.Windows.Forms.TextBox
        Me.txtSomay = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
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
        Me.btnThem = New TD.SandBar.ButtonItem
        Me.btnSua = New TD.SandBar.ButtonItem
        Me.btnXoa = New TD.SandBar.ButtonItem
        Me.btnLuu = New TD.SandBar.ButtonItem
        Me.btnIn = New TD.SandBar.ButtonItem
        Me.btnChon = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
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
        Me.UltraTabPageControl1.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl1.Controls.Add(Me.txtVitri)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTinhtrang)
        Me.UltraTabPageControl1.Controls.Add(Me.txtTenmay)
        Me.UltraTabPageControl1.Controls.Add(Me.txtSomay)
        Me.UltraTabPageControl1.Controls.Add(Me.Label6)
        Me.UltraTabPageControl1.Controls.Add(Me.Label5)
        Me.UltraTabPageControl1.Controls.Add(Me.Label1)
        Me.UltraTabPageControl1.Controls.Add(Me.Label7)
        Me.UltraTabPageControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(572, 130)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtIp)
        Me.GroupBox1.Controls.Add(Me.txtSocong)
        Me.GroupBox1.Controls.Add(Me.rdTcpip)
        Me.GroupBox1.Controls.Add(Me.txtGhichu)
        Me.GroupBox1.Controls.Add(Me.rdUdp)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(271, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 118)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Giao Thức"
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(82, 16)
        Me.txtIp.MaxLength = 15
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(134, 20)
        Me.txtIp.TabIndex = 7
        Me.txtIp.Text = "192.168."
        '
        'txtSocong
        '
        Me.txtSocong.Location = New System.Drawing.Point(82, 40)
        Me.txtSocong.MaxLength = 4
        Me.txtSocong.Name = "txtSocong"
        Me.txtSocong.Size = New System.Drawing.Size(134, 20)
        Me.txtSocong.TabIndex = 7
        '
        'rdTcpip
        '
        Me.rdTcpip.AutoSize = True
        Me.rdTcpip.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdTcpip.Location = New System.Drawing.Point(14, 17)
        Me.rdTcpip.Name = "rdTcpip"
        Me.rdTcpip.Size = New System.Drawing.Size(62, 19)
        Me.rdTcpip.TabIndex = 6
        Me.rdTcpip.TabStop = True
        Me.rdTcpip.Text = "TCP/IP"
        Me.rdTcpip.UseVisualStyleBackColor = True
        '
        'txtGhichu
        '
        Me.txtGhichu.Location = New System.Drawing.Point(82, 66)
        Me.txtGhichu.Multiline = True
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.Size = New System.Drawing.Size(134, 45)
        Me.txtGhichu.TabIndex = 5
        '
        'rdUdp
        '
        Me.rdUdp.AutoSize = True
        Me.rdUdp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdUdp.Location = New System.Drawing.Point(14, 41)
        Me.rdUdp.Name = "rdUdp"
        Me.rdUdp.Size = New System.Drawing.Size(49, 19)
        Me.rdUdp.TabIndex = 5
        Me.rdUdp.TabStop = True
        Me.rdUdp.Text = "UDP"
        Me.rdUdp.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 18)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Ghi Chú"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVitri
        '
        Me.txtVitri.Location = New System.Drawing.Point(109, 94)
        Me.txtVitri.Name = "txtVitri"
        Me.txtVitri.Size = New System.Drawing.Size(132, 20)
        Me.txtVitri.TabIndex = 5
        '
        'txtTinhtrang
        '
        Me.txtTinhtrang.Location = New System.Drawing.Point(109, 68)
        Me.txtTinhtrang.Name = "txtTinhtrang"
        Me.txtTinhtrang.Size = New System.Drawing.Size(132, 20)
        Me.txtTinhtrang.TabIndex = 5
        '
        'txtTenmay
        '
        Me.txtTenmay.Location = New System.Drawing.Point(109, 42)
        Me.txtTenmay.Name = "txtTenmay"
        Me.txtTenmay.Size = New System.Drawing.Size(132, 20)
        Me.txtTenmay.TabIndex = 5
        '
        'txtSomay
        '
        Me.txtSomay.Location = New System.Drawing.Point(109, 16)
        Me.txtSomay.MaxLength = 3
        Me.txtSomay.Name = "txtSomay"
        Me.txtSomay.Size = New System.Drawing.Size(44, 20)
        Me.txtSomay.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 18)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Tình Trạng"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Vị Trí"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tên Máy"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(30, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 18)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Số Máy"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlDetail
        '
        Me.pnlDetail.Controls.Add(Me.grpDetail)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(582, 180)
        Me.pnlDetail.TabIndex = 0
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.UltraTabControl1)
        Me.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDetail.Location = New System.Drawing.Point(0, 24)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(582, 156)
        Me.grpDetail.TabIndex = 6
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(3, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(576, 153)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.UltraTabControl1.TabIndex = 0
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Chi tiết máy chấm công"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(572, 130)
        '
        'XpCaption1
        '
        Me.XpCaption1.Cursor = System.Windows.Forms.Cursors.Default
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(582, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thông tin chi tiết máy chấm công"
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
        Me.ImageList1.Images.SetKeyName(6, "Save.bmp")
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 188)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(582, 254)
        Me.pnlList.TabIndex = 13
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 64)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(582, 190)
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
        Me.pnlButton.Size = New System.Drawing.Size(582, 64)
        Me.pnlButton.TabIndex = 3
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btnThem, Me.btnSua, Me.btnXoa, Me.btnLuu, Me.btnIn, Me.btnChon})
        Me.ToolBar1.Guid = New System.Guid("71185f57-2984-4e33-98d5-fb21c0482dd5")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 24)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(582, 26)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btnThem
        '
        Me.btnThem.ImageIndex = 0
        Me.btnThem.Text = "Thêm"
        '
        'btnSua
        '
        Me.btnSua.ImageIndex = 2
        Me.btnSua.Text = "Sửa"
        '
        'btnXoa
        '
        Me.btnXoa.ImageIndex = 1
        Me.btnXoa.Text = "Xóa"
        '
        'btnLuu
        '
        Me.btnLuu.ImageIndex = 6
        Me.btnLuu.Text = "Lưu"
        '
        'btnIn
        '
        Me.btnIn.ImageIndex = 3
        Me.btnIn.Text = "In"
        Me.btnIn.Visible = False
        '
        'btnChon
        '
        Me.btnChon.ImageIndex = 5
        Me.btnChon.Text = "Chọn"
        Me.btnChon.Visible = False
        '
        'XpCaption2
        '
        Me.XpCaption2.Cursor = System.Windows.Forms.Cursors.Default
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(582, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách máy chấm công"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(588, 445)
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
        Me.splDetail.Location = New System.Drawing.Point(3, 180)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 14
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'frmMayChamCong
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(588, 445)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmMayChamCong"
        Me.ShowIcon = False
        Me.Text = "Danh sach may cham cong"
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

    Public Sub LuuDuLieu()
        Dim obj As New objMayChamCong
        If (StringType.StrCmp(Me.txtSomay.Text, "", False) = 0) Then
            MessageBox.Show("Chưa nhập số máy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtSomay.Focus()
        ElseIf (StringType.StrCmp(Me.txtTenmay.Text, "", False) = 0) Then
            MessageBox.Show("Chưa nhập tên máy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtTenmay.Focus()
        Else

            obj.setvalue(Me.txtSomay.Text, Me.txtTenmay.Text, Me.txtTinhtrang.Text, Me.txtVitri.Text, Me.txtGhichu.Text, Me.txtIp.Text, Me.txtSocong.Text, Me.rdTcpip.Checked, Me.rdUdp.Checked)
            Me.b = New clsBMayChamCong
            Try
                If Me.b.CapNhat(obj, Me.ThemSua) Then
                    MessageBox.Show("Đã lưu dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.methodLoad()

                    If Me.btnThem.Enabled Then
                        Me.ThemMoi()
                    End If
                Else
                    Me.txtSomay.Focus()
                End If
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                Dim exception As Exception = exception1
                clsTools.thongbaoLoi(exception.Message)
                ProjectData.ClearProjectError()
            End Try
        End If
    End Sub

    Public Sub methodLoad()
        Dim grid As New clsTformatGrid
        Dim obj As New objMayChamCong
        obj.Setnull()
        obj.ChonBang = 1
        Me.dgrBC.DataSource = Me.b.LoadDS(obj)
        Dim dgrBC As Object = Me.dgrBC
        grid.initControlXML((dgrBC), (Application.StartupPath & "/layout/MayChamCong.xml"), typeControl.Grid, "coldgrMayChamCong")
        Me.dgrBC = DirectCast(dgrBC, UltraGrid)
        If (Me.dgrBC.Rows.Count > 0) Then
            Me.dgrBC.Rows.Item(0).Selected = True
            Me.dgrBC.Rows(0).Activated = True
            Me.HieuChinh()
            Me.ThemSua = 1
        End If
    End Sub

    Public Sub showGroupinvi()
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
    End Sub

    Public Sub ThemMoi()
        Me.b = New clsBMayChamCong

        Me.txtSomay.Clear()
        Me.txtTenmay.Clear()
        Me.txtGhichu.Clear()
        Me.txtVitri.Clear()
        Me.txtTinhtrang.Clear()
        Me.rdTcpip.Checked = False
        Me.rdUdp.Checked = False
        Me.txtSomay.ReadOnly = False
        Me.txtSomay.Focus()

        Me.ThemSua = 0
    End Sub

    'Public Sub UltraToolbarsManager1_ToolClick(ByVal sender As Object, ByVal e As ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
    '    Dim key As String = e.Tool.Key
    '    If (StringType.StrCmp(key, "mnuThem", False) = 0) Then
    '        Me.btnThem_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuSua", False) = 0) Then
    '        Me.btnSua_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuXoa", False) = 0) Then
    '        Me.btnXoa_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuLuu", False) = 0) Then
    '        Me.btnLuu_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    ElseIf (StringType.StrCmp(key, "mnuIn", False) = 0) Then
    '        Me.btnIn_Activate(RuntimeHelpers.GetObjectValue(sender), e)
    '    End If
    'End Sub

    Public Sub XoaDuLieu()
        Try
            Dim obj As New objMayChamCong
            If (Me.dgrBC.Selected.Rows.Count > 0) Then
                '1========Neu chi co mot dong duoc chon===============================
                If (Me.dgrBC.Selected.Rows.Count = 1) Then
                    Dim activeRow As UltraGridRow = Me.dgrBC.ActiveRow
                    If ((Not activeRow Is Nothing) AndAlso (activeRow.Index <> -1)) Then
                        obj.SoMay = StringType.FromObject(activeRow.Cells.Item("SOMAY").Value)
                        If Me.b.IsDeleteOK(obj) Then
                            If (MessageBox.Show("Bạn có muốn xoá số máy " + obj.SoMay + " được chọn không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                If Me.b.DeleteInfo(obj) Then
                                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                    GoTo Label_0274
                                End If
                                MessageBox.Show("Xoá bị lỗi." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            End If
                        Else
                            MessageBox.Show("Không thể xoá số máy " + obj.SoMay + " này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                    Return
                End If
                '2==============================================
                If (MessageBox.Show(("Bạn muốn xoá " & StringType.FromInteger(Me.dgrBC.Selected.Rows.Count) & " dòng đã chọn?"), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                    Return
                End If
                '3==========Neu co nhieu dong duoc chon========================================
                Dim num2 As Integer = (Me.dgrBC.Selected.Rows.Count - 1)
                Dim i As Integer = 0
                Do While (i <= num2)
                    obj.Setnull()
                    obj.SoMay = StringType.FromObject(Me.dgrBC.Selected.Rows.Item(i).Cells.Item("SOMAY").Value)
                    If Me.b.IsDeleteOK(obj) Then
                        If Me.b.DeleteInfo(obj) Then
                            'MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Else
                            MessageBox.Show("Xoá bị lỗi số máy " + obj.SoMay + "." & ChrW(13) & ChrW(10) & "Kiểm tra và thực hiện lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End If
                    Else
                        MessageBox.Show("Không thể xoá số máy " + obj.SoMay + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    i += 1
                Loop
            End If
Label_0274:

            Me.methodLoad()
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub


    ' Fields
    Friend WithEvents b As clsBMayChamCong
    Friend WithEvents btnChon As ButtonItem
    Friend WithEvents btnIn As ButtonItem
    Friend WithEvents btnLuu As ButtonItem
    Friend WithEvents btnSua As ButtonItem
    Friend WithEvents btnThem As ButtonItem
    Friend WithEvents btnXoa As ButtonItem
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpDetail As UltraGroupBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label7 As Label
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSomay As System.Windows.Forms.TextBox
    Friend WithEvents txtVitri As System.Windows.Forms.TextBox
    Friend WithEvents txtTinhtrang As System.Windows.Forms.TextBox
    Friend WithEvents txtTenmay As System.Windows.Forms.TextBox
    Friend WithEvents txtGhichu As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdTcpip As System.Windows.Forms.RadioButton
    Friend WithEvents rdUdp As System.Windows.Forms.RadioButton
    Friend WithEvents txtIp As System.Windows.Forms.TextBox
    Friend WithEvents txtSocong As System.Windows.Forms.TextBox
    Public ThemSua As Integer

    Private Sub frmMayChamCong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTools.GridTheme1(Me.dgrBC)
        If Me.splDetail.IsCollapsed Then
            Me.splDetail.ToggleState()
        End If
        Me.b = New clsBMayChamCong
        Me.methodLoad()
    End Sub

    Private Sub dgrBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.Click

    End Sub

    Private Sub rdTcpip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTcpip.CheckedChanged
        If Me.rdTcpip.Checked = True Then
            Me.txtIp.Enabled = True
            Me.txtIp.Text = "192.168."
            Me.txtSocong.Text = "1001"
        Else
            Me.txtIp.Enabled = False
        End If
    End Sub

    Private Sub rdUdp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdUdp.CheckedChanged
        If Me.rdUdp.Checked = True Then
            Me.txtSocong.Enabled = True
            Me.txtIp.Text = "192.168."
        Else
            Me.txtSocong.Enabled = False
        End If
    End Sub

    Private Sub btnThem_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThem.Activate
        Me.showGroupinvi()
        Me.ThemMoi()
    End Sub

    Private Sub btnLuu_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLuu.Activate
        If MessageBox.Show("Bạn có muốn lưu dữ liệu không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.LuuDuLieu()
        End If
    End Sub

    Private Sub dgrBC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgrBC.DoubleClick
        If Me.btnSua.Enabled Then
            Me.showGroupinvi()
            Me.HieuChinh()
        End If
    End Sub

    Private Sub btnSua_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSua.Activate
        Me.showGroupinvi()
        Me.HieuChinh()
    End Sub

    Private Sub btnXoa_Activate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXoa.Activate
        Me.XoaDuLieu()
    End Sub

    Private Sub txtSomay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSomay.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtSocong_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSocong.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub txtIp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIp.KeyPress
        If Convert.ToInt32(e.KeyChar) <> 8 Then
            If Not Information.IsNumeric(e.KeyChar) Then
                If e.KeyChar = "." Then
                    Exit Sub
                Else
                    e.KeyChar = ""
                End If
            End If
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        Dim frm As New frmMayChamCongSo
        frm.MaySo = Me.txtSomay.Text
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub pnlList_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlList.Paint

    End Sub
End Class

