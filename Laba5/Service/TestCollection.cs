using Laba1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Laba1.Service
{
    public class TestCollection
    {
        private List<Edition> listEditions;
        private List<string> listStrings;
        private Dictionary<Edition, Magazine> dictionaryEditions;
        private Dictionary<string, Magazine> dictionaryStrings;
        public TestCollection(int num)
        {
            listEditions = new List<Edition>(num);
            listStrings = new List<string>(num);
            dictionaryEditions = new Dictionary<Edition, Magazine>(num);
            dictionaryStrings = new Dictionary<string, Magazine>(num);

            for (int i = 0; i < num; i++)
            {
                var str= $"level+{i}";
                listStrings[i] = str;

                var edition = new Edition($"title{i}", new DateTime(2021, 5, DateTime.Today.Day + i),3+i);
                listEditions[i] = edition;

                var magazine = new Magazine($"Title Magazine {i}", Frequency.Weekly, new DateTime(2020, 8, DateTime.Today.Day + i), 2 + i);

                dictionaryEditions.Add(edition, magazine);
                dictionaryStrings.Add(str, magazine);
            }
        }
        //public static Magazine RandMagazine(int num)
        //{

        //}

        public void SearchElement()
        {
            Stopwatch stopwatch = new Stopwatch();
            var edition = new Edition($"title2", new DateTime(2021, 5, DateTime.Today.Day + 1), 3 + 1);

            stopwatch.Start();
            var search1_1=listEditions.Find(item=>item.TitleEdition=="title2");
            stopwatch.Stop();
            Console.WriteLine($"Time:{stopwatch.Elapsed}");

            stopwatch.Start();
            var search1_2 = listStrings.Find(item => item== "level2");
            stopwatch.Stop();
            Console.WriteLine($"Time:{stopwatch.Elapsed}");

            //stopwatch.Start();
            //var search1_3 = dictionaryEditions.ContainsKey(edition);
            //    .Find(item => item.TitleEdition == "title2");
            //stopwatch.Stop();
            //Console.WriteLine($"Time:{stopwatch.Elapsed}");

            //stopwatch.Start();
            //var search1_4 = listEditions.Find(item => item.TitleEdition == "title2");
            //stopwatch.Stop();
            //Console.WriteLine($"Time:{stopwatch.Elapsed}");
            //Console.WriteLine("------------");

            //stopwatch.Restart();
            //var index =listEditions.FindIndex(0, listEditions.Count / 2, item => item.EditionCount == 6);
            //stopwatch.Stop();
            //Console.WriteLine($"Time:{stopwatch.Elapsed}");

            //stopwatch.Restart();
            //var search2=listEditions.FindLast(item => item.TitleEdition == "title6");
            //stopwatch.Stop();
            //Console.WriteLine($"Time:{stopwatch.Elapsed}");

            //stopwatch.Restart();
            //var search3 = listEditions.Find(item => item.TitleEdition == "Title");
            //stopwatch.Stop();
            //Console.WriteLine($"Time:{stopwatch.Elapsed}");
        }
    }
}
