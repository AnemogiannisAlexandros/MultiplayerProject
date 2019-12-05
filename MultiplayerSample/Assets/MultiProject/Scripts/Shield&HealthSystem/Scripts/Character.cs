public class Character
{
    
    private Armor bodyArmor;
    private Helmet helmet;
    private Weapon equipedWeapon;

    public Character()
    {
        bodyArmor = new Armor(Item.ItemTiers.None,Item.ItemTypes.Armor,"No Equipped Armor");
        helmet = new Helmet(Item.ItemTiers.None, Item.ItemTypes.Helmet, "No Equipped Helmet");
        equipedWeapon = new Weapon(Item.ItemTiers.None,Item.ItemTypes.Weapon,"No Equipped Weapon");
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
