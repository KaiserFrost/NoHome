using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Animator animator; 
	public CharacterController2D controller;

	public float speed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private Manager food;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));//Sempre positivo, fazer animator

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
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
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
