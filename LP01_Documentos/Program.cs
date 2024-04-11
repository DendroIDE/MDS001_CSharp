//Crear la instancia de xmldocument
using System.Xml;

XmlDocument doc = new XmlDocument();
//Cargar el documento XML
doc.Load("testing.xml");
// Recorrer los hijos del nodo concesionario
foreach (XmlNode n1 in doc.DocumentElement.ChildNodes)
{
    // Si tiene nodos, recorrer sus hijos
    if (n1.HasChildNodes)
    {
        foreach (XmlNode n2 in n1.ChildNodes)
        {
            // Obtener el atributo matricula del nodo coche
            String matricula = n2.Attributes["matricula"].Value;
            Console.WriteLine("Matricula: " + matricula);
            // Nodos hijos del coche
            foreach (XmlNode n3 in n2.ChildNodes)
            {
                Console.WriteLine(n3.Name + " " + n3.InnerText);
            }
        }
    }

}