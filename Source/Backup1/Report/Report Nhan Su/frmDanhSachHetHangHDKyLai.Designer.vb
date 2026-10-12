<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachHetHangHDKyLai
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.btIn = New Infragistics.Win.Misc.UltraButton
        Me.btDSTangLuong = New Infragistics.Win.Misc.UltraButton
        Me.radXuong = New System.Windows.Forms.RadioButton
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.radDonvi = New System.Windows.Forms.RadioButton
        Me.radKhu = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cbKhu = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Panel2.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rptChamcong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 73)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1129, 391)
        Me.Panel2.TabIndex = 1
        '
        'rptChamcong
        '
        Me.rptChamcong.ActiveViewIndex = -1
        Me.rptChamcong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptChamcong.DisplayGroupTree = False
        Me.rptChamcong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptChamcong.Location = New System.Drawing.Point(0, 0)
        Me.rptChamcong.Name = "rptChamcong"
        Me.rptChamcong.SelectionFormula = ""
        Me.rptChamcong.Size = New System.Drawing.Size(1127, 389)
        Me.rptChamcong.TabIndex = 2
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(33, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Từ Ngày :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(259, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Đến Ngày :"
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTuNgay.Location = New System.Drawing.Point(99, 8)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(145, 22)
        Me.dtpTuNgay.TabIndex = 3
        '
        'cbDonvi
        '
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbDonvi.DisplayMember = "DV_TEN"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(332, 36)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(282, 24)
        Me.cbDonvi.TabIndex = 3
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(335, 7)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(134, 22)
        Me.dtpDenNgay.TabIndex = 4
        '
        'btIn
        '
        Appearance2.ForeColor = System.Drawing.Color.Blue
        Me.btIn.Appearance = Appearance2
        Me.btIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btIn.Location = New System.Drawing.Point(819, 38)
        Me.btIn.Name = "btIn"
        Me.btIn.Size = New System.Drawing.Size(105, 23)
        Me.btIn.TabIndex = 3
        Me.btIn.Text = "In DS Tháng 2"
        '
        'btDSTangLuong
        '
        Appearance1.ForeColor = System.Drawing.Color.Blue
        Me.btDSTangLuong.Appearance = Appearance1
        Me.btDSTangLuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btDSTangLuong.Location = New System.Drawing.Point(930, 37)
        Me.btDSTangLuong.Name = "btDSTangLuong"
        Me.btDSTangLuong.Size = New System.Drawing.Size(129, 23)
        Me.btDSTangLuong.TabIndex = 3
        Me.btDSTangLuong.Text = "In DS Tăng Lương"
        '
        'radXuong
        '
        Me.radXuong.AutoSize = True
        Me.radXuong.Checked = True
        Me.radXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.radXuong.ForeColor = System.Drawing.Color.Blue
        Me.radXuong.Location = New System.Drawing.Point(35, 41)
        Me.radXuong.Name = "radXuong"
        Me.radXuong.Size = New System.Drawing.Size(61, 17)
        Me.radXuong.TabIndex = 15
        Me.radXuong.TabStop = True
        Me.radXuong.Text = "Xưởng"
        Me.radXuong.UseVisualStyleBackColor = True
        '
        'cbXuong
        '
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbXuong.DisplayMember = "TENXUONG"
        Me.cbXuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbXuong.Location = New System.Drawing.Point(99, 37)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(145, 24)
        Me.cbXuong.TabIndex = 16
        Me.cbXuong.ValueMember = "X_MA_"
        '
        'radDonvi
        '
        Me.radDonvi.AutoSize = True
        Me.radDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.radDonvi.ForeColor = System.Drawing.Color.Blue
        Me.radDonvi.Location = New System.Drawing.Point(267, 40)
        Me.radDonvi.Name = "radDonvi"
        Me.radDonvi.Size = New System.Drawing.Size(62, 17)
        Me.radDonvi.TabIndex = 17
        Me.radDonvi.Text = "Đơn vị"
        Me.radDonvi.UseVisualStyleBackColor = True
        '
        'radKhu
        '
        Me.radKhu.AutoSize = True
        Me.radKhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.radKhu.ForeColor = System.Drawing.Color.Blue
        Me.radKhu.Location = New System.Drawing.Point(623, 40)
        Me.radKhu.Name = "radKhu"
        Me.radKhu.Size = New System.Drawing.Size(47, 17)
        Me.radKhu.TabIndex = 17
        Me.radKhu.Text = "Khu"
        Me.radKhu.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cbKhu)
        Me.Panel1.Controls.Add(Me.radKhu)
        Me.Panel1.Controls.Add(Me.radDonvi)
        Me.Panel1.Controls.Add(Me.cbXuong)
        Me.Panel1.Controls.Add(Me.radXuong)
        Me.Panel1.Controls.Add(Me.btDSTangLuong)
        Me.Panel1.Controls.Add(Me.btIn)
        Me.Panel1.Controls.Add(Me.dtpDenNgay)
        Me.Panel1.Controls.Add(Me.cbDonvi)
        Me.Panel1.Controls.Add(Me.dtpTuNgay)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1129, 73)
        Me.Panel1.TabIndex = 0
        '
        'cbKhu
        '
        Me.cbKhu.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbKhu.DisplayMember = ""
        Me.cbKhu.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbKhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKhu.Location = New System.Drawing.Point(673, 36)
        Me.cbKhu.Name = "cbKhu"
        Me.cbKhu.Size = New System.Drawing.Size(134, 24)
        Me.cbKhu.TabIndex = 22
        Me.cbKhu.ValueMember = ""
        '
        'frmDanhSachHetHangHDKyLai
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1129, 464)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDanhSachHetHangHDKyLai"
        Me.ShowIcon = False
        Me.Text = "Danh Sách CB-CNV Hết Hạn HD Ký Lại"
        Me.Panel2.ResumeLayout(False)
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btIn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btDSTangLuong As Infragistics.Win.Misc.UltraButton
    Friend WithEvents radXuong As System.Windows.Forms.RadioButton
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents radDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents radKhu As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbKhu As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
