// Weylin Volschenk
// ST10390916
// Group 1

// References: 
//             https://www.w3schools.com/cs/cs_syntax.php

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10390916PROGPOE
{
    internal class Ingredient
    {
        public String IngredientName {  get; set; }
        public String UnitOfMeasurement { get; set; }
        public double IngredientAmount { get; set; }

        public Ingredient(string ingredientName, string unitOfMeasurement, double ingredientAmount)
        {
            this.IngredientName = ingredientName;
            this.UnitOfMeasurement = unitOfMeasurement;
            this.IngredientAmount = ingredientAmount;
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...------------------------------------------------------//

