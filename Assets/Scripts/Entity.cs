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

   

    private bool ContainsEffect<T>() where T : Effect
    {
        foreach (var current in currentEffects)
        {
            if (current is T)
                return true;
        }

        return false;
    }
        
    private T GetEffectByType<T>() where T : Effect
    {
        foreach (var current in currentEffects)
        {
            if (current is T value)
                return value;
        }

        return null;
    }
    
    public void AddEffect<T>(T effect) where T : Effect
    {
        if (ContainsEffect<T>())
        {
            var duration = effect.Duration;
            var previousEffect = GetEffectByType<T>();
                
            previousEffect.AddDuration(duration);
                
            return;
        }
            
        currentEffects.Add(effect);   
        OnChangeEffects?.Invoke();
    }
    
    
}