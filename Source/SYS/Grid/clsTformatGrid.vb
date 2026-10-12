Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.IO

Public Class clsTformatGrid
    ' Methods
    Public Function initControlXML(ByRef o As Object, ByVal đường_Dẫn_FileXML As String, ByVal control As typeControl, ByVal nameAttribute As String) As Boolean
        Dim flag As Boolean
        Dim [set] As New DataSet
        Try
            [set].ReadXml(đường_Dẫn_FileXML)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Throw New Exception(exception.Message)
        End Try
        Try
            Dim tb As DataTable = [set].Tables.Item(nameAttribute)
            Select Case control
                Case typeControl.Form, typeControl.Button, typeControl.Lable
                    Return flag
                Case typeControl.Grid
                    Dim grid As UltraGrid = DirectCast(o, UltraGrid)
                    Me.InitGrid((grid), Me.setAtt(tb))
                    Return flag
            End Select
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Throw New Exception(exception2.Message)
        End Try
        Return flag
    End Function

    'Public Function initControlXML2(ByRef o As Object, ByVal đường_Dẫn_FileXML As String, ByVal control As typeControl, ByVal nameAttribute As String) As Boolean
    '    Dim flag As Boolean
    '    Dim [set] As New DataSet
    '    Try
    '        [set].ReadXml(đường_Dẫn_FileXML)
    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        Throw New Exception(exception.Message)
    '    End Try
    '    Try
    '        Dim tb As DataTable = [set].Tables.Item(nameAttribute)
    '        Select Case control
    '            Case typeControl.Form, typeControl.Button, typeControl.Lable
    '                Return flag
    '            Case typeControl.Grid
    '                Dim grid As UltraGrid = DirectCast(o, UltraGrid)
    '                Me.InitGrid((grid), Me.setAtt(tb))
    '                Return flag
    '        End Select
    '    Catch exception3 As Exception
    '        ProjectData.SetProjectError(exception3)
    '        Dim exception2 As Exception = exception3
    '        Throw New Exception(exception2.Message)
    '    End Try
    '    Return flag
    'End Function

    Public Sub InitGrid(ByRef Grid As UltraGrid, ByVal lstProperty As objPropertys())
        Dim band As UltraGridBand = Grid.DisplayLayout.Bands.Item(0)
        Dim num3 As Integer = (band.Columns.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            band.Columns.Item(i).Hidden = True
            i += 1
        Loop
        Dim propertys As objPropertys
        For Each propertys In lstProperty
            band.Columns.Item(propertys.tênCộtTrongBảng).Hidden = propertys.Ẩn
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.Caption = propertys.TiêuĐề
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.VisiblePosition = propertys.vịTríHiểnThị
            band.Columns.Item(propertys.tênCộtTrongBảng).Width = propertys.rộng
            band.Columns.Item(propertys.tênCộtTrongBảng).Format = propertys.địnhDạngÔ
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.Appearance.TextHAlign = propertys.vị_trí_text_Tiêu_Đề_Dọc
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.Appearance.TextVAlign = DirectCast(propertys.vị_trí_text_Tiêu_Đề_Ngang, VAlign)
            band.Columns.Item(propertys.tênCộtTrongBảng).CellAppearance.TextHAlign = propertys.vị_trí_text_Ô_Dọc
            band.Columns.Item(propertys.tênCộtTrongBảng).CellAppearance.TextVAlign = DirectCast(propertys.vị_trí_text_Ô_Ngang, VAlign)
        Next
        band.Layout.Override.FilterUIType = FilterUIType.FilterRow
        band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        'Column Chooser

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(1)
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
        band = Nothing
    End Sub

    Public Sub initControlNoXML(ByRef Grid As UltraGrid)
        If Not Grid.DataSource Is Nothing Then
            Dim band As UltraGridBand = Grid.DisplayLayout.Bands.Item(0)
            band.Layout.Override.FilterUIType = FilterUIType.FilterRow
            band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
            band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
            band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
            band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
            band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
            band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
            band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
            band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
            'Column Chooser
            band.Layout.Override.RowSelectors = DefaultableBoolean.True
            band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton
            Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(2)
            band.Layout.Bands(0).Summaries.Clear()
            Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
            summary.Appearance.TextHAlign = HAlign.Right
            band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            band.SummaryFooterCaption = "Tổng số: "
            band = Nothing
        End If
    End Sub

    Public Function initControlXMLCC(ByRef o As Object, ByVal đường_Dẫn_FileXML As String, ByVal control As typeControl, ByVal nameAttribute As String) As Boolean
        Dim flag As Boolean
        Dim [set] As New DataSet
        Try
            [set].ReadXml(đường_Dẫn_FileXML)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            Throw New Exception(exception.Message)
        End Try
        Try
            Dim tb As DataTable = [set].Tables.Item(nameAttribute)
            Select Case control
                Case typeControl.Form, typeControl.Button, typeControl.Lable
                    Return flag
                Case typeControl.Grid
                    Dim grid As UltraGrid = DirectCast(o, UltraGrid)
                    Me.InitGridCC((grid), Me.setAtt(tb))
                    Return flag
            End Select
        Catch exception3 As Exception
            ProjectData.SetProjectError(exception3)
            Dim exception2 As Exception = exception3
            Throw New Exception(exception2.Message)
        End Try
        Return flag
    End Function


    Public Sub InitGridCC(ByRef Grid As UltraGrid, ByVal lstProperty As objPropertys())
        Dim band As UltraGridBand = Grid.DisplayLayout.Bands.Item(0)
        Dim num3 As Integer = (band.Columns.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            band.Columns.Item(i).Hidden = True
            i += 1
        Loop
        Dim propertys As objPropertys
        For Each propertys In lstProperty
            band.Columns.Item(propertys.tênCộtTrongBảng).Hidden = propertys.Ẩn
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.Caption = propertys.TiêuĐề
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.VisiblePosition = propertys.vịTríHiểnThị
            band.Columns.Item(propertys.tênCộtTrongBảng).Width = propertys.rộng
            band.Columns.Item(propertys.tênCộtTrongBảng).Format = propertys.địnhDạngÔ
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.Appearance.TextHAlign = propertys.vị_trí_text_Tiêu_Đề_Dọc
            band.Columns.Item(propertys.tênCộtTrongBảng).Header.Appearance.TextVAlign = DirectCast(propertys.vị_trí_text_Tiêu_Đề_Ngang, VAlign)
            band.Columns.Item(propertys.tênCộtTrongBảng).CellAppearance.TextHAlign = propertys.vị_trí_text_Ô_Dọc
            band.Columns.Item(propertys.tênCộtTrongBảng).CellAppearance.TextVAlign = DirectCast(propertys.vị_trí_text_Ô_Ngang, VAlign)
        Next
        band.Layout.Override.FilterUIType = FilterUIType.FilterRow
        band.Layout.Override.FilterEvaluationTrigger = FilterEvaluationTrigger.OnCellValueChange
        band.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand
        band.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.StartsWith
        band.Layout.Override.FilterClearButtonLocation = FilterClearButtonLocation.RowAndCell
        band.Layout.Override.FilterRowAppearance.BackColor = Color.LightYellow
        band.Layout.Override.FilterRowPrompt = "Nhấn chuột vào đây để lọc dữ liệu..."
        band.Layout.Override.FilterRowPromptAppearance.BackColorAlpha = Alpha.Opaque
        band.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
        band.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(233, 242, 199)
        'Column Chooser

        band.Layout.Override.RowSelectors = DefaultableBoolean.True
        band.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton

        Dim columnToSummarize As UltraGridColumn = band.Layout.Bands(0).Columns(2)
        band.Layout.Bands(0).Summaries.Clear()
        Dim summary As SummarySettings = band.Layout.Bands(0).Summaries.Add("Count", SummaryType.Count, columnToSummarize)
        summary.Appearance.TextHAlign = HAlign.Right
        band.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        band.SummaryFooterCaption = "Tổng số: "
        band = Nothing
    End Sub

    Public Function setAtt(ByVal tb As DataTable) As objPropertys()
        Dim count As Integer = tb.Rows.Count
        Dim propertysArray As objPropertys() = New objPropertys(((count - 1) + 1) - 1) {}
        Dim table As DataTable = tb
        Dim num3 As Integer = (count - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            propertysArray(i) = New objPropertys
            propertysArray(i).rộng = IntegerType.FromObject(table.Rows.Item(i).Item("width"))
            propertysArray(i).TiêuĐề = StringType.FromObject(table.Rows.Item(i).Item("title"))
            propertysArray(i).tênCộtTrongBảng = StringType.FromObject(table.Rows.Item(i).Item("tblColName"))
            propertysArray(i).vị_trí_text_Tiêu_Đề_Dọc = DirectCast(IntegerType.FromObject(table.Rows.Item(i).Item("HtitAlign")), HAlign)
            propertysArray(i).vị_trí_text_Tiêu_Đề_Ngang = DirectCast(IntegerType.FromObject(table.Rows.Item(i).Item("VtitAlign")), HAlign)
            propertysArray(i).vị_trí_text_Ô_Dọc = DirectCast(IntegerType.FromObject(table.Rows.Item(i).Item("HtextAlign")), HAlign)
            propertysArray(i).vị_trí_text_Ô_Ngang = DirectCast(IntegerType.FromObject(table.Rows.Item(i).Item("VtextAlign")), HAlign)
            propertysArray(i).vịTríHiểnThị = IntegerType.FromObject(table.Rows.Item(i).Item("positionCol"))
            propertysArray(i).địnhDạngÔ = StringType.FromObject(table.Rows.Item(i).Item("formatCell"))
            propertysArray(i).Ẩn = BooleanType.FromObject(table.Rows.Item(i).Item("hide"))
            i += 1
        Loop
        table = Nothing
        Return propertysArray
    End Function

    Public Sub WriteFormatGridToXML(ByVal gr As UltraGrid, ByVal filename As String, ByVal nameAttribute As String)
        Dim table As New DataTable
        table.Columns.Add("tblColName")
        table.Columns.Add("title")
        table.Columns.Add("hide")
        table.Columns.Add("formatCell")
        table.Columns.Add("width")
        table.Columns.Add("HtextAlign")
        table.Columns.Add("VtextAlign")
        table.Columns.Add("HtitAlign")
        table.Columns.Add("VtitAlign")
        table.Columns.Add("positionCol")
        Dim num9 As Integer = (gr.DisplayLayout.Bands.Item(0).Columns.Count - 1)
        Dim i As Integer = 0
        Do While (i <= num9)
            Dim column As UltraGridColumn = gr.DisplayLayout.Bands.Item(0).Columns.Item(i)
            If Not column.Hidden Then
                Dim row As DataRow = table.NewRow
                row.Item("tblColName") = column.ToString.Trim
                row.Item("title") = column.Header.Caption
                row.Item("hide") = "false"
                If (Not column.Format Is Nothing) Then
                    row.Item("formatCell") = column.Format
                Else
                    row.Item("formatCell") = ""
                End If
                row.Item("width") = column.Width
                Select Case column.CellAppearance.TextHAlign
                    Case HAlign.Default
                        row.Item("HtextAlign") = 0
                        Exit Select
                    Case HAlign.Left
                        row.Item("HtextAlign") = 1
                        Exit Select
                    Case HAlign.Center
                        row.Item("HtextAlign") = 2
                        Exit Select
                    Case HAlign.Right
                        row.Item("HtextAlign") = 3
                        Exit Select
                End Select
                Select Case column.CellAppearance.TextVAlign
                    Case VAlign.Default
                        row.Item("VtextAlign") = 0
                        Exit Select
                    Case VAlign.Top
                        row.Item("VtextAlign") = 1
                        Exit Select
                    Case VAlign.Middle
                        row.Item("VtextAlign") = 2
                        Exit Select
                    Case VAlign.Bottom
                        row.Item("VtextAlign") = 3
                        Exit Select
                End Select
                Select Case column.Header.Appearance.TextHAlign
                    Case HAlign.Default
                        row.Item("HtitAlign") = 0
                        Exit Select
                    Case HAlign.Left
                        row.Item("HtitAlign") = 1
                        Exit Select
                    Case HAlign.Center
                        row.Item("HtitAlign") = 2
                        Exit Select
                    Case HAlign.Right
                        row.Item("HtitAlign") = 3
                        Exit Select
                End Select
                Select Case column.Header.Appearance.TextVAlign
                    Case VAlign.Default
                        row.Item("VtitAlign") = 0
                        Exit Select
                    Case VAlign.Top
                        row.Item("VtitAlign") = 1
                        Exit Select
                    Case VAlign.Middle
                        row.Item("VtitAlign") = 2
                        Exit Select
                    Case VAlign.Bottom
                        row.Item("VtitAlign") = 3
                        Exit Select
                End Select
                row.Item("positionCol") = column.Header.VisiblePosition.ToString
                table.Rows.Add(row)
                row = Nothing
            End If
            i += 1
        Loop
        Dim num2 As Integer = (table.Rows.Count - 1)
        Dim num As Integer = (table.Columns.Count - 1)
        Dim writer As New StreamWriter(filename)
        writer.WriteLine("<?xml version=""1.0"" encoding=""UTF-8"" ?>")
        writer.WriteLine("<form>")
        writer.WriteLine("  <controls>")
        Dim num7 As Integer = num2
        Dim j As Integer = 0
        Do While (j <= num7)
            Dim str As String = ("         <" & nameAttribute & "   ")
            Dim num6 As Integer = num
            Dim k As Integer = 0
            Do While (k <= num6)
                str = String.Concat(New String() {str, table.Columns.Item(k).ColumnName.Trim, "=""", StringType.FromObject(table.Rows.Item(j).Item(k)).Trim, """   "})
                k += 1
            Loop
            str = (str.Trim & "/>")
            writer.WriteLine(str)
            j += 1
        Loop
        writer.WriteLine("  </controls>")
        writer.WriteLine("</form>")
        writer.Close()
    End Sub

End Class


