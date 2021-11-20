using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlantStrategy : PolygonStrategy
{
    public PlantStrategy(IControlablePolygon polygon) : base(polygon)
    {
    }

    public override void OnCollision(Collision2D collision)
    {

    }

}
