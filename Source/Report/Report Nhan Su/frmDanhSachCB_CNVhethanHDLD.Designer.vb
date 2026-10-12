<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachCB_CNVhethanHDLD
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
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.btIn = New Infragistics.Win.Misc.UltraButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radDonvi = New System.Windows.Forms.RadioButton
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.radXuong = New System.Windows.Forms.RadioButton
        Me.radKhu = New System.Windows.Forms.RadioButton
        Me.cbKhu = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptChamcong
        '
        Me.rptChamcong.ActiveViewIndex = -1
        Me.rptChamcong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptChamcong.DisplayGroupTree = False
        Me.rptChamcong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptChamcong.Location = New System.Drawing.Point(0, 72)
        Me.rptChamcong.Name = "rptChamcong"
        Me.rptChamcong.SelectionFormula = ""
        Me.rptChamcong.Size = New System.Drawing.Size(936, 520)
        Me.rptChamcong.TabIndex = 3
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(7, 12)
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
        Me.Label3.Location = New System.Drawing.Point(221, 12)
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
        Me.dtpTuNgay.Location = New System.Drawing.Point(76, 7)
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
        Me.cbDonvi.Location = New System.Drawing.Point(293, 37)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(281, 24)
        Me.cbDonvi.TabIndex = 3
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(293, 7)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(104, 22)
        Me.dtpDenNgay.TabIndex = 4
        '
        'btIn
        '
        Me.btIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btIn.Location = New System.Drawing.Point(474, 3)
        Me.btIn.Name = "btIn"
        Me.btIn.Size = New System.Drawing.Size(100, 23)
        Me.btIn.TabIndex = 3
        Me.btIn.Text = "In"
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
        Me.Panel1.Controls.Add(Me.btIn)
        Me.Panel1.Controls.Add(Me.dtpDenNgay)
        Me.Panel1.Controls.Add(Me.cbDonvi)
        Me.Panel1.Controls.Add(Me.dtpTuNgay)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 72)
        Me.Panel1.TabIndex = 1
        '
        'radDonvi
        '
        Me.radDonvi.AutoSize = True
        Me.radDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.radDonvi.ForeColor = System.Drawing.Color.Blue
        Me.radDonvi.Location = New System.Drawing.Point(230, 41)
        Me.radDonvi.Name = "radDonvi"
        Me.radDonvi.Size = New System.Drawing.Size(62, 17)
        Me.radDonvi.TabIndex = 19
        Me.radDonvi.Text = "Đơn vị"
        Me.radDonvi.UseVisualStyleBackColor = True
        '
        'cbXuong
        '
        Me.cbXuong.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbXuong.DisplayMember = "TENXUONG"
        Me.cbXuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbXuong.Location = New System.Drawing.Point(76, 37)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(145, 24)
        Me.cbXuong.TabIndex = 18
        Me.cbXuong.ValueMember = "X_MA_"
        '
        'radXuong
        '
        Me.radXuong.AutoSize = True
        Me.radXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.radXuong.ForeColor = System.Drawing.Color.Blue
        Me.radXuong.Location = New System.Drawing.Point(14, 40)
        Me.radXuong.Name = "radXuong"
        Me.radXuong.Size = New System.Drawing.Size(61, 17)
        Me.radXuong.TabIndex = 17
        Me.radXuong.Text = "Xưởng"
        Me.radXuong.UseVisualStyleBackColor = True
        '
        'radKhu
        '
        Me.radKhu.AutoSize = True
        Me.radKhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.radKhu.ForeColor = System.Drawing.Color.Blue
        Me.radKhu.Location = New System.Drawing.Point(606, 40)
        Me.radKhu.Name = "radKhu"
        Me.radKhu.Size = New System.Drawing.Size(47, 17)
        Me.radKhu.TabIndex = 20
        Me.radKhu.Text = "Khu"
        Me.radKhu.UseVisualStyleBackColor = True
        '
        'cbKhu
        '
        Me.cbKhu.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbKhu.DisplayMember = "TENXUONG"
        Me.cbKhu.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbKhu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKhu.Location = New System.Drawing.Point(659, 37)
        Me.cbKhu.Name = "cbKhu"
        Me.cbKhu.Size = New System.Drawing.Size(192, 24)
        Me.cbKhu.TabIndex = 21
        Me.cbKhu.ValueMember = "X_MA_"
        '
        'frmDanhSachCB_CNVhethanHDLD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 592)
        Me.Controls.Add(Me.rptChamcong)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDanhSachCB_CNVhethanHDLD"
        Me.Text = "Danh Sách CB-CBV hết hạn HDLĐ"
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbKhu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btIn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents radXuong As System.Windows.Forms.RadioButton
    Friend WithEvents radDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents cbKhu As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents radKhu As System.Windows.Forms.RadioButton
End Class
