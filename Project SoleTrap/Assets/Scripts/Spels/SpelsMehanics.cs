using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelsMehanics : MonoBehaviour
{
    public const float CooldownRecoverySpeed = 1f;

    [Header("Properties")]
    [SerializeField] private static float manna = 0f;
    public static float Manna
    {
        set { manna = value; }
        get { return manna; }
    }
    [SerializeField] private float magicNumber = 1f;
    public float MagicNumber
    {
        set { magicNumber = value; }
        get { return magicNumber; }
    }

    [SerializeField]
    private GameObject[] prefabs;
    [HideInInspector]
    public static List<Spell> spellList = new List<Spell>();

    void Start()
    {
        spellList.Add(new SpellSummonGhost(40, 45, 15, prefabs[0], 2));
    }

    void Update()
    {
        manna += magicNumber * Time.deltaTime;
        foreach (Spell spell in spellList)
        {
            spell.UpdateCooldown(CooldownRecoverySpeed * Time.deltaTime);
        }
    }

    public void CastSpell(int index)
    {
        spellList[index].SpellEffect(transform);
    }

    public static void CreateEvent(GameObject eventToCreate, Transform transform)
    {
        GameObject ghost = Instantiate(eventToCreate, transform);
    }
}