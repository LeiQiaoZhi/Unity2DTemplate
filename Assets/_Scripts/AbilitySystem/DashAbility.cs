using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/DashAbility")]
public class DashAbility : Ability
{
    public float dashSpeedMultiplier;
    private float _normalSpeed;

    private Rigidbody2D _rb;
    public override void OnActivate(AbilityHolder abilityHolder)
    {
        _normalSpeed = abilityHolder.GetComponent<Movement>().movementSettings.moveSpeed;
        abilityHolder.GetComponent<Movement>().movementSettings.moveSpeed *= dashSpeedMultiplier;
        _rb = abilityHolder.GetComponent<Rigidbody2D>();
    }

    public override void WhenActive(AbilityHolder abilityHolder)
    {
        _rb.velocity = _rb.velocity.normalized * dashSpeedMultiplier;
    }

    public override void OnCoolDown(AbilityHolder abilityHolder)
    {
        abilityHolder.GetComponent<Movement>().movementSettings.moveSpeed = _normalSpeed;
    }
}