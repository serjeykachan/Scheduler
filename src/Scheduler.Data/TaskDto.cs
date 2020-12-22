using Scheduler.Data.Enums;

namespace Scheduler.Data
{
  public class TaskDto
  {
    /// <summary>
    /// ID задания.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Заголовок задания.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Приоритет.
    /// </summary>
    public EDataPriority Priority { get; set; }
  }
}
