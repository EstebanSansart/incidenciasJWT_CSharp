namespace ApiIncidenciasI.Dtos;
public class IncidenceTypeDto
{
    public int IncidenceTypeId { get; set; }
    public int Name { get; set; }
    public string Description { get; set; }
    public List<IncidenceDetailDto> IncidenceDetails { get; set; }
}