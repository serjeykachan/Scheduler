using Scheduler.Application.Enums;

namespace Scheduler.Service.Extensions
{
  public static class EConsoleCommandTypeExtensions
  {
    public static string GetDescription(this EConsoleCommandType command)
    {
      return command switch
      {
        EConsoleCommandType.Help => "help - возвращает список команд",
        EConsoleCommandType.List => "list - возвращает весь список задач",
        EConsoleCommandType.Get => "get {id} - возвращает задачу по идентификатору",
        EConsoleCommandType.Add => "add {title} {priority (normal/middle/high)} - добавляет новую задачу",
        EConsoleCommandType.Edit => "edit {id} {title} {priority (normal/middle/high)} - редактирует задачу по идентификатору",
        EConsoleCommandType.Delete => "delete {id} - удаляет задачу по идентификатору",
        EConsoleCommandType.Sort => "sort {id/title/priority} - сортирует список задач по идентификатору/заголовку/приоритету",
        EConsoleCommandType.Quit => "quit - выход из приложения",
        _ => string.Empty,
      };
    }
  }
}
