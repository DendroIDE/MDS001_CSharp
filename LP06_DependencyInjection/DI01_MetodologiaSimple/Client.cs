using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP06_DependencyInjection.DI01_MetodologiaSimple
{
    internal class Client
    {
        private IService _service;

        public Client() {
        }

        public void ServeMethod(IService service)
        {
            service.Serve();
        }
    }
}
