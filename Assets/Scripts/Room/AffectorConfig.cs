using System.Collections.Generic;
using UnityEngine;

public class AffectorConfig<T> : Config
{
    [SerializeField] private List<T> _prefabs; 

    public List<T> Prefabs => _prefabs;
}
