using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] LevelData level;

    public void Change()
    {
        LevelManager.singleton.LoadLevelScenes(level);
    }
}
