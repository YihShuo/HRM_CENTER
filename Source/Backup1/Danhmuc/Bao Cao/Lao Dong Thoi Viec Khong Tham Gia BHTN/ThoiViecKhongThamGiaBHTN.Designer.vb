<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThoiViecKhongThamGiaBHTN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ThoiViecKhongThamGiaBHTN))
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNgayKyHD = New System.Windows.Forms.TextBox
        Me.txtNgayVao = New System.Windows.Forms.TextBox
        Me.txtHoTen = New System.Windows.Forms.TextBox
        Me.txtManv = New System.Windows.Forms.TextBox
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.pnlList = New System.Windows.Forms.Panel
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.bntKiemTraST = New TD.SandBar.ToolBar
        Me.btXem = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.tabTraCuu = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlList.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.tabTraCuu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTraCuu.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.label3)
        Me.UltraTabPageControl2.Controls.Add(Me.Label2)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Controls.Add(Me.txtNgayKyHD)
        Me.UltraTabPageControl2.Controls.Add(Me.txtNgayVao)
        Me.UltraTabPageControl2.Controls.Add(Me.txtHoTen)
        Me.UltraTabPageControl2.Controls.Add(Me.txtManv)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(832, 43)
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(594, 14)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(69, 14)
        Me.label3.TabIndex = 25
        Me.label3.Text = "Ngày ký HD :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(406, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Ngày vào :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 14)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Số thẻ :"
        '
        'txtNgayKyHD
        '
        Me.txtNgayKyHD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayKyHD.HideSelection = False
        Me.txtNgayKyHD.Location = New System.Drawing.Point(668, 10)
        Me.txtNgayKyHD.Name = "txtNgayKyHD"
        Me.txtNgayKyHD.Size = New System.Drawing.Size(129, 21)
        Me.txtNgayKyHD.TabIndex = 24
        '
        'txtNgayVao
        '
        Me.txtNgayVao.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayVao.HideSelection = False
        Me.txtNgayVao.Location = New System.Drawing.Point(471, 13)
        Me.txtNgayVao.Name = "txtNgayVao"
        Me.txtNgayVao.Size = New System.Drawing.Size(115, 21)
        Me.txtNgayVao.TabIndex = 24
        '
        'txtHoTen
        '
        Me.txtHoTen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoTen.HideSelection = False
        Me.txtHoTen.Location = New System.Drawing.Point(154, 13)
        Me.txtHoTen.Name = "txtHoTen"
        Me.txtHoTen.Size = New System.Drawing.Size(246, 21)
        Me.txtHoTen.TabIndex = 24
        '
        'txtManv
        '
        Me.txtManv.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManv.HideSelection = False
        Me.txtManv.Location = New System.Drawing.Point(53, 13)
        Me.txtManv.Name = "txtManv"
        Me.txtManv.Size = New System.Drawing.Size(98, 21)
        Me.txtManv.TabIndex = 24
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'dgrBC
        '
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.Name = "Arial"
        Appearance35.ForeColor = System.Drawing.Color.Blue
        UltraGridBand1.Header.Appearance = Appearance35
        Appearance36.BackColor = System.Drawing.Color.LightGreen
        UltraGridBand1.Override.ActiveRowAppearance = Appearance36
        Me.dgrBC.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgrBC.DisplayLayout.GroupByBox.Hidden = True
        Me.dgrBC.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgrBC.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Show
        Me.dgrBC.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 64)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(836, 339)
        Me.dgrBC.TabIndex = 11
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 102)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(836, 403)
        Me.pnlList.TabIndex = 5
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.bntKiemTraST)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(836, 64)
        Me.pnlButton.TabIndex = 7
        '
        'bntKiemTraST
        '
        Me.bntKiemTraST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntKiemTraST.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btXem})
        Me.bntKiemTraST.Dock = System.Windows.Forms.DockStyle.None
        Me.bntKiemTraST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntKiemTraST.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.bntKiemTraST.ImageList = Me.ImageList1
        Me.bntKiemTraST.Location = New System.Drawing.Point(1, 27)
        Me.bntKiemTraST.Name = "bntKiemTraST"
        Me.bntKiemTraST.Size = New System.Drawing.Size(834, 26)
        Me.bntKiemTraST.TabIndex = 11
        Me.bntKiemTraST.Text = "ToolBar1"
        '
        'btXem
        '
        Me.btXem.ImageIndex = 1
        Me.btXem.Text = "Xem"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        Me.ImageList1.Images.SetKeyName(8, "")
        Me.ImageList1.Images.SetKeyName(9, "doc excel.ico")
        '
        'XpCaption2
        '
        Me.XpCaption2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(836, 28)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên "
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(832, 43)
        '
        'splDetail
        '
        Me.splDetail.AnimationDelay = 20
        Me.splDetail.AnimationStep = 20
        Me.splDetail.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.splDetail.ControlToHide = Me.pnlDetail
        Me.splDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.splDetail.ExpandParentForm = False
        Me.splDetail.Location = New System.Drawing.Point(3, 94)
        Me.splDetail.Name = "splDetail"
        Me.splDetail.TabIndex = 7
        Me.splDetail.TabStop = False
        Me.splDetail.UseAnimations = False
        Me.splDetail.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'pnlDetail
        '
        Me.pnlDetail.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.pnlDetail.Controls.Add(Me.tabTraCuu)
        Me.pnlDetail.Controls.Add(Me.XpCaption1)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetail.Location = New System.Drawing.Point(3, 0)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(836, 94)
        Me.pnlDetail.TabIndex = 0
        '
        'tabTraCuu
        '
        Appearance32.BackColor = System.Drawing.Color.AliceBlue
        Me.tabTraCuu.Appearance = Appearance32
        Me.tabTraCuu.Controls.Add(Me.UltraTabPageControl2)
        Me.tabTraCuu.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tabTraCuu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTraCuu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabTraCuu.Location = New System.Drawing.Point(0, 28)
        Me.tabTraCuu.Name = "tabTraCuu"
        Me.tabTraCuu.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tabTraCuu.Size = New System.Drawing.Size(836, 66)
        Me.tabTraCuu.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.tabTraCuu.TabIndex = 7
        Appearance33.BackColor = System.Drawing.Color.AliceBlue
        UltraTab5.Appearance = Appearance33
        UltraTab5.TabPage = Me.UltraTabPageControl2
        UltraTab5.Text = "Thông Tin Tìm Kiếm"
        Me.tabTraCuu.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab5})
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(836, 28)
        Me.XpCaption1.TabIndex = 4
        Me.XpCaption1.Text = "Tính trợ cấp thôi việc"
        '
        '_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom
        '
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 508)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Name = "_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom"
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(842, 0)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(842, 508)
        Me.UltraGroupBox1.TabIndex = 26
        '
        'ThoiViecKhongThamGiaBHTN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 508)
        Me.Controls.Add(Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Name = "ThoiViecKhongThamGiaBHTN"
        Me.Text = "ThoiViecKhongThamGiaBHTN"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlList.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.tabTraCuu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTraCuu.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend txtNgayKyHD As System.Windows.Forms.TextBox
    Friend label3 As System.Windows.Forms.Label
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtManv As System.Windows.Forms.TextBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents bntKiemTraST As TD.SandBar.ToolBar
    Friend WithEvents btXem As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents tabTraCuu As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents _frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNgayVao As System.Windows.Forms.TextBox
    Friend WithEvents txtHoTen As System.Windows.Forms.TextBox
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
