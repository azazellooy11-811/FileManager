using System.IO;

namespace FileManager.Service.Scaner
{
    interface IScanerTypeCount
    {
        (float, float) GetCountType(DirectoryInfo directoryInfo, string type);
    }
}

