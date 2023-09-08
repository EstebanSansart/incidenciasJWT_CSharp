namespace Domain.Entities;
public class IncidenceDetail : BaseEntity
{
    public string Description { get; set; }
    public int IdWorkToolFk { get; set; }
    public WorkTool WorkTool { get; set; }
    public int IdIncidenceTypeFk { get; set; }
    public IncidenceType IncidenceType { get; set; }
    public int IdIncidenceLevelFk { get; set; }
    public IncidenceLevel IncidenceLevel { get; set; }
    public int IdStateFk { get; set; }
    public State State { get; set; }
}