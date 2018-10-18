using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody2D rb; // the rigid body of the player

	[Space]
	[Header("Movement Logic")]

	private Vector3 movement;	// holds the transform vectors for the player
	public float speed = 10f;	// dictates how fast the player will move
	private float hMove = 0f;	// dictates the horizontal movement

	[Space]
	[Header("Jump Logic")]

	public float jumpForce = 200f;
	public bool grounded;
	public Transform groundCheck;
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
		movement = Vector3.zero;
		grounded = true;
	}

	// Update is called once per frame
	void Update () {
		hMove = Input.GetAxisRaw("Horizontal") * speed;

		if (grounded && Input.GetButtonDown("Jump"))
		{
			grounded = false;
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
		}
	}

	void FixedUpdate()
	{
		Vector3 targetVelocity = new Vector2(hMove * 10f * Time.fixedDeltaTime, rb.velocity.y);
		rb.velocity = targetVelocity;

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
	}
}
