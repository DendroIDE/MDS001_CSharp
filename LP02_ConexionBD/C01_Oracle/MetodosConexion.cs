using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace LP02_ConexionBD.C01_Oracle
{
    public class MetodosConexion
    {
        public string ObtenerCadenaConexion(string tipoBaseDatos, string entornoEmpresarial, string nombreCarpetaRecursos, string nombreArchivoXML)
        {
            //Ruta del documento
            string Ensamblador_Name = Assembly.GetExecutingAssembly().Location;
            string Directorio_Name = Path.GetDirectoryName(Ensamblador_Name);
            string rutaDocumentoXML = Path.Combine(Directorio_Name, nombreCarpetaRecursos, nombreArchivoXML);
            //Variable que permiten la lectura de los elementos del documento XML que contiene las cadenas de conexión.
            XElement root = XElement.Load(rutaDocumentoXML);
            //Variable que representa el elemento del documento xml con tipo de base de datos necesario a leer la cadena de conexion.
            IEnumerable<XElement> exml_base_datos;
            //Variable que representa el elemento del documento xml con entorno empresarial de datos necesario a leer la cadena de conexion.
            IEnumerable<XElement> exml_entorno_empresarial;
            //Cargar el documento XML
            try
            {
                //Crear la instancia de xmldocument
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaDocumentoXML);
                // Si tiene nodos hijos y el elemento root se define como <cadena_conexion> </cadena_conexion>, recorrer sus hijos
                if (doc.DocumentElement.HasChildNodes && doc.DocumentElement.Name.Equals("cadena_conexion"))
                {
                    //LinQ que permite la búsqueda del tipo de base de datos a utilizar definido en el documento XML
                    exml_base_datos =
                        from elemento in root.Elements("conexion")
                        where (string) elemento.Attribute("base_datos") == "oracle"
                        select elemento;
                    // Si se ha definido solo un tipo de base de datos como nodo padre principal entonces condiciona.
                    if (exml_base_datos.Count() == 1)
                    {
                        //LinQ que permite la búsqueda del entorno empresarial a utilizar definido en el documento XML.
                        exml_entorno_empresarial =
                            from element in exml_base_datos.Elements("variable_cadena_conexion")
                            where (string) element.Attribute("entorno_empresarial") == "MEGAKONS"
                            select element;
                        // Si se a defindo solo un entorno empresarial como nodo secundario entonces condiciona
                        if (exml_entorno_empresarial.Count() == 1)
                        {
                            Console.WriteLine(exml_entorno_empresarial.First().Value);
                        }
                        // Caso contrario al tener definido más de uno o menos de uno entorno empresarial en un tipo de base de daros entonces condiciona el mensaje de error
                        else
                        {
                            //Ciclo que recorre el elemento filtrado por LinQ en el nodo del entorno empresarial
                            foreach (XElement elemento_xml in exml_entorno_empresarial)
                            {
                                Console.WriteLine($"Debe existir una única variable de cadena de conexion por entorno empresarial: {elemento_xml.Name} - {elemento_xml.Attribute("entorno_empresarial").Value} - {elemento_xml.Value}");
                            }
                        }
                    }
                    //Caso contrario al tener definido más de uno o ménos de uno tipo de base de datos como nodo padre principal entones condiciona el mensaje de error
                    else
                    {
                        //Ciclo que recorre el elemento filtrado por LinQ en el nodo del tipo de base de datos.
                        foreach (XElement elemento_xml in exml_base_datos)
                        {
                            Console.WriteLine($"Debe existir una única variable de cadena de conexion por tipo de base de datos: {elemento_xml.Name} - {elemento_xml.Attribute("base_datos").Value} - {elemento_xml.Value}");
                        }
                    }

                }
                //Caso contrario al no tener nodos hijos y el elemento root no se define como <cadena_conexion> </cadena_conexion> entonces condiciona el mensaje de error
                else
                {

                    // Imprimir error del documento <cadena_conexion> </cadena_conexion>.
                    Console.WriteLine("Revisar archivo de conexión XML elemento <cadena_conexion>.");
                }
            }
            catch (Exception exception)
            {
                //Imprimir cualquiera error surgiente al ejecutar la lectura del archivo de cadena de conexion
                Console.WriteLine(exception.Message);
            }
            return "";
        }
    }
}
