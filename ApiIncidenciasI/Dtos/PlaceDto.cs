namespace ApiIncidenciasI.Dtos;
public class PlaceDto
{
    public int PlaceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<AreaDto> Areas { get; set; }
    public List<IncidenceDto> Incidences { get; set; }
}