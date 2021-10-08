using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    public Transform head { get; private set; }
    [SerializeField] PlayableDirector deathTimeline;
    [SerializeField] bool LoadSavedPlayerPosition = true;
    [SerializeField] UnityEvent OnDeath;

    FirstPersonAIO firstPersonAIO;
    CameraFOV cameraFOV;
    Rigidbody rb;

    private void Awake()
    {
        GameDirector.AssignPlayer(this);
        if(LoadSavedPlayerPosition)
            SaveSystem.LoadPlayer(this);
    }
    private void Start()
    {
        firstPersonAIO = GetComponent<FirstPersonAIO>();
        cameraFOV = GetComponentInChildren<CameraFOV>();
        rb = GetComponent<Rigidbody>();
        head = GetComponentInChildren<Camera>().transform;
        HidingManager.PlayerResetHiding();
    }

    public void FPSControllerEnabled(bool state)
    {
        firstPersonAIO.enabled = state;
        rb.isKinematic = !state;
    }
    public void StartKillSequence()
    {
        deathTimeline.Play();
        OnDeath.Invoke();
        HidingManager.PlayerResetHiding();
        firstPersonAIO.enabled = false;
        GetComponentInChildren<RotateTowards>().
            StartRotation(GameDirector.alien.killCamLookTarget);

        rb.isKinematic = true;
        cameraFOV.Zoom(40f);
        Invoke("RestartGame", 5.2f);
    }

    void RestartGame()
    {
        GameDirector.SetAlienActive(false);
        SceneManager.LoadScene("DeathScreen");
    }
}
