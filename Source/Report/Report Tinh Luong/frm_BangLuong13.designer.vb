<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_BangLuong13
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rptBangLuong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btXem = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblDVXUONG = New System.Windows.Forms.Label
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.dtpNam = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.rdXuong = New System.Windows.Forms.RadioButton
        Me.rdDV = New System.Windows.Forms.RadioButton
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rptBangLuong)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(740, 363)
        Me.Panel2.TabIndex = 5
        '
        'rptBangLuong
        '
        Me.rptBangLuong.ActiveViewIndex = -1
        Me.rptBangLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptBangLuong.DisplayGroupTree = False
        Me.rptBangLuong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptBangLuong.Location = New System.Drawing.Point(0, 0)
        Me.rptBangLuong.Name = "rptBangLuong"
        Me.rptBangLuong.SelectionFormula = ""
        Me.rptBangLuong.Size = New System.Drawing.Size(740, 363)
        Me.rptBangLuong.TabIndex = 1
        Me.rptBangLuong.ViewTimeSelectionFormula = ""
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(635, 21)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(95, 35)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(740, 89)
        Me.Panel1.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.rdDV)
        Me.Panel4.Controls.Add(Me.rdXuong)
        Me.Panel4.Controls.Add(Me.lblDVXUONG)
        Me.Panel4.Controls.Add(Me.cbDonvi)
        Me.Panel4.Controls.Add(Me.dtpNam)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(740, 89)
        Me.Panel4.TabIndex = 1
        '
        'lblDVXUONG
        '
        Me.lblDVXUONG.AutoSize = True
        Me.lblDVXUONG.Location = New System.Drawing.Point(244, 34)
        Me.lblDVXUONG.Name = "lblDVXUONG"
        Me.lblDVXUONG.Size = New System.Drawing.Size(41, 13)
        Me.lblDVXUONG.TabIndex = 21
        Me.lblDVXUONG.Text = "Đơn vị:"
        '
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(291, 25)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(310, 24)
        Me.cbDonvi.TabIndex = 20
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'dtpNam
        '
        Me.dtpNam.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNam.CustomFormat = "yyyy"
        Me.dtpNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNam.Location = New System.Drawing.Point(44, 27)
        Me.dtpNam.Name = "dtpNam"
        Me.dtpNam.Size = New System.Drawing.Size(89, 22)
        Me.dtpNam.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Năm:"
        '
        'rdXuong
        '
        Me.rdXuong.AutoSize = True
        Me.rdXuong.Location = New System.Drawing.Point(160, 11)
        Me.rdXuong.Name = "rdXuong"
        Me.rdXuong.Size = New System.Drawing.Size(62, 17)
        Me.rdXuong.TabIndex = 22
        Me.rdXuong.TabStop = True
        Me.rdXuong.Text = "Xưởng :"
        Me.rdXuong.UseVisualStyleBackColor = True
        '
        'rdDV
        '
        Me.rdDV.AutoSize = True
        Me.rdDV.Location = New System.Drawing.Point(160, 39)
        Me.rdDV.Name = "rdDV"
        Me.rdDV.Size = New System.Drawing.Size(62, 17)
        Me.rdDV.TabIndex = 23
        Me.rdDV.TabStop = True
        Me.rdDV.Text = "Đơn vị :"
        Me.rdDV.UseVisualStyleBackColor = True
        '
        'frm_BangLuong13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 452)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_BangLuong13"
        Me.Text = "Bảng lương tháng 13"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rptBangLuong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblDVXUONG As System.Windows.Forms.Label
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpNam As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rdDV As System.Windows.Forms.RadioButton
    Friend WithEvents rdXuong As System.Windows.Forms.RadioButton
End Class
