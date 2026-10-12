<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDSCNVKhongQuetTheVaoRa
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btXemrport = New Infragistics.Win.Misc.UltraButton
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkKQTRa = New System.Windows.Forms.CheckBox
        Me.chkKQTVao = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdDonvi = New System.Windows.Forms.CheckBox
        Me.Panel2.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptChamcong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1000, 614)
        Me.Panel2.TabIndex = 5
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
        Me.rptChamcong.Size = New System.Drawing.Size(1000, 614)
        Me.rptChamcong.TabIndex = 1
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'btXemrport
        '
        Appearance1.ForeColor = System.Drawing.Color.Blue
        Me.btXemrport.Appearance = Appearance1
        Me.btXemrport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXemrport.Location = New System.Drawing.Point(511, 38)
        Me.btXemrport.Name = "btXemrport"
        Me.btXemrport.Size = New System.Drawing.Size(101, 37)
        Me.btXemrport.TabIndex = 9
        Me.btXemrport.Text = "Xem Báo Cáo"
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "dd-MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(89, 19)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(96, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(33, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ngày :"
        '
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(88, 44)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(365, 24)
        Me.cbDonvi.TabIndex = 7
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.btXemrport)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1000, 89)
        Me.Panel4.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdDonvi)
        Me.GroupBox1.Controls.Add(Me.chkKQTRa)
        Me.GroupBox1.Controls.Add(Me.chkKQTVao)
        Me.GroupBox1.Controls.Add(Me.cbDonvi)
        Me.GroupBox1.Controls.Add(Me.dtpNgay)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 73)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'chkKQTRa
        '
        Me.chkKQTRa.AutoSize = True
        Me.chkKQTRa.ForeColor = System.Drawing.Color.Blue
        Me.chkKQTRa.Location = New System.Drawing.Point(331, 23)
        Me.chkKQTRa.Name = "chkKQTRa"
        Me.chkKQTRa.Size = New System.Drawing.Size(111, 17)
        Me.chkKQTRa.TabIndex = 13
        Me.chkKQTRa.Text = "Không quẹt thẻ ra"
        Me.chkKQTRa.UseVisualStyleBackColor = True
        '
        'chkKQTVao
        '
        Me.chkKQTVao.AutoSize = True
        Me.chkKQTVao.ForeColor = System.Drawing.Color.Blue
        Me.chkKQTVao.Location = New System.Drawing.Point(207, 22)
        Me.chkKQTVao.Name = "chkKQTVao"
        Me.chkKQTVao.Size = New System.Drawing.Size(120, 17)
        Me.chkKQTVao.TabIndex = 13
        Me.chkKQTVao.Text = "Không quẹt thẻ vào"
        Me.chkKQTVao.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 89)
        Me.Panel1.TabIndex = 4
        '
        'rdDonvi
        '
        Me.rdDonvi.AutoSize = True
        Me.rdDonvi.ForeColor = System.Drawing.Color.Blue
        Me.rdDonvi.Location = New System.Drawing.Point(25, 48)
        Me.rdDonvi.Name = "rdDonvi"
        Me.rdDonvi.Size = New System.Drawing.Size(60, 17)
        Me.rdDonvi.TabIndex = 14
        Me.rdDonvi.Text = "Đơn vị "
        Me.rdDonvi.UseVisualStyleBackColor = True
        '
        'frmDSCNVKhongQuetTheVaoRa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 703)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDSCNVKhongQuetTheVaoRa"
        Me.Text = "frmDSCNVKhongQuetTheVaoRa"
        Me.Panel2.ResumeLayout(False)
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btXemrport As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkKQTRa As System.Windows.Forms.CheckBox
    Friend WithEvents chkKQTVao As System.Windows.Forms.CheckBox
    Friend WithEvents rdDonvi As System.Windows.Forms.CheckBox
End Class
