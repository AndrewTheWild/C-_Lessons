using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba1.Model
{
    public enum Frequency
    {
        Weekly,
        Montly,
        Yearly
    }
    public class Magazine
    {
        private string title;
        private Frequency frequency;
        private DateTime releaseDate;
        private int edition;
        private Article[] articles;

        public string Title { get => title; set => title = value; }
        public Frequency Frequency { get => frequency; set => frequency = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public int Edition { get => edition; set => edition = value; }
        public Article[] Articles { get => articles; set => articles = value; }
        public double? AverageRaiting { get => Articles?.Sum(item => item.Raiting) / Articles?.Length; }

        public Magazine() : this(string.Empty, Frequency.Montly, default, default) { }
        public Magazine(string title, Frequency frequency, DateTime releaseDate, int edition)
        {
            Title = title;
            Frequency = frequency;
            ReleaseDate = releaseDate;
            Edition = edition;
        }

        public bool this[Frequency frequency]
        {
            get => Frequency == frequency ? true : false;
        }

        public void AddArticle(params Article[] articles)
        {
            var tempList = new List<Article>();
            if (Articles != null)
            {
                tempList.AddRange(Articles);
            }
            tempList.AddRange(articles);
            Articles = tempList.ToArray();
        }

        public override string ToString()
        {
            var format = $"{Title} {Frequency} {ReleaseDate} {Edition} {AverageRaiting}\n";
            var res = Articles.Select(item => item.ToString()).Aggregate((concat, str) => $"{concat}{str}");
            return $"{format}\n{res}";
        }

        public virtual string ToShortString()
            => $"{Title} {Frequency} {ReleaseDate} {Edition} {AverageRaiting}";
    }
}
