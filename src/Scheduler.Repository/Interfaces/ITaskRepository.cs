using Scheduler.Data;
using Scheduler.Repository.Enums;

namespace Scheduler.Repository.Interfaces
{
  public interface ITaskRepository : IBaseRepository<Task, int>
  {
    /// <summary>
    /// Сортировка сущностей
    /// </summary>
    /// <param name="sortType">Тип сортировки</param>
    void Sort(ESortCommandType sortType);
  }
}
