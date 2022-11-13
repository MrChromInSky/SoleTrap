using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UISC : MonoBehaviour
{

    public GameObject spells;

    private Vector2 screenCenter;

    void Start()
    {
        screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(screenCenter.x *.4f, screenCenter.y *0.3f, 60, 60), "GHOST"))
        {
            spells.GetComponent<SpelsMehanics>().CastSpell(0);
        }
    }
}
