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
    public string Surname { get; set; } = string.Empty;

    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [EmailAddress]
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime Created { get; set; } = DateTime.Now;

    [Required]
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}