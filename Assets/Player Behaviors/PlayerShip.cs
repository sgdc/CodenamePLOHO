using UnityEngine;
using System.Collections.Generic;

public class PlayerShip : MonoBehaviour {

    public ObjectPool BulletManager;
    public float speed = 3;
    public List<IWeapon> weapons = new List<IWeapon>();
    private static List<List<IWeapon>> weaponLoadouts = new List<List<IWeapon>>();

    private void LoadWeaponLayouts()
    {
        Transform[] weaponPositions = gameObject.GetComponentsInChildren<Transform>();
        weaponLoadouts.Add(new List<IWeapon> {  
            new LaserCannon(BulletManager, weaponPositions[1]),
            new LaserCannon(BulletManager, weaponPositions[2]) 
        });
        weaponLoadouts.Add(new List<IWeapon> {  
            new LaserCannon(BulletManager, weaponPositions[1]),
            new LaserCannon(BulletManager, weaponPositions[2]),
            new LaserCannon(BulletManager, weaponPositions[3]) 
        });
        weaponLoadouts.Add(new List<IWeapon> {  
            new LaserCannon(BulletManager, weaponPositions[1]),
            new LaserCannon(BulletManager, weaponPositions[2]),
            new LaserCannon(BulletManager, weaponPositions[4]),
            new LaserCannon(BulletManager, weaponPositions[5])
        });
        weaponLoadouts.Add(new List<IWeapon> {
            new LaserCannon(BulletManager, weaponPositions[1]),
            new LaserCannon(BulletManager, weaponPositions[2]),
            new LargeCannon(BulletManager, weaponPositions[3]),
            new LaserCannon(BulletManager, weaponPositions[4]),
            new LaserCannon(BulletManager, weaponPositions[5])
        });
    }

    public void Start()
    {
        LoadWeaponLayouts();
        weapons = weaponLoadouts[3];
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
