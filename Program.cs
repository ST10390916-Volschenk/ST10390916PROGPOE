
using System;
using System.Collections.Generic;

namespace ST10390916PROGPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool hasCurrentRecipe = false;
            String recipeName, ingredientName, unitOfMeasurement, ingredientAmount;
            int numOfIngredients = 0;
            int numOfSteps = 0;
            double ingredientScale;

            String option = "0";
            while (!option.Equals("5"))
            {
                Console.WriteLine("Select an option below (eg. 2):");
                Console.WriteLine("1. Make a new recipe\n2. View current recipe\n3. Scale your recipe\n4. Reset recipe scale\n5. Exit\n\nYour selction: ");
                option = Console.ReadLine();
                switch (option)
                {
                    ///////////////////////////////////////create new recipe/////////////////////////////////////////////////////

                    case "1":

                        //checking if a recipe already exists

                        if (hasCurrentRecipe)
                        {
                            Console.WriteLine("Your current recipe will be overwritten.\nProceed?\n1. Yes\n2. No");
                            String answer = Console.ReadLine();
                            if (answer.Equals("2"))
                                break;
                        }

                        //Collect recipe information

                        //recipe name

                        Console.Write("Enter your recipe name: ");
                        recipeName = Console.ReadLine();

                        //number of ingredients

                        bool validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of ingredients: ");

                            try
                            {
                                numOfIngredients = int.Parse(Console.ReadLine());
                                validNum = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid number.");
                            }

                        }

                        //list of ingredients

                        List<Ingredient> ingredients = new List<Ingredient>();

                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            Console.Write($"Enter ingredient no {i}: ");
                            ingredientName = Console.ReadLine();

                            Console.WriteLine($"Enter the unit of measurement for ingredient no {i}: ");
                            unitOfMeasurement = Console.ReadLine();

                            Console.Write($"Enter the quantity of ingredient no {i} in {unitOfMeasurement}: ");
                            ingredientAmount = Console.ReadLine();

                            ingredients.Add(new Ingredient(ingredientName, unitOfMeasurement, ingredientAmount));
                        }

                        //Scale of recipe ingredients

                        ingredientScale = 1;    //scale can be changed after recipe is created

                        //number of steps

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of steps: ");

                            try
                            {
                                numOfSteps = int.Parse(Console.ReadLine());
                                validNum = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid number.");
                            }

                        }

                        //list of steps
                        List<String> steps = new List<String>();

                        for (int i = 0; i < numOfSteps; i++)
                        {
                            Console.Write($"Enter step no {i}: ");
                            steps.Add(Console.ReadLine());
                        }

                        //create recipe and display it using ToString
                        Recipe recipe = new Recipe(recipeName, numOfIngredients, ingredients, ingredientScale, numOfSteps, steps);

                        hasCurrentRecipe = true;
                        recipe.ToString();

                        break;

                    /////////////////////////View the current recipe////////////////////////////////////////////////////

                    case "2":
                        if (!hasCurrentRecipe)  //check if a recipe has been entered.
                        {
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }
                        break;

                    case "3":   //scale recipe ingredients
                        if (!hasCurrentRecipe) //check if a recipe has been entered.
                        {
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }

                        Console.Write("Enter the scale to change ingredient quantities: ");
                        break;

                    case "4": //Reset recipe scale
                        if (!hasCurrentRecipe)  //check if a recipe has been entered.
                        {
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }
                        break;
                    case "5":
                        //exit app
                        break;
                }
            }
        }
    }
}
