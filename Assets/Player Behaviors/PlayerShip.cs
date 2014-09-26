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
            new QuickCannon(BulletManager, weaponPositions[1]),
            new QuickCannon(BulletManager, weaponPositions[2]),
            new LargeCannon(BulletManager, weaponPositions[3]),
            new LaserCannon(BulletManager, weaponPositions[4]),
            new LaserCannon(BulletManager, weaponPositions[5])
        });
    }

    public void Start()
    {
        LoadWeaponLayouts();
        weapons = weaponLoadouts[3];
        PlayerInput input = GetComponentInParent<PlayerInput>();
        input.OnButtonPressed += HandleInputs;
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

    public void HandleInputs(KeyCode e)
    {
        switch (e)
        {
            case KeyCode.A:
                {
                   Fire();
                   break;
                }

            case KeyCode.B:
                {
                    
                    break;
                }

            case KeyCode.C:
                {
                    
                    break;
                }

            case KeyCode.UpArrow:
                {
                    if (transform.position.y < 25)
                    {
                        transform.position = transform.position + new Vector3(0, speed) * Time.deltaTime;
                    }
                    break;
                }

            case KeyCode.DownArrow:
                {
                    if (transform.position.y > 2f)
                    {
                        transform.position = transform.position + new Vector3(0, -speed) * Time.deltaTime;
                    }
                    break;
                }
            case KeyCode.RightArrow:
                {
                    if (transform.position.x < 9)
                    {
                        transform.position = transform.position + new Vector3(speed, 0) * Time.deltaTime;
                        transform.eulerAngles = new Vector3(0, -7, 0);
                    }
                    break;
                }
            case KeyCode.LeftArrow:
                {
                    if (transform.position.x > -9)
                    {
                        transform.position = transform.position + new Vector3(-speed, 0) * Time.deltaTime;
                        transform.eulerAngles = new Vector3(0, 7, 0);
                    }
                    break;
                }
        }
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy Bullet")
        {
            Debug.Log("Ship was Hit");
            //Handle Collisions
            coll.gameObject.SetActive(false);
        }
    }

}
