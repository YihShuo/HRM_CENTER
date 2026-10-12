<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChamcongex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChamcongex))
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dtpDenngay = New System.Windows.Forms.DateTimePicker
        Me.dtpTungay = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.txtGioihantangcatoida = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtGiailaotangca = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtTinhlamdemtuluc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTinhducongkhididu = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtHesongaycong = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.chbtinhducongkhididu = New System.Windows.Forms.CheckBox
        Me.chbtinhlamdemtuluc = New System.Windows.Forms.CheckBox
        Me.chbgiailaotangca = New System.Windows.Forms.CheckBox
        Me.chbhesongaycong = New System.Windows.Forms.Label
        Me.chbgioihantangcatoida = New System.Windows.Forms.CheckBox
        Me.chbluontinhditre = New System.Windows.Forms.CheckBox
        Me.chbluontinhquenquetthe = New System.Windows.Forms.CheckBox
        Me.chbkhongtinhquenquetthe = New System.Windows.Forms.CheckBox
        Me.chbkhongtinhditre = New System.Windows.Forms.CheckBox
        Me.chbtinhtangca = New System.Windows.Forms.CheckBox
        Me.chbLuontinhducong = New System.Windows.Forms.CheckBox
        Me.cbChamcong = New System.Windows.Forms.Button
        Me.cbDong = New System.Windows.Forms.Button
        Me.chkVaoSom = New System.Windows.Forms.CheckBox
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.txtGioihantangcatoida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGiailaotangca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTinhlamdemtuluc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTinhducongkhididu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHesongaycong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox1.Controls.Add(Me.dtpDenngay)
        Me.UltraGroupBox1.Controls.Add(Me.dtpTungay)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Controls.Add(Me.Label1)
        Me.UltraGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.UltraGroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(339, 56)
        Me.UltraGroupBox1.TabIndex = 0
        Me.UltraGroupBox1.Text = "Thời gian chấm công"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'dtpDenngay
        '
        Me.dtpDenngay.CustomFormat = "dd/MM/yyyy"
        Me.dtpDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDenngay.Location = New System.Drawing.Point(239, 23)
        Me.dtpDenngay.Name = "dtpDenngay"
        Me.dtpDenngay.Size = New System.Drawing.Size(83, 22)
        Me.dtpDenngay.TabIndex = 2
        '
        'dtpTungay
        '
        Me.dtpTungay.CustomFormat = "dd/MM/yyyy"
        Me.dtpTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTungay.Location = New System.Drawing.Point(81, 24)
        Me.dtpTungay.Name = "dtpTungay"
        Me.dtpTungay.Size = New System.Drawing.Size(83, 22)
        Me.dtpTungay.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(168, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Đến ngày"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Từ ngày"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox2.Appearance = Appearance1
        Me.UltraGroupBox2.Controls.Add(Me.txtGioihantangcatoida)
        Me.UltraGroupBox2.Controls.Add(Me.txtGiailaotangca)
        Me.UltraGroupBox2.Controls.Add(Me.txtTinhlamdemtuluc)
        Me.UltraGroupBox2.Controls.Add(Me.Label6)
        Me.UltraGroupBox2.Controls.Add(Me.Label5)
        Me.UltraGroupBox2.Controls.Add(Me.Label4)
        Me.UltraGroupBox2.Controls.Add(Me.txtTinhducongkhididu)
        Me.UltraGroupBox2.Controls.Add(Me.txtHesongaycong)
        Me.UltraGroupBox2.Controls.Add(Me.chbtinhducongkhididu)
        Me.UltraGroupBox2.Controls.Add(Me.chbtinhlamdemtuluc)
        Me.UltraGroupBox2.Controls.Add(Me.chbgiailaotangca)
        Me.UltraGroupBox2.Controls.Add(Me.chbhesongaycong)
        Me.UltraGroupBox2.Controls.Add(Me.chbgioihantangcatoida)
        Me.UltraGroupBox2.Controls.Add(Me.chbluontinhditre)
        Me.UltraGroupBox2.Controls.Add(Me.chbluontinhquenquetthe)
        Me.UltraGroupBox2.Controls.Add(Me.chbkhongtinhquenquetthe)
        Me.UltraGroupBox2.Controls.Add(Me.chbkhongtinhditre)
        Me.UltraGroupBox2.Controls.Add(Me.chbtinhtangca)
        Me.UltraGroupBox2.Controls.Add(Me.chkVaoSom)
        Me.UltraGroupBox2.Controls.Add(Me.chbLuontinhducong)
        Me.UltraGroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGroupBox2.ForeColor = System.Drawing.Color.Black
        Me.UltraGroupBox2.Location = New System.Drawing.Point(4, 61)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(339, 338)
        Me.UltraGroupBox2.TabIndex = 0
        Me.UltraGroupBox2.Text = "Quy định"
        Me.UltraGroupBox2.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'txtGioihantangcatoida
        '
        Me.txtGioihantangcatoida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGioihantangcatoida.Location = New System.Drawing.Point(180, 203)
        Me.txtGioihantangcatoida.MaxLength = 1
        Me.txtGioihantangcatoida.Name = "txtGioihantangcatoida"
        Me.txtGioihantangcatoida.Size = New System.Drawing.Size(72, 21)
        Me.txtGioihantangcatoida.TabIndex = 14
        Me.txtGioihantangcatoida.Text = "3"
        '
        'txtGiailaotangca
        '
        Me.txtGiailaotangca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGiailaotangca.Location = New System.Drawing.Point(180, 230)
        Me.txtGiailaotangca.MaxLength = 2
        Me.txtGiailaotangca.Name = "txtGiailaotangca"
        Me.txtGiailaotangca.Size = New System.Drawing.Size(72, 21)
        Me.txtGiailaotangca.TabIndex = 13
        Me.txtGiailaotangca.Text = "30"
        '
        'txtTinhlamdemtuluc
        '
        Me.txtTinhlamdemtuluc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTinhlamdemtuluc.Location = New System.Drawing.Point(180, 256)
        Me.txtTinhlamdemtuluc.MaxLength = 5
        Me.txtTinhlamdemtuluc.Name = "txtTinhlamdemtuluc"
        Me.txtTinhlamdemtuluc.Size = New System.Drawing.Size(72, 21)
        Me.txtTinhlamdemtuluc.TabIndex = 12
        Me.txtTinhlamdemtuluc.Text = "20:00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(258, 284)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Giờ"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(258, 232)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Phút"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(258, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Giờ"
        '
        'txtTinhducongkhididu
        '
        Me.txtTinhducongkhididu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTinhducongkhididu.Location = New System.Drawing.Point(180, 282)
        Me.txtTinhducongkhididu.MaxLength = 1
        Me.txtTinhducongkhididu.Name = "txtTinhducongkhididu"
        Me.txtTinhducongkhididu.Size = New System.Drawing.Size(72, 21)
        Me.txtTinhducongkhididu.TabIndex = 11
        Me.txtTinhducongkhididu.Text = "7"
        '
        'txtHesongaycong
        '
        Me.txtHesongaycong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHesongaycong.Location = New System.Drawing.Point(180, 308)
        Me.txtHesongaycong.MaxLength = 1
        Me.txtHesongaycong.Name = "txtHesongaycong"
        Me.txtHesongaycong.Size = New System.Drawing.Size(72, 21)
        Me.txtHesongaycong.TabIndex = 10
        Me.txtHesongaycong.Text = "0"
        '
        'chbtinhducongkhididu
        '
        Me.chbtinhducongkhididu.AutoSize = True
        Me.chbtinhducongkhididu.Location = New System.Drawing.Point(21, 282)
        Me.chbtinhducongkhididu.Name = "chbtinhducongkhididu"
        Me.chbtinhducongkhididu.Size = New System.Drawing.Size(156, 20)
        Me.chbtinhducongkhididu.TabIndex = 9
        Me.chbtinhducongkhididu.Text = "Tính đủ công khi đi đủ"
        Me.chbtinhducongkhididu.UseVisualStyleBackColor = True
        '
        'chbtinhlamdemtuluc
        '
        Me.chbtinhlamdemtuluc.AutoSize = True
        Me.chbtinhlamdemtuluc.Location = New System.Drawing.Point(21, 256)
        Me.chbtinhlamdemtuluc.Name = "chbtinhlamdemtuluc"
        Me.chbtinhlamdemtuluc.Size = New System.Drawing.Size(141, 20)
        Me.chbtinhlamdemtuluc.TabIndex = 8
        Me.chbtinhlamdemtuluc.Text = "Tính làm đêm từ lúc"
        Me.chbtinhlamdemtuluc.UseVisualStyleBackColor = True
        '
        'chbgiailaotangca
        '
        Me.chbgiailaotangca.AutoSize = True
        Me.chbgiailaotangca.Location = New System.Drawing.Point(21, 230)
        Me.chbgiailaotangca.Name = "chbgiailaotangca"
        Me.chbgiailaotangca.Size = New System.Drawing.Size(120, 20)
        Me.chbgiailaotangca.TabIndex = 7
        Me.chbgiailaotangca.Text = "Giải lao tăng ca"
        Me.chbgiailaotangca.UseVisualStyleBackColor = True
        '
        'chbhesongaycong
        '
        Me.chbhesongaycong.AutoSize = True
        Me.chbhesongaycong.ForeColor = System.Drawing.Color.Black
        Me.chbhesongaycong.Location = New System.Drawing.Point(36, 310)
        Me.chbhesongaycong.Name = "chbhesongaycong"
        Me.chbhesongaycong.Size = New System.Drawing.Size(110, 16)
        Me.chbhesongaycong.TabIndex = 0
        Me.chbhesongaycong.Text = "Hệ số ngày công"
        '
        'chbgioihantangcatoida
        '
        Me.chbgioihantangcatoida.AutoSize = True
        Me.chbgioihantangcatoida.Location = New System.Drawing.Point(21, 203)
        Me.chbgioihantangcatoida.Name = "chbgioihantangcatoida"
        Me.chbgioihantangcatoida.Size = New System.Drawing.Size(159, 20)
        Me.chbgioihantangcatoida.TabIndex = 6
        Me.chbgioihantangcatoida.Text = "Giới hạn tăng ca tối đa"
        Me.chbgioihantangcatoida.UseVisualStyleBackColor = True
        '
        'chbluontinhditre
        '
        Me.chbluontinhditre.AutoSize = True
        Me.chbluontinhditre.Location = New System.Drawing.Point(21, 177)
        Me.chbluontinhditre.Name = "chbluontinhditre"
        Me.chbluontinhditre.Size = New System.Drawing.Size(111, 20)
        Me.chbluontinhditre.TabIndex = 5
        Me.chbluontinhditre.Text = "Luôn tính đi trễ"
        Me.chbluontinhditre.UseVisualStyleBackColor = True
        '
        'chbluontinhquenquetthe
        '
        Me.chbluontinhquenquetthe.AutoSize = True
        Me.chbluontinhquenquetthe.Location = New System.Drawing.Point(21, 151)
        Me.chbluontinhquenquetthe.Name = "chbluontinhquenquetthe"
        Me.chbluontinhquenquetthe.Size = New System.Drawing.Size(162, 20)
        Me.chbluontinhquenquetthe.TabIndex = 4
        Me.chbluontinhquenquetthe.Text = "Luôn tính quên quét thẻ"
        Me.chbluontinhquenquetthe.UseVisualStyleBackColor = True
        '
        'chbkhongtinhquenquetthe
        '
        Me.chbkhongtinhquenquetthe.AutoSize = True
        Me.chbkhongtinhquenquetthe.Location = New System.Drawing.Point(21, 125)
        Me.chbkhongtinhquenquetthe.Name = "chbkhongtinhquenquetthe"
        Me.chbkhongtinhquenquetthe.Size = New System.Drawing.Size(171, 20)
        Me.chbkhongtinhquenquetthe.TabIndex = 3
        Me.chbkhongtinhquenquetthe.Text = "Không tính quên quét thẻ"
        Me.chbkhongtinhquenquetthe.UseVisualStyleBackColor = True
        '
        'chbkhongtinhditre
        '
        Me.chbkhongtinhditre.AutoSize = True
        Me.chbkhongtinhditre.Location = New System.Drawing.Point(21, 99)
        Me.chbkhongtinhditre.Name = "chbkhongtinhditre"
        Me.chbkhongtinhditre.Size = New System.Drawing.Size(120, 20)
        Me.chbkhongtinhditre.TabIndex = 2
        Me.chbkhongtinhditre.Text = "Không tính đi trễ"
        Me.chbkhongtinhditre.UseVisualStyleBackColor = True
        '
        'chbtinhtangca
        '
        Me.chbtinhtangca.AutoSize = True
        Me.chbtinhtangca.Location = New System.Drawing.Point(21, 73)
        Me.chbtinhtangca.Name = "chbtinhtangca"
        Me.chbtinhtangca.Size = New System.Drawing.Size(100, 20)
        Me.chbtinhtangca.TabIndex = 1
        Me.chbtinhtangca.Text = "Tính tăng ca"
        Me.chbtinhtangca.UseVisualStyleBackColor = True
        '
        'chbLuontinhducong
        '
        Me.chbLuontinhducong.AutoSize = True
        Me.chbLuontinhducong.Location = New System.Drawing.Point(21, 47)
        Me.chbLuontinhducong.Name = "chbLuontinhducong"
        Me.chbLuontinhducong.Size = New System.Drawing.Size(130, 20)
        Me.chbLuontinhducong.TabIndex = 0
        Me.chbLuontinhducong.Text = "Luôn tính đủ công"
        Me.chbLuontinhducong.UseVisualStyleBackColor = True
        '
        'cbChamcong
        '
        Me.cbChamcong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbChamcong.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbChamcong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbChamcong.Location = New System.Drawing.Point(147, 405)
        Me.cbChamcong.Name = "cbChamcong"
        Me.cbChamcong.Size = New System.Drawing.Size(95, 27)
        Me.cbChamcong.TabIndex = 1
        Me.cbChamcong.Text = "Chấm công"
        Me.cbChamcong.UseVisualStyleBackColor = False
        '
        'cbDong
        '
        Me.cbDong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDong.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.cbDong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDong.Location = New System.Drawing.Point(248, 405)
        Me.cbDong.Name = "cbDong"
        Me.cbDong.Size = New System.Drawing.Size(95, 27)
        Me.cbDong.TabIndex = 2
        Me.cbDong.Text = "Đóng"
        Me.cbDong.UseVisualStyleBackColor = False
        '
        'chkVaoSom
        '
        Me.chkVaoSom.AutoSize = True
        Me.chkVaoSom.Location = New System.Drawing.Point(21, 22)
        Me.chkVaoSom.Name = "chkVaoSom"
        Me.chkVaoSom.Size = New System.Drawing.Size(129, 20)
        Me.chkVaoSom.TabIndex = 0
        Me.chkVaoSom.Text = "Tính tăng ca sớm"
        Me.chkVaoSom.UseVisualStyleBackColor = True
        '
        'frmChamcongex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 436)
        Me.Controls.Add(Me.cbDong)
        Me.Controls.Add(Me.cbChamcong)
        Me.Controls.Add(Me.UltraGroupBox2)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChamcongex"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chấm công máy"
        Me.TopMost = True
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.txtGioihantangcatoida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGiailaotangca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTinhlamdemtuluc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTinhducongkhididu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHesongaycong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpTungay As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDenngay As System.Windows.Forms.DateTimePicker
    Friend WithEvents chbtinhducongkhididu As System.Windows.Forms.CheckBox
    Friend WithEvents chbtinhlamdemtuluc As System.Windows.Forms.CheckBox
    Friend WithEvents chbgiailaotangca As System.Windows.Forms.CheckBox
    Friend WithEvents chbgioihantangcatoida As System.Windows.Forms.CheckBox
    Friend WithEvents chbluontinhditre As System.Windows.Forms.CheckBox
    Friend WithEvents chbluontinhquenquetthe As System.Windows.Forms.CheckBox
    Friend WithEvents chbkhongtinhquenquetthe As System.Windows.Forms.CheckBox
    Friend WithEvents chbkhongtinhditre As System.Windows.Forms.CheckBox
    Friend WithEvents chbtinhtangca As System.Windows.Forms.CheckBox
    Friend WithEvents chbLuontinhducong As System.Windows.Forms.CheckBox
    Friend WithEvents chbhesongaycong As System.Windows.Forms.Label
    Friend WithEvents cbChamcong As System.Windows.Forms.Button
    Friend WithEvents cbDong As System.Windows.Forms.Button
    Friend WithEvents txtGioihantangcatoida As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtGiailaotangca As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTinhlamdemtuluc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtTinhducongkhididu As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtHesongaycong As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkVaoSom As System.Windows.Forms.CheckBox
End Class
