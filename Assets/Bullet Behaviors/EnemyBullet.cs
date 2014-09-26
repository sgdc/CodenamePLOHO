using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

    public int Damage = 1;
    public float Speed = 4;

    void OnEnable()
    {
        Invoke("Kill", 8.5f);
    }

    void Kill()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke("Kill");
    }

	// Update is called once per frame
	void Update () {
        transform.position = transform.position + transform.up * Time.deltaTime * Speed;
	}
}
