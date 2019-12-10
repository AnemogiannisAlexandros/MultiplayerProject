using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 0)]

public class Armor : Item
{
    [SerializeField]
    [Range(0, 200)]
    protected float amountOfSield;

    public Armor(ItemTiers tier, string ItemName)
    {
        
    }
    public  void Awake()
    {
        Init(itemTier, ItemName);
    }
    public override void  Init(ItemTiers tier, string ItemName)
    {
        base.Init(tier, ItemName);
        itemType = ItemTypes.Armor;
    }

    public float GetShieldAmount() 
    {
        return amountOfSield;
    }
    public void SetShieldAmount(float amount) 
    {
        amountOfSield = amount;
    }
}
