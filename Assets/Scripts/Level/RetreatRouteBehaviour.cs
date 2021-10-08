using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatRouteBehaviour : MonoBehaviour
{
    private void OnEnable()
    {
        RetreatRoutes.AddRoute(this);
    }

    private void OnDisable()
    {
        RetreatRoutes.RemoveRoute(this);
    }
}
