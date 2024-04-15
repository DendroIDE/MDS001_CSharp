using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LP01_Documentos
{
    public class MetodosXML
    {
        public void leerDocumentoXML(string nombreCarpetaRecursos, string nombreArchivoXML)
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
                // Recorrer los hijos del nodo concesionario
                foreach (XmlNode n1 in doc.DocumentElement.ChildNodes)
                {
                    // Si tiene nodos, recorrer sus hijos
                    if (n1.HasChildNodes)
                    {
                        foreach (XmlNode n2 in n1.ChildNodes)
                        {
                            // Obtener el atributo de los nodos hijos
                            String nodo_hijo = n2.Attributes["nodo_hijo"].Value;
                            Console.WriteLine("Nodo: " + nodo_hijo);
                            // Nodos hijos de los nodos hijos
                            foreach (XmlNode n3 in n2.ChildNodes)
                            {
                                Console.WriteLine(n3.Name + " " + n3.InnerText);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
