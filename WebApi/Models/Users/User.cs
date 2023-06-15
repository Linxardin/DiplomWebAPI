using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Users
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required string Name { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public required string Email { get; set; }
        public string? Phone { get; set; }

        public UserType Type { get; set; }
        
        public DateTime? ModifiedAt { get; set; }
        
        public virtual ICollection<DocumentStore>? UserDocuments { get; set; }
        
        public virtual ICollection<FavoritePost>? FavoritePosts { get; set; }
        public virtual ICollection<Apartment>? Apartments { get; set; }
        public bool IsUserAdmin { get; set; }
    }
}
