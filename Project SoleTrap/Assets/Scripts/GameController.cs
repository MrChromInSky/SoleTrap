using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int howManyHumans = 0;
    public Room ringRoom;
    public GameObject defat;

    public GameObject wygrana;
    public bool isss = false;
    private float timer = 0.1f;
    private float timer1 = 5f;
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
            futureRingRoom.lightForRingRoom.active = true;
            futureRingRoom.Intresting = 40;
            ringRoom = futureRingRoom;
        }
        if (howManyHumans == 0)
        {
            isss = true;
            wygrana.active = true;
        }
        if(isss)
            timer1 -= 1 * Time.deltaTime;

        if (timer1 <= 0)
            SceneManager.LoadScene(4);
    }

    public void Koniec() {

        isss = true;
        defat.active = true;
    }

}
