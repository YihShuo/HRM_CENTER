<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachNhanVienTrungTuyen
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btIn = New Infragistics.Win.Misc.UltraButton
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel1.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.radTCT)
        Me.Panel1.Controls.Add(Me.radKhuB)
        Me.Panel1.Controls.Add(Me.dtpTuNgay)
        Me.Panel1.Controls.Add(Me.radKhuA)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btIn)
        Me.Panel1.Controls.Add(Me.dtpDenNgay)
        Me.Panel1.Controls.Add(Me.cbDonvi)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 101)
        Me.Panel1.TabIndex = 0
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radTCT.ForeColor = System.Drawing.Color.Blue
        Me.radTCT.Location = New System.Drawing.Point(206, 64)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(88, 17)
        Me.radTCT.TabIndex = 2
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "Toàn công ty"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuB.ForeColor = System.Drawing.Color.Blue
        Me.radKhuB.Location = New System.Drawing.Point(206, 41)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 1
        Me.radKhuB.TabStop = True
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radKhuA.ForeColor = System.Drawing.Color.Blue
        Me.radKhuA.Location = New System.Drawing.Point(206, 16)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 0
        Me.radKhuA.TabStop = True
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTuNgay.Location = New System.Drawing.Point(84, 16)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(93, 22)
        Me.dtpTuNgay.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(11, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Đến Ngày :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(15, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Từ Ngày :"
        '
        'btIn
        '
        Me.btIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btIn.Location = New System.Drawing.Point(331, 51)
        Me.btIn.Name = "btIn"
        Me.btIn.Size = New System.Drawing.Size(100, 29)
        Me.btIn.TabIndex = 3
        Me.btIn.Text = "In"
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(84, 58)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(93, 22)
        Me.dtpDenNgay.TabIndex = 4
        '
        'cbDonvi
        '
        Me.cbDonvi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbDonvi.DisplayMember = "DV_TEN"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(561, 16)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(66, 24)
        Me.cbDonvi.TabIndex = 3
        Me.cbDonvi.ValueMember = "DV_MA"
        Me.cbDonvi.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(558, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Đơn Vị :"
        Me.Label2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rptChamcong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(640, 363)
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
        Me.rptChamcong.Size = New System.Drawing.Size(638, 361)
        Me.rptChamcong.TabIndex = 2
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'frmDanhSachNhanVienTrungTuyen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 464)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDanhSachNhanVienTrungTuyen"
        Me.ShowIcon = False
        Me.Text = "Danh Sách Nhân Viên Trúng Tuyển"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btIn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
End Class
