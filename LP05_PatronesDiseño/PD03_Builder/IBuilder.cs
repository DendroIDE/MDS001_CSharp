using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD03_Builder

    {
    // La interfaz Builder especifica métodos para crear las diferentes partes
    // de los objetos Producto.
    internal interface IBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();
    }
}
