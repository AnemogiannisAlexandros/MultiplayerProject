/// <summary>
/// To Do Implementation
/// </summary>
public interface IItem
{
    Item.ItemTiers GetItemTier();
    Item.ItemTypes GetItemType();
    string GetItemName();
    void Init(Item.ItemTiers tier, string ItemName);
    void SetItemTier(Item.ItemTiers tier);
    void SetName(string newName);
}
