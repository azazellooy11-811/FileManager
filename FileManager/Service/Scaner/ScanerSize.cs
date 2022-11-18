
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Service.Pathfinders;

namespace FileManager.Service.Scaner
{
    class ScanerSize : IScanerSize
    {
        private readonly IPathfinderFile pathfinderFile;
        private Dictionary<string, long> _files = new Dictionary<string, long>();

        public ScanerSize(IPathfinderFile pathfinderFile)
        {
            this.pathfinderFile = pathfinderFile;
        }

        public Dictionary<string, long> GetAvgSizeFiles(DirectoryInfo directoryInfo)
        {
            var group = pathfinderFile.GetMyFiles(directoryInfo).GroupBy(g => g.Type)
              .Select(g => new
              {
                  Type = g.Key,
                  AvgSize = (g.Select(x => x.Size).Sum()) / g.Count()
              });

            foreach (var files in group)
            {
                _files.Add(files.Type, files.AvgSize);
            }

            return _files;
        }
    }
}
