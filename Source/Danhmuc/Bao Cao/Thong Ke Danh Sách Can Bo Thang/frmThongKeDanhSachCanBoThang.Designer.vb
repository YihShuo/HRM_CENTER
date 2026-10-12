<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongKeDanhSachCanBoThang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongKeDanhSachCanBoThang))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.pnlList = New System.Windows.Forms.Panel()
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlButton = New System.Windows.Forms.Panel()
        Me.ToolBar1 = New TD.SandBar.ToolBar()
        Me.btXemBaoCao = New TD.SandBar.ButtonItem()
        Me.ButtonItem1 = New TD.SandBar.ButtonItem()
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.rdDVC = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radTCT = New System.Windows.Forms.RadioButton()
        Me.radKhuB = New System.Windows.Forms.RadioButton()
        Me.radKhuA = New System.Windows.Forms.RadioButton()
        Me.chkChiTiet = New System.Windows.Forms.CheckBox()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption()
        Me.tabTKgiocongxuong = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraTabPageControl2.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTKgiocongxuong.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.pnlList)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox2)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(827, 335)
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(0, 61)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(827, 274)
        Me.pnlList.TabIndex = 6
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 58)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(827, 216)
        Me.dgrBC.TabIndex = 10
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(827, 58)
        Me.pnlButton.TabIndex = 7
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btXemBaoCao, Me.ButtonItem1})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.ToolBar1.Location = New System.Drawing.Point(2, 26)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(825, 26)
        Me.ToolBar1.TabIndex = 11
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btXemBaoCao
        '
        Me.btXemBaoCao.Image = CType(resources.GetObject("btXemBaoCao.Image"), System.Drawing.Image)
        Me.btXemBaoCao.ImageIndex = 3
        Me.btXemBaoCao.Text = "Xem"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Text = "Xuất Excel"
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(827, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách  "
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.rdDVC)
        Me.UltraGroupBox2.Controls.Add(Me.Label1)
        Me.UltraGroupBox2.Controls.Add(Me.radTCT)
        Me.UltraGroupBox2.Controls.Add(Me.radKhuB)
        Me.UltraGroupBox2.Controls.Add(Me.radKhuA)
        Me.UltraGroupBox2.Controls.Add(Me.chkChiTiet)
        Me.UltraGroupBox2.Controls.Add(Me.dtpNgay)
        Me.UltraGroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(827, 61)
        Me.UltraGroupBox2.TabIndex = 0
        Me.UltraGroupBox2.Text = "Điều kiện "
        '
        'rdDVC
        '
        Me.rdDVC.AutoSize = True
        Me.rdDVC.ForeColor = System.Drawing.Color.Teal
        Me.rdDVC.Location = New System.Drawing.Point(314, 35)
        Me.rdDVC.Name = "rdDVC"
        Me.rdDVC.Size = New System.Drawing.Size(69, 17)
        Me.rdDVC.TabIndex = 6
        Me.rdDVC.TabStop = True
        Me.rdDVC.Text = "Khu DVC"
        Me.rdDVC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(11, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ngày :"
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.ForeColor = System.Drawing.Color.Teal
        Me.radTCT.Location = New System.Drawing.Point(401, 34)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(88, 17)
        Me.radTCT.TabIndex = 4
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "Toàn công ty"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.ForeColor = System.Drawing.Color.Teal
        Me.radKhuB.Location = New System.Drawing.Point(254, 35)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 3
        Me.radKhuB.TabStop = True
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.ForeColor = System.Drawing.Color.Teal
        Me.radKhuA.Location = New System.Drawing.Point(194, 35)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 2
        Me.radKhuA.TabStop = True
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'chkChiTiet
        '
        Me.chkChiTiet.AutoSize = True
        Me.chkChiTiet.ForeColor = System.Drawing.Color.Blue
        Me.chkChiTiet.Location = New System.Drawing.Point(520, 36)
        Me.chkChiTiet.Name = "chkChiTiet"
        Me.chkChiTiet.Size = New System.Drawing.Size(113, 17)
        Me.chkChiTiet.TabIndex = 1
        Me.chkChiTiet.Text = "Danh sách Chi tiết"
        Me.chkChiTiet.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(58, 32)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(118, 20)
        Me.dtpNgay.TabIndex = 0
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(829, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thống Kê Danh Sách Cán Bộ"
        '
        'tabTKgiocongxuong
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BackColor2 = System.Drawing.Color.White
        Me.tabTKgiocongxuong.Appearance = Appearance6
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabPageControl2)
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabTKgiocongxuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTKgiocongxuong.Location = New System.Drawing.Point(0, 24)
        Me.tabTKgiocongxuong.Name = "tabTKgiocongxuong"
        Me.tabTKgiocongxuong.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTKgiocongxuong.Size = New System.Drawing.Size(829, 356)
        Me.tabTKgiocongxuong.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.tabTKgiocongxuong.TabIndex = 8
        Appearance7.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance7.BackColor2 = System.Drawing.Color.White
        UltraTab1.Appearance = Appearance7
        UltraTab1.TabPage = Me.UltraTabPageControl2
        UltraTab1.Text = "Thống Kê"
        Me.tabTKgiocongxuong.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.tabTKgiocongxuong.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(827, 335)
        '
        'frmThongKeDanhSachCanBoThang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 380)
        Me.Controls.Add(Me.tabTKgiocongxuong)
        Me.Controls.Add(Me.XpCaption1)
        Me.Name = "frmThongKeDanhSachCanBoThang"
        Me.Text = "frmThongKeDanhSachCanBoThang"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTKgiocongxuong.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents tabTKgiocongxuong As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btXemBaoCao As TD.SandBar.ButtonItem
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents ButtonItem1 As TD.SandBar.ButtonItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents chkChiTiet As System.Windows.Forms.CheckBox
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdDVC As System.Windows.Forms.RadioButton
End Class
