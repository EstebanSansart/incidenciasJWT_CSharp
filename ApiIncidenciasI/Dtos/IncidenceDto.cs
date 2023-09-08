namespace ApiIncidenciasI.Dtos;
public class IncidenceDto
{
    public int IncidenceId { get; set; }
    public string Description { get; set; }
    public DateTime IncidenceDate { get; set; }
    public List<StateDto> States { get; set; }
    public List<AreaDto> Areas { get; set; }
    public List<PlaceDto> Places { get; set; }
    public List<IncidenceDetailDto> IncidenceDetails { get; set; }
}