using System;

namespace Data.Models
{
    public class Trainer
    {
        private Monkey _monkey;

        public Trainer()
        {
            Console.WriteLine("Trainer created.");

            _monkey = new Monkey();
            Console.WriteLine("Monkey created.");
        }

        public Monkey ShowMonkey()
        {
            return _monkey;
        }

        public void MakeMonkeyDoTricks()
        {
            _monkey.DoTricks();
        }
    }
}