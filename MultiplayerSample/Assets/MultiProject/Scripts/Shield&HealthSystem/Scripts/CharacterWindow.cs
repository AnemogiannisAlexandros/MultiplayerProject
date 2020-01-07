using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class CharacterWindow : MonoBehaviour
{
    #region PrivateVariables
    private Color myBlue;
    private Color myPurple;
    private Color myOrange;
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private Transform ArmorObj;
    private Image armorUi;
    [SerializeField]
    private Transform helmetObj;
    private Image helmetUi;
    [SerializeField]
    private List<Image> shields;
    [SerializeField]
    private List<GameObject> shieldObjs;
    [SerializeField]
    private Image weaponIcon;
    [SerializeField]
    private GameObject weaponObj;
    private Character character;
    Item.ItemTiers bodyArmor;
    Item.ItemTiers helmet;
    Item.ItemTiers weapon;
    #endregion
    #region PublicVariables

    #endregion
    public void SetCharacter(Character character) 
    {
        this.character = character;
    }
    public void Start()
    {
        character = FindObjectOfType<PlayerHandler>().GetCharacter();
        myBlue = new Color(.2f, .5f, .8f,.8f);
        myPurple = new Color(1, .3f, .9f,.8f);
        myOrange = new Color(1, .8f, .3f,.8f);
        armorUi = ArmorObj.GetChild(0).GetComponent<Image>();
        helmetUi = helmetObj.GetChild(0).GetComponent<Image>();
        for (int i = 0; i < 4; i++) 
        {
            shields[i] = shieldObjs[i].transform.GetChild(1).GetComponent<Image>();
        }
        UpdateShieldSegments();
        UpdateHelmetGraphic();
        UpdateWeaponGraphic();
    }
    /// <summary>
    /// Runs the Appropriate function based on the Type of item we picked up
    /// </summary>
    /// <param name="item"></param>
    public void UpdatePickedItemGUI(Item item) 
    {
        switch (item.GetItemType()) 
        {
            case Item.ItemTypes.Helmet :
                UpdateHelmetGraphic();
                break;
            case Item.ItemTypes.Armor:
                UpdateShieldSegments();
                break;
            case Item.ItemTypes.Weapon:
                UpdateWeaponGraphic();
                break;
                
        }
    }
/// <summary>
/// Updates the Weapon Graphin in the UI.
/// </summary>
    public void UpdateWeaponGraphic() 
    {
        weapon = character.GetEquippedWeapon().GetItemTier();
        switch (weapon) 
        {
            case Item.ItemTiers.None:
                weaponObj.SetActive(false);
                break;
            case Item.ItemTiers.Common:
                weaponObj.SetActive(true);
                weaponIcon.color = Color.gray;
                break;
            case Item.ItemTiers.Rare:
                weaponObj.SetActive(true);
                weaponIcon.color = myBlue;
                break;
            case Item.ItemTiers.Epic:
                weaponObj.SetActive(true);
                weaponIcon.color = myPurple;
                break;
            case Item.ItemTiers.Legendary:
                weaponObj.SetActive(true);
                weaponIcon.color = myOrange;
                break;
        }
    }
    /// <summary>
    /// Updates the Helmet Graphin in the UI
    /// </summary>
    public void UpdateHelmetGraphic()
    {
        helmet = character.GetEquippedHelmet().GetItemTier();
        {
            switch (helmet) 
            {
                case Item.ItemTiers.None:
                    helmetObj.gameObject.SetActive(false);
                    break;
                case Item.ItemTiers.Common:
                    helmetObj.gameObject.SetActive(true);
                    helmetUi.color = Color.gray;
                    break;
                case Item.ItemTiers.Rare:
                    helmetObj.gameObject.SetActive(true);
                    helmetUi.color = myBlue;
                    break;
                case Item.ItemTiers.Epic:
                    helmetObj.gameObject.SetActive(true);
                    helmetUi.color = myPurple;
                    break;
                case Item.ItemTiers.Legendary:
                    helmetObj.gameObject.SetActive(true);
                    helmetUi.color = myOrange;
                    break;
            }
        }
    }
    /// <summary>
    /// Updates Shield Segments on the UI
    /// </summary>
    public void UpdateShieldSegments() 
    {
        bodyArmor = character.GetEquippedArmor().GetItemTier();
        switch (bodyArmor) 
        {
            case Item.ItemTiers.None:
                for(int i = 0;i<shieldObjs.Count;i++) 
                {
                    shieldObjs[i].SetActive(false);
                }
                ArmorObj.gameObject.SetActive(false);
                break;
            case Item.ItemTiers.Common:
                for (int i = 0; i < shieldObjs.Count; i++) 
                {
                    if (i < 2)
                    {
                        shieldObjs[i].SetActive(true);
                        shields[i].color = Color.white;
                    }
                    else 
                    {
                        shieldObjs[i].SetActive(false);
                    }
                }
                ArmorObj.gameObject.SetActive(true);
                armorUi.color = Color.grey;
                break;
            case Item.ItemTiers.Rare:
                for (int i = 0; i < shields.Count; i++)
                {
                    if (i < 3)
                    {
                        shieldObjs[i].SetActive(true);
                        shields[i].color = myBlue;
                    }
                    else
                    {
                        shieldObjs[i].SetActive(false);
                    }
                    ArmorObj.gameObject.SetActive(true);
                    armorUi.color = myBlue;
                }
                break;
            case Item.ItemTiers.Epic:
                for(int i=0;i<shieldObjs.Count;i++)
                {
                    shieldObjs[i].SetActive(true);
                    shields[i].color = myPurple;
                }
                ArmorObj.gameObject.SetActive(true);
                armorUi.color = myPurple;
                break;
            case Item.ItemTiers.Legendary:
                for (int i = 0; i < shieldObjs.Count; i++)
                {
                    shieldObjs[i].SetActive(true);
                    shields[i].color = myOrange;
                }
                ArmorObj.gameObject.SetActive(true);
                armorUi.color = myOrange;
                break;
        }
    }
}
