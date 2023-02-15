using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public KeyCode key;
    public bool useDefaultKeyInHolder = false;

    public float coolDownTime;
    public float activeTime;

    /// <summary>
    /// Called once when the key is pressed
    /// </summary>
    /// <param name="abilityHolder"></param>
    public virtual void OnActivate(AbilityHolder abilityHolder)
    {
    }

    /// <summary>
    /// Called every frame when active
    /// </summary>
    /// <param name="abilityHolder"></param>
    public virtual void WhenActive(AbilityHolder abilityHolder)
    {
        
    }

    /// <summary>
    /// Called once when entering cooldown state (i.e. leaves active state)
    /// </summary>
    /// <param name="abilityHolder"></param>
    public virtual void OnCoolDown(AbilityHolder abilityHolder)
    {
        
    }
}