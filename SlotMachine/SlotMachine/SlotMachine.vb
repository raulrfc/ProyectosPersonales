Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class SlotMachine
    Private arrImages(5) As Image
    Private RandGen As Random
    Private RandIndex As Integer
    Private TimeCounter As Integer
    Private Game As Integer = 1
    Private Credit As Integer = 3

    Private Sub SlotMachine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        arrImages(0) = My.Resources.limon1
        arrImages(1) = My.Resources.skull
        arrImages(2) = My.Resources.cereza
        arrImages(3) = My.Resources.presentGold
        arrImages(4) = My.Resources.presentRed

        pb1.SizeMode = PictureBoxSizeMode.StretchImage
        pb2.SizeMode = PictureBoxSizeMode.StretchImage
        pb3.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub btnSpin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpin.Click
        RandGen = New Random(Now.Millisecond)
        My.Computer.Audio.Play(My.Resources.Lever_Marianne_Gagnon_206547513, AudioPlayMode.WaitToComplete)

        btnSpin.Enabled = False
        tmrSlots.Enabled = True

        If TimeCounter < 48 And btnSpin.Enabled = False Then
            My.Computer.Audio.Play(My.Resources.slot, AudioPlayMode.BackgroundLoop)
        End If     

        Label7.Text = Credit
    End Sub

    Private Sub tmrSlots_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSlots.Tick
        TimeCounter += 1

        If TimeCounter <= 50 Then
            For i = 0 To 5
                RandIndex = RandGen.Next(0, 5)
                pb1.Image = arrImages(RandIndex)
                RandIndex = RandGen.Next(0, 5)
                pb2.Image = arrImages(RandIndex)
                RandIndex = RandGen.Next(0, 5)
                pb3.Image = arrImages(RandIndex)

            Next i

            If TimeCounter = 50 Then
                My.Computer.Audio.Stop()
                amañar(Game)
            End If
        Else
            tmrSlots.Enabled = False
            btnSpin.Enabled = True
            TimeCounter = 0
            Game += 1
            Credit -= 1
        End If
    End Sub
    Private Sub amañar(ByVal juego As Integer)
        Select Case juego
            Case 1
                pb1.Image = My.Resources.presentRed
                pb2.Image = My.Resources.presentRed
                pb3.Image = My.Resources.limon1
            Case 2
                pb1.Image = My.Resources.skull
                pb2.Image = My.Resources.skull
                pb3.Image = My.Resources.presentGold
            Case 3
                pb1.Image = My.Resources.presentGold
                pb2.Image = My.Resources.presentGold
                pb3.Image = My.Resources.presentGold
                My.Computer.Audio.Play(My.Resources.win, AudioPlayMode.Background)
                My.Computer.Audio.Play(My.Resources.slot_payoff, AudioPlayMode.Background)
        End Select
    End Sub
End Class

