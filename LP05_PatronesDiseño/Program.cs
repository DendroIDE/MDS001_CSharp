
using LP05_PatronesDiseño.PD01_Singleton;
using LP05_PatronesDiseño.PD02_Singleton_Seguridad_Hilos;

// Singleton ingenuo
Console.WriteLine("Singleton ingenuo");
// El código cliente.
//Realizar un Debug en esta línea para enteder el código.
Singleton s1 = Singleton.GetInstance();
Singleton s2 = Singleton.GetInstance();

if (s1 == s2)
{
    Console.WriteLine("Singleton funciona, ambas variables contienen la misma instancia.");
}
else
{
    Console.WriteLine("Singleton fallido, las variables contienen diferentes instancias.");
}
//------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n" + "--------------------------------------------------------------------------------------------" + "\n");
//------------------------------------------------------------------------------------------------------------------------------
//Singleton con seguridad en los hilos
Console.WriteLine("Singleton con seguridad en los hilos");
//Método de prueba del Singleton
static void TestSingleton(string value)
{
    SingletonSH singleton = SingletonSH.GetInstance(value);
    Console.WriteLine(singleton.Value);
}

//EL código del cliente
Console.WriteLine(
    "{0}\n{1}\n\n{2}\n",
    "Si ves el mismo valor, es que se ha reutilizado el singleton (¡bien!)",
    "Si ves valores diferentes, es que se han creado 2 singletons (¡¡booo!!)",
    "RESULTADO:"
);

Thread process1 = new Thread(() =>
{
    TestSingleton("FOO");
});
Thread process2 = new Thread(() =>
{
    TestSingleton("BAR");
});

process1.Start();
process2.Start();

process1.Join();
process2.Join();
//------------------------------------------------------------------------------------------------------------------------------
Console.WriteLine("\n" + "--------------------------------------------------------------------------------------------" + "\n");
//------------------------------------------------------------------------------------------------------------------------------