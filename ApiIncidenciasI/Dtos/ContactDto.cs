namespace ApiIncidenciasI.Dtos;
public class ContactDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public List<UserDto> Users { get; set; } 
    public List<ContactTypeDto> ContactTypes { get; set; }   
    public List<ContactCategoryDto> ContactCategories { get; set; }
}