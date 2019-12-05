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
    private List<Image> shields;
    private Character character;
    Item.ItemTiers bodyArmor;
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
        Debug.Log(character.GetEquippedArmor().GetItemName());
        Debug.Log(character.GetEquippedArmor().GetItemTier());
        myBlue = new Color(.2f, .5f, .8f,1);
        myPurple = new Color(1, .3f, .9f,1);
        myOrange = new Color(1, .8f, .3f,1);
    }

    public void UpdateShieldSegments() 
    {
        bodyArmor = character.GetEquippedArmor().GetItemTier();
        Debug.Log(character.GetEquippedArmor().GetItemTier());
        switch (bodyArmor) 
        {
            case Item.ItemTiers.None:
                foreach (Image c in shields) 
                {
                    c.gameObject.SetActive(false);
                }
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
                }
                break;
            case Item.ItemTiers.Epic:
                foreach (Image c in shields)
                {
                    c.gameObject.SetActive(true);
                    c.color = myPurple;
                }
                break;
            case Item.ItemTiers.Legendary:
                foreach (Image c in shields)
                {
                    c.gameObject.SetActive(true);
                    c.color = myOrange;
                }
                break;
        }
    }
}
