// Weylin Volschenk
// ST10390916
// Group 1

// References: 
//             https://www.w3schools.com/cs/cs_syntax.php

using System;
using System.Collections.Generic;

namespace ST10390916PROGPOE
{
    internal class Recipe
    {
        public String RecipeName { get; set; }
        public int NumOfIngredients { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();     //list of ingredients in recipe
        public double IngredientScale { get; set; }                                     //For scaling the quantities of ingredients
        public int NumOfSteps { get; set; }
        public List<String> RecipeSteps { get; set; }                                   //List of the recipe steps

        /////////////////////////////////////////Constructor/////////////////////////////////////////////////////////////////

        public Recipe(string recipeName, int numOfIngredients, List<Ingredient> ingredients, double ingredientScale, int numOfSteps, List<string> recipeSteps)
        {
            RecipeName = recipeName;
            NumOfIngredients = numOfIngredients;
            Ingredients = ingredients;
            IngredientScale = ingredientScale;
            NumOfSteps = numOfSteps;
            RecipeSteps = recipeSteps;
        }

        //////////////////////ToString method for displaying recipe////////////////////////////////////////////////////////

        public override String ToString()
        {
            String msg = "-------------------------------------------------\n";
            msg += $"Your recipe:\n{RecipeName}\n\nCurrent ingredient scale: x{IngredientScale}\nIngredients:\n\n";

            foreach (var ingredient in Ingredients)
            {
                msg += ingredient.IngredientName + " " + (ingredient.IngredientAmount * IngredientScale) + " " + ingredient.UnitOfMeasurement + "\n";
            }

            msg += "\nSteps: \n\n";

            for (int i = 1; i < NumOfSteps + 1; i++)
            {
                msg += i + ". " + RecipeSteps[i - 1].ToString() + "\n";
            }

            msg += "\nEnjoy\n";
            msg += "-------------------------------------------------";
            return msg;
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//

