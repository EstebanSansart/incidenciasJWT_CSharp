using Domain.Entities;

namespace ApiIncidenciasI.Dtos;
public class AreaDto
{
    public int AreaId { get; set; }
    public string AreaName { get; set; }
    public string AreaDescription { get; set; }
    public List<PlaceDto> Places { get; set; }  
    public List<IncidenceDto> Incidences { get; set; }  
}