<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBangCongKhoaSo
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBangCongKhoaSo))
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.radKhuDVC = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraDesktopAlert1 = New Infragistics.Win.Misc.UltraDesktopAlert(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.btGioTangCaDV = New Infragistics.Win.Misc.UltraButton
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.btGioTangCa = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.btExcel = New Infragistics.Win.Misc.UltraButton
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.txtSonhanvien = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.lnkBangChamCom = New System.Windows.Forms.LinkLabel
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDesktopAlert1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgrBC
        '
        Me.dgrBC.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Appearance4.BackColor = System.Drawing.SystemColors.MenuBar
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 10.0!
        Appearance4.ForeColor = System.Drawing.Color.Blue
        Me.dgrBC.DisplayLayout.Override.HeaderAppearance = Appearance4
        Me.dgrBC.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.dgrBC.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag
        Me.dgrBC.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgrBC.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgrBC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrBC.ImageList = Me.si_Grid
        Me.dgrBC.Location = New System.Drawing.Point(0, 0)
        Me.dgrBC.Name = "dgrBC"
        Me.dgrBC.Size = New System.Drawing.Size(1202, 498)
        Me.dgrBC.TabIndex = 2
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Checked = True
        Me.radTCT.Location = New System.Drawing.Point(194, 6)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(46, 17)
        Me.radTCT.TabIndex = 1
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "TCT"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ngày"
        '
        'radKhuDVC
        '
        Me.radKhuDVC.AutoSize = True
        Me.radKhuDVC.Location = New System.Drawing.Point(121, 5)
        Me.radKhuDVC.Name = "radKhuDVC"
        Me.radKhuDVC.Size = New System.Drawing.Size(69, 17)
        Me.radKhuDVC.TabIndex = 0
        Me.radKhuDVC.Text = "Khu DVC"
        Me.radKhuDVC.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Location = New System.Drawing.Point(65, 6)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 0
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'UltraDesktopAlert1
        '
        Me.UltraDesktopAlert1.AutoClose = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraDesktopAlert1.CloseButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraDesktopAlert1.MultipleWindowDisplayStyle = Infragistics.Win.Misc.MultipleWindowDisplayStyle.None
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'btGioTangCaDV
        '
        Me.btGioTangCaDV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGioTangCaDV.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btGioTangCaDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGioTangCaDV.Location = New System.Drawing.Point(1133, 596)
        Me.btGioTangCaDV.Name = "btGioTangCaDV"
        Me.btGioTangCaDV.Size = New System.Drawing.Size(79, 17)
        Me.btGioTangCaDV.TabIndex = 5
        Me.btGioTangCaDV.Text = "Total Overtime"
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(48, 12)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(95, 22)
        Me.dtpNgay.TabIndex = 1
        '
        'btGioTangCa
        '
        Me.btGioTangCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGioTangCa.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btGioTangCa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGioTangCa.Location = New System.Drawing.Point(1133, 594)
        Me.btGioTangCa.Name = "btGioTangCa"
        Me.btGioTangCa.Size = New System.Drawing.Size(79, 17)
        Me.btGioTangCa.TabIndex = 5
        Me.btGioTangCa.Text = "Total Overtime"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(440, 544)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(118, 31)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.Location = New System.Drawing.Point(12, 14)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(112, 16)
        Me.LinkLabel3.TabIndex = 9
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Chấm công tháng"
        '
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(456, 10)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(388, 24)
        Me.cbDonvi.TabIndex = 4
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(128, 14)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(126, 16)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Chấm công cá nhân"
        '
        'btExcel
        '
        Me.btExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(1133, 590)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(83, 25)
        Me.btExcel.TabIndex = 5
        Me.btExcel.Text = "Excel"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(12, 84)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1204, 500)
        Me.Panel4.TabIndex = 4
        '
        'txtSonhanvien
        '
        Me.txtSonhanvien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSonhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSonhanvien.ForeColor = System.Drawing.Color.Blue
        Me.txtSonhanvien.Location = New System.Drawing.Point(154, 592)
        Me.txtSonhanvien.Name = "txtSonhanvien"
        Me.txtSonhanvien.ReadOnly = True
        Me.txtSonhanvien.Size = New System.Drawing.Size(100, 22)
        Me.txtSonhanvien.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.lnkBangChamCom)
        Me.Panel2.Controls.Add(Me.LinkLabel3)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.btExcel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.txtSonhanvien)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.btGioTangCaDV)
        Me.Panel2.Controls.Add(Me.btGioTangCa)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1228, 626)
        Me.Panel2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 595)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tổng số nhân viên"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.cbDonvi)
        Me.Panel3.Controls.Add(Me.dtpNgay)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(12, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1204, 45)
        Me.Panel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.radTCT)
        Me.Panel1.Controls.Add(Me.radKhuDVC)
        Me.Panel1.Controls.Add(Me.radKhuB)
        Me.Panel1.Controls.Add(Me.radKhuA)
        Me.Panel1.Location = New System.Drawing.Point(153, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(245, 28)
        Me.Panel1.TabIndex = 7
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Location = New System.Drawing.Point(5, 6)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 0
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(406, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ngày :"
        '
        'lnkBangChamCom
        '
        Me.lnkBangChamCom.AutoSize = True
        Me.lnkBangChamCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkBangChamCom.Location = New System.Drawing.Point(260, 14)
        Me.lnkBangChamCom.Name = "lnkBangChamCom"
        Me.lnkBangChamCom.Size = New System.Drawing.Size(105, 16)
        Me.lnkBangChamCom.TabIndex = 9
        Me.lnkBangChamCom.TabStop = True
        Me.lnkBangChamCom.Text = "Chấm công cơm"
        '
        'frmBangCongKhoaSo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1228, 626)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmBangCongKhoaSo"
        Me.Text = "frmBangCongKhoaSo"
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDesktopAlert1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents radKhuDVC As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraDesktopAlert1 As Infragistics.Win.Misc.UltraDesktopAlert
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents btExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtSonhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btGioTangCaDV As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btGioTangCa As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lnkBangChamCom As System.Windows.Forms.LinkLabel
End Class
