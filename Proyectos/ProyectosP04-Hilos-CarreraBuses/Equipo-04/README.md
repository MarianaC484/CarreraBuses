#### **Carrera de buses Managua - Estelí** 



Numero de equipo: "Equipo 04"





**Integrantes del grupo:**

1. Angelica Mariana Moreno Calderón  -  MarianaC484             -  Alumno 1 (Interfaz)
2. Heyling Francella Guerrero Gomez  -  HeylingC                -  Alumno 2 (Hilos)
3. Iveth Tamara Toruño Toruño        -  ivethtamaratoruno-sudo  -  Alumno 3 (Monitor)



**Como abrir y ejecutar el proyecto**

Versión de Visual Studio: Microsoft Visual Studio 2022 / 2026.

Versión de .NET: .NET 10.0 (Windows Forms con Visual Basic).



**Pasos para ejecutar:**

&#x20; 1. Clonar el repositorio localmente.

&#x20; 2. Abrir el archivo de solución src/CarreraBuses.sln en Visual Studio.

&#x20; 3. Presionar el botón Iniciar (F5) para compilar y ejecutar de forma segura.



**Captura de la carrera en curso y de la carrera terminada con ganador.**



!\[Carrera en Curso](./docs/capturas/carrera%20buses.png)



!\[Carrera Terminada](./docs/capturas/bus%20ganador.png)





**Explicación breve**

**La ventana no se congela** porque la simulación del avance y los retrasos corren en hilos secundarios independientes, por lo que dejan libre el hilo principal

de la interfaz para responder al usuario.

**Los estados que se observaron** fueron "Running" (hilo activo), "WaitSleepJoin" (hilo en pausa que simula velocidad y "Stopped" (hilo finalizado al cruzar la meta).

**Solo hay un ganador** ya que debido al uso del objeto candado (Synclock). Cuando el primer hilo llega al 100%, bloquea la sección critica y escribe su nombre en la variable compartida que es "Ganador", por lo que deniega el acceso a los demás competidores en el mismo milisegundo.



**Enlace a la bitácora y al documento de estados observados**



\[Enlace a la Bitácora de Experimentos](./docs/bitacora.md)

\[Enlace al Documento de Estados Observados](./docs/estados-observados.md)



