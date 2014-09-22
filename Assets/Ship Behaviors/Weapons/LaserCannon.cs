using UnityEngine;
using System.Collections;

public class LaserCannon : IWeapon
{
    private const float fireSpeed = 0.15f;
    private float lastFireTime;
    private ObjectPool pool;
    private Transform weaponPosition;

    public LaserCannon(ObjectPool p, Transform pos)
    {
        pool = p;
        weaponPosition = pos;
    }

    public void Fire()
    {
        if (Time.time > fireSpeed + lastFireTime)
        {
            lastFireTime = Time.time;
            GameObject bullet = pool.GetNextObject();
            if (bullet == null) return;

            bullet.transform.position = weaponPosition.position + new Vector3(0, 0.5f);
            bullet.transform.rotation = weaponPosition.rotation;
            bullet.SetActive(true);
        }
    }
}
