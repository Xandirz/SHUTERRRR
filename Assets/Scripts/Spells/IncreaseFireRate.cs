using System.Collections;
using Inventory.Utils;
using UnityEngine;

public class IncreaseFireRate : Spell
{
    private float effectDuration;
        
    public IncreaseFireRate(float effectDurationInSeconds, float cooldownTimeInSeconds, PlayerConfig config) : base(cooldownTimeInSeconds, config)
    {
        effectDuration = effectDurationInSeconds;
    }

    public override void OnUse()
    {
        CoroutineRunner.Run(IncreaseFireRateRoutine());
    }

    private IEnumerator IncreaseFireRateRoutine()
    {
        PlayerConfig.fireRate += 10;
        yield return new WaitForSeconds(effectDuration);
        PlayerConfig.fireRate -= 10;
    }
}