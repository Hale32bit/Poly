using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Polygon), typeof(LineRenderer))]
public sealed class PolygonView : MonoBehaviour
{
    private const float LineWidth = 0.1f;

    private Polygon _polygon;
    private LineRenderer _renderer;

    private void Awake()
    {
        _polygon = GetComponent<Polygon>();

        _renderer = GetComponent<LineRenderer>();

        //_renderer = gameObject.AddComponent<LineRenderer>();
        //_renderer.widthCurve = AnimationCurve.Constant(0, 10, LineWidth);
        //_renderer.loop = true;
        //_renderer.useWorldSpace = false;
        //_renderer.startColor = Color.blue;
    }

    private void OnEnable()
    {
        _polygon.CornersChanged += OnCornersChanged;
        _polygon.TypeChanged += OnTypeChanged;
    }

    private void OnDisable()
    {
        _polygon.CornersChanged -= OnCornersChanged;
        _polygon.TypeChanged -= OnTypeChanged;

    }

    private void OnCornersChanged()
    {
        _renderer.positionCount = _polygon.CornersCount;
        _renderer.SetPositions(GeneratePositions());
    }

    private void OnTypeChanged()
    {
        _renderer.material = _polygon.Type.Material;
    }

    private Vector3[] GeneratePositions()
    {
        var corners = new Vector3[_polygon.CornersCount];
        for (int i = 0; i < _polygon.CornersCount; i++)
        {
            var corner = _polygon.Corner(i);
            corners[i] = new Vector3(corner.x, corner.y, 0);
        }

        return corners;
    }
}
