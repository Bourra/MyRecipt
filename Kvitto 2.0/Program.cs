using System;

namespace MyReciept
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;

        }


        const int _maxNrArticles = 10;
        const int _maxArticleNameLength = 20;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[_maxNrArticles];
        static int nrArticles;

        static void Main(string[] args)
        {
            ReadArticles();
            PrintReciept();
            Console.ReadLine();
        }

        private static void ReadArticles()
        {
            try
            {
                Console.WriteLine("How many articles do you want?");
                nrArticles = Convert.ToInt32(Console.ReadLine());

                articles = new Article[nrArticles];

                if (nrArticles > _maxNrArticles || nrArticles < 1)
                {
                    Console.WriteLine("Wrong input, try again");
                    Console.WriteLine();
                    ReadArticles();
                }

            }
            catch (FormatException)
            {

                Console.WriteLine("Wrong input, you need to type a number.");
                ReadArticles();
            }

            Console.Clear();

            for (int i = 0; i < articles.Length; i++)
            {
                bool run = false;
                do
                {
                    try
                    {
                        Console.WriteLine($"Please enter the name and price for article #{i + 1} in format: name; price");
                        string[] input = Console.ReadLine().Split(';');
                        decimal price = Convert.ToDecimal(input[1]);


                        if (!string.IsNullOrEmpty(input[0]))
                        {
                            articles[i] = new Article { Name = input[0], Price = price };
                            run = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Name error, pls try again!");
                            Console.WriteLine();
                        }



                        Console.WriteLine();

                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Format error, pls try again!");
                        Console.WriteLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Price error, pls try again!");
                        Console.WriteLine();
                    }

                } while (run == false);



                Console.WriteLine();

            }
            Console.Clear();

        }
        private static void PrintReciept()
        {
            Console.WriteLine("Reciept Purchased Articles");
            Console.WriteLine($"Purchase date: {DateTime.Now}");
            Console.WriteLine();
            Console.WriteLine($"Number of items purchased: {nrArticles}");
            decimal totalPrice = 0;
            decimal vat = 0;
            Console.WriteLine();
            Console.WriteLine($"{"#Name",-25} {"Price"}");

            for (int i = 0; i < nrArticles; i++)
            {

                totalPrice += articles[i].Price;

                Console.Write($"{articles[i].Name,-25}{articles[i].Price:c}");
                Console.WriteLine();

            }


            Console.WriteLine();
            Console.WriteLine($"{"Total price:",-25}{totalPrice:c}");
            vat = totalPrice * _vat;
            Console.WriteLine($"{"Includes VAT (25%):",-25}{vat:c}");

        }
    }
}

