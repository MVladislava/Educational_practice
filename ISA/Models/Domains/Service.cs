namespace TestAspCSDb.Models.Domains
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
