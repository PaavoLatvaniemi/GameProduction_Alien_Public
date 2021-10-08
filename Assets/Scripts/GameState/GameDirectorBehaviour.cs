using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorBehaviour : MonoBehaviour
{
    [SerializeField] bool SetAlienActiveOnStart;
    public void SetShouldAlienRetreat(bool state) => GameDirector.shouldAlienRetreat = state;

    public void SetAlienActive(bool state) => GameDirector.SetAlienActive(state);

    private void Start()
    {
        if (SetAlienActiveOnStart) GameDirector.SetAlienActive(true);
        else GameDirector.SetAlienActive(false);
    }
}
