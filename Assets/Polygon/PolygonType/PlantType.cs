using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PolygonTypes/Plant")]
public sealed class PlantType : PolygonType
{
    public override PolygonStrategy InstatiateStrategy(IControlablePolygon polygon)
    {
        return new PlantStrategy(polygon);
    }
}
