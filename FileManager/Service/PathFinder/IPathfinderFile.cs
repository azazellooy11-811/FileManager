using FileManager.Models;
using System.Collections.Generic;
using System.IO;

namespace FileManager.Service.Pathfinders
{
    interface IPathfinderFile
    {
        List<MyFile> GetMyFiles(DirectoryInfo directoryInfo);
    }
}