﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speedEnemy;
	private Animator animator;
	private Transform target;
	private bool follow = false;
	private bool m_FacingRight = true; 
	Vector3 oldPos, currentPos;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
		oldPos = animator.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		currentPos = animator.transform.position;

		if( follow == true)
		transform.position = Vector2.MoveTowards(transform.position, target.position,speedEnemy * Time.deltaTime);
		else
		{
			animator.SetBool("isPatrolling", true);
		}
		if(oldPos.x > animator.transform.position.x && m_FacingRight == true)
		{
			Flip();
			m_FacingRight = false;
		}
		if(oldPos.x < animator.transform.position.x && m_FacingRight == false)
		{
			Flip();
			m_FacingRight = true;
		}
			Debug.Log("Distance" + Vector3.Distance(oldPos,transform.position));
		oldPos = currentPos;
		

	}

	void FollowPlayer(){

		
	}

	void CheckPlayer(){
		if(GameObject.FindGameObjectWithTag("Player") ){}
	}


	private void OnTriggerStay2D(Collider2D other) {
		
		if(other.tag == "Player")
		{
			if(other.GetComponent<PlayerMovement>().stole == true)
			{
				follow = true;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other) {

		if(other.tag == "Player" && other.GetComponent<PlayerMovement>().stole == true)
		{
			follow = false;
			other.GetComponent<PlayerMovement>().stole = false;
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
