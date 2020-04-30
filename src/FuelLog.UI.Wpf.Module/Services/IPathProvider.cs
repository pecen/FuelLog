using System.IO;

namespace FuelLog.UI.Wpf.Module.Services {
  public interface IPathProvider {
    Stream FilePathService(string initialDirectory = "");
    void FolderPathService(string initialDirectory = "");
    void DbPathService();
  }
}
