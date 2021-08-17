using Data.Models;
using System;

namespace Data
{
    public class Spectator
    {
        public void GreetTrainer(Monkey m)
        {
            m.TrickPerformed += ReactToMonkeyTrick;
        }

        private void ReactToMonkeyTrick(object sender, Trick trick)
        {
            switch (trick.TypeOfTrick)
            {
                case Trick.TrickType.Acrobatics:
                    Console.WriteLine("Tour d'acrobatie -> Applaudissement !!!\n");
                    break;

                case Trick.TrickType.Musical:
                    Console.WriteLine("Tour musical -> Sifflement !!!\n");
                    break;
            }
        }
    }
}