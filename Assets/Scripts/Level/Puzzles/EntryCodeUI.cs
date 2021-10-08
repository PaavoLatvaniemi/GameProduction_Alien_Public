using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntryCodeUI : MonoBehaviour
{
    [SerializeField] TMP_InputField codeInputField;
    [SerializeField] GameObject InputUI;

    public void Initialize()
    {
        codeInputField.text = "";
        InputUI.SetActive(true);
        codeInputField.Select();
        codeInputField.ActivateInputField();
    }

    public void Hide()
    {
        InputUI.SetActive(false);
    }

    public string GetCode()
    {
        return codeInputField.text;
    }
}