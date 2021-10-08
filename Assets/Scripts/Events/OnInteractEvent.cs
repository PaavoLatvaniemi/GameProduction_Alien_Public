using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnInteractEvent : MonoBehaviour, IInteractable
{
    [SerializeField] float delay;
    [SerializeField] string interactableName = "";
    [SerializeField] UnityEvent onInteract;

    public string InteractableName => interactableName;

    public void OnInteract()
    {
        if (delay > 0) StartCoroutine("EventDelay");
        else onInteract.Invoke();
    }

    IEnumerator EventDelay()
    {
        yield return new WaitForSeconds(delay);
        onInteract.Invoke();
    }
}
