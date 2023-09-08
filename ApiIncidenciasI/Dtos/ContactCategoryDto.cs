namespace ApiIncidenciasI.Dtos;
public class ContactCategoryDto
{
    public int ContactCategoryId { get; set; }
    public string ContactCategoryName { get; set; }
    public List<ContactDto> Contacts { get; set; }  
}