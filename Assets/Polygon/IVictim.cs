using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVictim 
{
    event Action Destroyed;
    Rigidbody2D Rigidbody { get; }
}
