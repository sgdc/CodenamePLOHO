using UnityEngine;
using System.Collections.Generic;

public class EnemyShip : MonoBehaviour {

    public bool CanFire;
    public float Speed;
    public int Health;
    public ObjectPool BulletManager;
    public iTweenPath path;

    private IWeapon weapon;
    private float pathTime;
    private List<List<IWeapon>> weaponLoadouts = new List<List<IWeapon>>();

    private void Fire()
    {
        weapon.Fire();
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start ()
    {
        Transform[] weaponPositions = gameObject.GetComponentsInChildren<Transform>();
        pathTime = 0;
        weapon = new EnemyCannon(BulletManager, weaponPositions[1]);
	}
	
	// Update is called once per frame
	void Update ()
    {
        pathTime += Time.deltaTime * Speed * 0.03f;
        iTween.PutOnPath(gameObject, path.nodes.ToArray(), pathTime);

        if (Health <= 0)
        {
            Kill();
        }

        if (CanFire)
        {
            Fire();
        }
	}

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player Bullet")
        {
            Health -= coll.GetComponent<PlayerBullet>().Damage;
            //Handle Collisions
            coll.gameObject.SetActive(false);
        }
    }
}
