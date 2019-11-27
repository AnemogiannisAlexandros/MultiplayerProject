using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterWindow characterWindow;

    public delegate void OnItemPickUp(Item item);

    private void Awake()
    {
        Character character = new Character();
        characterWindow.SetCharacter(character);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
