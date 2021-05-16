
Public Enum States
    intro
    stand
    dash
    jump
    brake
    shoot
    drop
    leap
End Enum

Structure Sprite
    Public x, y As Integer
    Public Vx, Vy, Px, Py As Integer
    Public Cur_State As States
    Public iframe As Integer
    Public timerF As Integer
End Structure

Public Class Form1
    Dim bmp As New Drawing.Bitmap(512, 356)
    Dim gfx As Graphics = Graphics.FromImage(bmp)
    Dim bcg As Bitmap = Bitmap.FromFile("bg.png")
    Dim ss As Bitmap = Bitmap.FromFile("Overdrive Ostrich.png")
    Dim Mask As Bitmap = Bitmap.FromFile("MaskOverdrive Ostrich.png")
    Dim bcgX, bcgY As Integer
    Dim Direction As String = "right"
    Dim Rect As FrameElement
    Public Head As FrameElement
    Dim Ostrich As New Sprite
    Dim BcgPos As Integer
    Dim KeyPressed As Boolean = False

    Private Sub getImage(newCenterPoint As Point, newTop As Integer, newBottom As Integer, newLeft As Integer, newRight As Integer,
    newIndex As Integer, newMaxFrameTimer As Integer)
        Dim n As FrameElement = New FrameElement(newCenterPoint, newTop, newBottom, newLeft, newRight, newIndex, newMaxFrameTimer)
        n.nextFrame = Head
        Head = n
    End Sub

    Public Function OffScreen(ByVal x, ByVal y) As Boolean
        Dim Left, Right As Integer
        Dim Width, Height As Integer

        Width = Rect.Right - Rect.Left
        Height = Rect.Bottom - Rect.Top
        Left = x
        Right = x + Width
        If Left < 0 And Right < 0 Or Left > pbScreen.Width And Right > pbScreen.Width Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub delList()
        Head = Nothing
    End Sub

    Sub Reset()
        Rect = Head
    End Sub

    Sub Blit(ByVal MaskSub As Bitmap, ByVal Sprite As Bitmap, ByVal bcg As Bitmap, ByVal x As Integer, ByVal y As Integer)
        Dim spriteColor As Color
        Dim black As Color = Color.Black
        Dim CounterX = 0
        Dim CounterY = 0
        Dim PositionX = 0
        Dim PositionY = 0

        For i = Rect.Top To Rect.Bottom - 1
            For j = Rect.Left To Rect.Right - 1
                spriteColor = MaskSub.GetPixel(j, i)
                If spriteColor.ToArgb = black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX >= 0) And (PositionX < bmp.Width) And (PositionY >= 0) And (PositionY < bmp.Height)) Then
                        bmp.SetPixel(PositionX, PositionY, spriteColor)
                    End If
                End If
                CounterX += 1
            Next
            CounterX = 0
            CounterY += 1
        Next
        CounterX = 0
        CounterY = 0
        PositionX = 0
        PositionY = 0

        For i = Rect.Top To Rect.Bottom - 1
            For j = Rect.Left To Rect.Right - 1
                spriteColor = ss.GetPixel(j, i)
                If spriteColor.ToArgb <> black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX >= 0) And (PositionX < bmp.Width) And (PositionY >= 0) And (PositionY < bmp.Height)) Then
                        bmp.SetPixel(PositionX, PositionY, spriteColor)
                    End If
                End If
                CounterX += 1
            Next
            CounterX = 0
            CounterY += 1
        Next

    End Sub

    Sub BlitFlip(ByVal MaskSub As Bitmap, ByVal Sprite As Bitmap, ByVal bcg As Bitmap, ByVal x As Integer, ByVal y As Integer)
        Dim spriteColor As Color
        Dim black As Color = Color.Black
        Dim CounterX = 0
        Dim CounterY = 0
        Dim PositionX = 0
        Dim PositionY = 0

        For i = Rect.Top To Rect.Bottom - 1
            For j = Rect.Right To Rect.Left Step -1
                spriteColor = MaskSub.GetPixel(j, i)
                If spriteColor.ToArgb = black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX >= 0) And (PositionX < bmp.Width) And (PositionY >= 0) And (PositionY < bmp.Height)) Then
                        bmp.SetPixel(PositionX, PositionY, spriteColor)
                    End If
                End If
                CounterX += 1
            Next
            CounterX = 0
            CounterY += 1
        Next
        CounterX = 0
        CounterY = 0
        PositionX = 0
        PositionY = 0

        For i = Rect.Top To Rect.Bottom - 1
            For j = Rect.Right To Rect.Left Step -1
                spriteColor = ss.GetPixel(j, i)
                If spriteColor.ToArgb <> black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX >= 0) And (PositionX < bmp.Width) And (PositionY >= 0) And (PositionY < bmp.Height)) Then
                        bmp.SetPixel(PositionX, PositionY, spriteColor)
                    End If
                End If
                CounterX += 1
            Next
            CounterX = 0
            CounterY += 1
        Next
    End Sub

    Sub alter(ByVal Cur_State)
        Ostrich.Cur_State = Cur_State
    End Sub

    Private Sub SetSprite(ByVal Vx, ByVal Vy, ByVal x, ByVal y)
        Ostrich.Vx = Vx
        Ostrich.Vy = Vy
        Ostrich.x = x
        Ostrich.y = y
    End Sub

    Sub Intro()
        Ostrich.Cur_State = States.intro
        delList()
        getImage(New Point(484, 128), 88, 160, 444, 524, 22, 9)
        getImage(New Point(416, 128), 88, 160, 390, 442, 21, 2)
        getImage(New Point(362, 128), 88, 160, 342, 382, 20, 2)
        getImage(New Point(311, 128), 88, 160, 286, 336, 19, 1)
        getImage(New Point(256, 138), 88, 160, 235, 277, 18, 1)
        getImage(New Point(205, 128), 88, 160, 184, 226, 17, 1)
        getImage(New Point(153, 128), 88, 160, 127, 179, 16, 5)
        getImage(New Point(91, 128), 88, 160, 64, 118, 15, 3)
        getImage(New Point(33, 128), 88, 160, 6, 60, 14, 1)
        getImage(New Point(559, 41), 2, 80, 526, 592, 13, 9)
        getImage(New Point(494, 41), 2, 80, 461, 527, 12, 13)
        getImage(New Point(431, 41), 2, 80, 413, 446, 11, 10)
        getImage(New Point(395, 41), 2, 80, 381, 409, 10, 1)
        getImage(New Point(363, 41), 2, 80, 352, 374, 9, 1)
        getImage(New Point(335, 41), 2, 80, 322, 348, 8, 1)
        getImage(New Point(308, 41), 2, 80, 299, 317, 7, 1)
        getImage(New Point(284, 41), 2, 80, 275, 293, 6, 1)
        getImage(New Point(261, 41), 2, 80, 252, 270, 5, 1)
        getImage(New Point(238, 41), 2, 80, 229, 247, 4, 1)
        getImage(New Point(205, 41), 2, 80, 187, 223, 3, 1)
        getImage(New Point(152, 41), 2, 80, 124, 180, 2, 1)
        getImage(New Point(96, 41), 2, 80, 68, 124, 1, 1)
        getImage(New Point(40, 41), 2, 80, 12, 68, 0, 1)

        If Direction = "right" Then
            Ostrich.Vx = 10
            Ostrich.Vy = 0
            Ostrich.x = -100
            Ostrich.y = 80
        ElseIf Direction = "left" Then
            Ostrich.Vx = -10
            Ostrich.Vy = 0
            Ostrich.x = pbScreen.Width + 100
            Ostrich.y = 80
        End If

        Rect = Head

        Ostrich.timerF = 0
        Ostrich.iframe = Rect.index

    End Sub

    Sub Idle()
        alter(States.stand)
        delList()
        getImage(New Point(39, 443), 408, 478, 11, 67, 0, 1)
        Ostrich.Vx = 0
        Ostrich.Px = 0
        Ostrich.timerF = 0
        Rect = Head
    End Sub

    Sub Brake()
        Ostrich.Cur_State = States.brake
        delList()
        getImage(New Point(248, 519), 483, 555, 224, 272, 4, 4)
        getImage(New Point(199, 519), 483, 555, 175, 223, 3, 1)
        getImage(New Point(146, 519), 483, 555, 118, 173, 2, 1)
        getImage(New Point(89, 519), 483, 555, 62, 116, 1, 1)
        getImage(New Point(35, 519), 483, 555, 8, 62, 0, 1)
        Rect = Head
        Ostrich.Vx = 11
        Ostrich.Px = 2
        Ostrich.timerF = 0
        Ostrich.iframe = Rect.index
    End Sub
    Public Sub Start()
        gfx.DrawImage(bcg, BcgPos, 0)

        '-------------Intro'                                
        If Ostrich.Cur_State = States.intro Then
            If Direction = "right" Then
                If Ostrich.iframe = 2 And Ostrich.x <= bcgX - 50 Then
                    Reset()
                End If
            ElseIf Direction = "left" Then
                If Ostrich.iframe = 2 And Ostrich.x >= bcgX Then
                    Reset()
                End If
            End If
            If Ostrich.iframe >= 3 And Ostrich.iframe < 11 Then
                If Ostrich.y < -70 Then
                    Ostrich.Vx = 0
                    Ostrich.Vy = 0
                Else
                    Ostrich.Vx = 0
                    Ostrich.Vy = -13
                End If
            End If
            If Ostrich.iframe = 11 Or Ostrich.iframe = 12 Or Ostrich.iframe = 13 Then
                Ostrich.Vy = 10
            End If
            If Ostrich.iframe > 13 Then
                Ostrich.Vy = 0
            End If
            If Direction = "right" Then
                Blit(Mask, ss, bcg, Ostrich.x, Ostrich.y)
            Else
                BlitFlip(Mask, ss, bcg, Ostrich.x, Ostrich.y)
            End If
            Ostrich.x += Ostrich.Vx
            Ostrich.y += Ostrich.Vy

            '--------stand:-------------------------------------'
        ElseIf Ostrich.Cur_State = States.stand Then
            Ostrich.y = 150
            If Direction = "right" Then
                Blit(Mask, ss, bcg, Ostrich.x, Ostrich.y)
            ElseIf Direction = "Left" Then
                BlitFlip(Mask, ss, bcg, Ostrich.x, Ostrich.y)
            End If
            '-------------dash--------------------------------'
        ElseIf Ostrich.Cur_State = States.dash Then
            Ostrich.y = 165
            If Direction = "right" Then
                BlitFlip(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                pbScreen.Image = bmp
                If BcgPos > -500 And Ostrich.x >= bcgX - 50 Then
                    BcgPos -= Ostrich.Vx
                Else
                    Ostrich.x += Ostrich.Vx
                End If
            ElseIf Direction = "left" Then
                Blit(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                pbScreen.Image = bmp
                If BcgPos < 0 And Ostrich.x <= bcgX Then
                    BcgPos -= Ostrich.Vx
                Else
                    Ostrich.x += Ostrich.Vx
                End If
            End If
            '-----------------brake----------------------'
        ElseIf Ostrich.Cur_State = States.brake Then
            Ostrich.y = 150
            If Direction = "right" Then
                Blit(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                pbScreen.Image = bmp
                If BcgPos > -500 And Ostrich.x >= bcgX - 50 Then
                    BcgPos -= Ostrich.Vx
                    Ostrich.Vx -= Ostrich.Px
                Else
                    Ostrich.x += Ostrich.Vx
                    Ostrich.Vx -= Ostrich.Px
                End If
            ElseIf Direction = "left" Then
                BlitFlip(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                pbScreen.Image = bmp
                If BcgPos < 0 And Ostrich.x <= bcgX Then
                    BcgPos += Ostrich.Vx
                    Ostrich.Vx -= Ostrich.Px
                Else
                    Ostrich.x -= Ostrich.Vx
                    Ostrich.Vx -= Ostrich.Px
                End If
            End If
            '-------------------------jump------------------------------'
        ElseIf Ostrich.Cur_State = States.jump Then
            If Ostrich.iframe = 0 Then
                Ostrich.y = 118
            ElseIf Ostrich.iframe > 0 And Ostrich.iframe <= 2 Then
                Ostrich.y -= 10
            ElseIf Ostrich.iframe >= 3 Then
                Ostrich.y += 7
            End If
            If Direction = "right" Then
                Blit(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                pbScreen.Image = bmp
                If BcgPos > -500 And Ostrich.x >= bcgX - 50 Then
                    BcgPos -= Ostrich.Vx
                Else
                    Ostrich.x += Ostrich.Vx
                End If
            ElseIf Direction = "left" Then
                BlitFlip(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                pbScreen.Image = bmp
                If BcgPos < 0 And Ostrich.x <= bcgX Then
                    BcgPos += Ostrich.Vx
                Else
                    Ostrich.x -= Ostrich.Vx
                End If
            End If
            '------------------------leap-------------------------------'
        ElseIf Ostrich.Cur_State = States.leap Then
            If Direction = "right" Then
                BlitFlip(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                If Ostrich.x <= bcgX And Ostrich.iframe >= 2 Then
                    Ostrich.x += Ostrich.Vx
                End If
            ElseIf Direction = "left" Then
                Blit(Mask, ss, bcg, Ostrich.x, Ostrich.y)
                If Ostrich.x >= bcgX And Ostrich.iframe >= 2 Then
                    Ostrich.x += Ostrich.Vx
                End If
            End If
            If Ostrich.y > 30 And Ostrich.iframe >= 2 And Ostrich.iframe < 6 Then
                Ostrich.y += Ostrich.Vy
            ElseIf Ostrich.y < 145 And Ostrich.iframe >= 6 Then
                Ostrich.y -= Ostrich.Vy
            End If
        End If

        pbScreen.Image = bmp
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BcgPos = 0
        bcgX = pbScreen.Width / 2
        bcgY = pbScreen.Height / 2

        Intro()

        GTimer.Enabled = True
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Up Then
            If Ostrich.Cur_State = States.stand Then
                Ostrich.Cur_State = States.jump
                delList()

                getImage(New Point(242, 280), 237, 323, 213, 272, 4, 4)
                getImage(New Point(190, 280), 237, 323, 165, 215, 3, 1)
                getImage(New Point(144, 280), 237, 323, 120, 168, 2, 1)
                getImage(New Point(98, 280), 237, 323, 74, 122, 1, 1)
                getImage(New Point(45, 280), 237, 323, 14, 76, 0, 1)

                Rect = Head
                Ostrich.Vx = 10
                Ostrich.Px = 0
                Ostrich.timerF = 0
                Ostrich.iframe = Rect.index
            End If
            Return True
        End If
        'detect down arrow key for Brake
        If keyData = Keys.Down Then
            If Ostrich.Cur_State = States.dash Or Ostrich.Cur_State = States.jump Then
                If Ostrich.Cur_State = States.jump Then
                    KeyPressed = True
                ElseIf Ostrich.Cur_State = States.dash Then
                    Brake()
                    If Direction = "right" Then
                        Ostrich.x += 50
                    End If
                End If
            End If
            Return True
        End If
        'detect left arrow key
        If keyData = Keys.Space Then
            If Ostrich.Cur_State = States.stand Then
                If Ostrich.x > bcgX Then
                    Direction = "left"
                Else
                    Direction = "right"
                End If
                Ostrich.Cur_State = States.leap
                delList()
                getImage(New Point(731, 363), 320, 406, 705, 757, 11, 2)
                getImage(New Point(675, 363), 320, 406, 649, 701, 10, 2)
                getImage(New Point(619, 363), 320, 406, 593, 645, 9, 2)
                getImage(New Point(562, 363), 320, 406, 537, 587, 8, 5)
                getImage(New Point(498, 363), 320, 406, 461, 535, 7, 5)
                getImage(New Point(426, 363), 320, 406, 389, 463, 6, 4)
                getImage(New Point(352, 363), 320, 406, 315, 389, 5, 3)
                getImage(New Point(289, 363), 320, 406, 266, 312, 4, 10)
                getImage(New Point(227, 363), 320, 406, 190, 264, 3, 12)
                getImage(New Point(161, 363), 320, 406, 131, 191, 2, 2)
                getImage(New Point(101, 363), 320, 406, 65, 137, 1, 2)
                getImage(New Point(38, 363), 320, 406, 1, 75, 0, 2)
                Rect = Head
                Ostrich.Vx = (bcgX - Ostrich.x) / 10
                Ostrich.Vy = (30 - Ostrich.y) / 10
                Ostrich.Px = 0
                Ostrich.timerF = 0
                Ostrich.iframe = Rect.index
            End If
        End If
        If keyData = Keys.Left Then
            If Ostrich.Cur_State = States.stand Then
                If Direction = "right" Then
                    Direction = "left"
                End If

                Ostrich.Cur_State = States.dash
                delList()

                getImage(New Point(750, 210), 175, 245, 691, 809, 6, 1)
                getImage(New Point(636, 210), 175, 245, 577, 695, 5, 1)
                getImage(New Point(521, 210), 175, 245, 462, 580, 4, 1)
                getImage(New Point(406, 210), 175, 245, 347, 465, 3, 1)
                getImage(New Point(291, 210), 175, 245, 232, 350, 2, 1)
                getImage(New Point(175, 210), 175, 245, 116, 234, 1, 1)
                getImage(New Point(61, 210), 175, 245, 2, 120, 0, 1)

                Rect = Head
                Ostrich.x -= 10
                Ostrich.Vx = -10
                Ostrich.Px = 0
                Ostrich.timerF = 0
                Ostrich.iframe = Rect.index
            End If
            Return True
        End If
        'detect right arrow key
        If keyData = Keys.Right Then
            If Ostrich.Cur_State = States.stand Then
                If Direction = "left" Then
                    Direction = "right"
                End If

                Ostrich.Cur_State = States.dash
                delList()

                getImage(New Point(750, 210), 175, 245, 691, 809, 6, 1)
                getImage(New Point(636, 210), 175, 245, 577, 695, 5, 1)
                getImage(New Point(521, 210), 175, 245, 462, 580, 4, 1)
                getImage(New Point(406, 210), 175, 245, 347, 465, 3, 1)
                getImage(New Point(291, 210), 175, 245, 232, 350, 2, 1)
                getImage(New Point(175, 210), 175, 245, 116, 234, 1, 1)
                getImage(New Point(61, 210), 175, 245, 2, 120, 0, 1)

                Rect = Head
                Ostrich.x -= 40

                Ostrich.Vx = 10
                Ostrich.Px = 0
                Ostrich.timerF = 0
                Ostrich.iframe = Rect.index
            End If
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub GTimer_Tick(sender As Object, e As EventArgs) Handles GTimer.Tick
        Start()
        Ostrich.timerF = Ostrich.timerF + 1
        If Ostrich.timerF >= Rect.MaxFrameTimer Then
            Ostrich.iframe = Rect.index
            Rect = Rect.nextFrame
            Ostrich.timerF = 0
            If Rect Is Nothing Then
                If Ostrich.Cur_State = States.intro Then
                    Idle()
                ElseIf Ostrich.Cur_State = States.stand Then
                    Reset()
                ElseIf Ostrich.Cur_State = States.dash Then
                    Reset()
                ElseIf Ostrich.Cur_State = States.brake Then
                    Idle()
                ElseIf Ostrich.Cur_State = States.jump Then
                    If KeyPressed Then
                        KeyPressed = False
                        Brake()
                    Else
                        Reset()
                    End If
                ElseIf Ostrich.Cur_State = States.leap Then
                    alter(States.stand)
                    delList()
                    getImage(New Point(39, 443), 408, 478, 11, 67, 0, 1)
                    Rect = Head
                End If
                If OffScreen(Ostrich.x, Ostrich.y) Then
                    If Direction = "left" Then
                        Direction = "right"
                    ElseIf Direction = "right" Then
                        Direction = "left"
                    End If
                    Intro()
                End If
            End If
        End If
    End Sub
End Class
