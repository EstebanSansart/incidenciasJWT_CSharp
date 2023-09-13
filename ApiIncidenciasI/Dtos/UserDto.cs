namespace ApiIncidenciasI.Dtos;
public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public List<DocTypeDto> DocTypes { get; set; }
    public List<RoleDto> Roles { get; set; }
    public List<IncidenceDto> Incidences { get; set; }
    public List<ContactDto> Contacts { get; set; }
}