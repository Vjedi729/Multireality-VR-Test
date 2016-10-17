using UnityEngine;
using System.Collections;

public class ToggleMove : MonoBehaviour {
	bool moving = false;
	bool toggleMoveOn = true;

	float speed = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Take inputs: short press to start/stop moving, long press to toggle on or off this script.
		if(true){
			
		}

		//Move if the moving modifier is on
		if (moving) {
			transform.Translate (0, 0, speed);
		}
	}
}
