 namespace Laba1.Model
{
    public class Article
    {
        public Person PersonData { get; set; }
        public string Title { get; set; }
        public double Raiting { get; set; }

        public Article() : this(new Person(), string.Empty, default) { }

        public Article(Person person, string title, double raiting)
        {
            PersonData = person;
            Title = title;
            Raiting = raiting;
        }

        public override string ToString()
            => PersonData.ToString() + "\n" + $"{Title}:{Raiting}\n";
    }
}
