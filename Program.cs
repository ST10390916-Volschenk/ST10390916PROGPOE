
using System;
using System.Collections.Generic;

namespace ST10390916PROGPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = null;
            String recipeName, ingredientName, unitOfMeasurement;
            int numOfIngredients = 0;
            int numOfSteps = 0;
            double ingredientScale = 1;
            double ingredientAmount = 1;

            String option = "0";
            while (!option.Equals("5"))
            {
                Console.WriteLine("Select an option below (eg. 2):");
                Console.Write("1. Make a new recipe\n2. View current recipe\n3. Scale your recipe\n4. Reset recipe scale\n5. Clear all recipe data\n6. Exit\n\nYour selction: ");
                option = Console.ReadLine();
                switch (option)
                {
                    //-------------------------------create new recipe--------------------------------------------------------------------

                    case "1":

                        //checking if a recipe already exists

                        if (recipe == null)
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

                        for (int i = 1; i < numOfIngredients + 1; i++)
                        {
                            Console.Write($"Enter ingredient no {i}: ");
                            ingredientName = Console.ReadLine();

                            Console.WriteLine($"Enter the unit of measurement for ingredient no {i}: ");
                            unitOfMeasurement = Console.ReadLine();

                            validNum = false;

                            while (!validNum)
                            {
                                Console.Write($"Enter the quantity of ingredient no {i} in {unitOfMeasurement}: ");

                                try
                                {
                                    ingredientAmount = double.Parse(Console.ReadLine());
                                    validNum = true;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Enter a valid number.");
                                }

                            }
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

                        for (int i = 1; i < numOfSteps + 1; i++)
                        {
                            Console.Write($"Enter step no {i}: ");
                            steps.Add(Console.ReadLine());
                        }

                        //create recipe and display it using ToString
                        recipe = new Recipe(recipeName, numOfIngredients, ingredients, ingredientScale, numOfSteps, steps);

                        Console.WriteLine("New recipe created.");

                        recipe.ToString();

                        break;

                    //----------------------------------View the current recipe---------------------------------------

                    case "2":
                        if (recipe == null)  //check if a recipe has been entered.
                        {
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }

                        recipe.ToString();
                        break;

                    //------------------------------Scale recipe ingredients-------------------------------------------

                    case "3":
                        if (recipe == null) //check if a recipe has been entered.
                        {
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the scale to change ingredient quantities: ");

                            try
                            {
                                ingredientScale = double.Parse(Console.ReadLine());
                                validNum = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid number.");
                            }
                        }

                        recipe.IngredientScale = ingredientScale;

                        Console.WriteLine($"Recipe scale changed to {ingredientScale}");
                        recipe.ToString();

                        break;

                    //-----------------------------Reset Recipe Scale--------------------------------------------------------------

                    case "4":
                        if (recipe == null) //check if a recipe has been entered.
                        {
                            Console.WriteLine("You don't currently have a recipe saved.");
                            break;
                        }

                        recipe.IngredientScale = 1;
                        Console.WriteLine("Recipe scale reset successful.");
                        recipe.ToString();

                        break;

                    //-----------------------------Clear all recipe data--------------------------------------------------------------

                    case "5":
                        recipe = null;
                        break;

                    //----------------------------------Exit application----------------------------------------------------------------

                    case "6":
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}
