<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBinhBauA
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBinhBauA))
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.txtSonhanvien = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.dgrBC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnToanBo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnBoChon = New System.Windows.Forms.ToolStripMenuItem
        Me.si_Grid = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.btExcel = New Infragistics.Win.Misc.UltraButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.chkXuong = New System.Windows.Forms.CheckBox
        Me.chkDonvi = New System.Windows.Forms.CheckBox
        Me.lbCapNhatBBNam = New System.Windows.Forms.LinkLabel
        Me.linkBBTHTS = New System.Windows.Forms.LinkLabel
        Me.lbBBTH = New System.Windows.Forms.LinkLabel
        Me.cbDonvi = New System.Windows.Forms.ComboBox
        Me.cbXuong = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.chkThaiSan = New System.Windows.Forms.CheckBox
        Me.chkChiTiet = New System.Windows.Forms.CheckBox
        Me.cbDenNgay = New System.Windows.Forms.ComboBox
        Me.cbTuNgay = New System.Windows.Forms.ComboBox
        Me.cbBinhBau = New System.Windows.Forms.ComboBox
        Me.cbNam = New System.Windows.Forms.ComboBox
        Me.btXem = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.Panel4.SuspendLayout()
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSonhanvien
        '
        Me.txtSonhanvien.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSonhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSonhanvien.ForeColor = System.Drawing.Color.Blue
        Me.txtSonhanvien.Location = New System.Drawing.Point(154, 553)
        Me.txtSonhanvien.Name = "txtSonhanvien"
        Me.txtSonhanvien.ReadOnly = True
        Me.txtSonhanvien.Size = New System.Drawing.Size(100, 22)
        Me.txtSonhanvien.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.dgrBC)
        Me.Panel4.Location = New System.Drawing.Point(12, 116)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1080, 429)
        Me.Panel4.TabIndex = 4
        '
        'dgrBC
        '
        Me.dgrBC.ContextMenuStrip = Me.ContextMenuStrip1
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
        Me.dgrBC.Size = New System.Drawing.Size(1078, 427)
        Me.dgrBC.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnToanBo, Me.mnBoChon})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 48)
        '
        'mnToanBo
        '
        Me.mnToanBo.Name = "mnToanBo"
        Me.mnToanBo.Size = New System.Drawing.Size(120, 22)
        Me.mnToanBo.Text = "Toàn Bộ"
        '
        'mnBoChon
        '
        Me.mnBoChon.Name = "mnBoChon"
        Me.mnBoChon.Size = New System.Drawing.Size(120, 22)
        Me.mnBoChon.Text = "Bỏ Chọn"
        '
        'si_Grid
        '
        Me.si_Grid.ImageStream = CType(resources.GetObject("si_Grid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.si_Grid.TransparentColor = System.Drawing.Color.Transparent
        Me.si_Grid.Images.SetKeyName(0, "")
        Me.si_Grid.Images.SetKeyName(1, "")
        Me.si_Grid.Images.SetKeyName(2, "")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(130, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Từ tháng :"
        '
        'btExcel
        '
        Me.btExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btExcel.Location = New System.Drawing.Point(1009, 553)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(83, 25)
        Me.btExcel.TabIndex = 5
        Me.btExcel.Text = "Excel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Xem báo cáo bình bầu năm :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.chkXuong)
        Me.Panel2.Controls.Add(Me.chkDonvi)
        Me.Panel2.Controls.Add(Me.lbCapNhatBBNam)
        Me.Panel2.Controls.Add(Me.linkBBTHTS)
        Me.Panel2.Controls.Add(Me.lbBBTH)
        Me.Panel2.Controls.Add(Me.cbDonvi)
        Me.Panel2.Controls.Add(Me.btExcel)
        Me.Panel2.Controls.Add(Me.cbXuong)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtSonhanvien)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Blue
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1104, 587)
        Me.Panel2.TabIndex = 6
        '
        'chkXuong
        '
        Me.chkXuong.AutoSize = True
        Me.chkXuong.Location = New System.Drawing.Point(229, 14)
        Me.chkXuong.Name = "chkXuong"
        Me.chkXuong.Size = New System.Drawing.Size(57, 17)
        Me.chkXuong.TabIndex = 18
        Me.chkXuong.Text = "Xưởng"
        Me.chkXuong.UseVisualStyleBackColor = True
        '
        'chkDonvi
        '
        Me.chkDonvi.AutoSize = True
        Me.chkDonvi.Location = New System.Drawing.Point(229, 38)
        Me.chkDonvi.Name = "chkDonvi"
        Me.chkDonvi.Size = New System.Drawing.Size(57, 17)
        Me.chkDonvi.TabIndex = 18
        Me.chkDonvi.Text = "Đơn vị"
        Me.chkDonvi.UseVisualStyleBackColor = True
        '
        'lbCapNhatBBNam
        '
        Me.lbCapNhatBBNam.AutoSize = True
        Me.lbCapNhatBBNam.Location = New System.Drawing.Point(863, 42)
        Me.lbCapNhatBBNam.Name = "lbCapNhatBBNam"
        Me.lbCapNhatBBNam.Size = New System.Drawing.Size(138, 13)
        Me.lbCapNhatBBNam.TabIndex = 9
        Me.lbCapNhatBBNam.TabStop = True
        Me.lbCapNhatBBNam.Text = "Cập nhật vào bình bầu năm"
        '
        'linkBBTHTS
        '
        Me.linkBBTHTS.AutoSize = True
        Me.linkBBTHTS.Location = New System.Drawing.Point(556, 40)
        Me.linkBBTHTS.Name = "linkBBTHTS"
        Me.linkBBTHTS.Size = New System.Drawing.Size(111, 13)
        Me.linkBBTHTS.TabIndex = 8
        Me.linkBBTHTS.TabStop = True
        Me.linkBBTHTS.Text = "Bình bầu tổng hợp TS"
        '
        'lbBBTH
        '
        Me.lbBBTH.AutoSize = True
        Me.lbBBTH.Location = New System.Drawing.Point(557, 16)
        Me.lbBBTH.Name = "lbBBTH"
        Me.lbBBTH.Size = New System.Drawing.Size(94, 13)
        Me.lbBBTH.TabIndex = 8
        Me.lbBBTH.TabStop = True
        Me.lbBBTH.Text = "Bình bầu tổng hợp"
        '
        'cbDonvi
        '
        Me.cbDonvi.FormattingEnabled = True
        Me.cbDonvi.Items.AddRange(New Object() {"A", "ANEW", "C", "CNEW", "OX", "B", "Toàn bộ"})
        Me.cbDonvi.Location = New System.Drawing.Point(289, 36)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(263, 21)
        Me.cbDonvi.TabIndex = 15
        '
        'cbXuong
        '
        Me.cbXuong.FormattingEnabled = True
        Me.cbXuong.Items.AddRange(New Object() {"A", "ANEW", "C", "CNEW", "OX", "B", "Toàn bộ"})
        Me.cbXuong.Location = New System.Drawing.Point(289, 12)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(263, 21)
        Me.cbXuong.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 556)
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
        Me.Panel3.Controls.Add(Me.radKhuB)
        Me.Panel3.Controls.Add(Me.radKhuA)
        Me.Panel3.Controls.Add(Me.radTCT)
        Me.Panel3.Controls.Add(Me.chkThaiSan)
        Me.Panel3.Controls.Add(Me.chkChiTiet)
        Me.Panel3.Controls.Add(Me.cbDenNgay)
        Me.Panel3.Controls.Add(Me.cbTuNgay)
        Me.Panel3.Controls.Add(Me.cbBinhBau)
        Me.Panel3.Controls.Add(Me.cbNam)
        Me.Panel3.Controls.Add(Me.btXem)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(12, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1077, 48)
        Me.Panel3.TabIndex = 1
        '
        'chkThaiSan
        '
        Me.chkThaiSan.AutoSize = True
        Me.chkThaiSan.Location = New System.Drawing.Point(732, 23)
        Me.chkThaiSan.Name = "chkThaiSan"
        Me.chkThaiSan.Size = New System.Drawing.Size(67, 17)
        Me.chkThaiSan.TabIndex = 18
        Me.chkThaiSan.Text = "Thai sản"
        Me.chkThaiSan.UseVisualStyleBackColor = True
        '
        'chkChiTiet
        '
        Me.chkChiTiet.AutoSize = True
        Me.chkChiTiet.Location = New System.Drawing.Point(732, 7)
        Me.chkChiTiet.Name = "chkChiTiet"
        Me.chkChiTiet.Size = New System.Drawing.Size(102, 17)
        Me.chkChiTiet.TabIndex = 18
        Me.chkChiTiet.Text = "Bình bầu chi tiết"
        Me.chkChiTiet.UseVisualStyleBackColor = True
        '
        'cbDenNgay
        '
        Me.cbDenNgay.FormattingEnabled = True
        Me.cbDenNgay.Location = New System.Drawing.Point(383, 12)
        Me.cbDenNgay.Name = "cbDenNgay"
        Me.cbDenNgay.Size = New System.Drawing.Size(87, 21)
        Me.cbDenNgay.TabIndex = 17
        '
        'cbTuNgay
        '
        Me.cbTuNgay.FormattingEnabled = True
        Me.cbTuNgay.Location = New System.Drawing.Point(205, 12)
        Me.cbTuNgay.Name = "cbTuNgay"
        Me.cbTuNgay.Size = New System.Drawing.Size(90, 21)
        Me.cbTuNgay.TabIndex = 16
        '
        'cbBinhBau
        '
        Me.cbBinhBau.FormattingEnabled = True
        Me.cbBinhBau.Items.AddRange(New Object() {"A", "ANEW", "C", "CNEW", "OX", "B", "Toàn bộ"})
        Me.cbBinhBau.Location = New System.Drawing.Point(580, 11)
        Me.cbBinhBau.Name = "cbBinhBau"
        Me.cbBinhBau.Size = New System.Drawing.Size(90, 21)
        Me.cbBinhBau.TabIndex = 15
        '
        'cbNam
        '
        Me.cbNam.FormattingEnabled = True
        Me.cbNam.Location = New System.Drawing.Point(50, 12)
        Me.cbNam.Name = "cbNam"
        Me.cbNam.Size = New System.Drawing.Size(77, 21)
        Me.cbNam.TabIndex = 15
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.Location = New System.Drawing.Point(673, 6)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(56, 31)
        Me.btXem.TabIndex = 13
        Me.btXem.Text = "Xem"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(474, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Loại bình bầu :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(298, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Đến tháng :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(2, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Năm :"
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Checked = True
        Me.radTCT.Location = New System.Drawing.Point(853, 13)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(68, 17)
        Me.radTCT.TabIndex = 19
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "Toàn Cty"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Location = New System.Drawing.Point(949, 4)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 19
        Me.radKhuA.TabStop = True
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Location = New System.Drawing.Point(949, 23)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 19
        Me.radKhuB.TabStop = True
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'frmBinhBauA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 587)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmBinhBauA"
        Me.Text = "frmBinhBauA"
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgrBC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents txtSonhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnToanBo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnBoChon As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents si_Grid As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btExcel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents cbDenNgay As System.Windows.Forms.ComboBox
    Friend WithEvents cbTuNgay As System.Windows.Forms.ComboBox
    Friend WithEvents cbNam As System.Windows.Forms.ComboBox
    Friend WithEvents cbBinhBau As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkChiTiet As System.Windows.Forms.CheckBox
    Friend WithEvents lbBBTH As System.Windows.Forms.LinkLabel
    Friend WithEvents lbCapNhatBBNam As System.Windows.Forms.LinkLabel
    Friend WithEvents linkBBTHTS As System.Windows.Forms.LinkLabel
    Friend WithEvents cbDonvi As System.Windows.Forms.ComboBox
    Friend WithEvents chkDonvi As System.Windows.Forms.CheckBox
    Friend WithEvents chkXuong As System.Windows.Forms.CheckBox
    Friend WithEvents cbXuong As System.Windows.Forms.ComboBox
    Friend WithEvents chkThaiSan As System.Windows.Forms.CheckBox
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Private WithEvents dgrBC As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
