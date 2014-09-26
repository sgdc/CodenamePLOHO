using UnityEngine;
using System.Collections;

public class QuickCannon : IWeapon
{
    private const float fireSpeed = 0.075f;
    private float lastFireTime;
    private ObjectPool pool;
    private Transform weaponPosition;

    public QuickCannon(ObjectPool p, Transform pos)
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
