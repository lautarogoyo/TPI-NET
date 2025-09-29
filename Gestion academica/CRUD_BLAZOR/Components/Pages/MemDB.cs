using System.ComponentModel.DataAnnotations;

namespace CRUD_BLAZOR.Components.Pages;

public static class MemDB
{
    // Tipo compartido
    public class Especialidad
    {
        public int IDEspecialidad { get; set; }

        [Required, StringLength(100)]
        public string Descripcion { get; set; } = string.Empty;
    }

    // “BD” en memoria
    public static List<Especialidad> Especialidades { get; } =
    [
        new Especialidad { IDEspecialidad = 1, Descripcion = "Matemática" },
        new Especialidad { IDEspecialidad = 2, Descripcion = "Programación" },
        new Especialidad { IDEspecialidad = 3, Descripcion = "Sistemas Operativos" },
        new Especialidad { IDEspecialidad = 4, Descripcion = "Bases de Datos" },
        new Especialidad { IDEspecialidad = 5, Descripcion = "Redes" }
    ];

    public static Especialidad? Get(int id) =>
        Especialidades.FirstOrDefault(e => e.IDEspecialidad == id);

    public static void Upsert(Especialidad src)
    {
        if (src.IDEspecialidad == 0)
        {
            src.IDEspecialidad = Especialidades.Any()
                ? Especialidades.Max(x => x.IDEspecialidad) + 1 : 1;
            Especialidades.Add(src);
            return;
        }

        var ex = Get(src.IDEspecialidad);
        if (ex is not null)
            ex.Descripcion = src.Descripcion;  // ← modificar la existente
    }


}
