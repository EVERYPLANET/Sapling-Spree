using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public static class Calculations
{
    private static float multiplier = 1.15f;

    public static int ExponentialCost(int baseCost, int numberOwned)
    {
        return Mathf.CeilToInt(baseCost * Mathf.Pow(multiplier, numberOwned));
    }

    public static String FormatNumber(int num)
    {
        if (num >= 1000000)
        {
            double rounded = Math.Round(num / 1000000.0f, 2);
            String newVal = rounded.ToString() + "mil";
            return newVal;
        }
        else
        {
            return num.ToString();
        }
    }
}
