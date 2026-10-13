# CarreraBuses



###### **Guía:**



**Fase 0 · Arranque (Alumno 1, con el equipo presente)**



1\.	Clonar el repositorio en Visual Studio 2026: Git → Clonar repositorio y pegar la URL.

2\.	Crear el proyecto CarreraBuses (Aplicación de Windows Forms, VB, .NET 10) dentro de Equipo-NN/src/.

3\.	Renombrar Form1 a FrmBuses y fijarlo como formulario de inicio.

4\.	Crear los archivos vacíos FrmBuses.Hilos.vb y FrmBuses.Monitor.vb, cada uno con la declaración Partial Class FrmBuses vacía, para que los demás       tengan dónde trabajar.

5\.	Compilar, hacer commit y subir a main mediante un primer pull request. Desde aquí, todos parten del mismo     esqueleto.



**Fase 1 · Trabajo en paralelo**



•	Cada integrante actualiza su copia (git pull), crea su rama desde main y trabaja solo en sus archivos.

•	Commits pequeños y frecuentes: al menos uno por cada tarea terminada de la tabla de roles.

•	Mientras la interfaz no esté integrada, los Alumnos 2 y 3 pueden avanzar en la lógica y escribir la bitácora; compilarán contra los controles cuando el PR #1 esté en main.



**Fase 2 · Integración en orden**



1\.	PR #1 – interfaz: lo revisa el Alumno 3 y se integra primero.

2\.	Los Alumnos 2 y 3 traen esos cambios a sus ramas (git pull origin main) y verifican que compila.

3\.	PR #2 – hilos: lo revisa el Alumno 1. Con él, las barras ya se mueven.

4\.	El Alumno 3 vuelve a traer main, prueba el Timer y el ganador con los hilos reales.

5\.	PR #3 – sincronización: lo revisa el Alumno 2.



**Fase 3 · Cierre**



•	Prueba conjunta: correr la carrera al menos diez veces y anotar los ganadores en la bitácora.

•	Completar el README.md del equipo con capturas.

•	Crear la etiqueta (tag) equipoNN-v1.0 sobre el último commit de main; esa es la versión entregada.



