using PGL.Model;
using PGL.Persistence.Entities;

namespace PGL.Persistence.Repositories;

public interface IPersonRepository
{
    PageModel<PersonEntity> GetClients(int page, int pageSize);
    PageModel<PersonEntity> GetClientsSP(int page, int pageSize);
    void CreatePerson(PersonEntity person);
}