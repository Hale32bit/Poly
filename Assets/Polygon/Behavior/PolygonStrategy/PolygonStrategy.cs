using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PolygonStrategy 
{
    protected readonly IControlablePolygon Polygon;
    protected Rigidbody2D Rigidbody;

    public PolygonStrategy(IControlablePolygon polygon)
    {
        Polygon = polygon;
        Rigidbody = Polygon.Rigidbody;
    }

    public abstract void OnCollision(Collision2D collision);

    public virtual void FixedUpdate()
    { }
}
