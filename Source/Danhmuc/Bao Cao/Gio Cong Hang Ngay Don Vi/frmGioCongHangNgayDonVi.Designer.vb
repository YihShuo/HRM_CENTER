<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGioCongHangNgayDonVi
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGioCongHangNgayDonVi))
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnXuatEX = New System.Windows.Forms.Button
        Me.btnXem = New System.Windows.Forms.Button
        Me.btXem = New System.Windows.Forms.Button
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlList = New System.Windows.Forms.Panel
        Me.pnlButton = New System.Windows.Forms.Panel
        Me.ToolBar1 = New TD.SandBar.ToolBar
        Me.btXemBaoCao = New TD.SandBar.ButtonItem
        Me.ButtonItem1 = New TD.SandBar.ButtonItem
        Me.XpCaption2 = New SteepValley.Windows.Forms.XPCaption
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.XpCaption1 = New SteepValley.Windows.Forms.XPCaption
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.radTCT = New System.Windows.Forms.RadioButton
        Me.radKhuDVC = New System.Windows.Forms.RadioButton
        Me.radKhuB = New System.Windows.Forms.RadioButton
        Me.radKhuA = New System.Windows.Forms.RadioButton
        Me.Panel4.SuspendLayout()
        Me.pnlList.SuspendLayout()
        Me.pnlButton.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.btnXuatEX)
        Me.Panel4.Controls.Add(Me.btnXem)
        Me.Panel4.Controls.Add(Me.btXem)
        Me.Panel4.Controls.Add(Me.dtpNgay)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(843, 91)
        Me.Panel4.TabIndex = 2
        '
        'btnXuatEX
        '
        Me.btnXuatEX.Location = New System.Drawing.Point(231, 28)
        Me.btnXuatEX.Name = "btnXuatEX"
        Me.btnXuatEX.Size = New System.Drawing.Size(75, 23)
        Me.btnXuatEX.TabIndex = 9
        Me.btnXuatEX.Text = "Xuất excel"
        Me.btnXuatEX.UseVisualStyleBackColor = True
        '
        'btnXem
        '
        Me.btnXem.BackColor = System.Drawing.Color.Transparent
        Me.btnXem.Location = New System.Drawing.Point(152, 29)
        Me.btnXem.Name = "btnXem"
        Me.btnXem.Size = New System.Drawing.Size(75, 23)
        Me.btnXem.TabIndex = 8
        Me.btnXem.Text = "Xem"
        Me.btnXem.UseVisualStyleBackColor = False
        '
        'btXem
        '
        Me.btXem.Location = New System.Drawing.Point(311, 26)
        Me.btXem.Name = "btXem"
        Me.btXem.Size = New System.Drawing.Size(88, 23)
        Me.btXem.TabIndex = 7
        Me.btXem.Text = "Xem báo cáo"
        Me.btXem.UseVisualStyleBackColor = True
        '
        'dtpNgay
        '
        Me.dtpNgay.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.CustomFormat = "MM-yyyy"
        Me.dtpNgay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNgay.Location = New System.Drawing.Point(68, 30)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(75, 22)
        Me.dtpNgay.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(2, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Tháng :"
        '
        'pnlList
        '
        Me.pnlList.Controls.Add(Me.pnlButton)
        Me.pnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlList.Location = New System.Drawing.Point(0, 69)
        Me.pnlList.Name = "pnlList"
        Me.pnlList.Size = New System.Drawing.Size(827, 266)
        Me.pnlList.TabIndex = 6
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.ToolBar1)
        Me.pnlButton.Controls.Add(Me.XpCaption2)
        Me.pnlButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlButton.Location = New System.Drawing.Point(0, 0)
        Me.pnlButton.Name = "pnlButton"
        Me.pnlButton.Size = New System.Drawing.Size(827, 58)
        Me.pnlButton.TabIndex = 7
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.Buttons.AddRange(New TD.SandBar.ToolbarItemBase() {Me.btXemBaoCao, Me.ButtonItem1})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.Guid = New System.Guid("942fc5f3-6e2d-4d57-a1de-1e28245f9a05")
        Me.ToolBar1.Location = New System.Drawing.Point(2, 26)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(825, 26)
        Me.ToolBar1.TabIndex = 11
        Me.ToolBar1.Text = "ToolBar1"
        '
        'btXemBaoCao
        '
        Me.btXemBaoCao.Image = CType(resources.GetObject("btXemBaoCao.Image"), System.Drawing.Image)
        Me.btXemBaoCao.ImageIndex = 3
        Me.btXemBaoCao.Text = "Xem"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.Text = "Xuất Excel"
        '
        'XpCaption2
        '
        Me.XpCaption2.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption2.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption2.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption2.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption2.Name = "XpCaption2"
        Me.XpCaption2.Size = New System.Drawing.Size(827, 24)
        Me.XpCaption2.TabIndex = 0
        Me.XpCaption2.Text = "Danh sách  "
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CrystalReportViewer1)
        Me.Panel1.Controls.Add(Me.UltraGrid1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 91)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(843, 289)
        Me.Panel1.TabIndex = 7
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 25)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(843, 264)
        Me.CrystalReportViewer1.TabIndex = 11
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'UltraGrid1
        '
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 25)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(843, 264)
        Me.UltraGrid1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.XpCaption1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(843, 25)
        Me.Panel2.TabIndex = 7
        '
        'XpCaption1
        '
        Me.XpCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XpCaption1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold)
        Me.XpCaption1.InactiveGradientHighColor = System.Drawing.Color.CornflowerBlue
        Me.XpCaption1.InactiveGradientLowColor = System.Drawing.Color.RoyalBlue
        Me.XpCaption1.Location = New System.Drawing.Point(0, 0)
        Me.XpCaption1.Name = "XpCaption1"
        Me.XpCaption1.Size = New System.Drawing.Size(843, 24)
        Me.XpCaption1.TabIndex = 0
        Me.XpCaption1.Text = "Danh sách giờ công"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.radTCT)
        Me.Panel3.Controls.Add(Me.radKhuDVC)
        Me.Panel3.Controls.Add(Me.radKhuB)
        Me.Panel3.Controls.Add(Me.radKhuA)
        Me.Panel3.Location = New System.Drawing.Point(152, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(247, 28)
        Me.Panel3.TabIndex = 10
        '
        'radTCT
        '
        Me.radTCT.AutoSize = True
        Me.radTCT.Checked = True
        Me.radTCT.Location = New System.Drawing.Point(192, 6)
        Me.radTCT.Name = "radTCT"
        Me.radTCT.Size = New System.Drawing.Size(46, 17)
        Me.radTCT.TabIndex = 1
        Me.radTCT.TabStop = True
        Me.radTCT.Text = "TCT"
        Me.radTCT.UseVisualStyleBackColor = True
        '
        'radKhuDVC
        '
        Me.radKhuDVC.AutoSize = True
        Me.radKhuDVC.Location = New System.Drawing.Point(119, 5)
        Me.radKhuDVC.Name = "radKhuDVC"
        Me.radKhuDVC.Size = New System.Drawing.Size(69, 17)
        Me.radKhuDVC.TabIndex = 0
        Me.radKhuDVC.Text = "Khu DVC"
        Me.radKhuDVC.UseVisualStyleBackColor = True
        '
        'radKhuB
        '
        Me.radKhuB.AutoSize = True
        Me.radKhuB.Location = New System.Drawing.Point(63, 6)
        Me.radKhuB.Name = "radKhuB"
        Me.radKhuB.Size = New System.Drawing.Size(54, 17)
        Me.radKhuB.TabIndex = 0
        Me.radKhuB.Text = "Khu B"
        Me.radKhuB.UseVisualStyleBackColor = True
        '
        'radKhuA
        '
        Me.radKhuA.AutoSize = True
        Me.radKhuA.Location = New System.Drawing.Point(3, 6)
        Me.radKhuA.Name = "radKhuA"
        Me.radKhuA.Size = New System.Drawing.Size(54, 17)
        Me.radKhuA.TabIndex = 0
        Me.radKhuA.Text = "Khu A"
        Me.radKhuA.UseVisualStyleBackColor = True
        '
        'frmGioCongHangNgayDonVi
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(843, 380)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Name = "frmGioCongHangNgayDonVi"
        Me.Text = "frmGioCongHangNgayDonVi"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlList.ResumeLayout(False)
        Me.pnlButton.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btXem As System.Windows.Forms.Button
    Friend WithEvents btnXem As System.Windows.Forms.Button
    Friend WithEvents btnXuatEX As System.Windows.Forms.Button
    Friend WithEvents pnlList As System.Windows.Forms.Panel
    Friend WithEvents pnlButton As System.Windows.Forms.Panel
    Friend WithEvents ToolBar1 As TD.SandBar.ToolBar
    Friend WithEvents btXemBaoCao As TD.SandBar.ButtonItem
    Friend WithEvents ButtonItem1 As TD.SandBar.ButtonItem
    Friend WithEvents XpCaption2 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents XpCaption1 As SteepValley.Windows.Forms.XPCaption
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents radTCT As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuDVC As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuB As System.Windows.Forms.RadioButton
    Friend WithEvents radKhuA As System.Windows.Forms.RadioButton
End Class
