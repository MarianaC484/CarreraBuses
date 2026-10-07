Imports System.Threading

Partial Public Class FrmBuses

    Private buses(2) As Thread

    ' Variable compartida en memoria para registrar el nombre del bus ganador
    Private Shared Ganador As String

    ' Objeto candado para asegurar la exclusión mutua 
    Private ObjetoCandado As New Object()

    ' Bandera booleana de cierre seguro
    Private Cerrando As Boolean = False


    ' EVENTO DE CARGA DEL FORMULARIO

    Private Sub FrmBuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializaciones visuales si fuesen necesarias en el futuro
    End Sub


    ' BOTÓN INICIAR CARRERA 

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click

        ' 1. Reiniciar el estado visual de los componentes de la interfaz con barras en 0, etiquetas de estado en “Sin iniciar” y la etiqueta del ganador en “Ganador: —”.
        pbBus1.Value = 0
        pbBus2.Value = 0
        pbBus3.Value = 0

        lblEstado1.Text = "Sin iniciar"
        lblEstado2.Text = "Sin iniciar"
        lblEstado3.Text = "Sin iniciar"
        lblGanador.Text = "Ganador: —"

        ' 2. Vaciar la variable compartida del ganador para la nueva carrera
        Ganador = ""

        ' 3. Desactivar el botón de inicio para que nadie lance otra carrera encima de la actual.
        btnIniciar.Enabled = False

        buses(0) = New Thread(AddressOf Viajar) With {.Name = "Bus 1", .IsBackground = True}
        buses(1) = New Thread(AddressOf Viajar) With {.Name = "Bus 2", .IsBackground = True}
        buses(2) = New Thread(AddressOf Viajar) With {.Name = "Bus 3", .IsBackground = True}

        ' 5. Iniciar el Timer de y arrancar los hilos en paralelo
        tmrEstados.Start()

        For Each bus As Thread In buses
            bus.Start()
        Next
    End Sub


    ' BOTÓN SALIR Y CIERRE SEGURO

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmBuses_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Activart la bandera de cierre para avisarle al Timer 
        Cerrando = True
        tmrEstados.Stop()
    End Sub

    Public Sub viajar()

    End Sub
End Class
