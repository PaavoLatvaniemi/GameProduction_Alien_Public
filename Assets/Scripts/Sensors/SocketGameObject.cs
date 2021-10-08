using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SocketGameObject : MonoBehaviour
{
    [SerializeField] Transform socketTransform;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = socketTransform.position;
        transform.SetParent(socketTransform);
    }
}
