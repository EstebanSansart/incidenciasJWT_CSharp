namespace Domain.Entities;
public class ContactType : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}
