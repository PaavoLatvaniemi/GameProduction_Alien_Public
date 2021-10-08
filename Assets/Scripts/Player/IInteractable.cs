using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string InteractableName
    {
        get;
    }

    void OnInteract();
}
