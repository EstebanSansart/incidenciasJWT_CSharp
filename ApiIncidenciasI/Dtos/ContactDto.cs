namespace ApiIncidenciasI.Dtos;
public class ContactDto
{
    public int ContactId { get; set; }
    public string ContactDescription { get; set; }
    public List<UserDto> Users { get; set; } 
    public List<ContactTypeDto> ContactTypes { get; set; }   
    public List<ContactCategoryDto> ContactCategories { get; set; }
}