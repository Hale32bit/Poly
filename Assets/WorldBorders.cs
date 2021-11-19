using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(LineRenderer),typeof(EdgeCollider2D))]
public sealed class WorldBorders : MonoBehaviour
{
    [SerializeField] private Vector2 _center;
    public Vector2 Center => _center;

    [SerializeField] private float _width, _height;
    public float Width => _width;
    public float Height => _height;

    public float Left => _center.x - _width / 2f;
    public float Right => _center.x + _width / 2f;
    public float Top => _center.y + _height / 2f;
    public float Bottom => _center.y - _height / 2f;

    private Vector2 _topLeftCorner, _topRightCorner, _bottomRightCorner, _bottomLeftCorner;

    private void Awake()
    {
        CalculateCorners();

        PrepareRenderer();

        PrepareCollider();
    }

    private void PrepareCollider()
    {
        var collider = GetComponent<EdgeCollider2D>();
        collider.points = new Vector2[]
        {
            _topLeftCorner,
            _topRightCorner,
            _bottomRightCorner,
            _bottomLeftCorner,
            _topLeftCorner
        };
    }

    private void PrepareRenderer()
    {
        var renderer = GetComponent<LineRenderer>();
        var corners = new Vector3[]
        {
            new Vector3(_topLeftCorner.x, _topLeftCorner.y, 0),
            new Vector3(_topRightCorner.x, _topRightCorner.y, 0),
            new Vector3(_bottomRightCorner.x, _bottomRightCorner.y, 0),
            new Vector3(_bottomLeftCorner.x,_bottomLeftCorner.y, 0)
        };
        renderer.SetPositions(corners);
    }

    private void CalculateCorners()
    {
        _topLeftCorner = new Vector2(Left, Top);
        _topRightCorner = new Vector2(Right, Top);
        _bottomRightCorner = new Vector2(Right, Bottom);
        _bottomLeftCorner = new Vector2(Left, Bottom);
    }
}
