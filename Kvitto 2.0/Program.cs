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
            //           ReadArticles();
            Menu();           
            Console.ReadLine();
        }

        static void Menu()
        {
            
            Console.WriteLine($"{ nrArticles} articles entered" );
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Enter an article");
            Console.WriteLine("2 - Remove an article");
            Console.WriteLine("3 - Print receipt sorted by price");
            Console.WriteLine("4 - Print receipt sorted by name");
            Console.WriteLine("5 - Quit");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                EnterAnArticle();
            }
            else if (choice == 2)
            {
                DeleteArticle();
            }
            else if (choice == 3)
            {
                PrintReciept();
            }
            else if (choice == 4)
            {

            }
            else if (choice == 5)
            {
                Console.Clear();
            }


        }

        static void EnterAnArticle()
        {
            try
            {
                Console.WriteLine($"Please enter the name and price for article #{nrArticles + 1} in format: name; price");
                string[] input = Console.ReadLine().Split(';');
                decimal price = Convert.ToDecimal(input[1]);


                if (!string.IsNullOrEmpty(input[0]))
                {
                    articles[nrArticles] = new Article { Name = input[0], Price = price };
                    nrArticles++;
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
            Menu();
        }
        static void DeleteArticle()
        {
            Console.WriteLine("Please enter the name of the article you want to remove (exmaple: Beer)");
            string remove = Console.ReadLine();
            remove.ToLower();

            for (int i = 0; i < articles.Length; i++)
            {
                if (remove == articles[i].Name)
                {
                    articles[i] = new Article();
                    nrArticles--;
                }
            }
            Menu();
        }
        static void PrintSortName()
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
                if (articles[i].Name != null || articles[i].Price != 0)
                {
                    totalPrice += articles[i].Price;

                    Console.Write($"{articles[i].Name,-25}{articles[i].Price:c}");
                    Console.WriteLine();

                }

            }


            Console.WriteLine();
            Console.WriteLine($"{"Total price:",-25}{totalPrice:c}");
            vat = totalPrice * _vat;
            Console.WriteLine($"{"Includes VAT (25%):",-25}{vat:c}");
            Menu();
        }
        static void PrintSortPrice()
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
                if (articles[i].Name != null || articles[i].Price != 0)
                {
                    totalPrice += articles[i].Price;

                    Console.Write($"{articles[i].Name,-25}{articles[i].Price:c}");
                    Console.WriteLine();

                }

            }


            Console.WriteLine();
            Console.WriteLine($"{"Total price:",-25}{totalPrice:c}");
            vat = totalPrice * _vat;
            Console.WriteLine($"{"Includes VAT (25%):",-25}{vat:c}");
            Menu();
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
            Menu();
        }

        
    }
}

