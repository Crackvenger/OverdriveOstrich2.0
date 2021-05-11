<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.pbScreen = New System.Windows.Forms.PictureBox()
        Me.GTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pbScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbScreen
        '
        Me.pbScreen.Location = New System.Drawing.Point(70, 73)
        Me.pbScreen.Name = "pbScreen"
        Me.pbScreen.Size = New System.Drawing.Size(1062, 548)
        Me.pbScreen.TabIndex = 0
        Me.pbScreen.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 733)
        Me.Controls.Add(Me.pbScreen)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbScreen As PictureBox
    Friend WithEvents GTimer As Timer
End Class
