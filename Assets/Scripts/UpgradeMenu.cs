using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public Gun gun;

    public void FireRateUp()
    {
        gun.ChangeFireRate();
        gameObject.SetActive(false);
    }

    public void IncreaseRatSpawnChance()
    {
        gun.ChangeRatSpawnChance();
        gameObject.SetActive(false);
    }

    public void IncreaseDamage()
    {
        gun.playerConfig.damage++;
        gameObject.SetActive(false);
    }
}