<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongKeHD
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
        Me.components = New System.ComponentModel.Container
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongKeHD))
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.groupbox = New Infragistics.Win.Misc.UltraGroupBox
        Me.radDVC = New System.Windows.Forms.RadioButton
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpDenNgay = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtpNgay = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.radChuaKyHDLDThang = New System.Windows.Forms.RadioButton
        Me.CollapsibleSplitter1 = New NJFLib.Controls.CollapsibleSplitter
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.tabTKgiocongxuong = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btXemreport = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.groupbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupbox.SuspendLayout()
        CType(Me.dtpDenNgay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpNgay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTKgiocongxuong.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.groupbox)
        Me.UltraTabPageControl2.Controls.Add(Me.CollapsibleSplitter1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(677, 119)
        '
        'groupbox
        '
        Me.groupbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupbox.Controls.Add(Me.radDVC)
        Me.groupbox.Controls.Add(Me.radTCT)
        Me.groupbox.Controls.Add(Me.radKhuB)
        Me.groupbox.Controls.Add(Me.radKhuA)
        Me.groupbox.Controls.Add(Me.Label2)
        Me.groupbox.Controls.Add(Me.Label1)
        Me.groupbox.Controls.Add(Me.dtpDenNgay)
        Me.groupbox.Controls.Add(Me.dtpNgay)
        Me.groupbox.Controls.Add(Me.UltraGroupBox2)
        Me.groupbox.Location = New System.Drawing.Point(8, 3)
        Me.groupbox.Name = "groupbox"
        Me.groupbox.Size = New System.Drawing.Size(665, 118)
        Me.groupbox.TabIndex = 10
        Me.groupbox.Text = "Điều Kiện Xem Danh Sách"
        '
        'radDVC
        '
        Me.radDVC.AutoSize = True
        Me.radDVC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDVC.ForeColor = System.Drawing.Color.Blue
        Me.radDVC.Location = New System.Drawing.Point(312, 45)
        Me.radDVC.Name = "radDVC"
        Me.radDVC.Size = New System.Drawing.Size(69, 17)
        Me.radDVC.TabIndex = 15
        Me.radDVC.TabStop = True
        Me.radDVC.Text = "Khu DVC"
        Me.radDVC.UseVisualStyleBackColor = True
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radTCT.ForeColor = System.Drawing.Color.Blue
        Me.radTCT.Location = New System.Drawing.Point(396, 45)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(88, 17)
        Me.radTCT.TabIndex = 14
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "Toàn công ty"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuB.ForeColor = System.Drawing.Color.Blue
        Me.radKhuB.Location = New System.Drawing.Point(236, 45)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 13
        Me.radKhuB.TabStop = True
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuA.ForeColor = System.Drawing.Color.Blue
        Me.radKhuA.Location = New System.Drawing.Point(162, 45)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 4
        Me.radKhuA.TabStop = True
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(286, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Đến Ngày :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(89, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Từ Ngày :"
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.Location = New System.Drawing.Point(347, 19)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(125, 21)
        Me.dtpDenNgay.TabIndex = 11
        '
        'dtpNgay
        '
        Me.dtpNgay.Location = New System.Drawing.Point(144, 19)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(125, 21)
        Me.dtpNgay.TabIndex = 11
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox2.Controls.Add(Me.radChuaKyHDLDThang)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(6, 65)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(653, 52)
        Me.UltraGroupBox2.TabIndex = 10
        '
        'radChuaKyHDLDThang
        '
        Me.radChuaKyHDLDThang.AutoSize = True
        Me.radChuaKyHDLDThang.ForeColor = System.Drawing.Color.Red
        Me.radChuaKyHDLDThang.Location = New System.Drawing.Point(138, 17)
        Me.radChuaKyHDLDThang.Name = "radChuaKyHDLDThang"
        Me.radChuaKyHDLDThang.Size = New System.Drawing.Size(293, 17)
        Me.radChuaKyHDLDThang.TabIndex = 2
        Me.radChuaKyHDLDThang.TabStop = True
        Me.radChuaKyHDLDThang.Text = "Danh Sách CB-CNV Chưa Ký HDLD Đóng BHXH Tháng"
        Me.radChuaKyHDLDThang.UseVisualStyleBackColor = True
        '
        'CollapsibleSplitter1
        '
        Me.CollapsibleSplitter1.AnimationDelay = 20
        Me.CollapsibleSplitter1.AnimationStep = 20
        Me.CollapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.CollapsibleSplitter1.ControlToHide = Nothing
        Me.CollapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CollapsibleSplitter1.ExpandParentForm = False
        Me.CollapsibleSplitter1.Location = New System.Drawing.Point(0, 0)
        Me.CollapsibleSplitter1.Name = "splDetail"
        Me.CollapsibleSplitter1.TabIndex = 9
        Me.CollapsibleSplitter1.TabStop = False
        Me.CollapsibleSplitter1.UseAnimations = False
        Me.CollapsibleSplitter1.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(679, 24)
        Me.XpCaption1.TabIndex = 5
        Me.XpCaption1.Text = "Thống Kê Danh Sách"
        '
        'tabTKgiocongxuong
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Appearance6.BackColor2 = System.Drawing.Color.White
        Me.tabTKgiocongxuong.Appearance = Appearance6
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabPageControl2)
        Me.tabTKgiocongxuong.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.tabTKgiocongxuong.Dock = System.Windows.Forms.DockStyle.Top
        Me.tabTKgiocongxuong.Location = New System.Drawing.Point(0, 24)
        Me.tabTKgiocongxuong.Name = "tabTKgiocongxuong"
        Me.tabTKgiocongxuong.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.tabTKgiocongxuong.Size = New System.Drawing.Size(679, 140)
        Me.tabTKgiocongxuong.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Excel
        Me.tabTKgiocongxuong.TabIndex = 8
        Appearance7.BackColor = System.Drawing.Color.WhiteSmoke
        Appearance7.BackColor2 = System.Drawing.Color.White
        UltraTab1.Appearance = Appearance7
        UltraTab1.TabPage = Me.UltraTabPageControl2
        Me.tabTKgiocongxuong.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        Me.tabTKgiocongxuong.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(677, 119)
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.tabTKgiocongxuong
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(0, 164)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 9
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 172)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(679, 46)
        Me.pnlButton.TabIndex = 10
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btXemreport})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New System.Drawing.Point(0, 21)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(676, 26)
        Me.ToolBar1.TabIndex = 12
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btXemreport
        '
        Me.btXemreport.ImageIndex = 2
        Me.btXemreport.Text = "Xem Báo Cáo"
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
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(679, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên "
        '
        'dgrBC
        '
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Location = New System.Drawing.Point(0, 218)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(679, 227)
        Me.dgrBC.TabIndex = 11
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 218)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(679, 227)
        Me.CrystalReportViewer1.TabIndex = 12
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmThongKeHD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 445)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.dgrBC)
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.splDetail)
        Me.Controls.Add(Me.tabTKgiocongxuong)
        Me.Controls.Add(Me.XpCaption1)
        Me.Name = "frmThongKeHD"
        Me.Text = "frmThongKeHD"
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.groupbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupbox.ResumeLayout(False)
        Me.groupbox.PerformLayout()
        CType(Me.dtpDenNgay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpNgay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.tabTKgiocongxuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTKgiocongxuong.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents tabTKgiocongxuong As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents groupbox As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDenNgay As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtpNgay As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents radChuaKyHDLDThang As System.Windows.Forms.RadioButton
    Friend WithEvents CollapsibleSplitter1 As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btXemreport As TD.SandBar.ButtonItem
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents radDVC As System.Windows.Forms.RadioButton

End Class
