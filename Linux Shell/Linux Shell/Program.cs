namespace Linux_Shell
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = @"cd C:\Users\"+Environment.UserName;
            Command command = new Command(input);

            //LS lS = new LS();
            //lS.writeFiles(@"C:\Users\hrubanoliver\Desktop\slozka", "-a");
            while (true)
            {
                command.FindCommand();
                command.WritePath();
                input = Console.ReadLine();
                command.newCommand(input);
            }
        }
    }
}