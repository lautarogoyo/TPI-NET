using System;
using Domain.Model;

public class CursoInMemory
{

    public static List<Curso> Curso;

    static CursoInMemory()
    {
        Curso = new List<Curso>
            {
                new Curso(2025, 50, "Sistemas", 05, 3 ),
                new Curso(2025, 30, "Programación", 05, 2 ),
                new Curso(2025, 40, "Base de Datos", 05, 1 ),
                new Curso(2025, 20, "Redes", 05, 4 ),
            };
    }
}