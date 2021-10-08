using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CodeGeneration
{
    public static string GenerateRandomCode(int nbOfDigits, int min, int max)
    {
        string toReturn = "";
        for (int i = 0; i < nbOfDigits; ++i)
        {
            int rand = Random.Range(min, max);
            toReturn += rand.ToString();
        }

        return toReturn;
    }
}
