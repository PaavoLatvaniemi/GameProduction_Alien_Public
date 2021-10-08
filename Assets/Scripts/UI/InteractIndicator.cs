using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractIndicator : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] TextMeshProUGUI actionText;

    public bool IsActive => indicator.activeSelf;
    public void ShowIndicator() => indicator.SetActive(true);
    public void HideIndicator() => indicator.SetActive(false);

    public void SetActionText(string text)
    {
        if (text == actionText.text) return;
        actionText.text = text;
    }
}
