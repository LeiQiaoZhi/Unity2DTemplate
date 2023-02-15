using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/DefaultWeapon")]
public class DefaultWeapon : Weapon
{
    public override void ShootBullet(WeaponHolder holder)
    {
        base.ShootBullet(holder);
    }
}
