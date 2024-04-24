using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD05_Observer
{
    internal interface IObserver
    {
        // Recibir actualización del sujeto
        void Update(ISubject subject);
    }
}
