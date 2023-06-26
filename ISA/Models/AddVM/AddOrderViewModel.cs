using TestAspCSDb.Models.Domains;

namespace ISA.Models.AddVM
{
    public class AddOrderViewModel
    {
        public DateTime Data { get; set; }
        public Guid CarsId { get; set; }
        public Guid ClientsId { get; set; }
        public Guid ServicesId { get; set; }
        public Guid SparesId { get; set; }
        public Guid StaffsId { get; set; }
    }
}
