using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public float speed;
	private Vector3 position;
	public CharacterController controller;
	public AnimationClip run;
	public AnimationClip idle;


	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Click Mouse Left
		if (Input.GetMouseButton (0)) {
			getLocation();
		}
		moveToPosition ();	
	}

	// Get Current Position
	void getLocation() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray, out hit, 1000)) {
			position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
		}
	
	}

	void moveToPosition() {
		if (Vector3.Distance (transform.position, position) > 1.1) {
			Quaternion newRotation = Quaternion.LookRotation (position - transform.position);
			newRotation.x = 0f;
			newRotation.z = 0f;
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 1000);
			controller.SimpleMove (transform.forward * speed);
			GetComponent<Animation>().CrossFade(run.name);
		} else {
			GetComponent<Animation>().CrossFade(idle.name);

		}
	}


}
