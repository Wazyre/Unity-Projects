using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody2D rb; // the rigid body of the player
	private int score;
	public Text countText;
	public Text winText;
	SpriteRenderer my_sprite;

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
		score = 0;
		winText.text = "";
		SetScore();
		my_sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		hMove = Input.GetAxisRaw("Horizontal") * speed;
		FlipSprite();
		UnFlipSprite();
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

	void FlipSprite(){
		if (hMove < 0){
			my_sprite.flipX = true;
		}
	}

	void UnFlipSprite(){
		if (hMove > 0){
			my_sprite.flipX = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Jem") {
			score += 1;
			col.gameObject.SetActive (false);
			SetScore();
		}
		else if (col.gameObject.tag == "Finish") {
			winText.text = "You Win!";
		}

	}

	void SetScore()
	{
		countText.text = "Count: " + score.ToString ();
	}
}
