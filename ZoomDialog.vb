Imports System.Windows.Forms

Public Class ZoomDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        MainForm.RichTextBox1.ZoomFactor = 1
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub TrackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        Dim TrackZoomLevel As Int32
        TrackZoomLevel = TrackBar1.Value
        MainForm.RichTextBox1.ZoomFactor = TrackZoomLevel
    End Sub

    Private Sub ResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetButton.Click
        TrackBar1.Value = 1
    End Sub

End Class
