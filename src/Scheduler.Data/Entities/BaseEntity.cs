namespace Scheduler.Data.Entities
{
  public abstract class BaseEntity<T>
  {
    /// <summary>
    /// Идентификатор
    /// </summary>
    public T Id { get; set; }
  }
}
