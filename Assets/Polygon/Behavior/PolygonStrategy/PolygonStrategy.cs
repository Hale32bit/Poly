using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PolygonStrategy 
{
    protected readonly IControlablePolygon Polygon;
    protected Rigidbody2D Transform;

    public PolygonStrategy(IControlablePolygon polygon)
    {
        Polygon = polygon;
        Transform = Polygon.Rigidbody;
    }
}
