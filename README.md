📘 CodeAcademy

📌 Descripción del programa

CodeAcademy es una aplicación de escritorio desarrollada en C# utilizando Windows Forms, cuyo objetivo es gestionar y visualizar cursos de programación de manera organizada e intuitiva.

El sistema permite administrar información relacionada con cursos, lecciones y estudiantes, proporcionando una interfaz gráfica amigable que facilita la navegación entre los contenidos educativos.

La aplicación implementa el patrón arquitectónico MVP (Model-View-Presenter), lo que permite separar la lógica del sistema de la interfaz gráfica, mejorando la mantenibilidad y escalabilidad del software.

🎯 Problemas que soluciona

Este sistema fue diseñado para dar solución a las siguientes problemáticas:

❌ Desorganización del contenido educativo
→ Centraliza cursos y lecciones en una sola aplicación.
❌ Dificultad para gestionar información de cursos
→ Permite estructurar datos de cursos, estudiantes y lecciones.
❌ Acoplamiento entre interfaz y lógica
→ Implementa MVP para separar responsabilidades.
❌ Aplicaciones difíciles de mantener
→ Uso de buenas prácticas que facilitan futuras mejoras.
🧱 Arquitectura del sistema

El proyecto implementa el patrón MVP (Model - View - Presenter):

Model: Representa los datos (Course, Student, Lesson).
View: Formularios de Windows Forms (MainForm, CourseDetailForm).
Presenter: Contiene la lógica del sistema (CoursePresenter, MainPresenter).

Además, se incluye una capa de acceso a datos mediante Repository.

🛠️ Tecnologías utilizadas
Lenguaje: C#
Framework: .NET (Windows Forms)
IDE: Visual Studio
Control de versiones: Git
Plataforma de repositorio: GitHub
⚙️ Requisitos previos

Antes de ejecutar el proyecto, asegúrate de tener instalado:

✅ Sistema operativo: Windows 10 o superior
✅ Visual Studio (recomendado 2019 o superior)
✅ .NET Framework / .NET SDK compatible con WinForms
✅ Git (opcional, para clonar el repositorio)
🚀 Instalación y ejecución

Sigue estos pasos para ejecutar el proyecto:

1. Clonar el repositorio
git clone https://github.com/DragonIceCream65/CodeAcademy.git
2. Abrir el proyecto
Abre Visual Studio
Selecciona "Abrir proyecto o solución"
Busca el archivo .sln del proyecto
3. Ejecutar la aplicación
Presiona F5 o haz clic en Iniciar
Se abrirá la aplicación Windows Forms

👥 Integrantes
👤 Integrante 1: Brigitte Lopez Torres 
👤 Integrante 2: Sebastian Morales Escudero
