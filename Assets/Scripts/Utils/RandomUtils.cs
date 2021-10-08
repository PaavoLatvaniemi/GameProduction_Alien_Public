using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtils<T>
{
    public static T RandomFromArray(T[] array)
    {
        int index = Random.Range(0, array.Length);
        return array[index];
    }
}
