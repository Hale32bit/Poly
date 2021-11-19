using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PolygonCollider2D), typeof(Rigidbody2D))]
public sealed class Polygon : MonoBehaviour, IPolygon, IControlablePolygon
{
    public const float Radius = 0.3f;

    public event Action CornersChanged;
    public event Action TypeChanged;
    public event Action<Collision2D> Colided;
    public event Action Destroyed;

    private PolygonCollider2D _collider;
    public PolygonType Type { get; private set; }

    private Vector3[] _edgeDirections;
    Vector3[] IControlablePolygon.EdgeDirections => _edgeDirections;

    private float AngleBetweenCorners => Mathf.PI * 2 / (float)CornersCount;

    public int CornersCount { get; private set; }

    public Rigidbody2D Rigidbody => this.GetComponent<Rigidbody2D>();

    private void Awake()
    {
        _collider = gameObject.GetComponent<PolygonCollider2D>();
    }

    public void SetCornersCount(int value)
    {
        CornersCount = value;

        GenerateEdgeDirections();

        UpdateCollider();
        CornersChanged?.Invoke();
    }

    public void SetType(PolygonType type)
    {
        Type = type;
        TypeChanged?.Invoke();
    }

    private void GenerateEdgeDirections()
    {
        _edgeDirections = new Vector3[CornersCount];
        for (int i = 0; i < CornersCount; i++)
        {
            float angle = (float)i * AngleBetweenCorners + AngleBetweenCorners / 2;
            _edgeDirections[i] = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
    }

    private void UpdateCollider()
    {
        Vector2[] points = new Vector2[CornersCount];
        for (int i = 0; i < CornersCount; i++)
            points[i] = Corner(i);

        _collider.points = points;
    }

    public Vector2 Corner(int index)
    {
        if (index >= CornersCount)
            throw new Exception("index out of corners count");

        float angle = (float)index * AngleBetweenCorners;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;
    }

    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Colided?.Invoke(collision);
    }
}
