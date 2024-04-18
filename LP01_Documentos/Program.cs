using LP01_Documentos;
using LP01_Documentos.D02_INI;
using System.Reflection;


MetodosXML metodosXML = new MetodosXML();
metodosXML.leerDocumentoXML("D01_XML", "testing.xml");

MetodosINI metodosINI = new MetodosINI();
Inifile configuracion = new Inifile("testing.ini");

Console.WriteLine(configuracion.mostrar("rutas", "alumnos"));