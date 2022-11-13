using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UISC : MonoBehaviour
{

    public GameObject spells;
    public Texture[] textures;
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
        GUI.Label(new Rect(screenCenter.x * 0f, screenCenter.y * 0f, 200, 80),"MANA: " + SpelsMehanics.Manna.ToString());


        if (GUI.Button(new Rect(screenCenter.x *.0f, screenCenter.y *1.7f, 80, 80), textures[0]))
        {
            spells.GetComponent<SpelsMehanics>().CastSpell(0);
        }
        if (GUI.Button(new Rect(screenCenter.x * .2f, screenCenter.y * 1.7f, 80, 80), textures[1]))
        {
            spells.GetComponent<SpelsMehanics>().CastSpell(1);
        }
    }
}