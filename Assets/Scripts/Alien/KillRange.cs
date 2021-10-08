using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRange : MonoBehaviour
{
    bool _inKillRange;
    public bool inKillRange => _inKillRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _inKillRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _inKillRange = false;
    }
}
