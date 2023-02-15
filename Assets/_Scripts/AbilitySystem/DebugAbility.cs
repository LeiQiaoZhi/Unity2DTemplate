using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/DebugAbility")]
public class DebugAbility : Ability
{
    public override void OnActivate(AbilityHolder abilityHolder)
    {
        XLogger.Log(Category.Ability,"TEST -- ACTIVATED");
    }

    public override void WhenActive(AbilityHolder abilityHolder)
    {
        XLogger.Log(Category.Ability,"TEST -- ACTIVE PERIOD");
    }

    public override void OnCoolDown(AbilityHolder abilityHolder)
    {
        XLogger.Log(Category.Ability,"TEST -- ENTER COOLDOWN");
    }
}