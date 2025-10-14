using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ComisionMateria
    {
        public int IDComisionMateria { get; private set; }
        public int HsSemanales { get; private set; }
        public int HsTotales { get; private set; }
        public int IDComision { get; private set; }
        public int IDMateria { get; private set; }
        public Comision Comision { get; private set; }
        public Materia Materia { get; private set; }

        private ComisionMateria() { }

        public ComisionMateria(int hsSemanales, int hsTotales, int idComision, int idMateria)
        {
            SetHsSemanales(hsSemanales);
            SetHsTotales(hsTotales);
            SetIDComision(idComision);
            SetIDMateria(idMateria);
        }

        public void SetHsSemanales(int hsSemanales)
        {
            if (hsSemanales <= 0) throw new ArgumentException("Las horas semanales deben ser mayores que 0.", nameof(hsSemanales));
            HsSemanales = hsSemanales;
        }
        public void SetHsTotales(int hsTotales)
        {
            if (hsTotales <= 0) throw new ArgumentException("Las horas totales deben ser mayores que 0.", nameof(hsTotales));
            HsTotales = hsTotales;
        }
        public void SetIDComision(int idComision)
        {
            if (idComision <= 0) throw new ArgumentException("El ID de la comisión debe ser mayor que 0.", nameof(idComision));
            IDComision = idComision;
        }
        public void SetIDMateria(int idMateria)
        {
            if (idMateria <= 0) throw new ArgumentException("El ID de la materia debe ser mayor que 0.", nameof(idMateria));
            IDMateria = idMateria;
        }

    }
}
