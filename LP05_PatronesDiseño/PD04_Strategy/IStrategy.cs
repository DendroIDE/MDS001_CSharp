using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD04_Strategy
{

    // La interfaz Estrategia declara operaciones comunes a todas las versiones soportadas de algún algoritmo.
    // El Contexto utiliza esta interfaz para llamar al algoritmo definido por Estrategias Concretas.
    internal interface IStrategy
    {
        object DoAlgorithm(object data);

    }
}
