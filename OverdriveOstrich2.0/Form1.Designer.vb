<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pbScreen = New System.Windows.Forms.PictureBox()
        Me.GTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.pbScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbScreen
        '
        Me.pbScreen.Location = New System.Drawing.Point(50, 62)
        Me.pbScreen.Name = "pbScreen"
        Me.pbScreen.Size = New System.Drawing.Size(669, 319)
        Me.pbScreen.TabIndex = 0
        Me.pbScreen.TabStop = False
        '
        'GTimer
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(101, 448)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Spacebar - Jump"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 478)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Left Arrow - run left"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(101, 505)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Right Arrow = run right"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(101, 534)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Up arrow - skipping"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 631)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbScreen)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbScreen As PictureBox
    Friend WithEvents GTimer As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
