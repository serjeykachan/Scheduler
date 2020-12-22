using Scheduler.Data.Enums;

namespace Scheduler.Data.Extensions
{
  public static class EDataPriorityExtensions
  {
    public static string ToString(this EDataPriority priority)
    {
      return priority switch
      {
        EDataPriority.Normal => "Normal",
        EDataPriority.Middle => "Middle",
        EDataPriority.High => "High",
        _ => string.Empty,
      };
    }
  }
}
