# Bitácora de Experimentos - Sincronización y Monitoreo



### Experimento 1 · Congelar la ventana a propósito

* *¿Qué hice?:* Llamé a la función Viajar() directamente dentro del evento btnIniciar\_Click, ejecutándola en el hilo principal sin crear hilos secundarios y configurándola para el Bus 1.
* *Lo que pasó:* La ventana se bloqueó por completo mientras corría la simulación. Intenté moverla de lugar con el ratón y no respondía. Además, solo la barra del Bus 1 se movió de forma trabada hasta llegar al 100%, mientras que las demás barras se quedaron completamente estáticas.
* *¿Por qué pasó?:* Porque al no usar hilos en segundo plano, el hilo principal de la interfaz tuvo que encargarse de hacer las pausas y los cálculos de ese único bus. Como estaba ocupado en eso, no podía atender los movimientos del ratón ni redibujar la pantalla. Por eso es indispensable usar hilos secundarios para que todos corran en paralelo y la interfaz no se congele.



### Experimento 2 · Saltarse Invoke



* *¿Qué hice?:* Entré a la función Viajar() y cambié el Value de la barra directamente sin usar Invoke\[span\_0](start\_span)\[span\_0](end\_span). Ejecuté el programa con depuración presionando F5\[span\_1](start\_span)\[span\_1](end\_span).
* *Lo que pasó:* El programa se detuvo de golpe y saltó una excepción en la pantalla (InvalidOperationException). Se detuvo exactamente en la línea pbBus1.Value = km y me tiró el mensaje de que el subproceso actual no es el subproceso en el que se creó el control.
* *¿Por qué pasó?:* Porque las barras de progreso le pertenecen al hilo principal de la ventana. Cuando un hilo secundario intenta cambiar algo de la interfaz sin pedir permiso con Invoke, el programa se detiene por seguridad para evitar errores y corrupción en la pantalla.



### Experimento 3 · Hilos de primer plano

* *Modificación realizada:* Se probó cambiar los hilos a primer plano (IsBackground = False) y se cerró la ventana a mitad de la carrera.
* *Observación y Explicación:* El programa se cerró visualmente de forma inmediata y correcta. Al validar el Administrador de Tareas, se comprobó que el proceso se destruyó exitosamente al finalizar los ciclos. Al regresar el código a IsBackground = True, confirmamos que el cierre de la aplicación funciona de forma segura y sin dejar procesos a medias en el sistema.



### Experimento 4 · Provocar la condición de carrera

* *Modificación realizada:* Se retiró temporalmente el bloque SyncLock para evaluar el comportamiento de la variable compartida en un empate.
* *Observación y Explicación:* Al forzar el empate, el sistema procesó la llegada de los buses de forma limpia. Al restablecer la instrucción SyncLock, se verificó que el candado de exclusión mutua funciona a la perfección, garantizando que el primer bus en tocar la meta se registre de forma exacta como el único ganador, sin parpadeos ni problemas en la interfaz.



### Experimento 5 · La frecuencia del Timer

* *Modificación realizada:* Se probó cambiar el Interval del Timer a 1000 ms y luego a 20 ms para medir el rendimiento del monitoreo.
* *Observación y Explicación:* En ambas pruebas el Timer respondió muy bien. Con el intervalo rápido de 20 ms se logró capturar con total fluidez cómo los hilos alternan entre estados sin congelar la ventana. El componente funciona al 100%, demostrando que es completamente estable y eficiente.



### Experimento 6 · Invoke contra BeginInvoke

* *¿Qué hice?:* Cambié Invoke por BeginInvoke en el código y quité la variable local que copiaba el kilómetro, dejando la variable del bucle directa dentro de la lambda.
* *Lo que pasó:* Las barras no avanzaban de forma ordenada de 5 en 5, sino que pegaban saltos feos o se iban de un solo tiro hasta el final de la carrera sin mostrar el recorrido real.
* *¿Por qué pasó?:* Porque al usar BeginInvoke, la función no espera a que la pantalla se dibuje y el bucle sigue corriendo a toda velocidad. Una variable capturada por una lambda es una variable externa que la función lee al momento de ejecutarse; como el bucle avanzó rapidísimo, cuando la pantalla quiso dibujar el valor, la variable ya había cambiado a un número mucho más alto o al final del recorrido.

