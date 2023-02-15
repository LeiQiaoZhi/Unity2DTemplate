using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public KeyCode defaultKey;

    /// <summary>
    /// State Pattern
    /// </summary>
    private IAbilityState _currentState;

    private float _nextAvailableTime;
    private float _activeUntilTime;

    private interface IAbilityState
    {
        void StateUpdate(AbilityHolder holder);
    }

    private class ReadyState : IAbilityState
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public void StateUpdate(AbilityHolder holder)
        {
            var key = (holder.ability.useDefaultKeyInHolder) ? holder.defaultKey : holder.ability.key;
            if (Input.GetKeyDown(key) && Time.time > holder._nextAvailableTime)
            {
                // transition
                XLogger.Log(Category.Ability, "Enter Active State");
                holder.ability.OnActivate(holder);
                holder._nextAvailableTime = Time.time + holder.ability.coolDownTime;
                holder._activeUntilTime = Time.time + holder.ability.activeTime;
                holder._currentState = new ActiveState();
            }
        }
    }

    private class ActiveState : IAbilityState
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public void StateUpdate(AbilityHolder holder)
        {
            if (Time.time > holder._activeUntilTime)
            {
                // transition
                XLogger.Log(Category.Ability, "Enter Cooldown State");
                holder.ability.OnCoolDown(holder);
                holder._currentState = new CoolDownState();
                return;
            }

            holder.ability.WhenActive(holder);
        }
    }

    private class CoolDownState : IAbilityState
    {
        public void StateUpdate(AbilityHolder holder)
        {
            if (Time.time >= holder._nextAvailableTime)
            {
                // transition
                XLogger.Log(Category.Ability, "Enter Ready State");
                holder._currentState = new ReadyState();
            }
        }
    }

    void Start()
    {
        if (ability == null)
        {
            XLogger.LogError(Category.Ability, "No ability in holder");
        }

        _currentState = new ReadyState();
    }

    void Update()
    {
        _currentState.StateUpdate(this);
    }
}