using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            Subscriber s1 = new Subscriber("Sanyok");
            Subscriber s2 = new Subscriber("Tosha");
            Subscriber s3 = new Subscriber("Vlad");
            Subscriber s4 = new Subscriber("Masha");
            List <int> IMEIs = new List<int> { s1.IMEI, s2.IMEI, s3.IMEI };
            CallingSystem auth = new AuthenticationSystem(IMEIs, "Life");
            auth.MakeCall(s1, s2);
            auth.MakeCall(s4, s2);


            // Task 2
            EnSystem system = new EnSystem();
            Adapter adapter = new Adapter();
            adapter.SetSystem(system);
            while (true)
            {
                Console.WriteLine();
                string command = Console.ReadLine();
                adapter.Execute(command);
                
            }

            Console.ReadKey();
        }

    }
}
