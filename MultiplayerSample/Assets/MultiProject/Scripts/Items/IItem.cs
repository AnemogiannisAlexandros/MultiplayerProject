/// <summary>
/// To Do Implementation
/// </summary>
public interface IItem
{
    Item.ItemTiers GetItemTier();
    Item.ItemTypes GetItemType();
    string GetItemName();
    void SetItemTier(Item.ItemTiers tier);
    void SetItemType(Item.ItemTypes type);
    void SetName(string newName);
}
