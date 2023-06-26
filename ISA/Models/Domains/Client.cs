using System.ComponentModel.DataAnnotations;

namespace TestAspCSDb.Models.Domains
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public DateTime DateOfB { get; set; }
        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
