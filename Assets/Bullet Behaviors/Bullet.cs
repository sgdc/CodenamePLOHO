using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int Damage;
    public float Speed;

    void OnEnable()
    {
        Invoke("Kill", 1.7f);
    }

    void Kill()
    {
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        transform.position = transform.position + transform.up * Time.deltaTime * Speed;
	}
}
