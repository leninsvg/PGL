using Microsoft.EntityFrameworkCore;
using PGL.Model;
using PGL.Persistence.Entities;

namespace PGL.Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public PersonRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public PageModel<PersonEntity> GetClients(int page, int pageSize)
    {
        long totalItems = _applicationDbContext.People.Count();
        int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalItems) / Convert.ToDecimal(pageSize)));
        return new PageModel<PersonEntity>()
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = totalPages,
            Items = _applicationDbContext.People.Skip((page - 1) * pageSize).Take(pageSize).ToList()
        };
    }

    public PageModel<PersonEntity> GetClientsSP(int page, int pageSize)
    {
        var items = _applicationDbContext.People.FromSql($"dbo.getClients {page}, {pageSize}").ToList();
        long totalItems = _applicationDbContext.People.Count();
        int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalItems) / Convert.ToDecimal(pageSize)));
        return new PageModel<PersonEntity>()
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = totalPages,
            Items = items
        };
    }

    public void CreatePerson(PersonEntity person)
    {
        this._applicationDbContext.People.Add(person);
        this._applicationDbContext.SaveChanges();
    }
}