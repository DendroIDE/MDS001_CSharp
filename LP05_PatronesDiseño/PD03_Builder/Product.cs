using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD03_Builder
{
    // Tiene sentido utilizar el patrón Builder sólo cuando sus productos son bastante complejos y requieren una configuración extensa.

    // A diferencia de otros patrones de creación, diferentes constructores concretos pueden producir productos no relacionados.
    // En otras palabras, los resultados de varios constructores pueden no seguir siempre la misma interfaz.
    internal class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // eliminar la última ", coma"

            return "Partes del producto: " + str + "\n";
        }
    }
}
