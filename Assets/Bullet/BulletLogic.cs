using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

    public int Damage;
    public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + transform.up * Time.deltaTime * Speed;
	}
}
