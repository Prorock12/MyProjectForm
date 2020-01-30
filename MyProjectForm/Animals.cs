using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectForm
{
    abstract public class Animals : IComparable
    {
        string name;
        int BirthYear;
        virtual public string Name
        {
            get { return name; }
        }
        virtual public int BIRTH_YEAR
        {
            get { return BirthYear; }
        }
        virtual public string Suit
        {
            get;
        }
        virtual public double Height
        {
            get;
        }
        public Animals(string name, int BirthYear)
        {
            this.name = name;
            this.BirthYear = BirthYear;
        }
        virtual public string Print() { return " "; }
        public int CompareTo(object other)
        {
            Horse horse = other as Horse;
            Donkey donkey = other as Donkey;
            if (horse != null)
                return this.BirthYear.CompareTo(horse.BirthYear);
            else if (donkey != null)
                return this.BirthYear.CompareTo(donkey.BirthYear);
            else
                return 1;
        }
    }
}
