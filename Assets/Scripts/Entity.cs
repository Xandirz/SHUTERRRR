using System;
using System.Collections.Generic;
using Effects;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public event Action OnChangeEffects;
    
    public List<Effect> currentEffects = new List<Effect>();

    public void Move(Vector2 direction)
    {
        transform.Translate(direction, Space.World);
    }

    public void ApplyEffect(Effect effect)
    {
        currentEffects.Add(effect);
        OnChangeEffects?.Invoke();
    }
}