namespace LP03_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IBebida oBebidaC = new Cerveza();
            IBebida oBebidaV = new VinoTinto();
            var lst = new List<IBebida>();

            lst.Add(oBebidaC);
            lst.Add(oBebidaV);

            Mostrar(lst);
        }

        public static void Mostrar(List<IBebida> lst)
        {
            foreach (var oElement in lst)
            {
                Console.WriteLine(oElement.Mostrar());
            }
        }

        public interface IBebida
        {

            int Cantidad { get; set; }
            string Mostrar();
        }


        public interface IBebidaAlcoholica : IBebida
        {
            string Alcohol { get; set; }
            string Presentacion { get; set; }
            string Marca { get; set; }

            void Llenar(int NuevaCantidad);
        }

        public class Cerveza : IBebidaAlcoholica
        {
            public string Alcohol { get; set; }
            public string Presentacion { get; set; }
            public string Marca { get; set; }
            public int Cantidad { get; set; }

            public void Llenar(int NuevaCantidad)
            {
                //Validaciones

                //Otras
                this.Cantidad = NuevaCantidad - 10;
            }
            public string Mostrar()
            {
                return "La cantidad de la cerveza es: " + this.Cantidad;
            }
        }

        public class VinoTinto : IBebidaAlcoholica
        {
            public string Alcohol { get; set; }
            public string Presentacion { get; set; }
            public string Marca { get; set; }
            public int Cantidad { get; set; }

            public void Llenar(int NuevaCantidad)
            {
                //Validaciones

                //Otras
                this.Cantidad = NuevaCantidad - 20;
            }

            public string Mostrar()
            {
                return "La cantidad del vino es: " + this.Cantidad;
            }

        }
    }
}