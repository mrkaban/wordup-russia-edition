#Region "License: GNU GPL v3"
'This file is part of WordUp.

'WordUp is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.

'WordUp is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License
'along with WordUp.  If not, see <http://www.gnu.org/licenses/>.
#End Region

Imports System.Drawing
Imports System

Public Class MainForm

#Region "Global Declarations"
    'TODO: Please clean up unused/obsolete variables here, if any.
    Public currentdoctext As String 'Not Used?
    Public docchanged As Boolean = False 'Not Used?
    Private doc As System.Drawing.Printing.PrintDocument
    Private currentdocument 'Not Used?
    Private currentFile As String 'Not Used
    Private checkPrint As Integer 'Not Used

    Private dirty As Boolean
    Private filepath As String = ""
    Private DocumentTitle As String

    Dim stylearray(5) As Font
#End Region  '9 Variables

#Region "File Operations"
#Region "Shortcuts"



    Private Sub CloseDocButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseDocButton.Click
        closedoc()
        'Tabs.Dispose()
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        newdoc()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        newdoc()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        closedoc()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Me.SaveDoc()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Me.SaveDoc()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        saveasdoc()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        loaddoc()
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        loaddoc()
    End Sub

    Private Sub SaveDoc()
        If filepath = "" Then
            saveasdoc()
        Else
            RichTextBox1.SaveFile(filepath)
        End If
    End Sub
#End Region
    'Saving, Loading, Opening and Closing

    Public Sub New()
        DocumentTitle = String.Empty

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub closedoc()
        If dirty = True Then
            Dim res As MsgBoxResult = MsgBox("There are unsaved changes, would you like to save?", MsgBoxStyle.YesNoCancel)
            If res = MsgBoxResult.Yes Then
                saveasdoc()
                dirty = False
                closedoc()
            ElseIf res = MsgBoxResult.No Then
                dirty = False
                closedoc()
            Else
                Exit Sub
            End If
        Else
            RichTextBox1.Hide()
            RichTextBox1.Text = String.Empty
            ' RichTextBox2.Hide()
            ' RichTextBox2.Text = ""
            filepath = String.Empty
            DocumentTitle = String.Empty
            ChangeTitleBarText(True)

        End If
    End Sub

    Public Sub newdoc()
        If dirty = True Then
            Dim res As MsgBoxResult = MsgBox("Save?", MsgBoxStyle.YesNoCancel)
            If res = MsgBoxResult.Yes Then
                saveasdoc()
                dirty = False
                newdoc()
            ElseIf res = MsgBoxResult.No Then
                dirty = False
                ChangeTitleBarText(True)
                newdoc()
            Else
                Exit Sub
            End If
        Else
            RichTextBox1.Show()
            '   RichTextBox2.Show()
            RichTextBox1.Text = String.Empty
            '     RichTextBox2.Text = ""
            filepath = String.Empty
            DocumentTitle = String.Empty
            ChangeTitleBarText(True)
        End If
    End Sub

    Public Sub saveasdoc()
        Dim save As New SaveFileDialog
        save.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)| *.*"
        save.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        save.OverwritePrompt = True
        save.Title = "Save Document"
        If save.ShowDialog = Windows.Forms.DialogResult.OK Then
            filepath = save.FileName

            DocumentTitle = ParseDocFileNameFromFullPath(filepath)

            If save.FilterIndex = 1 Then
                RichTextBox1.SaveFile(filepath)
            ElseIf save.FilterIndex = 3 Then
                IO.File.WriteAllText(filepath, RichTextBox1.Text)
            Else
                IO.File.WriteAllText(filepath & ".txt", RichTextBox1.Text)
            End If
            dirty = False
            ChangeTitleBarText(True)
        End If
    End Sub

    Public Sub loaddoc()
        Dim open As New OpenFileDialog
        open.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|All Files (*.*)| *.*"
        open.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        open.Title = "Load Document"
        If open.ShowDialog = Windows.Forms.DialogResult.OK Then
            filepath = open.FileName
            DocumentTitle = ParseDocFileNameFromFullPath(filepath)
            If open.FilterIndex = 0 Then
                RichTextBox1.LoadFile(filepath)
            Else
                RichTextBox1.Text = IO.File.ReadAllText(filepath)
            End If
            dirty = False

            ChangeTitleBarText(True)
        End If
    End Sub

    Private Sub ChangeTitleBarText(ByVal pFileSaved As Boolean)
        Dim _Title As String

        If DocumentTitle.Length <> 0 Then
            _Title = DocumentTitle
        Else
            _Title = "Untitled Document"
        End If

        If pFileSaved Then
            Me.Text = String.Concat(_Title, " - WordUp (Development)")
        Else
            Me.Text = String.Concat(_Title, "* - WordUp (Development)")
        End If
    End Sub

    Private Function ParseDocFileNameFromFullPath(ByVal pFullPath As String)
        pFullPath.Replace("/", "\") 'Replace forward slashes with backslashes to prevent problems.
        Dim Arr As String() = pFullPath.Split("\"c)
        Dim FilName As String = Arr(Arr.Length - 1)

        Return FilName
    End Function


#End Region  'Complete

#Region "Basic Text Formatting"

#Region "Styles"

    Enum Styles
        Normal
        Paragraph
        Header1
        Header2
        Header3
        Header4
    End Enum
    Dim style As Styles

#End Region 'Incomplete. Collections of formatting settings.

#Region "Formatting"
    'TODO: Add strikethrough/out

    Private Sub BoldButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldButton.Click
        With Me.RichTextBox1
            If .SelectionFont IsNot Nothing Then
                Dim currentFont As System.Drawing.Font = .SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                If .SelectionFont.Bold = True Then
                    newFontStyle = currentFont.Style - System.Drawing.FontStyle.Bold
                    BoldButton.Checked = False
                Else
                    newFontStyle = currentFont.Style + System.Drawing.FontStyle.Bold
                    BoldButton.Checked = True
                End If

                .SelectionFont = New System.Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
            End If
        End With

        'With Me.RichTextBox2
        '    If .SelectionFont IsNot Nothing Then
        '        Dim currentFont As System.Drawing.Font = .SelectionFont
        '        Dim newFontStyle As System.Drawing.FontStyle

        '        If .SelectionFont.Bold = True Then
        '            newFontStyle = currentFont.Style - Drawing.FontStyle.Bold
        '        Else
        '            newFontStyle = currentFont.Style + Drawing.FontStyle.Bold
        '        End If

        '        .SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        '    End If
        'End With
    End Sub 'Bold

    Private Sub ItalicButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicButton.Click
        With Me.RichTextBox1
            If .SelectionFont IsNot Nothing Then
                Dim currentFont As System.Drawing.Font = .SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                If .SelectionFont.Italic = True Then
                    newFontStyle = currentFont.Style - System.Drawing.FontStyle.Italic
                    ItalicButton.Checked = False
                Else
                    newFontStyle = currentFont.Style + System.Drawing.FontStyle.Italic
                    ItalicButton.Checked = True
                End If

                .SelectionFont = New System.Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
            End If
        End With

        'With Me.RichTextBox2
        '    If .SelectionFont IsNot Nothing Then
        '        Dim currentFont As System.Drawing.Font = .SelectionFont
        '        Dim newFontStyle As System.Drawing.FontStyle

        '        If .SelectionFont.Bold = True Then
        '            newFontStyle = currentFont.Style - Drawing.FontStyle.Italic
        '        Else
        '            newFontStyle = currentFont.Style + Drawing.FontStyle.Italic
        '        End If

        '        .SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        '    End If
        'End With
    End Sub 'Italic

    Private Sub UnderlineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineButton.Click
        With Me.RichTextBox1
            If .SelectionFont IsNot Nothing Then
                Dim currentFont As System.Drawing.Font = .SelectionFont
                Dim newFontStyle As System.Drawing.FontStyle

                If .SelectionFont.Italic = True Then
                    newFontStyle = currentFont.Style - System.Drawing.FontStyle.Underline
                    UnderlineButton.Checked = False
                Else
                    newFontStyle = currentFont.Style + System.Drawing.FontStyle.Underline
                    UnderlineButton.Checked = True
                End If

                .SelectionFont = New System.Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
            End If
        End With

        'With Me.RichTextBox2
        '    If .SelectionFont IsNot Nothing Then
        '        Dim currentFont As System.Drawing.Font = .SelectionFont
        '        Dim newFontStyle As System.Drawing.FontStyle

        '        If .SelectionFont.Underline = True Then
        '            newFontStyle = currentFont.Style - Drawing.FontStyle.Underline
        '        Else
        '            newFontStyle = currentFont.Style + Drawing.FontStyle.Underline
        '        End If

        '        .SelectionFont = New Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        '    End If
        'End With
    End Sub 'Underline

#End Region 'Complete. Bold, Italic etc. 

#Region "Aligning Text"

    'There's no way to get Justification without a custom or 3rd party control, 
    'as per extensive research. ~Zach S.

    Private Sub TextAlignLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAlignLeft.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
        TextAlignRight.CheckState = CheckState.Unchecked
        CenterText.CheckState = CheckState.Unchecked
        TextAlignLeft.CheckState = CheckState.Checked
        'RichTextBox1.
    End Sub 'Align Left

    Private Sub TextAlignRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAlignRight.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
        TextAlignLeft.CheckState = CheckState.Unchecked
        CenterText.CheckState = CheckState.Unchecked
        TextAlignRight.CheckState = CheckState.Checked
    End Sub 'Align Right

    Private Sub CenterText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterText.Click
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        TextAlignRight.CheckState = CheckState.Unchecked
        TextAlignLeft.CheckState = CheckState.Unchecked
        CenterText.CheckState = CheckState.Checked
    End Sub 'Align Center

#End Region 'Complete. See inside for Justification notes.

#Region "Selection and Highlight Colors" 'Conpleted

#Region "Highlight Color"

    Private Sub TextHighLightColor_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextHighLightColor.ButtonClick
        ColorDialogHighlight.ShowDialog()
        RichTextBox1.SelectionBackColor = ColorDialogHighlight.Color
    End Sub 'Show Text Highlight Color Dialog

    Private Sub ChooseHighlightColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseHighlightColorToolStripMenuItem.Click
        ColorText.ShowDialog()
        RichTextBox1.SelectionColor = ColorText.Color
    End Sub 'Highlight Color Dialog confirmation

#End Region 'Complete

#Region "Text Color"

    Private Sub ChooseTextColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseTextColorToolStripMenuItem.Click
        ColorDialogHighlight.ShowDialog()
        RichTextBox1.SelectionBackColor = ColorDialogHighlight.Color
    End Sub 'Show Text Color Dialog

    Private Sub TextColor_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextColor.ButtonClick
        ColorText.ShowDialog()
        RichTextBox1.SelectionColor = ColorText.Color
    End Sub 'Text Color confirmation

#End Region 'Complete

#End Region 'Complete.

#End Region  'Complete. See inside for justification notes.

#Region "Document Updating"

    'Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RichTextBox2.Rtf = RichTextBox1.Rtf
    'End Sub

    'Private Sub RichTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RichTextBox1.Rtf = RichTextBox2.Rtf
    'End Sub

#End Region 'To be used for synching the views (Normal, Print, Web) of the opened document.

#Region "Insert"

#Region "Insert Time & Date"

    Private Sub TimeDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToolStripMenuItem.Click
        Dim hour As Integer = My.Computer.Clock.LocalTime.TimeOfDay.Hours   'The user's current hour
        Dim ampm As String                                                  'Stores if it's AM/PM
        Dim min As Integer = My.Computer.Clock.LocalTime.TimeOfDay.Minutes  'The user's current minute
        Dim min2 As String
        If hour > 12 Then       'If user's hour is more than 12,
            hour = hour - 12    'minus 12 to get 12 hour time.
            ampm = " PM "       'Set to PM.
        Else                    'If it's not over 12 (i.e on the 24hr clock),
            ampm = " AM "       'just use AM.
        End If
        If min < 10 Then        'If the unit digit of minutes is less than ten,
            min2 = "0" + min    'Add digit 0 (eg. time:13:09, therefore: min = 9. Change to: min2 = 09
        Else                    'If it's 10 or over (i.e double digit)
            min2 = min          'just use the minutes given by the system.
        End If
        RichTextBox1.AppendText(hour & ":" & min2 & ampm & My.Computer.Clock.LocalTime.Date) 'Inserts the hour string, then ":" sign then min2 then AM or PM {hour:min2ampm} into the RichTextBox. (Append adds on to existing text.)
    End Sub

#End Region 'Complete. Inserts time and date.

#Region "Insert Image"

    Private Sub ImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageToolStripMenuItem.Click

        OpenFileDialog1.Title = "Insert Image File"
        OpenFileDialog1.DefaultExt = "rtf"
        OpenFileDialog1.Filter = "PNG Files|*.png|Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|Other Images| *.*"
        OpenFileDialog1.FilterIndex = 1

        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = "" Then Exit Sub

        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Dim img As Image
            img = Image.FromFile(strImagePath)
            Clipboard.SetDataObject(img)
            Dim df As DataFormats.Format
            df = DataFormats.GetFormat(DataFormats.Bitmap)
            If Me.RichTextBox1.CanPaste(df) Then
                Me.RichTextBox1.Paste(df)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to insert image format selected.", "Paste", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region 'Complete for PNG, BMP, JPG and GIF files.

#End Region 'Incomplete

#Region "Printing"

    'Thanks to  Scott Lysle for printing controls and methods

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintPreviewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripButton.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Public Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim prtrich As New RichTextBoxPrintCtrl
        ' Adapted from Microsoft's example for extended richtextbox control
        '
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = RichTextBox1.Print(checkPrint, RichTextBox1.TextLength, e)

        ' Look for more pages
        If checkPrint < RichTextBox1.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub
#End Region 'Incomplete.

#Region "Advanced Text Formating"

#Region "Font Styles"
    Private Sub StylesSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StylesSelector.DropDownClosed
        Select Case StylesSelector.SelectedIndex
            Case 0
                style = Styles.Normal
            Case 1
                style = Styles.Paragraph
            Case 2
                style = Styles.Header1
            Case 3
                style = Styles.Header2
            Case 4
                style = Styles.Header3
            Case 5
                style = Styles.Header4
        End Select
        applystyle()
    End Sub 'Complete

    Private Sub applystyle()
        Select Case style
            Case Styles.Normal
                ApplyFont(RichTextBox1, stylearray(0).FontFamily.Name, stylearray(0).Size, RichTextBox1.SelectionFont.Style)
            Case Styles.Paragraph
                ApplyFont(RichTextBox1, stylearray(1).FontFamily.Name, stylearray(1).Size, RichTextBox1.SelectionFont.Style)
            Case Styles.Header1
                ApplyFont(RichTextBox1, stylearray(2).FontFamily.Name, stylearray(2).Size, RichTextBox1.SelectionFont.Style)
            Case Styles.Header2
                ApplyFont(RichTextBox1, stylearray(3).FontFamily.Name, stylearray(3).Size, RichTextBox1.SelectionFont.Style)
            Case Styles.Header3
                ApplyFont(RichTextBox1, stylearray(4).FontFamily.Name, stylearray(4).Size, RichTextBox1.SelectionFont.Style)
            Case Styles.Header4
                ApplyFont(RichTextBox1, stylearray(5).FontFamily.Name, stylearray(5).Size, RichTextBox1.SelectionFont.Style)
        End Select
    End Sub 'Complete, the array needs to be filled

    Private Sub FontSelector_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontSelector.LostFocus
        Try
            ApplyFont(RichTextBox1, FontSelector.Text, RichTextBox1.SelectionFont.SizeInPoints, RichTextBox1.SelectionFont.Style)
        Catch
            MsgBox("Error changing font", MsgBoxStyle.OkOnly)
        End Try
    End Sub 'Complete

    Private Sub FontSizeSelector_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontSizeSelector.LostFocus
        Try
            ApplyFont(RichTextBox1, RichTextBox1.SelectionFont.Name, FontSizeSelector.Text, RichTextBox1.SelectionFont.Style)
        Catch
            MsgBox("Error changing font", MsgBoxStyle.OkOnly)
        End Try
    End Sub 'Complete

    Private Sub ApplyFont(ByVal textbox As RichTextBox, ByVal FamilyName As String, ByVal Size As Single, ByVal Style As System.Drawing.FontStyle)
        textbox.SelectionFont = New Font(FamilyName, Size, Style, GraphicsUnit.Point)
    End Sub 'Complete

#End Region 'Incomplete

#End Region 'Incomplete. Major work to be done here.

#Region "Edit"

#Region "Undo/Redo"

    Public Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        If RichTextBox1.CanUndo = True Then
            RichTextBox1.Undo()
        Else
            StatusText.Text = "No operations to undo"
        End If
        If RichTextBox1.CanUndo = False Then
            UndoToolStripMenuItem.Enabled = False
        Else
            UndoToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        If RichTextBox1.CanRedo = True Then
            RichTextBox1.Redo()
        Else
            StatusText.Text = "No operations to redo"
            RedoToolStripMenuItem.Enabled = False
        End If
        If RichTextBox1.CanRedo = False Then
            RedoToolStripMenuItem.Enabled = False
        Else
            RedoToolStripMenuItem.Enabled = True
        End If
    End Sub

#End Region 'Complete.

#Region "Clipboard Functions"

#Region "ToolStrip Buttons"

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        RichTextBox1.Cut()
        'RichTextBox2.Cut()
    End Sub

    Private Sub CopyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripButton.Click
        RichTextBox1.Copy()
        ' RichTextBox2.Copy()
    End Sub

    Private Sub PasteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripButton.Click
        RichTextBox1.Paste()
        'RichTextBox2.Paste()
    End Sub

#End Region 'Complete.

#Region "Menu Items"

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
        'RichTextBox2.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
        'RichTextBox2.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
        'RichTextBox2.Paste()
    End Sub
#End Region 'Complete.

#End Region 'Complete; Contain Cut/Copy/Paste.

#Region "Others"

    Private Sub FindReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fr.Click
        Find_Replace.Show()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

#End Region 'Complete. Find/Replace and Select All.

#End Region 'Complete, for current menu. To be expanded with new Edit menu items.

#Region "Misc"
    Public Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i As Integer = 0
        FontSelector.Items.Clear()
        Do While i < FontFamily.Families.Length
            FontSelector.Items.Add(FontFamily.Families(i).Name)
            i = i + 1
        Loop

        'Disable View > Zoom out if zoom level is 1 (causes crash if goes less than 1)
        If RichTextBox1.ZoomFactor = 1 Then
            ZoomOutToolStripMenuItem.Enabled = False
            'ActualSizeToolStripMenuItem.CheckState = CheckState.Checked
        End If

        If SearchBox.Text = "Search Help..." Then
            SearchBox.ForeColor = Color.Gray
        End If

    End Sub 'Events that take place as the form loads

    Private Sub RichTextBox1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.SelectionChanged
        FontSelector.SelectedItem = RichTextBox1.SelectionFont.Name
        FontSizeSelector.SelectedItem = RichTextBox1.SelectionFont.Size
        With RichTextBox1.SelectionFont
            If .Style = FontStyle.Bold Then
                BoldButton.Checked = False
            End If
            If .Style = FontStyle.Italic Then
                ItalicButton.Checked = False
            End If
            If .Style = FontStyle.Underline Then
                UnderlineButton.Checked = False
            End If
        End With
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        dirty = True
        UndoToolStripMenuItem.Enabled = True
        ChangeTitleBarText(False)
    End Sub

    Private Sub LockButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockButton.Click
        If LockButton.Checked = True Then
            RichTextBox1.ReadOnly = True
            LockButton.ToolTipText = "Document is locked"
        Else
            RichTextBox1.ReadOnly = False
            LockButton.ToolTipText = "Document is unlocked"
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        closedoc()
        Application.Exit()
    End Sub 'When the user exits through File > Exit, Close Button or Alt - F4.

#End Region 'Others, such as OnLoad, Lock etc.

#Region "View"

#Region "View modes"

    'View > Normal
    Private Sub DraftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DraftToolStripMenuItem.Click
        Tabs.SelectedTab = NormalTab1
    End Sub

    'View > Print Layout
    Private Sub PrintLayoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintLayoutToolStripMenuItem.Click
        Tabs.SelectedTab = PrintTab
    End Sub

    'View > Web Layout
    Private Sub WebLayoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebLayoutToolStripMenuItem.Click
        Tabs.SelectedTab = WebTab
    End Sub

#End Region

#End Region 'View Menu.

#Region "Help"

#Region "Help Menu"

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Process.Start("http://apps.sourceforge.net/mediawiki/wordup/")
    End Sub 'Help > Contents

    Private Sub OnlineSupportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnlineSupportToolStripMenuItem.Click
        Process.Start("https://sourceforge.net/tracker2/?group_id=240123&atid=1111934")
    End Sub 'Help > Online Support

    Private Sub BugReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BugReportToolStripMenuItem.Click
        Process.Start("http://xn--90abhbolvbbfgb9aje4m.xn--p1ai/")
    End Sub 'Help > Bug Report

    Private Sub WordUpHomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordUpHomeToolStripMenuItem.Click
        Dim webAddress As String = "http://sourceforge.net/projects/wordup"
        Process.Start(webAddress)
    End Sub 'Help > WordUp Home

    Private Sub ContributeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContributeToolStripMenuItem.Click
        Process.Start("http://sourceforge.net/projects/wordup")
    End Sub 'Help > Contribute

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        'On clicking About... in the Help menu, show the AboutForm
        AboutForm.ShowDialog()
    End Sub 'Help > About

#End Region 'Complete.

#Region "Instant Search Help Box"

    Public Sub SearchBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.Click

        If SearchBox.Text = "Search Help..." Then 'Only if it's "Search Help..." clear it, as it could be a
            SearchBox.TextBox.Clear()             'nuisance. However we want to retain user-entered text.
        End If

        CheckSearchTextFalse() 'Makes the user-entered text black

    End Sub 'Clears the "Search Help" text as the user clicks in the textbox

    Public Sub SearchBox_KeyPress(ByVal sender As Object, ByVal e As KeyEventArgs) Handles SearchBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim SearchString As String
            SearchString = SearchBox.Text 'Get the string entered into the textbox
            Dim URL As String 'Process.Start can only handle one argument. This is the combined string
            URL = ("http://apps.sourceforge.net/mediawiki/wordup/index.php?search=" + SearchString + "&go=Go") 'Combine them. {Initial URL + String + Instruction that says go directly to the page if it exists}
            Process.Start(URL) 'Starts the combined string above, in the user's favorite browser
        End If
    End Sub 'Goes to the wiki with the entered text

    Private Sub SearchBox_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.Leave
        If SearchBox.Text = "" Then                         'If blank,
            SearchBox.TextBox.AppendText("Search Help...")  'insert the phrase
        End If
        CheckSearchTextTrue() 'Turn the "Search Help..." gray.
    End Sub 'If blank, returns "Search Help..." to the textbox

    Function CheckSearchTextTrue()
        If SearchBox.Text = "Search Help..." Then
            SearchBox.ForeColor = Color.Gray
        End If
        Return 0
    End Function 'If "Search Help..." make text gray.

    Function CheckSearchTextFalse()
        If Not SearchBox.Text = "Search Help..." Then
            SearchBox.ForeColor = Color.Black
        End If
        Return 0
    End Function 'If not "Search Help..." make text black.

#End Region 'Complete. Contains code for the search box.


#End Region 'Complete. Contains Help menu and Search Help functions.

#Region "Zooming"

    Private Sub ZoomInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomInToolStripMenuItem.Click
        Dim RTBZoom As Int32
        RTBZoom = RichTextBox1.ZoomFactor
        Dim RTBZoom2 As Int32
        RTBZoom2 = RTBZoom + 0.5
        RichTextBox1.ZoomFactor = RTBZoom2

        ToggleAT()
    End Sub 'Zoom In

    Private Sub ActualSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualSizeToolStripMenuItem.Click
        RichTextBox1.ZoomFactor = 1.0
        ToggleAT()
    End Sub 'Actual Size (100%)

    Private Sub ZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomOutToolStripMenuItem.Click
        Dim RTBZoom3 As Int32
        RTBZoom3 = RichTextBox1.ZoomFactor - 1
        RichTextBox1.ZoomFactor = RTBZoom3

        ToggleAT()
    End Sub 'Zoom Out

    Private Sub CustomToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomToolStripMenuItem1.Click
        ZoomDialog.ShowDialog()
        ToggleAT()
    End Sub 'Dialog for Zooming wide range Min-Max (64 sizes)

    Function ToggleAT()
        If Not RichTextBox1.ZoomFactor = 1 Then
            ZoomOutToolStripMenuItem.Enabled = True
            ActualSizeToolStripMenuItem.CheckState = CheckState.Unchecked
        End If
        If RichTextBox1.ZoomFactor = 1 Then
            ZoomOutToolStripMenuItem.Enabled = False
            ActualSizeToolStripMenuItem.CheckState = CheckState.Checked
        End If
        Return 0
    End Function

    Private Sub CommunityForumsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommunityForumsToolStripMenuItem.Click

    End Sub
#End Region 'Complete. Contains code for zooming the document.

End Class