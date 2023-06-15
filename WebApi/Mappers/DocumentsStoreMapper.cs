using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Mappers;

public static class DocumentStoreMapper
{
    public static DocumentStoreDto ToDto(this DocumentStore store)
    {
        return new DocumentStoreDto
        {
            Id = store.Id,
            Url = store.URL,
            Type = store.Type
        };
    }

    public static DocumentStore ToModel(this DocumentStoreDto store)
    {
        return new DocumentStore
        {
            Id = store.Id,
            URL = store.Url,
            Type = store.Type
        };
    }
    
    public static DocumentStore ToModel(this CreateDocumentStoreDto store)
    {
        return new DocumentStore
        {
            URL = store.Url,
            Type = store.Type
        };
    }
}
