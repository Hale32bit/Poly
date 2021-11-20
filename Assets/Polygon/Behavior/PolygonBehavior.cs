using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Polygon))]
public sealed class PolygonBehavior : MonoBehaviour
{
    private Polygon _polygon;
    private PolygonStrategy _strategy;

    private void Awake()
    {
        _polygon = GetComponent<Polygon>();
    }

    private void OnEnable()
    {
        _polygon.TypeChanged += OnTypeChanged;
    }

    private void OnDisable()
    {
        _polygon.TypeChanged -= OnTypeChanged;
    }

    private void OnTypeChanged()
    {
        _strategy = _polygon.Type.InstatiateStrategy(_polygon);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _strategy.OnCollision(collision);
    }

    private void FixedUpdate()
    {
        _strategy.FixedUpdate();
    }
}
