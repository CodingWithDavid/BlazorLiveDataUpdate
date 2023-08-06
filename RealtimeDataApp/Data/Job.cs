namespace RealtimeDataApp.Data
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
    }
}
