namespace BlazorApp1.Entities
{
    public class Cleaner : Employee
    {
        
        public List<CleanerTimeSlot> WorkingTimeSlots { get; set; } = new List<CleanerTimeSlot>();

    }
}
