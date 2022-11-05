using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    public class Command
    {
        private string[] pole { get; set; }
        private string input { get; set; }
        private string path;

        private GREP grep = new GREP();
        private LESS less = new LESS();
        private CD cd = new CD();
        private PWD pwd = new PWD();
        private CAT cat = new CAT();
        private WC wc = new WC();
        private LS ls = new LS();


        public Command(string input)
        {
            this.path = input.Substring(3);
            newCommand(input);
        }

        public void newCommand(string input)
        {
            this.pole = input.Split(' ');
            this.input = input;
        }

        public void WritePath()
        {
            Console.Write($"{pwd.EditPath(this.path)}$ ");
        }
        public void FindCommand()
        {
            if (pole.Length > 1 || pole[0] == "cls" || pole[0] == "ls" || pole[0] == "pwd")
            {
                switch (pole[0])
                {
                    case "less":
                        less.Nacti(cd.addFile(this.path, input.Substring(5)));
                        break;
                    case "grep":
                        grep.Nacti(FindText(), cd.addFile(this.path, input.Substring(input.IndexOf('"', 6) + 2)));
                        break;
                    case "cd":
                        this.path = cd.addPath(this.path, input.Substring(3));
                        break;
                    case "pwd":
                        Console.WriteLine(pwd.EditPath(this.path));
                        break;
                    case "cat":
                        cat.WriteFile(cd.addFile(this.path, input.Substring(4)));
                        break;
                    case "wc":
                        string atribut = FindAttribut();
                        if (atribut == null)
                        {                           
                            wc.WriteCWL(cd.addFile(this.path, input.Substring(3)), null);
                        }
                        else
                        {
                            if (input.Length < 6)
                            {
                                Console.WriteLine("Enter the path.");
                            }
                            else
                            {
                                wc.WriteCWL(cd.addFile(this.path, input.Substring(6)), atribut);
                            }
                        }
                        break;
                    case "cls":
                        Console.Clear();
                        break;
                    case "ls":
                        atribut = FindAttribut();
                        if (atribut == null)
                        {
                            if(pole.Length > 1)
                            {
                                ls.writeFiles(cd.addPath(this.path, input.Substring(3)), null);
                            }
                            else
                            {
                                ls.writeFiles(this.path, null);
                            }
                            
                        }
                        else
                        {
                            if (input.Length < 6)
                            {
                                ls.writeFiles(this.path, atribut);
                            }
                            else
                            {
                                ls.writeFiles(cd.addPath(this.path, input.Substring(6)), atribut);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("I could't find command :(\n");
                        break;
                }
            
            }
        }

        private string? FindText()
        {
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i][0] == '"')
                {
                    return pole[i].Replace("\"", "");
                }
            }
            return null;
        }

        private string? FindAttribut()
        {
            foreach (var item in pole)
            {
                if (item[0] == '-')
                {
                    return item;
                }
            }
            return null;
        }
    }
}
