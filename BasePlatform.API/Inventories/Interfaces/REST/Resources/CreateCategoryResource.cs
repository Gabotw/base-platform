namespace BasePlatform.API.Inventories.Interfaces.REST.Resources;

public record CreateCategoryResource(
    string Name,
    int GroupId,
    string Description,
    string ReferenceImageUrl
    );