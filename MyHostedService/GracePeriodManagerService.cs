using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHostedService
{
    public class GracePeriodManagerService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"GracePeriodManagerService is starting.");

            stoppingToken.Register(() =>
                Console.WriteLine($" GracePeriod background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"GracePeriod task doing background work.");

                // This eShopOnContainers method is querying a database table
                // and publishing events into the Event Bus (RabbitMQ / ServiceBus)
                CheckConfirmedGracePeriodOrders();

                await Task.Delay(3000, stoppingToken);
            }

            Console.WriteLine($"GracePeriod background task is stopping.");
        }

        private void CheckConfirmedGracePeriodOrders()
        {
            Console.WriteLine("CheckConfirmedGracePeriodOrders completed.");
        }
    }
}
