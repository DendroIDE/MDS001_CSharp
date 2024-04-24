using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD05_Observer
{
    // El Sujeto posee algún estado importante y notifica a los observadores cuando el estado cambia.
    internal class Subject : ISubject
    {
        // Por simplicidad, el estado del Sujeto, esencial para todos los suscriptores, se almacena en esta variable.
        public int State { get; set; } = -0;

        // Lista de abonados. En la vida real, la lista de suscriptores puede almacenarse de forma más exhaustiva (categorizada por tipo de evento, etc.).
        private List<IObserver> _observers = new List<IObserver>();

        // Los métodos de gestión de suscripciones.
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Asunto: Adjunto un observador.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Asunto: Separado un observador.");
        }

        // Activar una actualización en cada suscriptor.
        public void Notify()
        {
            Console.WriteLine("Asunto: Notificar a los observadores...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        // Normalmente, la lógica de suscripción es sólo una fracción de lo que un Sujeto puede hacer realmente.
        // Los Sujetos comúnmente contienen alguna lógica de negocio importante,
        // que desencadena un método de notificación cada vez que algo importante está a punto de suceder (o después de ello).
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nAsunto: Estoy haciendo algo importante.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Asunto: Mi estado acaba de cambiar a: " + this.State);
            this.Notify();
        }
    }
}
