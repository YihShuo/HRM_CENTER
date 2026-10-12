<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDanhSachCB_CNVBinhBauNam
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
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.btIn = New Infragistics.Win.Misc.UltraButton
        Me.cbNam = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.rptChamcong = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtSoThe = New System.Windows.Forms.TextBox
        Me.rdDonVi = New System.Windows.Forms.RadioButton
        Me.rdSoThe = New System.Windows.Forms.RadioButton
        Me.cbLoaiBB = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.cbDonVi = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.cbNam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cbLoaiBB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDonVi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btIn
        '
        Appearance1.ForeColor = System.Drawing.Color.Blue
        Me.btIn.Appearance = Appearance1
        Me.btIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btIn.Location = New System.Drawing.Point(945, 14)
        Me.btIn.Name = "btIn"
        Me.btIn.Size = New System.Drawing.Size(60, 31)
        Me.btIn.TabIndex = 3
        Me.btIn.Text = "In"
        '
        'cbNam
        '
        Me.cbNam.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbNam.DisplayMember = "DV_TEN"
        Me.cbNam.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem7.DataValue = "ValueListItem4"
        ValueListItem7.DisplayText = "2009"
        ValueListItem6.DataValue = "ValueListItem3"
        ValueListItem6.DisplayText = "2010"
        ValueListItem3.DataValue = "ValueListItem0"
        ValueListItem3.DisplayText = "2011"
        ValueListItem4.DataValue = "ValueListItem1"
        ValueListItem4.DisplayText = "2012"
        ValueListItem5.DataValue = "ValueListItem2"
        ValueListItem5.DisplayText = "2013"
        ValueListItem8.DataValue = "ValueListItem5"
        ValueListItem8.DisplayText = "2014"
        ValueListItem9.DataValue = "ValueListItem6"
        ValueListItem9.DisplayText = "2015"
        ValueListItem10.DataValue = "ValueListItem7"
        ValueListItem10.DisplayText = "2016"
        ValueListItem11.DataValue = "ValueListItem8"
        ValueListItem11.DisplayText = "2017"
        Me.cbNam.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem7, ValueListItem6, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11})
        Me.cbNam.Location = New System.Drawing.Point(55, 19)
        Me.cbNam.Name = "cbNam"
        Me.cbNam.Size = New System.Drawing.Size(109, 24)
        Me.cbNam.TabIndex = 3
        Me.cbNam.ValueMember = "DV_MA"
        '
        'rptChamcong
        '
        Me.rptChamcong.ActiveViewIndex = -1
        Me.rptChamcong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptChamcong.DisplayGroupTree = False
        Me.rptChamcong.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptChamcong.Location = New System.Drawing.Point(0, 60)
        Me.rptChamcong.Name = "rptChamcong"
        Me.rptChamcong.SelectionFormula = ""
        Me.rptChamcong.Size = New System.Drawing.Size(1013, 509)
        Me.rptChamcong.TabIndex = 5
        Me.rptChamcong.ViewTimeSelectionFormula = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(664, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Loại bình bầu :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtSoThe)
        Me.Panel1.Controls.Add(Me.rdDonVi)
        Me.Panel1.Controls.Add(Me.rdSoThe)
        Me.Panel1.Controls.Add(Me.cbLoaiBB)
        Me.Panel1.Controls.Add(Me.btIn)
        Me.Panel1.Controls.Add(Me.cbDonVi)
        Me.Panel1.Controls.Add(Me.cbNam)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1013, 60)
        Me.Panel1.TabIndex = 4
        '
        'txtSoThe
        '
        Me.txtSoThe.Location = New System.Drawing.Point(245, 24)
        Me.txtSoThe.Name = "txtSoThe"
        Me.txtSoThe.Size = New System.Drawing.Size(145, 20)
        Me.txtSoThe.TabIndex = 8
        '
        'rdDonVi
        '
        Me.rdDonVi.AutoSize = True
        Me.rdDonVi.Location = New System.Drawing.Point(396, 25)
        Me.rdDonVi.Name = "rdDonVi"
        Me.rdDonVi.Size = New System.Drawing.Size(59, 17)
        Me.rdDonVi.TabIndex = 7
        Me.rdDonVi.TabStop = True
        Me.rdDonVi.Text = "Đơn vị "
        Me.rdDonVi.UseVisualStyleBackColor = True
        '
        'rdSoThe
        '
        Me.rdSoThe.AutoSize = True
        Me.rdSoThe.Location = New System.Drawing.Point(183, 23)
        Me.rdSoThe.Name = "rdSoThe"
        Me.rdSoThe.Size = New System.Drawing.Size(56, 17)
        Me.rdSoThe.TabIndex = 6
        Me.rdSoThe.TabStop = True
        Me.rdSoThe.Text = "Số thẻ"
        Me.rdSoThe.UseVisualStyleBackColor = True
        '
        'cbLoaiBB
        '
        Me.cbLoaiBB.DisplayMember = "HV_TEN"
        Me.cbLoaiBB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem2.DataValue = "ValueListItem1"
        ValueListItem2.DisplayText = "Bình bầu năm chấm tay"
        ValueListItem1.DataValue = "ValueListItem0"
        ValueListItem1.DisplayText = "Bình bầu năm"
        Me.cbLoaiBB.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem2, ValueListItem1})
        Me.cbLoaiBB.Location = New System.Drawing.Point(762, 19)
        Me.cbLoaiBB.Name = "cbLoaiBB"
        Me.cbLoaiBB.Size = New System.Drawing.Size(177, 24)
        Me.cbLoaiBB.TabIndex = 5
        Me.cbLoaiBB.ValueMember = ""
        '
        'cbDonVi
        '
        Me.cbDonVi.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cbDonVi.DisplayMember = "DV_TEN"
        Me.cbDonVi.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbDonVi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDonVi.Location = New System.Drawing.Point(461, 23)
        Me.cbDonVi.Name = "cbDonVi"
        Me.cbDonVi.Size = New System.Drawing.Size(186, 24)
        Me.cbDonVi.TabIndex = 3
        Me.cbDonVi.ValueMember = "DV_MA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Năm :"
        '
        'frmDanhSachCB_CNVBinhBauNam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 569)
        Me.Controls.Add(Me.rptChamcong)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDanhSachCB_CNVBinhBauNam"
        Me.Text = "frmDanhSachCB_CNVBinhBauNam"
        CType(Me.cbNam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cbLoaiBB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDonVi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btIn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cbNam As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents rptChamcong As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbLoaiBB As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cbDonVi As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents rdSoThe As System.Windows.Forms.RadioButton
    Friend WithEvents rdDonVi As System.Windows.Forms.RadioButton
    Friend WithEvents txtSoThe As System.Windows.Forms.TextBox
End Class
