namespace ApiIncidenciasI.Dtos;
public class IncidenceLevelDto
{
    public int IncidenceLevelId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IncidenceDetailDto> IncidenceDetails { get; set; }
}