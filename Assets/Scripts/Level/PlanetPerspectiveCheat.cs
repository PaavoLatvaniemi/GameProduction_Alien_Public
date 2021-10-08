using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPerspectiveCheat : MonoBehaviour
{
    Transform player;
    private void Start()
    {
        player = GameDirector.player.transform;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
    }
}
