using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PolygonType/Randomer")]
public sealed class RandomerType : PolygonType
{
    public override PolygonStrategy InstatiateStrategy(IControlablePolygon polygon)
    {
        return new RandomerStrategy(polygon);
    }
}
