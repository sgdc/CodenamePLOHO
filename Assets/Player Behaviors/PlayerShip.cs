using UnityEngine;
using System.Collections.Generic;

public class PlayerShip : MonoBehaviour {

    public ObjectPool BulletManager;
    public GameObject laserCannon;
    public float speed = 3;
    public List<IWeapon> weapons = new List<IWeapon>();
    private static List<List<IWeapon>> weaponLoadouts = new List<List<IWeapon>>();

    public void Start()
    {
        Transform[] weaponPositions = gameObject.GetComponentsInChildren<Transform>();
        weaponLoadouts.Add(new List<IWeapon> {  
            new LaserCannon(BulletManager, weaponPositions[1]),
            new LaserCannon(BulletManager, weaponPositions[2]) 
        });
        weaponLoadouts.Add(new List<IWeapon> {  
            new LaserCannon(BulletManager, weaponPositions[1]),
            new LaserCannon(BulletManager, weaponPositions[2]),
            new LargeCannon(BulletManager, weaponPositions[3]) 
        });

        weapons = weaponLoadouts[1];
    }

    public void Fire()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].Fire();
        }
    }

    public void Update()
    {
        
    }
}
