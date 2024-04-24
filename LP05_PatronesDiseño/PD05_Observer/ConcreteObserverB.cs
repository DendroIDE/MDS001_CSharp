using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD05_Observer
{
    // Los Observadores concretos reaccionan a las actualizaciones emitidas por el Sujeto al que han sido adjuntados.
    internal class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reaccionó ante el acontecimiento.");
            }
        }
    }
}
