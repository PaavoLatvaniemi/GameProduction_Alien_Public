using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    public delegate void SavePlayerDelegate();
    public static event SavePlayerDelegate OnPlayerSave;
    public static void SavePlayer(Player player)
    {        
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.Save();
        Debug.Log("Played Saved");
        OnPlayerSave?.Invoke();
    }

    public static void SaveLevel(string levelName)
    {
        PlayerPrefs.SetString("LevelName", levelName);
        PlayerPrefs.Save();
        Debug.Log("Level Saved");
    }

    public static void LoadPlayer(Player player)
    {
        if(PlayerPrefs.HasKey("PlayerX"))
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
    }

    public static string GetSavedLevel()
    {
        return PlayerPrefs.GetString("LevelName");
    }
}
