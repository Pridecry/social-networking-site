using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DieteticSNS.WebUI.Models.Ingredients
{
    public class UpdateIngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrate { get; set; }
        public int? Fat { get; set; }
        public int? Calories { get; set; }
    }
}
