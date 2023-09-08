namespace ApiIncidenciasI.Dtos;
public class ContactCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ContactDto> Contacts { get; set; }  
}