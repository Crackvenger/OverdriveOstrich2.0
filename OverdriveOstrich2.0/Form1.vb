﻿
Public Enum States
    intro
    stand
    background_run
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
    Dim bmp As New Drawing.Bitmap(600, 500)
    Dim gfx As Graphics = Graphics.FromImage(bmp)
    Dim bcg As Bitmap = Bitmap.FromFile("bg.png")
    Dim ss As Bitmap = Bitmap.FromFile("Overdrive Ostrich.png")
    Dim Mask As Bitmap = Bitmap.FromFile("MaskOverdrive Ostrich.png")
    Dim bcgX, bcgY As Integer
    Dim Direction As String
    Dim Head, Rect As FrameElement
    Dim Ostrich As New Sprite
    Dim BcgPos As Integer
    Dim KeyPressed As Boolean

    Private Sub getImage(newCenterPoint As Point, newTop As Integer, newBottom As Integer, newLeft As Integer, newRight As Integer,
    newIndex As Integer, newMaxFrameTimer As Integer)
        Dim n As FrameElement = New FrameElement(newCenterPoint, newTop, newBottom, newLeft, newRight, newIndex, newMaxFrameTimer)
        n.nextFrame = Head
        Head = n
    End Sub

    Sub delList()
        Head = Nothing
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
                spriteColor = MaskSub.GetPixel(x, y)
                If spriteColor.ToArgb = black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX & PositionY >= 0) And (PositionX < bmp.Width) And (PositionY < bmp.Height)) Then
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
                spriteColor = MaskSub.GetPixel(x, y)
                If spriteColor.ToArgb <> black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX & PositionY >= 0) And (PositionX < bmp.Width) And (PositionY < bmp.Height)) Then
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
                spriteColor = MaskSub.GetPixel(x, y)
                If spriteColor.ToArgb = black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX & PositionY >= 0) And (PositionX < bmp.Width) And (PositionY < bmp.Height)) Then
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
                spriteColor = MaskSub.GetPixel(x, y)
                If spriteColor.ToArgb <> black.ToArgb Then
                    PositionX = CounterX + x
                    PositionY = CounterY + y
                    If ((PositionX & PositionY >= 0) And (PositionX < bmp.Width) And (PositionY < bmp.Height)) Then
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BcgPos = 0
        bcgX = pbScreen.Width / 2
        bcgY = pbScreen.Height / 2

        Intro()

        GTimer.Enabled = True
    End Sub
    Sub leap()
    ElseIf sprite.CurrentState = TStateOverdriveOstrich.leap Then
        If Direction = "right" Then
            BitBlittingFlip(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
            If sprite.posX <= backgroundX And sprite.FrameIndex >= 2 Then
                sprite.posX += sprite.Vx
            End If
        ElseIf Direction = "left" Then
            BitBlitting(MaskSS, SpritSheet, background, sprite.posX, sprite.posY)
            If sprite.posX >= backgroundX And sprite.FrameIndex >= 2 Then
                sprite.posX += sprite.Vx
            End If
        End If
        If sprite.posY > 30 And sprite.FrameIndex >= 2 And sprite.FrameIndex < 6 Then
            sprite.posY += sprite.Vy
        ElseIf sprite.posY < 145 And sprite.FrameIndex >= 6 Then
            sprite.posY -= sprite.Vy
        End If
    End If
    End Sub
End Cass
