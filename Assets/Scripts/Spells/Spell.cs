using UnityEngine;

public abstract class Spell
{
    public PlayerConfig PlayerConfig;
    
    private float cooldownTimeInSeconds;
    private float timer;
        
    public Spell(float cooldownTimeInSeconds, PlayerConfig config)
    {
        PlayerConfig = config;
        this.cooldownTimeInSeconds = cooldownTimeInSeconds;
        
        timer = this.cooldownTimeInSeconds;
    }

    public void Use()
    {
        if (!InCooldown())
        {
            OnUse();
            timer = 0;
        }
    }

    public bool InCooldown()
    {
        return timer < cooldownTimeInSeconds;
    }

    public float TimeLeft()
    {
        if (timer < cooldownTimeInSeconds)
            return cooldownTimeInSeconds - timer;
        
        return 0;
    }

    public abstract void OnUse();

    public void Tick()
    {
        timer += Time.deltaTime;
    }
}