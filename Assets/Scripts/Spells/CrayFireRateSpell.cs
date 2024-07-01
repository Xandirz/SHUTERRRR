public class CrayFireRateSpell : Spell
{
    public CrayFireRateSpell(float cooldownTimeInSeconds, PlayerConfig config) : base(cooldownTimeInSeconds, config)
    {
        config.onShoot += OnShoot;
    }

    private void OnShoot()
    {
        PlayerConfig.fireRate += 5;
    }

    public override void OnUse()
    {
        return;
    }
}