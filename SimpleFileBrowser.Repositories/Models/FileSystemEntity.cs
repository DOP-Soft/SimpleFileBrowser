using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileManager.Repositories.Models
{
    public class FileSystemEntity
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsDirectory { get; set; }
    }
}
