using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class alienAI_script : MonoBehaviour
{
    NavMeshAgent alienAgent;
    GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        //food = GameObject.FindGameObjectWithTag("Player");
        //alienAgent.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //alienAgent.SetDestination(food.transform.position);
    }
}
