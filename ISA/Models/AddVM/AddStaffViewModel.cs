namespace ISA.Models.AddVM
{
    public class AddStaffViewModel
    {
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public Guid PostsId { get; set; }
    }
}
