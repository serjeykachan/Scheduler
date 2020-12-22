using System;
using Scheduler.Application.Enums;
using Scheduler.Data;
using Scheduler.Data.Enums;
using Scheduler.Repository.Enums;
using Scheduler.Service.Extensions;
using Scheduler.Services;
using Scheduler.Services.Enums;

namespace Scheduler.Application
{
  class ConsoleAppUI
  {
    private readonly ITaskService _service;

    public ConsoleAppUI(ITaskService service)
    {
      _service = service;
    }

    public void Start()
    {
      Console.WriteLine("Планировщик.");

      EConsoleCommandType command = EConsoleCommandType.None;

      string commandLine;
      do
      {
        Console.Write("Command: ");

        commandLine = Console.ReadLine();

        if (string.IsNullOrEmpty(commandLine))
        {
          continue;
        }

        var commandParams = commandLine.Split(" ");

        command = GetCommandByString(commandParams[0]);

        switch (command)
        {
          case EConsoleCommandType.Help when commandParams.Length == 1:
            foreach (EConsoleCommandType commandType in Enum.GetValues(typeof(EConsoleCommandType)))
            {
              if (commandType == EConsoleCommandType.None)
                continue;

              Console.WriteLine(commandType.GetDescription());
            }

            break;

          case EConsoleCommandType.List when commandParams.Length == 1:
            var taskList = _service.GetAll();
            if (taskList.Count != 0)
            {
              foreach (var task in taskList)
              {
                Console.WriteLine(task.ToString());
              }
            }
            else
            {
              Console.WriteLine("Список задач пуст.");
            }

            break;

          case EConsoleCommandType.Get when commandParams.Length == 2:
            if (int.TryParse(commandParams[1], out int getTaskId))
            {
              Task task = _service.Get(getTaskId);
              if (task != null)
              {
                Console.WriteLine(task.ToString());
              }
              else
              {
                Console.WriteLine("Задача по данному ID отсутствует.");
              }
            }
            else
            {
              Console.WriteLine("Невозможно вернуть задачу. Неверно введёт ID задачи.");
            }

            break;

          case EConsoleCommandType.Add when commandParams.Length == 3:
            EDataPriority addTaskPriority = GetTaskPriorityByString(commandParams[2]);
            if (addTaskPriority != EDataPriority.None)
            {
              var taskDto = new TaskDto
              {
                Title = commandParams[1],
                Priority = addTaskPriority
              };

              _service.Add(taskDto);

              Console.WriteLine("Задание успешно добавлено.");
            }
            else
            {
              Console.WriteLine("Приоритет задания введён неверно. Введите help для справки.");
            }

            break;

          case EConsoleCommandType.Edit when commandParams.Length == 4:
            if (int.TryParse(commandParams[1], out int editTaskId))
            {
              EDataPriority editTaskPriority = GetTaskPriorityByString(commandParams[3]);
              if (editTaskPriority != EDataPriority.None)
              {
                var taskDto = new TaskDto
                {
                  Id = editTaskId,
                  Title = commandParams[2],
                  Priority = editTaskPriority
                };

                switch (_service.Edit(taskDto))
                {
                  case EEditResult.Ok:
                    Console.WriteLine("Задание успешно редактировано.");
                    break;

                  case EEditResult.NotFoundId:
                    Console.WriteLine("Ошибка при редактировании задачи. Не известный ID задачи.");
                    break;

                  default:
                    Console.WriteLine("Ошибка при редактировании задачи. Не известная причина.");
                    break;
                }
              }
              else
              {
                Console.WriteLine("Приоритет задания введён неверно. Введите help для справки.");
              }
            }
            else
            {
              Console.WriteLine("Ошибка при редактировании задачи. Неверно введёт ID задачи.");
            }
            break;

          case EConsoleCommandType.Delete when commandParams.Length == 2:
            if (int.TryParse(commandParams[1], out int deleteTaskId))
            {
              switch (_service.Delete(deleteTaskId))
              {
                case EDeleteResult.Ok:
                  Console.WriteLine("Задача успешно удалена");
                  break;
                case EDeleteResult.NotFoundId:
                  Console.WriteLine("Ошибка при удалении задачи. Не известный ID задачи.");
                  break;

                default:
                  Console.WriteLine("Ошибка при удалении задачи. Не известная причина.");
                  break;
              }
            }
            else
            {
              Console.WriteLine("Ошибка при удалении задачи. Неверно введёт ID задачи.");
            }

            break;

          case EConsoleCommandType.Sort when commandParams.Length == 2:
            ESortCommandType sortCommand = GetSortCommandByString(commandParams[1]);
            if (sortCommand != ESortCommandType.None)
            {
              _service.Sort(sortCommand);
              Console.WriteLine("Задачи успешно отсортированы.");
            }
            else
            {
              Console.WriteLine("Ошибка при вводе команды сортировки. Введите help для справки.");
            }

            break;

          case EConsoleCommandType.Quit:
            break;

          case EConsoleCommandType.None:
          default:
            Console.WriteLine("Ошибка при вводе команды. Введите help для справки.");
            break;
        }
      }
      while (command != EConsoleCommandType.Quit);
    }

    private EConsoleCommandType GetCommandByString(string commandString)
    {
      return commandString switch
      {
        "help" => EConsoleCommandType.Help,
        "list" => EConsoleCommandType.List,
        "get" => EConsoleCommandType.Get,
        "add" => EConsoleCommandType.Add,
        "edit" => EConsoleCommandType.Edit,
        "delete" => EConsoleCommandType.Delete,
        "sort" => EConsoleCommandType.Sort,
        "quit" => EConsoleCommandType.Quit,
        _ => EConsoleCommandType.None,
      };
    }

    private ESortCommandType GetSortCommandByString(string commandString)
    {
      return commandString switch
      {
        "id" => ESortCommandType.ById,
        "title" => ESortCommandType.ByTitle,
        "priority" => ESortCommandType.ByPriority,
        _ => ESortCommandType.None,
      };
    }

    private EDataPriority GetTaskPriorityByString(string priorityString)
    {
      return priorityString switch
      {
        "normal" => EDataPriority.Normal,
        "middle" => EDataPriority.Middle,
        "high" => EDataPriority.High,
        _ => EDataPriority.None,
      };
    }
  }
}
