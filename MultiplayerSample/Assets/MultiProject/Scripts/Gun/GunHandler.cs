using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour,IGun
{
    Character myCharacter;
    Weapon characterWeapon;

    public void CalculateRecoil(float recoil)
    {
        throw new System.NotImplementedException();
    }

    public void CalculateSpread(float spread)
    {
        throw new System.NotImplementedException();
    }

    public void Reload()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        
    }

    public void CalculateFireRate() 
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        myCharacter = GetComponent<PlayerHandler>().GetCharacter();
        characterWeapon = myCharacter.GetEquippedWeapon();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
