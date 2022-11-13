using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMuveObjects : Spell
{
    public override void SpellEffect(Transform transform)
    {
        if (!AbleToCast())
            return;
        base.SpellEffect(transform);
        SpelsMehanics.CreateEvent(eventPrefab, transform);
    }

    public SpellMuveObjects(float cooldown, int manaRequired, int manaCost, GameObject eventPrefab, int sanityDamage = 0) : base(cooldown, manaRequired, manaCost, eventPrefab, sanityDamage)
    {
        eventPrefab.GetComponent<ScaryEvent>().SanityDamage = sanityDamage;
    }
}
