using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PolygonType/Hunter")]
public sealed class HunterType : PolygonType
{

    private IVictimsProvider _victimsProvider;

    public void Initialize(IVictimsProvider victimsProvider)
    {
        _victimsProvider = victimsProvider;
    }

    public override PolygonStrategy InstatiateStrategy(IControlablePolygon polygon)
    {
        if (_victimsProvider == null)
            throw new System.Exception("HunterType notInitialized");

        return new HunterStrategy(polygon, _victimsProvider);
    }
}
