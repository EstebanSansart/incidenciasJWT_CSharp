namespace ApiIncidenciasI.Dtos;
public class WorkToolDto
{
    public int Id { get; set; }
    public int Name { get; set; }
    public List<IncidenceDetailDto> IncidenceDetails { get; set; }
}