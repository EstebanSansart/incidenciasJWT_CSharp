namespace Domain.Entities;
public class Incidence : BaseEntity
{
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public int IdStateFk { get; set; }
    public State State { get; set; }
    public int IdUserFk { get; set; }
    public User User { get; set; }
    public int IdAreaFk { get; set; }
    public Area Area { get; set; }
    public int IdPlaceFk { get; set; }
    public Place Place { get; set; }

    public ICollection<IncidenceDetail> IncidenceDetails { get; set; }
}
