using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto;

public class DocumentStoreDto
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}

public class CreateDocumentStoreDto
{
    [Required]
    public string Url { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
}
