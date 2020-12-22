using Newtonsoft.Json;
using Scheduler.Data;
using Scheduler.Repository.Enums;
using Scheduler.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Scheduler.Repository
{
  public class TaskJsonRepository : ITaskRepository
  {
    private const string TaskDataDirName = "..\\..\\..\\..\\..\\data";
    private const string TaskListName = "TaskList.json";

    private List<Task> dataList = new List<Task>();

    public TaskJsonRepository()
    {
      Load();
    }

    public IList<Task> GetAll()
    {
      return dataList;
    }

    public Task Get(int id)
    {
      return dataList.Find(x => x.Id == id);
    }

    public void Create(Task item)
    {
      if (item == null)
        return;

      dataList.Add(item);

      Save();
    }

    public void Edit(Task item)
    {
      if (item == null)
        return;

      Task editItem = Get(item.Id);

      if (editItem == null)
        return;

      Delete(editItem);
      Create(item);

      Save();
    }

    public void Delete(int id)
    {
      Task item = Get(id);

      if (item != null)
        dataList.Remove(item);

      Save();
    }

    public void Delete(Task item)
    {
      if (item == null)
        return;

      Delete(item.Id);

      Save();
    }

    public void Sort(ESortCommandType sortType)
    {
      switch (sortType)
      {
        case ESortCommandType.ById:
          SortDataList((data1, data2) => data1.Id.CompareTo(data2.Id));
          break;

        case ESortCommandType.ByTitle:
          SortDataList((data1, data2) => data1.Title.CompareTo(data2.Title));
          break;

        case ESortCommandType.ByPriority:
          SortDataList((data1, data2) => data1.Priority.CompareTo(data2.Priority));
          break;

        case ESortCommandType.None:
        default:
          //do nothing
          break;
      }
    }

    private void SortDataList(Comparison<Task> comparison)
    {
      dataList.Sort(comparison);

      Save();
    }

    #region load/save data
    private void Load()
    {
      string dirPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, TaskDataDirName));
      string path = Path.Combine(dirPath, TaskListName);

      if (File.Exists(path))
      {
        string dataAsJson = File.ReadAllText(path);

        if (!string.IsNullOrEmpty(dataAsJson))
        {
          dataList = JsonConvert.DeserializeObject<List<Task>>(dataAsJson);
        }
      }
    }

    private void Save()
    {
      string dirPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, TaskDataDirName));

      if (!Directory.Exists(dirPath))
      {
        Directory.CreateDirectory(dirPath);
      }

      string dataAsJson = JsonConvert.SerializeObject(dataList, Formatting.Indented);

      string path = Path.Combine(dirPath, TaskListName);
      File.WriteAllText(path, dataAsJson);
    }
    #endregion
  }
}
