using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public Player player;
    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!player.isPlaying)
        {
            cam.transform.position = new Vector3(0f, 17.5f, -30f);
        }
        else
        {
            cam.transform.position = new Vector3(0, 15, -25);
        }
	}
}
