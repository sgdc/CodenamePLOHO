using UnityEngine;
using System.Collections;

public class QuickCannon : IWeapon
{
    private const float fireSpeed = 0.075f;
    private const int weaponDamage = 1;
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
            PlayerBullet pb = pool.GetNextObject().GetComponent<PlayerBullet>();
            if (pb == null) return;

            pb.transform.position = weaponPosition.position + new Vector3(0, 0.5f);
            pb.transform.rotation = weaponPosition.rotation;
            pb.Damage = weaponDamage;
            pb.gameObject.SetActive(true);
        }
    }
}
