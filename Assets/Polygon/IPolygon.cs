using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPolygon : IVictim
{
    event Action<Collision2D> Colided;
    int CornersCount { get; }
    bool isDestroyed { get; }
    void Destroy();
}
