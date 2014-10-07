using UnityEngine;
using System.Collections.Generic;

public class EnemyShip : MonoBehaviour {

    public bool CanFire;
    public float Speed;
    public int Health;
    public ObjectPool BulletManager;
    public iTweenPath path;
    public Floater floater;

    private IWeapon weapon;
    private float pathTime;
    private List<List<IWeapon>> weaponLoadouts = new List<List<IWeapon>>();

    private void Fire()
    {
        weapon.Fire();
    }

    private void Kill()
    {
        for (int i = 0; i < Random.Range(1,3); i++)
            Instantiate(floater,transform.position + new Vector3(Random.insideUnitCircle.x,Random.insideUnitCircle.y),transform.rotation);
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
