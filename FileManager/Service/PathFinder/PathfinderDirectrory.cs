using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Service.Pathfinders
{
    class PathfinderDirectrory : IPathfinderDirectrory
    {
        private List<MyDirectory> _directories = new List<MyDirectory>();
        private readonly IPathfinderFile pathfinderFile;
        public PathfinderDirectrory(IPathfinderFile pathfinderFile)
        {
            this.pathfinderFile = pathfinderFile;
        }

        public ICollection<MyDirectory> GetMyDirectories(DirectoryInfo directoryInfo)
        {
            SearchDirectory(directoryInfo);
            return _directories;
        }

        private void SearchDirectory(DirectoryInfo directoryInfo)
        {
            if (!directoryInfo.Exists)
                return;

            long size = pathfinderFile.GetMyFiles(directoryInfo).Sum(x => x.Size);

            _directories.Add(new MyDirectory() { Name = directoryInfo.Name, Size = size });

            if (directoryInfo.GetDirectories() is null)
                return;

            foreach (var d in directoryInfo.GetDirectories())
            {
                SearchDirectory(d);
            }
        }
    }
}
