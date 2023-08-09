using apiwise.Data;
using apiwise.Interface;
using Microsoft.EntityFrameworkCore;

namespace apiwise.HostedService
{
    /// <summary>
    /// </summary>
    public class MyHostedService : IHostedService, IDisposable
    {
        private Timer _timer;


        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        public MyHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Calcula el tiempo hasta la próxima ejecución dentro del rango horario
            DateTime now = DateTime.Now;
            //_logger.LogHosted($"HOSTED START:{now}");
            // Iniciar la tarea programada cuando la aplicación se inicie
            _timer = new Timer(callback: DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        private async void DoWork(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContextProcedures>();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerWise>();
            await dbContext.Database.EnsureCreatedAsync();
            var currentTime = DateTime.Now.TimeOfDay;
            logger.LogHosted($"HOSTED INICIADO EJECUTAR:{currentTime}");
            // Verificar si estamos dentro del rango de 5 minutos específico
           // if (currentTime >= TimeSpan.FromMinutes(30) && currentTime < TimeSpan.FromMinutes(32))
           // {
                // Coloca aquí la lógica de la tarea que deseas ejecutar
                var parameter1 = Guid.NewGuid(); // Ejemplo de valor para el primer parámetro
                var parameter2 = DateTime.Now;   // Ejemplo de valor para el segundo parámetro
                var esultado = await dbContext.Database.ExecuteSqlRawAsync("CALL GRabarPruebaserviciobacgrao({0}, {1})", parameter1, parameter2);
                logger.LogHosted($"HOSTED FINALIZA EJECUTAR:{esultado}");
           // }
        }
        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            //   _logger.LogHosted($"HOSTED STOP");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        /// <summary>
        /// </summary>
        public void Dispose() => _timer?.Dispose();
    }
}
