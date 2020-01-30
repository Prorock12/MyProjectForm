using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectForm
{
    class Donkey : Animals
    {
        string kind;
        double height;
        public override string Name
        {
            get { return base.Name; }
        }
        public override int BIRTH_YEAR
        {
            get { return base.BIRTH_YEAR; }
        }
        public override string Suit
        {
            get { return kind; }
        }
        public override double Height
        {
            get { return height; }
        }
        public Donkey(string name, int BirthYear, string kind, double height) : base(name, BirthYear)
        {
            this.kind = kind;
            this.height = height;
        }
        public override string Print()
        {
            return Name + " " + BIRTH_YEAR + " " + kind + " " + height;
        }
    }
}
