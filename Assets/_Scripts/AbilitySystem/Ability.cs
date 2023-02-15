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
    public virtual void OnActivate()
    {
    }

    /// <summary>
    /// Called every frame when active
    /// </summary>
    public virtual void WhenActive()
    {
        
    }

    /// <summary>
    /// Called once when entering cooldown state (i.e. leaves active state)
    /// </summary>
    public virtual void OnCoolDown()
    {
        
    }
}