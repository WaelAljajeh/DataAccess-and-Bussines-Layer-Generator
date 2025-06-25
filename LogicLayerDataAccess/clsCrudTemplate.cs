using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LogicLayerDataAccess
{
    public class clsCrudTemplate
    {
        private static readonly object _fileLock = new object();
        public static string LoadTemplate(string Path)
        {
           return File.ReadAllText(Path);
        }
        public static void SaveTemplate(string MethodsPath,string Content)
        { lock (_fileLock)
            {
                File.WriteAllText(MethodsPath, Content);
            }
        }

    }
}
