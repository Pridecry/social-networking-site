namespace DieteticSNS.Domain.Entities.Base
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
