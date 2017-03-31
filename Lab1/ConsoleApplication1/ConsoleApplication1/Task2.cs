using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class ReceiverComponent
    {
        protected string name;
        public ReceiverComponent(string name)
        {
            this.name = name;
        }
        public abstract void Add(ReceiverComponent c);
        public abstract void Remove(ReceiverComponent c);
        public abstract void Send(Letter letter);
        public abstract void Display(int depth);
    }

 
class Company : ReceiverComponent
    {
        private string address;
        private List<ReceiverComponent> _children = new List<ReceiverComponent>();
        public Company(string name, string address) : base(name)
        {
            this.address = address;
        }
        public Company(string name) : base(name)
        {
            this.address = "";
        }
        public override void Add(ReceiverComponent c)
        {

            _children.Add(c);
            
        }
        public override void Remove(ReceiverComponent c)
        {

            _children.Remove(c);
            
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + "Company " + name + ", " + address);
            foreach (ReceiverComponent component in _children)
                component.Display(depth + 2);
        }
        public override void Send(Letter letter)
        {
            //Console.WriteLine(name + " Company, " + address + ", got letter from " + letter.responser_name + " with text:\n" + letter.text);
            foreach (ReceiverComponent component in _children)
                component.Send(letter);
        }

    }
    class Receiver : ReceiverComponent
    {
        private string address;
        public Receiver(string name, string address) : base(name)
        {
            this.address = address;
        }
        public override void Add(ReceiverComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Remove(ReceiverComponent c)
        {
            Console.WriteLine("Impossible operation");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name + ", " + address);
        }
        public override void Send(Letter letter)
        {
            Console.WriteLine(name + ", " + address + ", got letter from " + letter.responser_name + " with text:\n" + letter.text);
        }
    }





    public class Letter
    {
        public string text;
        public string responser_name;
        public Letter(string text, string responser_name)
        {
            this.text = text;
            this.responser_name = responser_name;
        }
    }
}
