namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientsList
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }
    }
}
