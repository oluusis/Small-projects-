using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    public class CD
    {
        public string addPath(string pathNow, string addPath)
        {
            try
            {
                addPath = addPath.Replace('/', '\\');
                if (addPath == "..")
                {
                    if(pathNow.Length <= 3) 
                    {
                        Console.WriteLine("Wrong path :(\n");
                        return pathNow;
                    }
                    return DeletePath(ref pathNow);
                }
                string path = Path.Combine(pathNow, addPath)/*.Replace("\\\\", "\\")*/;
                if (Directory.Exists(path))
                {
                    return path;
                }

                if (addPath[0] == '\\')
                {
                    addPath = addPath.Remove(0, 1).Insert(1, ":");
                    if (Directory.Exists(addPath) && !File.Exists(addPath))
                    {
                        return addPath;
                    }
                }
            }
            catch { }
            Console.WriteLine("Wrong path :(\n");
            return pathNow;
        }

        public string addFile(string pathNow, string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            string path = Path.Combine(pathNow, fileName);
            if (File.Exists(path))
            {
                return path;
            }
            if (fileName[0] == '\\' && fileName[2] == '\\')
            {
                fileName = fileName.Remove(0, 1).Insert(1, ":");
                if (File.Exists(fileName))
                {
                    return fileName;
                }
            }
            Console.WriteLine("Wrong file name or wrong path to file :(\n");
            return pathNow;
        }

        public string DeletePath(ref string pathNow)
        {
            return pathNow.Substring(0, pathNow.LastIndexOf('\\'));
        }
    }
}
