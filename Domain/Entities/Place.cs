namespace Domain.Entities;
public class Place : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int IdAreaFk { get; set; }
    public Area Area { get; set; }
    public ICollection<Incidence> Incidences { get; set; }
}
