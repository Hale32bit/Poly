using System;
using UnityEngine;

public interface IPolygonCreator
{
    event Action<IPolygon> PolygonCreated;
    void CreatePolygonOfRandomType(Vector2 position, int cornersCount);
}