using Laba1.Model;
using System;
using System.Diagnostics;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Magazine");
            var magazine = new Magazine("New Web Technology", Frequency.Weekly, new DateTime(2021, 2, 13), 6);
            
            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine("\nIndexer");
            Console.WriteLine(magazine[Frequency.Weekly]);
            Console.WriteLine(magazine[Frequency.Montly]);
            Console.WriteLine(magazine[Frequency.Yearly]);

            Console.WriteLine("\nProperty");
            magazine.Title = "PCF Controls";
            magazine.Frequency = Frequency.Yearly;
            magazine.ReleaseDate = new DateTime(2020, 1, 21);
            magazine.Edition = 10;
            Console.WriteLine("\nAdd Articles");
            magazine.AddArticle(new Article[]
            {
                new Article(){
                    PersonData=new Person("Mad","Devis",new DateTime(1999,10,21)),
                    Title="Attention",
                    Raiting=10.1
                },
                new Article(){
                    PersonData=new Person("Mark","Travis",new DateTime(1991,11,11)),
                    Title="Development",
                    Raiting=8.1
                },
                new Article(){
                    PersonData=new Person("Luck","Redis",new DateTime(2001,6,1)),
                    Title="Speak up",
                    Raiting=11.8
                },
                new Article(){
                    PersonData=new Person("Rick","Monro",new DateTime(1989,2,25)),
                    Title="Modern Operating System",
                    Raiting=5.9
                },
            });
            Console.WriteLine(magazine.ToString());

            Console.WriteLine("\nWork with array");
            Console.WriteLine("Input Size array(Count rows and columns):");
            var size = Console.ReadLine().Split(new char[] { ' ', ',' });
            while (size.Length > 2 || size.Length==1)
            {
                size = Console.ReadLine().Split(new char[] { ' ', ',' });
            }
            try
            {
                var rows = int.Parse(size[0]);
                var columns = int.Parse(size[1]);

                var array1 = new Article[rows * columns];
                for(int i=0;i<array1.Length;i++)
                {
                    array1[i]= new Article();
                }

                var array2 = new Article[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        array2[i,j] = new Article();
                    }
                }

                var array3 = new Article[rows][];
                for (int i = 0; i < rows; i++)
                {
                    array3[i] = new Article[columns];
                    for (int j = 0; j < columns; j++)
                    {
                        array3[i][j] = new Article();
                    }
                }



                Stopwatch stopwatch = new Stopwatch();

                Console.WriteLine("\nWork with one dimensional array"); 
                stopwatch.Start();
                foreach (var item in array1)
                {
                    item.Title = "Some value";
                }
                var finish = Environment.TickCount;
                stopwatch.Stop();
                Console.WriteLine($"Time:{stopwatch.Elapsed}"); 

                Console.WriteLine("\nWork with two dimensional array");
                stopwatch.Restart();
                foreach (var item in array2)
                {
                    item.Title = "Some value";
                }
                stopwatch.Stop();
                Console.WriteLine($"Time:{stopwatch.Elapsed}");

                Console.WriteLine("\nWork with array of arrays");
                stopwatch.Restart();
                foreach (var row in array3)
                {
                    foreach (var item in row)
                    {
                        item.Title = "Some value";
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"Time:{stopwatch.Elapsed}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
            }

        }
    }
}
