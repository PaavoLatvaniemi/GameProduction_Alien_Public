using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuBehaviour : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NewGameButton()
    {
        PlayerPrefs.DeleteAll();
        LevelManager.singleton.LoadLastCheckpoint();
    }

    public void ContinueButton()
    {
        LevelManager.singleton.LoadLastCheckpoint();
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
