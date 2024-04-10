
using System;
using System.Runtime.CompilerServices;

namespace ST10390916PROGPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String option = "0";
            while (!option.Equals("5"))
            {
                Recipe recipe = new Recipe();
                bool hasCurrentRecipe = false;

                Console.WriteLine("Select an option below (eg. 2):");
                Console.WriteLine("1. Make a new recipe\n2. View current recipe\n3. Scale your recipe\n4. Reset recipe scale\n5. Exit\n\nYour selction: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":   //new recipe
                        if (hasCurrentRecipe)  //check if a current recipe has been entered.
                        {
                            Console.WriteLine("Your current recipe will be overwritten");
                            break;
                        }
                        Console.Write("Enter your recipe name: ");
                        //Enter and check details
                        //set recipe to true
                        break;

                    case "2":   //view recipe
                        if (!hasCurrentRecipe)  //check if a recipe has been entered.
                        {  
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }
                        break;

                    case "3":   //scale recipe ingredients
                        if (!hasCurrentRecipe) //check if a recipe has been entered.
                            Console.WriteLine("You don't currently have a recipe saved.");
                        Console.Write("Enter the scale to change ingredient quantities: ");
                        break;
                }
            }

        }
    }
}
