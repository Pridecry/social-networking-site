namespace DieteticSNS.Domain.Entities
{
    public class RecipeReport : Report
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
