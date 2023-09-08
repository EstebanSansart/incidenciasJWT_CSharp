namespace Domain.Entities;
public class IncidenceLevel : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<IncidenceDetail> IncidenceDetails { get; set; }
}