using FileManager.Service.Pathfinders;
using FileManager.Service.Scaner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Service.Scaner
{
    class ScanerTypeCount : IScanerTypeCount
    {
        private readonly IPathfinderFile pathfinder;
        public ScanerTypeCount(IPathfinderFile pathfinder)
        {
            this.pathfinder = pathfinder;
        }

        public (float, float) GetCountType(DirectoryInfo directoryInfo, string type)
        {
            var files = pathfinder.GetMyFiles(directoryInfo);
            float count = files.Count();
            float typeCount = files.Where(x => x.Type == type).Count();

            return (typeCount, (count / 100) * typeCount * 100);
        }
    }
}


