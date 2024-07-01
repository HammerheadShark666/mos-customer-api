using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservice.Customer.Api.Domain;

[Table("MSOS_Customer")]
public class Customer
{
    [Key] 
    public Guid Id { get; set; }

    [MaxLength(30)]
    [Required]
    public string Surname { get; set; }

    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; }

    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime Created { get; set; } = DateTime.Now;

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}