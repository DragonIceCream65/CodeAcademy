using System.Collections.Generic;
using CodeAcademy.Models;

namespace CodeAcademy.Data
{
    public class CourseRepository
    {
        public List<Course> GetAllCourses()
        {
            return new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Title = "Python desde Cero",
                    Description = "Aprende Python con proyectos reales. Variables, funciones, POO y más.",
                    Icon = "🐍",
                    Category = CourseCategory.Programming,
                    Difficulty = DifficultyLevel.Beginner,
                    AccentColor = "#3776AB",
                    Lessons = new List<Lesson>
                    {
                        new Lesson(1, "¿Qué es Python?", "Python es un lenguaje de programación de alto nivel...\n\nFue creado por Guido van Rossum en 1991.\nEs interpretado, dinámico y multiparadigma.\n\n✅ Ventajas:\n• Sintaxis clara y legible\n• Gran comunidad\n• Multiplataforma\n• Miles de librerías disponibles", 10),
                        new Lesson(2, "Variables y Tipos de Datos", "Las variables almacenan información.\n\n📌 Ejemplo:\n\nname = 'Juan'        # String\nage = 25             # Integer\nheight = 1.75        # Float\nis_active = True     # Boolean\n\nPython es dinámico: no declaras el tipo, él lo infiere.", 15),
                        new Lesson(3, "Condicionales if/else", "Las condiciones controlan el flujo del programa.\n\n📌 Ejemplo:\n\nif age >= 18:\n    print('Eres mayor de edad')\nelif age >= 13:\n    print('Eres adolescente')\nelse:\n    print('Eres niño')\n\n⚠️ La indentación es obligatoria en Python.", 12),
                        new Lesson(4, "Bucles for y while", "Los bucles repiten código.\n\n📌 For:\nfor i in range(5):\n    print(i)   # 0,1,2,3,4\n\n📌 While:\nx = 0\nwhile x < 5:\n    print(x)\n    x += 1\n\n💡 Usa for cuando sabes cuántas veces iterar.", 15),
                        new Lesson(5, "Funciones", "Las funciones son bloques reutilizables.\n\n📌 Ejemplo:\n\ndef saludar(nombre, edad=18):\n    return f'Hola {nombre}, tienes {edad} años'\n\nresultado = saludar('Ana', 25)\nprint(resultado)\n\n• def: define la función\n• return: devuelve un valor\n• Los parámetros pueden tener valores por defecto", 20),
                        new Lesson(6, "Listas y Diccionarios", "Estructuras de datos esenciales.\n\n📌 Lista:\nfruits = ['mango', 'pera', 'uva']\nfruits.append('kiwi')\nprint(fruits[0])  # mango\n\n📌 Diccionario:\nperson = {'name': 'Juan', 'age': 25}\nprint(person['name'])  # Juan\nperson['city'] = 'Medellín'\n\n💡 Diccionarios: clave → valor", 18),
                    }
                },
                new Course
                {
                    Id = 2,
                    Title = "Git Esencial",
                    Description = "Control de versiones profesional. Domina commits, branches y flujos de trabajo.",
                    Icon = "🌿",
                    Category = CourseCategory.Git,
                    Difficulty = DifficultyLevel.Beginner,
                    AccentColor = "#F05032",
                    Lessons = new List<Lesson>
                    {
                        new Lesson(1, "¿Qué es Git?", "Git es un sistema de control de versiones distribuido.\n\nCreado por Linus Torvalds en 2005.\n\n🎯 ¿Para qué sirve?\n• Guardar el historial de cambios\n• Trabajar en equipo sin conflictos\n• Revertir errores fácilmente\n• Tener ramas de desarrollo paralelas\n\n💡 No confundir: Git ≠ GitHub\nGit = herramienta local\nGitHub = plataforma en la nube", 10),
                        new Lesson(2, "Configuración Inicial", "Antes de usar Git, configúralo:\n\n📌 Comandos básicos:\n\ngit config --global user.name 'Tu Nombre'\ngit config --global user.email 'tu@email.com'\ngit config --global core.editor code\n\n✅ Verificar configuración:\ngit config --list\n\n💡 --global aplica a todos tus proyectos en este equipo.", 8),
                        new Lesson(3, "Primer Repositorio", "Iniciar y gestionar un repo:\n\n📌 Flujo básico:\n\n# Iniciar repositorio\ngit init\n\n# Ver estado de archivos\ngit status\n\n# Agregar archivos al staging\ngit add archivo.txt\ngit add .   # todos los archivos\n\n# Guardar cambios (commit)\ngit commit -m 'Mi primer commit'\n\n💡 El staging es una zona intermedia antes del commit.", 15),
                        new Lesson(4, "Ramas (Branches)", "Las ramas permiten trabajar en paralelo.\n\n📌 Comandos:\n\n# Ver ramas\ngit branch\n\n# Crear rama\ngit branch feature/login\n\n# Cambiar de rama\ngit checkout feature/login\n# O de forma moderna:\ngit switch feature/login\n\n# Crear y cambiar en un paso\ngit checkout -b feature/registro\n\n💡 Main/Master es la rama principal.", 20),
                        new Lesson(5, "Merge y Conflictos", "Unir ramas y resolver conflictos.\n\n📌 Merge:\ngit checkout main\ngit merge feature/login\n\n⚠️ Conflicto:\n<<<<<<< HEAD\ntu código\n=======\ncódigo entrante\n>>>>>>> feature/login\n\n✅ Resolución:\n1. Edita el archivo manualmente\n2. Quita los marcadores <<<, ===, >>>\n3. git add archivo.txt\n4. git commit", 25),
                    }
                },
                new Course
                {
                    Id = 3,
                    Title = "GitHub Profesional",
                    Description = "Repositorios remotos, Pull Requests, Issues y trabajo colaborativo en equipos.",
                    Icon = "🐙",
                    Category = CourseCategory.GitHub,
                    Difficulty = DifficultyLevel.Intermediate,
                    AccentColor = "#6E40C9",
                    Lessons = new List<Lesson>
                    {
                        new Lesson(1, "GitHub vs Git", "GitHub es la plataforma, Git es la herramienta.\n\n🌐 ¿Qué ofrece GitHub?\n• Repositorios remotos en la nube\n• Colaboración en equipo\n• Pull Requests y Code Review\n• GitHub Actions (CI/CD)\n• Issues y Proyectos\n• Pages (hosting gratuito)\n\n💡 Alternativas: GitLab, Bitbucket, Azure DevOps", 10),
                        new Lesson(2, "Clonar y Conectar Repos", "Vincular repositorio local con GitHub.\n\n📌 Clonar un repo existente:\ngit clone https://github.com/user/repo.git\n\n📌 Conectar repo local:\ngit remote add origin https://github.com/user/repo.git\ngit push -u origin main\n\n📌 Comandos remotos:\ngit remote -v          # ver remotos\ngit fetch              # descargar cambios\ngit pull               # descargar y fusionar\ngit push               # subir cambios", 15),
                        new Lesson(3, "Pull Requests", "Los PR son la base del trabajo colaborativo.\n\n🔄 Flujo de PR:\n1. Crea una rama: git checkout -b feature/nueva\n2. Haz commits con tus cambios\n3. Sube la rama: git push origin feature/nueva\n4. En GitHub: 'New Pull Request'\n5. Describe los cambios\n6. Solicita revisores\n7. Discute y aplica feedback\n8. Merge cuando esté aprobado\n\n✅ Los PR mantienen main siempre estable.", 20),
                        new Lesson(4, "Issues y Proyectos", "Gestión de tareas y errores.\n\n📋 Issues:\n• Reportar bugs\n• Solicitar features\n• Hacer preguntas\n• Etiquetar: bug, enhancement, help-wanted\n\n📌 Referencias en commits:\ngit commit -m 'Fix login error. Closes #42'\n\n🗂️ GitHub Projects:\n• Tableros Kanban (To-do, In Progress, Done)\n• Automatización de estados\n• Vinculación con Issues y PRs\n\n💡 Los Issues cerrados por commits mantienen el historial limpio.", 18),
                    }
                },
                new Course
                {
                    Id = 4,
                    Title = "SQL Completo",
                    Description = "Bases de datos relacionales desde cero. SELECT, JOIN, subconsultas, índices y más.",
                    Icon = "🗄️",
                    Category = CourseCategory.SQL,
                    Difficulty = DifficultyLevel.Intermediate,
                    AccentColor = "#00758F",
                    Lessons = new List<Lesson>
                    {
                        new Lesson(1, "¿Qué es SQL?", "SQL = Structured Query Language\n\nEs el lenguaje estándar para gestionar bases de datos relacionales.\n\n🗄️ Bases de datos relacionales populares:\n• MySQL / MariaDB\n• PostgreSQL\n• SQL Server (Microsoft)\n• SQLite\n• Oracle DB\n\n📌 SQL se divide en:\n• DDL: Definir estructura (CREATE, ALTER, DROP)\n• DML: Manipular datos (SELECT, INSERT, UPDATE, DELETE)\n• DCL: Control de acceso (GRANT, REVOKE)", 10),
                        new Lesson(2, "CREATE y INSERT", "Crear tablas e insertar datos.\n\n📌 Crear tabla:\nCREATE TABLE students (\n    id INT PRIMARY KEY AUTO_INCREMENT,\n    name VARCHAR(100) NOT NULL,\n    email VARCHAR(150) UNIQUE,\n    age INT,\n    created_at DATETIME DEFAULT NOW()\n);\n\n📌 Insertar datos:\nINSERT INTO students (name, email, age)\nVALUES ('Juan Pérez', 'juan@email.com', 25);\n\n💡 PRIMARY KEY identifica cada fila de forma única.", 18),
                        new Lesson(3, "SELECT y Filtros", "Consultar datos con precisión.\n\n📌 Básico:\nSELECT * FROM students;\nSELECT name, email FROM students;\n\n📌 Con filtros:\nSELECT * FROM students\nWHERE age > 20 AND city = 'Medellín';\n\n📌 Ordenar y limitar:\nSELECT * FROM students\nORDER BY name ASC\nLIMIT 10;\n\n📌 Buscar texto:\nSELECT * FROM students\nWHERE name LIKE 'Juan%';\n\n💡 % es comodín: 'Juan%' = empieza con Juan.", 20),
                        new Lesson(4, "JOINs", "Combinar datos de múltiples tablas.\n\n📌 INNER JOIN (solo coincidencias):\nSELECT s.name, c.title\nFROM students s\nINNER JOIN enrollments e ON s.id = e.student_id\nINNER JOIN courses c ON e.course_id = c.id;\n\n📌 LEFT JOIN (todos los de la izquierda):\nSELECT s.name, c.title\nFROM students s\nLEFT JOIN enrollments e ON s.id = e.student_id;\n\n💡 Tipos de JOIN:\n• INNER: solo filas con coincidencia en ambas tablas\n• LEFT: todas las filas de la tabla izquierda\n• RIGHT: todas las filas de la tabla derecha\n• FULL OUTER: todas las filas de ambas tablas", 25),
                        new Lesson(5, "Funciones de Agregación", "Calcular estadísticas sobre los datos.\n\n📌 Funciones:\nSELECT\n    COUNT(*) AS total,\n    AVG(age) AS promedio_edad,\n    MAX(age) AS mayor,\n    MIN(age) AS menor,\n    SUM(salary) AS total_salarios\nFROM students;\n\n📌 GROUP BY:\nSELECT city, COUNT(*) AS total\nFROM students\nGROUP BY city\nHAVING COUNT(*) > 5\nORDER BY total DESC;\n\n💡 HAVING filtra grupos (como WHERE pero para agregaciones).", 22),
                        new Lesson(6, "UPDATE y DELETE", "Modificar y eliminar datos.\n\n📌 UPDATE:\nUPDATE students\nSET age = 26, city = 'Bogotá'\nWHERE id = 1;\n\n⚠️ ¡SIEMPRE usa WHERE en UPDATE y DELETE!\n\n📌 DELETE:\nDELETE FROM students\nWHERE id = 1;\n\n📌 Eliminar todos (peligroso):\nDELETE FROM students;  -- borra fila a fila\nTRUNCATE TABLE students;  -- más rápido, resetea auto_increment\n\n💡 Usa transacciones para operaciones críticas:\nBEGIN;\nDELETE FROM students WHERE age < 0;\nROLLBACK; -- o COMMIT;", 20),
                    }
                },
                new Course
                {
                    Id = 5,
                    Title = "C# para Principiantes",
                    Description = "El lenguaje de Microsoft. Aprende C# con proyectos prácticos y buenas prácticas.",
                    Icon = "⚡",
                    Category = CourseCategory.Programming,
                    Difficulty = DifficultyLevel.Beginner,
                    AccentColor = "#9B4F96",
                    Lessons = new List<Lesson>
                    {
                        new Lesson(1, "Introducción a C#", "C# es un lenguaje moderno, tipado y orientado a objetos.\n\nDesarrollado por Microsoft (Anders Hejlsberg, 2000).\nCorre sobre .NET Framework / .NET Core.\n\n🎯 ¿Para qué se usa?\n• Aplicaciones de escritorio (WinForms, WPF)\n• Web (ASP.NET Core)\n• Juegos (Unity)\n• Mobile (Xamarin, MAUI)\n• Microservicios\n\n📌 Primer programa:\nusing System;\nConsole.WriteLine(\"Hola, Colombia!\");", 12),
                        new Lesson(2, "Variables y Tipos", "C# es fuertemente tipado.\n\n📌 Tipos básicos:\nint edad = 25;\ndouble altura = 1.75;\nstring nombre = \"Juan\";\nbool activo = true;\nchar letra = 'A';\n\n📌 var (inferencia):\nvar ciudad = \"Medellín\";  // string\nvar numero = 42;           // int\n\n📌 Constantes:\nconst double PI = 3.14159;\n\n💡 Usa nombres descriptivos: totalStudents, not ts.", 15),
                        new Lesson(3, "Clases y Objetos", "C# es orientado a objetos.\n\n📌 Definir clase:\npublic class Student\n{\n    public string Name { get; set; }\n    public int Age { get; set; }\n\n    public Student(string name, int age)\n    {\n        Name = name;\n        Age = age;\n    }\n\n    public string GetInfo()\n    {\n        return $\"{Name} tiene {Age} años\";\n    }\n}\n\n📌 Usar la clase:\nvar student = new Student(\"Ana\", 22);\nConsole.WriteLine(student.GetInfo());", 25),
                    }
                },
                new Course
                {
                    Id = 6,
                    Title = "JavaScript Moderno",
                    Description = "El lenguaje de la web. ES6+, async/await, DOM, Fetch API y proyectos reales.",
                    Icon = "🌐",
                    Category = CourseCategory.Web,
                    Difficulty = DifficultyLevel.Intermediate,
                    AccentColor = "#F7DF1E",
                    Lessons = new List<Lesson>
                    {
                        new Lesson(1, "JavaScript Hoy", "JS es el lenguaje de la web moderna.\n\nCorre en el navegador Y en el servidor (Node.js).\n\n🌐 ¿Dónde se usa?\n• Páginas web interactivas\n• Aplicaciones web (React, Vue, Angular)\n• Backend (Node.js + Express)\n• Apps móviles (React Native)\n• Desktop (Electron)\n\n📌 Ejemplo moderno (ES6+):\nconst greet = (name) => `Hola, ${name}!`;\nconsole.log(greet('Colombia'));", 10),
                        new Lesson(2, "Arrow Functions y ES6", "La sintaxis moderna de JavaScript.\n\n📌 Arrow functions:\n// Tradicional\nfunction add(a, b) { return a + b; }\n\n// Arrow\nconst add = (a, b) => a + b;\n\n📌 Destructuring:\nconst { name, age } = person;\nconst [first, ...rest] = array;\n\n📌 Spread operator:\nconst newArray = [...arr1, ...arr2];\nconst newObj = { ...obj1, extra: 'value' };\n\n📌 Template literals:\nconst msg = `Hola ${name}, tienes ${age} años`;", 18),
                        new Lesson(3, "Promesas y Async/Await", "Manejo de operaciones asíncronas.\n\n📌 Fetch API:\nasync function getUsers() {\n    try {\n        const response = await fetch(\n            'https://api.example.com/users'\n        );\n        const data = await response.json();\n        return data;\n    } catch (error) {\n        console.error('Error:', error);\n    }\n}\n\n💡 async/await hace el código asíncrono\n   legible como si fuera síncrono.\n\n⚠️ Siempre usa try/catch con await.", 22),
                    }
                }
            };
        }
    }
}