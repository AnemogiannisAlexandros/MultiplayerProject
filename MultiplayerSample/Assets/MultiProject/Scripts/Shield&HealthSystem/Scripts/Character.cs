using UnityEngine;

public class Character
{
    
    private Armor bodyArmor;
    private Helmet helmet;
    private Weapon equipedWeapon;

    public Character()
    {
        bodyArmor = ScriptableObject.CreateInstance<Armor>();
        helmet = ScriptableObject.CreateInstance<Helmet>();
        equipedWeapon = ScriptableObject.CreateInstance<Weapon>();
        bodyArmor.Init(Item.ItemTiers.None,"No Armor");
        helmet.Init(Item.ItemTiers.None, "No Helmet");
        equipedWeapon.Init(Item.ItemTiers.None, "No Weapon");
    }
    #region Getters
    public Armor GetEquippedArmor() 
    {
        return bodyArmor;
    }
    public Helmet GetEquippedHelmet()
    {
        return helmet;
    }
    public Weapon GetEquippedWeapon()
    {
        return equipedWeapon;
    }
    public void SetArmor(Armor armor) 
    {
        bodyArmor = armor;
        bodyArmor.SetShieldAmount(armor.GetShieldAmount());
    }
    public void SetHelmet(Helmet helmet) 
    {
        this.helmet = helmet;
    }
    public void SetWeapon(Weapon weapon) 
    {
        equipedWeapon = weapon;
    }
    #endregion
    #region Setters

    #endregion
}
