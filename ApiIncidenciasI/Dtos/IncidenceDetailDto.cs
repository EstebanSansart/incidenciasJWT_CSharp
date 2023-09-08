namespace ApiIncidenciasI.Dtos;
public class IncidenceDetailDto
{
    public int IncidenceDetailId { get; set; }
    public string Description { get; set; }
    public List<WorkToolDto> WorkTools { get; set; }
    public List<IncidenceTypeDto> IncidenceTypes { get; set; }
    public List<IncidenceLevelDto> IncidenceLevels { get; set; }
    public List<StateDto> States { get; set; }
}