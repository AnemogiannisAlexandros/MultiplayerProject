using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    void Shoot();
    void CalculateSpread(float spread);
    void CalculateRecoil(float recoil);
    void Reload();
}
