using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSummonGhost : Spell
{
    public override void SpellEffect(Transform transform)
    {
        if (!AbleToCast())
            return;
        base.SpellEffect(transform);
        SpelsMehanics.CreateEvent(eventPrefab, transform);
    }

    public SpellSummonGhost(float cooldown, int manaRequired, int manaCost, GameObject eventPrefab, int sanityDamage = 0) : base(cooldown, manaRequired, manaCost, eventPrefab, sanityDamage) 
    {
        eventPrefab.GetComponent<ScaryEvent>().SanityDamage = sanityDamage;
    }
}
