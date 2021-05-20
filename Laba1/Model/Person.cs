using System;

namespace Laba1
{
    public class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }

        public int Year {get => birthday.Year; set=> birthday.AddYears(value - birthday.Year);}

        public Person() : this(string.Empty, string.Empty, DateTime.Today) { }
        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }
        public override string ToString()
            => $"{Name} {Surname}:{Birthday}";
        public virtual string ToShortString()
            => $"{Name} {Surname}";
    }
}
