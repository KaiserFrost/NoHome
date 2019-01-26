using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speedEnemy;

	private Transform target;
	private bool follow = false;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if( follow == true)
		FollowPlayer();
		

		if(Vector2.Distance(transform.position, target.position) < 3)
		{
			
		}
	}

	void FollowPlayer(){

		transform.position = Vector2.MoveTowards(transform.position, target.position,speedEnemy * Time.deltaTime);
	}

	void CheckPlayer(){
		if(GameObject.FindGameObjectWithTag("Player") ){}
	}
}
