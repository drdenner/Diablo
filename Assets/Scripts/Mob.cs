﻿using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	public float speed;
	public float range;
	public Transform player;
	public CharacterController controller;
	public AnimationClip run;
	public AnimationClip idle;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!inRange ()) {
			chase ();
		} else {
			GetComponent<Animation>().CrossFade(idle.name);
		}

	}

	bool inRange() {
		if (Vector3.Distance (transform.position, player.position) < range) {
			return true;		
		} else {
			return false;
		}
	}

	void chase() {
		transform.LookAt (player.position);
		controller.SimpleMove (transform.forward * speed);
		GetComponent<Animation>().CrossFade(run.name);
	}

	void OnMouseOver() {
		player.GetComponent<Combat>().opponent = gameObject;
	}
}
