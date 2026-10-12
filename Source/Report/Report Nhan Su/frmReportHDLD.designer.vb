<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportHDLD
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
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.rdDonvi = New System.Windows.Forms.RadioButton
        Me.rdNganh = New System.Windows.Forms.RadioButton
        Me.rdXuong = New System.Windows.Forms.RadioButton
        Me.cbNganh = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cbXuong = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cbDonvi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dtpDenngayNV = New System.Windows.Forms.DateTimePicker
        Me.dtpTungayNV = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dtpDenngayKHD = New System.Windows.Forms.DateTimePicker
        Me.dtpTungayKHD = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btXem = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.CollapsibleSplitter1 = New NJFLib.Controls.CollapsibleSplitter
        Me.UltraCalendarInfo1 = New Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.cbNganh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
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
        Me.rptChamcong.Size = New System.Drawing.Size(1026, 406)
        Me.rptChamcong.TabIndex = 1
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 161)
        Me.Panel1.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.UltraGroupBox3)
        Me.Panel4.Controls.Add(Me.UltraGroupBox2)
        Me.Panel4.Controls.Add(Me.UltraGroupBox1)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1028, 161)
        Me.Panel4.TabIndex = 1
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.rdDonvi)
        Me.UltraGroupBox3.Controls.Add(Me.rdNganh)
        Me.UltraGroupBox3.Controls.Add(Me.rdXuong)
        Me.UltraGroupBox3.Controls.Add(Me.cbNganh)
        Me.UltraGroupBox3.Controls.Add(Me.cbXuong)
        Me.UltraGroupBox3.Controls.Add(Me.cbDonvi)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(523, 5)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(492, 120)
        Me.UltraGroupBox3.TabIndex = 10
        Me.UltraGroupBox3.Text = "Điều Kiện Lọc Báo Cáo"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'rdDonvi
        '
        Me.rdDonvi.AutoSize = True
        Me.rdDonvi.Location = New System.Drawing.Point(17, 87)
        Me.rdDonvi.Name = "rdDonvi"
        Me.rdDonvi.Size = New System.Drawing.Size(62, 17)
        Me.rdDonvi.TabIndex = 12
        Me.rdDonvi.TabStop = True
        Me.rdDonvi.Text = "Đơn vị :"
        Me.rdDonvi.UseVisualStyleBackColor = True
        '
        'rdNganh
        '
        Me.rdNganh.AutoSize = True
        Me.rdNganh.Location = New System.Drawing.Point(17, 55)
        Me.rdNganh.Name = "rdNganh"
        Me.rdNganh.Size = New System.Drawing.Size(63, 17)
        Me.rdNganh.TabIndex = 11
        Me.rdNganh.TabStop = True
        Me.rdNganh.Text = "Ngành :"
        Me.rdNganh.UseVisualStyleBackColor = True
        '
        'rdXuong
        '
        Me.rdXuong.AutoSize = True
        Me.rdXuong.Location = New System.Drawing.Point(17, 23)
        Me.rdXuong.Name = "rdXuong"
        Me.rdXuong.Size = New System.Drawing.Size(62, 17)
        Me.rdXuong.TabIndex = 10
        Me.rdXuong.TabStop = True
        Me.rdXuong.Text = "Xưởng :"
        Me.rdXuong.UseVisualStyleBackColor = True
        '
        'cbNganh
        '
        Me.cbNganh.DisplayMember = "N_TEN"
        Me.cbNganh.Location = New System.Drawing.Point(85, 53)
        Me.cbNganh.Name = "cbNganh"
        Me.cbNganh.Size = New System.Drawing.Size(250, 21)
        Me.cbNganh.TabIndex = 9
        Me.cbNganh.ValueMember = "N_MA"
        '
        'cbXuong
        '
        Me.cbXuong.Location = New System.Drawing.Point(85, 21)
        Me.cbXuong.Name = "cbXuong"
        Me.cbXuong.Size = New System.Drawing.Size(250, 21)
        Me.cbXuong.TabIndex = 8
        '
        'cbDonvi
        '
        Me.cbDonvi.DisplayMember = "TEN_DV"
        Me.cbDonvi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonvi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonvi.Location = New System.Drawing.Point(85, 83)
        Me.cbDonvi.Name = "cbDonvi"
        Me.cbDonvi.Size = New System.Drawing.Size(250, 24)
        Me.cbDonvi.TabIndex = 7
        Me.cbDonvi.ValueMember = "DV_MA"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.dtpDenngayNV)
        Me.UltraGroupBox2.Controls.Add(Me.dtpTungayNV)
        Me.UltraGroupBox2.Controls.Add(Me.Label5)
        Me.UltraGroupBox2.Controls.Add(Me.Label3)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(267, 5)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(250, 120)
        Me.UltraGroupBox2.TabIndex = 10
        Me.UltraGroupBox2.Text = "Ngày Vào"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'dtpDenngayNV
        '
        Me.dtpDenngayNV.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenngayNV.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngayNV.Location = New System.Drawing.Point(91, 53)
        Me.dtpDenngayNV.Name = "dtpDenngayNV"
        Me.dtpDenngayNV.Size = New System.Drawing.Size(144, 20)
        Me.dtpDenngayNV.TabIndex = 7
        '
        'dtpTungayNV
        '
        Me.dtpTungayNV.CustomFormat = "dd/MM/yyyy"
        Me.dtpTungayNV.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungayNV.Location = New System.Drawing.Point(91, 21)
        Me.dtpTungayNV.Name = "dtpTungayNV"
        Me.dtpTungayNV.Size = New System.Drawing.Size(144, 20)
        Me.dtpTungayNV.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(24, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Đến Ngày :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(31, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Từ Ngày :"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.dtpDenngayKHD)
        Me.UltraGroupBox1.Controls.Add(Me.dtpTungayKHD)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 5)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(250, 120)
        Me.UltraGroupBox1.TabIndex = 9
        Me.UltraGroupBox1.Text = "Ngày Ký"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'dtpDenngayKHD
        '
        Me.dtpDenngayKHD.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenngayKHD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngayKHD.Location = New System.Drawing.Point(92, 53)
        Me.dtpDenngayKHD.Name = "dtpDenngayKHD"
        Me.dtpDenngayKHD.Size = New System.Drawing.Size(144, 20)
        Me.dtpDenngayKHD.TabIndex = 7
        '
        'dtpTungayKHD
        '
        Me.dtpTungayKHD.CustomFormat = "dd/MM/yyyy"
        Me.dtpTungayKHD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungayKHD.Location = New System.Drawing.Point(92, 21)
        Me.dtpTungayKHD.Name = "dtpTungayKHD"
        Me.dtpTungayKHD.Size = New System.Drawing.Size(144, 20)
        Me.dtpTungayKHD.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(25, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Đến Ngày :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(32, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Từ Ngày :"
        '
        'btXem
        '
        Me.btXem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btXem.ForeColor = System.Drawing.Color.Blue
        Me.btXem.Location = New System.Drawing.Point(11, 131)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(86, 25)
        Me.btXem.TabIndex = 8
        Me.btXem.Text = "Xem Report"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 161)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1028, 418)
        Me.Panel2.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.rptChamcong)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 10)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1028, 408)
        Me.Panel6.TabIndex = 14
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.CollapsibleSplitter1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1028, 10)
        Me.Panel5.TabIndex = 13
        '
        'CollapsibleSplitter1
        '
        Me.CollapsibleSplitter1.AnimationDelay = 20
        Me.CollapsibleSplitter1.AnimationStep = 20
        Me.CollapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat
        Me.CollapsibleSplitter1.ControlToHide = Me.Panel1
        Me.CollapsibleSplitter1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CollapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CollapsibleSplitter1.ExpandParentForm = False
        Me.CollapsibleSplitter1.Location = New System.Drawing.Point(0, 0)
        Me.CollapsibleSplitter1.Name = "CollapsibleSplitter1"
        Me.CollapsibleSplitter1.TabIndex = 13
        Me.CollapsibleSplitter1.TabStop = False
        Me.CollapsibleSplitter1.UseAnimations = False
        Me.CollapsibleSplitter1.VisualStyle = NJFLib.Controls.VisualStyles.Mozilla
        '
        'UltraCalendarInfo1
        '
        Me.UltraCalendarInfo1.DataBindingsForAppointments.BindingContextControl = Me
        Me.UltraCalendarInfo1.DataBindingsForOwners.BindingContextControl = Me
        '
        'frmReportHDLD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 579)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReportHDLD"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Danh Sách Nhân Viên Ký Hợp Đồng"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.cbNganh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbXuong, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDonvi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cbDonvi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UltraCalendarInfo1 As Infragistics.Win.UltraWinSchedule.UltraCalendarInfo
    Friend WithEvents cbNganh As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cbXuong As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents dtpDenngayNV As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungayNV As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDenngayKHD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTungayKHD As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdDonvi As System.Windows.Forms.RadioButton
    Friend WithEvents rdNganh As System.Windows.Forms.RadioButton
    Friend WithEvents rdXuong As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents CollapsibleSplitter1 As NJFLib.Controls.CollapsibleSplitter
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
End Class
