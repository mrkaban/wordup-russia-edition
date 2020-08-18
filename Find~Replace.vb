Public Class Find_Replace

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim StartPosition As Integer

        Dim SearchType As CompareMethod



        If chkMatchCase.Checked = True Then

            SearchType = CompareMethod.Binary

        Else

            SearchType = CompareMethod.Text

        End If



        StartPosition = InStr(1, MainForm.RichTextBox1.Text, txtSearchTerm.Text, SearchType)



        If StartPosition = 0 Then

            MessageBox.Show("String: '" & txtSearchTerm.Text.ToString() & "'not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            Exit Sub

        End If



        MainForm.RichTextBox1.Select(StartPosition - 1, txtSearchTerm.Text.Length)

        MainForm.RichTextBox1.ScrollToCaret()

        MainForm.Focus()

    End Sub

    Private Sub btnFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        Dim StartPosition As Integer = MainForm.RichTextBox1.SelectionStart + 2

        Dim SearchType As CompareMethod



        If chkMatchCase.Checked = True Then

            SearchType = CompareMethod.Binary

        Else

            SearchType = CompareMethod.Text

        End If



        StartPosition = InStr(StartPosition, MainForm.RichTextBox1.Text, txtSearchTerm.Text, SearchType)



        If StartPosition = 0 Then

            MessageBox.Show("String: '" & txtSearchTerm.Text.ToString() & "' not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            Exit Sub

        End If



        MainForm.RichTextBox1.Select(StartPosition - 1, txtSearchTerm.Text.Length)

        MainForm.RichTextBox1.ScrollToCaret()

        MainForm.Focus()

    End Sub

    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        If MainForm.RichTextBox1.SelectedText.Length <> 0 Then

            MainForm.RichTextBox1.SelectedText = txtReplacementText.Text

        End If



        Dim StartPosition As Integer = MainForm.RichTextBox1.SelectionStart + 2

        Dim SearchType As CompareMethod



        If chkMatchCase.Checked = True Then

            SearchType = CompareMethod.Binary

        Else

            SearchType = CompareMethod.Text

        End If



        StartPosition = InStr(StartPosition, MainForm.RichTextBox1.Text, txtSearchTerm.Text, SearchType)



        If StartPosition = 0 Then

            MessageBox.Show("String: '" & txtSearchTerm.Text.ToString() & "' not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            Exit Sub

        End If



        MainForm.RichTextBox1.Select(StartPosition - 1, txtSearchTerm.Text.Length)

        MainForm.RichTextBox1.ScrollToCaret()

        MainForm.Focus()

    End Sub

    Private Sub btnReplaceAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceAll.Click



        Dim currentPosition As Integer = MainForm.RichTextBox1.SelectionStart

        Dim currentSelect As Integer = MainForm.RichTextBox1.SelectionLength



        MainForm.RichTextBox1.Rtf = Replace(MainForm.RichTextBox1.Rtf, Trim(txtSearchTerm.Text), Trim(txtReplacementText.Text))

        MainForm.RichTextBox1.SelectionStart = currentPosition

        MainForm.RichTextBox1.SelectionLength = currentSelect

        MainForm.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
        Me.Hide()
    End Sub
End Class