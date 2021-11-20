using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class RandomerStrategy : SimpleStrategy
{
    private const float DirectionChangingPeriod = 1f;

    private float _lastDirectionChangingTime; 

    public RandomerStrategy(IControlablePolygon polygon) : base(polygon)
    {
        _lastDirectionChangingTime = Time.time;
    }

    public override sealed void FixedUpdate()
    {
        if(Time.time > _lastDirectionChangingTime + DirectionChangingPeriod)
        {
            ChangeDirection();
            _lastDirectionChangingTime = Time.time;
        }
    }

}
