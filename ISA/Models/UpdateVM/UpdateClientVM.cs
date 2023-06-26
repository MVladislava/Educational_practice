using System.ComponentModel.DataAnnotations;

namespace ISA.Models.UpdateVM
{
    public class UpdateClientVM
    {
        public Guid Id { get; set; }
        [StringLength(25)]
        [Required(ErrorMessage = "Введите фамилию!")]
        public string Surname { get; set; } = null!;
        [StringLength(25)]
        [Required(ErrorMessage = "Введите имя!")]
        public string Name { get; set; } = null!;
        [StringLength(25)]
        [Required(ErrorMessage = "Введите отчество!")]
        public string? Patronymic { get; set; }
        [Required(ErrorMessage = "Введите дату!")]
        public DateTime DateOfB { get; set; }
    }
}
