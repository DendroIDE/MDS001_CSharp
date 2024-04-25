using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP06_DependencyInjection.DI01_MetodologiaSimple
{
    internal class Service1 : IService
    {
        public void Serve()
        {
            Console.WriteLine("Llamado a Service 1");
        }
    }
}
