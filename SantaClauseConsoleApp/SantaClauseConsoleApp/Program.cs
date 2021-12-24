using System;
using System.Collections.Generic;
using System.IO;

namespace SantaClauseConsoleApp
{
    class Program
    {
        private static List<Child> children = new List<Child>();
        private static string dataDirectory;

        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            Console.WriteLine("Question 1:");

            Item item1 = new Item("Bicycle");
            Item item2 = new Item("Gaming console");
            Item item3 = new Item("Keyboard");
            Item item4 = new Item("Tennis ball");
            Item item5 = new Item("Mouse");
            Item item6 = new Item("Bicycle");

            Child child1 = new Child("Sam Johnson", 11, new FullAddress("123 Howard Street", "New York City","United States of America"), BehaviorEnum.Good);
            Child child2 = new Child("William Turner", 13, new FullAddress("243 Morton Street", "Boston", "United States of America"), BehaviorEnum.Bad);
            Child child3 = new Child("Adam West", 9, new FullAddress("5334 Howard Street", "New York City", "United States of America"), BehaviorEnum.Good);

            child1.addItemToLetter(item1);
            child1.addItemToLetter(item2);
            child2.addItemToLetter(item3);
            child2.addItemToLetter(item4);
            child3.addItemToLetter(item5);
            child3.addItemToLetter(item6);

            children.Add(child1);
            children.Add(child2);
            children.Add(child3);

            foreach (Child child in children)
            {
                Console.WriteLine(child.ToString() + "\n");
            }
        }

        static void Question2()
        {
            Console.WriteLine("\nQuestion 2:");

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            dataDirectory = projectDirectory + @"\Data";

            children.Add(new Child(dataDirectory + @"\input-letter1.txt"));
            children.Add(new Child(dataDirectory + @"\input-letter2.txt"));
            children.Add(new Child(dataDirectory + @"\input-letter3.txt"));
            for (int i = 3; i < 6; ++i)
            {
                Console.WriteLine(children[i].ToString() + "\n");
            }
        }

        static void Question3()
        {
            children[0].writeLetter(dataDirectory + @"\letter1.txt");
            children[1].writeLetter(dataDirectory + @"\letter2.txt");
            children[2].writeLetter(dataDirectory + @"\letter3.txt");
        }

        static void Question4()
        {
            // For questions 4 and 6 I have used the children from both question 1 and question 2 in order to have a bigger data sample.

            Console.WriteLine("\nQuestion 4:");

            SantaClaus.GET.Children = children;
            List<(string, int)> report = SantaClaus.GET.getToyReport();

            foreach ((string name, int quantity) in report)
            {
                Console.WriteLine($"{name} - {quantity}");
            }
        }

        static void Question5()
        {
            /*
             * I have used the Singleton pattern with the Santa Claus class, because it makes sense from both a logical and a programmatical point of view, as there is only one Santa Claus
             * and it would also be redundant and inefficient to instantiate a new object everytime we need the methods from the Santa Claus class. Another solution would have been to make
             * the methods static and to give the list of children as a parameter to the methods.
            */
        }

        static void Question6()
        {
            // For questions 4 and 6 I have used the children from both question 1 and question 2 in order to have a bigger data sample.

            Console.WriteLine("\nQuestion 6:");

            SantaClaus.GET.Children = children;
            List<FullAddress> addresses = SantaClaus.GET.getGroupedAddresses();

            foreach (FullAddress adr in addresses)
            {
                Console.WriteLine($"{adr}");
            }
        }
    }
}
