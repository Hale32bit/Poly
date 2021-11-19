using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(IPolygonCreator))]
public sealed class World : MonoBehaviour, IPolygonDestroyer, IVictimsProvider
{

    private IPolygonCreator _polygonCreator;
    private readonly LinkedList<IPolygon> _polygons = new LinkedList<IPolygon>();

    //public IEnumerable<Polygon> Polygons => _polygons;

    private void Awake()
    {
        _polygonCreator = GetComponent<IPolygonCreator>();
    }

    private void OnEnable()
    {
        _polygonCreator.PolygonCreated += OnPolygonCreated;   
    }

    private void OnDisable()
    {
        _polygonCreator.PolygonCreated -= OnPolygonCreated;
    }

    private void OnPolygonCreated(IPolygon obj)
    {
        _polygons.AddLast(obj);
    }

    public void Destroy(IPolygon polygon)
    {
        polygon.Destroy();
        _polygons.Remove(polygon);
    }
    public IVictim GetRandomVictim()
    {
        int number = (int)UnityEngine.Random.Range(0, _polygons.Count);
        return _polygons.Skip(number - 1).First();
    }

}
