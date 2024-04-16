using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            //Cargar el documento XML
            try
            {
                //Crear la instancia de xmldocument
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaDocumentoXML);
                // Si tiene nodos, recorrer sus hijos
                if (doc.DocumentElement.HasChildNodes)
                {
                    // Recorrer los hijos del nodo principal
                    foreach (XmlNode n1 in doc.DocumentElement.ChildNodes)
                    {
                        if (n1.Attributes["base_datos"].Value.Equals(tipoBaseDatos))
                        {
                            // Obtener el atributo de los nodos hijos
                            foreach (XmlNode n2 in n1.ChildNodes)
                            {
                                if (n2.Attributes["entorno_empresarial"].Value.Equals(entornoEmpresarial))
                                {
                                    Console.WriteLine(n2.Name + " " + n2.InnerText.Replace(":CONNECTION_NAME", "MEGAKONS").Replace(":HOST_IP", "192.168.1.12").Replace(":PORT_IP", "1522").Replace(":NAME_BD", "MGK").Replace(":USER_BD", "PRD").Replace(":PASSWORD_BD", "PRD"));
                                }
                            }
                        }
                        else
                        {
                            // Obtener el atributo de los nodos hijos
                            foreach (XmlNode n2 in n1.ChildNodes)
                            {
                                if (n2.Attributes["entorno_empresarial"].Value.Equals(entornoEmpresarial))
                                {
                                    Console.WriteLine($"Solo debe existir una variable de cadena de conexion por entorno empresarial y por tipo de base de datos: {n2.Name} - {n2.Attributes["entorno_empresarial"].Value} - {n2.InnerText}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Revisar archivo de conexión XML");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}
