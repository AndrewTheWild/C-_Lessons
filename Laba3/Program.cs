using Laba1.Interfaces;
using Laba1.Model;
using Laba1.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Laba1
            //Console.WriteLine("Magazine");
            //var magazine = new Magazine("New Web Technology", Frequency.Weekly, new DateTime(2021, 2, 13), 6);

            //Console.WriteLine(magazine.ToShortString());
            //Console.WriteLine("\nIndexer");
            //Console.WriteLine(magazine[Frequency.Weekly]);
            //Console.WriteLine(magazine[Frequency.Montly]);
            //Console.WriteLine(magazine[Frequency.Yearly]);

            //Console.WriteLine("\nProperty");
            //magazine.Title = "PCF Controls";
            //magazine.Frequency = Frequency.Yearly;
            //magazine.ReleaseDate = new DateTime(2020, 1, 21);
            //magazine.Edition = 10;
            //Console.WriteLine("\nAdd Articles");
            //magazine.AddArticle(new Article[]
            //{
            //    new Article(){
            //        PersonData=new Person("Mad","Devis",new DateTime(1999,10,21)),
            //        Title="Attention",
            //        Rating=10.1
            //    },
            //    new Article(){
            //        PersonData=new Person("Mark","Travis",new DateTime(1991,11,11)),
            //        Title="Development",
            //        Rating=8.1
            //    },
            //    new Article(){
            //        PersonData=new Person("Luck","Redis",new DateTime(2001,6,1)),
            //        Title="Speak up",
            //        Rating=11.8
            //    },
            //    new Article(){
            //        PersonData=new Person("Rick","Monro",new DateTime(1989,2,25)),
            //        Title="Modern Operating System",
            //        Rating=5.9
            //    },
            //});
            //Console.WriteLine(magazine.ToString());

            //Console.WriteLine("\nWork with array");
            //Console.WriteLine("Input Size array(Count rows and columns):");
            //var size = Console.ReadLine().Split(new char[] { ' ', ',' });
            //while (size.Length > 2 || size.Length==1)
            //{
            //    size = Console.ReadLine().Split(new char[] { ' ', ',' });
            //}
            //try
            //{
            //    var rows = int.Parse(size[0]);
            //    var columns = int.Parse(size[1]);

            //    var array1 = new Article[rows * columns];
            //    for(int i=0;i<array1.Length;i++)
            //    {
            //        array1[i]= new Article();
            //    }

            //    var array2 = new Article[rows, columns];
            //    for (int i = 0; i < rows; i++)
            //    {
            //        for (int j = 0; j < columns; j++)
            //        {
            //            array2[i,j] = new Article();
            //        }
            //    }

            //    var array3 = new Article[rows][];
            //    for (int i = 0; i < rows; i++)
            //    {
            //        array3[i] = new Article[columns];
            //        for (int j = 0; j < columns; j++)
            //        {
            //            array3[i][j] = new Article();
            //        }
            //    }



            //    Stopwatch stopwatch = new Stopwatch();

            //    Console.WriteLine("\nWork with one dimensional array"); 
            //    stopwatch.Start();
            //    foreach (var item in array1)
            //    {
            //        item.Title = "Some value";
            //    } 
            //    stopwatch.Stop();
            //    Console.WriteLine($"Time:{stopwatch.Elapsed}"); 

            //    Console.WriteLine("\nWork with two dimensional array");
            //    stopwatch.Restart();
            //    foreach (var item in array2)
            //    {
            //        item.Title = "Some value";
            //    }
            //    stopwatch.Stop();
            //    Console.WriteLine($"Time:{stopwatch.Elapsed}");

            //    Console.WriteLine("\nWork with array of arrays");
            //    stopwatch.Restart();
            //    foreach (var row in array3)
            //    {
            //        foreach (var item in row)
            //        {
            //            item.Title = "Some value";
            //        }
            //    }
            //    stopwatch.Stop();
            //    Console.WriteLine($"Time:{stopwatch.Elapsed}");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
            //}
            #endregion

            #region Laba2
            //var edition1 = new Edition("Test Title",new DateTime(2021,3,21), 4);
            //var edition2 = new Edition("Test Title", new DateTime(2021, 3, 21), 4);
            //Console.WriteLine(edition1 == edition2);

            //try
            //{
            //    edition2.EditionCount = -1;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error,not correct value,\n{ex.Message}");
            //}

            //var magazine = new Magazine("Test", Frequency.Weekly, DateTime.Now, 5)
            //{
            //    Articles = new List<Article>()
            //    {
            //        new Article(
            //            new Person("Jack","Redl",new DateTime(2021,3,21)),
            //            ".Net",
            //            10.7
            //            ),
            //        new Article(
            //            new Person("Myko","Plug",new DateTime(2021,8,23)),
            //            ".Net Core",
            //            7.7
            //            ),
            //        new Article(
            //            new Person("Myav","Leader",new DateTime(2020,9,11)),
            //            "Blazor",
            //            5.7
            //            ),
            //        new Article(
            //            new Person("Leo","Kapri",new DateTime(2011,7,21)),
            //            "ASP.NET",
            //            3.7
            //            )
            //    },
            //    Editors=new List<Person>()
            //    {
            //        new Person("Mad","Max",new DateTime(2010,11,11)),
            //        new Person("Bruce","Brokly",new DateTime(2005,5,21)),
            //        new Person("Myko","Plug",new DateTime(2021,8,23)),
            //        new Person("Leo","Kapri",new DateTime(2011,7,21))
            //    }
            //};
            //Console.WriteLine(magazine.ToString());

            //Console.WriteLine($"Edition:{magazine.Edition}");

            //var copyMagazine =((IRateAndCopy)magazine).DeepCopy() as Magazine;

            //magazine.TitleEdition = "Test v2.0";

            //Console.WriteLine();

            //Console.WriteLine($"Original:{magazine.TitleEdition}");
            //Console.WriteLine($"Copy:{copyMagazine?.TitleEdition}");

            //Console.WriteLine("Iterator");
            //Console.WriteLine("First");
            //Console.WriteLine();

            //foreach (var item in magazine.AtrticleLessRating(7))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("Second");
            //Console.WriteLine();

            //foreach (var item in magazine.AtrticleNameContains("Net"))
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine("--Query--");
            //Console.WriteLine();

            //Console.WriteLine("1.");
            //foreach (var item in magazine)
            //{
            //    Console.WriteLine((item as Article)?.ToString());
            //}

            //Console.WriteLine();
            //Console.WriteLine("2.");

            //foreach (var item in magazine.AtrticleAuthorIsEditor())
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //Console.WriteLine();
            //Console.WriteLine("3.");

            //foreach (var item in magazine.EditorsNotContainsArticles())
            //{
            //    Console.WriteLine(item.ToString());
            //}
            #endregion

            var magazineCollection = new MagazineCollection();
            magazineCollection.AddDefaults();

            Console.WriteLine(magazineCollection.ToString());
            Console.WriteLine("\n----Sorting----\n");

            Console.WriteLine("\nSort On title----");
            magazineCollection.SortOnTitle.ForEach(item=>Console.WriteLine(item.ToShortString()));

            Console.WriteLine("\nSort On Date----");
            magazineCollection.SortOnDate.ForEach(item => Console.WriteLine(item.ToShortString()));

            Console.WriteLine("\nSort On EditionCount----");
            magazineCollection.SortOnEditionCount.ForEach(item => Console.WriteLine(item.ToShortString()));

            Console.WriteLine("\nOperation----\n");

            Console.WriteLine($"\nMax rate average from collection: {magazineCollection.MaxRateAverage}");

            Console.WriteLine("\nFrequency montly");
            foreach (var item in magazineCollection.MagazineMonly)
            {
                Console.WriteLine(item.ToShortString());
            }

            Console.WriteLine("\nGrouping----");
            magazineCollection.RatingGroup(2).ForEach(item => Console.WriteLine(item.ToShortString()));
        }
    }
}
