using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Linux_Shell
{
    public class LS
    {
        public void writeFiles(string path, string? attribut)
        {
            try
            {
                //nactu si cesty k souborům a slozkám
                string[] soubory = Directory.GetFiles(path);
                string[] slozky = Directory.GetDirectories(path);

                //nactu si to bez cesty
                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] fileInfo = d.GetFiles();
                DirectoryInfo[] dir = d.GetDirectories();

                //owner
                string usr = d.GetAccessControl().GetOwner(typeof(System.Security.Principal.SecurityIdentifier))?.Translate(typeof(System.Security.Principal.NTAccount)).ToString();

                if (attribut == null)
                {
                    foreach (var item in fileInfo)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else if (attribut == "-l" || attribut == "-a")
                {
                    if(attribut == "-a")
                    {
                        DirectoryInfo par = d.Parent;
                        usr = par.GetAccessControl().GetOwner(typeof(System.Security.Principal.SecurityIdentifier))?.Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                        Console.WriteLine($"d--x {usr} - {par.CreationTime} .");
                        par = d.Parent.Parent;
                        usr = par.GetAccessControl().GetOwner(typeof(System.Security.Principal.SecurityIdentifier))?.Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                        Console.WriteLine($"d--x {usr} - {par.CreationTime} ..");
                    }

                    for (int i = 0; i < fileInfo.Length; i++)
                    {
                        usr = fileInfo[i].GetAccessControl().GetOwner(typeof(System.Security.Principal.SecurityIdentifier))?.Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                        Console.Write("-");
                        if (tryRead(soubory[i]))
                        {
                            Console.Write("r");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                        if (tryWrite(soubory[i]))
                        {
                            Console.Write("w");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                        Console.Write("x");

                        Console.WriteLine($" {usr} {fileInfo[i].Length} {fileInfo[i].CreationTime} {fileInfo[i].Name}");
                    }
                    for (int i = 0; i < dir.Length; i++)
                    {
                        usr = dir[i].GetAccessControl().GetOwner(typeof(System.Security.Principal.SecurityIdentifier))?.Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                        Console.Write("d");
                        if (tryRead(slozky[i]))
                        {
                            Console.Write("r");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                        if (tryWrite(slozky[i]))
                        {
                            Console.Write("w");
                        }
                        else
                        {
                            Console.Write("-");
                        }
                        Console.Write("x");

                        Console.WriteLine($" {usr} - {dir[i].CreationTime} {dir[i].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong attribut.");
                }
            }
            catch { }
            


            //try
            //{
            //    DirectoryInfo d = new DirectoryInfo(path);
            //    FileInfo[] fileInfo = d.GetFiles();
            //    DirectoryInfo[] dir = d.GetDirectories();
            //    FileAttributes attributes = File.GetAttributes(path);
            //    FileInfo Info = new FileInfo(path);
            //    string usr = Info.GetAccessControl().GetOwner(typeof(System.Security.Principal.SecurityIdentifier))?.Translate(typeof(System.Security.Principal.NTAccount)).ToString();

            //    //for (int i = 0; i < fileInfo.Length; i++)
            //    //{
            //    //    Console.WriteLine(fileInfo[i]);
            //    //}
            //    //Console.WriteLine();
            //    //for (int i = 0; i < dir.Length; i++)
            //    //{
            //    //    Console.WriteLine(dir[i]);
            //    //}
            //    //Console.WriteLine();
            //    //Console.WriteLine(Info);
            //    //Console.WriteLine(attributes);

            //    Console.WriteLine();
            //    if (attribut == null)
            //    {
            //        foreach (var item in fileInfo)
            //        {
            //            Console.WriteLine(item.Name);
            //        }
            //    }
            //    else if (attribut == "-l" || attribut == "-a")
            //    {

            //        if (attribut == "-a")
            //        {
            //            Console.WriteLine($"{attributes} {fileInfo[0].Directory.CreationTime} .");
            //            Console.WriteLine(d.Parent.Parent.GetDirectories());
            //        }
            //        for (int i = 0; i < fileInfo.Length; i++)
            //        {
            //            Console.Write("-");
            //            Console.WriteLine($"{usr} {fileInfo[i].Length} {fileInfo[i].CreationTime} {fileInfo[i].Name}");
            //        }
            //        for (int i = 0; i < dir.Length; i++)
            //        {
            //            Console.Write("d")
            //            Console.WriteLine($"{usr} {dir[i].Lenght}");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Wrong attribut.");
            //    }
            //}
            //catch { }

        }
        
        public bool tryRead(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                sr.Close();
            }
            catch
            {
                return false;
            }          
            return true;
        }

        public bool tryWrite(string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
