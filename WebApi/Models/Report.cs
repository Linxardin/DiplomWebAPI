using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Users;

namespace WebApi.Models;

public class Report
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required long UserId { get; set; }
    public virtual User User { get; set; }
    
    public required long ApartmentId { get; set; }
    public virtual Apartment Apartment { get; set; }
    
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? ResolvedAt { get; set; }
}
