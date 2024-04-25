using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP06_DependencyInjection.DI02_MetodologiaCompleta.Services
{
    internal class TodoController
    {
        private readonly ITodoItemService _todoItemService;
        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public void Index()
        {
            // Obtener las tareas desde la base de datos

            // Coloca los elemento dentro de un modelo

            // Pasa la vista al model y visualiza
        }
    }
}
