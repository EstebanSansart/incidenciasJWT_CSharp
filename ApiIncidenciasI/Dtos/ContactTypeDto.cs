namespace ApiIncidenciasI.Dtos;
public class ContactTypeDto
{
    public int ContactTypeId { get; set; }
    public string ContactTypeName { get; set; }
    public string ContactTypeDescription { get; set; }
    public List<ContactDto> Contacts { get; set; }

}