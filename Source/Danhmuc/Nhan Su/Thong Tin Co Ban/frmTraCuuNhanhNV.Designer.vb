<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraCuuNhanhNV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraCuuNhanhNV))
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radNghiViec = New System.Windows.Forms.RadioButton
        Me.radDilam = New System.Windows.Forms.RadioButton
        Me.dtpNgay = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.radNgayvao = New System.Windows.Forms.RadioButton
        Me.radDV = New System.Windows.Forms.RadioButton
        Me.radDonviDD = New System.Windows.Forms.RadioButton
        Me.cboDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.chkSothe = New System.Windows.Forms.CheckBox
        Me.txtManv = New System.Windows.Forms.TextBox
        Me.btExcel = New TD.SandBar.ButtonItem
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.pnlList = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.bntKiemTraST = New TD.SandBar.ToolBar
        Me.splDetail = New NJFLib.Controls.CollapsibleSplitter
        Me.pnlDetail = New System.Windows.Forms.Panel
        Me.tabTraCuu = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraTabPageControl2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtpNgay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.pnlList.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        Me.pnlDetail.SuspendLayout()
        CType(Me.tabTraCuu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTraCuu.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl2.Controls.Add(Me.dtpNgay)
        Me.UltraTabPageControl2.Controls.Add(Me.radNgayvao)
        Me.UltraTabPageControl2.Controls.Add(Me.radDV)
        Me.UltraTabPageControl2.Controls.Add(Me.radDonviDD)
        Me.UltraTabPageControl2.Controls.Add(Me.cboDonvi)
        Me.UltraTabPageControl2.Controls.Add(Me.chkSothe)
        Me.UltraTabPageControl2.Controls.Add(Me.txtManv)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(2, 21)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1184, 43)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radNghiViec)
        Me.Panel1.Controls.Add(Me.radDilam)
        Me.Panel1.Location = New System.Drawing.Point(664, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 39)
        Me.Panel1.TabIndex = 31
        '
        'radNghiViec
        '
        Me.radNghiViec.AutoSize = True
        Me.radNghiViec.Location = New System.Drawing.Point(67, 10)
        Me.radNghiViec.Name = "radNghiViec"
        Me.radNghiViec.Size = New System.Drawing.Size(69, 18)
        Me.radNghiViec.TabIndex = 29
        Me.radNghiViec.Text = "Nghỉ việc"
        Me.radNghiViec.UseVisualStyleBackColor = True
        '
        'radDilam
        '
        Me.radDilam.AutoSize = True
        Me.radDilam.Checked = True
        Me.radDilam.Location = New System.Drawing.Point(3, 10)
        Me.radDilam.Name = "radDilam"
        Me.radDilam.Size = New System.Drawing.Size(54, 18)
        Me.radDilam.TabIndex = 29
        Me.radDilam.TabStop = True
        Me.radDilam.Text = "Đi làm"
        Me.radDilam.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.FormatString = "dd/MM/yyyy"
        Me.dtpNgay.Location = New System.Drawing.Point(896, 10)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(115, 21)
        Me.dtpNgay.TabIndex = 30
        '
        'radNgayvao
        '
        Me.radNgayvao.AutoSize = True
        Me.radNgayvao.Location = New System.Drawing.Point(813, 12)
        Me.radNgayvao.Name = "radNgayvao"
        Me.radNgayvao.Size = New System.Drawing.Size(77, 18)
        Me.radNgayvao.TabIndex = 29
        Me.radNgayvao.TabStop = True
        Me.radNgayvao.Text = "Ngày vào :"
        Me.radNgayvao.UseVisualStyleBackColor = True
        '
        'radDV
        '
        Me.radDV.AutoSize = True
        Me.radDV.Location = New System.Drawing.Point(192, 14)
        Me.radDV.Name = "radDV"
        Me.radDV.Size = New System.Drawing.Size(57, 18)
        Me.radDV.TabIndex = 28
        Me.radDV.TabStop = True
        Me.radDV.Text = "Đơn vị"
        Me.radDV.UseVisualStyleBackColor = True
        '
        'radDonviDD
        '
        Me.radDonviDD.AutoSize = True
        Me.radDonviDD.Location = New System.Drawing.Point(255, 13)
        Me.radDonviDD.Name = "radDonviDD"
        Me.radDonviDD.Size = New System.Drawing.Size(107, 18)
        Me.radDonviDD.TabIndex = 28
        Me.radDonviDD.TabStop = True
        Me.radDonviDD.Text = "Đơn vị điều động"
        Me.radDonviDD.UseVisualStyleBackColor = True
        '
        'cboDonvi
        '
        Me.cboDonvi.AlwaysInEditMode = True
        Me.cboDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cboDonvi.DisplayMember = "DV_TEN"
        Me.cboDonvi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDonvi.Location = New System.Drawing.Point(364, 10)
        Me.cboDonvi.Name = "cboDonvi"
        Me.cboDonvi.Size = New System.Drawing.Size(293, 22)
        Me.cboDonvi.SortStyle = Infragistics.Win.ValueListSortStyle.AscendingByValue
        Me.cboDonvi.TabIndex = 27
        Me.cboDonvi.ValueMember = "DV_MA"
        '
        'chkSothe
        '
        Me.chkSothe.AutoSize = True
        Me.chkSothe.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSothe.Location = New System.Drawing.Point(20, 15)
        Me.chkSothe.Name = "chkSothe"
        Me.chkSothe.Size = New System.Drawing.Size(61, 19)
        Me.chkSothe.TabIndex = 25
        Me.chkSothe.Text = "Số thẻ"
        Me.chkSothe.UseVisualStyleBackColor = True
        '
        'txtManv
        '
        Me.txtManv.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManv.HideSelection = False
        Me.txtManv.Location = New System.Drawing.Point(83, 13)
        Me.txtManv.MaxLength = 6
        Me.txtManv.Name = "txtManv"
        Me.txtManv.Size = New System.Drawing.Size(98, 21)
        Me.txtManv.TabIndex = 24
        '
        'btExcel
        '
        Me.btExcel.ImageIndex = 9
        Me.btExcel.Text = "Xuất Excel"
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
        Me.XpCaption2.Size = New System.Drawing.Size(1188, 28)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách nhân viên "
        '
        '_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom
        '
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 402)
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Name = "_frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom"
        Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(1194, 0)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.pnlList)
        Me.UltraGroupBox1.Controls.Add(Me.splDetail)
        Me.UltraGroupBox1.Controls.Add(Me.pnlDetail)
        Me.UltraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(1194, 402)
        Me.UltraGroupBox1.TabIndex = 24
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.dgrBC)
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(3, 102)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(1188, 297)
        Me.pnlList.TabIndex = 5
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
        Me.dgrBC.Size = New System.Drawing.Size(1188, 233)
        Me.dgrBC.TabIndex = 11
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.bntKiemTraST)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(1188, 64)
        Me.pnlButton.TabIndex = 7
        '
        'bntKiemTraST
        '
        Me.bntKiemTraST.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntKiemTraST.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btExcel})
        Me.bntKiemTraST.Dock = System.Windows.Forms.DockStyle.None
        Me.bntKiemTraST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntKiemTraST.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.bntKiemTraST.ImageList = Me.ImageList1
        Me.bntKiemTraST.Location = New System.Drawing.Point(1, 27)
        Me.bntKiemTraST.Name = "bntKiemTraST"
        Me.bntKiemTraST.Size = New System.Drawing.Size(1186, 26)
        Me.bntKiemTraST.TabIndex = 11
        Me.bntKiemTraST.Text = "ToolBar1"
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
        Me.pnlDetail.Size = New System.Drawing.Size(1188, 94)
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
        Me.tabTraCuu.Size = New System.Drawing.Size(1188, 66)
        Me.tabTraCuu.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Me.tabTraCuu.TabIndex = 7
        Appearance33.BackColor = System.Drawing.Color.AliceBlue
        UltraTab5.Appearance = Appearance33
        UltraTab5.TabPage = Me.UltraTabPageControl2
        UltraTab5.Text = "Thông Tin Tìm Kiếm"
        Me.tabTraCuu.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab5})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1184, 43)
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(1188, 28)
        Me.XpCaption1.TabIndex = 4
        Me.XpCaption1.Text = "Tra cứu thông tin nhân viên"
        '
        'frmTraCuuNhanhNV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1194, 402)
        Me.Controls.Add(Me._frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTraCuuNhanhNV"
        Me.Text = "frmTraCuuNhanhNV"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtpNgay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.pnlList.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        Me.pnlDetail.ResumeLayout(False)
        CType(Me.tabTraCuu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTraCuu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents radDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents btExcel As TD.SandBar.ButtonItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents _frmPhuNuMangThai_KThai_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents bntKiemTraST As TD.SandBar.ToolBar
    Friend WithEvents splDetail As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents pnlDetail As System.Windows.Forms.Panel
    Friend WithEvents tabTraCuu As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents chkSothe As System.Windows.Forms.CheckBox
    Friend WithEvents txtManv As System.Windows.Forms.TextBox
    Friend WithEvents radDonviDD As System.Windows.Forms.RadioButton
    Friend WithEvents radDV As System.Windows.Forms.RadioButton
    Friend WithEvents radNgayvao As System.Windows.Forms.RadioButton
    Friend WithEvents dtpNgay As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radNghiViec As System.Windows.Forms.RadioButton
    Friend WithEvents radDilam As System.Windows.Forms.RadioButton
End Class
