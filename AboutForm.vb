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


Public Class AboutForm
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        License.ShowDialog()

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Dim webAddress As String = "http://www.openoffice.org"

        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim webAddress As String = "http://www.gnu.org/licenses/gpl.html"

        Process.Start(webAddress)

    End Sub

    Private Sub WebSiteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebSiteButton.Click
        Dim webAddress As String = "http://sourceforge.net/projects/wordup"

        Process.Start(webAddress)
    End Sub

    Private Sub DevButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevButton.Click
        Dim webAddress As String = "http://sourceforge.net/projects/wordup"

        Process.Start(webAddress)
    End Sub
End Class