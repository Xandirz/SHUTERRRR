using System.Collections.Generic;
using UnityEngine;


    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _speedPerFrame = 2f;
        
        public List<Sprite> playerWalkSprites;
        private int index;
        private float _timer;
        
        private void Start()
        {
            _spriteRenderer.sprite = playerWalkSprites[index];
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _speedPerFrame)
            {
                index += 1;
                index %= playerWalkSprites.Count;

                _spriteRenderer.sprite = playerWalkSprites[index];
                _timer = 0;
            }
        }
    }
