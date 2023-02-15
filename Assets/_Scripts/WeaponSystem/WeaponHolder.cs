using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Weapon weapon;
    private float _nextFireTime;

    public void Fire()
    {
        if (Time.time < _nextFireTime)
        {
            return;
        }
        
        weapon.ShootBullet(this);
        
        _nextFireTime = Time.time + weapon.weaponProperties.secondsBetweenFire;
    }
}