namespace WebApp.Entities;

public class Holiday
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool IsRecurring { get; set; }
    public string RecurrencePattern { get; set; } = string.Empty;
}