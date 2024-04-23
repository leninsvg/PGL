using PGL.Model;
using PGL.Persistence.Entities;

namespace PGL.Business.Mappers;

public static class PersonMapper
{
    public static PersonModel MapToPersonModel(this PersonEntity person)
    {
        return new PersonModel
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Country = person.Country,
            Phone = person.Phone
        };
    }
    
    public static PersonEntity MapToPersonEntity(this PersonModel person)
    {
        return new PersonEntity()
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Country = person.Country,
            Phone = person.Phone
        };
    }
}