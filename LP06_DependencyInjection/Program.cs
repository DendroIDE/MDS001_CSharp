//------------------------------------------------------------------------------------------------------------------------------
using LP06_DependencyInjection.DI01_MetodologiaSimple;

Console.WriteLine("\n" + "--------------------------------------------------------------------------------------------" + "\n");
//------------------------------------------------------------------------------------------------------------------------------
//DI01_MetodologíaSimple
Console.WriteLine("Dependency Injection - Simple Method");
Service1 service1 = new Service1();
Client client1 = new Client();
client1.Service = service1;
client1.ServeMethod();


Service2 service2 = new Service2();
Client client2 = new Client();
client2.Service = service2;
client2.ServeMethod();