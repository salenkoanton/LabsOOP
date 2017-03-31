using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Subscriber
    {
        private int imei;
        private string name;
        static Random rand = new Random();
        public Subscriber(string name)
        {
            this.name = name;
            imei = rand.Next();
        }

        public int IMEI {
            get { return imei; }
        }

        public string Name
        {
            get { return name; }
        }

        public bool Connect(Subscriber other)
        {
            //TODO really conection
            return true;
        }

    }

    public interface CallingSystem
    {
        void MakeCall(Subscriber caller, Subscriber receiver);
    }

    public class AuthenticationSystem 
        : CallingSystem
    {
        private List<int> allowedMobiles;
        private Operator op;
        
        public AuthenticationSystem(List<int> allowedMobiles, string operatorName)
        {
            this.allowedMobiles = allowedMobiles;
            op = new Operator(operatorName);
        }

        public void MakeCall(Subscriber caller, Subscriber receiver)
        {
            int founded = allowedMobiles.FindIndex(IMEI => IMEI == caller.IMEI);
            if (founded < 0)
            {
                Console.WriteLine("Non-allowed phone");
                //TODO send msg to police
                return;
            }
            op.MakeCall(caller, receiver);
        }
    }

    public class Operator 
        : CallingSystem
    {
        private string name;
        public Operator(string name)
        {
            this.name = name;
        }
        
        public void MakeCall(Subscriber caller, Subscriber receiver)
        {
            if (caller.Connect(receiver))
                Console.WriteLine("conected: " + caller.Name + "\t" + receiver.Name);
        }
    }
}
