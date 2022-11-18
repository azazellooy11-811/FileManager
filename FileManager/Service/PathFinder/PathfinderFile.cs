using FileManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Service.Pathfinders
{
    class PathfinderFile : IPathfinderFile
    {
        private List<MyFile> _files;

        public List<MyFile> GetMyFiles(DirectoryInfo directoryInfo)
        {
            _files = new List<MyFile>();
            SearchFiles(directoryInfo);
            return _files;
        }

        private void SearchFiles(DirectoryInfo directoryInfo)
        {
            if (!directoryInfo.Exists)
                return;

            var list = directoryInfo.GetFiles().Select(x => new MyFile()
            {
                Name = x.Name,
                Size = x.Length,
                Type = x.Extension
            });

            _files = _files.Union(list).ToList();

            if (directoryInfo.GetDirectories() is null)
                return;

            foreach (var d in directoryInfo.GetDirectories())
            {
                SearchFiles(d);
            }
        }
    }
}
