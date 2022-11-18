using System.IO;

namespace FileManager.Service
{
    interface IScanerManager
    {
        void WriteAllData(DirectoryInfo directoryInfo);
        void WriteDataFiles(DirectoryInfo directoryInfo, string type);
    }
}
