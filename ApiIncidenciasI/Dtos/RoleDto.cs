namespace ApiIncidenciasI.Dtos;
public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserDto> Users { get; set; }
}