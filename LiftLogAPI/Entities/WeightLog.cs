namespace LiftLogAPI.Entities
{
    public class WeightLog
    {
        public required int Id { get; set; }
        public float Weight { get; set; }
        public required DateTime Date { get; set; }
        public required int ExerciseId { get; set; }

    }
}
