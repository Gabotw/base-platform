using BasePlatform.API.Inventories.Domain.Model.ValueObjects;

namespace BasePlatform.API.Inventories.Interfaces.REST.Resources;

public record CategoryResource(
    int Id,
    string Name,
    EGroup GroupId,
    string Description,
    string ReferenceImageUrl
    );