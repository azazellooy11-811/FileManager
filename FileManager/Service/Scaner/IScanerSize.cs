using System.Collections.Generic;
using System.IO;

namespace FileManager.Service.Scaner
{
    interface IScanerSize
    {
        Dictionary<string, long> GetAvgSizeFiles(DirectoryInfo directoryInfo);
    }
}