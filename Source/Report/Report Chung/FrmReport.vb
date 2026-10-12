Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Public Class FrmReport
    Inherits Form
    ' Methods
    Public Sub New()
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.FrmReport_Load)
        Me.issysReport = True
        Me.InitializeComponent()
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing AndAlso (Not Me.components Is Nothing)) Then
            Me.components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

   

    <DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.rpt = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lblWait = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'rpt
        '
        Me.rpt.ActiveViewIndex = -1
        Me.rpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rpt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpt.Location = New System.Drawing.Point(0, 0)
        Me.rpt.Name = "rpt"
        Me.rpt.SelectionFormula = ""
        Me.rpt.Size = New System.Drawing.Size(599, 464)
        Me.rpt.TabIndex = 0
        Me.rpt.ViewTimeSelectionFormula = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(254, 173)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(228, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'lblWait
        '
        Me.lblWait.AutoSize = True
        Me.lblWait.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWait.Location = New System.Drawing.Point(277, 203)
        Me.lblWait.Name = "lblWait"
        Me.lblWait.Size = New System.Drawing.Size(177, 15)
        Me.lblWait.TabIndex = 2
        Me.lblWait.Text = "Vui lòng chờ trong giây lát."
        '
        'FrmReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(599, 464)
        Me.Controls.Add(Me.lblWait)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.rpt)
        Me.Name = "FrmReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    ' Fields
    Public components As IContainer
    Public issysReport As Boolean
    Public para As Object()
    Public reportID As String
    Public sortAtt As String()
    Friend WithEvents rpt As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Public strFileName As String
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblWait As System.Windows.Forms.Label

    Private WithEvents rs As New clsReportStatus
    Private Delegate Sub BarUpdate(ByVal val As Integer)
    Private Delegate Sub ChangeCursor(ByVal myCursor As Windows.Forms.Cursor)
    Private Delegate Sub ctrlVisible(ByVal meVisible As Boolean)


    Private Sub Report_ProgressBarValue(ByVal val As Integer) Handles rs.ProgressBarValue
        Try
            If Me.InvokeRequired Then
                Dim bu As New BarUpdate(AddressOf Me.Report_ProgressBarValue)
                Me.Invoke(bu, New Object() {val})
            Else
                ProgressBar1.Value = val
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Report_ctrlVisible(ByVal meVisible As Boolean) Handles rs.ctrlVisible
        Try
            If Me.InvokeRequired Then
                Dim lv As New ctrlVisible(AddressOf Me.Report_ctrlVisible)
                Me.Invoke(lv, New Object() {meVisible})
            Else
                lblWait.Visible = meVisible
                ProgressBar1.Visible = meVisible
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Report_mCursor(ByVal myCursor As Windows.Forms.Cursor) Handles rs.mCursor
        Try
            If Me.InvokeRequired Then
                Dim mc As New ChangeCursor(AddressOf Me.Report_mCursor)
                Me.Invoke(mc, New Object() {myCursor})
            Else
                Cursor = myCursor
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Left = Me.Width / 2 - Me.ProgressBar1.Width / 2
        Me.ProgressBar1.Top = Me.Height / 2 - Me.ProgressBar1.Height / 2
        Me.lblWait.Left = Me.Width / 2 - Me.lblWait.Width / 2
        Me.lblWait.Top = Me.Height / 2 - Me.lblWait.Height / 2 + Me.ProgressBar1.Height + 2
        Dim document As ReportDocument
        Dim report As New ClsBReport
        'Try
        '    If Not rs.Running Then
        '        rs.StartThread()
        '    End If
        '    Application.DoEvents()
        '    If ((Not Me.sortAtt Is Nothing) AndAlso (Me.sortAtt.Length = 3)) Then
        '        document = report.InitReport2(Me.reportID, Me.sortAtt(0), Me.sortAtt(1), Me.sortAtt(2))
        '    Else
        '        document = report.InitReport(Me.reportID)
        '    End If
        '    If Me.issysReport Then
        '        document = report.SetParameter(document, Me.para)
        '    End If
        '    Me.rpt.ReportSource = document
        '    Me.Show()
        '    Application.DoEvents()
        '    rs.StopThread()
        'Catch exception1 As Exception
        '    ProjectData.SetProjectError(exception1)
        '    Dim exception As Exception = exception1
        '    Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Th" & ChrW(244) & "ng b" & ChrW(225) & "o")
        '    Me.Close()
        '    ProjectData.ClearProjectError()
        '    Return
        'End Try
        Try
            If Not rs.Running Then
                rs.StartThread()
            End If
            Application.DoEvents()

            Dim nPages As Integer
            If ((Not Me.sortAtt Is Nothing) AndAlso (Me.sortAtt.Length = 3)) Then
                document = report.InitReport2(Me.reportID, Me.sortAtt(0), Me.sortAtt(1), Me.sortAtt(2))
            Else
                document = report.InitReport(Me.reportID)
            End If

            If Me.issysReport Then
                document = report.SetParameter(document, Me.para)
            End If
            Me.rpt.ReportSource = document
            'Me.rptChamcong.Refresh()
            Me.Show()
            Application.DoEvents()
            'Here is where I inserted the line from the SAP Community Network forum
            nPages = document.FormatEngine.GetLastPageNumber(New CrystalDecisions.Shared.ReportPageRequestContext)
            rs.StopThread()
        Catch ex As Exception
            rs.StopThread()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class

