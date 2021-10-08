using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{
    [SerializeField] LevelData levelData;

    bool invoked;
    private void OnTriggerEnter(Collider other)
    {
        if (invoked) return;
        if (other.CompareTag("Player"))
        {
            SaveSystem.SavePlayer(other.GetComponent<Player>());
            SaveSystem.SaveLevel(levelData.levelName);
            invoked = true;
        }
    }
}
