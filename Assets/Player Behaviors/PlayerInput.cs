using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    Player p;

	// Use this for initialization
	void Start () {
        p = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("P1ButtonA"))
        {
            p.ship.Fire();
        }

        if (Input.GetAxis("P1JoystickH") > 0)
        {
            p.ship.transform.position = p.ship.transform.position + new Vector3(p.ship.speed, 0) * Time.deltaTime;
        }
        else if (Input.GetAxis("P1JoystickH") < 0)
        {
            p.ship.transform.position = p.ship.transform.position + new Vector3(-p.ship.speed, 0) * Time.deltaTime;
        }

        if (Input.GetAxis("P1JoystickV") > 0)
        {
            p.ship.transform.position = p.ship.transform.position + new Vector3(0, p.ship.speed) * Time.deltaTime;
        }
        else if (Input.GetAxis("P1JoystickV") < 0)
        {
            p.ship.transform.position = p.ship.transform.position + new Vector3(0, -p.ship.speed) * Time.deltaTime;
        }
	}
}
