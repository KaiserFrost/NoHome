using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speedEnemy;
	private Animator animator;
	private Transform target;
	private bool follow = false;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if( follow == true)
		transform.position = Vector2.MoveTowards(transform.position, target.position,speedEnemy * Time.deltaTime);
		else
		{
			animator.SetBool("isPratolling", true);
		}
		if(Vector2.Distance(transform.position, target.position) < 3)
		{
			
		}
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
}
