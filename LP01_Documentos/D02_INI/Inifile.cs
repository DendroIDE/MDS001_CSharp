using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LP01_Documentos.D02_INI
{
    public class Inifile
    {
        /// <summary>
        /// Variable para manejar el nombre del archivo de configuracion
        /// </summary>
        private string _archivo;
        /// <summary>
        /// Permite definir que caracter se usará de comentario
        /// </summary>
        private string ComentLimit;
        /// <summary>
        /// Permite almacenar los valores que se obtendran del archivo
        /// </summary>
        private Dictionary<string, string> diccionario = new Dictionary<string, string>();
        /// <summary>
        /// Variable definida con set y get para modificar los accesos a elarchivo
        /// </summary>
        public string elarchivo
        {
            get
            {
                // Retornará el valor de _archivo
                return _archivo;
            }

            set
            {
                // Primero setear a _archivo con el valor null 
                _archivo = null;
                // Condicional que verifica si existe el archivo informado a elarchivo, caso contrario deja a _archivo como null.
                if (File.Exists(value)) //value es la propiedad que almacena el valor que le asignamos a la variable es propio del lenguaje y lo tenes a disposicion siempre
                {
                    // Setear _archivo con el valor de value 
                    _archivo = value;
                    // Utilizar a using para poder ejecutar el StreamReader para leer el archivo que se informa en _archivo
                    using (StreamReader sr = File.OpenText(_archivo))
                    {
                        // Variable a utilizar en distintos datos del archivo
                        string linea, seccion = "", clave = "", clave2 = "", valor = "";
                        // while que se utiliza para verificar que el valor almacenado en linea sea disitinto de null
                        while ((linea = sr.ReadLine()) != null) // El ReadLine lee la linea completa y la almacena en la variable del mismo nombre
                        {
                            // Bloque condicional que se encargara de verificar el tamaño de linea,
                            // si es igual a 0 procede a omitir la vuelta porque considera que es una linea vacia.
                            if (linea.Length == 0)
                                continue;
                            // Bloque condicional que verifica primero que se haya informado un caracter de comentario
                            // y con otra condicion donde verifica si la linea comienza con ese caracter,
                            // todo con el operador logico AND (&&)
                            // si las dos son verdaderas considera que la linea esta comentada y procede a saltar esta vuelta del bucle.
                            if (!String.IsNullOrEmpty(ComentLimit)
                                && linea.StartsWith(ComentLimit))
                                continue;
                            // Verifica si comienza con un corchete ([) y luego verifica si en la misma contiene otro corchete (]),
                            // si se cumplen ambas condiciones, significa que es la etiqueta de la seccion de la configuracion.
                            if (linea.StartsWith("[") && linea.Contains("]"))
                            {
                                // Procedera a primero crear una variable donde almacenara la posicion del ultimo corchete
                                int indice = linea.IndexOf(']');
                                // Luego usará un SubString donde le dirá que empiece de la posicion 1 y que vaya hasta el valor de indice restandole uno.
                                seccion = linea.Substring(1, indice - 1).Trim(); // Por ultimo usará un Trim para eliminar cualquier espacio en blanco al principio o al final, todo esto lo almacenará en la variable seccion
                                // Imprimir el resultado de la variable seccion en Consola
                                // Console.WriteLine(seccion);
                            }
                            // Bloque condicional que se encargara de buscar si existe un simbolo de igual (=),
                            // en caso de ser cierto quiere decir que aqui esta almacenado el valor con la referencia.
                            if (linea.Contains("="))
                            {
                                // En la variable indice verificará en que posicion esta el igual
                                int indice = linea.IndexOf('=');
                                // En la variable clave se asignará el valor obtenido por la SubString que iniciara desde la primer posicion hasta el valor de indice
                                clave = linea.Substring(0, indice).Trim(); //Con un Trim se limpiará los espacios de adelante y atras
                                // En la variable valor se asignará el extracto obtenido del Substring, pero esta vez no se asignará una longitud para que lo haga hasta el final de la línea
                                valor = linea.Substring(indice + 1).Trim(); // Con un Trim se limpiará los espacios de adelante y atras
                                // Bloque condicional que verificara si el comienzo y el final de valor posee comillas
                                if (valor.StartsWith("\"") && valor.EndsWith("\""))
                                {
                                    // En caso de ser cierto el condicional, usa un Substring donde omite el primer caracter y le restará dos caracteres para omitir el ultimo caracter y el anterior
                                    valor = valor.Substring(1, valor.Length - 2);
                                }
                            }
                            // Imprime la obtención de clave y valor en Consola
                            // Console.WriteLine(seccion + "->" + clave + "->" + valor);
                            // Verifica si seccion y clave son distintos de nada
                            if (seccion != "" && clave != "")
                            {
                                // En caso de ser verdadero procede a asignar a clave2 el valor de seccion concatenado con el valor de clave y en el medio un guion
                                clave2 = seccion + "-" + clave;
                                // Adicionar a clave2 como la clave de busqueda y a valor como el valor de la clave
                                diccionario.Add(clave2, valor);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Constructor de la clase que recibe dos datos pero uno sera opcional, 
        /// el primero sera el nombre del archivo y lo almacena en archivo 
        /// y el segundo sera para informar cual va a ser el simbolo de comentario, 
        /// sino comentamos ninguno tomara de manera predeterminada el punto y coma (;)
        /// </summary>
        /// <param name="archivo">Valor informado en el archivo.</param>
        /// <param name="comentLimit">Valor informado de comentLimit sino se informa ninguno pasará el predeterminado (;).</param>
        public Inifile(string archivo, string comentLimit = ";")
        {
            //Ruta del documento
            string Ensamblador_Name = Assembly.GetExecutingAssembly().Location;
            string Directorio_Name = Path.GetDirectoryName(Ensamblador_Name);
            string rutaDocumentoXML = Path.Combine(Directorio_Name, "D02_INI", archivo);
            //Asignacion de variables
            ComentLimit = comentLimit;
            elarchivo = rutaDocumentoXML;
        }
        /// <summary>
        /// Metodo que permite obtener el valor de diccionario, lo primero que hará sera concatenar las variables sección y dato, 
        /// para luego por medio de un return devolver el valor almacenado en diccionario en base a la clave generada.
        /// </summary>
        /// <param name="seccion">Sección a buscar en el archivo ini</param>
        /// <param name="dato">Dato a buscar en el archivo ini</param>
        /// <returns></returns>
        public string mostrar(string seccion, string dato)
        {
            string clave = seccion + "-" + dato;
            return diccionario[clave];
        }

    }
}
