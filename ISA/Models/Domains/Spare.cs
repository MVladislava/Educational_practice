namespace TestAspCSDb.Models.Domains
{
    public class Spare
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid StoragesId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Storage Storages { get; set; }
    }
}
