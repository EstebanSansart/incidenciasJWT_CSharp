namespace ApiIncidenciasI.Dtos;
public class AreaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public List<PlaceDto> Places { get; set; }  
    public List<IncidenceDto> Incidences { get; set; } 
}