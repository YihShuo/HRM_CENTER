<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChuyenDuLieu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChuyenDuLieu))
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbThang = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btThoat = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btCapNhat = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cbThang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_frmNhapDBLuong_Toolbars_Dock_Area_Bottom
        '
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 111)
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.Name = "_frmNhapDBLuong_Toolbars_Dock_Area_Bottom"
        Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(262, 0)
        '
        '_frmSoTienPC_Toolbars_Dock_Area_Bottom
        '
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.SystemColors.Control
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 111)
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.Name = "_frmSoTienPC_Toolbars_Dock_Area_Bottom"
        Me._frmSoTienPC_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(262, 0)
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.UltraGroupBox1)
        Me.Panel3.Location = New System.Drawing.Point(2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(259, 107)
        Me.Panel3.TabIndex = 2
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox2)
        Me.UltraGroupBox1.Controls.Add(Me.GroupBox1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(257, 105)
        Me.UltraGroupBox1.TabIndex = 23
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbThang)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(241, 45)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'cbThang
        '
        Me.cbThang.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbThang.DisplayMember = "TEN_DV"
        Me.cbThang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cbThang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbThang.Location = New System.Drawing.Point(91, 13)
        Me.cbThang.Name = "cbThang"
        Me.cbThang.Size = New System.Drawing.Size(141, 24)
        Me.cbThang.TabIndex = 34
        Me.cbThang.ValueMember = "DV_MA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 14)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Tháng Trước :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btThoat)
        Me.GroupBox1.Controls.Add(Me.btCapNhat)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 46)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'btThoat
        '
        Me.btThoat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btThoat.ForeColor = System.Drawing.Color.Blue
        Me.btThoat.ImageIndex = 1
        Me.btThoat.ImageList = Me.ImageList1
        Me.btThoat.Location = New System.Drawing.Point(166, 12)
        Me.btThoat.MaximumSize = New System.Drawing.Size(68, 27)
        Me.btThoat.MinimumSize = New System.Drawing.Size(68, 27)
        Me.btThoat.Name = "btThoat"
        Me.btThoat.Size = New System.Drawing.Size(68, 27)
        Me.btThoat.TabIndex = 28
        Me.btThoat.Text = "Đóng"
        Me.btThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btThoat.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "0.add.ico")
        Me.ImageList1.Images.SetKeyName(1, "1.xoa.ico")
        Me.ImageList1.Images.SetKeyName(2, "2.note.ico")
        Me.ImageList1.Images.SetKeyName(3, "3.PRINTER.ico")
        Me.ImageList1.Images.SetKeyName(4, "4.save.ico")
        Me.ImageList1.Images.SetKeyName(5, "5.a91.ico")
        '
        'btCapNhat
        '
        Me.btCapNhat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btCapNhat.ForeColor = System.Drawing.Color.Blue
        Me.btCapNhat.ImageIndex = 5
        Me.btCapNhat.ImageList = Me.ImageList1
        Me.btCapNhat.Location = New System.Drawing.Point(91, 12)
        Me.btCapNhat.MaximumSize = New System.Drawing.Size(68, 27)
        Me.btCapNhat.MinimumSize = New System.Drawing.Size(68, 27)
        Me.btCapNhat.Name = "btCapNhat"
        Me.btCapNhat.Size = New System.Drawing.Size(68, 27)
        Me.btCapNhat.TabIndex = 27
        Me.btCapNhat.Text = "Chọn"
        Me.btCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btCapNhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btCapNhat.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 111)
        Me.Panel1.TabIndex = 11
        '
        'frmChuyenDuLieu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(262, 111)
        Me.Controls.Add(Me._frmNhapDBLuong_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._frmSoTienPC_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmChuyenDuLieu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chuyển dữ liệu"
        Me.Panel3.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cbThang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _frmNhapDBLuong_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _frmSoTienPC_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbThang As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btThoat As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btCapNhat As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
