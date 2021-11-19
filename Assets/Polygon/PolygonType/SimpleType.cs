using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PolygonType/Simple")]
public sealed class SimpleType : PolygonType
{
    public override PolygonStrategy InstatiateStrategy(IControlablePolygon polygon)
    {
        return new SimpleStrategy(polygon);
    }
}
