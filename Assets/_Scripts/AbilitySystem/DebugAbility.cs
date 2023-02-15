using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/DebugAbility")]
public class DebugAbility : Ability
{
    public override void OnActivate()
    {
        XLogger.Log(Category.Ability,"TEST -- ACTIVATED");
    }

    public override void WhenActive()
    {
        XLogger.Log(Category.Ability,"TEST -- ACTIVE PERIOD");
    }

    public override void OnCoolDown()
    {
        XLogger.Log(Category.Ability,"TEST -- ENTER COOLDOWN");
    }
}