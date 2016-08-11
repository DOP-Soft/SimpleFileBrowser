using SimpleFileManager.Repositories.Abstract;
using SimpleFileManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileManager.Repositories.Concrete
{
    public class DirectoriesRepository : BaseIOEntityRepository, IIOEntityRepository<DirectoryInfo>
    {
        public IEnumerable<DirectoryInfo> Get(string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DirectoryInfo> GetRootEntries()
        {
            throw new NotImplementedException();
        }
    }
}
