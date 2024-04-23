using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD01_Singleton
{
    // La clase Singleton define el método `GetInstance` que sirve como una
    // alternativa al constructor y permite a los clientes acceder a la misma instancia de
    // esta clase una y otra vez.

    // ES : El Singleton debe ser siempre una clase 'sellada' para prevenir la herencia // de clases a través de clases externas y también a través de clases anidadas.
    // herencia a través de clases externas y también a través de clases anidadas.
    internal sealed class Singleton
    {
        // El constructor del Singleton debe ser siempre privado para prevenir
        // llamadas directas de construcción con el operador `new`.
        private Singleton() { }

        // La instancia del Singleton se almacena en un campo estático. Existen
        // múltiples maneras de inicializar este campo, todas ellas tienen varios pros
        // y contras. En este ejemplo mostraremos la más simple de estas formas,
        // que, sin embargo, no funciona muy bien en programas multihilo.
        private static Singleton _instance;
        // Este es el método estático que controla el acceso al singleton
        // instancia. En la primera ejecución, crea un objeto singleton y lo coloca
        // en el campo estático. En las siguientes ejecuciones, devuelve al cliente
        // objeto existente almacenado en el campo estático.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
        // Por último, cualquier singleton debe definir alguna lógica de negocio, que puede
        // ser ejecutada en su instancia.
        public void someBusinessLogic()
        {
            // ...
        }
    }
}
