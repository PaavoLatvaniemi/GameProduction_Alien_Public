using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RetreatRoutes
{
    static List<RetreatRouteBehaviour> routes = new List<RetreatRouteBehaviour>();

    public static void AddRoute(RetreatRouteBehaviour route) => routes.Add(route);
    public static void RemoveRoute(RetreatRouteBehaviour route) => routes.Remove(route);

    public static RetreatRouteBehaviour GetClosestRoute(Transform transform)
    {
        if (routes.Count == 0) return null;

        RetreatRouteBehaviour retreatRoute = null;
        float minDist = Mathf.Infinity;
        foreach (var route in routes)
        {
            float dist = Vector3.Distance(transform.position, route.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                retreatRoute = route;
            }
        }
        return retreatRoute;
    }
}
