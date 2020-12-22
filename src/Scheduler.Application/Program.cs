using Microsoft.Extensions.DependencyInjection;
using Scheduler.Repository;
using Scheduler.Repository.Interfaces;
using Scheduler.Services;

namespace Scheduler.Application
{
  class Program
  {
    static void Main(string[] args)
    {
      ServiceProvider serviceProvider = new ServiceCollection()
          .AddTransient<ITaskService, TaskService>()
          .AddTransient<ITaskRepository, TaskJsonRepository>()
          .BuildServiceProvider();

      var service = serviceProvider.GetService<ITaskService>();

      new ConsoleAppUI(service).Start();
    }
  }
}
