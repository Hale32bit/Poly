using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HunterStrategy : SimpleStrategy
{
    private const float AngularSpeed = 50f;

    private readonly IVictimsProvider _victimsProvider;
    private IVictim _victim;

    public HunterStrategy(IControlablePolygon polygon, IVictimsProvider victimsProvider) : base(polygon)
    {
        _victimsProvider = victimsProvider;
        ChangeVictim();
    }

    private void ChangeVictim()
    {
        _victim = _victimsProvider.GetRandomVictim();

        if (_victim == null)
            return;

        _victim.Destroyed += OnVictimDestroyed;
    }

    private void OnVictimDestroyed(IPolygon obj)
    {
        _victim.Destroyed -= OnVictimDestroyed;
        ChangeVictim();
    }

    public sealed override void FixedUpdate()
    {
        if (_victim == null || _victim == Polygon)
            return;

        Vector2 directionToVictim = _victim.Rigidbody.position - Polygon.Rigidbody.position;
        float necessaryDeltaAzimuth = Vector2.SignedAngle(Polygon.Rigidbody.velocity, directionToVictim);
        float deltaAthimuth = CalculateDeltaAzimuth(necessaryDeltaAzimuth);
        Rigidbody.rotation += deltaAthimuth;
        this.UpdateVelocity();
    }

    private static float CalculateDeltaAzimuth(float necessarydeltaAzimuth)
    {
        float deltaAthimuth = Mathf.Sign(necessarydeltaAzimuth) * Time.fixedDeltaTime * AngularSpeed;
        if (deltaAthimuth > 0)
        {
            deltaAthimuth = Mathf.Min(deltaAthimuth, necessarydeltaAzimuth);
        }
        else
        {
            deltaAthimuth = Mathf.Max(deltaAthimuth, necessarydeltaAzimuth);
        }

        return deltaAthimuth;
    }
}
