using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SavingNotification : MonoBehaviour
{
    [SerializeField] PlayableDirector notificationTimeline;

    private void Awake()
    {
        SaveSystem.OnPlayerSave += ShowNotification;
    }

    private void OnDestroy()
    {
        SaveSystem.OnPlayerSave -= ShowNotification;
    }

    void ShowNotification()
    {
        if(notificationTimeline != null)
            notificationTimeline.Play();
    }
}
