using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeDisplay : MonoBehaviour
{
    [SerializeField] EntryCode entryCode;
    [SerializeField] TextMeshPro codeText;
    [SerializeField] MeshRenderer screenMesh;

    [SerializeField] Material displayOnMaterial;
    [SerializeField] Material displayOffMaterial;

    bool isOn;
 
    public void EnableDisplay()
    {
        codeText.gameObject.SetActive(true);
        codeText.text = entryCode.Code;
        screenMesh.material = displayOnMaterial;
        isOn = true;
    }

    public void DisableDisplay()
    {
        codeText.gameObject.SetActive(false);
        screenMesh.material = displayOffMaterial;
        isOn = false;
    }

    public void ToggleDisplay()
    {
        if (!isOn) EnableDisplay();
        else DisableDisplay();
    }
}
