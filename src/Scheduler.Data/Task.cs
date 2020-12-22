using Scheduler.Data.Entities;
using Scheduler.Data.Enums;
using System;

namespace Scheduler.Data
{
  public class Task : BaseIntEntity
  {
    /// <summary>
    /// Заголовок задания.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Приоритет задания.
    /// </summary>
    public EDataPriority Priority { get; set; }

    /// <summary>
    /// Дата и время создания задания
    /// </summary>
    public DateTime CreateDateTime { get; set; }

    /// <summary>
    /// Дата и время изменения задания
    /// </summary>
    public DateTime UpdateDateTime { get; set; }

    public override string ToString()
    {
      return $"Id: {Id}, Title: {Title}, Priority: {Priority}, Created: {CreateDateTime:dd.MM.yyyy HH:mm:ss}, Updated: {UpdateDateTime:dd.MM.yyyy HH:mm:ss}";
    }
  }
}
