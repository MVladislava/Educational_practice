namespace ISA.Models.UpdateVM
{
    public class UpdateSpareVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid StorageId { get; set; }
    }
}
