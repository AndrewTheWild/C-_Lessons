using Laba1.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using Laba1.Event;

namespace Laba1.Service
{
    public class MagazineCollection
    {
        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);
       // public event MagazineListHandler NotifyChangeCollection;
        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;
        public string NameCollection { get; set; }

        private List<Magazine> listMagazine;

        public Magazine this[int number]
        {
            get => listMagazine[number];
            set
            {
                listMagazine[number] = value;
                MagazineReplaced?.Invoke(null, new MagazineListHandlerEventArgs(NameCollection, "A was replaced new element", number+1));
            }
        }
        public bool Replace(int j, Magazine magazine)
        {
            if (listMagazine.Count >= j)
            {
                listMagazine[j - 1] = magazine;
                MagazineReplaced?.Invoke(null, new MagazineListHandlerEventArgs(NameCollection, "A was replaced new element", j));
                return true;
            }
            return false;
        }
        public double MaxRateAverage
        {
            get
            {
                if (listMagazine.Count == 0)
                {
                    return 0;
                }

                return listMagazine
                          .Select(item => item.Articles.Sum(article => article.Rating) / item.Articles.Count)
                          .Max();
            }
        }

        public IEnumerable<Magazine> MagazineMonly
            => listMagazine.Where(item => item.Frequency == Frequency.Montly);

        public List<Magazine> RatingGroup(double value)
            => listMagazine
              .GroupBy(item => item.AverageRating)
              .Where(item => item.Key >= value).Select(item => item.ToList())
              .Aggregate((gr1, gr2) => gr1.Concat(gr2).ToList());


        public List<Magazine> SortOnTitle
        {
            get
            {
                var copyList = listMagazine.ToList();
                copyList.Sort((item1, item2) => item1.Edition.CompareTo(item2.Edition));
                return copyList;
            }

        }

        public List<Magazine> SortOnDate
        {
            get
            {
                var copyList = listMagazine.ToList();
                copyList.Sort(new Edition());
                return copyList;
            }

        }

        public List<Magazine> SortOnEditionCount
        {
            get
            {
                var copyList = listMagazine.ToList();
                copyList.Sort(new EditionCompare());
                return copyList;
            }

        }

        public void AddDefaults()
        {
            listMagazine = new List<Magazine>()
            {
                new Magazine("Forbes", Frequency.Weekly, DateTime.Now, 5)
                {
                Articles = new List<Article>()
                {
                    new Article(
                        new Person("Jack","Redl",new DateTime(2021,3,21)),
                        ".Net",
                        10.7
                        ),
                    new Article(
                        new Person("Myko","Plug",new DateTime(2021,8,23)),
                        ".Net Core",
                        7.7
                        ),
                    new Article(
                        new Person("Myav","Leader",new DateTime(2020,9,11)),
                        "Blazor",
                        5.7
                        ),
                    new Article(
                        new Person("Leo","Kapri",new DateTime(2011,7,21)),
                        "ASP.NET",
                        3.7
                        )
                },
                Editors = new List<Person>()
                {
                    new Person("Mad","Max",new DateTime(2010,11,11)),
                    new Person("Bruce","Brokly",new DateTime(2005,5,21)),
                    new Person("Myko","Plug",new DateTime(2021,8,23)),
                    new Person("Leo","Kapri",new DateTime(2011,7,21))
                }
                },
                new Magazine("Daily Planet", Frequency.Montly, DateTime.Now, 9)
                {
                Articles = new List<Article>()
                {
                    new Article(
                        new Person("George","Kik",new DateTime(2001,3,11)),
                        "Ruby",
                        2.7
                        ),
                    new Article(
                        new Person("Mike","Orego",new DateTime(2014,1,23)),
                        "Python",
                        1.7
                        )
                },
                Editors = new List<Person>()
                {
                    new Person("Ben","Luck",new DateTime(2000,11,11)),
                    new Person("Gean","Reck",new DateTime(2004,5,17)),
                }
                }
            };
            MagazineAdded?.Invoke(null, new MagazineListHandlerEventArgs(NameCollection, "A was added new element", 1));
            MagazineAdded?.Invoke(null, new MagazineListHandlerEventArgs(NameCollection, "A was added new element", 2));
        }
        public void AddMagazines(params Magazine[] magazines)
        {
            foreach (var item in magazines)
            {
                listMagazine.Add(item);
                var number = listMagazine.IndexOf(item) + 1;
                MagazineAdded?.Invoke(null, new MagazineListHandlerEventArgs(NameCollection, "A was added new element", number));
            }
        }
        public override string ToString()
        {
            var resultString = string.Empty;
            listMagazine.ForEach(item => resultString += item.ToString() + "\n");
            return resultString;
        }

        public virtual string ToShortString()
        {
            var resultString = string.Empty;
            listMagazine.ForEach(item => resultString += item.ToShortString() + "\n");
            return resultString;
        }
    }
}
