using apiwise.Data;
using apiwise.Interface;
using apiwise.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

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
            // Iniciar la tarea programada cuando la aplicación se inicie
            _timer = new Timer(callback: DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }
        private async void DoWork(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            var _ctxProcedure = scope.ServiceProvider.GetRequiredService<DataContextProcedures>();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerWise>();
            await _ctxProcedure.Database.EnsureCreatedAsync();
            try
            {
                DateTime now = DateTime.Now;
                string formattedDate = now.ToString("yyyy-MM-dd");
                logger.LogHosted($"HOSTED INICIADO EJECUTAR:{now}");
                // Verificar si estamos dentro del rango de 5 minutos específico
                formattedDate = "2023-05-25";
                var parameter2 = DateTime.Now;   // Ejemplo de valor para el segundo parámetro
                List<Itemsfvfranquiciadosamatriz> ItemsFv = await _ctxProcedure.Itemsfvfranquiciadosamatrizs.FromSqlRaw($"CALL GenerarReporteItemsFacturadasFranquiciasParaMatriz('{formattedDate}')").ToListAsync();
                logger.LogHosted($"HOSTED FINALIZA EJECUTAR:{JsonConvert.SerializeObject(ItemsFv)}");
            }
            catch (Exception ex)
            {
                string mensaje = $"{ex.Message}:{(ex.InnerException != null ? ex.InnerException.Message : "")}";
                logger.LogError($"ERROR:HOSTED:{mensaje}");

            }

        }
        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        /// <summary>
        /// </summary>
        public void Dispose() => _timer?.Dispose();
    }
}
