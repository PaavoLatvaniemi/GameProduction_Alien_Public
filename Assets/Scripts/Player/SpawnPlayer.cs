using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    private void Awake()
    {
        Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}
