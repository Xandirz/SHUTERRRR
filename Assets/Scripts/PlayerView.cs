using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerView : MonoBehaviour
    {
        public Player player;
        public SpriteRenderer spriteRenderer;
    
        public SpriteAnimator walkAnimator;
        public SpriteAnimator idleAnimator;
        
        public void Update()
        {
            Debug.Log(player.isMoving);
            
            walkAnimator.gameObject.SetActive(player.isMoving);
            idleAnimator.gameObject.SetActive(!player.isMoving);
        
            spriteRenderer.flipX = player.faceDirection.x < 0;
        }
    }
}