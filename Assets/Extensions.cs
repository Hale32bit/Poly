using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{

    public static int GetIndexByProbability(this float[] probabilities, float value)
    {
        if (value > 1 || value < 0)
            throw new System.Exception("probability must be in range 0 - 1");

        int currentIndex = 0;
        while(value > probabilities[currentIndex])
        {
            value -= probabilities[currentIndex];
            currentIndex++;

            if (currentIndex >= probabilities.Length)
                throw new System.Exception("Summary probability in array less than 1");
        }

        return currentIndex;

               
    }
}
