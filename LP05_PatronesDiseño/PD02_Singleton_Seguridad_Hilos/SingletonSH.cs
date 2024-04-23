using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD02_Singleton_Seguridad_Hilos
{
    // Esta implementación de Singleton se llama "bloqueo de doble comprobación". Es segura
    // en entornos multihilo y proporciona una inicialización perezosa para el objeto
    // objeto Singleton.
    internal class SingletonSH
    {
        private SingletonSH() { }

        private static SingletonSH _instance;

        // Ahora tenemos un objeto de bloqueo que se utilizará para sincronizar hilos
        // durante el primer acceso al Singleton.
        private static readonly object _lock = new object();

        public static SingletonSH GetInstance(string value)
        {
            // Esta condicional es necesaria para evitar que los hilos tropiecen con el
            // bloqueo una vez que la instancia está lista.
            if (_instance == null)
            {
                // Ahora, imagine que el programa acaba de lanzarse. Dado que
                // aún no hay instancia Singleton, múltiples hilos pueden
                // pasar simultáneamente el condicional anterior y llegar a este
                // punto casi al mismo tiempo. El primero de ellos adquirirá
                // el bloqueo y seguirá adelante, mientras que el resto esperará aquí.
                lock (_lock)
                {
                    // El primer hilo que adquiere el bloqueo, alcanza esta
                    // condicional, entra y crea la instancia Singleton.
                    // Una vez que abandona el bloqueo, un hilo que
                    // podría haber estado esperando la liberación del bloqueo puede entonces
                    // entrar en esta sección. Pero como el campo Singleton
                    // ya inicializado, el hilo no creará un nuevo
                    // objeto.
                    if (_instance == null)
                    {
                        _instance = new SingletonSH();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        // Usaremos esta propiedad para probar que nuestro Singleton realmente funciona.
        public string Value { get; set; }

    }
}
