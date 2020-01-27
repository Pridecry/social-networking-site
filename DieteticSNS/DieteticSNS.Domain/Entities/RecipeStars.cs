namespace DieteticSNS.Domain.Entities
{
    public class RecipeStars : Stars
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
