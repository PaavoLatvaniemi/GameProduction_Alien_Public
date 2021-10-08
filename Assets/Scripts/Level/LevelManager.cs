using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager singleton;
    [SerializeField] LevelData[] levelDatas;
    public LevelData[] LevelDatas => levelDatas;

    private void Awake()
    {
        singleton = this;
    }

    public void LoadLastCheckpoint()
    {
        string savedLevelName = SaveSystem.GetSavedLevel();
        LevelData levelData = null;
        foreach (var level in levelDatas)
        {
            if (level.levelName == savedLevelName)
                levelData = level;
        }
        if (levelData != null)
            LoadLevelScenes(levelData);
        else
        {
            LoadLevelScenes(levelDatas[0]);
        }
    }

    public void LoadLevelScenes(LevelData level)
    {
        for (int i = 0; i < level.levelSceneNames.Length; i++)
        {
            if(i == 0)
                SceneManager.LoadScene(level.levelSceneNames[i]);
            else
                SceneManager.LoadScene(level.levelSceneNames[i], LoadSceneMode.Additive);
        }
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public LevelData GetLevelData(string levelName)
    {
        foreach (var level in levelDatas)
        {
            if (level.levelName == levelName)
                return level;
        }
        return null;
    }
}
