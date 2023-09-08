namespace Domain.Entities;
public class Area : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<UserArea> UserAreas { get; set; }
    public ICollection<Place> Places { get; set; }
    public ICollection<Incidence> Incidences { get; set; }
}
