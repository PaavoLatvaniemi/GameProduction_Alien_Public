using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Transform target;
    bool shouldRotate;

    public void StartRotation(Transform _target)
    {
        target = _target;
        shouldRotate = true;
    }

    public void EndRotation()
    {
        target = null;
        shouldRotate = false;
    }

    private void Update()
    {
        if (!shouldRotate || target == null) return;

        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

}
