using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPoints : MonoBehaviour
{
    [SerializeField] Transform pointsParent;
    [SerializeField] float speed;

    int currentPoint;
    bool shouldMove;
    List<Transform> points = new List<Transform>();

    private void Awake()
    {
        foreach (Transform child in pointsParent)
            points.Add(child);
    }

    private void Update()
    {
        if (!shouldMove) return;

        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * Time.deltaTime);
        if (transform.position == points[currentPoint].position)
            currentPoint++;
        if(currentPoint >= points.Count)
        {
            currentPoint = 0;
            shouldMove = false;
        }
    }

    public void StartMoving() => shouldMove = true;
}
