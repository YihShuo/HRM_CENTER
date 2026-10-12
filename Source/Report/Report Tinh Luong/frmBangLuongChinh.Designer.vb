<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBangLuongChinh
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdXuong = New System.Windows.Forms.RadioButton
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdDonvi = New System.Windows.Forms.RadioButton
        Me.cboXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btXem = New System.Windows.Forms.Button
        Me.rptBangLuong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdXuong)
        Me.GroupBox1.Controls.Add(Me.cbDonvi)
        Me.GroupBox1.Controls.Add(Me.dtpNgay)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rdDonvi)
        Me.GroupBox1.Controls.Add(Me.cboXuong)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(708, 46)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'rdXuong
        '
        Me.rdXuong.AutoSize = True
        Me.rdXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdXuong.ForeColor = System.Drawing.Color.Blue
        Me.rdXuong.Location = New System.Drawing.Point(164, 16)
        Me.rdXuong.Name = "rdXuong"
        Me.rdXuong.Size = New System.Drawing.Size(61, 17)
        Me.rdXuong.TabIndex = 12
        Me.rdXuong.TabStop = True
        Me.rdXuong.Text = "Xưởng"
        Me.rdXuong.UseVisualStyleBackColor = True
        '
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(329, 12)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(367, 24)
        Me.cbDonvi.TabIndex = 7
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(70, 13)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(75, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tháng :"
        '
        'rdDonvi
        '
        Me.rdDonvi.AutoSize = True
        Me.rdDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDonvi.ForeColor = System.Drawing.Color.Blue
        Me.rdDonvi.Location = New System.Drawing.Point(257, 16)
        Me.rdDonvi.Name = "rdDonvi"
        Me.rdDonvi.Size = New System.Drawing.Size(63, 17)
        Me.rdDonvi.TabIndex = 12
        Me.rdDonvi.TabStop = True
        Me.rdDonvi.Text = "Đơn Vị"
        Me.rdDonvi.UseVisualStyleBackColor = True
        '
        'cboXuong
        '
        Me.cboXuong.DisplayMember = ""
        Me.cboXuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cboXuong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboXuong.Location = New System.Drawing.Point(329, 12)
        Me.cboXuong.Name = "cboXuong"
        Me.cboXuong.Size = New System.Drawing.Size(367, 24)
        Me.cboXuong.TabIndex = 13
        Me.cboXuong.ValueMember = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 83)
        Me.Panel1.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1028, 83)
        Me.Panel4.TabIndex = 1
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(733, 24)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(83, 35)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'rptBangLuong
        '
        Me.rptBangLuong.ActiveViewIndex = -1
        Me.rptBangLuong.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptBangLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptBangLuong.DisplayGroupTree = False
        Me.rptBangLuong.Location = New System.Drawing.Point(0, 89)
        Me.rptBangLuong.Name = "rptBangLuong"
        Me.rptBangLuong.SelectionFormula = ""
        Me.rptBangLuong.Size = New System.Drawing.Size(1034, 476)
        Me.rptBangLuong.TabIndex = 1
        Me.rptBangLuong.ViewTimeSelectionFormula = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptBangLuong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1028, 565)
        Me.Panel2.TabIndex = 7
        '
        'frmBangLuongChinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 565)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmBangLuongChinh"
        Me.Text = "frmBangLuongChinh"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboXuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rptBangLuong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdXuong As System.Windows.Forms.RadioButton
    Friend WithEvents cboXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
End Class
