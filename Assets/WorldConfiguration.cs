using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class WorldConfiguration : MonoBehaviour
{
    [SerializeField] private Text _polygonsCountField;

    [SerializeField] private Text[] _weightFields;

    public int PolygonsCount { get; private set; }
    public float[] Weights { get; private set; }

    public float[] Probabilities { get; private set; }


    private void Awake()
    {
        Weights = new float[_weightFields.Length];
        Probabilities = new float[_weightFields.Length];
        OnChanged();
    }

    public void OnChanged()
    {
        UpdatePolygonsCount();

        UpdateProbabilities();
    }

    private void UpdateProbabilities()
    {
        float summaryWeight = 0;
        for (int index = 0; index < _weightFields.Length; index++)
        {
            Weights[index] = Convert.ToSingle(_weightFields[index].text);
            summaryWeight += Weights[index];
        }

        for (int index = 0; index < _weightFields.Length; index++)
            Probabilities[index] = Weights[index] / summaryWeight;

    }

    private void UpdatePolygonsCount()
    {
        PolygonsCount = Convert.ToInt32(_polygonsCountField.text);
    }
}
