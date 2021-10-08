using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntryCode : MonoBehaviour
{
    [SerializeField] string code;
    [SerializeField] bool generateRandomCode = true;
    [SerializeField] int numberOfDigits = 4;
    [SerializeField] EntryCodeUI entryCodeUI;
    [Header("Audio"), SerializeField] AudioClip interactClip;
    [SerializeField] AudioClip correctCodeClip;
    [SerializeField] AudioClip wrongCodeClip;
    [Space]
    [SerializeField] UnityEvent OnCorrectCodeEntered;
    [SerializeField] UnityEvent OnWrongCodeEntered;

    AudioSource audioSource;
    bool interactEnabled;

    public string Code => code;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(generateRandomCode)
            code = CodeGeneration.GenerateRandomCode(numberOfDigits, 0, 10);
    }

    public void InteractEnter()
    {
        GameDirector.player.FPSControllerEnabled(false);
        entryCodeUI.Initialize();
        interactEnabled = true;
        PlayAudioClip(interactClip);
    }

    public void InteractExit()
    {
        GameDirector.player.FPSControllerEnabled(true);
        entryCodeUI.Hide();
        interactEnabled = false;
    }

    void EnterCode()
    {
        if (code == entryCodeUI.GetCode())
        {
            OnCorrectCodeEntered.Invoke();
            InteractExit();
            PlayAudioClip(correctCodeClip);
        }
        else
        {
            OnWrongCodeEntered.Invoke();
            InteractExit();
            PlayAudioClip(wrongCodeClip);
        }
    }

    void PlayAudioClip(AudioClip clip)
    {
        if (audioSource == null || clip == null) return;
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void Update()
    {
        if (!interactEnabled) return;

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            EnterCode();

        if (Input.GetKeyDown(KeyCode.Escape)) InteractExit();
    }
}
