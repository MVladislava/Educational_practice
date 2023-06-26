using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestAspCSDb.Models.Domains
{
    public class Car
    {
        public Guid Id { get; set; }
        public string RegNumber { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

    }
}
