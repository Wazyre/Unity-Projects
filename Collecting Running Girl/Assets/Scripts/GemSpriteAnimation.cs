using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpriteAnimation : MonoBehaviour {
	[SerializeField] private Sprite[] frames;
	[SerializeField] private float fps = 8f;
	SpriteRenderer my_sprite;

	// Use this for initialization
	void Start () {
		my_sprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		int index = (int)(Time.time * fps) % frames.Length;
    my_sprite.sprite = frames[index];
	}
}
