using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {

    public float speed;
    public float rot_speed;
    public GameObject playerShip;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(1, 1, 1), rot_speed * Time.deltaTime);
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        
	}
}
