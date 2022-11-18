using FileManager.Models;
using System.Collections.Generic;
using System.IO;

namespace FileManager.Service.Pathfinders
{
    interface IPathfinderDirectrory
    {
        ICollection<MyDirectory> GetMyDirectories(DirectoryInfo directoryInfo);
    }
}