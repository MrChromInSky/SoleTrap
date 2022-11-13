using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell
{
    protected float cooldown;
    protected float cooldownTimer = 0f;
    protected int manaRequired;
    protected int manaCost;
    protected int sanityDamage;

    protected GameObject eventPrefab;

    public void UpdateCooldown(float passedTime)
    {
        cooldownTimer += passedTime;
    }

    public bool AbleToCast()
    {
        return cooldownTimer >= cooldown && SpelsMehanics.Manna >= manaRequired;
    }

    public virtual void SpellEffect(Transform transform)
    {
        SpelsMehanics.Manna -= manaCost;
        cooldownTimer = 0f;
    }

    public Spell(float cooldown, int manaRequired, int manaCost, GameObject eventPrefab, int sanityDamage = 0)
    {
        this.cooldown = cooldown;
        this.manaRequired = manaRequired;
        this.manaCost = manaCost;
        this.sanityDamage = sanityDamage;
        this.eventPrefab = eventPrefab;
    }
}
