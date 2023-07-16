//using Data;
//using Microsoft.EntityFrameworkCore;

//namespace apiwise.HostedService
//{
//    /// <summary>
//    /// </summary>
//    public class MyHostedService : IHostedService, IDisposable
//    {
//        private Timer _timer;
//        readonly DataContext _datacontext;
//        private readonly IServiceProvider _serviceProvider;
//        /// <summary>
//        /// </summary>
//        /// <param name="logger"></param>
//        public MyHostedService(DataContext dataContext, IServiceProvider serviceProvider)
//        {
//            _datacontext = dataContext;
//            _serviceProvider = serviceProvider;
//        }
//        /// <summary>
//        /// </summary>
//        /// <param name="cancellationToken"></param>
//        /// <returns></returns>
//        public async Task StartAsync(CancellationToken cancellationToken)
//        {

//            using (var scope = _serviceProvider.CreateScope())
//            {
//                var scopedServices = scope.ServiceProvider;

//                // Resuelve los servicios de ámbito dentro del ámbito creado
//                // var myScopedService = scopedServices.GetRequiredService<IMyScopedService>();

//                // Realiza las operaciones necesarias utilizando los servicios de ámbito
//                _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
//                await Task.CompletedTask;
//            }
//            //_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
//            // return Task.CompletedTask;
//        }

//        private async void DoWork(object state)
//        {
//            var esultado = await _datacontext.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO pruebaserviciobacgrao VALUES('{Guid.NewGuid()}',NOW());");
//            // _logger.LogInformation("Doing some work...");
//        }
//        /// <summary>
//        /// </summary>
//        /// <param name="cancellationToken"></param>
//        /// <returns></returns>
//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            _timer?.Change(Timeout.Infinite, 0);
//            return Task.CompletedTask;
//        }
//        /// <summary>
//        /// </summary>
//        public void Dispose()
//        {
//            _timer?.Dispose();
//        }
//    }
//}
