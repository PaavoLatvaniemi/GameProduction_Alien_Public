using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableRoomBehaviour : MonoBehaviour
{
    [SerializeField] float searchingRadius;
    [SerializeField] int searchingPriority;
    public float SearchingRadius => searchingRadius;
    public int SearchingPriority => searchingPriority;
    public bool playerInside { get; private set; }
    public bool isSearched { get; private set; }

    private void OnEnable()
    {
        SearchableRooms.AddRoom(this);
    }

    private void OnDisable()
    {
        SearchableRooms.RemoveRoom(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            isSearched = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInside = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, searchingRadius);
    }

    public bool SetIsSearched(bool state) => isSearched = state;
}
