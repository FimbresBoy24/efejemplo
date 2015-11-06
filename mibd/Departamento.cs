using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.mibd
{
    public class Departamento
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
