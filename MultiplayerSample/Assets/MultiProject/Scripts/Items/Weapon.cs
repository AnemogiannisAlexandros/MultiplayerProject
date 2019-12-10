using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 0)]

public class Weapon : Item
{
    [SerializeField]
    [Range(0, 100)]
    protected float damageOfBullets;

    public Weapon(ItemTiers tier, string ItemName)
    {

    }
    public void Awake()
    {
        Init(itemTier, ItemName);
    }
    public override void Init(ItemTiers tier, string ItemName)
    {
        base.Init(tier, ItemName);
        itemType = ItemTypes.Weapon;
    }

    public float GetDamage()
    {
        return damageOfBullets;
    }
    public void SetDamage(float amount)
    {
        damageOfBullets = amount;
    }
}
