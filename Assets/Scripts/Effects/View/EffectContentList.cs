using System.Collections.Generic;
using UnityEngine;

public class EffectContentList : MonoBehaviour
{
    [SerializeField] private EffectView _prefab;
    [SerializeField] private Entity _entity;

    private void OnEnable()
    {
        _entity.OnChangeEffects += RefreshUI;
    }

    private void OnDisable()
    {
        _entity.OnChangeEffects -= RefreshUI;
    }

    private List<EffectView> _views = new();
    
    private void Clear()
    {
        foreach (var view in _views)
            Destroy(view.gameObject);

        _views.Clear();
    }

    private void RefreshUI()
    {
        Clear();
        var effects = _entity.currentEffects;

        foreach (var effect in effects)
        {
            var prefabInstance= Instantiate(_prefab, transform);
            prefabInstance.Constructor(effect);
            
            _views.Add(prefabInstance);
        }
    }
}