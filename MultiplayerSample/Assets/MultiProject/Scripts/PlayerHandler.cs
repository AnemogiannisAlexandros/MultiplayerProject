using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterWindow characterWindow;

    //public Item.ItemTiers currentTier;
    Character character;
    private void Awake()
    {
        character = new Character();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogFormat("Armor Name : {0} Shield Amount : {1}", character.GetEquippedArmor().GetItemName() , character.GetEquippedArmor().GetShieldAmount());
        Debug.LogFormat("Helmet Name : {0} Damage Reduction Amount : {1}", character.GetEquippedHelmet().GetItemName(), character.GetEquippedHelmet().GetDamageReduction());
        Debug.LogFormat("Weapon Name : {0} Damage Amount : {1}", character.GetEquippedWeapon().GetItemName(), character.GetEquippedWeapon().GetDamage());
    }
    public Character GetCharacter() 
    {
        return character;
    }
}
