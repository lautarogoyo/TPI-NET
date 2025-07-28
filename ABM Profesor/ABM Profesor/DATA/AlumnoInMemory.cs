using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    internal class AlumnoInMemory
    {
        public static List<Alumno> Alumos;

        static AlumnoInMemory()
        {
            Alumos = new List<Alumno>
            {
                new Alumno()
            }
        }

    }
}

