using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP05_PatronesDiseño.PD03_Builder
{
    // Las clases Concrete Builder siguen la interfaz Builder y proporcionan
    // implementaciones específicas de los pasos de construcción. Tu programa puede tener
    // varias variaciones de Constructores, implementadas de forma diferente.
    internal class ConcreteBuilder : IBuilder
    {

        // Una nueva instancia del constructor debe contener un objeto producto en blanco, que
        // se utiliza en el montaje posterior.
        private Product _product = new Product();
        public ConcreteBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Product();
        }
        // Todos los pasos de producción trabajan con la misma instancia de producto.
        public void BuildPartA()
        {
            this._product.Add("PartA1");
        }

        public void BuildPartB()
        {
            this._product.Add("PartB1");
        }

        public void BuildPartC()
        {
            this._product.Add("PartC1");
        }
        // Se supone que Concrete Builder debe proporcionar sus propios métodos para recuperar resultados.
        // Esto se debe a que varios tipos de constructores pueden crear productos completamente diferentes
        // que no siguen la misma interfaz. Por lo tanto, tales métodos no pueden ser declarados en
        // la interfaz base del Constructor (al menos en un lenguaje de programación estáticamente tipado).
        //
        // Normalmente, después de devolver el resultado final al cliente,
        // se espera que una instancia del constructor esté lista para empezar a producir otro producto.
        // Por eso es una práctica habitual llamar al método reset al final del cuerpo del método `GetProduct`.
        // Sin embargo, este comportamiento no es obligatorio, y puedes hacer que tus constructores esperen
        // una llamada explícita a reset desde el código del cliente antes de deshacerse del resultado anterior.
        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }

    }
}
