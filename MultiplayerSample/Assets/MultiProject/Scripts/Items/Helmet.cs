using UnityEngine;

[CreateAssetMenu(fileName = "Helmet", menuName = "Items/Helmet", order = 0)]

public class Helmet : Item
{
    [SerializeField]
    [Range(0, 100)]
    protected float damageReductionPercent;

    public Helmet(ItemTiers tier, string ItemName)
    {

    }
    public void Awake()
    {
        Init(itemTier, ItemName);
    }
    public override void Init(ItemTiers tier, string ItemName)
    {
        base.Init(tier, ItemName);
        itemType = ItemTypes.Helmet;
    }

    public float GetDamageReduction()
    {
        return damageReductionPercent;
    }
    public void SetDamageReduction(float amount)
    {
        damageReductionPercent = amount;
    }
}