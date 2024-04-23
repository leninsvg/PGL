using PGL.Model;

namespace PGL.Business.Services;

public interface IPersonService
{
    PageModel<PersonModel> GetClients(int page, int pageSize);
    PageModel<PersonModel> GetClientsSP(int page, int pageSize);
    PersonModel CreatClient(PersonModel client);
}