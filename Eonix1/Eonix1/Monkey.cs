using System;
using System.Collections.Generic;
using static Data.Models.Trick;

namespace Data.Models
{
    public class Monkey
    {
        public event EventHandler<Trick> TrickPerformed;

        private List<Trick> _tricks = new List<Trick> {
            new Trick {Name="TrickOne", TypeOfTrick = TrickType.Acrobatics },
            new Trick {Name="TrickTwo", TypeOfTrick = TrickType.Musical }
        };

        public void DoTricks()
        {
            foreach (var trick in _tricks)
            {
                Console.WriteLine($"Monkey performed trick {trick.Name} of type {trick.TypeOfTrick}");
                TrickPerformed?.Invoke(this, trick);
            }
        }
    }
}