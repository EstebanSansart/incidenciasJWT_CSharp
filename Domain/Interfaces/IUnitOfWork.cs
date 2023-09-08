namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IAreaRepository Areas { get; }
    IContactCategoryRepository ContactCategories { get; }
    IContactRepository Contacts { get; }
    IContactTypeRepository ContactTypes { get; }
    IDocTypeRepository DocTypes { get; }
    IIncidenceRepository Incidences { get; }
    IIncidenceDetailRepository IncidenceDetails { get; }
    IIncidenceLevelRepository IncidenceLevels { get; }
    IIncidenceTypeRepository IncidenceTypes { get; }
    IPlaceRepository Places { get; }
    IRoleRepository Roles { get; }
    IStateRepository States { get; }
    IUserRepository Users { get; }
    IWorkToolRepository WorkTools { get; }
    Task<int> SaveAsync();
}