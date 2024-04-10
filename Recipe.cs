using System;
using System.Collections.Generic;

namespace ST10390916PROGPOE
{
    internal class Recipe
    {
        public String recipeName { get; set; }
        public String numOfIngredients { get; set; }
        public List<Ingredient> ingredients { get; set; }       //list of ingredients in recipe
        public List<double> ingredientQuantity { get; set; }    //quantity of each ingredient
        public double ingredientScale { get; set; }             //For scaling the quantities of ingredients
        public int numOfSteps { get; set; }
        public List<String> recipeSteps { get; set; }           //List of the recipe steps
    }
}
