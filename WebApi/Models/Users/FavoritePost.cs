using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Users;

public class FavoritePost
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public long ApartmentId { get; set; }
    public long UserId { get; set; }
    public virtual required User User { get; set; }
}
