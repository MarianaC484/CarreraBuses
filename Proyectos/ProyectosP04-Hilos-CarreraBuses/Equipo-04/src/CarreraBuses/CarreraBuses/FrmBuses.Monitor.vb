Imports System.Threading

Partial Class FrmBuses

    ' 1. MÉTODO PARA REGISTRAR AL GANADOR 

    Public Sub RegistrarGanador(nombreBus As String)
        SyncLock ObjetoCandado
            If String.IsNullOrEmpty(Ganador) Then
                Ganador = nombreBus

                ' Forzamos visualmente el destino Estelí para el ganador
                If nombreBus = "Bus 1" Then lblRuta1.Text = "Estelí"
                If nombreBus = "Bus 2" Then lblRuta2.Text = "Estelí"
                If nombreBus = "Bus 3" Then lblRuta3.Text = "Estelí"

                lblGanador.Text = "Ganador: " & Ganador
            End If
        End SyncLock
    End Sub

    ' 2. EVENTO TICK DEL TIMER (Monitoreo de estados)

    Private Sub tmrEstados_Tick(sender As Object, e As EventArgs) Handles tmrEstados.Tick
        If Cerrando Then Return
        If buses Is Nothing Then Return

        Dim todosTerminaron As Boolean = True

        For i As Integer = 0 To 2
            Dim hilActual As Thread = buses(i)
            Dim lblEstadoActual As Label = ObtenerEtiquetaEstado(i)
            Dim barraActual As ProgressBar = ObtenerBarraProgreso(i)

            ' Actualizamos los puntos de referencia basados en el progreso real
            If i = 0 AndAlso pbBus1.Value < 100 Then lblRuta1.Text = ObtenerMunicipioRuta(pbBus1.Value)
            If i = 1 AndAlso pbBus2.Value < 100 Then lblRuta2.Text = ObtenerMunicipioRuta(pbBus2.Value)
            If i = 2 AndAlso pbBus3.Value < 100 Then lblRuta3.Text = ObtenerMunicipioRuta(pbBus3.Value)

            If hilActual IsNot Nothing Then
                ' Refrescamos el estado del hilo
                lblEstadoActual.Text = hilActual.ThreadState.ToString()

                ' Si la barra llega a 100, registramos de inmediato
                If barraActual.Value = 100 Then
                    RegistrarGanador(hilActual.Name)
                End If

                ' Verificamos si sigue en ejecución
                If hilActual.IsAlive Then
                    todosTerminaron = False
                End If
            Else
                lblEstadoActual.Text = "Sin iniciar"
            End If
        Next

        ' Si todos terminaron, apagamos el reloj y habilitamos el botón de inicio
        If todosTerminaron Then
            tmrEstados.Stop()
            btnIniciar.Enabled = True
        End If
    End Sub

    ' 3. FUNCIONES AUXILIARES PARA VINCULAR COMPONENTES VISUALES

    Private Function ObtenerEtiquetaEstado(indice As Integer) As Label
        Select Case indice
            Case 0 : Return lblEstado1
            Case 1 : Return lblEstado2
            Case 2 : Return lblEstado3
            Case Else : Return Nothing
        End Select
    End Function

    Private Function ObtenerBarraProgreso(indice As Integer) As ProgressBar
        Select Case indice
            Case 0 : Return pbBus1
            Case 1 : Return pbBus2
            Case 2 : Return pbBus3
            Case Else : Return Nothing
        End Select
    End Function

    Private Function ObtenerMunicipioRuta(progreso As Integer) As String
        Select Case progreso
            Case 0 To 15 : Return "Managua"
            Case 16 To 35 : Return "Tipitapa"
            Case 36 To 55 : Return "San Benito"
            Case 56 To 75 : Return "Ciudad Darío"
            Case 76 To 85 : Return "Sébaco"
            Case 86 To 95 : Return "La Trinidad"
            Case 96 To 100 : Return "Estelí"
            Case Else : Return "Managua"
        End Select
    End Function

End Class