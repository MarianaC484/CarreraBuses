Imports System.Threading

Partial Class FrmBuses

    Public Sub Viajar()

        Dim nombre As String = Thread.CurrentThread.Name
        Dim rnd As New Random()

        For km As Integer = 5 To 150 Step 5

            Dim kmActual As Integer = km

            Me.Invoke(New MethodInvoker(
            Sub()

                Select Case nombre

                    Case "Bus 1"
                        pbBus1.Value = kmActual

                    Case "Bus 2"
                        pbBus2.Value = kmActual

                    Case "Bus 3"
                        pbBus3.Value = kmActual

                End Select

            End Sub))

            Thread.Sleep(rnd.Next(50, 200))

        Next

    End Sub

End Class