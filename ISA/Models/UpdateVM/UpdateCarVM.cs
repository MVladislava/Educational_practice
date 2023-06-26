namespace ISA.Models.UpdateVM
{
    public class UpdateCarVM
    {
        public Guid Id { get; set; }
        public string RegNumber { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public Guid ClientId { get; set; }

    }
}
