var builder = WebApplication.CreateBuilder(args);

using NLog;
using NLog.Web;
using System;

namespace LP07_Logs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Init temprano de NLog para permitir el inicio y el registro de excepciones, antes de que se construya el host
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // A�adir servicios al contenedor.
                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                //Limpieza de proveedores y contrucci�n del Host para utilizaci�n de NLog
                builder.Logging.ClearProviders();
                // NLog: Configurar NLog para inyecci�n de dependencias
                builder.Host.UseNLog();

                var app = builder.Build();

                // Configurar el canal de peticiones HTTP.
                if (app.Environment.IsProduction())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception exception)
            {
                // NLog: detectar errores de configuraci�n
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Aseg�rese de vaciar y detener los temporizadores/hilos internos antes de salir de la aplicaci�n (Evite el fallo de segmentaci�n en Linux)
                NLog.LogManager.Shutdown();
            }
        }
    }
}
