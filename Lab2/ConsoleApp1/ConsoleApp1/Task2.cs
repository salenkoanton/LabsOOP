using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //adaptee
    class EnSystem
    {
        bool isStarted = false;
        bool isPaused = false;
        public EnSystem()
        {

        }

        public bool Run()
        {
            Console.WriteLine("Run");
            if (!isStarted)
            {
                isStarted = true;
                return true;
            }
            return false;
            
        }

        public bool Stop()
        {
            if (isStarted)
            {
                Console.WriteLine("Stop");
                isStarted = false;
                return true;
            }
            return false;
        }

        public bool Pause()
        {
            if (isPaused) Console.WriteLine("Continue");
            else Console.WriteLine("Pause");
            return true;
        }

        public bool Execute(string command)
        {
            switch (command)
            {
                case "run": return Run();
                case "stop": return Stop();
                case "pause": return Pause();
                default: Console.WriteLine("Wrong command"); return false;
                
            }
            
        }
    }

    //target
    public class УкраїнськийІнтерфейс
    {

        public УкраїнськийІнтерфейс()
        {

        }

        public virtual bool Запустити(bool результат)
        {
            if (результат)
                Console.WriteLine("Запущено");
            else Console.WriteLine("Щось пішло не так..");
            return результат;
        }

        public bool Зупинити(bool результат)
        {
            if (результат)
                Console.WriteLine("Зупинено");
            else Console.WriteLine("Щось пішло не так..");
            return результат;
        }

        public bool Пауза(bool результат)
        {
            if (результат)
                Console.WriteLine("Пауза");
            else Console.WriteLine("Щось пішло не так..");
            return результат;
        }

        public virtual bool Execute(string command) {
            switch (command)
            {
                case "старт": return Зупинити(false);
                case "стоп": return Запустити(false);
                case "пауза": return Пауза(false);
                default: Console.WriteLine("Неправильна команда"); return false;
            }
        }
    }

    //adapter
    class Adapter 
        : УкраїнськийІнтерфейс
    {
        private EnSystem system;
        public Adapter() : base() { }

        public void SetSystem(EnSystem system)
        {
            this.system = system;
        }

        public override bool Execute(string command)
        {
            switch (command)
            {
                case "старт": return Запустити(system.Run());
                case "стоп": return Зупинити(system.Stop());
                case "пауза": return Пауза(system.Pause());
                default: Console.WriteLine("Неправильна команда"); return false;
            }
        }
    }
}

