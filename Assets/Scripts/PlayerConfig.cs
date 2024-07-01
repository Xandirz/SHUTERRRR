﻿
    using System;
    using UnityEngine;

    public class PlayerConfig : MonoBehaviour
    {
        public event Action onShoot;
        public int amountOfShots;
        public float fireRate;
        public float boltSpeed = 10.0f;
        public int damage;
    }
