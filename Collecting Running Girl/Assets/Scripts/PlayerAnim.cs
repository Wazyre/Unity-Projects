﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Horizontal")) {
			anim.SetTrigger ("IdleToWalk");
		} 
		else {
			anim.SetTrigger ("WalkToIdle");
		}
	}
}
