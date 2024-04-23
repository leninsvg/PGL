using PGL.Business.Mappers;
using PGL.Model;
using PGL.Persistence.Repositories;

namespace PGL.Business.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public PageModel<PersonModel> GetClients(int page, int pageSize)
    {
        var clients = _personRepository.GetClients(page, pageSize);
        return new PageModel<PersonModel>()
        {
            PageSize = clients.PageSize,
            Page = clients.Page,
            TotalItems = clients.TotalItems,
            TotalPages = clients.TotalPages,
            Items = clients.Items.Select(c => c.MapToPersonModel()).ToList()
        };
    }
    public PageModel<PersonModel> GetClientsSP(int page, int pageSize)
    {
        var clients = _personRepository.GetClientsSP(page, pageSize);
        return new PageModel<PersonModel>()
        {
            PageSize = clients.PageSize,
            Page = clients.Page,
            TotalItems = clients.TotalItems,
            TotalPages = clients.TotalPages,
            Items = clients.Items.Select(c => c.MapToPersonModel()).ToList()
        };
    }
    
    

    public PersonModel CreatClient(PersonModel client)
    {
        var personEntity = client.MapToPersonEntity();
        _personRepository.CreatePerson(personEntity);
        return personEntity.MapToPersonModel();
    }
}