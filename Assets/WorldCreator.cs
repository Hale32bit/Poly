using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public sealed class WorldCreator : MonoBehaviour, IPolygonCreator
{
    private const int MinCornersCount = 2;
    private const int MaxCornersCount = 5;

    [SerializeField] private WorldConfiguration _configuration;
    [SerializeField] private WorldBorders _borders;

    [SerializeField] private Polygon _polygonPrefab;

    [SerializeField] private PolygonType[] _polygonTypes;

    


    public event System.Action<IPolygon> PolygonCreated;




    public void Create()
    {

        for (int i =0; i < _configuration.PolygonsCount; i++)
        {
            Vector2 position = GenerateCorrectPosition();
            int cornersCount = Random.Range(MinCornersCount, MaxCornersCount);

            UnityEngine.Debug.Log(cornersCount);

            CreatePolygonOfRandomType(position, cornersCount);
        }

    }

    private Vector2 GenerateCorrectPosition()
    {
        Vector2 position = default;
        bool isPositionCorrect = false;
        while (!isPositionCorrect)
        {
            position = new Vector2(
                Random.Range(_borders.Left, _borders.Right),
                Random.Range(_borders.Bottom, _borders.Top));

            isPositionCorrect =
                Physics2D.OverlapCircle(position, Polygon.Radius) == null;

            UnityEngine.Debug.Log(Physics2D.OverlapCircle(position, Polygon.Radius));
        }

        return position;
    }





    public void CreatePolygonOfRandomType(Vector2 position, int cornersCount)
    {
        Polygon polygon = GameObject.Instantiate<Polygon>(_polygonPrefab);

        polygon.SetCornersCount(cornersCount);
        polygon.transform.position = new Vector3(position.x, position.y, 0);

        PolygonType type = _polygonTypes[_configuration.Probabilities.GetIndexByProbability(Random.value)];
        polygon.SetType(type);

        float azimuth = Random.Range(0, 360);
        polygon.transform.rotation = Quaternion.Euler(0, 0, azimuth);

        PolygonCreated?.Invoke(polygon);
    }
}
