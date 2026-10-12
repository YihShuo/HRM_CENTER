Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.UltraWinToolbars
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports SteepValley.Windows.Forms
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Data.SqlClient.SqlParameter
Imports System.Data.SqlClient
Imports System.Timers
Public Class frmWaitingPhepNam
    Dim obj As New objPhepNam

    Private mParentForm As Form
    Private Shared mCurrentProgressForm As frmWaitingPhepNam
    Private Delegate Sub CloseProgressDelegate()
    Public Shared Function ShowProgress(ByVal parentForm As Form) As frmWaitingPhepNam
        Application.DoEvents()
        If Not mCurrentProgressForm Is Nothing Then
            Throw New InvalidOperationException("A ProgressWaitForm is already displayed")
        End If
        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf DoLoadProgress, parentForm)
        While mCurrentProgressForm Is Nothing OrElse mCurrentProgressForm.Visible = False
            System.Threading.Thread.Sleep(1)
        End While
        Return mCurrentProgressForm
    End Function

    Private Shared Sub DoLoadProgress(ByVal parentForm As Object)
        Dim f As New frmWaitingPhepNam(parentForm)
        Application.DoEvents()
        mCurrentProgressForm = f
        f.ShowDialog()
    End Sub

    Private Sub New(ByVal parentForm As Form)
        InitializeComponent()
        mParentForm = parentForm
        TopMost = True
    End Sub
    Public Shadows Sub Close()
        CloseProgress()
    End Sub

    Private Sub DoCloseProgress()
        mCurrentProgressForm = Nothing
        MyBase.Close()
    End Sub
    Public Sub CloseProgress()
        If InvokeRequired Then
            Invoke(New CloseProgressDelegate(AddressOf DoCloseProgress))
        Else
            DoCloseProgress()
        End If
    End Sub

    Private Sub frmWaiting_Procedure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        lblKhu.Text = obj.WaitingKhu
        lblNam.Text = obj.Nam
    End Sub
End Class