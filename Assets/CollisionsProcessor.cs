using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(IPolygonDestroyer),typeof(IPolygonCreator))]
public sealed class CollisionsProcessor : MonoBehaviour
{
    private IPolygonCreator _creator;
    private IPolygonDestroyer _destroyer;

    private void Awake()
    {
        _creator = GetComponent<IPolygonCreator>();
        _destroyer = GetComponent<IPolygonDestroyer>();
    }

    private void OnEnable()
    {
        _creator.PolygonCreated += OnPolygonCreated;
    }

    private void OnDisable()
    {
        _creator.PolygonCreated -= OnPolygonCreated;
    }

    private void OnPolygonCreated(IPolygon obj)
    {
        obj.Destroyed += OnPolygonDestroyed;
        obj.Colided += OnPolygonCollided;

    }

    private void OnPolygonCollided(Collision2D collision)
    {
        if (collision.collider.gameObject.IsPolygon() == false)
            return;

        IPolygon first = collision.gameObject.GetComponent<IPolygon>();
        IPolygon second = collision.gameObject.GetComponent<IPolygon>();

        int summaryCornersCount = first.CornersCount + second.CornersCount;

        _destroyer.Destroy(first);
        _destroyer.Destroy(second);

        _creator.CreatePolygonOfRandomType(collision.contacts[0].point, summaryCornersCount);
    }

    private void OnPolygonDestroyed(IPolygon obj)
    {
        obj.Destroyed -= OnPolygonDestroyed;
        obj.Colided -= OnPolygonCollided;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
