using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD03_Builder
{
    // El Director sólo es responsable de ejecutar los pasos de construcción en una secuencia determinada.
    // Es útil cuando se producen productos de acuerdo con un orden o configuración específicos.
    // Estrictamente hablando, la clase Director es opcional, ya que el cliente puede controlar directamente a los constructores.
    internal class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        // El Director puede construir varias variaciones del producto utilizando los mismos pasos de construcción.
        public void BuildMinimalViableProduct()
        {
            this._builder.BuildPartA();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.BuildPartA();
            this._builder.BuildPartB();
            this._builder.BuildPartC();
        }

    }
}
