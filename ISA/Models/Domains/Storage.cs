namespace TestAspCSDb.Models.Domains
{
    public class Storage
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Spare> Spares { get; set; }
    }
}
