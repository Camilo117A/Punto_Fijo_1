using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Fijo_1.modelo
{
    internal class IteracionData
    {
        public int Iteracion { get; set; }
        public double Xi { get; set; }
        public double Gxi { get; set; }
        public double Error { get; set; }
        public bool Convergio { get; set; }
    }
}
