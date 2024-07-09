using UnityEngine;

namespace Perks
{
    public class DoubleShotPerk :Perk
    {
        private PlayerConfig _playerConfig;
        private int basicAmountOfShots;
        
        public DoubleShotPerk(PlayerConfig playerConfig) : base(playerConfig)
        {
            _playerConfig = playerConfig;
        }

        public override void OnActivate()
        {
            _playerConfig.onPreShoot += OnPreShoot;
            _playerConfig.onShoot += OnShoot;
        }

        private void OnPreShoot()
        {
            basicAmountOfShots = _playerConfig.amountOfShots;

            int chance = Random.Range(0, 101);
            if (chance < 50)
            {
                _playerConfig.amountOfShots ++;
            }
        }

        private void OnShoot()
        {
             _playerConfig.amountOfShots = basicAmountOfShots;
        }

        public override void OnDeactivate()
        {
            _playerConfig.onShoot -= OnShoot;
            _playerConfig.onPreShoot -= OnPreShoot;

        }
    }
}