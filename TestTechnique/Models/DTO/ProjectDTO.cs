namespace TestTechnique.Models.DTO;

public class ProjectDTO
{
    public string Uuid { get; set; } 
    public DateTime Date { get; set; } 
    public string WorkingHours { get; set; }
    public string WorkAt { get; set; } 
    public int? TemperatureMorning { get; set; } 
    public int? TemperatureAfternoon { get; set; } 
    public string Weather { get; set; } 
}
