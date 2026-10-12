Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Friend Class clsTools
    ' Methods
    Public Shared Function createGroupKey(ByVal number As Boolean, ByVal key As String) As String
        Dim strArray As String() = clsTools.decodeKEY(key)
        Dim str2 As String = "'"
        If number Then
            str2 = ""
        End If
        Dim str4 As String = ""
        Dim length As Integer = strArray.Length
        Select Case length
            Case 2
                Return String.Concat(New String() {"(", str2, strArray(0), str2, ")"})
            Case 3
                Return String.Concat(New String() {"(", str2, strArray(0), str2, ",", str2, strArray(1), str2, ")"})
            Case 4
                Return String.Concat(New String() {"(", str2, strArray(0), str2, ",", str2, strArray(1), str2, ",", str2, strArray(2), str2, ")"})
        End Select
        If (length <= 3) Then
            Return str4
        End If
        str4 = "("
        Dim num2 As Integer = (strArray.Length - 3)
        Dim i As Integer = 0
        Do While (i <= num2)
            str4 = String.Concat(New String() {str4, str2, strArray(i), str2, ","})
            i += 1
        Loop
        Return String.Concat(New String() {str4, str2, strArray((strArray.Length - 2)), str2, ")"})
    End Function

    Public Shared Function createGroupKey1(ByVal number As Boolean, ByVal key As String) As String
        Dim strArray As String() = clsTools.decodeKEY(key)
        Dim str2 As String = "'"
        Dim str3 As String = "N'"
        If number Then
            str2 = ""
            str3 = ""
        End If
        Dim str4 As String = ""
        Dim length As Integer = strArray.Length
        Select Case length
            Case 2
                Return String.Concat(New String() {"(", str3, strArray(0), str2, ")"})
            Case 3
                Return String.Concat(New String() {"(", str3, strArray(0), str2, ",", str3, strArray(1), str2, ")"})
            Case 4
                Return String.Concat(New String() {"(", str3, strArray(0), str2, ",", str3, strArray(1), str2, ",", str3, strArray(4), str2, ")"})
        End Select
        If (length <= 3) Then
            Return str4
        End If
        str4 = "("
        Dim num2 As Integer = (strArray.Length - 3)
        Dim i As Integer = 0
        Do While (i <= num2)
            str4 = String.Concat(New String() {str4, str3, strArray(i), str2, ","})
            i += 1
        Loop
        Return String.Concat(New String() {str4, str3, strArray((strArray.Length - 2)), str2, ")"})
    End Function

    Public Shared Function decodeKEY(ByVal key As String) As String()
        Return key.Split(New Char() {";"c})
    End Function

    Public Shared Function Decrypt1(ByVal varEncrypt As String) As String
        Dim str As String
        Dim num4 As Integer
        Dim num5 As Integer
        Dim str2 As String
        ProjectData.ClearProjectError()
        num5 = 1
        Dim o As Object = Strings.Split(varEncrypt, "-", -1, CompareMethod.Text)
        Dim num2 As Integer = Information.UBound(DirectCast(o, Array), 1)
        Dim num6 As Integer = num2
        Dim i As Integer = 1
        Do While (i <= num6)
            Dim charCode As Integer = CInt(Math.Round(DoubleType.FromObject(LateBinding.LateIndexGet(o, New Object() {i}, Nothing))))
            charCode = CInt(CLng(Math.Round(CDbl((CDbl(charCode) / CDbl((num2 + i)))))))
            str2 = (str2 & StringType.FromChar(Strings.Chr(charCode)))
            i += 1
        Loop
        str = str2

Label_00CA:
        If (num4 <> 0) Then
            ProjectData.ClearProjectError()
        End If
        Return str
    End Function

    Public Shared Function Encrypt1(ByVal varPass As String) As String
        Dim str As String
        Dim num4 As Integer
        Dim num5 As Integer
        ProjectData.ClearProjectError()
        num5 = 1
        Dim num2 As Integer = Strings.Len(varPass)
        If (num2 > 30) Then
            varPass = Strings.Left(varPass, 30)
        End If
        Dim str2 As String = ""
        Dim num6 As Integer = num2
        Dim i As Integer = 1
        Do While (i <= num6)
            Dim num3 As Long = Strings.Asc(Strings.Mid(varPass, i, 1))
            str2 = (str2 & "-" & StringType.FromLong((num3 * (num2 + i))))
            i += 1
        Loop
        str = str2

Label_00A4:
        If (num4 <> 0) Then
            ProjectData.ClearProjectError()
        End If
        Return str
    End Function

    Public Shared Sub fillCombobox(ByVal optS As combo, ByVal cmb As UltraComboEditor, ByVal source As DataTable, ByVal display As String, ByVal value As String)
        cmb.DataSource = Nothing
        Try
            Dim row As DataRow
            If (source.Rows.Count = 0) Then
                row = source.NewRow
                row.Item(display) = "None" 'None
                row.Item(value) = "-2"
                source.Rows.Add(row)
            ElseIf (optS <> combo.mDefault) Then
                If (optS = combo.TấtCả) Then
                    row = source.NewRow
                    row.Item(display) = "Toàn công ty" 'Toàn công ty
                    row.Item(value) = "Toàn công ty" '"-1"
                    source.Rows.Add(row)
                End If
                If (optS = combo.None) Then
                    row = source.NewRow
                    row.Item(display) = "None" 'None
                    row.Item(value) = "-2"
                    source.Rows.Add(row)
                End If
                If (optS = combo.TấtCả_None) Then
                    row = source.NewRow
                    row.Item(display) = "Toàn công ty" 'Toàn công ty
                    row.Item(value) = "-1"
                    source.Rows.Add(row)
                    row = source.NewRow
                    row.Item(display) = "None" 'None
                    row.Item(value) = "-2"
                    source.Rows.Add(row)
                End If
            End If
            cmb.DisplayMember = display
            cmb.ValueMember = value
            cmb.DataSource = source
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongBao((exception.Message & ChrW(13) & exception.StackTrace))
            ProjectData.ClearProjectError()
        End Try
        cmb.SelectedIndex = (cmb.Items.Count - 1)
    End Sub

    Public Shared Sub fillCombobox(ByVal optS As combo, ByVal cmb As ComboBox, ByVal source As DataTable, ByVal display As String, ByVal value As String)
        cmb.DataSource = Nothing
        Try
            Dim row As DataRow
            If (source.Rows.Count = 0) Then
                row = source.NewRow
                row.Item(display) = "None"
                row.Item(value) = "-2"
                source.Rows.Add(row)
            ElseIf (optS <> combo.mDefault) Then
                If (optS = combo.TấtCả) Then
                    row = source.NewRow
                    row.Item(display) = "T" & ChrW(7845) & "t c" & ChrW(7843)
                    row.Item(value) = "-1"
                    source.Rows.Add(row)
                End If
                If (optS = combo.None) Then
                    row = source.NewRow
                    row.Item(display) = "None"
                    row.Item(value) = "-2"
                    source.Rows.Add(row)
                End If
                If (optS = combo.TấtCả_None) Then
                    row = source.NewRow
                    row.Item(display) = "T" & ChrW(7845) & "t c" & ChrW(7843)
                    row.Item(value) = "-1"
                    source.Rows.Add(row)
                    row = source.NewRow
                    row.Item(display) = "None"
                    row.Item(value) = "-2"
                    source.Rows.Add(row)
                End If
            End If
            cmb.DisplayMember = display
            cmb.ValueMember = value
            cmb.DataSource = source
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            clsTools.thongBao((exception.Message & ChrW(13) & exception.StackTrace))
            ProjectData.ClearProjectError()
        End Try
        cmb.SelectedIndex = (cmb.Items.Count - 1)
    End Sub

    Public Shared Sub GridTheme1(ByVal dgr As UltraGrid)
        Dim displayLayout As UltraGridLayout = dgr.DisplayLayout
        displayLayout.Appearance.BackColor = Color.White
        Dim captionAppearance As AppearanceBase = displayLayout.CaptionAppearance
        captionAppearance.FontData.Bold = DefaultableBoolean.True
        captionAppearance.FontData.Name = "Verdana"
        captionAppearance.FontData.SizeInPoints = 9.0!
        captionAppearance = Nothing
        displayLayout.CaptionVisible = DefaultableBoolean.False
        displayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
        Dim override As UltraGridOverride = displayLayout.Override
        override.FilterUIType = FilterUIType.FilterRow
        override.FilterClearButtonLocation = FilterClearButtonLocation.Cell
        override.FilterRowAppearance.BackColor = Color.LightYellow
        override.FilterOperandStyle = FilterOperandStyle.Edit
        override.FilterOperatorLocation = FilterOperatorLocation.Hidden
        override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

        override.AllowAddNew = AllowAddNew.No
        override.AllowUpdate = DefaultableBoolean.False
        override.AllowDelete = DefaultableBoolean.False

        override.AllowRowFiltering = DefaultableBoolean.True
        override.CellClickAction = CellClickAction.RowSelect
        override.HeaderClickAction = HeaderClickAction.SortSingle

        override.SelectedRowAppearance.BackColor = Color.FromArgb(&HFF, &HE0, &HC0)
        override.SelectedRowAppearance.BackColor2 = Color.FromArgb(&HFF, &H80, 0)
        override.SelectedRowAppearance.BackGradientStyle = GradientStyle.Vertical
        override.SelectedRowAppearance.ForeColor = Color.Blue

        override.HeaderStyle = HeaderStyle.WindowsXPCommand
        override.RowSelectorStyle = HeaderStyle.WindowsXPCommand
        override = Nothing
        displayLayout.EmptyRowSettings.Style = EmptyRowStyle.HideRowSelector
        displayLayout.GroupByBox.Prompt = "K" & ChrW(233) & "o ti" & ChrW(234) & "u " & ChrW(273) & ChrW(7873) & " c" & ChrW(7897) & "t v" & ChrW(224) & "o " & ChrW(273) & ChrW(226) & "y " & ChrW(273) & ChrW(7875) & " nh" & ChrW(243) & "m th" & ChrW(244) & "ng tin theo c" & ChrW(7897) & "t " & ChrW(273) & ChrW(243)
        displayLayout.GroupByBox.Appearance.BackColor = Color.LightBlue
        displayLayout.GroupByBox.Appearance.ForeColor = Color.Green
        displayLayout = Nothing
    End Sub

    <DllImport("user32", CharSet:=CharSet.Ansi, SetLastError:=True, ExactSpelling:=True)> _
    Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    End Sub

    Public Shared Function randomNumber() As String
        Return StringType.FromDouble(Math.Round(CDbl((VBMath.Rnd(SingleType.FromString((StringType.FromInteger(DateAndTime.Now.Second) & StringType.FromDecimal(Math.Round(New Decimal(DateAndTime.Now.Millisecond), 4))))) * 1.0E+7!)), 0))
    End Function

    Public Shared Function readnum(ByRef no As Object) As String
        Dim str As String
        Dim obj2 As Object = no
        If (ObjectType.ObjTst(obj2, "1", False) = 0) Then
            Return "một"
        End If
        If (ObjectType.ObjTst(obj2, "2", False) = 0) Then
            Return "hai"
        End If
        If (ObjectType.ObjTst(obj2, "3", False) = 0) Then
            Return "ba"
        End If
        If (ObjectType.ObjTst(obj2, "4", False) = 0) Then
            Return "bốn"
        End If
        If (ObjectType.ObjTst(obj2, "5", False) = 0) Then
            Return "năm"
        End If
        If (ObjectType.ObjTst(obj2, "6", False) = 0) Then
            Return "sáu"
        End If
        If (ObjectType.ObjTst(obj2, "7", False) = 0) Then
            Return "bảy"
        End If
        If (ObjectType.ObjTst(obj2, "8", False) = 0) Then
            Return "tám"
        End If
        If (ObjectType.ObjTst(obj2, "9", False) = 0) Then
            Return "chín"
        End If
        If (ObjectType.ObjTst(obj2, "0", False) = 0) Then
            str = "không"
        End If
        Return str
    End Function

    Public Shared Function readNumber(ByRef currr As Decimal) As String
        Dim sLeft As String = ""
        Dim flag As Boolean = False
        Dim expression As String = StringType.FromDecimal(Math.Round(currr, 0))
        expression = (New String("0"c, (13 - Strings.Len(expression))) & expression)
        If (ShortType.FromString(Strings.Mid(expression, 1, 1)) > 0) Then
            sLeft = (clsTools.readnum((Strings.Mid(expression, 1, 1))) & " ngàn ")
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 2, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 2, 1)) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 2, 1))) & " trăm ")
            ElseIf ((ShortType.FromString(Strings.Mid(expression, 3, 1)) Or ShortType.FromString(Strings.Mid(expression, 4, 1))) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 2, 1))) & " trăm ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 3, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 3, 1)) > 0) Then
                If (StringType.StrCmp(Strings.Mid(expression, 3, 1), "1", False) = 0) Then
                    sLeft = (sLeft & " mười ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 3, 1))) & " mươi ")
                End If
            ElseIf (ShortType.FromString(Strings.Mid(expression, 4, 1)) > 0) Then
                sLeft = (sLeft & "lẻ ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 4, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 4, 1)) > 0) Then
                If ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 4, 1), "5", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 3, 1))) > 0) Then
                    sLeft = (sLeft & "lăm tỷ ")
                ElseIf ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 4, 1), "1", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 3, 1))) > 0) Then
                    sLeft = (sLeft & "mốt tỷ ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 4, 1))) & " tỷ ")
                End If
            Else
                sLeft = (sLeft & "tỷ ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 5, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 5, 1)) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 5, 1))) & " trăm ")
            ElseIf ((ShortType.FromString(Strings.Mid(expression, 6, 1)) Or ShortType.FromString(Strings.Mid(expression, 7, 1))) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 5, 1))) & " trăm ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 6, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 6, 1)) > 0) Then
                If (StringType.StrCmp(Strings.Mid(expression, 6, 1), "1", False) = 0) Then
                    sLeft = (sLeft & "mười ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 6, 1))) & " mươi ")
                End If
            ElseIf (ShortType.FromString(Strings.Mid(expression, 7, 1)) > 0) Then
                sLeft = (sLeft & "lẻ ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 7, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 7, 1)) > 0) Then
                If ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 7, 1), "5", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 6, 1))) > 0) Then
                    sLeft = (sLeft & " lăm triệu ")
                ElseIf ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 7, 1), "1", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 6, 1))) > 0) Then
                    sLeft = (sLeft & "mốt triệu ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 7, 1))) & " triệu ")
                End If
            ElseIf ((ShortType.FromString(Strings.Mid(expression, 5, 1)) Or ShortType.FromString(Strings.Mid(expression, 6, 1))) > 0) Then
                sLeft = (sLeft & "triệu ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 8, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 8, 1)) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 8, 1))) & " trăm ")
            ElseIf ((ShortType.FromString(Strings.Mid(expression, 9, 1)) Or ShortType.FromString(Strings.Mid(expression, 10, 1))) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 8, 1))) & " trăm ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 9, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 9, 1)) > 0) Then
                If (StringType.StrCmp(Strings.Mid(expression, 9, 1), "1", False) = 0) Then
                    sLeft = (sLeft & " mười ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 9, 1))) & " mươi ")
                End If
            ElseIf (ShortType.FromString(Strings.Mid(expression, 10, 1)) > 0) Then
                sLeft = (sLeft & "lẻ ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 10, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 10, 1)) > 0) Then
                If ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 10, 1), "5", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 9, 1))) > 0) Then
                    sLeft = (sLeft & "lăm ngàn ")
                ElseIf ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 10, 1), "1", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 9, 1))) > 0) Then
                    sLeft = (sLeft & "mốt ngàn ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 10, 1))) & " ngàn ")
                End If
            ElseIf ((ShortType.FromString(Strings.Mid(expression, 8, 1)) Or ShortType.FromString(Strings.Mid(expression, 9, 1))) > 0) Then
                sLeft = (sLeft & "ngàn ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 11, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 11, 1)) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 11, 1))) & " trăm ")
            ElseIf ((ShortType.FromString(Strings.Mid(expression, 12, 1)) Or ShortType.FromString(Strings.Mid(expression, 13, 1))) > 0) Then
                sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 11, 1))) & " trăm ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 12, 1)) Or CShort(-(flag > False))) > 0) Then
            If (ShortType.FromString(Strings.Mid(expression, 12, 1)) > 0) Then
                If (StringType.StrCmp(Strings.Mid(expression, 12, 1), "1", False) = 0) Then
                    sLeft = (sLeft & " mười ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 12, 1))) & " mươi ")
                End If
            ElseIf (ShortType.FromString(Strings.Mid(expression, 13, 1)) > 0) Then
                sLeft = (sLeft & "lẻ ")
            End If
            flag = True
        End If
        If ((ShortType.FromString(Strings.Mid(expression, 13, 1)) Or CShort(-(flag > False))) > 0) Then
            Dim obj2 As Object
            If (ShortType.FromString(Strings.Mid(expression, 13, 1)) > 0) Then
                If ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 13, 1), "5", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 12, 1))) > 0) Then
                    If (ObjectType.ObjTst(obj2, "USD", False) = 0) Then
                        sLeft = (sLeft & "lăm Dollar ")
                    Else
                        sLeft = (sLeft & "lăm Đồng ")
                    End If
                ElseIf ((CShort(-((StringType.StrCmp(Strings.Mid(expression, 13, 1), "1", False) = 0) > False)) And ShortType.FromString(Strings.Mid(expression, 12, 1))) > 0) Then
                    If (ObjectType.ObjTst(obj2, "USD", False) = 0) Then
                        sLeft = (sLeft & "mốt Dollar ")
                    Else
                        sLeft = (sLeft & "mốt Đồng ")
                    End If
                ElseIf (ObjectType.ObjTst(obj2, "USD", False) = 0) Then
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 13, 1))) & " Dollar ")
                Else
                    sLeft = (sLeft & clsTools.readnum((Strings.Mid(expression, 13, 1))) & " Đồng ")
                End If
            ElseIf (StringType.StrCmp(sLeft, "", False) = 0) Then
                If (ObjectType.ObjTst(obj2, "USD", False) = 0) Then
                    sLeft = "không Dollar "
                Else
                    sLeft = "không Đồng "
                End If
            ElseIf (ObjectType.ObjTst(obj2, "USD", False) = 0) Then
                sLeft = (sLeft & "Dollar ")
            Else
                sLeft = (sLeft & "Đồng ")
            End If
            flag = True
        End If
        Return (Strings.UCase(Strings.Mid(Strings.Trim(sLeft), 1, 1)) & Strings.Mid(Strings.Trim(sLeft), 2))
    End Function

    Public Shared Sub TextBox_Change(ByVal txt As TextBox)
        If (StringType.StrCmp(txt.Text, "", False) = 0) Then
            txt.Text = "0"
        Else
            Dim obj2 As Object
            txt.Text = Strings.Format(DoubleType.FromString(txt.Text), "##,##0")
            clsTools.keybd_event(ByteType.FromObject(obj2), 0, 0, 0)
            txt.SelectionStart = Strings.Len(txt.Text)
        End If
    End Sub

    Public Shared Sub TextBox_Change1(ByVal txt As TextBox)
        If (StringType.StrCmp(txt.Text, "", False) = 0) Then
            txt.Text = StringType.FromInteger(0)
        Else
            If Not Information.IsNumeric(txt.Text) Then
                txt.Text = txt.Text.Substring(0, (txt.Text.Length - 1))
            End If
            If (StringType.StrCmp(Strings.Trim(Strings.Mid(txt.Text, 1, 1)), ",", False) = 0) Then
                Dim str As String = Strings.Mid(txt.Text, 2, Strings.Len(txt.Text))
                txt.Text = str
            ElseIf (Strings.InStr(txt.Text, ".", CompareMethod.Binary) = 0) Then
                Dim obj2 As Object
                txt.Text = Strings.Format(DoubleType.FromString(txt.Text), "##,##0")
                clsTools.keybd_event(ByteType.FromObject(obj2), 0, 0, 0)
                txt.SelectionStart = Strings.Len(txt.Text)
            End If
        End If
    End Sub

    Public Shared Sub TextBox_Change2(ByVal txt As UltraTextEditor)
        If (StringType.StrCmp(txt.Text, "", False) = 0) Then
            txt.Text = StringType.FromInteger(0)
        Else
            If Not Information.IsNumeric(txt.Text) Then
                txt.Text = txt.Text.Substring(0, (txt.Text.Length - 1))
            End If
            If (StringType.StrCmp(Strings.Trim(Strings.Mid(txt.Text, 1, 1)), ",", False) = 0) Then
                Dim str As String = Strings.Mid(txt.Text, 2, Strings.Len(txt.Text))
                txt.Text = str
            ElseIf (Strings.InStr(txt.Text, ".", CompareMethod.Binary) = 0) Then
                Dim obj2 As Object
                txt.Text = Strings.Format(DoubleType.FromString(txt.Text), "##,##0")
                clsTools.keybd_event(ByteType.FromObject(obj2), 0, 0, 0)
                txt.SelectionStart = Strings.Len(txt.Text)
            End If
        End If
    End Sub

    Public Shared Sub thongBao(ByVal mess As String)
        MessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
    End Sub

    Public Shared Sub thongbaoLoi(ByVal msgError As String)
        MessageBox.Show(("Thông báo lỗi: " & msgError & ChrW(13) & ChrW(10) & "Vui lòng liên hệ với chúng tôi để được hổ trợ"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    End Sub


    ' Nested Types
    Public Enum combo
        ' Fields
        mDefault = 0
        None = 1
        TấtCả = 2
        TấtCả_None = 3
    End Enum
End Class


