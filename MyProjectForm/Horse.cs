using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectForm
{
    public class Horse : Animals
    {
        string suit;
        string breed;
        public override string Name
        {
            get { return base.Name; }
        }
        public override string Suit
        {
            get { return suit; }
        }
        public override int BIRTH_YEAR
        {
            get { return base.BIRTH_YEAR; }
        }
        public Horse(string name, int BirthYear, string suit, string breed) : base(name, BirthYear)
        {
            this.suit = suit;
            this.breed = breed;
        }
        public override string Print()
        {
            return Name + " " + BIRTH_YEAR + " " + suit + " " + breed;
        }
    }
}
