# Estados Observados en la Carrera de Buses
*Responsable:* Alumno 3 (Equipo 04)

Durante el desarrollo y monitoreo de la carrera de buses Managua - Estelí, se identificaron los siguientes estados en las etiquetas a través de la propiedad ThreadState:

*   *Unstarted:* el estado inicial del bus cuando se crea en memoria. En el programa, este estado dura solo un milisegundo, ya que inmediatamente después el botón llama al método .Start() para arrancar la carrera.
*   *WaitSleepJoin:* Estado predominante. El hilo se encuentra bloqueado temporalmente debido a la instrucción Thread.Sleep(), cediendo el control de la CPU para evitar congelar la interfaz gráfica.
*   *Background:* Marca que indica que el hilo se ejecuta en segundo plano. Permite que el proceso de Windows finalice de forma segura si el usuario decide cerrar la ventana del escritorio.
*   *Stopped:* El bus ha completado muy bien los 150 km del trayecto y el método Viajar() ha finalizado su ciclo de ejecución correctamente.