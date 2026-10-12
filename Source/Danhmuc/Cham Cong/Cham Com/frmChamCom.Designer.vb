<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChamCom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChamCom))
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.rdDonvi = New System.Windows.Forms.RadioButton
        Me.rdDonviNV = New System.Windows.Forms.RadioButton
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSonhanvien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuDVC = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.chkThang = New System.Windows.Forms.CheckBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lbToanbo = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.lbNhom = New System.Windows.Forms.Label
        Me.btGioTangCaDV = New Infragistics.Win.Misc.UltraButton
        Me.btGioTangCa = New Infragistics.Win.Misc.UltraButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.linkChamCom = New System.Windows.Forms.LinkLabel
        Me.linkChamComTuDong = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lnkLayDuLieu = New System.Windows.Forms.LinkLabel
        Me.linkChamComTay = New System.Windows.Forms.LinkLabel
        Me.btExcel = New Infragistics.Win.Misc.UltraButton
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.Panel4.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel4.Size = New System.Drawing.Size(1050, 407)
        Me.Panel4.TabIndex = 4
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
        Me.dgrBC.Size = New System.Drawing.Size(1048, 405)
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
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(684, 9)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(349, 24)
        Me.cbDonvi.TabIndex = 4
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'rdDonvi
        '
        Me.rdDonvi.AutoSize = True
        Me.rdDonvi.Checked = True
        Me.rdDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDonvi.Location = New System.Drawing.Point(552, 11)
        Me.rdDonvi.Name = "rdDonvi"
        Me.rdDonvi.Size = New System.Drawing.Size(126, 20)
        Me.rdDonvi.TabIndex = 3
        Me.rdDonvi.TabStop = True
        Me.rdDonvi.Text = "Đơn vị điều động"
        Me.rdDonvi.UseVisualStyleBackColor = True
        '
        'rdDonviNV
        '
        Me.rdDonviNV.AutoSize = True
        Me.rdDonviNV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDonviNV.Location = New System.Drawing.Point(483, 12)
        Me.rdDonviNV.Name = "rdDonviNV"
        Me.rdDonviNV.Size = New System.Drawing.Size(63, 20)
        Me.rdDonviNV.TabIndex = 2
        Me.rdDonviNV.Text = "Đơn vị"
        Me.rdDonviNV.UseVisualStyleBackColor = True
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
        'txtSonhanvien
        '
        Me.txtSonhanvien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSonhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSonhanvien.ForeColor = System.Drawing.Color.Blue
        Me.txtSonhanvien.Location = New System.Drawing.Point(154, 499)
        Me.txtSonhanvien.Name = "txtSonhanvien"
        Me.txtSonhanvien.ReadOnly = True
        Me.txtSonhanvien.Size = New System.Drawing.Size(100, 22)
        Me.txtSonhanvien.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 502)
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
        Me.Panel3.Controls.Add(Me.chkThang)
        Me.Panel3.Controls.Add(Me.cbDonvi)
        Me.Panel3.Controls.Add(Me.rdDonvi)
        Me.Panel3.Controls.Add(Me.rdDonviNV)
        Me.Panel3.Controls.Add(Me.dtpNgay)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Location = New System.Drawing.Point(12, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1050, 45)
        Me.Panel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.radTCT)
        Me.Panel1.Controls.Add(Me.radKhuDVC)
        Me.Panel1.Controls.Add(Me.radKhuB)
        Me.Panel1.Controls.Add(Me.radKhuA)
        Me.Panel1.Location = New System.Drawing.Point(205, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 28)
        Me.Panel1.TabIndex = 6
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BorderColor = System.Drawing.Color.White
        UltraToolTipInfo2.Appearance = Appearance2
        Me.UltraToolTipManager1.SetUltraToolTip(Me.Panel1, UltraToolTipInfo2)
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Checked = True
        Me.radTCT.Location = New System.Drawing.Point(211, 5)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(46, 17)
        Me.radTCT.TabIndex = 1
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "TCT"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuDVC
        '
        Me.radKhuDVC.AutoSize = True
        Me.radKhuDVC.Location = New System.Drawing.Point(138, 5)
        Me.radKhuDVC.Name = "radKhuDVC"
        Me.radKhuDVC.Size = New System.Drawing.Size(69, 17)
        Me.radKhuDVC.TabIndex = 0
        Me.radKhuDVC.Text = "Khu DVC"
        Me.radKhuDVC.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Location = New System.Drawing.Point(78, 4)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 0
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Location = New System.Drawing.Point(10, 4)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 0
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'chkThang
        '
        Me.chkThang.AutoSize = True
        Me.chkThang.Location = New System.Drawing.Point(147, 14)
        Me.chkThang.Name = "chkThang"
        Me.chkThang.Size = New System.Drawing.Size(57, 17)
        Me.chkThang.TabIndex = 5
        Me.chkThang.Text = "Tháng"
        Me.chkThang.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(473, 7)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(209, 28)
        Me.Panel5.TabIndex = 7
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.White
        UltraToolTipInfo3.Appearance = Appearance1
        Me.UltraToolTipManager1.SetUltraToolTip(Me.Panel5, UltraToolTipInfo3)
        '
        'lbToanbo
        '
        Me.lbToanbo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbToanbo.AutoSize = True
        Me.lbToanbo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbToanbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbToanbo.Location = New System.Drawing.Point(1003, 14)
        Me.lbToanbo.Name = "lbToanbo"
        Me.lbToanbo.Size = New System.Drawing.Size(59, 16)
        Me.lbToanbo.TabIndex = 0
        Me.lbToanbo.Text = "Toàn bộ"
        '
        'lbNhom
        '
        Me.lbNhom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbNhom.AutoSize = True
        Me.lbNhom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbNhom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNhom.Location = New System.Drawing.Point(953, 14)
        Me.lbNhom.Name = "lbNhom"
        Me.lbNhom.Size = New System.Drawing.Size(44, 16)
        Me.lbNhom.TabIndex = 0
        Me.lbNhom.Text = "Nhóm"
        '
        'btGioTangCaDV
        '
        Me.btGioTangCaDV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGioTangCaDV.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btGioTangCaDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGioTangCaDV.Location = New System.Drawing.Point(979, 503)
        Me.btGioTangCaDV.Name = "btGioTangCaDV"
        Me.btGioTangCaDV.Size = New System.Drawing.Size(79, 17)
        Me.btGioTangCaDV.TabIndex = 5
        Me.btGioTangCaDV.Text = "Total Overtime"
        '
        'btGioTangCa
        '
        Me.btGioTangCa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGioTangCa.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.btGioTangCa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGioTangCa.Location = New System.Drawing.Point(979, 501)
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
        'linkChamCom
        '
        Me.linkChamCom.AutoSize = True
        Me.linkChamCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkChamCom.Location = New System.Drawing.Point(118, 13)
        Me.linkChamCom.Name = "linkChamCom"
        Me.linkChamCom.Size = New System.Drawing.Size(74, 16)
        Me.linkChamCom.TabIndex = 23
        Me.linkChamCom.TabStop = True
        Me.linkChamCom.Text = "Chấm Cơm"
        '
        'linkChamComTuDong
        '
        Me.linkChamComTuDong.AutoSize = True
        Me.linkChamComTuDong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkChamComTuDong.Location = New System.Drawing.Point(196, 13)
        Me.linkChamComTuDong.Name = "linkChamComTuDong"
        Me.linkChamComTuDong.Size = New System.Drawing.Size(129, 16)
        Me.linkChamComTuDong.TabIndex = 12
        Me.linkChamComTuDong.TabStop = True
        Me.linkChamComTuDong.Text = "Chấm Cơm Toàn Bộ"
        UltraToolTipInfo1.ToolTipTextStyle = Infragistics.Win.ToolTipTextStyle.Raw
        Me.UltraToolTipManager1.SetUltraToolTip(Me.linkChamComTuDong, UltraToolTipInfo1)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.linkChamCom)
        Me.Panel2.Controls.Add(Me.lnkLayDuLieu)
        Me.Panel2.Controls.Add(Me.linkChamComTuDong)
        Me.Panel2.Controls.Add(Me.linkChamComTay)
        Me.Panel2.Controls.Add(Me.btExcel)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.txtSonhanvien)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lbToanbo)
        Me.Panel2.Controls.Add(Me.lbNhom)
        Me.Panel2.Controls.Add(Me.btGioTangCaDV)
        Me.Panel2.Controls.Add(Me.btGioTangCa)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1074, 533)
        Me.Panel2.TabIndex = 2
        '
        'lnkLayDuLieu
        '
        Me.lnkLayDuLieu.AutoSize = True
        Me.lnkLayDuLieu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkLayDuLieu.Location = New System.Drawing.Point(331, 13)
        Me.lnkLayDuLieu.Name = "lnkLayDuLieu"
        Me.lnkLayDuLieu.Size = New System.Drawing.Size(159, 16)
        Me.lnkLayDuLieu.TabIndex = 12
        Me.lnkLayDuLieu.TabStop = True
        Me.lnkLayDuLieu.Text = "Lấy dữ liệu không ăn cơm"
        '
        'linkChamComTay
        '
        Me.linkChamComTay.AutoSize = True
        Me.linkChamComTay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkChamComTay.Location = New System.Drawing.Point(12, 13)
        Me.linkChamComTay.Name = "linkChamComTay"
        Me.linkChamComTay.Size = New System.Drawing.Size(101, 16)
        Me.linkChamComTay.TabIndex = 12
        Me.linkChamComTay.TabStop = True
        Me.linkChamComTay.Text = "Chấm Cơm Tay"
        '
        'btExcel
        '
        Me.btExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(979, 497)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(83, 25)
        Me.btExcel.TabIndex = 5
        Me.btExcel.Text = "Excel"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'frmChamCom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 533)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmChamCom"
        Me.Text = "Chấm Cơm"
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents rdDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents rdDonviNV As System.Windows.Forms.RadioButton
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSonhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbToanbo As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lbNhom As System.Windows.Forms.Label
    Friend WithEvents btGioTangCaDV As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btGioTangCa As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents linkChamCom As System.Windows.Forms.LinkLabel
    Friend WithEvents linkChamComTuDong As System.Windows.Forms.LinkLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents linkChamComTay As System.Windows.Forms.LinkLabel
    Friend WithEvents btExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkThang As System.Windows.Forms.CheckBox
    Friend WithEvents lnkLayDuLieu As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuDVC As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
End Class
