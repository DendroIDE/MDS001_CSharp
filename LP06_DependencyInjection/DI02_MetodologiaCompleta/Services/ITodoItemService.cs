using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP06_DependencyInjection.DI02_MetodologiaCompleta.Services
{
    internal interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();

    }
}
