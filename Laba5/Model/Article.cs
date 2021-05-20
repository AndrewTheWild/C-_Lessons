using Laba1.Interfaces;
using System;

namespace Laba1.Model
{
    [Serializable]
    public class Article: IRateAndCopy
    {
        public Person PersonData { get; set; }
        public string Title { get; set; }

        public double Rating { get; }

        public Article() : this(new Person(), string.Empty, default) { }

        public Article(Person person, string title, double raiting)
        {
            PersonData = person;
            Title = title;
            Rating = raiting;
        }

        public override string ToString()
            => PersonData.ToString() + "\n" + $"{Title}:{Rating}\n";

        public object DeepCopy()
        {
            return new Article(PersonData,Title, Rating);
        }
    }
}
