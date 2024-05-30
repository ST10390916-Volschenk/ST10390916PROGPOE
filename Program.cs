// Weylin Volschenk
// ST10390916
// Group 1

// References: 
//              https://www.w3schools.com/cs/cs_syntax.php
//              https://code-maze.com/sort-list-by-object-property-dotnet/
//              https://stackoverflow.com/questions/42961712/how-to-include-image-as-markdown-in-visual-studio-code


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ST10390916PROGPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            String recipeName = null;
            String ingredientName = null;
            String unitOfMeasurement = null;
            int numOfIngredients = 0;
            int numOfSteps = 0;
            double ingredientScale = 1;
            double ingredientAmount = 1;
            double ingredientCalories = 0;
            string ingredientFoodGroup = null;
            int recipeToView = -1;

            Console.WriteLine("Welcome to your recipe book!", Console.ForegroundColor = ConsoleColor.Magenta);
            Console.ForegroundColor = ConsoleColor.White;

            String option = "0";
            while (!option.Equals("6"))
            {
                Console.WriteLine("\nSelect an option below (eg. 2):");
                Console.Write("1. Make a new recipe\n2. View a recipe\n3. Scale a recipe\n4. Reset a recipe's scale\n5. Delete a recipe\n6. Exit\n\nYour selection: ");
                option = Console.ReadLine();
                switch (option)
                {
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //-------------------------------create new recipe--------------------------------------------------------------------
                    //User enters "1" to create a new recipe that will be added to the list of recipes.
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    case "1":

                        //Collect recipe information

                        //----------------------------------------Enter recipe name----------------------------------------------------

                        Console.Write("Enter your recipe name: ");
                        recipeName = Console.ReadLine();

                        while (recipeName.Equals(""))
                        {
                            Console.Write("Enter a valid recipe name: ", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            recipeName = Console.ReadLine();
                        }

                        //--------------------------------------Enter number of ingredients----------------------------------------------

                        bool validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of ingredients: ");

                            try
                            {
                                numOfIngredients = int.Parse(Console.ReadLine());
                                if (numOfIngredients >= 1)
                                {
                                    validNum = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid number.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }

                        //------------------------------------Enter list of ingredients-----------------------------------------------------

                        List<Ingredient> ingredients = new List<Ingredient>();

                        for (int i = 1; i < numOfIngredients + 1; i++)
                        {
                            Console.Write($"Enter the name of ingredient no {i}: ");
                            ingredientName = Console.ReadLine();

                            while (ingredientName.Equals(""))
                            {
                                Console.Write("Enter a valid ingredient name: ", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                                ingredientName = Console.ReadLine();
                            }

                            Console.Write($"Enter the unit of measurement for ingredient no {i}: ");
                            unitOfMeasurement = Console.ReadLine();

                            while (unitOfMeasurement.Equals(""))
                            {
                                Console.Write("Enter a valid unit of measurement. e.g. ml, tbsp, g: ", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                                unitOfMeasurement = Console.ReadLine();
                            }

                            validNum = false;

                            while (!validNum)
                            {
                                Console.Write($"Enter the quantity of ingredient no {i} in {unitOfMeasurement}: ");

                                try
                                {
                                    ingredientAmount = double.Parse(Console.ReadLine());
                                    if (ingredientAmount >= 1)
                                    {
                                        validNum = true;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Enter a valid number.", Console.ForegroundColor = ConsoleColor.Red);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }

                            //-------------------------------------Enter calories-----------------------------------------------------------

                            validNum = false;

                            while (!validNum)
                            {
                                Console.WriteLine("A colorie is a unit of energy that one can get from consuming food or drinks.");
                                Console.Write($"Enter the number of calories in ingredient no {i}: ");

                                try
                                {
                                    ingredientCalories = double.Parse(Console.ReadLine());
                                    if (ingredientCalories > 0)
                                    {
                                        validNum = true;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Enter a valid number.", Console.ForegroundColor = ConsoleColor.Red);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                            }

                            //----------------------------------------------Enter food group----------------------------------------------

                            Console.WriteLine("A food group is a collection of foods that share similar nutritional properties or biological classifications.");
                            Console.Write($"Enter the food group ingredient no {i} belongs to: ");
                            ingredientFoodGroup = Console.ReadLine();

                            while (ingredientFoodGroup.Equals(""))
                            {
                                Console.Write("Enter a valid food group e.g. protein: ", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                                ingredientFoodGroup = Console.ReadLine();
                            }

                            ingredients.Add(new Ingredient(ingredientName, unitOfMeasurement, ingredientAmount, ingredientCalories, ingredientFoodGroup));
                        }

                        //-------------------------------Scale of recipe ingredients---------------------------------------------------------------
                        //Default/initial scale will be 1

                        ingredientScale = 1;

                        //------------------------------------------Enter number of steps----------------------------------------------------------

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of steps in your recipe: ");

                            try
                            {
                                numOfSteps = int.Parse(Console.ReadLine());
                                if (numOfSteps >= 1)
                                {
                                    validNum = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid number.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }

                        //--------------------------------Enter list of steps-------------------------------------------------

                        List<String> steps = new List<String>();
                        String step;

                        for (int i = 1; i < numOfSteps + 1; i++)
                        {
                            Console.Write($"Enter step no {i}: ");
                            step = Console.ReadLine();


                            while (step.Equals(""))
                            {
                                Console.Write("Enter a valid step name: ", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                                step = Console.ReadLine();
                            }

                            steps.Add(step);
                        }

                        //------------------------------Create recipe and display it using ToString-------------------------------

                        recipes.Add(new Recipe(recipeName, numOfIngredients, ingredients, ingredientScale, numOfSteps, steps));

                        Console.WriteLine("\nNew recipe created.", Console.ForegroundColor = ConsoleColor.DarkGreen);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine(recipes[recipes.Count - 1].ToString());

                        break;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //----------------------------------View a recipe-------------------------------------------------------------------------------
                    //User enters "2" to view the list of recipes and has the option to view a single recipe
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    case "2":
                        if (recipes.Count == 0)  //check if a recipe exists
                        {
                            Console.WriteLine("You don't currently have any recipes saved.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        //Sort list alphabetically by name using OrderBy LINQ method
                        recipes.OrderBy(x => x.RecipeName).ToList();

                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + recipes[i].RecipeName);
                        }

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of the recipe you want to view: ");

                            try
                            {
                                recipeToView = int.Parse(Console.ReadLine()) - 1;
                                if ((recipeToView >= 0) && (recipeToView < recipes.Count))
                                {
                                    validNum = true;
                                    Console.WriteLine(recipes[recipeToView].ToString());
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid option.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        break;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //------------------------------Scale recipe ingredients-------------------------------------------------------------------
                    //User enters "3" to scale the list of recipes and has the option to view a single recipe
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    case "3":
                        if (recipes.Count == 0)  //check if a recipe exists
                        {
                            Console.WriteLine("You don't currently have any recipes saved.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        //Sort list alphabetically by name using OrderBy LINQ method
                        recipes.OrderBy(x => x.RecipeName).ToList();

                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + recipes[i].RecipeName);
                        }

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of the recipe you want to scale: ");

                            try
                            {
                                recipeToView = int.Parse(Console.ReadLine()) - 1;
                                if ((recipeToView >= 0) && (recipeToView < recipes.Count))
                                {
                                    validNum = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid option.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //----------------------Confirm selection choice-------------------------------------------

                        Console.WriteLine(recipes[recipeToView].ToString());

                        bool validAns = false;

                        while (!validAns)
                        {
                            Console.WriteLine("Do you want to scale the recipe above? Y/N");
                            String answer = Console.ReadLine();

                            if (answer.ToLower().Equals("y"))
                            {
                                validAns = true;
                                validNum = false;

                                while (!validNum)
                                {
                                    Console.Write("Enter the number you want to scale the ingredient quantities with: ");

                                    try
                                    {
                                        ingredientScale = double.Parse(Console.ReadLine());
                                        if (ingredientScale > 0)
                                        {
                                            validNum = true;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Enter a valid number.", Console.ForegroundColor = ConsoleColor.Red);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }

                                recipes[recipeToView].IngredientScale = ingredientScale;

                                Console.WriteLine($"Recipe scale changed to {ingredientScale}", Console.ForegroundColor = ConsoleColor.DarkGreen);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(recipes[recipeToView].ToString());
                            }
                            else if (answer.ToLower().Equals("n"))
                            {
                                validAns = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }

                        break;

                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //-----------------------------Reset Recipe Scale--------------------------------------------------------------
                    //User enters "4" to view the list of recipes and has the option to reset a single recipe's scale
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    case "4":
                        if (recipes.Count == 0) //check if a recipe exists
                        {
                            Console.WriteLine("You don't currently have a recipe saved.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        //Sort list alphabetically by name using OrderBy LINQ method
                        recipes.OrderBy(x => x.RecipeName).ToList();

                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + recipes[i].RecipeName);
                        }

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of the recipe you want to reset the scale for: ");

                            try
                            {
                                recipeToView = int.Parse(Console.ReadLine()) - 1;
                                if ((recipeToView >= 0) && (recipeToView < recipes.Count))
                                {
                                    validNum = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid option.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //----------------------Confirm selection choice-------------------------------------------

                        Console.WriteLine(recipes[recipeToView].ToString());

                        validAns = false;

                        while (!validAns)
                        {
                            Console.WriteLine("Do you want to reset the scale for the recipe above? Y/N");
                            String answer = Console.ReadLine();

                            if (answer.ToLower().Equals("y"))
                            {
                                validAns = true;
                                recipes[recipeToView].IngredientScale = 1;
                                Console.WriteLine("Recipe scale reset successful.", Console.ForegroundColor = ConsoleColor.DarkGreen);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(recipes[recipeToView].ToString());
                            }
                            else if (answer.ToLower().Equals("n"))
                            {
                                validAns = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        break;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //-----------------------------Delete a recipe--------------------------------------------------------------
                    //User enters "5" to view the list of recipes and has the option to delete a single recipe
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    case "5":

                        if (recipes.Count == 0) //check if a recipe exists
                        {
                            Console.WriteLine("You don't currently have a recipe saved.", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        //Sort list alphabetically by name using OrderBy LINQ method
                        recipes.OrderBy(x => x.RecipeName).ToList();

                        for (int i = 0; i < recipes.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + recipes[i].RecipeName);
                        }

                        validNum = false;

                        while (!validNum)
                        {
                            Console.Write("Enter the number of the recipe you want to delete: ");

                            try
                            {
                                recipeToView = int.Parse(Console.ReadLine()) - 1;
                                if ((recipeToView >= 0) && (recipeToView < recipes.Count))
                                {
                                    validNum = true;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Enter a valid option.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        //----------------------Confirm selection choice-------------------------------------------

                        Console.WriteLine(recipes[recipeToView].ToString());

                        validAns = false;

                        while (!validAns)
                        {
                            Console.WriteLine("Do you want to delete the recipe above? Y/N");
                            String answer = Console.ReadLine();

                            if (answer.ToLower().Equals("y"))
                            {
                                validAns = true;
                                recipes.Remove(recipes[recipeToView]);
                                Console.WriteLine("Recipe deletion successful.", Console.ForegroundColor = ConsoleColor.DarkGreen);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (answer.ToLower().Equals("n"))
                            {
                                validAns = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.", Console.ForegroundColor = ConsoleColor.Red);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                        break;

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //----------------------------------Exit application----------------------------------------------------------------
                    //User enters "6" to exit the application
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    case "6":
                        Environment.Exit(0);
                        break;

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //Return a message if user does not enter a valid menu option
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    default:
                        Console.WriteLine("Enter a valid option. Eg. 1", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                }
            }
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//

