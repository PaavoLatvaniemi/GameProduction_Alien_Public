using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScenesOnAwake : MonoBehaviour
{
    [SerializeField] string[] names;
    private void Awake()
    {
        foreach (var scene in names)
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);

    }
}
