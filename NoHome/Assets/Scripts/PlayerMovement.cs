using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Animator animator; 
	//public CharacterController2D controller;

	public float speed = 1f;

	float horizontalMove = 0f;
	float verticalMove = 0f;
	bool jump = false;
	bool crouch = false;
	Vector2 movement;
	Rigidbody2D rigidbody;
	private bool m_FacingRight = true; 
	public bool stole = false;

	private Manager food;
	

	void Start() {
	
		rigidbody = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") ;
		verticalMove = Input.GetAxisRaw("Vertical") ;
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//Sempre positivo, fazer animator

			Vector2 move = new Vector2(horizontalMove,verticalMove);
				movement = move.normalized * speed;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
				
				if (horizontalMove > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (horizontalMove < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}

		if (Input.GetButtonDown("Jump"))
		{

			jump = true;
			animator.SetBool("isJumping", true);
		}

		food = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
	}

	void FixedUpdate ()
	{
		// Move our character
		//controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	
		rigidbody.MovePosition(rigidbody.position + movement * Time.fixedDeltaTime);
		jump = false;
	}

	public void OnLanding(){
		animator.SetBool("IsJumping", false);
	}

	void OnTriggerEnter2D(Collider2D colid){
		if(colid.CompareTag("Food")){

			Destroy(colid.gameObject);
			food.comida += 1;
		}
		if(colid.CompareTag("Steal"))
		{
			Destroy(colid.gameObject);
			food.stolenFood +=1;
			stole = true;
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
