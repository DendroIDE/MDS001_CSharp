using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD04_Strategy
{
    // El Contexto define la interfaz de interés para los clientes.
    internal class Context
    {
        // El Contexto mantiene una referencia a uno de los objetos Estrategia.
        // El Contexto no conoce la clase concreta de una estrategia.
        // Debe trabajar con todas las estrategias a través de la interfaz Strategy.
        private IStrategy _strategy;
        public Context()
        { }

        // Normalmente, el Context acepta una estrategia a través del constructor, pero también proporciona un setter para cambiarla en tiempo de ejecución.
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Normalmente, el Contexto permite reemplazar un objeto Estrategia en tiempo de ejecución.
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        // El Contexto delega parte del trabajo al objeto Estrategia en lugar de implementar múltiples versiones del algoritmo por su cuenta.
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Ordenar los datos utilizando la estrategia (no estoy seguro de cómo lo hará)");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }

    }
}
