using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    private readonly ApiIncidenciasIContext _context;

    public ContactRepository(ApiIncidenciasIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await _context.Contacts
                            .ToListAsync();
    }
}