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


	private Manager food;
	

	void Start() {
	
		rigidbody = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {

		horizontalMove += Input.GetAxisRaw("Horizontal") ;
		verticalMove += Input.GetAxisRaw("Vertical") ;
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//Sempre positivo, fazer animator

			Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
				movement = move.normalized * speed;

			
				
				
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
	}
}
