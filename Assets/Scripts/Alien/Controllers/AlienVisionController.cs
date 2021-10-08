using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Controls the Alien Vision using FieldOfViewCheck() method from FIeldOfView class
public class AlienVisionController : MonoBehaviour
{
    FieldOfView[] fieldOfViews;
    public bool targetDetected;



    public float targetDetectionCertainty;
    private void OnEnable()
    {
        if(fieldOfViews == null)
           fieldOfViews = GetComponentsInChildren<FieldOfView>();
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            float newFoVCertainty = 0f;
            foreach (var fov in fieldOfViews)
            {
               if(fov.FieldOfViewCheck() > newFoVCertainty)
               {
                    newFoVCertainty = fov.targetDetectionCertainty;
               }
               
            }
            targetDetectionCertainty = newFoVCertainty;

            if (newFoVCertainty <= 0)
            {
                targetDetected = false;
            }
            else if (newFoVCertainty >= 1)
            {
                targetDetected = true;
            }
        }
    }
}
