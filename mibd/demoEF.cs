using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.mibd
{
    public class demoEF : DbContext
    {
      public  DbSet <Empleado> Empleado { get; set; }
        
    }
}
