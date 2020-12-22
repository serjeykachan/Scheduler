using Scheduler.Data;
using Scheduler.Repository.Enums;
using Scheduler.Services.Enums;
using System.Collections.Generic;

namespace Scheduler.Services
{
  public interface ITaskService
  {
    /// <summary>
    /// Возвращает весь список задач
    /// </summary>
    /// <returns></returns>
    ICollection<Task> GetAll();

    /// <summary>
    /// Возвращает задачу по ID
    /// </summary>
    /// <param name="id">ID задачи</param>
    /// <returns></returns>
    Task Get(int id);

    /// <summary>
    /// Добавление нового задания
    /// </summary>
    /// <param name="newTaskDto">Шаблон задания</param>
    void Add(TaskDto newTaskDto);

    /// <summary>
    /// Удаление задачи
    /// </summary>
    /// <param name="id">ID задачи</param>
    /// <returns>Результат операции удаления</returns>
    EDeleteResult Delete(int id);

    /// <summary>
    /// Редактирование задачи
    /// </summary>
    /// <param name="taskDto">Шаблон задания</param>
    /// <returns>Результат операции редактирования</returns>
    EEditResult Edit(TaskDto taskDto);

    /// <summary>
    /// Сортировка задач
    /// </summary>
    /// <param name="sortType">Тип сортировки</param>
    void Sort(ESortCommandType sortType);
  }
}