<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuyetdinhTV
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
        Me.rptqdtv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnin = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpk = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtsothe = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSoQuyetDinh = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtsothe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtSoQuyetDinh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptqdtv
        '
        Me.rptqdtv.ActiveViewIndex = -1
        Me.rptqdtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptqdtv.DisplayGroupTree = False
        Me.rptqdtv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptqdtv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rptqdtv.Location = New System.Drawing.Point(0, 81)
        Me.rptqdtv.Name = "rptqdtv"
        Me.rptqdtv.SelectionFormula = ""
        Me.rptqdtv.Size = New System.Drawing.Size(834, 286)
        Me.rptqdtv.TabIndex = 6
        Me.rptqdtv.ViewTimeSelectionFormula = ""
        '
        'btnin
        '
        Me.btnin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnin.Location = New System.Drawing.Point(558, 22)
        Me.btnin.Name = "btnin"
        Me.btnin.Size = New System.Drawing.Size(75, 23)
        Me.btnin.TabIndex = 5
        Me.btnin.Text = "In QĐTV"
        Me.btnin.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(18, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Số thẻ :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSoQuyetDinh)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpk)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtsothe)
        Me.GroupBox1.Controls.Add(Me.btnin)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(810, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Quyết định thôi việc"
        '
        'dtpk
        '
        Me.dtpk.CustomFormat = "dd/MM/yyyy"
        Me.dtpk.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpk.Location = New System.Drawing.Point(445, 25)
        Me.dtpk.Name = "dtpk"
        Me.dtpk.Size = New System.Drawing.Size(96, 20)
        Me.dtpk.TabIndex = 43
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(652, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 23)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "In phiếu hẹn lãnh lương"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtsothe
        '
        Me.txtsothe.Location = New System.Drawing.Point(68, 24)
        Me.txtsothe.Name = "txtsothe"
        Me.txtsothe.Size = New System.Drawing.Size(79, 21)
        Me.txtsothe.TabIndex = 41
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(834, 81)
        Me.Panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(168, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Số quyết định :"
        '
        'txtSoQuyetDinh
        '
        Me.txtSoQuyetDinh.Location = New System.Drawing.Point(253, 24)
        Me.txtSoQuyetDinh.Name = "txtSoQuyetDinh"
        Me.txtSoQuyetDinh.Size = New System.Drawing.Size(72, 21)
        Me.txtSoQuyetDinh.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(341, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Ngày nhận QĐTV :"
        '
        'frmQuyetdinhTV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 367)
        Me.Controls.Add(Me.rptqdtv)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmQuyetdinhTV"
        Me.Text = "Quyết định thôi việc"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtsothe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtSoQuyetDinh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptqdtv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnin As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtsothe As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtpk As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSoQuyetDinh As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
