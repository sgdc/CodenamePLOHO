using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    public ObjectPool BulletManager;
    public float fireSpeed = 0.1f;
    private float lastFireTime = 0;

    public void Fire()
    {
        Debug.Log("Firing!");

        if (Time.time - lastFireTime > fireSpeed)
        {
            lastFireTime = Time.time;
            GameObject bullet = BulletManager.GetNextObject();
            if (bullet == null) return;

            bullet.transform.position = transform.position + new Vector3(0, 0.5f);
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}
