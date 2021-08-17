using Data;
using Data.Models;
using System;

namespace Eonix1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var spectator = new Spectator();

            var trainerOne = new Trainer();
            var trainerTwo = new Trainer();

            spectator.GreetTrainer(trainerOne.ShowMonkey());
            spectator.GreetTrainer(trainerTwo.ShowMonkey());

            trainerOne.MakeMonkeyDoTricks();
            trainerTwo.MakeMonkeyDoTricks();

            Console.ReadKey();
        }
    }
}