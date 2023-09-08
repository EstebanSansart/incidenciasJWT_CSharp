namespace Domain.Entities;
public class State : BaseEntity
{
    public string Description { get; set; }
    public ICollection<Incidence> Incidences { get; set; }
    public ICollection<IncidenceDetail> IncidenceDetails { get; set; }
}
