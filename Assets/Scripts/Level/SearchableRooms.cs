using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchableRooms
{
    static List<SearchableRoomBehaviour> availableRooms = new List<SearchableRoomBehaviour>();
    public static void AddRoom(SearchableRoomBehaviour room) => availableRooms.Add(room);
    public static void RemoveRoom(SearchableRoomBehaviour room) => availableRooms.Remove(room);

    public static SearchableRoomBehaviour GetAvailableRoom()
    {
        if (availableRooms.Count == 0) return null;

        int highestPriority = 0;
        SearchableRoomBehaviour searchableRoom = null;
        foreach (var room in availableRooms)
        {
            if (room.isSearched) continue;
            if(room.SearchingPriority > highestPriority)
            {
                searchableRoom = room;
                highestPriority = room.SearchingPriority;
            }
        }
        if (highestPriority > 0)
            return searchableRoom;

        int i = Random.Range(0, availableRooms.Count);
        return availableRooms[i];
    }

    public static SearchableRoomBehaviour GetAvailableRoomWithPlayerInside()
    {
        foreach (var room in availableRooms)
        {
            if (room.playerInside) return room;
        }
        return null;
    }

    public static bool RoomsAvailable => availableRooms.Count > 0;
}
