namespace ApiIncidenciasI.Dtos;
public class DocTypeDto
{
    public int DocTypeId { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public List<ContactTypeDto> ContactTypes { get; set; }
    public List<UserDto> Users { get; set; }
}