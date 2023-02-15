using UnityEngine;

public class Weapon : ScriptableObject
{
    public GameObject bulletPrefab;
    public float firePointOffset = 0.5f;

    public WeaponProperties weaponProperties;

    // ReSharper disable Unity.PerformanceAnalysis
    public virtual void ShootBullet(WeaponHolder holder)
    {
        for (int directionIndex = 0; directionIndex < 4; directionIndex++)
        {
            int numBullets = weaponProperties.numBulletsTDLR[directionIndex];
            for (int i = 0; i < numBullets; i++)
            {
                Vector2 direction = weaponProperties.GetDirection(directionIndex, holder.transform).normalized;
                Vector2 tangentRight = new Vector2(direction.y, -direction.x).normalized;
                Vector2 bulletPos =
                    holder.transform.position
                    + (Vector3)direction* firePointOffset
                    + (Vector3)tangentRight * weaponProperties.GetHorizontalOffset(i, numBullets);
                
                var bullet = Instantiate(bulletPrefab,bulletPos,holder.transform.rotation);
                bullet.GetComponent<Bullet>().Init(direction.normalized);
                
            }
        }
    }
}