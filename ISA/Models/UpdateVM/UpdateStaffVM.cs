namespace ISA.Models.UpdateVM
{
    public class UpdateStaffVM
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public Guid PostsId { get; set; }
    }
}
