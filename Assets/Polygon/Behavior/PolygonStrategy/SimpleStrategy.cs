using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStrategy : PolygonStrategy
{
    protected Vector3 CurrentDirection;

    public SimpleStrategy(IControlablePolygon polygon) : base(polygon)
    {
    }
}
