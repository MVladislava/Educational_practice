using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using TestAspCSDb.Models.Domains;

namespace ISA.Models.AddVM
{
    public class AddCarViewModel
    {
        [StringLength(6)]
        [Required(ErrorMessage = "Введите регистрационный номер!")]
        public string RegNumber { get; set; } = null!;
        [StringLength(6)]
        [Required(ErrorMessage = "Введите бренд автомобиля!")]
        public string Brand { get; set; } = null!;
        [StringLength(6)]
        [Required(ErrorMessage = "Введите модель автомобиля!")]
        public string Model { get; set; } = null!;
        [Required]
        public Guid ClientId { get; set; }
    }
}
