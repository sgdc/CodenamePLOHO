using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    private List<GameObject> pool;
    public GameObject pooledObject;
    public bool canGrow = true;
    public int initialSize = 300;

	void Start () {
        pool = new List<GameObject>();
        for (int i = 0; i < initialSize; i++)
        {
            GameObject bullet = InitBullet();
            pool.Add(bullet);
        }
	}

    public GameObject GetNextObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        if (canGrow)
        {
            GameObject obj = InitBullet();
            pool.Add(obj);
            return obj;
        }

        return null;
    }

    GameObject InitBullet()
    {
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.transform.parent = this.transform;
        obj.SetActive(false);
        return obj;
    }
}
