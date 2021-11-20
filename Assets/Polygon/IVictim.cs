using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVictim 
{
    event Action<IPolygon> Destroyed;
    Rigidbody2D Rigidbody { get; }
}
