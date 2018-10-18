using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSettings : MonoBehaviour {

	GameObject my_sprite;
	SpriteRenderer my_rend;

	// Use this for initialization
	void Start () {
		my_sprite = GameObject.Find("Sprite");
		my_rend = my_sprite.GetComponent<SpriteRenderer>();
		my_rend.color = Color.blue;
	}


	private void Awake()
	{

	}


	// Update is called once per frame
	void Update () {
	}
}
