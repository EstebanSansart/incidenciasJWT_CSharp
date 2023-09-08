namespace Domain.Entities;
public class ContactCategory : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}
