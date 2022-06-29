using System;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            dsUniversidad miUniversidad = new dsUniversidad();

            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            dsUniversidad.dtAlumnosRow rowAlumno = dtAlumnos.NewdtAlumnosRow();

            rowAlumno.Apellido = "Perez";
            rowAlumno.Nombre = "Juan";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dsUniversidad.dtCursosRow rowCurso = dtCursos.NewdtCursosRow();
            rowCurso.Curso = "Informatica";
            dtCursos.AdddtCursosRow(rowCurso);

            dsUniversidad.dt_Alumnos_CursosDataTable dtAlumnos_Cursos = new dsUniversidad.dt_Alumnos_CursosDataTable();
            dsUniversidad.dt_Alumnos_CursosRow rowAlumnosCursos = dtAlumnos_Cursos.Newdt_Alumnos_CursosRow();
            dtAlumnos_Cursos.Adddt_Alumnos_CursosRow(rowAlumno, rowCurso);

            rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Apellido = "Perez";
            rowAlumno.Nombre = "Marcelo";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);

            dtAlumnos_Cursos.Adddt_Alumnos_CursosRow(rowAlumno, rowCurso);
        }
    }
}
