using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    private List<GameObject> pool;
    public GameObject pooledObject;
    public bool canGrow = true;
    public int initialSize = 300;

	void Start () {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
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
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
        }

        return null;
    }
}
