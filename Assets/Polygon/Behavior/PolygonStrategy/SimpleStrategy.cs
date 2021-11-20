using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SimpleStrategy : PolygonStrategy
{
    const float Speed = 0.3f;

    protected Vector3 CurrentDirection;

    public SimpleStrategy(IControlablePolygon polygon) : base(polygon)
    {
        ChangeDirection();
    }

    public sealed override void OnCollision(Collision2D collision)
    {
        if (collision.collider.gameObject.IsBorder())
        {
            ChangeDirection();
        }    
    }

    protected void ChangeDirection()
    {
        CurrentDirection = Polygon.EdgeDirections[Random.Range(0, Polygon.EdgeDirections.Length)];
        UpdateVelocity();
    }

    protected void UpdateVelocity()
    { 
        Vector3 globalDirection = Rigidbody.transform.TransformVector(CurrentDirection);
        Rigidbody.velocity = globalDirection * Speed;
    }
}
