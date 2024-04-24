using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD05_Observer
{
    internal interface ISubject
    {
        // Adjuntar un observador al sujeto.
        void Attach(IObserver observer);
        // Separar un observador del sujeto.
        void Detach(IObserver observer);
        // Notificar a todos los observadores sobre un evento.
        void Notify();
    }
}
