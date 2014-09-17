using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("P1ButtonA"))
        {
            Player p1 = GetComponent<Player>();
            p1.ship.Fire();
        }
	}
}
