using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour,IGun
{
    Character myCharacter;
    Weapon characterWeapon;
    private bool hasBullets;
    [SerializeField]
    [Tooltip("How fast the recoil rotation is applied")]
    private float recoilSmoothnes;
    private bool canShoot=true;
    private float shootTimer = 0;

    public void CalculateRecoil(float recoil)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(0, 0, recoil), recoilSmoothnes);
    }

    public void CalculateSpread(float spread)
    {
        throw new System.NotImplementedException();
    }

    public void Reload()
    {
        characterWeapon.SetBulletCount(characterWeapon.GetClipSize());
    }

    public void Shoot()
    {
        
    }

    public bool HasBullets()
    {
        hasBullets = characterWeapon.GetBulletCount() > 0 ? true : false;
     
        return hasBullets;
    }
    public bool CanShoot()
    {
        return canShoot;
    }
    public float CalculateFireRate() 
    {
        return characterWeapon.GetFireRate();
    }
    // Start is called before the first frame update
    void Start()
    {
        myCharacter = GetComponent<PlayerHandler>().GetCharacter();
        characterWeapon = myCharacter.GetEquippedWeapon();
    }
    public void UpdateWeaponValues()
    {
        characterWeapon = myCharacter.GetEquippedWeapon();
    }
    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && shootTimer > CalculateFireRate())
        {
            CalculateRecoil(15f) ;
            shootTimer = 0;
        }

    }
}
