using UnityEngine;
using System.Collections;
using System;

public class PlayerInput : MonoBehaviour {

    Player p;
    public delegate void ButtonPressed(KeyCode e);
    public event ButtonPressed OnButtonPressed;

	// Use this for initialization
	void Start () {
        p = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        p.ship.transform.eulerAngles = new Vector3();

        if (Input.GetButton("P1ButtonA"))
        {
            OnButtonPressed(KeyCode.A);
        }

        if (Input.GetButton("P1ButtonB"))
        {
            OnButtonPressed(KeyCode.B);
        }

        if (Input.GetButton("P1ButtonC"))
        {
            OnButtonPressed(KeyCode.C);
        }

        if (Input.GetAxis("P1JoystickH") > 0)
        {
            OnButtonPressed(KeyCode.RightArrow);
        }
        else if (Input.GetAxis("P1JoystickH") < 0)
        {
            OnButtonPressed(KeyCode.LeftArrow);
        }

        if (Input.GetAxis("P1JoystickV") > 0)
        {
            OnButtonPressed(KeyCode.UpArrow);
        }
        else if (Input.GetAxis("P1JoystickV") < 0)
        {
            OnButtonPressed(KeyCode.DownArrow);
        }
	}
}
