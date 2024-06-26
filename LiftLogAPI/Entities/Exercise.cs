namespace LiftLogAPI.Entities
{
    public class Exercise
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
