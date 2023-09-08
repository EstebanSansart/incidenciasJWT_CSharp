namespace Domain.Entities;
public class WorkTool : BaseEntity
{
    public string Name { get; set; }
    public ICollection<IncidenceDetail> IncidenceDetails { get; set; }
}
