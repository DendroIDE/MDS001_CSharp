//Conexión base de datos Oracle
using LP02_ConexionBD.C01_Oracle;

MetodosConexion metodosConexionOracle = new MetodosConexion();
metodosConexionOracle.ObtenerCadenaConexion("oracle", "MEGAKONS", "Cadenas de conexion", "conexion.xml");