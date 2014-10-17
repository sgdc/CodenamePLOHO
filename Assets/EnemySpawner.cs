using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public List<EnemyShip> enemyList;
    public ObjectPool BulletManager;
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 1.0f);
	}

    void SpawnEnemy()
    {
        EnemyShip newEnemy = (EnemyShip)Instantiate(enemyList[0]);
        newEnemy.BulletManager = BulletManager;
        newEnemy.path = iTweenPath.paths["SmallFighter1"];
    }
}
