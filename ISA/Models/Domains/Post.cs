namespace TestAspCSDb.Models.Domains
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
