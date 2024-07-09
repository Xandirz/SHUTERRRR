using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityView : MonoBehaviour
{
    public TextMeshPro hpText;
    public Player player;
    public SpriteRenderer spriteRenderer;
    public SpriteAnimator spriteAnimator;

    public void ChangeHpText(int hp, int maxHp)
    {
        hpText.text = hp + "/" + maxHp;
    }

    public void Update()
    {
        if (player.isMoving)
        {
            
        }

        spriteRenderer.flipX = player.faceDirection.x > 0;
    }
    
}
