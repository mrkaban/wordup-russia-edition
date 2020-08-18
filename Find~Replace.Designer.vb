<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Find_Replace
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnReplaceAll = New System.Windows.Forms.Button()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReplacementText = New System.Windows.Forms.TextBox()
        Me.btnFindNext = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchTerm = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Все открытые документы", "Текущий документ", "Текущая страница", "выбор"})
        Me.ComboBox1.Location = New System.Drawing.Point(21, 73)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 21)
        Me.ComboBox1.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Заменить на:"
        '
        'btnReplaceAll
        '
        Me.btnReplaceAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnReplaceAll.Location = New System.Drawing.Point(309, 106)
        Me.btnReplaceAll.Name = "btnReplaceAll"
        Me.btnReplaceAll.Size = New System.Drawing.Size(90, 23)
        Me.btnReplaceAll.TabIndex = 48
        Me.btnReplaceAll.Text = "Заменить всё"
        Me.btnReplaceAll.UseVisualStyleBackColor = True
        '
        'btnReplace
        '
        Me.btnReplace.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnReplace.Location = New System.Drawing.Point(231, 106)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(72, 23)
        Me.btnReplace.TabIndex = 47
        Me.btnReplace.Text = "Заменить"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnFind.Location = New System.Drawing.Point(68, 106)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(61, 23)
        Me.btnFind.TabIndex = 46
        Me.btnFind.Text = "Искать"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(334, 83)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(95, 17)
        Me.CheckBox5.TabIndex = 45
        Me.CheckBox5.Text = "Искать вверх"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Location = New System.Drawing.Point(171, 83)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(142, 17)
        Me.CheckBox4.TabIndex = 44
        Me.CheckBox4.Text = "Искать скрытый текст"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(334, 60)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(114, 17)
        Me.CheckBox3.TabIndex = 43
        Me.CheckBox3.Text = "Учитывать слова"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'chkMatchCase
        '
        Me.chkMatchCase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMatchCase.AutoSize = True
        Me.chkMatchCase.Location = New System.Drawing.Point(171, 60)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(124, 17)
        Me.chkMatchCase.TabIndex = 42
        Me.chkMatchCase.Text = "Учитывать регистр"
        Me.chkMatchCase.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Искать в:"
        '
        'txtReplacementText
        '
        Me.txtReplacementText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplacementText.Location = New System.Drawing.Point(231, 34)
        Me.txtReplacementText.Multiline = True
        Me.txtReplacementText.Name = "txtReplacementText"
        Me.txtReplacementText.Size = New System.Drawing.Size(236, 20)
        Me.txtReplacementText.TabIndex = 40
        '
        'btnFindNext
        '
        Me.btnFindNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnFindNext.Location = New System.Drawing.Point(135, 106)
        Me.btnFindNext.Name = "btnFindNext"
        Me.btnFindNext.Size = New System.Drawing.Size(90, 23)
        Me.btnFindNext.TabIndex = 39
        Me.btnFindNext.Text = "Искать далее"
        Me.btnFindNext.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Искать:"
        '
        'txtSearchTerm
        '
        Me.txtSearchTerm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSearchTerm.Location = New System.Drawing.Point(23, 34)
        Me.txtSearchTerm.Multiline = True
        Me.txtSearchTerm.Name = "txtSearchTerm"
        Me.txtSearchTerm.Size = New System.Drawing.Size(202, 20)
        Me.txtSearchTerm.TabIndex = 37
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(405, 106)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Закрыть"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Find_Replace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 147)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnReplaceAll)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.chkMatchCase)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtReplacementText)
        Me.Controls.Add(Me.btnFindNext)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearchTerm)
        Me.Controls.Add(Me.Button2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Find_Replace"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Поиск и замена"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnReplaceAll As System.Windows.Forms.Button
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReplacementText As System.Windows.Forms.TextBox
    Friend WithEvents btnFindNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchTerm As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
