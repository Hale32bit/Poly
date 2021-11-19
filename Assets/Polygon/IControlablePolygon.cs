using UnityEngine;

public interface IControlablePolygon
{
    Rigidbody2D Rigidbody { get; }
    Vector3[] EdgeDirections { get; }
}