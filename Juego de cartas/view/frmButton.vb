Public Class frmButton
    Inherits System.Windows.Forms.Form

    ' Declaring array of (26) Buttons
    Private btnArray(26) As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents btnAddButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.btnAddButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(96, 16)
        Me.label1.TabIndex = 31
        Me.label1.Text = "Click any Button"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(244, 96)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 24)
        Me.btnExit.TabIndex = 30
        Me.btnExit.Text = "Exit"
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.SystemColors.Control
        Me.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlButtons.Location = New System.Drawing.Point(16, 36)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(316, 43)
        Me.pnlButtons.TabIndex = 29
        '
        'btnAddButton
        '
        Me.btnAddButton.Location = New System.Drawing.Point(144, 96)
        Me.btnAddButton.Name = "btnAddButton"
        Me.btnAddButton.Size = New System.Drawing.Size(88, 24)
        Me.btnAddButton.TabIndex = 28
        Me.btnAddButton.Text = "Button array"
        '
        'frmButton
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(346, 131)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.btnAddButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmButton"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AddButtons()
        Dim xPos As Integer = 0
        Dim yPos As Integer = 0
        Dim n As Integer = 0

        For i As Integer = 0 To 25
            ' Initialize one variable
            btnArray(i) = New System.Windows.Forms.Button
        Next i

        While (n < 26)
            With (btnArray(n))
                .Tag = n + 1 ' Tag of button
                .Width = 24 ' Width of button
                .Height = 20 ' Height of button
                If (n = 13) Then ' Location of second line of buttons:
                    xPos = 0
                    yPos = 20
                End If
                ' Location of button:
                .Left = xPos
                .Top = yPos
                ' Add buttons to a Panel:
                pnlButtons.Controls.Add(btnArray(n)) ' Let panel hold the Buttons
                xPos = xPos + .Width ' Left of next button
                ' Write English Character:
                .Text = Chr(n + 65)

                ' ****************************************************************
                ' You can use following code instead previous line
                ' Dim Alphabet() As Char = {"A", "B", "C", "D", "E", "F", "G", _
                ' "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", _
                ' "U", "V", "W", "X", "Y", "Z"}
                ' .Text = Alphabet(n)
                ' ****************************************************************

                ' for Event of click Button
                AddHandler .Click, AddressOf Me.ClickButton
                n += 1
            End With
        End While

        btnAddButton.Enabled = False ' not need now to this button now
        label1.Visible = True
    End Sub

    ' Result of (Click Button) event, get the text of button
    Public Sub ClickButton(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Dim btn As Button = sender
        MessageBox.Show("You clicked character [" + btn.Text + "]")
    End Sub

    Private Sub btnAddButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddButton.Click
        AddButtons()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
