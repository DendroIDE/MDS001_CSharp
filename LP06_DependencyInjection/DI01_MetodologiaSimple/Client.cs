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
        public IService Service
        {
            set
            {
                this._service = value;
            }
        }

        public Client(){

        }

        public void ServeMethod()
        {
            this._service.Serve();
        }
    }
}
