using Laba1.Interfaces;
using System;
using System.Collections;
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
    public class Magazine:Edition,IRateAndCopy,IEnumerable
    { 
        private Frequency frequency;
        private List<Person> editors;
        private List<Article> articles; 
        public Frequency Frequency { get => frequency; set => frequency = value; }  
        public List<Article> Articles { get => articles; set => articles = value; }
        public List<Person> Editors { get => editors; set => editors = value; }
        public Edition Edition 
        { 
            get => base.DeepCopy as Edition; 
            set 
            {
                TitleEdition = value.TitleEdition;
                ReleaseDate = value.ReleaseDate;
                EditionCount = value.EditionCount;
            } 
        }
        public double AverageRating 
        { get 
            {
                var average = 0D;
                foreach (var item in Articles)
                {
                     
                        average += item.Rating;
                     
                }
                return Articles.Count>0?average / Articles.Count:0;
            }
        }

        public double Rating => throw new NotImplementedException();

        public Magazine() : this(string.Empty, Frequency.Montly, default, default) { }
        public Magazine(string title, Frequency frequency, DateTime releaseDate, int edition)
            :base(title,releaseDate,edition)=> Frequency = frequency;  

        public bool this[Frequency frequency]
        {
            get => Frequency == frequency ? true : false;
        }

        public void AddArticle(params Article[] articles)
            =>Articles.AddRange(articles);
        public void AddEditors(params Person[] persons)
            => Editors.AddRange(persons);

        public override string ToString()
        {
            var format = base.ToString() + $" Average:{AverageRating}  {Frequency}\n";
            var listArticles = "List Articles:\n";
            foreach (var item in Articles)
            {
                
                    listArticles += item.ToString()+"\n";
                
            }
            var listEditors = "List Editors:\n";
            foreach (var item in Editors)
            {
                 
                    listEditors += item.ToString() + "\n";
                 
            }

            return $"{format}{listArticles}{listEditors}"; 
        }

        public virtual string ToShortString()
            => $"{base.ToString()} {Frequency} Average:{AverageRating}";

        object IRateAndCopy.DeepCopy()
        {
            return new Magazine(TitleEdition, Frequency, ReleaseDate, EditionCount);
        }

        public IEnumerable<Article> AtrticleLessRating(double max)
        {
            foreach (var item in Articles)
            {
                if (item is Article article && article.Rating>max)
                {
                    yield return article;
                }
            }
        }
        public IEnumerable<Article> AtrticleNameContains(string name)
        {
            foreach (var item in Articles)
            {
                if (item is Article article && article.Title.Contains(name))
                {
                    yield return article;
                }
            }
        }

        public IEnumerable<Article> AtrticleAuthorIsEditor()
        {
            foreach (var item in Articles)
            {
                if (item is Article article)
                {
                    if (Editors.Contains(article.PersonData))
                    {
                        yield return article;
                    }
                }
            }
        }

        public IEnumerable<Person> EditorsNotContainsArticles()
        {
            foreach (var item in Editors)
            {
                if (item is Person person)
                {
                    var flag = false;
                    foreach (var elem in Articles)
                    {
                        if (elem is Article article)
                        {
                            if (article.PersonData == person)
                            {
                                flag = true;
                            }
                        }
                    }
                    if (!flag)
                    {
                        yield return person;
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MagazineEnumerator(this);
        }
    }
}
