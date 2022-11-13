using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int howManyHumans = 0;
    public Room ringRoom;

    private float timer = 0.1f;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0 && ringRoom == null)
        {
            Room futureRingRoom = FindObjectOfType<Room>();
            futureRingRoom.Type = Room.RoomType.ring;
            ringRoom = futureRingRoom;
        }
        if (howManyHumans == 0)
            Debug.Log("WIN!");
    }
}
