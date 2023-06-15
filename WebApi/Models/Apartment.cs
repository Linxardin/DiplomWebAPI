using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Users;

namespace WebApi.Models
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public required ApartmentStateType ApartmentStateType { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set;} = string.Empty;
        public required int Price { get; set; }
        public required short Floor { get; set; }
        public required byte Rooms { get; set;}
        public required float TotallyArea { get; set; }
        public required float CeilingHeight { get; set; }
        public required string RenovationKind { get; set; }
        public required float Area { get; set; }
        public required string HaveBalcony { get; set; }
        public required string Address { get; set; }
        public required byte ToiletsCount { get; set; }
        public required int Floors { get; set; }
        public required float KitchenSquare { get; set; }
        public required string PostType { get; set; }
        public bool IsClosed { get; set; }
        public required string ApartmentType { get; set; }
        public ICollection<DocumentStore>? Files { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }

    public enum ApartmentStateType
    {
        Buy,
        Rent
    }
}
