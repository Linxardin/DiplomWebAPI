using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiplomWebAPI.Models
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set;}
        public int Rooms { get; set;}
        public string Type { get; set;}
        public int SellerId { get; set; }

    }
}
