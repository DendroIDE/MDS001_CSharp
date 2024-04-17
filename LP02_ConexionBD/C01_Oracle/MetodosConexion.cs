﻿using System.Reflection;
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
            IEnumerable<XElement> address;
            //Variable que representa el elemento del documento xml con entorno empresarial de datos necesario a leer la cadena de conexion.
            IEnumerable<XElement> entorno;
            //Cargar el documento XML
            try
            {
                //Crear la instancia de xmldocument
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaDocumentoXML);
                // Si tiene nodos y el elemento root se define como <cadena_conexion> </cadena_conexion>, recorrer sus hijos
                if (doc.DocumentElement.HasChildNodes && doc.DocumentElement.Name.Equals("cadena_conexion"))
                {                    
                    address =
                        from elemento in root.Elements("conexion")
                        where (string)elemento.Attribute("base_datos") == "oracle"
                        select elemento;

                    if (address.Count() == 1)
                    {
                        entorno =
                            from element in address.Elements("variable_cadena_conexion")
                            where (string) element.Attribute("entorno_empresarial") == "MEGAKONS"
                            select element;

                        if (entorno.Count() == 1)
                        {
                            Console.WriteLine(entorno.First().Value);
                        }
                        else
                        {
                            foreach (XElement el in entorno)
                            {
                                Console.WriteLine($"Debe existir una única variable de cadena de conexion por entorno empresarial: {el.Name} - {el.Attribute("entorno_empresarial").Value} - {el.Value}");
                            }
                        }
                    }
                    else
                    {
                        foreach (XElement el in address)
                        {
                            Console.WriteLine($"Debe existir una única variable de cadena de conexion por tipo de base de datos: {el.Name} - {el.Attribute("base_datos").Value} - {el.Value}");
                        }
                    }

                }
                else
                {

                    // Imprimir error del documento <cadena_conexion> </cadena_conexion>.
                    Console.WriteLine("Revisar archivo de conexión XML elemento <cadena_conexion>.");
                }
            }
            catch (Exception e)
            {
                //Imprimir cualquiera error surgiente al ejecutar la lectura del archivo de cadena de conexion
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}