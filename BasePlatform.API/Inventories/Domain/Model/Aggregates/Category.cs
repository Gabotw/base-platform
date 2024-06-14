
using BasePlatform.API.Inventories.Domain.Model.ValueObjects;

namespace BasePlatform.API.Inventories.Domain.Model.Aggregates;

public partial class Category
{
    public Category(string name, EGroup groupId, string description,string referenceImageUrl)
    {
        this.Name = name;
        this.GroupId = groupId;
        this.Description = description;
        this.ReferenceImageUrl = referenceImageUrl;
    }
    public int Id { get; }
    public string Name { get; private set; }
    public EGroup GroupId { get; private set; }
    public string Description { get; private set; }
    public string ReferenceImageUrl { get; private set; }
}