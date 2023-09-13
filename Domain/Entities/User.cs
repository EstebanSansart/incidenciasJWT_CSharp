namespace Domain.Entities;
public class User : BaseEntity
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int IdDocTypeFk { get; set; }
    public DocType DocType { get; set; }
    public int IdRoleFk { get; set; }
    public Role Roles { get; set; }
    public ICollection<Incidence> Incidences { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<UserArea> UserAreas { get; set; }
}