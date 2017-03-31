using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            User user = new User("Tosha");
            user.Message(user.Language);
            user.SetLanguage(new EnLang());
            user.Message(user.Language);


            //Task2
            Company mail = new Company("");
            Company some_list = new Company("some list");
            mail.Add(some_list);
            Company comp = new Company("Google", "Paris");
            some_list.Add(comp);
            comp.Add(new Receiver("some popular proger", "Paris"));
            comp.Add(new Receiver("another popular proger", "Kiev"));
            some_list.Add(new Receiver("some guy", "Selo"));
            comp.Add(new Company("false test", "error"));
            mail.Display(0);
            mail.Send(new Letter("blablablablablablablablabla", "Me"));

            Console.ReadKey();
        }
    }
}
