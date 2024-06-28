
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyManager :  MonoBehaviour
    {
        public List <Enemy> enemies;
        public int deadEnemies = 0;
        public GameObject upgradeMenu;
        public Player player;

        public void enemyDied()
        {
            deadEnemies++;
            if (deadEnemies % 5 == 0)
            {
                upgradeMenu.SetActive(true);
                player.TogglePause();
                
            }
        }
    }
