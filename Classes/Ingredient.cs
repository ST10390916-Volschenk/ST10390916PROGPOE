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
        public String IngredientAmount { get; set; }

        public Ingredient(string ingredientName, string unitOfMeasurement, string ingredientAmount)
        {
            this.IngredientName = ingredientName;
            this.UnitOfMeasurement = unitOfMeasurement;
            this.IngredientAmount = ingredientAmount;
        }

        public override string ToString()
        {
            string msg = IngredientName + " " + IngredientAmount + " " + UnitOfMeasurement;
            return msg;
        }
    }
}
