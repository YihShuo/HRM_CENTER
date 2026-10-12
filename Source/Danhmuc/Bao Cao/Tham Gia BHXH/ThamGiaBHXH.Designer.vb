<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ThamGiaBHXH
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btsk = New Infragistics.Win.Misc.UltraButton
        Me.dtpTuNgay = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDenNgay = New System.Windows.Forms.DateTimePicker
        Me.btIn = New Infragistics.Win.Misc.UltraButton
        Me.rptThamGiaBHXH = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btsk)
        Me.Panel1.Controls.Add(Me.dtpTuNgay)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtpDenNgay)
        Me.Panel1.Controls.Add(Me.btIn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(810, 52)
        Me.Panel1.TabIndex = 2
        '
        'btsk
        '
        Me.btsk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btsk.Location = New System.Drawing.Point(500, 14)
        Me.btsk.Name = "btsk"
        Me.btsk.Size = New System.Drawing.Size(113, 23)
        Me.btsk.TabIndex = 9
        Me.btsk.Text = "Giấy khám SK"
        '
        'dtpTuNgay
        '
        Me.dtpTuNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTuNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTuNgay.Location = New System.Drawing.Point(81, 14)
        Me.dtpTuNgay.Name = "dtpTuNgay"
        Me.dtpTuNgay.Size = New System.Drawing.Size(93, 22)
        Me.dtpTuNgay.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(196, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Đến Ngày :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Từ Ngày :"
        '
        'dtpDenNgay
        '
        Me.dtpDenNgay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenNgay.Location = New System.Drawing.Point(273, 14)
        Me.dtpDenNgay.Name = "dtpDenNgay"
        Me.dtpDenNgay.Size = New System.Drawing.Size(89, 22)
        Me.dtpDenNgay.TabIndex = 8
        '
        'btIn
        '
        Me.btIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btIn.Location = New System.Drawing.Point(394, 13)
        Me.btIn.Name = "btIn"
        Me.btIn.Size = New System.Drawing.Size(100, 23)
        Me.btIn.TabIndex = 3
        Me.btIn.Text = "In"
        '
        'rptThamGiaBHXH
        '
        Me.rptThamGiaBHXH.ActiveViewIndex = -1
        Me.rptThamGiaBHXH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptThamGiaBHXH.DisplayGroupTree = False
        Me.rptThamGiaBHXH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptThamGiaBHXH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rptThamGiaBHXH.Location = New System.Drawing.Point(0, 52)
        Me.rptThamGiaBHXH.Name = "rptThamGiaBHXH"
        Me.rptThamGiaBHXH.SelectionFormula = ""
        Me.rptThamGiaBHXH.Size = New System.Drawing.Size(810, 466)
        Me.rptThamGiaBHXH.TabIndex = 3
        Me.rptThamGiaBHXH.ViewTimeSelectionFormula = ""
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(619, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Danh sách khám SK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ThamGiaBHXH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 518)
        Me.Controls.Add(Me.rptThamGiaBHXH)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ThamGiaBHXH"
        Me.Text = "ThamGiaBHXH"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btIn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents rptThamGiaBHXH As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dtpTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDenNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents btsk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
