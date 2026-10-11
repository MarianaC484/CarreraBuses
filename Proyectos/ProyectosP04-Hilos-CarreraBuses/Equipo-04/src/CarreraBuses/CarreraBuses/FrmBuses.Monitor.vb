Imports System.Threading

Partial Class FrmBuses

    ' 1. MÉTODO PARA REGISTRAR AL GANADOR (Exclusión mutua con el candado de tu equipo)
    Public Sub RegistrarGanador(nombreBus As String)
        SyncLock ObjetoCandado
            If String.IsNullOrEmpty(Ganador) Then
                Ganador = nombreBus

                ' Actualizamos la interfaz en el hilo principal
                Me.Invoke(New MethodInvoker(Sub()
                                                lblGanador.Text = $"Ganador: {nombreBus}"
                                            End Sub))
            End If
        End SyncLock
    End Sub

    ' 2. EVENTO TICK DEL TIMER (Monitoreo de estados y detección de ganador)
    Private Sub tmrEstados_Tick(sender As Object, e As EventArgs) Handles tmrEstados.Tick
        If Cerrando Then Return
        If buses Is Nothing Then Return

        Dim todosTerminaron As Boolean = True

        For i As Integer = 0 To 2
            Dim hiloActual As Thread = buses(i)
            Dim lblEstadoActual As Label = ObtenerEtiquetaEstado(i)
            Dim barraActual As ProgressBar = ObtenerBarraProgreso(i)

            If hiloActual IsNot Nothing Then
                ' Refrescamos el estado real del hilo en la pantalla
                lblEstadoActual.Text = hiloActual.ThreadState.ToString()

                ' TRUCO AUTOMÁTICO: Si la barra llegó a 150 y nadie ha ganado, lo registramos
                If barraActual IsNot Nothing AndAlso barraActual.Value = 150 Then
                    Dim nombreBus As String = $"Bus {i + 1}"
                    If String.IsNullOrEmpty(Ganador) Then
                        RegistrarGanador(nombreBus)
                    End If
                End If

                ' Comprobamos si el hilo ya terminó
                If Not hiloActual.ThreadState.HasFlag(ThreadState.Stopped) Then
                    todosTerminaron = False
                End If
            Else
                lblEstadoActual.Text = "Sin iniciar"
                todosTerminaron = False
            End If
        Next

        ' Si todos terminaron, apagamos el reloj y habilitamos el botón de inicio
        If todosTerminaron Then
            tmrEstados.Stop()
            btnIniciar.Enabled = True
        End If
    End Sub

    ' Funciones auxiliares para conectar tus componentes
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

End Class