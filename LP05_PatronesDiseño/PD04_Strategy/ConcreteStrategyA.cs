using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD04_Strategy
{
    // Las Estrategias concretas implementan el algoritmo siguiendo la interfaz de la Estrategia base. La interfaz las hace intercambiables en el Contexto.
    internal class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }
}
