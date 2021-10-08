using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] bool invokeOnce;
    [SerializeField] bool invokeWhenAlienActive = true;
    [SerializeField] string inkokerTag = "Player";
    [SerializeField] UnityEvent OnTrigger;

    bool invoked;
    private void OnTriggerEnter(Collider other)
    {
        if (!invokeWhenAlienActive)
            if (GameDirector.alienActive) return;
        if (invokeOnce && invoked) return;
        if (!other.CompareTag(inkokerTag)) return;

        if (delay > 0) StartCoroutine("EventDelay");
        else OnTrigger.Invoke();
        invoked = true;
    }

    IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(delay);
        OnTrigger.Invoke();
    }
}
