using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HunterStrategy : SimpleStrategy
{
    public HunterStrategy(IControlablePolygon polygon) : base(polygon)
    {
    }
}
