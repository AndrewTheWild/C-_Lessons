using System;

namespace Laba1
{
    [Serializable]
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

        public override bool Equals(object obj)
        {
            return obj is Person person && 
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Birthday == person.Birthday &&
                   Year == person.Year;
        }

        public static bool operator ==(Person p1,Person p2)
            =>p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2)
            => !(p1==p2);

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Birthday, Year);
        }
    }
}
