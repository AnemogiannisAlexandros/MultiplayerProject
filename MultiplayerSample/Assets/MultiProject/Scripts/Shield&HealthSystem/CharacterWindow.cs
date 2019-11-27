using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterWindow : MonoBehaviour
{
    #region PrivateVariables
    private Color myBlue = new Color(78, 151, 255);
    private Color myPurple = new Color(227, 78, 255);
    private Color myOrange = new Color(255,226,16);
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private List<Image> shields = new List<Image>();
    private Character character;
    #endregion
    #region PublicVariables

    #endregion
    public void SetCharacter(Character character) 
    {
        this.character = character;
        Debug.Log(character);
    }
    private void UpdateShieldSegments() 
    {
        Item.ItemTiers bodyArmor = character.GetEquippedArmor().GetTier();
        switch (bodyArmor) 
        {
            default:
            case Item.ItemTiers.None:
                foreach (Image c in shields) 
                {
                    c.gameObject.SetActive(false);
                    c.color = Color.white;
                }
                break;
            case Item.ItemTiers.Common:
                shields[0].gameObject.SetActive(true);
                shields[1].gameObject.SetActive(true);
                break;
            case Item.ItemTiers.Rare:
                shields[0].gameObject.SetActive(true);
                shields[0].color = myBlue;
                shields[1].gameObject.SetActive(true);
                shields[1].color = myBlue;
                shields[2].gameObject.SetActive(true);
                shields[2].color = myBlue;
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
