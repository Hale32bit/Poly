using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class PolygonType : ScriptableObject
{
    [SerializeField]
    private Material _material;
    public Material Material => _material;

    public abstract PolygonStrategy InstatiateStrategy(IControlablePolygon polygon);
}
