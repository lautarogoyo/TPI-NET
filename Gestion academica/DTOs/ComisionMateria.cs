using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ComisionMateriaDTO
    {
        public int IDComisionMateria { get; set; }
        public int HsSemanales { get; set; }
        public int HsTotales { get; set; }
        public int IDComision { get; set; }
        public int IDMateria { get; set; }
        public string DescMateria { get; set; } = string.Empty;

    }
}
