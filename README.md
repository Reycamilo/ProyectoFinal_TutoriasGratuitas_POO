# 📚 Tutorías Estudiantiles Gratuitas

Sistema de gestión de tutorías donde estudiantes de años superiores pueden ofrecer ayuda a estudiantes de primer ingreso, organizando tutores y materias de forma clara y eficiente.

---

## 🛠️ Tecnologías

- **Backend:** ASP.NET Core Web API
- **Base de datos:** SQLite / SQLiteStudio
- **Lenguaje:** C#
- **Control de versiones:** Git & GitHub

---

## 🗄️ Estructura de la Base de Datos

**Tutores** — Nombre, Carrera, Carnet, MateriaId

**Materias** — Nombre de la materia, Facultad

> La relación entre tablas permite filtrar tutores por materia, facilitando la búsqueda para el usuario final.

---

## 🌿 Ramas del Proyecto

| Rama | Descripción |
|---|---|
| `main` | Código final y estable |
| `develop` | Rama de integración y pruebas |
| `feature/...` | Ramas individuales de desarrollo |

---

## 👥 Equipo

| Nombre | Rol |
|---|---|
| Jose Camilo Alvarado | Líder del proyecto |
| Osvin Jossue Alvarado | Desarrollador |
| Marlon Dorian | Desarrollador |

---

## 📋 Requisitos

- .NET SDK
- SQLiteStudio
- Git

---

## 🚀 Instalación

```bash
# Clonar el repositorio
git clone https://github.com/Reycamilo/TutoriasGratuitas.git

# Entrar a la carpeta
cd TutoriasGratuitas

# Restaurar dependencias
dotnet restore

# Ejecutar el proyecto
dotnet run
```

---

*Proyecto académico — Programación Orientada a Objetos*