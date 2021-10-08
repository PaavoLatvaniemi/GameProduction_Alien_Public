using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] float minTriggerForce;
    [SerializeField] float timeBetweenCollisions = .1f;
    [SerializeField] UnityEvent OnCollision;

    float time;
    private void OnCollisionEnter(Collision collision)
    {
        if (time > 0) return;
        if (collision.impulse.magnitude < minTriggerForce) return;

        if (delay > 0) StartCoroutine("EventDelay");
        else OnCollision.Invoke();
        time = timeBetweenCollisions;
    }

    IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(delay);
        OnCollision.Invoke();
    }

    private void Update()
    {
        if (time > 0f) time -= Time.deltaTime;
        if (time < 0f) time = 0f;
    }
}
