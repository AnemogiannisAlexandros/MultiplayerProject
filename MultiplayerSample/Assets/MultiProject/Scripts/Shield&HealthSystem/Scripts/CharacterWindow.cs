using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterWindow : MonoBehaviour
{
    #region PrivateVariables
    private Color myBlue;
    private Color myPurple;
    private Color myOrange;
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private Image armorImage;
    [SerializeField]
    private Image helmetImage;
    [SerializeField]
    private List<Image> shields;
    private Character character;
    Item.ItemTiers bodyArmor;
    Item.ItemTiers helmet;
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
        myBlue = new Color(.2f, .5f, .8f,1);
        myPurple = new Color(1, .3f, .9f,1);
        myOrange = new Color(1, .8f, .3f,1);
    }
    public void UpdateHelmetGraphic()
    {
        helmet = character.GetEquippedHelmet().GetItemTier();
        {
            switch (helmet) 
            {
                case Item.ItemTiers.None:
                    helmetImage.gameObject.SetActive(false);
                    break;
                case Item.ItemTiers.Common:
                    helmetImage.color = Color.white;
                    break;
                case Item.ItemTiers.Rare:
                    helmetImage.color = myBlue;
                    break;
                case Item.ItemTiers.Epic:
                    helmetImage.color = myPurple;
                    break;
                case Item.ItemTiers.Legendary:
                    helmetImage.color = myOrange;
                    break;
            }
        }
    }
    public void UpdateShieldSegments() 
    {
        bodyArmor = character.GetEquippedArmor().GetItemTier();
        switch (bodyArmor) 
        {
            case Item.ItemTiers.None:
                foreach (Image c in shields) 
                {
                    c.gameObject.SetActive(false);
                }
                armorImage.gameObject.SetActive(false);
                helmetImage.gameObject.SetActive(false);
                break;
            case Item.ItemTiers.Common:
                for (int i = 0; i < shields.Count; i++) 
                {
                    if (i < 2)
                    {
                        shields[i].gameObject.SetActive(true);
                        shields[i].color = Color.white;
                    }
                    else 
                    {
                        shields[i].gameObject.SetActive(false);
                    }
                }
                armorImage.color = Color.white;
                break;
            case Item.ItemTiers.Rare:
                for (int i = 0; i < shields.Count; i++)
                {
                    if (i < 3)
                    {
                        shields[i].gameObject.SetActive(true);
                        shields[i].color = myBlue;
                    }
                    else
                    {
                        shields[i].gameObject.SetActive(false);
                    }
                    armorImage.color = myBlue;
                }
                break;
            case Item.ItemTiers.Epic:
                foreach (Image c in shields)
                {
                    c.gameObject.SetActive(true);
                    c.color = myPurple;
                }
                armorImage.color = myPurple;
                break;
            case Item.ItemTiers.Legendary:
                foreach (Image c in shields)
                {
                    c.gameObject.SetActive(true);
                    c.color = myOrange;
                }
                armorImage.color = myOrange;
                break;
        }
    }
}
