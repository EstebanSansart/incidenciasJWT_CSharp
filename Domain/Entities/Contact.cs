namespace Domain.Entities;
public class Contact : BaseEntity
{
    public string Description { get; set; }
    public int IdUserFk { get; set; }
    public User User { get; set; }
    public int IdContactTypeFk { get; set; }
    public ContactType ContactType { get; set; }
    public int IdContactCategoryFk { get; set; }
    public ContactCategory ContactCategory { get; set; }
}
