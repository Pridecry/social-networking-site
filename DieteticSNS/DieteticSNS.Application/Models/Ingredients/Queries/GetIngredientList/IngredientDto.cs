namespace DieteticSNS.Application.Models.Ingredients.Queries.GetIngredientList
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }
    }
}
