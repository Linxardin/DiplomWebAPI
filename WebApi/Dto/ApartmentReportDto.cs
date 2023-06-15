using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto;

public class ApartmentReportDto
{
    public class ReportDto
    {
        public required Guid Id { get; init; }
        public required long UserId { get; set; }
    
        public required long ApartmentId { get; set; }
    
        public required string Description { get; set; }
        public DateTime ReportCreatedAt { get; set; } 
    }
    
    public class CreateReportDto
    {
        [Required]
        public required long UserId { get; set; }
        [Required]
        public required long ApartmentId { get; set; }
        [Required]
        public required string Description { get; set; }
    }
}
