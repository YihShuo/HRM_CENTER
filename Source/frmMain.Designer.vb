<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.btnNhanSu = New Infragistics.Win.Misc.UltraButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnKeToan = New Infragistics.Win.Misc.UltraButton
        Me.btnChamCong = New Infragistics.Win.Misc.UltraButton
        Me.btnTuyenDung = New Infragistics.Win.Misc.UltraButton
        Me.btndanhgiahieuquacongviec = New Infragistics.Win.Misc.UltraButton
        Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox
        Me.SuspendLayout()
        '
        'btnNhanSu
        '
        Appearance2.Image = "User-Files-icon.png"
        Me.btnNhanSu.Appearance = Appearance2
        Me.btnNhanSu.Enabled = False
        Me.btnNhanSu.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNhanSu.ImageList = Me.ImageList1
        Me.btnNhanSu.ImageSize = New System.Drawing.Size(50, 50)
        Me.btnNhanSu.Location = New System.Drawing.Point(37, 111)
        Me.btnNhanSu.Name = "btnNhanSu"
        Me.btnNhanSu.Size = New System.Drawing.Size(230, 73)
        Me.btnNhanSu.TabIndex = 1
        Me.btnNhanSu.Text = "NHÂN SỰ"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Money-icon.png")
        Me.ImageList1.Images.SetKeyName(1, "Time-Machine-icon.png")
        Me.ImageList1.Images.SetKeyName(2, "User-Files-icon.png")
        Me.ImageList1.Images.SetKeyName(3, "user-search-icon.png")
        Me.ImageList1.Images.SetKeyName(4, "icon-review-75f1504aff4e75b84b5abf307b21688e.png")
        '
        'btnKeToan
        '
        Appearance3.Image = "Money-icon.png"
        Me.btnKeToan.Appearance = Appearance3
        Me.btnKeToan.Enabled = False
        Me.btnKeToan.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeToan.ImageList = Me.ImageList1
        Me.btnKeToan.ImageSize = New System.Drawing.Size(50, 50)
        Me.btnKeToan.Location = New System.Drawing.Point(310, 200)
        Me.btnKeToan.Name = "btnKeToan"
        Me.btnKeToan.Size = New System.Drawing.Size(230, 73)
        Me.btnKeToan.TabIndex = 2
        Me.btnKeToan.Text = "TÍNH LƯƠNG"
        '
        'btnChamCong
        '
        Appearance4.Image = "Time-Machine-icon.png"
        Me.btnChamCong.Appearance = Appearance4
        Me.btnChamCong.Enabled = False
        Me.btnChamCong.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChamCong.ImageList = Me.ImageList1
        Me.btnChamCong.ImageSize = New System.Drawing.Size(50, 50)
        Me.btnChamCong.Location = New System.Drawing.Point(310, 111)
        Me.btnChamCong.Name = "btnChamCong"
        Me.btnChamCong.Size = New System.Drawing.Size(230, 73)
        Me.btnChamCong.TabIndex = 3
        Me.btnChamCong.Text = "CHẤM CÔNG"
        '
        'btnTuyenDung
        '
        Appearance1.Image = "user-search-icon.png"
        Me.btnTuyenDung.Appearance = Appearance1
        Me.btnTuyenDung.Enabled = False
        Me.btnTuyenDung.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTuyenDung.ImageList = Me.ImageList1
        Me.btnTuyenDung.ImageSize = New System.Drawing.Size(50, 50)
        Me.btnTuyenDung.Location = New System.Drawing.Point(37, 200)
        Me.btnTuyenDung.Name = "btnTuyenDung"
        Me.btnTuyenDung.Size = New System.Drawing.Size(230, 73)
        Me.btnTuyenDung.TabIndex = 4
        Me.btnTuyenDung.Text = "TUYỂN DỤNG"
        '
        'btndanhgiahieuquacongviec
        '
        Appearance5.Image = "icon-review-75f1504aff4e75b84b5abf307b21688e.png"
        Me.btndanhgiahieuquacongviec.Appearance = Appearance5
        Me.btndanhgiahieuquacongviec.Enabled = False
        Me.btndanhgiahieuquacongviec.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndanhgiahieuquacongviec.ImageList = Me.ImageList1
        Me.btndanhgiahieuquacongviec.ImageSize = New System.Drawing.Size(50, 50)
        Me.btndanhgiahieuquacongviec.Location = New System.Drawing.Point(103, 279)
        Me.btndanhgiahieuquacongviec.Name = "btndanhgiahieuquacongviec"
        Me.btndanhgiahieuquacongviec.Size = New System.Drawing.Size(367, 73)
        Me.btndanhgiahieuquacongviec.TabIndex = 5
        Me.btndanhgiahieuquacongviec.Text = "ĐÁNH GIÁ HIỆU QUẢ CÔNG VIỆC"
        '
        'UltraPictureBox1
        '
        Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
        Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
        Me.UltraPictureBox1.Location = New System.Drawing.Point(-417, -17)
        Me.UltraPictureBox1.Name = "UltraPictureBox1"
        Me.UltraPictureBox1.Size = New System.Drawing.Size(994, 122)
        Me.UltraPictureBox1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 377)
        Me.Controls.Add(Me.btndanhgiahieuquacongviec)
        Me.Controls.Add(Me.btnTuyenDung)
        Me.Controls.Add(Me.btnChamCong)
        Me.Controls.Add(Me.btnKeToan)
        Me.Controls.Add(Me.btnNhanSu)
        Me.Controls.Add(Me.UltraPictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Màn hình chính"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNhanSu As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnKeToan As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnChamCong As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnTuyenDung As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btndanhgiahieuquacongviec As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
End Class
