using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterWindow characterWindow;

    public Item.ItemTiers currentTier;
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
        character.GetEquippedArmor().SetItemTier(currentTier);
    }
    public Character GetCharacter() 
    {
        return character;
    }
}
