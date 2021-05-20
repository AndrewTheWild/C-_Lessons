using Laba1.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laba1.Model
{
    public enum Frequency
    {
        Weekly,
        Montly,
        Yearly
    }
    [Serializable]
    public class Magazine : Edition, IRateAndCopy, IEnumerable
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
        {
            get
            {
                var average = 0D;
                foreach (var item in Articles)
                {

                    average += item.Rating;

                }
                return Articles.Count > 0 ? average / Articles.Count : 0;
            }
        }

        public double Rating => throw new NotImplementedException();

        public Magazine() : this(string.Empty, Frequency.Montly, default, default) { }
        public Magazine(string title, Frequency frequency, DateTime releaseDate, int edition)
            : base(title, releaseDate, edition) => Frequency = frequency;

        public bool this[Frequency frequency]
        {
            get => Frequency == frequency ? true : false;
        }

        public void AddArticle(params Article[] articles)
            => Articles.AddRange(articles);
        public void AddEditors(params Person[] persons)
            => Editors.AddRange(persons);

        public override string ToString()
        {
            var format = base.ToString() + $" Average:{AverageRating}  {Frequency}\n";
            var listArticles = "List Articles:\n";
            foreach (var item in Articles)
            {

                listArticles += item.ToString() + "\n";

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

        private byte[] SerializeObject()
        {
            if (this == null)
            {
                return null;
            }
            var ms = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, this);
            var bytes = ms.GetBuffer();
            return bytes;
        }
        private object DeserializeObject(byte[] bytes)
        {
            object obj = null;

            if (bytes == null)
            {
                return obj;
            }

            var ms = new MemoryStream(bytes)
            {
                Position = 0
            };
            var formatter = new BinaryFormatter();
            obj = formatter.Deserialize(ms);
            ms.Close();
            return obj;
        }
        public new Magazine DeepCopy()
        {
            var serializeObj = SerializeObject();
            return (Magazine)DeserializeObject(serializeObj);
        }

        public bool Save(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Load(string filename)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    var newMagazine = (Magazine)formatter.Deserialize(fs);
                    Articles = newMagazine.Articles;
                    Editors = newMagazine.Editors;
                    Edition = newMagazine.Edition; 
                    Frequency = newMagazine.Frequency; 

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool Save(string filename, Magazine magazine)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, magazine);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool Load(string filename, Magazine magazine)
        {
            try
            {
                var formatter = new BinaryFormatter();
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    magazine = (Magazine)formatter.Deserialize(fs);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Please input data in one line:\n");
            Console.WriteLine("-Title of article;\n-Name author\n-Surname author\n-Birthday author\n-Rating");
            Console.WriteLine("List of  delimiting characters: ; space sign ");
            var stringWithData = Console.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(stringWithData))
                {
                    throw new Exception("---Error---\nString is empty!");
                }

                var dataArray = stringWithData.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (dataArray.Length != 5)
                {
                    throw new Exception("---Error---\nNot correct data!Please check your input data");
                }

                AddArticle(new Article(new Person(dataArray[1], dataArray[2], DateTime.Parse(dataArray[3])),
                                       dataArray[0],
                                       double.Parse(dataArray[4])));
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<Article> AtrticleLessRating(double max)
        {
            foreach (var item in Articles)
            {
                if (item is Article article && article.Rating > max)
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
