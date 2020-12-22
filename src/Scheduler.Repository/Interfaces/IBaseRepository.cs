using Scheduler.Data.Entities;
using System.Collections.Generic;

namespace Scheduler.Repository.Interfaces
{
  public interface IBaseRepository<TEntity, TId> where TEntity : BaseEntity<TId>
  {
    /// <summary>
    /// Получить список всех сущностей
    /// </summary>
    /// <returns>список</returns>
    IList<TEntity> GetAll();

    /// <summary>
    /// Получить сущность
    /// </summary>
    /// <param name="id">ID сущности</param>
    /// <returns></returns>
    TEntity Get(TId id);

    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="item">Сущность</param>
    /// <returns></returns>
    void Create(TEntity item);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    /// <param name="id">ID сущности</param>
    void Delete(TId id);

    /// <summary>
    /// Удаление сущности
    /// </summary>
    /// <param name="item">Сущность</param>
    void Delete(TEntity item);

    /// <summary>
    /// Редактирование сущности
    /// </summary>
    /// <param name="item">Сущность</param>
    void Edit(TEntity item);
  }
}
