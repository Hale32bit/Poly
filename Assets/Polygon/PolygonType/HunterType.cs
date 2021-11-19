using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PolygonType/Hunter")]
public sealed class HunterType : PolygonType
{
    public override PolygonStrategy InstatiateStrategy(IControlablePolygon polygon)
    {
        return new HunterStrategy(polygon);
    }
}
