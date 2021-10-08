using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sensor system for Alien

public class FieldOfView : MonoBehaviour
{
    public float radius;        // kuinka kaukana
    [Range(0, 360)]
    public float angle;
    [HideInInspector]public GameObject PlayerRef;

    [SerializeField] Vector3 targetPosOffset;    // Testing the offset sight detection.
    [SerializeField] LayerMask targetMask;      // put this on Player layer 
    [SerializeField] LayerMask obstructionMask; // redandent, soon to be removed

    public float targetDetectionCertainty;       // True when Alien can see player.
    [SerializeField] bool instantDetect;
    [SerializeField] float detectionTimeRange = 3.0f;
    [Range(1, 100)]
    [SerializeField] float slowCertaintyCoolDown = 3.0f;
    [Range(0,1)]
    [SerializeField] float detectionThreshold = 0.05f;



    private void Start()
    {
        PlayerRef = GameDirector.player.gameObject;  //Important! Finds the player for Alien.
    }

    public float FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = ((target.position + targetPosOffset) - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                RaycastHit hit;
                if (!Physics.Raycast(transform.position, directionToTarget, out hit, distanceToTarget, obstructionMask))
                {
                    Debug.Log("Alien: I can see the meat!");
                    CertaintyIncrease();
                    return targetDetectionCertainty;
                }
                else
                {
                    CertaintyDicrease();
                    return targetDetectionCertainty;
                }
            }
            else
            {
                CertaintyDicrease();
                return targetDetectionCertainty;
            }
        }
        else if (targetDetectionCertainty > 0)
            {
            CertaintyDicrease();
            return targetDetectionCertainty; 
        }

        CertaintyDicrease();
        return targetDetectionCertainty;
    }

    void CertaintyIncrease()
    {
        
        if (instantDetect)
        {
            targetDetectionCertainty = 1;
            return;
        }


        if (targetDetectionCertainty >= 1)
        {
            targetDetectionCertainty = 1;
            return;
        }

        if ((targetDetectionCertainty + (0.2f / detectionTimeRange)) > detectionThreshold)
        {
            targetDetectionCertainty += 0.2f / detectionTimeRange;
            return;
        }

    }
    void CertaintyDicrease()
    {
        if (targetDetectionCertainty <= 0)
        {
            targetDetectionCertainty = 0;
            return;
        }
        targetDetectionCertainty -= 0.2f/slowCertaintyCoolDown;
    }
}
