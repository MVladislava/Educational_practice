namespace TestAspCSDb.Models.Domains
{
    public class Staff
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public Guid PostsId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual Post Posts { get; set; }
    }
}
