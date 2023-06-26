//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestAspCSDb.Models.Domains
{

    public partial class Order
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public Guid CarsId { get; set; }
        public Guid ClientsId { get; set; }
        public Guid ServicesId { get; set; }
        public Guid SparesId { get; set; }
        public Guid StaffsId { get; set; }

        public Car Cars { get; set; }
        public Client Clients { get; set; }
        public Service Services { get; set; }
        public Spare Spares { get; set; }
        public Staff Staffs { get; set; }
    }
}
