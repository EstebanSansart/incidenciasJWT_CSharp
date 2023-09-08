namespace Domain.Entities;
public class DocType : BaseEntity
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<User> Users { get; set; }
}