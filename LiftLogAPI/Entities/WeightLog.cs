namespace LiftLogAPI.Entities
{
    public class WeightLog
    {
        public required int Id { get; set; }
        public required DateTime Date { get; set; }
        public required Exercise Exercise { get; set; }

    }
}
