using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    public class PWD
    {
        public string EditPath(string path)
        {
            return "/" + path.Replace('\\', '/').Replace(":", "");
        }
    }
}
