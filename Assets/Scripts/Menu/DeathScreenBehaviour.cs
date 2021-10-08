using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenBehaviour : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadLastCheckpointButton()
    {
        LevelManager.singleton.LoadLastCheckpoint();
    }

    public void ExitToMainMenuButton()
    {
        SceneManager.LoadScene("BetaMainMenu");
    }
}
