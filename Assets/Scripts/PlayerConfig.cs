
    using System;
    using UnityEngine;

    public class PlayerConfig : MonoBehaviour
    {
        public Action onShoot;
        public Action onPreShoot;
        public int amountOfShots = 1;
        public float fireRate = 1;
        public float boltSpeed = 10.0f;
        public int damage = 1;

        public bool isFire = false;
    }
