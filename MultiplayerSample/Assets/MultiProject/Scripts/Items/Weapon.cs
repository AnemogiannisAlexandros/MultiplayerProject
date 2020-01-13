using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 0)]

public class Weapon : Item
{
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("The Damage of each bullet")]
    protected float damageOfBullets;
    [SerializeField]
    [Tooltip("How Often the gun can shoot")]
    protected float fireRate;
    [SerializeField]
    [Tooltip("The gun's Clip Size")]
    protected int clipSize;
    [SerializeField]
    [Tooltip("The current bullets in our clip")]
    protected int bulletCount;
    [SerializeField]
    [Tooltip("The amount of bullet spread applied")]
    protected float spreadAmount;
    [SerializeField]
    [Tooltip("The amount of recoil applied after firing")]
    protected float recoilAmount;

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
    #region Getters
    public float GetDamage()
    {
        return damageOfBullets;
    }
    public float GetFireRate() 
    {
        return fireRate;
    }
    public int GetClipSize() 
    {
        return clipSize;
    }
    public int GetBulletCount() 
    {
        return bulletCount;
    }
    public float GetSpreadAmount() 
    {
        return spreadAmount;
    }
    public float GetRecoilAmount() 
    {
        return recoilAmount;
    }
    #endregion Getters
    #region Setters
    public void SetDamage(float amount)
    {
        damageOfBullets = amount;
    }
    public void SetFireRate(float amount) 
    {
        fireRate = amount;
    }
    public void SetClipSize(int amount)
    {
        clipSize = amount;
    }
    public void SetBulletCount(int amount)
    {
        bulletCount = amount;
    }
    public void SetSpreadAmount(float amount)
    {
        spreadAmount = amount;
    }
    public void SetRecoilAmount(float amount)
    {
        recoilAmount = amount;
    }
    #endregion Setters
}
