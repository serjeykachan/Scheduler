using Scheduler.Data.Entities;
using System.Collections.Generic;

namespace Scheduler.DataAccess.Interfaces
{
  public interface IBaseDataAccess<TEntity, TId> where TEntity : BaseEntity<TId>
  {
    /// <summary>
    /// Загрузка данных
    /// </summary>
    /// <returns>список сущностей</returns>
    IList<TEntity> Load();

    /// <summary>
    /// Сохранение данных
    /// </summary>
    /// <param name="dataList">список сущностей</param>
    void Save(IList<TEntity> dataList);
  }
}
