using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponProperty")]
public class WeaponProperties : ScriptableObject
{
    public float secondsBetweenFire;

    [Tooltip("Half the width of fire positions in a direction")]
    public float halfWidth = 0.5f;

    public List<int> numBulletsTDLR;

    public Vector2 GetDirection(int directionIndex, Transform transform)
    {
        switch (directionIndex)
        {
            case 0:
                return transform.up;
            case 1:
                return -transform.up;
            case 2:
                return -transform.right;
            default:
                return transform.right;
        }
    }

    public float GetHorizontalOffset(int i, int numBullets)
    {
        if (numBullets == 1)
        {
            return 0;
        }

        return (2 * halfWidth) / (numBullets - 1) * i - halfWidth;
    }
}