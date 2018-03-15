using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrapper
{
    class MyApplication
    {
        public MyApplication()
        {
            ConsoleKeyInfo key;
            Wrapper wr = new Wrapper();
            String name = "", num = "", rank = "";
            int choice = 0;

            do
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Add the staff object info list");
                Console.WriteLine("2 - Load list from file");
                Console.WriteLine("3 - Save list to file");
                Console.WriteLine("4 - Replace the entered element");
                Console.WriteLine("5 - Remove the frist elemet");
                Console.WriteLine("6 - Get value of first element");
                Console.WriteLine("7 - Print the list");

                key = Console.ReadKey();
                
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Input name: "); name = Console.ReadLine();
                        Console.Write("Input shop number: "); num = Console.ReadLine();
                        Console.Write("Input rank: "); rank = Console.ReadLine();
                        wr.Insert(new Staff(name, Convert.ToUInt32(num), Convert.ToByte(rank)));
                        break;
                    case ConsoleKey.D2:
                        wr.LoadFromFile("d:\\Info.txt");
                        break;
                    case ConsoleKey.D3:
                        wr.SaveToFile("d:\\Info.txt");
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.Write("Input the index of replacement element: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Input name: "); name = Console.ReadLine();
                        Console.Write("Input shop number: "); num = Console.ReadLine();
                        Console.Write("Input rank: "); rank = Console.ReadLine();
                        wr.Change(wr.getFromIndex(choice), new Staff(name, Convert.ToUInt32(num), Convert.ToByte(rank)));
                        break;
                    case ConsoleKey.D5:
                        wr.Remove();
                        break;
                    case ConsoleKey.D6:
                        Staff p = wr.GetValue();
                        Console.WriteLine($"name: { p.Name }");
                        Console.WriteLine($"shop sumber: { p.Num }");
                        Console.WriteLine($"rank: { p.Rank }");
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        wr.Print();
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            } while (key.KeyChar != '0');
        }
    }
}
