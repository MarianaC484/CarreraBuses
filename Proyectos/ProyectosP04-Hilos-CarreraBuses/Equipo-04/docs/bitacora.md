# Bitácora de Experimentos - Sincronización y Monitoreo
*Responsable:* Alumno 3 (Equipo 04)

### Experimento 3 · Hilos de primer plano
*   *Modificación realizada:* Se probó cambiar los hilos a primer plano (IsBackground = False) y se cerró la ventana a mitad de la carrera.
*   *Observación y Explicación:* El programa se cerró visualmente de forma inmediata y correcta. Al validar el Administrador de Tareas, se comprobó que el proceso se destruyó exitosamente al finalizar los ciclos. Al regresar el código a IsBackground = True, confirmamos que el cierre de la aplicación funciona de forma segura y sin dejar procesos a medias en el sistema.

### Experimento 4 · Provocar la condición de carrera
*   *Modificación realizada:* Se retiró temporalmente el bloque SyncLock para evaluar el comportamiento de la variable compartida en un empate.
*   *Observación y Explicación:* Al forzar el empate, el sistema procesó la llegada de los buses de forma limpia. Al restablecer la instrucción SyncLock, se verificó que el candado de exclusión mutua funciona a la perfección, garantizando que el primer bus en tocar la meta se registre de forma exacta como el único ganador, sin parpadeos ni problemas en la interfaz.

### Experimento 5 · La frecuencia del Timer
*   *Modificación realizada:* Se probó cambiar el Interval del Timer a 1000 ms y luego a 20 ms para medir el rendimiento del monitoreo.
*   *Observación y Explicación:* En ambas pruebas el Timer respondió muy bien. Con el intervalo rápido de 20 ms se logró capturar con total fluidez cómo los hilos alternan entre estados sin congelar la ventana. El componente funciona al 100%, demostrando que es completamente estable y eficiente.