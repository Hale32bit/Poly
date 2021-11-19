using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RandomerStrategy : SimpleStrategy
{
    public RandomerStrategy(IControlablePolygon polygon) : base(polygon)
    {
    }
}
