using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PGL.Persistence.Entities;

[Table("Person")]
public class PersonEntity : BaseEntity
{
    [MaxLength(64)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(64)]
    [Required]
    public string LastName { get; set; }

    [MaxLength(64)]
    [Required]
    public string Phone { get; set; }
    
    [Required]
    public string Country { get; set; }
}