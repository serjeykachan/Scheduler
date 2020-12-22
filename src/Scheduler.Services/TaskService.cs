using Scheduler.Data;
using Scheduler.Repository.Enums;
using Scheduler.Repository.Interfaces;
using Scheduler.Services.Enums;
using System;
using System.Collections.Generic;

namespace Scheduler.Services
{
  public class TaskService : ITaskService
  {
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
      _taskRepository = taskRepository;
    }

    public Task Get(int id)
    {
      return _taskRepository.Get(id);
    }

    public ICollection<Task> GetAll()
    {
      return _taskRepository.GetAll();
    }

    public void Add(TaskDto newTaskDto)
    {
      var random = new Random();

      Task task = new Task()
      {
        Id = random.Next(0, 10000),
        Title = newTaskDto.Title,
        Priority = newTaskDto.Priority,
        CreateDateTime = DateTime.Now,
        UpdateDateTime = DateTime.Now,
      };

      _taskRepository.Create(task);
    }

    public EDeleteResult Delete(int id)
    {
      Task task = _taskRepository.Get(id);
      if (task == null)
      {
        return EDeleteResult.NotFoundId;
      }

      _taskRepository.Delete(task);
      return EDeleteResult.Ok;
    }

    EEditResult ITaskService.Edit(TaskDto taskDto)
    {
      Task task = _taskRepository.Get(taskDto.Id);
      if (task == null)
      {
        return EEditResult.NotFoundId;
      }

      task.Title = taskDto.Title;
      task.Priority = taskDto.Priority;
      task.UpdateDateTime = DateTime.Now;

      _taskRepository.Edit(task);
      return EEditResult.Ok;
    }

    public void Sort(ESortCommandType sortType)
    {
      _taskRepository.Sort(sortType);
    }
  }
}
